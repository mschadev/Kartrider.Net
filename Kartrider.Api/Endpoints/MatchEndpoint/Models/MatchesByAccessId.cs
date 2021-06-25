using Kartrider.Api.Endpoints.MatchEndpoint.Interfaces;
using Kartrider.Api.Json.Converter;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 유저 고유 식별자를 기반 매치 리스트
    /// </summary>
    [JsonConverter(typeof(MatchesByAccessIdJsonConverter))]
    public class MatchesByAccessId : IAllMatches<MatchInfo>
    {
        /// <summary>
        /// 닉네임
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 매치 리스트
        /// </summary>
        public Dictionary<string, List<MatchInfo>> Matches { get; set; }
    }
}