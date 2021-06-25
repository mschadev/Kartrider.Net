using Kartrider.Api.Endpoints.Interfaces;

namespace Kartrider.Api
{
    /// <summary>
    /// KartriderApi Wrapper library interface.
    /// </summary>
    public interface IKartriderApi
    {
        /// <summary>
        /// 유저 정보 API
        /// </summary>
        IUserEndpoint User { get; }
        /// <summary>
        /// 매치 정보 API
        /// </summary>
        IMatchEndpoint Match { get; }
    }
}