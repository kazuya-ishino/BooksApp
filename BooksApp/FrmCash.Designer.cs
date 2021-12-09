
namespace BooksApp
{
    partial class FrmCash
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCash = new System.Windows.Forms.Label();
            this.DgvCash = new System.Windows.Forms.DataGridView();
            this.BtnReturn = new System.Windows.Forms.Button();
            this.BtnFix = new System.Windows.Forms.Button();
            this.BtnCashList = new System.Windows.Forms.Button();
            this.DGV_DATE_DEBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_ACCONT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_PAYMENT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_CASH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_OTHER = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_BALANCE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCash)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCash
            // 
            this.lblCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCash.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCash.Location = new System.Drawing.Point(266, 9);
            this.lblCash.Name = "lblCash";
            this.lblCash.Size = new System.Drawing.Size(255, 41);
            this.lblCash.TabIndex = 1;
            this.lblCash.Text = "現金出納帳";
            this.lblCash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvCash
            // 
            this.DgvCash.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCash.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_DATE_DEBIT,
            this.DGV_ACCONT,
            this.DGV_DESCRIPTION,
            this.DGV_PAYMENT,
            this.DGV_CASH,
            this.DGV_OTHER,
            this.DGV_BALANCE});
            this.DgvCash.Location = new System.Drawing.Point(25, 119);
            this.DgvCash.Name = "DgvCash";
            this.DgvCash.RowTemplate.Height = 21;
            this.DgvCash.Size = new System.Drawing.Size(763, 223);
            this.DgvCash.TabIndex = 2;
            // 
            // BtnReturn
            // 
            this.BtnReturn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnReturn.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnReturn.Location = new System.Drawing.Point(648, 367);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(125, 59);
            this.BtnReturn.TabIndex = 7;
            this.BtnReturn.Text = "戻　る";
            this.BtnReturn.UseVisualStyleBackColor = false;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // BtnFix
            // 
            this.BtnFix.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnFix.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnFix.Location = new System.Drawing.Point(440, 367);
            this.BtnFix.Name = "BtnFix";
            this.BtnFix.Size = new System.Drawing.Size(125, 59);
            this.BtnFix.TabIndex = 6;
            this.BtnFix.Text = "登　録";
            this.BtnFix.UseVisualStyleBackColor = false;
            this.BtnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // BtnCashList
            // 
            this.BtnCashList.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.BtnCashList.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCashList.Location = new System.Drawing.Point(219, 367);
            this.BtnCashList.Name = "BtnCashList";
            this.BtnCashList.Size = new System.Drawing.Size(125, 59);
            this.BtnCashList.TabIndex = 8;
            this.BtnCashList.Text = "現金出納帳一覧";
            this.BtnCashList.UseVisualStyleBackColor = false;
            this.BtnCashList.Click += new System.EventHandler(this.BtnCashList_Click);
            // 
            // DGV_DATE_DEBIT
            // 
            this.DGV_DATE_DEBIT.HeaderText = "日付";
            this.DGV_DATE_DEBIT.MaxInputLength = 8;
            this.DGV_DATE_DEBIT.Name = "DGV_DATE_DEBIT";
            this.DGV_DATE_DEBIT.ToolTipText = "YYYYMMDD";
            // 
            // DGV_ACCONT
            // 
            this.DGV_ACCONT.HeaderText = "勘定科目";
            this.DGV_ACCONT.MaxInputLength = 20;
            this.DGV_ACCONT.Name = "DGV_ACCONT";
            this.DGV_ACCONT.Width = 130;
            // 
            // DGV_DESCRIPTION
            // 
            this.DGV_DESCRIPTION.HeaderText = "摘要";
            this.DGV_DESCRIPTION.MaxInputLength = 30;
            this.DGV_DESCRIPTION.Name = "DGV_DESCRIPTION";
            this.DGV_DESCRIPTION.Width = 150;
            // 
            // DGV_PAYMENT
            // 
            this.DGV_PAYMENT.HeaderText = "入金";
            this.DGV_PAYMENT.MaxInputLength = 7;
            this.DGV_PAYMENT.Name = "DGV_PAYMENT";
            this.DGV_PAYMENT.Width = 80;
            // 
            // DGV_CASH
            // 
            this.DGV_CASH.HeaderText = "出金　　現金仕入";
            this.DGV_CASH.MaxInputLength = 7;
            this.DGV_CASH.Name = "DGV_CASH";
            this.DGV_CASH.Width = 80;
            // 
            // DGV_OTHER
            // 
            this.DGV_OTHER.HeaderText = "出金　　　その他";
            this.DGV_OTHER.MaxInputLength = 7;
            this.DGV_OTHER.Name = "DGV_OTHER";
            this.DGV_OTHER.Width = 80;
            // 
            // DGV_BALANCE
            // 
            this.DGV_BALANCE.HeaderText = "残高";
            this.DGV_BALANCE.MaxInputLength = 7;
            this.DGV_BALANCE.Name = "DGV_BALANCE";
            this.DGV_BALANCE.ReadOnly = true;
            // 
            // FrmCash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCashList);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.BtnFix);
            this.Controls.Add(this.DgvCash);
            this.Controls.Add(this.lblCash);
            this.Name = "FrmCash";
            this.Text = "現金出納帳";
            this.Load += new System.EventHandler(this.FrmCash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCash)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCash;
        private System.Windows.Forms.DataGridView DgvCash;
        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.Button BtnFix;
        private System.Windows.Forms.Button BtnCashList;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_DATE_DEBIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_ACCONT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_PAYMENT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_CASH;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_OTHER;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_BALANCE;
    }
}