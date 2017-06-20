using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestStaticMember.Model
{
    public class UserManager
    {
        public UserManager(List<IUser> userList)
        {
            this.userList = userList;
        }

        /// <summary>
        /// get users they have service's authorized code; S or A.
        /// return type is list.
        /// </summary>
        public List<IUser> AuthorizedUserList()
        {
            var authzCodes = ServiceManager.GetServiceAuthorizedCode();
            return userList.Select(user => user)
                           .Where(user => authzCodes.Contains(user.AuthCode))
                           .ToList();
        }

        private List<IUser> userList;
    }
}
