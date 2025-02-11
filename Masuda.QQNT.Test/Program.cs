// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Masuda.QQNT;
using Masuda.QQNT.Models.Message;
using TestBot;

// var aa = JsonSerializer.Deserialize<ProtoEvent>(
// """
// {"t":"Message","d":{"sender":{"uid":"u_rlWjzoy0VCOwxiaHXRiH8w","memberName":"米米尔","nickName":"米米尔"},"content":[{"peer":{"uid":"790890246","name":"Project Shigeru Ohmori测试","chatType":"group"},"sender":{"uid":"u_rlWjzoy0VCOwxiaHXRiH8w","memberName":"米米尔","nickName":"米米尔"},"elements":[{"type":"text","content":"？"}]}]}}
// """);
// System.Console.WriteLine(aa.Data);
// var bb = JsonSerializer.Deserialize<MasudaMessage>(aa.Data.ToString(), new JsonSerializerOptions {
//      Converters = { new MessageJsonConverter() }
// });
// return;
NeteaseCloudMusic.NET.NeteasyCloudClient neteasyCloudClient = new();
await neteasyCloudClient.RegisterAnonimous();
NTBot bot = new NTBot
{
    BotConfig = new Masuda.QQNT.Models.BotConfig
    {
        IPAddress = "127.0.0.1:8080",
        Key = "165423",
    }
};
var kuiPath = @"D:\kui";
string[][] kuishi = new[]
    {
        BotLib.失魂雨,
        BotLib.阮郎归,
        BotLib.蓝葵结局,
        BotLib.寥落风,
        BotLib.浙大校歌,
        BotLib.黯淡蓝点,
        BotLib.幽弥狂的狂怒,
        BotLib.AStepAway,
    };

bot.LaunchAsync().Wait();
bot.OnFriendMessage += async (bot, messages) =>
{
    var mdata = messages.Content;
    foreach (var message in mdata)
    {
        if (message is PlainMessage plainMessage)
        {

            System.Console.WriteLine(plainMessage.Content);
            var content = plainMessage.Content;

            if (content == "test1")
            {
                //await bot.SendFriendMessageAsync(messages.Peer.Uid, new RefMessage());
                await bot.SendFriendMessageAsync(messages.Peer.Uid, new PlainMessage("1234"));
                //await bot.SendFriendMessageAsync("3084029286", new RefMessage());

            }
        }
    }
    
   

};
bot.OnMessage += async (bot, messages) =>
{
    var mdata = messages.Content;
    foreach (var message in mdata)
    {
        // System.Console.WriteLine(message.GetType());

        //ImageMessage imageMessage = new();
        //await imageMessage.WaitImageExistAsync();
        //while (!File.Exists(imageMessage.File))
        //{
        //    await Task.Delay(100);
        //}


        if (message is PlainMessage plainMessage)
        {

            System.Console.WriteLine(plainMessage.Content);
            var content = plainMessage.Content;

            if (content == "test1")
            {
                //await bot.SendFriendMessageAsync(messages.Peer.Uid, new RefMessage());
                await bot.SendFriendMessageAsync("u_XYCAUcydUutkVCNQNHJ1ow", new RefMessage());
                //await bot.SendFriendMessageAsync("3084029286", new RefMessage());

            }

            if (content == "test")
            {
                var song = await neteasyCloudClient.SearchMusicAsync("Where We Belong");
                //var song = await neteasyCloudClient.SearchMusicAsync("a step away");
                await bot.SendGroupMessageAsync(messages.Peer.Uid, new MusicMessage(song[0].id.ToString() , song[0].name + " (" + song[0].tns[0] + ")", "http://p1.music.126.net/uz6z15QyBmrnsC-pSmJMWA==/109951167736550226.jpg?imageView=1&thumbnail=1200z2543&type=webp&quality=80"));
                //await bot.SendGroupMessageAsync(messages.Peer.Uid, new FileMessage("C:\\Users\\admin\\Documents\\LiteLoaderQQNT\\plugins\\masuda_20059 \\src\\main.js"));
            }

            if (content.StartsWith("点歌"))
            {

                var song = await neteasyCloudClient.SearchMusicAsync(content[2..].Trim());
                if (song.Length > 0)
                {
                    //await bot.SendGroupMessageAsync(messages.Peer.Uid, );

                    await bot.SendGroupMessageAsync(messages.Peer.Uid, new PlainMessage($"{song[0].name}\n{song[0].alia.FirstOrDefault()}\n{song[0].ar.FirstOrDefault()?.name}\n{song[0].tns?.FirstOrDefault()}\nhttp://music.163.com/song/media/outer/url?id={song[0].id}"),new ImageMessage(url: song[0].al.picUrl));
                }

            }
            if (content.StartsWith("电台"))
            {

                var song = await neteasyCloudClient.SearchMusicAsync(content[2..].Trim(), type: 1009);
                if (song?.Length  > 0)
                {
                    //await bot.SendGroupMessageAsync(messages.Peer.Uid, );

                    await bot.SendGroupMessageAsync(messages.Peer.Uid, new PlainMessage($"{song[0].name}\n{song[0].alia.FirstOrDefault()}\n{song[0].ar.FirstOrDefault()?.name}\n{song[0].tns?.FirstOrDefault()}\nhttp://music.163.com/song/media/outer/url?id={song[0].id}"), new ImageMessage(url: song[0].al.picUrl));
                }

            }
            if (plainMessage.Content.Length < 2) return;



            foreach (var shi in kuishi)
            {
                for (int i = 0; i < shi.Length; ++i)
                {
                    if (shi[i].StartsWith(content))
                    {
                        if (content == shi[i])
                        {

                            // await bot.SendMessageAsync(messages, new PlainMessage("你好呀"), new ImageMessage("https://www.baidu.com/img/flexible/logo/pc/result.png"));
                            // // 2. 直接发送文本
                            // await bot.SendMessageAsync(messages, "你好呀");
                            // // 3. 回复
                            // await bot.ReplyMessageAsync(messages, "你好呀");
                            // // 4. 回复并@发送者
                            //await bot.ReplyMessageAsync(messages, new AtMessage(messages.Sender), new PlainMessage("你好呀"));
                            if (i < shi.Length - 1)
                                await bot.SendMessageAsync(messages.Peer, shi[i + 1]);
                            return;
                        }
                        else
                        {
                            if (shi[i][content.Length] == ',')
                            {
                                await bot.SendMessageAsync(messages.Peer, shi[i][(content.Length + 1)..].Trim());
                                return;
                            }
                            else
                            {
                                await bot.SendMessageAsync(messages.Peer, shi[i]);
                                return;
                            }
                        }

                    }
                }
            }
            break;
        }
    }

};
Console.ReadLine();