namespace WareHouse.DataMachine
{
    partial class frmDataChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataChart));
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesHistory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnViewMonth = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.cbMachineCode = new System.Windows.Forms.ComboBox();
            this.cbMoldCode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 101;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Tên hạng mục";
            this.gridColumn2.FieldName = "Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 173;
            // 
            // colSalesHistory
            // 
            this.colSalesHistory.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSalesHistory.AppearanceCell.Options.UseFont = true;
            this.colSalesHistory.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colSalesHistory.AppearanceHeader.Options.UseFont = true;
            this.colSalesHistory.AppearanceHeader.Options.UseTextOptions = true;
            this.colSalesHistory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSalesHistory.Caption = "Biểu đồ";
            this.colSalesHistory.Name = "colSalesHistory";
            this.colSalesHistory.Visible = true;
            this.colSalesHistory.VisibleIndex = 3;
            this.colSalesHistory.Width = 986;
            // 
            // flpMain
            // 
            this.flpMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpMain.AutoSize = true;
            this.flpMain.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.flpMain.Location = new System.Drawing.Point(12, 45);
            this.flpMain.Name = "flpMain";
            this.flpMain.Size = new System.Drawing.Size(1281, 45);
            this.flpMain.TabIndex = 0;
            this.flpMain.Click += new System.EventHandler(this.btnView_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnViewMonth);
            this.panel1.Controls.Add(this.btnView);
            this.panel1.Controls.Add(this.dtpkDate);
            this.panel1.Controls.Add(this.cbMachineCode);
            this.panel1.Controls.Add(this.cbMoldCode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1281, 36);
            this.panel1.TabIndex = 1;
            // 
            // btnViewMonth
            // 
            this.btnViewMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewMonth.ImageOptions.Image")));
            this.btnViewMonth.Location = new System.Drawing.Point(1111, 6);
            this.btnViewMonth.Name = "btnViewMonth";
            this.btnViewMonth.Size = new System.Drawing.Size(114, 23);
            this.btnViewMonth.TabIndex = 3;
            this.btnViewMonth.Text = "Xem trong tháng";
            this.btnViewMonth.Click += new System.EventHandler(this.btnViewMonth_Click);
            // 
            // btnView
            // 
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.Location = new System.Drawing.Point(943, 6);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(112, 23);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "Xem trong ngày";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpkDate
            // 
            this.dtpkDate.CustomFormat = "dd/MM/yyyy ";
            this.dtpkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkDate.Location = new System.Drawing.Point(670, 3);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(193, 26);
            this.dtpkDate.TabIndex = 2;
            // 
            // cbMachineCode
            // 
            this.cbMachineCode.FormattingEnabled = true;
            this.cbMachineCode.Location = new System.Drawing.Point(392, 4);
            this.cbMachineCode.Name = "cbMachineCode";
            this.cbMachineCode.Size = new System.Drawing.Size(137, 27);
            this.cbMachineCode.TabIndex = 1;
            // 
            // cbMoldCode
            // 
            this.cbMoldCode.FormattingEnabled = true;
            this.cbMoldCode.Location = new System.Drawing.Point(97, 4);
            this.cbMoldCode.Name = "cbMoldCode";
            this.cbMoldCode.Size = new System.Drawing.Size(217, 27);
            this.cbMoldCode.TabIndex = 1;
            this.cbMoldCode.SelectedIndexChanged += new System.EventHandler(this.cbMoldCode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày tháng năm :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(320, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã máy :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khuôn :";
            // 
            // frmDataChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1305, 651);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDataChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biểu Đồ";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesHistory;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.ComboBox cbMachineCode;
        private System.Windows.Forms.ComboBox cbMoldCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnViewMonth;
    }
}