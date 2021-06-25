using Kartrider.Api.Endpoints.UserEndpoint;

using System.Threading.Tasks;

namespace Kartrider.Api.Endpoints.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserEndpoint
    {
        /// <summary>
        /// 라이더명으로 유저 정보 조회
        /// </summary>
        /// <remarks>
        /// 라이더명으로 유저의 정보를 조회합니다.<br/>
        /// <see href="https://developers.nexon.com/kart/api/12/33">API Docs</see>
        /// </remarks>
        /// <param name="nickname">유저 닉네임(라이더명)</param>
        /// <returns>유저 고유 식별자, 레벨, 닉네임 프로퍼티가 있는 인스턴스</returns>
        /// <exception cref="Kartrider.Api.KartriderApiException">description</exception>
        Task<User> GetUserByNicknameAsync(string nickname);
        /// <summary>
        /// 유저 고유 식별자로 라이더명 조회
        /// </summary>
        /// <remarks>
        /// 유저 고유 식별자로 유저의 정보를 조회합니다.<br/>
        /// <see href="https://developers.nexon.com/kart/api/12/32">API Docs</see>
        /// </remarks>
        /// <param name="accessId">유저 고유 식별자</param>
        /// <returns>유저 고유 식별자, 레벨, 닉네임 프로퍼티가 있는 인스턴스</returns>
        /// <exception cref="Kartrider.Api.KartriderApiException">description</exception>
        Task<User> GetUserByAccessIdAsync(string accessId);
    }
}