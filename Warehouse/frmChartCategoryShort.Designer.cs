namespace WareHouse
{
    partial class frmChartCategoryShort
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChartCategoryShort));
			DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
			DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
			DevExpress.XtraCharts.LineSeriesView lineSeriesView1 = new DevExpress.XtraCharts.LineSeriesView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnLong = new DevExpress.XtraEditors.SimpleButton();
			this.btnViewMonth = new DevExpress.XtraEditors.SimpleButton();
			this.dtpkDate = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cbMachineCode = new System.Windows.Forms.ComboBox();
			this.flpMain = new System.Windows.Forms.FlowLayoutPanel();
			this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
			this.panel1.SuspendLayout();
			this.flpMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.btnLong);
			this.panel1.Controls.Add(this.btnViewMonth);
			this.panel1.Controls.Add(this.dtpkDate);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.cbMachineCode);
			this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.panel1.Location = new System.Drawing.Point(7, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1168, 40);
			this.panel1.TabIndex = 0;
			// 
			// btnLong
			// 
			this.btnLong.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnLong.Appearance.Options.UseFont = true;
			this.btnLong.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLong.ImageOptions.SvgImage")));
			this.btnLong.Location = new System.Drawing.Point(965, 2);
			this.btnLong.Name = "btnLong";
			this.btnLong.Size = new System.Drawing.Size(196, 35);
			this.btnLong.TabIndex = 3;
			this.btnLong.Text = "Biểu đồ HM Định kỳ";
			this.btnLong.Click += new System.EventHandler(this.btnLong_Click);
			// 
			// btnViewMonth
			// 
			this.btnViewMonth.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnViewMonth.Appearance.Options.UseFont = true;
			this.btnViewMonth.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnViewMonth.ImageOptions.SvgImage")));
			this.btnViewMonth.Location = new System.Drawing.Point(748, 2);
			this.btnViewMonth.Name = "btnViewMonth";
			this.btnViewMonth.Size = new System.Drawing.Size(196, 35);
			this.btnViewMonth.TabIndex = 3;
			this.btnViewMonth.Text = "Biểu đồ HM Hàng ngày";
			this.btnViewMonth.Click += new System.EventHandler(this.btnViewMonth_Click);
			// 
			// dtpkDate
			// 
			this.dtpkDate.CustomFormat = "MM/yyyy";
			this.dtpkDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpkDate.Location = new System.Drawing.Point(484, 6);
			this.dtpkDate.Name = "dtpkDate";
			this.dtpkDate.Size = new System.Drawing.Size(200, 26);
			this.dtpkDate.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(382, 11);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "Tháng năm :";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(81, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mã thiết bị :";
			// 
			// cbMachineCode
			// 
			this.cbMachineCode.FormattingEnabled = true;
			this.cbMachineCode.Location = new System.Drawing.Point(105, 6);
			this.cbMachineCode.Name = "cbMachineCode";
			this.cbMachineCode.Size = new System.Drawing.Size(168, 27);
			this.cbMachineCode.TabIndex = 0;
			// 
			// flpMain
			// 
			this.flpMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.flpMain.AutoScroll = true;
			this.flpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			this.flpMain.Controls.Add(this.chartControl1);
			this.flpMain.Location = new System.Drawing.Point(7, 46);
			this.flpMain.Name = "flpMain";
			this.flpMain.Size = new System.Drawing.Size(1168, 581);
			this.flpMain.TabIndex = 1;
			// 
			// chartControl1
			// 
			xyDiagram1.AxisX.Title.MaxLineCount = 10;
			xyDiagram1.AxisX.Title.Text = "Ngày";
			xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
			xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
			xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
			this.chartControl1.Diagram = xyDiagram1;
			this.chartControl1.Legend.Name = "Default Legend";
			this.chartControl1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
			this.chartControl1.Location = new System.Drawing.Point(10, 10);
			this.chartControl1.Margin = new System.Windows.Forms.Padding(10);
			this.chartControl1.Name = "chartControl1";
			series1.Name = "Series 1";
			series1.View = lineSeriesView1;
			this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
			this.chartControl1.Size = new System.Drawing.Size(606, 164);
			this.chartControl1.TabIndex = 0;
			// 
			// frmChartCategoryShort
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1179, 639);
			this.Controls.Add(this.flpMain);
			this.Controls.Add(this.panel1);
			this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("frmChartCategoryShort.IconOptions.Icon")));
			this.Name = "frmChartCategoryShort";
			this.Text = "BIỂU ĐỒ BẢO DƯỠNG HÀNG NGÀY";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.flpMain.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(lineSeriesView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnViewMonth;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMachineCode;
        private System.Windows.Forms.FlowLayoutPanel flpMain;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.SimpleButton btnLong;
    }
}