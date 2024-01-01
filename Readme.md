# Masuda.QQNT

基于[LiteLoaderQQNT](https://github.com/LiteLoaderQQNT/LiteLoaderQQNT)，开发的C#SDK

需要配合[masuda插件](https://github.com/ssccinng/Masuda.LLPlugin)使用

目前支持 FileMessage AtMessage ImageMessage PlainMessage

支持回复 后续补充文档

## ⚠️ 注意事项

> 本项目仅为个人兴趣而制作，开发目的在于学习和探索，一切开发皆在学习，请勿用于非法用途。  
> 因使用本项目产生的一切问题与后果由使用者自行承担，项目开发者不承担任何责任。

- 目前仍在开发当中，可能会存在一些问题和不足。
- 仅为个人兴趣而制作，开发目的在于学习和探索。
- 能力有限，随缘更新。不过也欢迎各位来提交PR。
- 由于项目特殊性，必要时会停止开发或删除仓库。

## 使用说明
1. 按照[LiteLoaderQQNT](https://github.com/LiteLoaderQQNT/LiteLoaderQQNT)的步骤，成功安装新版魔改后QQ
2. 在插件市场中找到LLAPI插件，安装并启用
3. 在[masuda插件](https://github.com/ssccinng/Masuda.LLPlugin)找到最新版release，下载并解压到插件目录下
4. 新建一个.NET项目，添加Masuda.QQNT的引用，即可正常使用(在vs nuget中搜索Masuda.QQNT，或者使用命令行添加)
```
dotnet add package Masuda.QQNT
```

## 使用示例
```csharp

NTBot bot = new NTBot
{
    BotConfig = new Masuda.QQNT.Models.BotConfig
    {
        IPAddress = "127.0.0.1:8080", // masuda插件的监听地址, 在config.json中设置 默认为8080端口
        Key = "165423", // masuda插件的key, 在config.json中设置, 默认为165423
    }
};
// 与masuda插件建立连接
await bot.LaunchAsync();

// 监听消息
bot.OnMessage += async (bot, messages) =>
{
    foreach (var message in messages.Content)
    {
        switch (message)
        {
            case AtMessage atMessage:
                // At消息 暂不支持读取
                break;
            case FileMessage fileMessage:
                // 文件消息 暂不支持读取
                break;
            case ImageMessage imageMessage:
                // 图片消息
                break;
            case PlainMessage plainMessage:
                // 文本消息
                switch (plainMessage.Content) 
                {
                    case "你好":
                        // 回复文本消息
                        // 1. 组合消息
                        await bot.SendMessageAsync(messages, new PlainMessage("你好呀"), new ImageMessage("https://www.baidu.com/img/flexible/logo/pc/result.png"));
                        // 2. 直接发送文本
                        await bot.SendMessageAsync(messages, "你好呀");
                        // 3. 回复
                        await bot.ReplyMessageAsync(messages, "你好呀");
                        // 4. 回复并@发送者
                       await bot.ReplyMessageAsync(messages, new AtMessage(messages.Sender), new PlainMessage("你好呀"));
                        break;
                }
                break;
        }
    }
};

```