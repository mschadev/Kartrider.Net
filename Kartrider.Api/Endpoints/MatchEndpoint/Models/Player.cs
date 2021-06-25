using Kartrider.Api.Json.Converter;

using System;
using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 플레이어 정보
    /// </summary>
    [JsonConverter(typeof(PlayerJsonConverter))]
    public class Player
    {
        /// <summary>
        /// 플레이어 팀 종류
        /// </summary>
        public TeamType TeamType { get; set; }
        /// <summary>
        /// 유저 고유 식별자
        /// </summary>
        public string AccessId { get; set; }
        /// <summary>
        /// 닉네임
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 사용한 캐릭터
        /// </summary>
        public string Character { get; set; }
        /// <summary>
        /// 탑승한 카트바디
        /// </summary>
        public string Kartbody { get; set; }
        /// <summary>
        /// 라이센스
        /// </summary>
        public License License { get; set; }
        /// <summary>
        /// 착용한 펫
        /// </summary>
        public string Pet { get; set; }
        /// <summary>
        /// 착용한 플라잉 펫
        /// </summary>
        public string FlyingPet { get; set; }

        // 파츠는 지원하지 않음.
        /// <summary>
        /// 매치에서의 순위
        /// </summary>
        public int Rank { get; set; }
        /// <summary>
        /// 매치에서 리타이어 여부
        /// </summary>
        public bool Retired { get; set; }
        /// <summary>
        /// 매치에서 승리 여부
        /// </summary>
        public bool Win { get; set; }
        /// <summary>
        /// 매치에서의 기록
        /// </summary>
        public TimeSpan Record { get; set; }
    }
}