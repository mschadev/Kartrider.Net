using System.Collections.Generic;

namespace Kartrider.Api.Endpoints.MatchEndpoint.Interfaces
{
    /// <summary>
    /// 매치 리스트 인터페이스
    /// </summary>
    /// <typeparam name="T"><see cref="Kartrider.Api.Endpoints.MatchEndpoint.Models.MatchDetail"/> or <see cref="Kartrider.Api.Endpoints.MatchEndpoint.Models.MatchInfo"/></typeparam>
    public interface IAllMatches<T>
    {
        /// <summary>
        /// 매치타입별 List&lt;T&gt;
        /// </summary>
        Dictionary<string, List<T>> Matches { get; set; }
    }
}