﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestStaticMember.Model;

namespace UnitTestStaticMember
{
    class Program
    {
        static void Main(string[] args)
        {
            // サービス情報を初期化する
            // Init 内で "認可された 権限コード(AuthorityCode) のリスト" を初期化する
            ServiceManager.Init();

            // User(Name, AuthorityCode) のリストを作成する(userManager に渡すため)
            var users = new List<IUser>()
            {
                new User("foo", AuthorityCode.A), new User("bar", AuthorityCode.B)
            };

            // サービスにて認可された 権限コード(AuthorityCode) を所有したユーザーだけを表示する
            // プロジェクト実装上 User:"foo" だけが表示される
            var userManager = new UserManager(users);
            var authzUserList = userManager.AuthorizedUserList();
            foreach(var authzUList in authzUserList)
            {
                System.Console.WriteLine(authzUList.Name);
            }
        }
    }
}
