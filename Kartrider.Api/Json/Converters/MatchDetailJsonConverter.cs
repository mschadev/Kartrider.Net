using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Json.Converter
{
    /// <summary>
    /// json string to <see cref=" Kartrider.Api.Endpoints.MatchEndpoint.Models.MatchDetail">MatchDetail</see> JsonConverter
    /// </summary>
    internal class MatchDetailJsonConverter : JsonConverter<MatchDetail>
    {
        public override MatchDetail Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var matchDetail = new MatchDetail();
            var lastTeamType = TeamType.Solo;
            while (reader.Read())
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var property = reader.GetString();
                    switch (property)
                    {
                        case "channelName":
                            reader.Read();
                            var channel = reader.GetString();
                            matchDetail.Channel = channel;
                            break;

                        case "endTime":
                            reader.Read();
                            var endDateTime = reader.GetDateTime();
                            matchDetail.EndDateTime = endDateTime;
                            break;

                        case "gameSpeed":
                            reader.Read();
                            // Int32일때도, string일때도 있음.
                            string gameSpeed;
                            if (reader.TokenType == JsonTokenType.Number)
                            {
                                gameSpeed = reader.GetInt32().ToString();
                            }
                            else
                            {
                                gameSpeed = reader.GetString();
                            }
                            if (gameSpeed == "4") //무한 부스터
                                matchDetail.GameSpeed = GameSpeed.Fast;
                            else
                                matchDetail.GameSpeed = (GameSpeed)Enum.Parse(typeof(GameSpeed), gameSpeed.ToString());
                            break;

                        case "matchId":
                            reader.Read();
                            var matchId = reader.GetString();
                            matchDetail.MatchId = matchId;
                            break;

                        case "matchResult":
                            reader.Read();
                            var matchResult = reader.GetString();
                            matchDetail.Result = (MatchResult)Enum.Parse(typeof(MatchResult), matchResult);
                            break;

                        case "matchType":
                            reader.Read();
                            var matchType = reader.GetString();
                            matchDetail.MatchType = matchType;
                            break;

                        case "playTime":
                            reader.Read();
                            int playTime;
                            if (reader.TokenType == JsonTokenType.Number)
                            {
                                playTime = reader.GetInt32();
                            }
                            else
                            {
                                playTime = Convert.ToInt32(reader.GetString());
                            }
                            matchDetail.PlayTime = TimeSpan.FromSeconds(playTime);
                            break;

                        case "startTime":
                            reader.Read();
                            var startDateTime = reader.GetDateTime();
                            matchDetail.StartDateTime = startDateTime;
                            break;

                        case "trackId":
                            reader.Read();
                            var trackId = reader.GetString();
                            matchDetail.TrackId = trackId;
                            break;

                        case "teamId":
                            reader.Read();
                            var teamId = reader.GetString();
                            lastTeamType = (TeamType)Enum.Parse(typeof(TeamType), teamId);
                            break;

                        case "players":
                            reader.Read();
                            reader.Read();
                            if (matchDetail.Players == null) matchDetail.Players = new List<Player>();
                            while (reader.TokenType != JsonTokenType.EndArray)
                            {
                                var player = JsonSerializer.Deserialize<Player>(ref reader, options);
                                player.TeamType = lastTeamType;
                                matchDetail.Players.Add(player);
                                reader.Read();
                            }

                            break;
                    }
                }

            if (1 < matchDetail.Players.Count) matchDetail.Players = matchDetail.Players.OrderBy(p => p.Rank).ToList();
            return matchDetail;
        }

        public override void Write(Utf8JsonWriter writer, MatchDetail value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("channelName");
            writer.WriteStringValue(value.Channel);
            writer.WritePropertyName("endTime");
            writer.WriteStringValue(value.EndDateTime);
            writer.WritePropertyName("gameSpeed");
            writer.WriteStringValue(((int)value.GameSpeed).ToString());
            writer.WritePropertyName("matchId");
            writer.WriteStringValue(value.MatchId);
            writer.WritePropertyName("matchResult");
            writer.WriteStringValue(((int)value.Result).ToString());
            writer.WritePropertyName("matchType");
            writer.WriteStringValue(value.MatchType);
            writer.WritePropertyName("playTime");
            writer.WriteStringValue(value.PlayTime.TotalSeconds.ToString());
            writer.WritePropertyName("startTime");
            writer.WriteStringValue(value.StartDateTime);
            writer.WritePropertyName("trackId");
            writer.WriteStringValue(value.TrackId);
            if (value.IsTeamMode)
            {
                writer.WritePropertyName("teams");
                writer.WriteStartArray();
                var redPlayers = value.Players.Where(p => p.TeamType == TeamType.Red);
                if (0 < redPlayers.Count())
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("teamId");
                    writer.WriteStringValue("1"); // Red Team
                    writer.WritePropertyName("players");
                    writer.WriteStartArray();
                    foreach (var player in redPlayers)
                    {
                        JsonSerializer.Serialize(writer, player, options);
                    }
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                var bluePlayers = value.Players.Where(p => p.TeamType == TeamType.Blue);
                if (0 < bluePlayers.Count())
                {
                    writer.WriteStartObject();
                    writer.WritePropertyName("teamId");
                    writer.WriteStringValue("2"); // Red Team
                    writer.WritePropertyName("players");
                    writer.WriteStartArray();
                    foreach (var player in bluePlayers)
                    {
                        JsonSerializer.Serialize(writer, player, options);
                    }
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                }
                writer.WriteEndArray();
            }
            else
            {
                writer.WritePropertyName("players");
                writer.WriteStartArray();
                foreach (var player in value.Players)
                {
                    JsonSerializer.Serialize(writer, player, options);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();


        }
    }
}