using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Linq;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints.Match
{
    [TestClass]
    public class MatchesByAccessIdTests : TestBase
    {
        [DataTestMethod]
        [DataRow("117717532")]
        public async Task Get_Matches_By_AccessId(string accessId)
        {
            await kartriderApi.Match.GetMatchesByAccessIdAsync(accessId, null, null, 0, 500);
        }
        [TestMethod("존재하지 않은 AccessId")]
        public async Task Get_Matches_By_AccessId_NotFound()
        {
            const string accessId = "1";
            Func<Task> action = async () =>  await kartriderApi.Match.GetMatchesByAccessIdAsync(accessId);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }
        [DataTestMethod]
        [DataRow("117717532", 0,10,null)]
        [DataRow("117717532", 0,100,new object[] { "effd66758144a29868663aa50e85d3d95c5bc0147d7fdb9802691c2087f3416e" })]
        public async Task Get_Matches_By_AccessId_Limit_Validation(string accessId,int offset,int limit,object[] matchTypeObjects)
        {
            string[] matchTypes = matchTypeObjects?.Select(p => p.ToString()).ToArray();
            var res  = await kartriderApi.Match.GetMatchesByAccessIdAsync(accessId, null, null,offset,limit,matchTypes);
            int resCount = res.Matches.SelectMany(p => p.Value).Count();
            Assert.AreEqual(limit, resCount);
        }
    }
}