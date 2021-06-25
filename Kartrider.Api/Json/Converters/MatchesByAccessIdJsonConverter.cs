using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Json.Converter
{
    /// <summary>
    /// json string to <see cref=" Kartrider.Api.Endpoints.MatchEndpoint.Models.MatchesByAccessId">MatchesByAccessId</see> JsonConverter
    /// </summary>
    internal class MatchesByAccessIdJsonConverter : JsonConverter<MatchesByAccessId>
    {
        public override MatchesByAccessId Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var matchesByAccessId = new MatchesByAccessId
            {
                Matches = new Dictionary<string, List<MatchInfo>>()
            };
            while (reader.Read())
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var property = reader.GetString();
                    switch (property)
                    {
                        case "nickName":
                            reader.Read();
                            var nickname = reader.GetString();
                            matchesByAccessId.Nickname = nickname;
                            break;

                        case "matchType":
                            reader.Read();
                            var matchType = reader.GetString();
                            reader.Read();
                            // current: PropertyName, matches
                            reader.Read();
                            // current: StartArray
                            reader.Read();
                            // current: StartObject
                            matchesByAccessId.Matches.Add(matchType, new List<MatchInfo>());
                            while (reader.TokenType != JsonTokenType.EndArray)
                            {
                                var matchInfo = JsonSerializer.Deserialize<MatchInfo>(ref reader, options);
                                matchesByAccessId.Matches[matchType].Add(matchInfo);
                                reader.Read();
                            }

                            break;
                    }
                }

            return matchesByAccessId;
        }

        public override void Write(Utf8JsonWriter writer, MatchesByAccessId value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("nickName");
            writer.WriteStringValue(value.Nickname);
            writer.WritePropertyName("matches");
            writer.WriteStartArray();
            foreach (var pair in value.Matches)
            {
                string matchType = pair.Key;
                List<MatchInfo> matchInfos = pair.Value;
                writer.WriteStartObject();
                writer.WritePropertyName("matchType");
                writer.WriteStringValue(matchType);
                writer.WritePropertyName("matches");
                writer.WriteStartArray();
                foreach (MatchInfo matchInfo in matchInfos)
                {
                    JsonSerializer.Serialize(writer, matchInfo, options);

                }
                writer.WriteEndArray();
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}