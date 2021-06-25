using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints
{
    [TestClass]
    public class GetUserTests : TestBase
    {
        [DataTestMethod]
        [DataRow("extern", DisplayName = "라이더명: extern")]
        [DataRow("TTEESSTT", DisplayName = "라이더명: TTEESSTT")]
        public async Task Get_User_By_Nickname(string nickname)
        {
            await kartriderApi.User.GetUserByNicknameAsync(nickname);
        }

        [DataTestMethod]
        [DataRow("extern123123", DisplayName = "라이더명: extern123123")]
        [DataRow("TTEESSTT123123", DisplayName = "라이더명: TTEESSTT123123")]
        public async Task Get_User_By_Nickname_NotFound(string nickname)
        {
            Func<Task> action = async () => await kartriderApi.User.GetUserByNicknameAsync(nickname);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }

        [DataTestMethod]
        [DataRow("117717532", DisplayName = "유저 고유 식별자: 117717532")]
        [DataRow("302575272", DisplayName = "유저 고유 식별자: 302575272")]
        public async Task Get_User_By_AccessId(string accessId)
        {
            await kartriderApi.User.GetUserByAccessIdAsync(accessId);
        }

        [DataTestMethod]
        [DataRow("1", DisplayName = "AccessId: 1 (존재하지 않은 유저)")]
        public async Task Get_User_By_AccessId_NotFound(string nickname)
        {
            Func<Task> action = async () => await kartriderApi.User.GetUserByAccessIdAsync(nickname);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }
    }
}