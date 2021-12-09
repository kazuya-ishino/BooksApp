
namespace BooksApp
{
    partial class FrmInit
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
            this.TxtDepositBalance = new System.Windows.Forms.TextBox();
            this.LblDepositBalance = new System.Windows.Forms.Label();
            this.lblInit = new System.Windows.Forms.Label();
            this.BtnFix = new System.Windows.Forms.Button();
            this.BtnReturn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtDepositBalance
            // 
            this.TxtDepositBalance.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtDepositBalance.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.TxtDepositBalance.Location = new System.Drawing.Point(198, 76);
            this.TxtDepositBalance.MaxLength = 7;
            this.TxtDepositBalance.Name = "TxtDepositBalance";
            this.TxtDepositBalance.Size = new System.Drawing.Size(149, 34);
            this.TxtDepositBalance.TabIndex = 0;
            // 
            // LblDepositBalance
            // 
            this.LblDepositBalance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblDepositBalance.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblDepositBalance.Location = new System.Drawing.Point(57, 76);
            this.LblDepositBalance.Name = "LblDepositBalance";
            this.LblDepositBalance.Size = new System.Drawing.Size(135, 34);
            this.LblDepositBalance.TabIndex = 1;
            this.LblDepositBalance.Text = "預金残高";
            this.LblDepositBalance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInit
            // 
            this.lblInit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInit.Font = new System.Drawing.Font("MS UI Gothic", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblInit.Location = new System.Drawing.Point(262, 9);
            this.lblInit.Name = "lblInit";
            this.lblInit.Size = new System.Drawing.Size(255, 41);
            this.lblInit.TabIndex = 2;
            this.lblInit.Text = "初期設定";
            this.lblInit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnFix
            // 
            this.BtnFix.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BtnFix.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnFix.Location = new System.Drawing.Point(452, 358);
            this.BtnFix.Name = "BtnFix";
            this.BtnFix.Size = new System.Drawing.Size(125, 59);
            this.BtnFix.TabIndex = 5;
            this.BtnFix.Text = "登　録";
            this.BtnFix.UseVisualStyleBackColor = false;
            this.BtnFix.Click += new System.EventHandler(this.BtnFix_Click);
            // 
            // BtnReturn
            // 
            this.BtnReturn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnReturn.Font = new System.Drawing.Font("MS UI Gothic", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnReturn.Location = new System.Drawing.Point(651, 358);
            this.BtnReturn.Name = "BtnReturn";
            this.BtnReturn.Size = new System.Drawing.Size(125, 59);
            this.BtnReturn.TabIndex = 11;
            this.BtnReturn.Text = "戻　る";
            this.BtnReturn.UseVisualStyleBackColor = false;
            this.BtnReturn.Click += new System.EventHandler(this.BtnReturn_Click);
            // 
            // FrmInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnReturn);
            this.Controls.Add(this.BtnFix);
            this.Controls.Add(this.lblInit);
            this.Controls.Add(this.LblDepositBalance);
            this.Controls.Add(this.TxtDepositBalance);
            this.Name = "FrmInit";
            this.Text = "初期設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtDepositBalance;
        private System.Windows.Forms.Label LblDepositBalance;
        private System.Windows.Forms.Label lblInit;
        private System.Windows.Forms.Button BtnFix;
        private System.Windows.Forms.Button BtnReturn;
    }
}