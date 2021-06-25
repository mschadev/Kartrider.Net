using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Linq;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints.Match
{
    [TestClass]
    public class GetAllMatchesTests : TestBase
    {
        [DataTestMethod]
        [DataRow(10, DisplayName = "Limit: 10")]
        [DataRow(100, DisplayName = "Limit: 100")]
        [DataRow(500, DisplayName = "Limit: 500")]
        public async Task Get_All_Matches_Limit_Validation(int limit)
        {
            var allMatches = await kartriderApi.Match.GetAllMatchesAsync(null, null, 0, limit, null);
            int matchCount = allMatches.Matches.SelectMany(p => p.Value).Count();
            Assert.AreEqual(limit, matchCount);
        }

        [DataTestMethod]
        [DataRow(new object[] { "speedIndiFastest" }, DisplayName = "스피드 개인전(매우 빠름)")]
        [DataRow(new object[] { "speedIndiFastest", "speedIndiInfinit" }, DisplayName = "스피드 개인전(매우빠름), 스피드 개인전(무한부스터)")]
        public async Task Get_All_Matches_MatchTypes_Validation(object[] objs)
        {
            string[] matchTypes = objs.Select(p => p.ToString()).ToArray();
            var allMatches = await kartriderApi.Match.GetAllMatchesAsync(null, null, 0, 10, matchTypes);
            foreach (string matchType in matchTypes)
            {
                Assert.IsFalse(allMatches.Matches.ContainsKey(matchType));
            }
        }
        [DataTestMethod]
        // 스피드 팀전
        [DataRow(10,new object[] { "effd66758144a29868663aa50e85d3d95c5bc0147d7fdb9802691c2087f3416e" }, DisplayName = "Limit: 10, matchTypes: 스피드 팀전")]
        // 스피드 개인전
        [DataRow(100, new object[] { "7b9f0fd5377c38514dbb78ebe63ac6c3b81009d5a31dd569d1cff8f005aa881a" },DisplayName = "Limit: 100, matchTypes: 스피드 개인전")]
        // 스피드 개인전, 스피드 팀전
        [DataRow(500, new object[] { "7b9f0fd5377c38514dbb78ebe63ac6c3b81009d5a31dd569d1cff8f005aa881a", "effd66758144a29868663aa50e85d3d95c5bc0147d7fdb9802691c2087f3416e" }, DisplayName = "Limit: 500, matchTypes: 스피드 개인전, 스피드 팀전")]
        public async Task Get_All_Matches_Limit_With_MatchTypes_Validation(int limit,params object[] matchTypeObjects)
        {
            string[] matchTypes = matchTypeObjects?.Select(p => p.ToString()).ToArray();
            var allMatches = await kartriderApi.Match.GetAllMatchesAsync(null, null, 0, limit, matchTypes);
            int matchCount = allMatches.Matches.SelectMany(p => p.Value).Count();
            Assert.AreEqual(limit, matchCount);
        }
    }
}