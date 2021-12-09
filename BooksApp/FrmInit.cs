using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BooksApp
{
    public partial class FrmInit : Form
    {
        public FrmInit()
        {
            Db db = new Db();

            try
            {
                InitializeComponent();

                db.CheckDBFile(db.DBFilePath, Common.DB03);
            }
            catch
            {
                throw;
            }
        }

        #region イベント
        /// <summary>
        /// 登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFix_Click(object sender, EventArgs e)
        {
            List<string> sqls = new List<string>();
            Db db = new Db();

            try
            {
                // INSERT文を作成
                sqls.Add($"insert into DB03 values('00000000', '初期設定', '初期設定', 0, 0,  0, {TxtDepositBalance.Text})");

                // SQL実行
                db.ExecuteNoneQueryWithTransaction(db.ConnectStringDB03, sqls);
            }
            catch
            {
                throw;
            }
            finally
            {
                // テキストボックス値クリア
                TxtDepositBalance.Text = string.Empty;

                // 登録しました
                MessageBox.Show(Common.INITDATAMSG);
            }
        }

        /// <summary>
        /// 戻るボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch
            {
                throw;
            }
        }
        #endregion


    }
}
