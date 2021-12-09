using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace BooksApp
{
    /// <summary>
    /// データベースクラス
    /// </summary>
    public class Db
    {
        #region プロパティ
        /// <summary>
        /// データベースファイル定義
        /// </summary>
        public string ConnectString { get; set; } = "DATA Source = ../../";

        /// <summary>
        /// データベースファイルDB02定義
        /// </summary>
        public string ConnectStringDB02 { get; set; } = "DATA Source = ../../DB02.db";

        /// <summary>
        /// データベースファイルDB03定義
        /// </summary>
        public string ConnectStringDB03 { get; set; } = "DATA Source = ../../DB03.db";

        /// <summary>
        /// データベースファイルパス
        /// </summary>
        public string DBFilePath { get; set; } = @"C:\BooksApp\BooksApp\";

        /// <summary>
        /// データベースバックアップ先
        /// </summary>
        public string DBFileBackupPath { get; set; } = @"C:\BooksApp\BooksApp\BACKUP\";
        #endregion

        #region パブリックメソッド

        /// <summary>
        /// DBファイルが存在するかチェック→存在しない場合作成
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="tableName">テーブル名</param>
        public void CheckDBFile(string dbFilePath, string tableName)
        {
            try
            {
                // テーブルが存在するか
                //if (Exists(connectString, tableName))
                //{
                //    return;
                //}

                // テーブルが存在するか
                if (System.IO.File.Exists(dbFilePath + tableName))
                {
                    return;
                }

                // テーブル名によって作成するDBを変更
                switch (tableName)
                {
                    case Common.DB02:
                        // テーブルを作成
                        SortingCreateTableDB02(ConnectStringDB02);
                        break;

                    case Common.DB03:
                        // テーブルを作成
                        SortingCreateTableDB03(ConnectStringDB03);
                        break;

                    default:
                        break;
                }
            }
            catch
            {
                throw;
            }

            return;
        }

        /// <summary>
        /// SQLの実行(更新、削除)
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="sqls">SQL文</param>
        public void ExecuteNoneQuery(string connectString, string sql)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// SQLの実行(トランザクションつき)
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="sqls">SQL文</param>
        public void ExecuteNoneQueryWithTransaction(string connectString, List<string> sqls)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();
                SQLiteTransaction trans = connection.BeginTransaction();

                try
                {
                    foreach (string sql in sqls)
                    {
                        using (SQLiteCommand cmd = connection.CreateCommand())
                        {
                            cmd.Transaction = trans;

                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                            cmd.Dispose();
                        }
                    }
                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        /// <summary>
        /// DataReaderを使ったデータの取得
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="sql">SQL文</param>
        /// <returns></returns>
        public List<object[]> ExecuteReader(string connectString, string sql)
        {
            List<object[]> result = new List<object[]>();

            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    //SQLの設定
                    cmd.CommandText = sql;

                    //検索
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            object[] data = Enumerable.Range(0, reader.FieldCount).Select(i => reader[i]).ToArray();
                            result.Add(data);
                        }
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// DataTableを使ったデータの取得(DataGridViewを使う場合はこちらを使用)
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="sql"></param>
        /// <returns>データテーブル</returns>
        public DataTable GetData(string connectString, string sql)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;

                    // DataAdapterの生成
                    SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                    // データベースからデータを取得
                    da.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// DataTableの内容をデータベースに保存
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="tableName"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable SetData(string connectString, string tableName, DataTable dt)
        {
            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();
                SQLiteTransaction trans = connection.BeginTransaction();

                try
                {
                    using (SQLiteCommand cmd = connection.CreateCommand())
                    {
                        //書き込み先テーブルの列名と型を取得するためのSQLをCommandに登録
                        cmd.CommandText = "select * from " + tableName;

                        // DataAdapterの生成
                        SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);

                        //Insert、Delete、Update　コマンドの自動生成
                        SQLiteCommandBuilder bulider = new SQLiteCommandBuilder(da);

                        //DataTableの内容をデータベースに書き込む
                        da.Update(dt);

                        //コミット
                        trans.Commit();
                    }
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
            return dt;
        }

        /// <summary>
        /// スカラーによる単一データの取得
        /// </summary>
        /// <param name="connectString"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object ExecuteScalar(string connectString, string sql)
        {
            object result = null;

            using (SQLiteConnection connection = new SQLiteConnection(connectString))
            {
                connection.Open();

                using (SQLiteCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    result = cmd.ExecuteScalar();
                }
            }

            return result;
        }

        /// <summary>
        /// テーブル存在チェック
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="tableName">テーブル名</param>
        public bool Exists(string connectString, string tableName)
        {
            object val = ExecuteScalar(connectString,
                "select count(*) from sqlite_master where type in ('table','view') and name='" + tableName + "'");
            return (int.Parse(val.ToString()) == 0) ? false : true;
        }

        /// <summary>
        /// テーブル一覧取得
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        public string[] GetTableList(string connectString)
        {
            var dt = GetData(connectString, "select tbl_name from sqlite_master where type in ('table','view') ");
            return dt.AsEnumerable().Select(i => i[0].ToString()).ToArray();
        }

        /// <summary>
        /// カラム名(列名)一覧取得
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="tableName">テーブル名</param>
        public string[] GetColumnNames(string connectString, string tableName)
        {
            var dt = GetData(connectString, "select * from " + tableName + " where 1=2");
            return dt.Columns.Cast<DataColumn>().Select(i => i.ColumnName).ToArray();
        }

        /// <summary>
        /// テーブルの作成
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="tableName">テーブル名</param>
        /// <param name="fieldList">型</param>
        /// <param name="primaryKeyList">主キー</param>
        public void CreateTable(string connectString, string tableName, string fieldList, string primaryKeyList)
        {
            var primary = (primaryKeyList == "") ? "" : (",primary key (" + primaryKeyList + ")");
            var sql = string.Format("create table {0}({1} {2})", tableName, fieldList, primary);

            ExecuteNoneQuery(connectString, sql);
        }

        /// <summary>
        /// テーブルの作成DB01(初期設定)
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        public void SortingCreateTableDB01(string connectString)
        {

            try
            {
                string sql = "create table DB01(DEPOSITBALANCE INTEGER)";

                ExecuteNoneQuery(connectString, sql);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// テーブルの作成DB02(仕訳)
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        public void SortingCreateTableDB02(string connectString)
        {
            //SQLiteConnection con = new SQLiteConnection("Data Source=mydb.sqlite;Version=3;");
            //con.Open();

            try
            {
                //SQLiteConnection.CreateFile("DB02.sqlite");

                string sql = "create table DB02(SORTNUMBER INTEGER, DATE TEXT, DEBITACCOUNT TEXT, DEBITMONEY INTEGER, CREDITACCOUNT TEXT, CREDITMONEY INTEGER)";

                ExecuteNoneQuery(connectString, sql);

                //con.Close();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// テーブルの作成DB03(現金出納帳)
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        public void SortingCreateTableDB03(string connectString)
        {

            try
            {
                string sql = "create table DB03(DATE TEXT, ACCOUNT TEXT, DESCRIPTION TEXT, PAYMENT INTEGER, CASH INTEGER, OTHER INTEGER, BALANCE INTEGER)";

                ExecuteNoneQuery(connectString, sql);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// テーブルの削除
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        /// <param name="tableName">テーブル名</param>
        public void DropTable(string connectString, string tableName)
        {
            ExecuteNoneQuery(connectString, "drop table  " + tableName);
        }

        /// <summary>
        /// 肥大化したデータベースをスリム化
        /// </summary>
        /// <param name="connectString">データベースファイル定義</param>
        public void Vacuum(string connectString)
        {
            ExecuteNoneQuery(connectString, "VACUUM");
        }

        #endregion
    }
}
