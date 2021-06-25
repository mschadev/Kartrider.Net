using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Json.Converter
{
    /// <summary>
    /// json string to <see cref=" Kartrider.Api.Endpoints.MatchEndpoint.Models.Player">Player</see> JsonConverter
    /// </summary>
    public class PlayerJsonConverter : JsonConverter<Player>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="typeToConvert"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public override Player Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            var player = new Player();
            while (reader.Read())
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var property = reader.GetString();
                    switch (property)
                    {
                        case "accountNo":
                            reader.Read();
                            var accessId = reader.GetString();
                            player.AccessId = accessId;
                            break;

                        case "characterName":
                            reader.Read();
                            var nickname = reader.GetString();
                            player.Nickname = nickname;
                            break;

                        case "character":
                            reader.Read();
                            var character = reader.GetString();
                            player.Character = character;
                            break;

                        case "kart":
                            reader.Read();
                            var kartbody = reader.GetString();
                            player.Kartbody = kartbody;
                            break;

                        case "pet":
                            reader.Read();
                            var pet = reader.GetString();
                            player.Pet = pet;
                            break;

                        case "flyingPet":
                            reader.Read();
                            var flyingPet = reader.GetString();
                            player.FlyingPet = flyingPet;
                            break;
                        // Parts...
                        case "rankinggrade2":
                            reader.Read();
                            var license = reader.GetString();
                            if (string.IsNullOrEmpty(license))
                                player.License = License.Unknown;
                            else
                                player.License = (License)Enum.Parse(typeof(License), reader.GetString());
                            break;

                        case "matchRank":
                            reader.Read();
                            var rankStr = reader.GetString();
                            if (rankStr == "")
                            {
                                player.Rank = -1;
                            }
                            else
                            {
                                var rank = Convert.ToInt32(rankStr);
                                player.Rank = rank;
                            }
                            break;

                        case "matchRetired":
                            reader.Read();
                            var retiredStr = reader.GetString();
                            var retired = retiredStr == "1";
                            player.Retired = retired;
                            break;

                        case "matchWin":
                            reader.Read();
                            var winStr = reader.GetString();
                            var win = winStr == "1";
                            player.Win = win;
                            break;

                        case "matchTime":
                            reader.Read();
                            var record = reader.GetString();
                            if (record == null || record == "")
                            {
                                player.Record = TimeSpan.Zero;
                            }
                            else
                            {
                                int sec = int.Parse(record.Substring(0, record.Length - 3));
                                var mill = int.Parse(record.Substring(record.Length - 3, 3));
                                player.Record = new TimeSpan(0, 0, 0, sec, mill);
                            }

                            break;
                    }
                }
                else if (reader.TokenType == JsonTokenType.EndObject)
                {
                    break;
                }

            return player;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="player"></param>
        /// <param name="options"></param>
        public override void Write(
            Utf8JsonWriter writer,
            Player player,
            JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("accountNo");
            writer.WriteStringValue(player.AccessId);
            writer.WritePropertyName("characterName");
            writer.WriteStringValue(player.Nickname);
            writer.WritePropertyName("character");
            writer.WriteStringValue(player.Character);
            writer.WritePropertyName("kart");
            writer.WriteStringValue(player.Kartbody);
            writer.WritePropertyName("pet");
            writer.WriteStringValue(player.Pet);
            writer.WritePropertyName("flyingPet");
            writer.WriteStringValue(player.FlyingPet);
            writer.WritePropertyName("rankinggrade2");
            writer.WriteStringValue(((int)player.License).ToString());
            writer.WritePropertyName("matchRank");
            writer.WriteStringValue(player.Rank.ToString());
            writer.WritePropertyName("matchRetired");
            writer.WriteStringValue(player.Retired ? "1" : "0");
            writer.WritePropertyName("matchWin");
            writer.WriteStringValue(player.Win ? "1" : "0");
            writer.WritePropertyName("matchTime");
            string record = $"{player.Record.Seconds}{player.Record.Milliseconds:000}";
            writer.WriteStringValue(record);
            writer.WriteEndObject();
        }
    }
}