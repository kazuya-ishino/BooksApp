
namespace BooksApp
{
    partial class FrmSortingList
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
            this.BtnReturn = new System.Windows.Forms.Button();
            this.lblCredit = new System.Windows.Forms.Label();
            this.lblDebit = new System.Windows.Forms.Label();
            this.DgvSorting = new System.Windows.Forms.DataGridView();
            this.DGV_DATE_DEBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_ACCONT_DEBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_MONEY_DEBIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.empty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_ACCONT_CREDIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV_MONEY_CREDIT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSorting = new System.Windows.Forms.Label();
            this.BtnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSorting)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnReturn
            // 
            this.BtnReturn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnReturn.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnReturn.Location = new System.Drawing.Point(657, 381);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(125, 59);
            this.BtnReturn.TabIndex = 10;
            this.BtnReturn.Text = "戻　る";
            this.BtnReturn.UseVisualStyleBackColor = false;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // lblCredit
            // 
            this.lblCredit.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCredit.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCredit.Location = new System.Drawing.Point(480, 92);
            this.lblCredit.Name = "lblCredit";
            this.lblCredit.Size = new System.Drawing.Size(302, 41);
            this.lblCredit.TabIndex = 9;
            this.lblCredit.Text = "貸方";
            this.lblCredit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDebit
            // 
            this.lblDebit.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblDebit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDebit.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblDebit.Location = new System.Drawing.Point(161, 92);
            this.lblDebit.Name = "lblDebit";
            this.lblDebit.Size = new System.Drawing.Size(301, 41);
            this.lblDebit.TabIndex = 8;
            this.lblDebit.Text = "借方";
            this.lblDebit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvSorting
            // 
            this.DgvSorting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvSorting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DGV_DATE_DEBIT,
            this.DGV_ACCONT_DEBIT,
            this.DGV_MONEY_DEBIT,
            this.empty,
            this.DGV_ACCONT_CREDIT,
            this.DGV_MONEY_CREDIT});
            this.DgvSorting.Location = new System.Drawing.Point(19, 136);
            this.DgvSorting.MultiSelect = false;
            this.DgvSorting.Name = "DgvSorting";
            this.DgvSorting.ReadOnly = true;
            this.DgvSorting.RowTemplate.Height = 21;
            this.DgvSorting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSorting.Size = new System.Drawing.Size(763, 229);
            this.DgvSorting.TabIndex = 7;
            // 
            // DGV_DATE_DEBIT
            // 
            this.DGV_DATE_DEBIT.HeaderText = "日付";
            this.DGV_DATE_DEBIT.MaxInputLength = 8;
            this.DGV_DATE_DEBIT.Name = "DGV_DATE_DEBIT";
            this.DGV_DATE_DEBIT.ReadOnly = true;
            this.DGV_DATE_DEBIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGV_DATE_DEBIT.ToolTipText = "YYYYMMDD";
            // 
            // DGV_ACCONT_DEBIT
            // 
            this.DGV_ACCONT_DEBIT.HeaderText = "勘定科目";
            this.DGV_ACCONT_DEBIT.MaxInputLength = 20;
            this.DGV_ACCONT_DEBIT.Name = "DGV_ACCONT_DEBIT";
            this.DGV_ACCONT_DEBIT.ReadOnly = true;
            this.DGV_ACCONT_DEBIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGV_ACCONT_DEBIT.Width = 200;
            // 
            // DGV_MONEY_DEBIT
            // 
            this.DGV_MONEY_DEBIT.HeaderText = "金額";
            this.DGV_MONEY_DEBIT.MaxInputLength = 8;
            this.DGV_MONEY_DEBIT.Name = "DGV_MONEY_DEBIT";
            this.DGV_MONEY_DEBIT.ReadOnly = true;
            this.DGV_MONEY_DEBIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // empty
            // 
            this.empty.HeaderText = "";
            this.empty.MaxInputLength = 0;
            this.empty.Name = "empty";
            this.empty.ReadOnly = true;
            this.empty.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.empty.Width = 20;
            // 
            // DGV_ACCONT_CREDIT
            // 
            this.DGV_ACCONT_CREDIT.HeaderText = "勘定科目";
            this.DGV_ACCONT_CREDIT.MaxInputLength = 20;
            this.DGV_ACCONT_CREDIT.Name = "DGV_ACCONT_CREDIT";
            this.DGV_ACCONT_CREDIT.ReadOnly = true;
            this.DGV_ACCONT_CREDIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGV_ACCONT_CREDIT.Width = 200;
            // 
            // DGV_MONEY_CREDIT
            // 
            this.DGV_MONEY_CREDIT.HeaderText = "金額";
            this.DGV_MONEY_CREDIT.MaxInputLength = 8;
            this.DGV_MONEY_CREDIT.Name = "DGV_MONEY_CREDIT";
            this.DGV_MONEY_CREDIT.ReadOnly = true;
            this.DGV_MONEY_CREDIT.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DGV_MONEY_CREDIT.Width = 82;
            // 
            // lblSorting
            // 
            this.lblSorting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSorting.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblSorting.Location = new System.Drawing.Point(286, 19);
            this.lblSorting.Name = "lblSorting";
            this.lblSorting.Size = new System.Drawing.Size(255, 41);
            this.lblSorting.TabIndex = 6;
            this.lblSorting.Text = "仕訳帳一覧";
            this.lblSorting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnPrint
            // 
            this.BtnPrint.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BtnPrint.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnPrint.Location = new System.Drawing.Point(470, 381);
            this.BtnPrint.Name = "BtnPrint";
            this.BtnPrint.Size = new System.Drawing.Size(125, 59);
            this.BtnPrint.TabIndex = 12;
            this.BtnPrint.Text = "印刷";
            this.BtnPrint.UseVisualStyleBackColor = false;
            this.BtnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // FrmSortingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnPrint);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.lblCredit);
            this.Controls.Add(this.lblDebit);
            this.Controls.Add(this.DgvSorting);
            this.Controls.Add(this.lblSorting);
            this.Name = "FrmSortingList";
            this.Text = "仕訳帳一覧";
            this.Load += new System.EventHandler(this.FrmSortingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvSorting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnReturn;
        private System.Windows.Forms.Label lblCredit;
        private System.Windows.Forms.Label lblDebit;
        private System.Windows.Forms.DataGridView DgvSorting;
        private System.Windows.Forms.Label lblSorting;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_DATE_DEBIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_ACCONT_DEBIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_MONEY_DEBIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn empty;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_ACCONT_CREDIT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DGV_MONEY_CREDIT;
        private System.Windows.Forms.Button BtnPrint;
    }
}