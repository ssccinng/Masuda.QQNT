using System.Text.Json;
using System.Text.Json.Serialization;
using Masuda.QQNT.Models;
using Masuda.QQNT.Models.Message;

namespace Masuda.QQNT;

public class JsonHelper
{

}

public class MessageJsonConverter : JsonConverter<MessageBase>
{
    public override MessageBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
        var type = jsonObject.GetProperty("type").GetString();
        switch (type)
        {
            case "text":
                return JsonSerializer.Deserialize<PlainMessage>(jsonObject.GetRawText());
            case "image":
                return JsonSerializer.Deserialize<ImageMessage>(jsonObject.GetRawText());
            case "raw":
                return JsonSerializer.Deserialize<MessageBase>(jsonObject.GetRawText());
            default:
                return null;
        }
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, MessageBase value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType());

    }
}

public class ProtoJsonConverter : JsonConverter<ProtoEvent>
{
    public override ProtoEvent? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var jsonObject = JsonDocument.ParseValue(ref reader).RootElement;
        var type = jsonObject.GetProperty("t").GetString();
        switch (type)
        {
            // case "Message":
            //     return JsonSerializer.Deserialize<ProtoEvent>>(jsonObject.GetRawText());
            // case "FriendMessage":
            //     return JsonSerializer.Deserialize<ProtoEvent<FriendMessageEvent>>(jsonObject.GetRawText());
            // case "GroupMessage":
            //     return JsonSerializer.Deserialize<ProtoEvent<GroupMessageEvent>>(jsonObject.GetRawText());
            // case "TempMessage":
            //     return JsonSerializer.Deserialize<ProtoEvent<TempMessageEvent>>(jsonObject.GetRawText());
            // default:
            //     return null;
        }
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, ProtoEvent value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}