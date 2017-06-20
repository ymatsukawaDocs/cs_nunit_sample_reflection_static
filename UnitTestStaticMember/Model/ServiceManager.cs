using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestStaticMember.Model
{
    public class ServiceManager
    {
        /// <summary>
        /// アプリ立ち上げ時に実行するメソッド
        /// 初期化処理を突っ込む
        /// </summary>
        public static void Init()
        {
            InitServiceAuthorizedCode();
        }

        /// <summary>
        /// 初期化した static 変数を取得するメソッド
        /// 徒に static 変数を public へしないための対策
        /// </summary>
        /// <returns></returns>
        public static List<AuthorityCode> GetServiceAuthorizedCode()
        {
            return authorizedCode;
        }

        private static void InitServiceAuthorizedCode()
        {
            // TODO: 将来的には WebAPI をコールして
            // レスポンスをパースした結果を List に Add したい
            // すなわち、このメソッド処理内で HTTP リクエストが発生する予定
            authorizedCode.Add(AuthorityCode.S);
            authorizedCode.Add(AuthorityCode.A);
        }

        private static List<AuthorityCode> authorizedCode = new List<AuthorityCode>();
    }
}
