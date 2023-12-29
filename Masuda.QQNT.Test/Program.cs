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
        IPAddress = "127.0.0.1:8080"
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
bot.OnGroupMessage += async (bot, messages) =>
{
    var mdata = messages.Content[0];
    foreach (var message in mdata.Elements)
    {
        // System.Console.WriteLine(message.GetType());
        if (message is PlainMessage plainMessage)
        {
            System.Console.WriteLine(plainMessage.Content);
            var content = plainMessage.Content;

            switch (content.ToLower())
            {
                case "masuda":
                    await bot.SendGroupMessageAsync(mdata.Peer.Uid, "Masuda is God!");

                    break;
                case "随机蓝葵":
                    var lanKuiPath = Directory.GetFiles($"{kuiPath}/蓝葵游戏1/");

                    await bot.SendGroupMessageAsync(mdata.Peer.Uid, new ImageMessage { File = $"{lanKuiPath[Random.Shared.Next(lanKuiPath.Length)]}" });
                    break;
                case "随机红葵":
                    var hongKuiPath = Directory.GetFiles($"{kuiPath}/红葵游戏1/");

                    await bot.SendGroupMessageAsync(mdata.Peer.Uid, new ImageMessage { File = $"{hongKuiPath[Random.Shared.Next(hongKuiPath.Length)]}" });
                    break;
                default:
                    if (plainMessage.Content.Length < 2) return;
                    foreach (var shi in kuishi)
                    {
                        for (int i = 0; i < shi.Length; ++i)
                        {
                            if (shi[i].StartsWith(content))
                            {
                                if (content == shi[i])
                                {
                                    if (i < shi.Length - 1)
                                        await bot.SendGroupMessageAsync(mdata.Peer.Uid, shi[i + 1]);
                                    return;
                                }
                                else
                                {
                                    if (shi[i][content.Length] == ',')
                                    {
                                        await bot.SendGroupMessageAsync(mdata.Peer.Uid, shi[i][(content.Length + 1)..].Trim());
                                        return;
                                    }
                                    else
                                    {
                                        // await bot.DeleteMessageAsync(msg);
                                        await bot.SendGroupMessageAsync(mdata.Peer.Uid, shi[i]);
                                        return;
                                    }
                                }

                            }
                        }
                    }
                    break;
            }
        }

    }
};
Console.ReadLine();