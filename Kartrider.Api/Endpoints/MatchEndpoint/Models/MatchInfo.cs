using Kartrider.Api.Json.Converter;

using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 매치 정보
    /// </summary>
    [JsonConverter(typeof(MatchInfoJsonConverter))]
    public class MatchInfo : MatchBase
    {
        /// <summary>
        /// 해당 매치 플레이어 수
        /// </summary>
        public int PlayerCount { get; set; }
        /// <summary>
        /// 내 정보
        /// </summary>
        public Player Player { get; set; }
    }
}