using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApp
{
    /// <summary>
    /// 共通定義クラス
    /// </summary>
    public class Common
    {
        #region 定数
        /// <summary>
        /// DB02(文字列)
        /// </summary>
        public const string DB02 = "DB02.db";

        /// <summary>
        /// DB03(文字列)
        /// </summary>
        public const string DB03 = "DB03.db";
        #endregion

        #region メッセージ
        /// <summary>
        /// 日付チェックメッセージ
        /// </summary>
        public const string NODATEMSG = "日付を正しく入力してください";

        /// <summary>
        /// 初期設定登録メッセージ
        /// </summary>
        public const string INITDATAMSG = "残高の登録をしました";

        /// <summary>
        /// 入力データ消去メッセージ
        /// </summary>
        public const string DATADELMSG = "入力データは消えてしまいますが戻ってもよろしいですか？";

        /// <summary>
        /// 警告メッセージ
        /// </summary>
        public const string WARNINGMSG = "警告";

        #endregion

        #region パブリックメソッド
        /// <summary>
        /// カンマ区切り
        /// </summary>
        /// <param name="strNum">カンマ区切りする文字</param>
        /// <returns></returns>
        public string CommaSeparated(string strNum)
        {
            string strRet = string.Empty;

            try
            {
                strRet = (String.Format("{0:#,0}", Convert.ToInt32(strNum)) == null) ? "" : String.Format("{0:#,0}", Convert.ToInt32(strNum));
            }
            catch
            {
                throw;
            }

            return strRet;
        }

        /// <summary>
        /// 日付"/"追加
        /// </summary>
        /// <param name="Date">日付</param>
        /// <returns></returns>
        public string DateSeparation(string Date)
        {
            string dateRet = string.Empty;

            try
            {
                dateRet = Date.Substring(0, 4) + "/" + Date.Substring(4, 2) + "/" + Date.Substring(6, 2);
            }
            catch
            {
                dateRet = "None";
            }

            return dateRet;
        }

        /// <summary>
        /// 日付チェックメソッド
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckDate(string date)
        {
            try
            {
                // 日付が8文字かチェック
                if (date.Length == 8)
                {
                    return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }
        #endregion
    }
}
