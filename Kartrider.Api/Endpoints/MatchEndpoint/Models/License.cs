namespace Kartrider.Api.Endpoints.MatchEndpoint.Models
{
    /// <summary>
    /// 플레이어 라이센스
    /// </summary>
    public enum License
    {
        /// <summary>
        ///     알 수 없음
        /// </summary>
        Unknown = -1,

        /// <summary>
        ///     라이센스 없음
        /// </summary>
        None,

        /// <summary>
        ///     초보
        /// </summary>
        Beginner,

        /// <summary>
        ///     뉴비
        /// </summary>
        Newbie,

        /// <summary>
        ///     L3
        /// </summary>
        L3,

        /// <summary>
        ///     L2
        /// </summary>
        L2,

        /// <summary>
        ///     L1
        /// </summary>
        L1,

        /// <summary>
        ///     PRO
        /// </summary>
        PRO
    }
}