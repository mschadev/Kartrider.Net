using Kartrider.Api.Json.Converter;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 매치 상세 정보
    /// </summary>
    [JsonConverter(typeof(MatchDetailJsonConverter))]
    public class MatchDetail : MatchBase
    {
        /// <summary>
        /// 매치 카트바디 속도
        /// </summary>
        public GameSpeed GameSpeed { get; set; }
        /// <summary>
        /// 1등 기록 + 10초 카운트까지 포함된 시간
        /// </summary>
        public TimeSpan PlayTime { get; set; }
        /// <summary>
        /// 매치를 진행한 플레이어 리스트
        /// </summary>
        public List<Player> Players { get; set; }
        /// <summary>
        /// 팀전 유무
        /// </summary>
        public bool IsTeamMode => Result == MatchResult.BlueWin || Result == MatchResult.RedWin;
    }
}