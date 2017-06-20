using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestStaticMember.Model
{
    public interface IUser
    {
        string Name { get; }
        AuthorityCode AuthCode { get; }
    }

    public class User : IUser
    {
        public User(string name, AuthorityCode authorityCode)
        {
            this.name = name;
            this.authorityCode = authorityCode;
        }

        public string Name
        {
            get { return this.name; }
        }

        public AuthorityCode AuthCode
        {
            get { return authorityCode; }
        }

        private string name;
        private AuthorityCode authorityCode;
    }
}
