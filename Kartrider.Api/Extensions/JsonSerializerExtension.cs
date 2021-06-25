using System.Text.Json;

namespace Kartrider.Api.Extensions
{
    /// <summary>
    /// Json Serializer, Deserializer Extension
    /// </summary>
    /// <remarks>
    /// <see href="https://stackoverflow.com/a/65433372">Source</see>
    /// </remarks>
    public static class JsonSerializerExtension
    {
#pragma warning disable IDE0060 // 사용하지 않는 매개 변수를 제거하세요.
        /// <summary>
        /// json string을 익명 타입 객체로 반환
        /// </summary>
        /// <typeparam name="T">객체</typeparam>
        /// <param name="json"></param>
        /// <param name="anonymousTypeObject">익명 타입 객체</param>
        /// <param name="options">JsonSerializerOptions 옵션</param>
        /// <returns></returns>
        public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject,
            JsonSerializerOptions options = default)
#pragma warning restore IDE0060 // 사용하지 않는 매개 변수를 제거하세요.
        {
            return JsonSerializer.Deserialize<T>(json, options);
        }
    }
}