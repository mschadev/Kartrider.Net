using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Json.Converter
{
    /// <summary>
    /// json string to <see cref=" Kartrider.Api.Endpoints.MatchEndpoint.Models.MatchInfo">MatchInfo</see> JsonConverter
    /// </summary>
    public class MatchInfoJsonConverter : JsonConverter<MatchInfo>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override MatchInfo Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var matchInfo = new MatchInfo();

            var myTeamType = TeamType.Solo;
            while (reader.Read())
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var property = reader.GetString();
                    switch (property)
                    {
                        case "channelName":
                            reader.Read();
                            var channel = reader.GetString();
                            matchInfo.Channel = channel;
                            break;

                        case "endTime":
                            reader.Read();
                            var endDateTime = reader.GetDateTime();
                            matchInfo.EndDateTime = endDateTime;
                            break;

                        case "matchId":
                            reader.Read();
                            var matchId = reader.GetString();
                            matchInfo.MatchId = matchId;
                            break;

                        case "matchResult":
                            reader.Read();
                            var matchResult = reader.GetString();
                            if (matchResult == "1")
                                matchInfo.Result = MatchResult.SoloWin;
                            else if (matchResult == "0")
                                matchInfo.Result = MatchResult.Lose;
                            else
                                /*
                                     * 유저 고유 식별자로 매치 리스트 조회(https://developers.nexon.com/kart/api/13/34)시
                                     * matchResult Property가 ""인 경우가 있음
                                     * 특정 매치의 상세 정보 조회(https://developers.nexon.com/kart/api/13/40)시에는 정상,
                                     * API 버그로 판단됨
                                     */
                                matchInfo.Result = MatchResult.Unknown;

                            break;

                        case "matchType":
                            reader.Read();
                            var matchType = reader.GetString();
                            matchInfo.MatchType = matchType;
                            break;

                        case "startTime":
                            reader.Read();
                            var startDateTime = reader.GetDateTime();
                            matchInfo.StartDateTime = startDateTime;
                            break;

                        case "trackId":
                            reader.Read();
                            var trackId = reader.GetString();
                            matchInfo.TrackId = trackId;
                            break;

                        case "teamId":
                            reader.Read();
                            var teamId = reader.GetString();
                            myTeamType = (TeamType)Enum.Parse(typeof(TeamType), teamId);
                            break;
                        case "playerCount":
                            reader.Read();
                            var playerCount = reader.GetInt32();
                            matchInfo.PlayerCount = playerCount;
                            break;
                        case "player":
                            if (matchInfo.Player == null) matchInfo.Player = new Player();
                            var player = JsonSerializer.Deserialize<Player>(ref reader, options);
                            player.TeamType = myTeamType;
                            matchInfo.Player = player;
                            break;
                    }
                }

            return matchInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        public override void Write(Utf8JsonWriter writer, MatchInfo value,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("channelName");
            writer.WriteStringValue(value.Channel);
            writer.WritePropertyName("endTime");
            writer.WriteStringValue(value.EndDateTime);
            writer.WritePropertyName("matchId");
            writer.WriteStringValue(value.MatchId);
            writer.WritePropertyName("matchResult");
            string matchResult = "";
            if (value.Result == MatchResult.SoloWin)
            {
                matchResult = "1";
            }
            else if (value.Result == MatchResult.Lose)
            {
                matchResult = "0";
            }
            writer.WriteStringValue(matchResult);
            writer.WritePropertyName("matchType");
            writer.WriteStringValue(value.MatchType);
            writer.WritePropertyName("startTime");
            writer.WriteStringValue(value.StartDateTime);
            writer.WritePropertyName("trackId");
            writer.WriteStringValue(value.TrackId);
            writer.WritePropertyName("teamId");
            writer.WriteStringValue(value.Player.TeamType.ToString());
            writer.WritePropertyName("player");
            JsonSerializer.Serialize(writer, value.Player, options);
            writer.WriteEndObject();
        }
    }
}