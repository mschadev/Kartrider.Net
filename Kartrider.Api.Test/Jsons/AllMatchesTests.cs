using Kartrider.Api.Endpoints.MatchEndpoint.Models;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.Json;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Jsons
{
    [TestClass]
    public class AllMatchesTests : TestBase
    {
        [DataTestMethod]
        [DataRow(0, DisplayName = "Get all matches offset 0")]
        [DataRow(100, DisplayName = "Get all matches offset 100")]
        [DataRow(200, DisplayName = "Get all matches offset 200")]
        public async Task Json_Write(int offset)
        {
            AllMatches data = await kartriderApi.Match.GetAllMatchesAsync(null, null, offset, 100);
            JsonSerializer.Serialize(data);
        }
        // Json Read는 메서드 내부적으로 진행하므로 스킵
    }
}