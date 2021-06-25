namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 매치 결과
    /// </summary>
    public enum MatchResult
    {
        /// <summary>
        /// 알 수 없음
        /// </summary>
        Unknown = -2,
        /// <summary>
        /// 레드팀 승리
        /// </summary>
        RedWin = 1,
        /// <summary>
        /// 블루팀 승리
        /// </summary>
        BlueWin = 2,
        /// <summary>
        /// 개인전 승리
        /// </summary>
        SoloWin = 0,
        /// <summary>
        /// 패배
        /// </summary>
        Lose = -1
    }
}