using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Jsons
{
    [TestClass]
    public class MatchDetailTests : TestBase
    {
        [DataTestMethod]
        [DataRow(0, DisplayName = "Get all match detail, offset: 0")]
        [DataRow(100, DisplayName = "Get all match detail, offset: 100")]
        [DataRow(200, DisplayName = "Get all match detail, offset: 200")]
        [DataRow(300, DisplayName = "Get all match detail, offset: 300")]
        [DataRow(400, DisplayName = "Get all match detail, offset: 400")]
        public async Task Json_Write(int offset)
        {
            AllMatches allMatches = await kartriderApi.Match.GetAllMatchesAsync(null, null, offset, 50);
            foreach (string matchId in allMatches.Matches.SelectMany(p => p.Value))
            {
                var data = await kartriderApi.Match.GetMatchDetailAsync(matchId);
                var json = JsonSerializer.Serialize(data, new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });
            }
        }
        // Json Read는 메서드 내부적으로 진행하므로 스킵
    }
}
