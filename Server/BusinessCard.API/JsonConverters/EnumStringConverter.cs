using Newtonsoft.Json;

namespace BusinessCard.API.JsonConverters;

public class EnumStringConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue(value.ToString());
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
        {
            return default; 
        }

        var enumType = objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? Nullable.GetUnderlyingType(objectType)
            : objectType;

        return Enum.Parse(enumType, reader.Value.ToString(), true); 
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType.IsEnum || (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>)
                                     && Nullable.GetUnderlyingType(objectType).IsEnum);
    }
}
