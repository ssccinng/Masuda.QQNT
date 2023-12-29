using Masuda.QQNT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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
                OnGroupMessage?.Invoke(this, JsonSerializer.Deserialize<MasudaMessage>(protoEvent.Data,
                    new JsonSerializerOptions
                    {
                        Converters = { new MessageJsonConverter() }
                    }
                ));
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
        while (true)
        {
            var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            if (result.MessageType == WebSocketMessageType.Text)
            {
                string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                await MessageHandlerAsync(message);
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
    public async Task SendMessagesAsync(string target, params MessageBase[] message)
    {

    }

    public async Task SendGroupMessageAsync(string group, string message) {
        await SendGroupMessageAsync(group, new PlainMessage {Content = message});
    }
    public async Task SendGroupMessageAsync(string group, params MessageBase[] message)
    {
        var data = JsonSerializer.Serialize(new ProtoCommand
        {
            CommandType = CommandType.SendGroupMessage,
            Data = new SendMessageComand
            {
                Target = group,
                MessageChain = message
            }
        }, new JsonSerializerOptions
        {
            Converters = { new MessageJsonConverter() }
        });
        await Send(_client, data);
    }
    #endregion
}
