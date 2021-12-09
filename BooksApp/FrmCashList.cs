using DataGridViewHelper;
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
    public partial class FrmCashList : Form
    {
        #region プライベート定数

        /// <summary>
        /// 日付けインデックス番号
        /// </summary>
        private const int DGV_INDEX_DATE = 0;

        /// <summary>
        /// 勘定科目インデックス番号
        /// </summary>
        private const int DGV_INDEX_ACCONTT = 1;

        /// <summary>
        /// 摘要インデックス番号
        /// </summary>
        private const int DGV_INDEX_DESCRIPTION = 2;

        /// <summary>
        /// 入金インデックス番号
        /// </summary>
        private const int DGV_INDEX_PAYMENT = 3;

        /// <summary>
        /// 出金(現金仕入)インデックス番号
        /// </summary>
        private const int DGV_INDEX_CASH = 4;

        /// <summary>
        /// 出金(その他)インデックス番号
        /// </summary>
        private const int DGV_INDEX_OTHER = 5;

        /// <summary>
        /// 残高インデックス番号
        /// </summary>
        private const int DGV_INDEX_BALANCE = 6;

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrmCashList()
        {
            InitializeComponent();
        }

        #region イベント

        /// <summary>
        /// 印刷ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(DgvCash);

            try
            {
                // 印刷処理
                dataGridViewPrinter.Print("現金出納帳");
            }
            catch
            {
                throw;
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
                // 画面を閉じる
                this.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCashList_Load(object sender, EventArgs e)
        {
            Db db = new Db();
            Common common = new Common();
            DataTable dt = new DataTable();
            string sql = "select * from db03";

            try
            {
                dt = db.GetData(db.ConnectStringDB03, sql);

                // 行数を設定
                DgvCash.RowCount = dt.Rows.Count;

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    // 日付け
                    DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value = common.DateSeparation(dt.Rows[row]["DATE"].ToString().Trim());

                    // 勘定科目
                    DgvCash.Rows[row].Cells[DGV_INDEX_ACCONTT].Value = dt.Rows[row]["ACCOUNT"].ToString().Trim();

                    // 摘要)
                    DgvCash.Rows[row].Cells[DGV_INDEX_DESCRIPTION].Value = dt.Rows[row]["DESCRIPTION"].ToString().Trim();

                    // 入金
                    DgvCash.Rows[row].Cells[DGV_INDEX_PAYMENT].Value = common.CommaSeparated(dt.Rows[row]["PAYMENT"].ToString().Trim());

                    // 出金(現金仕入)
                    DgvCash.Rows[row].Cells[DGV_INDEX_CASH].Value = common.CommaSeparated(dt.Rows[row]["CASH"].ToString().Trim());

                    // 出金(その他)
                    DgvCash.Rows[row].Cells[DGV_INDEX_OTHER].Value = common.CommaSeparated(dt.Rows[row]["OTHER"].ToString().Trim());

                    // 残高
                    DgvCash.Rows[row].Cells[DGV_INDEX_BALANCE].Value = common.CommaSeparated(dt.Rows[row]["BALANCE"].ToString().Trim());
                }

                // アライメント
                DgvCash.Columns[DGV_INDEX_DATE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgvCash.Columns[DGV_INDEX_PAYMENT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_CASH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_OTHER].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_BALANCE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
