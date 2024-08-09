using SchoolSystemBackend.Models.Entities;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace SchoolSystemBackend.Libs
{
    public class GenderTypeJsonConverter : JsonConverter<GenderType>
    {
        public override GenderType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var genderString = reader.GetString();
            return genderString switch
            {
                "Male" => GenderType.Male,
                "Female" => GenderType.Female,
                "Other" => GenderType.Other,
                _ => throw new JsonException($"Unknown gender type: {genderString}")
            };
        }

        public override void Write(Utf8JsonWriter writer, GenderType value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString().ToLower());
        }
    }
}
