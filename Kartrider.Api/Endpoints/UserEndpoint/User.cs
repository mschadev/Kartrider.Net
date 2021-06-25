using System.Text.Json.Serialization;

namespace Kartrider.Api.Endpoints.UserEndpoint
{
    /// <summary>
    /// 유저 정보
    /// </summary>
    public class User
    {
        /// <summary>
        /// 닉네임
        /// </summary>
        [JsonPropertyName("name")]
        public string Nickname { get; set; }

        /// <summary>
        /// 유저 고유 식별자
        /// </summary>
        [JsonPropertyName("accessId")]
        public string AccessId { get; set; }
        /// <summary>
        /// 레벨
        /// </summary>
        [JsonPropertyName("level")] public int Level { get; set; }
    }
}