using Masuda.QQNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;
namespace Masuda.QQNT;

public class NTBot
{
    public required BotConfig BotConfig { get; init; }
    private ClientWebSocket _client;
    private Thread _thread;


    #region 事件
    public event Action<NTBot, MessageBase[]> OnMessage;
    public event Action<NTBot, MasudaMessage> OnGroupMessage;
    #endregion

    MemoryCache memoryCache = new MemoryCache(new MemoryCacheOptions() { });


    public async Task LaunchAsync()
    {
        Uri uri = new Uri($"ws://{BotConfig.IPAddress}");
        _client = new ClientWebSocket();
        await _client.ConnectAsync(uri, CancellationToken.None);
        _thread = new Thread(async () => await Receive(_client));
        _thread.Start();
    }

    internal async Task MessageHandlerAsync(string message)
    {
        System.Console.WriteLine(message);
        // return;
        ProtoEvent protoEvent;
        try
        {
            protoEvent = JsonSerializer.Deserialize<ProtoEvent>(message);
        }
        catch (Exception)
        {
            return;
        }
        switch (protoEvent.EventType)
        {
            case EventType.Message:
                var messageData = protoEvent.Data.GetData<MasudaMessage>();
                if (messageData.Peer.ChatType == "group")
                {
                    OnGroupMessage?.Invoke(this, messageData);
                }
                break;
            case EventType.FriendMessage:
                // OnMessage?.Invoke(this, protoEvent.Message);
                break;
            case EventType.GroupMessage:
                // OnMessage?.Invoke(this, protoEvent.Message);
                break;
            case EventType.TempMessage:
                // OnMessage?.Invoke(this, protoEvent.Message);
                break;
            case EventType.GetUserInfo:
                var userInfo = protoEvent.Data.GetData<QQUserInfo>();
                memoryCache.Set(userInfo.Uid, userInfo, TimeSpan.FromHours(1));
                break; 


            default:
                break;
        }
    }

    async Task Send(ClientWebSocket client, string data)
    {
        byte[] buffer = Encoding.UTF8.GetBytes(data);
        await client.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
    }

    async Task Receive(ClientWebSocket client)
    {
        byte[] buffer = new byte[1024];
        StringBuilder sb = new StringBuilder();
        while (true)
        {
            var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                sb.Append(message);
                if (message.EndsWith("[end]")) {
                    sb.Remove(sb.Length - 5, 5);
                    message = sb.ToString();
                    sb.Clear();
                    await MessageHandlerAsync(message);
                }
                // Console.WriteLine("Received: " + message);
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                Console.WriteLine("Connection closed.");
                break;
            }
        }
    }



    #region MessageMethod
    public async Task SendFriendMessageAsync(string target, params MessageBase[] message)
    {
        await SendMessageCoreAsync(target, CommandType.SendFriendMessage, message);
    }

    public async Task SendGroupMessageAsync(string group, string message) {
        await SendGroupMessageAsync(group, new PlainMessage {Content = message});
    }
    public async Task SendMessageAsync(Peer peer, string message)
    {
        if (peer.ChatType == "group")
            await SendGroupMessageAsync(peer.Uid, new PlainMessage { Content = message });
        else
            await SendFriendMessageAsync(peer.Uid, new PlainMessage { Content = message });
    }
    private async Task SendMessageCoreAsync(string target, CommandType commandType, params MessageBase[] message)
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = commandType,
            Data = new SendMessageComand
            {
                Target = target,
                MessageChain = message
            }
        }, new JsonSerializerOptions
        {
            Converters = { new MessageJsonConverter() },
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        });
        await Send(_client, data);
    }
    public async Task SendGroupMessageAsync(string group, params MessageBase[] message)
    {
        await SendMessageCoreAsync(group, CommandType.SendGroupMessage, message);
    }
    #endregion


    #region GetInfoMethod
    public async Task<QQUserInfo> GetUserInfoAsync(string uid)
    {
        if (memoryCache.TryGetValue<QQUserInfo>(uid, out var userInfo))
        {
            return userInfo;
        }
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.GetUserInfo,
            Data = new 
            {
                Uid = uid
            }
        });
        await Send(_client, data);
        while (!memoryCache.TryGetValue<QQUserInfo>(uid, out userInfo))
        {
            await Task.Delay(100);
        }
        return userInfo;
    }
    public async Task GetGroupListAsync(bool forced = false)
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.GetGroupList,
            Data = new { 
                forced
            }
        });
        await Send(_client, data);
    }
    public async Task GetFriendListAsync(bool forced = false)
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.GetFriendList,
            Data = new {
                forced
            }
        });
        await Send(_client, data);
    }
    public async Task GetAccountInfoAsync()
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.GetAccountInfo,
            Data = new { }
        });
        await Send(_client, data);
    }
    public async Task GetPeerAsync(string uid)
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.GetPeer,
            Data = new { Uid = uid }
        });
        await Send(_client, data);
    }
    #endregion
}
