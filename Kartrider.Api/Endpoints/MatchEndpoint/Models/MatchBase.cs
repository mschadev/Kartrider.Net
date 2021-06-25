using System;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 매치 정보 베이스
    /// </summary>
    public class MatchBase
    {
        /// <summary>
        /// 매치 결과
        /// </summary>
        public MatchResult Result { get; set; }
        /// <summary>
        /// 매치 고유 식별자
        /// </summary>
        public string MatchId { get; set; }
        /// <summary>
        /// 매치가 진행된 채널 이름
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// 매치가 끝난 시간 (UTC 기준)
        /// </summary>
        public DateTime EndDateTime { get; set; }
        /// <summary>
        /// 매치 타입
        /// </summary>
        /// <remarks>
        /// <see href="https://static.api.nexon.co.kr/kart/latest/metadata.zip">metadata.zip</see> 다운로드 후, matchType.json 참고
        /// </remarks>
        public string MatchType { get; set; }
        /// <summary>
        /// 매치가 시작된 시간 (UTC 기준)
        /// </summary>
        public DateTime StartDateTime { get; set; }
        /// <summary>
        /// 트랙 고유 식별자
        /// </summary>
        public string TrackId { get; set; }

    }
}