using Kartrider.Api.Endpoints.Interfaces;
using Kartrider.Api.Http.Interfaces;

using System.Text.Json;
using System.Threading.Tasks;

namespace Kartrider.Api.Endpoints.UserEndpoint
{
    /// <summary>
    /// 유저 정보 API Endpoint
    /// </summary>
    public class UserEndpoint : IUserEndpoint
    {
        private const string AccountRootUrl = "/users";
        private const string ByNickname = "/nickname/{0}";
        private readonly IRequester _requester;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="requester"></param>
        public UserEndpoint(IRequester requester)
        {
            _requester = requester;
        }
        /// <inheritdoc/>
        public async Task<User> GetUserByAccessIdAsync(string accessId)
        {
            var json = await _requester.CreateGetRequestAsync($"{AccountRootUrl}/{accessId}").ConfigureAwait(false);
            return JsonSerializer.Deserialize<User>(json);
        }
        /// <inheritdoc/>
        public async Task<User> GetUserByNicknameAsync(string nickname)
        {
            var json = await _requester.CreateGetRequestAsync($"{AccountRootUrl}{string.Format(ByNickname, nickname)}")
                .ConfigureAwait(false);
            return JsonSerializer.Deserialize<User>(json);
        }
    }
}