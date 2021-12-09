
namespace BooksApp
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSorting = new System.Windows.Forms.Button();
            this.BtnCash = new System.Windows.Forms.Button();
            this.lblHome = new System.Windows.Forms.Label();
            this.BtnInit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSorting
            // 
            this.btnSorting.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSorting.Location = new System.Drawing.Point(311, 86);
            this.btnSorting.Name = "btnSorting";
            this.btnSorting.Size = new System.Drawing.Size(187, 76);
            this.btnSorting.TabIndex = 1;
            this.btnSorting.Text = "仕訳帳";
            this.btnSorting.UseVisualStyleBackColor = true;
            this.btnSorting.Click += new System.EventHandler(this.BtnSorting_Click);
            // 
            // BtnCash
            // 
            this.BtnCash.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCash.Location = new System.Drawing.Point(574, 86);
            this.BtnCash.Name = "BtnCash";
            this.BtnCash.Size = new System.Drawing.Size(187, 76);
            this.BtnCash.TabIndex = 3;
            this.BtnCash.Text = "現金出納帳";
            this.BtnCash.UseVisualStyleBackColor = true;
            this.BtnCash.Click += new System.EventHandler(this.BtnCash_Click);
            // 
            // lblHome
            // 
            this.lblHome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHome.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblHome.Location = new System.Drawing.Point(272, 9);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(255, 41);
            this.lblHome.TabIndex = 2;
            this.lblHome.Text = "ホーム";
            this.lblHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnInit
            // 
            this.BtnInit.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnInit.Location = new System.Drawing.Point(51, 86);
            this.BtnInit.Name = "BtnInit";
            this.BtnInit.Size = new System.Drawing.Size(187, 76);
            this.BtnInit.TabIndex = 0;
            this.BtnInit.Text = "初期設定";
            this.BtnInit.UseVisualStyleBackColor = true;
            this.BtnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnInit);
            this.Controls.Add(this.lblHome);
            this.Controls.Add(this.BtnCash);
            this.Controls.Add(this.btnSorting);
            this.Name = "FormMain";
            this.Text = "ホーム画面";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSorting;
        private System.Windows.Forms.Button BtnCash;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Button BtnInit;
    }
}

