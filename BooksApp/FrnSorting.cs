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
    /// <summary>
    /// 仕分け帳クラス
    /// </summary>
    public partial class FrnSorting : Form
    {
        #region プライベートメソッド定数
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

        /// <summary>
        /// 日付
        /// </summary>
        private const string DGV_HEADER_DATE = "日付";

        /// <summary>
        /// 勘定科目(借方)
        /// </summary>
        private const string DGV_HEADER_ACCOUNT_DEBIT = "勘定科目";

        /// <summary>
        /// 金額(借方)
        /// </summary>
        private const string DGV_HEADER_MONEY_DEBIT = "金額";

        /// <summary>
        /// 区切り
        /// </summary>
        private const string DGV_HEADER_EMPTY = "";

        /// <summary>
        /// 勘定科目(貸方)
        /// </summary>
        private const string DGV_HEADER_ACCOUNT_CREDIT = "勘定科目";

        /// <summary>
        /// 金額(貸方)
        /// </summary>
        private const string DGV_HEADER_MONEY_CREDIT = "金額";

        /// <summary>
        /// 日付
        /// </summary>
        private const int DGV_WIDTH_DATE = 100;

        /// <summary>
        /// 勘定科目(借方)
        /// </summary>
        private const int DGV_WIDTH_ACCOUNT_DEBIT = 200;

        /// <summary>
        /// 金額(借方)
        /// </summary>
        private const int DGV_WIDTH_MONEY_DEBIT = 100;

        /// <summary>
        /// 区切り
        /// </summary>
        private const int DGV_WIDTH_EMPTY = 20;

        /// <summary>
        /// 勘定科目(貸方)
        /// </summary>
        private const int DGV_WIDTH_ACCOUNT_CREDIT = 200;

        /// <summary>
        /// 金額
        /// </summary>
        private const int DGV_WIDTH_MONEY_CREDIT = 100;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrnSorting()
        {
            Db db = new Db();

            try
            {
                InitializeComponent();

                // データベースファイルが存在するかチェック
                db.CheckDBFile(db.DBFilePath, Common.DB02);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region イベントメソッド
        /// <summary>
        /// ロードイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrnSorting_Load(object sender, EventArgs e)
        {
            try
            {
                // 初期化
                ClearGridView();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 登録ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFix_Click(object sender, EventArgs e)
        {
            Db db = new Db();
            Common common = new Common();
            List<string> sqls = new List<string>();
            string date = string.Empty;
            string accountDebit = string.Empty;
            string moneyDebit = string.Empty;
            string accountCredit = string.Empty;
            string moneyCredit = string.Empty;

            try
            {
                // 日付入力チェック
                for (int row = 0; row < this.DgvSorting.RowCount; row++)
                {
                    if (this.DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        if (!common.CheckDate(this.DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value.ToString()))
                        {
                            // 日付を正しく入力してください
                            MessageBox.Show(Common.NODATEMSG);
                            return;
                        }
                    }
                }

                // データベースに値を登録
                for (int row = 0; row < this.DgvSorting.RowCount; row++)
                {
                    if (this.DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        date = (this.DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value == null) ? string.Empty : this.DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value.ToString();
                        accountDebit = (this.DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_DEBIT].Value == null) ? string.Empty : this.DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_DEBIT].Value.ToString();
                        moneyDebit = (this.DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_DEBIT].Value == null) ? "0" : this.DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_DEBIT].Value.ToString();
                        accountCredit = (this.DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_CREDIT].Value == null) ? string.Empty : this.DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_CREDIT].Value.ToString();
                        moneyCredit = (this.DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_CREDIT].Value == null) ? "0" : this.DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_CREDIT].Value.ToString();

                        // INSERT文を作成
                        //sqls.Add($"insert into DB02 values('null', '{date}', '{accountDebit}', '{moneyDebit}', '{accountCredit}', {moneyCredit})");
                        sqls.Add($"insert into DB02 values('null', '{date}', '{accountDebit}', {moneyDebit}, '{accountCredit}', {moneyCredit})");
                    }
                    else
                    {
                        break;
                    }
                }

                // SQL実行
                db.ExecuteNoneQueryWithTransaction(db.ConnectStringDB02, sqls);

                // データグリッドビューの値クリア
                ClearGridView();
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
            MessageBoxButtons button = MessageBoxButtons.OKCancel;
            MessageBoxIcon icon = MessageBoxIcon.Warning;
            MessageBoxDefaultButton defaultButton = MessageBoxDefaultButton.Button2;

            try
            {
                if (CheckDataDel())
                {
                    // 画面を閉じる
                    this.Close();
                }
                else
                {
                    DialogResult dialogResult = MessageBox.Show(this, Common.DATADELMSG, Common.WARNINGMSG, button, icon, defaultButton);

                    if (dialogResult == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 仕訳帳一覧ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSortingList_Click(object sender, EventArgs e)
        {
            FrmSortingList frnSortingList = new FrmSortingList();

            try
            {
                frnSortingList.ShowDialog();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// データグリッドビュークリア
        /// </summary>
        private void ClearGridView()
        {
            try
            {
                // データグリッドビューのクリア
                DgvSorting.Columns.Clear();
                DgvSorting.Rows.Clear();

                DgvSorting.ColumnCount = 6;
                DgvSorting.RowCount = 1;

                // ヘッダーの設定
                DgvSorting.Columns[DGV_INDEX_DATE].HeaderText = DGV_HEADER_DATE;
                DgvSorting.Columns[DGV_INDEX_ACCONT_DEBIT].HeaderText = DGV_HEADER_ACCOUNT_DEBIT;
                DgvSorting.Columns[DGV_INDEX_MONEY_DEBIT].HeaderText = DGV_HEADER_MONEY_DEBIT;
                DgvSorting.Columns[DGV_INDEX_EMPTY].HeaderText = DGV_HEADER_EMPTY;
                DgvSorting.Columns[DGV_INDEX_ACCONT_CREDIT].HeaderText = DGV_HEADER_ACCOUNT_CREDIT;
                DgvSorting.Columns[DGV_INDEX_MONEY_CREDIT].HeaderText = DGV_HEADER_MONEY_CREDIT;

                // 幅の設定
                DgvSorting.Columns[DGV_INDEX_DATE].Width = DGV_WIDTH_DATE;
                DgvSorting.Columns[DGV_INDEX_ACCONT_DEBIT].Width = DGV_WIDTH_ACCOUNT_DEBIT;
                DgvSorting.Columns[DGV_INDEX_MONEY_DEBIT].Width = DGV_WIDTH_MONEY_DEBIT;
                DgvSorting.Columns[DGV_INDEX_EMPTY].Width = DGV_WIDTH_EMPTY;
                DgvSorting.Columns[DGV_INDEX_ACCONT_CREDIT].Width = DGV_WIDTH_ACCOUNT_CREDIT;
                DgvSorting.Columns[DGV_INDEX_MONEY_CREDIT].Width = DGV_WIDTH_MONEY_CREDIT;

                // 最大文字数
                ((DataGridViewTextBoxColumn)DgvSorting.Columns[DGV_INDEX_DATE]).MaxInputLength = 8;
                ((DataGridViewTextBoxColumn)DgvSorting.Columns[DGV_INDEX_ACCONT_DEBIT]).MaxInputLength = 20;
                ((DataGridViewTextBoxColumn)DgvSorting.Columns[DGV_INDEX_MONEY_DEBIT]).MaxInputLength = 8;
                ((DataGridViewTextBoxColumn)DgvSorting.Columns[DGV_INDEX_ACCONT_CREDIT]).MaxInputLength = 20;
                ((DataGridViewTextBoxColumn)DgvSorting.Columns[DGV_INDEX_MONEY_CREDIT]).MaxInputLength = 8;

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
        /// 戻るボタン押下時の入力データチェック
        /// </summary>
        /// <returns></returns>
        private bool CheckDataDel()
        {
            bool flag = true;

            try
            {
                // データグリッドビューにデータが存在するのか確認
                for (int row = 0; row < DgvSorting.RowCount; row++)
                {
                    if (DgvSorting.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_DEBIT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_DEBIT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvSorting.Rows[row].Cells[DGV_INDEX_ACCONT_CREDIT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvSorting.Rows[row].Cells[DGV_INDEX_MONEY_CREDIT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                }
            }
            catch
            {
                throw;
            }

            return flag;
        }

        #endregion
    }
}
