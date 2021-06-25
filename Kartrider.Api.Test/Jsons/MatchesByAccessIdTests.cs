using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Jsons
{
    [TestClass]
    public class MatchesByAccessIdTests : TestBase
    {
        [DataTestMethod]
        // Extern
        [DataRow(0, "117717532", DisplayName = "Get all matches by accessId: 117717532, offset: 0")]
        [DataRow(100, "117717532", DisplayName = "Get all matches by accessId: 117717532, offset: 100")]
        [DataRow(200, "117717532", DisplayName = "Get all matches by accessId: 117717532, offset: 200")]
        // TTEESSTT
        [DataRow(0, "302575272", DisplayName = "Get all matches by accessId: 302575272, offset: 0")]
        [DataRow(100, "302575272", DisplayName = "Get all matches by accessId: 302575272, offset: 100")]
        [DataRow(200, "302575272", DisplayName = "Get all matches by accessId: 302575272, offset: 200")]
        public async Task Json_Write(int offset, string accessId)
        {
            MatchesByAccessId data = await kartriderApi.Match.GetMatchesByAccessIdAsync(accessId, null, null, offset, 100,new string[] { "effd66758144a29868663aa50e85d3d95c5bc0147d7fdb9802691c2087f3416e" });
            JsonSerializer.Serialize(data);
        }
        // Json Read는 메서드 내부적으로 진행하므로 스킵
    }
}
