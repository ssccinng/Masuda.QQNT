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
bot.OnMessage += async (bot, messages) =>
{
    var mdata = messages.Content;
    foreach (var message in mdata)
    {
        // System.Console.WriteLine(message.GetType());

        ImageMessage imageMessage = new();
        await imageMessage.WaitImageExistAsync();
        while (!File.Exists(imageMessage.File))
        {
            await Task.Delay(100);
        }


        if (message is PlainMessage plainMessage)
        {
            System.Console.WriteLine(plainMessage.Content);
            var content = plainMessage.Content;
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
                            // await bot.ReplyMessageAsync(messages, new AtMessage(messages.Sender), new PlainMessage("你好呀"));
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