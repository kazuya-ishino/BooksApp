using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/* ----<テスト>-------- */
using System.Data.SQLite;
/* ----<テスト>-------- */

namespace BooksApp
{
    /// <summary>
    /// ホーム画面クラス
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            Db db = new Db();

            try
            {
                InitializeComponent();

                // 起動時にBACKUPを取得
                if (File.Exists(db.DBFilePath + Common.DB02))
                {
                    File.Copy(db.DBFilePath + Common.DB02, db.DBFileBackupPath + Common.DB02, true);
                }

                if (File.Exists(db.DBFilePath + Common.DB03))
                {
                    File.Copy(db.DBFilePath + Common.DB03, db.DBFileBackupPath + Common.DB03, true);
                }

                /* ----<テスト>-------- */
                //using (var connection = new SQLiteConnection("Data Source=Sample.db"))
                //using (var connection = new SQLiteConnection("DATA Source = ../../DB02"))
                //{
                //    connection.Open();
                //    using (var command = connection.CreateCommand())
                //    {
                //        command.CommandText = "CREATE TABLE IF NOT EXISTS Sample( Name TEXT)";
                //        command.ExecuteNonQuery();
                //    }
                //    connection.Close();
                //}

                //Common common = new Common();
                //common.DateSeparation("4545");
                /* ----<テスト>-------- */
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 初期設定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInit_Click(object sender, EventArgs e)
        {
            FrmInit frmInit = new FrmInit();

            try
            {
                frmInit.ShowDialog();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 仕訳帳ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSorting_Click(object sender, EventArgs e)
        {
            FrnSorting frnSorting = new FrnSorting();

            try
            {
                frnSorting.ShowDialog();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 現金出納帳ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCash_Click(object sender, EventArgs e)
        {
            FrmCash frmCash = new FrmCash();

            try
            {
                frmCash.ShowDialog();
            }
            catch
            {
                throw;
            }
        }
    }
}
