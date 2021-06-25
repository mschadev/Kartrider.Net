using Kartrider.Api.Endpoints.Interfaces;
using Kartrider.Api.Endpoints.MatchEndpoint;
using Kartrider.Api.Endpoints.UserEndpoint;
using Kartrider.Api.Http;

namespace Kartrider.Api
{
    /// <summary>
    /// Kartrider OPEN API wrapper class.
    /// </summary>
    public class KartriderApi : IKartriderApi
    {
        #region Private Fields

        private static KartriderApi _instance;

        #endregion Private Fields

        #region Endpoints

        /// <inheritdoc/>
        public IUserEndpoint User { get; }
        /// <inheritdoc/>
        public IMatchEndpoint Match { get; }

        #endregion Endpoints
        private KartriderApi(string apiKey)
        {
            Requesters.KartriderApiRequester = new Requester(apiKey);
            var requester = Requesters.KartriderApiRequester;

            User = new UserEndpoint(requester);
            Match = new MatchEndpoint(requester);
        }
        /// <summary>
        /// KartriderApi 인스턴스 생성
        /// </summary>
        /// <param name="apiKey">API Key</param>
        /// <returns></returns>
        public static KartriderApi GetInstance(string apiKey)
        {
            if (_instance == null || Requesters.KartriderApiRequester == null ||
                apiKey != Requesters.KartriderApiRequester.ApiKey)
                _instance = new KartriderApi(apiKey);
            return _instance;
        }
    }
}