using Newtonsoft.Json;

namespace BusinessCard.API.JsonConverters;

public sealed class DateTimeJsonConverter : JsonConverter<DateTime>
{
    public override void WriteJson
    (JsonWriter writer, DateTime value, JsonSerializer serializer)
    {
        writer.WriteValue(value.ToString("O"));
    }

    public override DateTime ReadJson
    (JsonReader reader, Type objectType, DateTime existingValue,
     bool hasExistingValue, JsonSerializer serializer)
    {
        var v = reader.Value;
        if (v == null)
        {
            return DateTime.MinValue;
        }

        var vType = v.GetType();
        if (vType == typeof(DateTimeOffset))
        {
            return (((DateTimeOffset)v).DateTime);
        }

        if (vType == typeof(string))
        {
            return DateTime.Parse((string)v); //DateOnly can parse 00001-01-01
        }

        if (vType == typeof(DateTime))
        {
            return (DateTime)v;
        }

        throw new NotSupportedException
              ($"Not yet support {vType} in {this.GetType()}.");
    }
}