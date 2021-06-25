using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints.Match
{
    [TestClass]
    public class GetMatchDetailTests : TestBase
    {
        [DataTestMethod]
        [DataRow("036e0001f656572a", DisplayName = "아이템 팀 배틀모드: 036e0001f656572a")]
        [DataRow("036a000ef64df337", DisplayName = "스피드 개인전: 036a000ef64df337")]
        [DataRow("0343000ef64d9a4a", DisplayName = "스피드 개인전: 0343000ef64d9a4a")]
        [DataRow("03210018f64ff810", DisplayName = "스피드 팀전: 03210018f64ff810")]
        [DataRow("02080018f64fe39e", DisplayName = "스피드 팀전: 02080018f64fe39e")]
        [DataRow("00d40009f64d9038", DisplayName = "아이템 팀전: 00d40009f64d9038")]
        public async Task Get_Match_Detail(string matchId)
        {
            await kartriderApi.Match.GetMatchDetailAsync(matchId);
        }
        [TestMethod("존재하지 않은 매치 상세 정보")]
        public async Task Get_Match_Detail_NotFound()
        {
            const string matchId = "1";
            Func<Task> action = async () => await kartriderApi.Match.GetMatchDetailAsync(matchId);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }
    }
}