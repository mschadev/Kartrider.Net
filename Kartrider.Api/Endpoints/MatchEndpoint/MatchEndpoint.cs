using Kartrider.Api.Endpoints.Interfaces;
using Kartrider.Api.Endpoints.MatchEndpoint.Models;
using Kartrider.Api.Http.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kartrider.Api.Endpoints.MatchEndpoint
{
    /// <summary>
    /// 매치 정보 API Endpoint
    /// </summary>
    public class MatchEndpoint : IMatchEndpoint
    {
        private const string MatchRootUrl = "/matches";
        private const string AllMatches = "/all?start_date={0}&end_date={1}&offset={2} &limit={3}&match_types={4}";
        private const string MatchDetail = "/{0}";

        private const string AllMatchesByAccessId =
            "/users/{0}/matches?start_date={1}&end_date={2} &offset={3}&limit={4}&match_types={5}";

        private readonly IRequester _requester;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requester"></param>
        public MatchEndpoint(IRequester requester)
        {
            _requester = requester;
        }
        /// <inheritdoc/>
        public async Task<AllMatches> GetAllMatchesAsync(DateTime? startDate = null, DateTime? endDate = null,
            int offset = 0, int limit = 10, IEnumerable<string> matchTypes = null)
        {
            var url = $"{MatchRootUrl}/{string.Format(AllMatches, startDate, endDate, offset, limit, MatchTypeToStringArray(matchTypes))}";
            var json = await _requester.CreateGetRequestAsync(url).ConfigureAwait(false);
            return JsonSerializer.Deserialize<AllMatches>(json);
        }
        /// <inheritdoc/>
        public async Task<MatchDetail> GetMatchDetailAsync(string matchId)
        {
            var json = await _requester.CreateGetRequestAsync($"{MatchRootUrl}{string.Format(MatchDetail, matchId)}")
                .ConfigureAwait(false);
            return JsonSerializer.Deserialize<MatchDetail>(json);
        }


        /// <inheritdoc/>
        public async Task<MatchesByAccessId> GetMatchesByAccessIdAsync(string accessId, DateTime? startDate = null,
            DateTime? endDate = null, int offset = 0, int limit = 10, IEnumerable<string> matchTypes = null)
        {
            var json = await _requester
                .CreateGetRequestAsync(string.Format(AllMatchesByAccessId, accessId, startDate, endDate, offset, limit, MatchTypeToStringArray(matchTypes)
                    )).ConfigureAwait(false);
            var obj = JsonSerializer.Deserialize<MatchesByAccessId>(json);
            if(obj.Nickname == null)
            {
                throw new KartriderApiException("AccessId에 해당하는 유저가 없습니다.", HttpStatusCode.NotFound);
            }
            return obj;
        }
        private string MatchTypeToStringArray(IEnumerable<string> matchTypes)
        {
            if(matchTypes == null)
            {
                return "";
            }
            return string.Join(",", matchTypes);
        }
    }
}