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
    /// 現金出納帳クラス
    /// </summary>
    public partial class FrmCash : Form
    {

        #region プロパティ

        private int Balance { get; set; } = 0;

        #endregion


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

        /// <summary>
        /// 日付
        /// </summary>
        private const string DGV_HEADER_DATE = "日付";

        /// <summary>
        /// 勘定科目
        /// </summary>
        private const string DGV_HEADER_ACCONTT = "勘定科目";

        /// <summary>
        /// 摘要
        /// /summary>
        private const string DGV_HEADER_DESCRIPTION = "摘要";

        /// <summary>
        /// 入金
        /// </summary>
        private const string DGV_HEADER_PAYMENT = "入金";

        /// <summary>
        /// 出金(現金仕入)
        /// </summary>
        private const string DGV_HEADER_ACCONT_CASH = "出金\r\n現金仕入";

        /// <summary>
        /// 出金(その他)
        /// </summary>
        private const string DGV_HEADER_MONEY_OTHER = "出金\r\nその他";

        /// <summary>
        /// 残高
        /// </summary>
        private const string DGV_HEADER_MONEY_BALANCE = "残高";

        /// <summary>
        /// 日付け幅番号
        /// </summary>
        private const int DGV_WIDTH_DATE = 100;

        /// <summary>
        /// 勘定科目幅番号
        /// </summary>
        private const int DGV_WIDTH_ACCONTT = 130;

        /// <summary>
        /// 摘要幅番号
        /// </summary>
        private const int DGV_WIDTH_DESCRIPTION = 150;

        /// <summary>
        /// 入金幅番号
        /// </summary>
        private const int DGV_WIDTH_PAYMENT = 80;

        /// <summary>
        /// 出金(現金仕入)幅番号
        /// </summary>
        private const int DGV_WIDTH_ACCONT_CASH = 80;

        /// <summary>
        /// 出金(その他)幅番号
        /// </summary>
        private const int DGV_WIDTH_MONEY_OTHER = 80;

        /// <summary>
        /// 残高幅番号
        /// </summary>
        private const int DGV_WIDTH_MONEY_BALANCE = 100;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrmCash()
        {
            Db db = new Db();

            try
            {
                InitializeComponent();

                // データベースファイルが存在するかチェック
                db.CheckDBFile(db.DBFilePath, Common.DB03);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region イベント
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
            string account = string.Empty;
            string description = string.Empty;
            string payment = string.Empty;
            string cash = string.Empty;
            string other = string.Empty;
            string balance = string.Empty;

            try
            {
                // 日付入力チェック
                for (int row = 0; row < this.DgvCash.RowCount; row++)
                {
                    if (this.DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        if (!common.CheckDate(this.DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value.ToString()))
                        {
                            // 日付を正しく入力してください
                            MessageBox.Show(Common.NODATEMSG);
                            return;
                        }
                    }
                }

                // データベースに値を登録
                for (int row = 0; row < this.DgvCash.RowCount; row++)
                {
                    if (this.DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        date = (this.DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value == null) ? string.Empty : this.DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value.ToString();
                        account = (this.DgvCash.Rows[row].Cells[DGV_INDEX_ACCONTT].Value == null) ? string.Empty : this.DgvCash.Rows[row].Cells[DGV_INDEX_ACCONTT].Value.ToString();
                        description = (this.DgvCash.Rows[row].Cells[DGV_INDEX_DESCRIPTION].Value == null) ? string.Empty : this.DgvCash.Rows[row].Cells[DGV_INDEX_DESCRIPTION].Value.ToString();
                        payment = (this.DgvCash.Rows[row].Cells[DGV_INDEX_PAYMENT].Value == null) ? "0" : this.DgvCash.Rows[row].Cells[DGV_INDEX_PAYMENT].Value.ToString();
                        cash = (this.DgvCash.Rows[row].Cells[DGV_INDEX_CASH].Value == null) ? "0" : this.DgvCash.Rows[row].Cells[DGV_INDEX_CASH].Value.ToString();
                        other = (this.DgvCash.Rows[row].Cells[DGV_INDEX_OTHER].Value == null) ? "0" : this.DgvCash.Rows[row].Cells[DGV_INDEX_OTHER].Value.ToString();
                        //balance = (this.DgvCash.Rows[row].Cells[DGV_INDEX_BALANCE].Value == null) ? "0" : this.DgvCash.Rows[row].Cells[DGV_INDEX_BALANCE].Value.ToString();
                        balance = (this.Balance + Convert.ToInt32(payment) - Convert.ToInt32(cash) - Convert.ToInt32(other)).ToString();

                        // 残高の値を保持
                        this.Balance = Convert.ToInt32(balance);

                        // INSERT文を作成
                        //sqls.Add($"insert into DB03 values('{date}', '{account}', '{description}', '{payment}', {cash},  '{other}', '{balance}')");
                        sqls.Add($"insert into DB03 values('{date}', '{account}', '{description}', {payment}, {cash},  {other}, {balance})");
                    }
                    else
                    {
                        break;
                    }
                }

                // SQL実行
                db.ExecuteNoneQueryWithTransaction(db.ConnectStringDB03, sqls);

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
        /// 現金出納帳一覧
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCashList_Click(object sender, EventArgs e)
        {
            FrmCashList frmCashList = new FrmCashList();

            try
            {
                frmCashList.ShowDialog();
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
        private void FrmCash_Load(object sender, EventArgs e)
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
        #endregion

        #region プライベートメソッド
        /// <summary>
        /// データグリッドビュークリア
        /// </summary>
        private void ClearGridView()
        {
            Db db = new Db();
            Common common = new Common();
            DataTable dt = new DataTable();
            string sql = "select BALANCE from db03";

            try
            {
                // データグリッドビューのクリア
                DgvCash.Columns.Clear();
                DgvCash.Rows.Clear();

                DgvCash.ColumnCount = 7;
                DgvCash.RowCount = 1;

                // ヘッダーの設定
                DgvCash.Columns[DGV_INDEX_DATE].HeaderText = DGV_HEADER_DATE;
                DgvCash.Columns[DGV_INDEX_ACCONTT].HeaderText = DGV_HEADER_ACCONTT;
                DgvCash.Columns[DGV_INDEX_DESCRIPTION].HeaderText = DGV_HEADER_DESCRIPTION;
                DgvCash.Columns[DGV_INDEX_PAYMENT].HeaderText = DGV_HEADER_PAYMENT;
                DgvCash.Columns[DGV_INDEX_CASH].HeaderText = DGV_HEADER_ACCONT_CASH;
                DgvCash.Columns[DGV_INDEX_OTHER].HeaderText = DGV_HEADER_MONEY_OTHER;
                DgvCash.Columns[DGV_INDEX_BALANCE].HeaderText = DGV_HEADER_MONEY_BALANCE;

                // 幅の設定
                DgvCash.Columns[DGV_INDEX_DATE].Width = DGV_WIDTH_DATE;
                DgvCash.Columns[DGV_INDEX_ACCONTT].Width = DGV_WIDTH_ACCONTT;
                DgvCash.Columns[DGV_INDEX_DESCRIPTION].Width = DGV_WIDTH_DESCRIPTION;
                DgvCash.Columns[DGV_INDEX_PAYMENT].Width = DGV_WIDTH_PAYMENT;
                DgvCash.Columns[DGV_INDEX_CASH].Width = DGV_WIDTH_ACCONT_CASH;
                DgvCash.Columns[DGV_INDEX_OTHER].Width = DGV_WIDTH_MONEY_OTHER;
                DgvCash.Columns[DGV_INDEX_BALANCE].Width = DGV_WIDTH_MONEY_BALANCE;

                // 最大文字数
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_DATE]).MaxInputLength = 8;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_ACCONTT]).MaxInputLength = 20;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_DESCRIPTION]).MaxInputLength = 30;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_PAYMENT]).MaxInputLength = 7;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_CASH]).MaxInputLength = 7;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_OTHER]).MaxInputLength = 7;
                ((DataGridViewTextBoxColumn)DgvCash.Columns[DGV_INDEX_BALANCE]).MaxInputLength = 7;

                // アライメント
                DgvCash.Columns[DGV_INDEX_DATE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                DgvCash.Columns[DGV_INDEX_PAYMENT].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_CASH].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_OTHER].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DgvCash.Columns[DGV_INDEX_BALANCE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dt = db.GetData(db.ConnectStringDB03, sql);
                this.Balance = int.Parse(dt.Rows[dt.Rows.Count - 1]["BALANCE"].ToString());
                this.DgvCash.Rows[0].Cells[DGV_INDEX_BALANCE].Value = common.CommaSeparated(dt.Rows[dt.Rows.Count - 1]["BALANCE"].ToString().Trim());
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
                for (int row = 0; row < DgvCash.RowCount; row++)
                {
                    if (DgvCash.Rows[row].Cells[DGV_INDEX_DATE].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvCash.Rows[row].Cells[DGV_INDEX_ACCONTT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvCash.Rows[row].Cells[DGV_INDEX_DESCRIPTION].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvCash.Rows[row].Cells[DGV_INDEX_PAYMENT].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvCash.Rows[row].Cells[DGV_INDEX_CASH].Value != null)
                    {
                        flag = false;
                        return flag;
                    }
                    else if (DgvCash.Rows[row].Cells[DGV_INDEX_OTHER].Value != null)
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
