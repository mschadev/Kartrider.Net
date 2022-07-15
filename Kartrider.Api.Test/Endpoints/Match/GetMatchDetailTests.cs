using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints.Match
{
    [TestClass]
    public class GetMatchDetailTests : TestBase
    {
        [TestMethod("존재하지 않은 매치 상세 정보")]
        public async Task Get_Match_Detail_NotFound()
        {
            const string matchId = "1";
            Func<Task> action = async () => await kartriderApi.Match.GetMatchDetailAsync(matchId);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }
    }
}