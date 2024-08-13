namespace WareHouse.PO_and_Order
{
    partial class frmBoxCheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBoxCheck));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtQrCode = new System.Windows.Forms.TextBox();
            this.lblCountCheck = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCountOut = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.txtQrCode);
            this.panel1.Controls.Add(this.lblCountCheck);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblCountOut);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1013, 211);
            this.panel1.TabIndex = 0;
            // 
            // txtQrCode
            // 
            this.txtQrCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQrCode.Location = new System.Drawing.Point(3, 60);
            this.txtQrCode.Name = "txtQrCode";
            this.txtQrCode.Size = new System.Drawing.Size(998, 26);
            this.txtQrCode.TabIndex = 4;
            this.txtQrCode.TextChanged += new System.EventHandler(this.txtQrCode_TextChanged);
            // 
            // lblCountCheck
            // 
            this.lblCountCheck.AutoSize = true;
            this.lblCountCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCountCheck.ForeColor = System.Drawing.Color.Black;
            this.lblCountCheck.Location = new System.Drawing.Point(182, 150);
            this.lblCountCheck.Name = "lblCountCheck";
            this.lblCountCheck.Size = new System.Drawing.Size(19, 21);
            this.lblCountCheck.TabIndex = 3;
            this.lblCountCheck.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số lượng đã Check :";
            // 
            // lblCountOut
            // 
            this.lblCountOut.AutoSize = true;
            this.lblCountOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.lblCountOut.ForeColor = System.Drawing.Color.Black;
            this.lblCountOut.Location = new System.Drawing.Point(182, 115);
            this.lblCountOut.Name = "lblCountOut";
            this.lblCountOut.Size = new System.Drawing.Size(19, 21);
            this.lblCountOut.TabIndex = 3;
            this.lblCountOut.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số lượng cần Check :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã vạch :";
            // 
            // frmBoxCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 229);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBoxCheck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SCAN QR CODE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBoxCheck_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCountCheck;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCountOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtQrCode;
    }
}