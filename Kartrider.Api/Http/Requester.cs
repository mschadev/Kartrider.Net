using Kartrider.Api.Http.Interfaces;

using System.Net.Http;
using System.Threading.Tasks;

namespace Kartrider.Api.Http
{
    /// <summary>
    /// Http Requester
    /// </summary>
    /// <seealso cref="Kartrider.Api.Http.RequesterBase" />
    /// <seealso cref="Kartrider.Api.Http.Interfaces.IRequester" />
    public class Requester : RequesterBase, IRequester
    {
        /// <inheritdoc />
        public Requester(string apiKey) : base(apiKey)
        {
        }

        /// <inheritdoc />
        public Requester()
        {
        }

        #region Public Methods

        /// <inheritdoc />
        public async Task<string> CreateGetRequestAsync(string relativeUrl)
        {
            var request = PrepareRequest(relativeUrl, HttpMethod.Get);
            var response = await SendAsync(request).ConfigureAwait(false);
            return await GetResponseContentAsync(response).ConfigureAwait(false);
        }
        #endregion Public Methods
    }
}