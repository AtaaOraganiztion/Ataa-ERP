using System.Text.Json;
using System.Text.Json.Serialization;

namespace Infrastructure.Converters;

public class UlidJsonConverter : JsonConverter<Ulid>
{
    public override Ulid Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            string? stringValue = reader.GetString();
            if (string.IsNullOrEmpty(stringValue))
                return Ulid.Empty;

            return Ulid.Parse(stringValue);
        }

        throw new JsonException($"Unexpected token type {reader.TokenType} when parsing Ulid.");
    }

    public override void Write(Utf8JsonWriter writer, Ulid value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}
