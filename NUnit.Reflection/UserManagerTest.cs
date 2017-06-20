using NUnit.Framework;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnitTestStaticMember.Model;

namespace NUnit.Reflection
{
    [TestFixture]
    public class UserManagerTest
    {
        [Test]
        public void AuthorizedUserListNotEmpty()
        {
            // ここからリフレクション
            // ServiceManager > authorizedCode(private static) に値割り当てる
            // 結果的に ServiceManager > GetServiceAuthorizedCode() の返却値がスタブされている
            var authzCode = new List<AuthorityCode>() { AuthorityCode.S, AuthorityCode.A }; // 
            FieldInfo authorizedCode = typeof(ServiceManager).GetField("authorizedCode", BindingFlags.NonPublic | BindingFlags.Static);
            authorizedCode.SetValue(new ServiceManager(), authzCode);
            // ここまでリフレクション

            var user1 = Substitute.For<IUser>();
            user1.AuthCode.Returns(AuthorityCode.A);
            var userList = new List<IUser>() { user1 };
            var userManger = new UserManager(userList);

            Assert.AreEqual(1, userManger.AuthorizedUserList().Count);
        }
    }
}
