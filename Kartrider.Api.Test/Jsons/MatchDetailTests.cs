using System;
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

        [DataTestMethod]
        [DataRow("02480011c20941a3")]
        [DataRow("02480011c213bed1")]
        [DataRow("02480011c216268a")]
        [DataRow("02480011c21b59b7")]
        [DataRow("02480011c21d9fee")]
        [DataRow("02480011c21fd637")]
        [DataRow("02480011c223049b")]
        [DataRow("02480011c2256688")]
        [DataRow("02480011c2279c15")]
        [DataRow("02480011c22a9a80")]
        [DataRow("02480011c22cccf1")]
        [DataRow("02480011c22f52c1")]
        [DataRow("02480011c2317080")]
        [DataRow("02480011c2345374")]
        [DataRow("02480011c2370c99")]
        [DataRow("032b000dc4945b28")]
        public async Task Json_Read(string matchId)
        {
            try
            {
                await kartriderApi.Match.GetMatchDetailAsync(matchId);
            }
            catch (JsonException e)
            {
                Assert.Fail(e.ToString());
            }
        }
    }
}
