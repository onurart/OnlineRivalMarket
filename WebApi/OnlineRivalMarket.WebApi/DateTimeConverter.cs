using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace OnlineRivalMarket.WebApi;
public class DateTimeConverter : JsonConverter<DateTime>
{
    private static readonly string[] Formats = new[]
    {
        "dd-MM-yyyy HH:mm:ss",
        "dd-MM-yyyy"
    };
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var dateString = reader.GetString();

        foreach (var format in Formats)
        {
            if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }
        }

        throw new JsonException($"Invalid date format. Expected formats: {string.Join(" or ", Formats)}");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString(Formats[0])); // Always writes in "dd-MM-yyyy" format
    }
}