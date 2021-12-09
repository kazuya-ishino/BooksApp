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
    public partial class FrmSortingList : Form
    {
        #region プライベート定数

        /// <summary>
        /// 日付けインデックス番号
        /// </summary>
        private const int DGV_INDEX_DATE = 0;

        /// <summary>
        /// 勘定科目(借方)インデックス番号
        /// </summary>
        private const int DGV_INDEX_ACCONT_DEBIT = 1;

        /// <summary>
        /// 金額(借方)インデックス番号
        /// </summary>
        private const int DGV_INDEX_MONEY_DEBIT = 2;

        /// <summary>
        /// 空白区切りインデックス番号
        /// </summary>
        private const int DGV_INDEX_EMPTY = 3;

        /// <summary>
        /// 勘定科目(貸方)インデックス番号
        /// </summary>
        private const int DGV_INDEX_ACCONT_CREDIT = 4;

        /// <summary>
        /// 金額(貸方)インデックス番号
        /// </summary>
        private const int DGV_INDEX_MONEY_CREDIT = 5;

        #endregion

        #region コンストラクタ
        public FrmSortingList()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSortingList_Load(object sender, EventArgs e)
        {
            Db db = new Db();
            Common common = new Common();
            DataTable dt = new DataTable();
            string sql = "select * from db02";

            try
            {
                dt = db.GetData(db.ConnectStringDB02, sql);

                // 行数を設定
                DgvSorting.RowCount = dt.Rows.Count;

                for (int row = 0; row < dt.Rows.Count; row++)
                {
                    // 日付け
                    DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value = common.DateSeparation(dt.Rows[row]["DATE"].ToString().Trim());

                    // 勘定科目(借方)
                    DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_DEBIT].Value = dt.Rows[row]["DEBITACCOUNT"].ToString().Trim();

                    // 金額(借方)
                    DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_DEBIT].Value = common.CommaSeparated(dt.Rows[row]["DEBITMONEY"].ToString().Trim());

                    // 勘定科目(貸方)
                    DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_CREDIT].Value = dt.Rows[row]["CREDITACCOUNT"].ToString().Trim();

                    // 金額(貸方)
                    DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_CREDIT].Value = common.CommaSeparated(dt.Rows[row]["CREDITMONEY"].ToString().Trim());
                }

                // アライメント
                DgvSorting.Columns[DGV_INDEX_DATE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgvSorting.Columns[DGV_INDEX_MONEY_DEBIT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvSorting.Columns[DGV_INDEX_MONEY_CREDIT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 印刷クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPrint_Click(object sender, EventArgs e)
        {
            DataGridViewPrinter dataGridViewPrinter = new DataGridViewPrinter(DgvSorting);

            try
            {
                // 印刷処理
                dataGridViewPrinter.Print("仕訳帳");
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
