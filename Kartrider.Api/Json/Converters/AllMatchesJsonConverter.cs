using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Json.Converter
{
    /// <summary>
    /// json string to <see cref=" Kartrider.Api.Endpoints.MatchEndpoint.Models.AllMatches">AllMatches</see> JsonConverter
    /// </summary>
    public class AllMatchesJsonConverter : JsonConverter<AllMatches>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override AllMatches Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var allMatches = new AllMatches
            {
                Matches = new Dictionary<string, List<string>>()
            };
            while (reader.Read())
                if (reader.TokenType == JsonTokenType.PropertyName && reader.GetString() == "matchType")
                {
                    reader.Read();
                    var matchType = reader.GetString();
                    var matches = new List<string>(); //matchId List

                    while (reader.TokenType != JsonTokenType.EndArray)
                    {
                        reader.Read();
                        if (reader.TokenType == JsonTokenType.String) matches.Add(reader.GetString());
                    }

                    allMatches.Matches.Add(matchType, matches);
                }

            return allMatches;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="allMatches"></param>
        /// <param name="options"></param>
        public override void Write(
            Utf8JsonWriter writer,
            AllMatches allMatches,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("matches");
            writer.WriteStartArray();
            foreach (var pair in allMatches.Matches)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("matchType");
                writer.WriteStringValue(pair.Key);
                writer.WritePropertyName("matches");
                writer.WriteStartArray();
                foreach (var matchId in pair.Value) writer.WriteStringValue(matchId);
                writer.WriteEndArray();
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}