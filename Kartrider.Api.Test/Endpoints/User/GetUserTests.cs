using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Threading.Tasks;

namespace Kartrider.Api.Test.Endpoints
{
    [TestClass]
    public class GetUserTests : TestBase
    {
        [DataTestMethod]
        [DataRow("extern", DisplayName = "���̴���: extern")]
        [DataRow("TTEESSTT", DisplayName = "���̴���: TTEESSTT")]
        public async Task Get_User_By_Nickname(string nickname)
        {
            await kartriderApi.User.GetUserByNicknameAsync(nickname);
        }

        [DataTestMethod]
        [DataRow("extern123123", DisplayName = "���̴���: extern123123")]
        [DataRow("TTEESSTT123123", DisplayName = "���̴���: TTEESSTT123123")]
        public async Task Get_User_By_Nickname_NotFound(string nickname)
        {
            Func<Task> action = async () => await kartriderApi.User.GetUserByNicknameAsync(nickname);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }

        [DataTestMethod]
        [DataRow("117717532", DisplayName = "���� ���� �ĺ���: 117717532")]
        [DataRow("302575272", DisplayName = "���� ���� �ĺ���: 302575272")]
        public async Task Get_User_By_AccessId(string accessId)
        {
            await kartriderApi.User.GetUserByAccessIdAsync(accessId);
        }

        [DataTestMethod]
        [DataRow("1", DisplayName = "AccessId: 1 (�������� ���� ����)")]
        public async Task Get_User_By_AccessId_NotFound(string nickname)
        {
            Func<Task> action = async () => await kartriderApi.User.GetUserByAccessIdAsync(nickname);
            await Assert.ThrowsExceptionAsync<KartriderApiException>(action);
        }
    }
}