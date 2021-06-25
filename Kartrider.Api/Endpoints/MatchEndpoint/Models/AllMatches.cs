using Kartrider.Api.Endpoints.MatchEndpoint.Interfaces;
using Kartrider.Api.Json.Converter;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 모든 매치 리스트 객체
    /// </summary>
    [JsonConverter(typeof(AllMatchesJsonConverter))]
    public class AllMatches : IAllMatches<string>
    {
        /// <inheritdoc/>
        public Dictionary<string, List<string>> Matches { get; set; }
    }
}