using System.Threading.Tasks;

namespace Kartrider.Api.Http.Interfaces
{
    /// <summary>
    /// HTTP Requester Interface
    /// </summary>
    public interface IRequester
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="relativeUrl">API Relative Url</param>
        /// <returns></returns>
        Task<string> CreateGetRequestAsync(string relativeUrl);
    }
}