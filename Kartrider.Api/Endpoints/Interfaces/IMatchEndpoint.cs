using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kartrider.Api.Endpoints.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMatchEndpoint
    {
        /// <summary>
        /// 유저 고유 식별자로 매치 리스트 조회
        /// </summary>
        /// <remarks>
        /// 유저의 MatchId를 매치 타입별, startDate 기준 내림차순으로 반환한다. <br/>
        /// 파라미터 정보 startDate, endDate 생략되는 경우 최근 10건 조회한다. <br/>
        /// (최대 조회 건 수 500건) <br/>
        /// <see href="https://developers.nexon.com/kart/api/13/34">API Docs</see>
        /// </remarks>
        /// <param name="accessId">유저 고유 식별자</param>
        /// <see cref="Kartrider.Api.Endpoints.UserEndpoint.User.AccessId"/>
        /// <param name="startDate">조회 시작 날짜 (UTC 기준)</param>
        /// <param name="endDate">조회 끝 날짜 (UTC 기준)</param>
        /// <param name="offset">조회 오프셋 </param>
        /// <param name="limit">조회 수</param>
        /// <param name="matchTypes">조회할 매치 타입 HashID 배열</param>
        /// <seealso href="https://static.api.nexon.co.kr/kart/latest/metadata.zip">
        /// zip 다운로드 후, matchType.json 참고
        /// </seealso>
        /// <returns>닉네임, 'Dictionary&lt;MatchType, List&lt;매치정보&gt;&gt;' 프로퍼티가 있는 인스턴스</returns>
        /// <exception cref=" Kartrider.Api.KartriderApiException">description</exception>
        Task<MatchesByAccessId> GetMatchesByAccessIdAsync(string accessId, DateTime? startDate = null,
            DateTime? endDate = null, int offset = 0, int limit = 10, IEnumerable<string> matchTypes = null);
        /// <summary>
        /// 모든 매치 리스트 조회
        /// </summary>
        /// <remarks>
        /// 모든 유저의 MatchId를 매치 타입별, startDate 기준 내림차순으로 반환한다. <br/>
        /// startDate, endDate 생략되는 경우 UTC 기준 현재 날짜의 매치리스트를 조회한다. <br/>
        /// (최대 조회 건 수 500건) <br/>
        /// <see href="https://developers.nexon.com/kart/api/13/35">API Docs</see>
        /// </remarks>
        /// <param name="startDate">조회 시작 날짜 (UTC 기준)</param>
        /// <param name="endDate">조회 끝 날짜 (UTC 기준)</param>
        /// <param name="offset">조회 오프셋</param>
        /// <param name="limit">조회 수 (최대 500)</param>
        /// <param name="matchTypes">조회할 매치 타입 HashID 배열</param>
        /// <seealso href="https://static.api.nexon.co.kr/kart/latest/metadata.zip">
        /// zip 다운로드 후, matchType.json 참고
        /// </seealso>
        /// <returns>'Dictionary&lt;MatchType,List&lt;MatchId&gt;' 프로퍼티가 있는 인스턴스</returns>
        /// <exception cref=" Kartrider.Api.KartriderApiException">description</exception>
        Task<AllMatches> GetAllMatchesAsync(DateTime? startDate = null, DateTime? endDate = null, int offset = 0,
            int limit = 10, IEnumerable<string> matchTypes = null);
        /// <summary>
        /// 특정 매치의 상세 정보 조회
        /// </summary>
        /// <remarks>
        /// 매치 고유 식별자로 특정 매치의 상세 정보를 조회한다.<br/>
        /// <see href="https://developers.nexon.com/kart/api/13/40">API Docs</see>
        /// </remarks>
        /// <param name="matchId">매치 고유 식별자</param>
        /// <returns>해당 매치 상세 정보 인스턴스</returns>
        /// <exception cref=" Kartrider.Api.KartriderApiException">description</exception>
        Task<MatchDetail> GetMatchDetailAsync(string matchId);
    }
}