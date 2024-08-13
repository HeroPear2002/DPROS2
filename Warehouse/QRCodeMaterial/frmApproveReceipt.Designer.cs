namespace WareHouse.QRCodeMaterial
{
    partial class frmApproveReceipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmApproveReceipt));
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnConfirm);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 164);
            this.panel1.TabIndex = 0;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarCode.Location = new System.Drawing.Point(3, 47);
            this.txtBarCode.Multiline = true;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(569, 51);
            this.txtBarCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "MÃ VẠCH :";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnConfirm.Location = new System.Drawing.Point(121, 116);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(125, 38);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.btnClose.Location = new System.Drawing.Point(281, 116);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmApproveReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 172);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmApproveReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BẮN MÃ VẠCH PHIẾU NHẬN NHỰA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmApproveReceipt_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBarCode;
    }
}