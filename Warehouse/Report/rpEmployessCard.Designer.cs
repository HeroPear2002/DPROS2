namespace WareHouse.Report
{
    partial class rpEmployessCard
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rpEmployessCard));
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.panel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.txtBarCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.txtEmployessCode = new DevExpress.XtraReports.UI.XRLabel();
            this.txtPositionName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtEmployessName = new DevExpress.XtraReports.UI.XRLabel();
            this.pctAvata = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.panel1});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 545.3126F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.MultiColumn.ColumnSpacing = 25F;
            this.Detail.MultiColumn.ColumnWidth = 902F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
            this.Detail.Name = "Detail";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.panel1.CanGrow = false;
            this.panel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtBarCode,
            this.txtEmployessCode,
            this.txtPositionName,
            this.txtEmployessName,
            this.pctAvata,
            this.xrLabel1,
            this.xrLabel5,
            this.xrPictureBox1});
            this.panel1.Dpi = 254F;
            this.panel1.LocationFloat = new DevExpress.Utils.PointFloat(10.58313F, 23.33347F);
            this.panel1.Name = "panel1";
            this.panel1.SizeF = new System.Drawing.SizeF(891.4169F, 510.3124F);
            this.panel1.StylePriority.UseBackColor = false;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtBarCode.AutoModule = true;
            this.txtBarCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtBarCode.Dpi = 254F;
            this.txtBarCode.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.LocationFloat = new DevExpress.Utils.PointFloat(354.271F, 404.1633F);
            this.txtBarCode.Module = 1F;
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(38, 38, 5, 5, 254F);
            this.txtBarCode.ShowText = false;
            this.txtBarCode.SizeF = new System.Drawing.SizeF(500.1039F, 79.5867F);
            this.txtBarCode.StylePriority.UseBorders = false;
            this.txtBarCode.StylePriority.UseFont = false;
            this.txtBarCode.StylePriority.UsePadding = false;
            this.txtBarCode.StylePriority.UseTextAlignment = false;
            this.txtBarCode.Symbology = code128Generator1;
            this.txtBarCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtEmployessCode
            // 
            this.txtEmployessCode.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployessCode.BorderColor = System.Drawing.Color.Black;
            this.txtEmployessCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtEmployessCode.Dpi = 254F;
            this.txtEmployessCode.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.txtEmployessCode.ForeColor = System.Drawing.Color.Black;
            this.txtEmployessCode.LocationFloat = new DevExpress.Utils.PointFloat(314.58F, 335F);
            this.txtEmployessCode.Multiline = true;
            this.txtEmployessCode.Name = "txtEmployessCode";
            this.txtEmployessCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtEmployessCode.SizeF = new System.Drawing.SizeF(576.833F, 55.88022F);
            this.txtEmployessCode.StylePriority.UseBackColor = false;
            this.txtEmployessCode.StylePriority.UseBorderColor = false;
            this.txtEmployessCode.StylePriority.UseBorders = false;
            this.txtEmployessCode.StylePriority.UseFont = false;
            this.txtEmployessCode.StylePriority.UseForeColor = false;
            this.txtEmployessCode.StylePriority.UseTextAlignment = false;
            this.txtEmployessCode.Text = "M0008";
            this.txtEmployessCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtPositionName
            // 
            this.txtPositionName.BackColor = System.Drawing.Color.Transparent;
            this.txtPositionName.BorderColor = System.Drawing.Color.Black;
            this.txtPositionName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtPositionName.Dpi = 254F;
            this.txtPositionName.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPositionName.ForeColor = System.Drawing.Color.Black;
            this.txtPositionName.LocationFloat = new DevExpress.Utils.PointFloat(314.5835F, 276.6719F);
            this.txtPositionName.Multiline = true;
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtPositionName.SizeF = new System.Drawing.SizeF(576.833F, 53.23453F);
            this.txtPositionName.StylePriority.UseBackColor = false;
            this.txtPositionName.StylePriority.UseBorderColor = false;
            this.txtPositionName.StylePriority.UseBorders = false;
            this.txtPositionName.StylePriority.UseFont = false;
            this.txtPositionName.StylePriority.UseForeColor = false;
            this.txtPositionName.StylePriority.UseTextAlignment = false;
            this.txtPositionName.Text = "Phó Trưởng Phòng";
            this.txtPositionName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // txtEmployessName
            // 
            this.txtEmployessName.BackColor = System.Drawing.Color.Transparent;
            this.txtEmployessName.BorderColor = System.Drawing.Color.Black;
            this.txtEmployessName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.txtEmployessName.Dpi = 254F;
            this.txtEmployessName.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
            this.txtEmployessName.ForeColor = System.Drawing.Color.Black;
            this.txtEmployessName.LocationFloat = new DevExpress.Utils.PointFloat(314.5835F, 183.7499F);
            this.txtEmployessName.Multiline = true;
            this.txtEmployessName.Name = "txtEmployessName";
            this.txtEmployessName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtEmployessName.SizeF = new System.Drawing.SizeF(576.833F, 92.92197F);
            this.txtEmployessName.StylePriority.UseBackColor = false;
            this.txtEmployessName.StylePriority.UseBorderColor = false;
            this.txtEmployessName.StylePriority.UseBorders = false;
            this.txtEmployessName.StylePriority.UseFont = false;
            this.txtEmployessName.StylePriority.UseForeColor = false;
            this.txtEmployessName.StylePriority.UseTextAlignment = false;
            this.txtEmployessName.Text = "Dương Đức Anh";
            this.txtEmployessName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // pctAvata
            // 
            this.pctAvata.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.pctAvata.Dpi = 254F;
            this.pctAvata.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.pctAvata.ImageUrl = "Z:\\DONG DUONG 1\\TEMPORARY\\IT\\2.LOGO\\LOGO1.png";
            this.pctAvata.LocationFloat = new DevExpress.Utils.PointFloat(14.41676F, 183.75F);
            this.pctAvata.Name = "pctAvata";
            this.pctAvata.SizeF = new System.Drawing.SizeF(300F, 300F);
            this.pctAvata.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.pctAvata.StylePriority.UseBorders = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel1.BorderColor = System.Drawing.Color.Black;
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(314.5835F, 14.41669F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(576.833F, 92.92192F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorderColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "CÔNG TY TNHH SẢN XUẤT NHỰA & CƠ KHÍ ĐÔNG DƯƠNG 2";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel5
            // 
            this.xrLabel5.BackColor = System.Drawing.Color.Aqua;
            this.xrLabel5.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel5.Dpi = 254F;
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.White;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 107.3386F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(891.4165F, 55.88029F);
            this.xrLabel5.StylePriority.UseBackColor = false;
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Website : dongduongpla.com.vn\r\n";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.Dpi = 254F;
            this.xrPictureBox1.ImageAlignment = DevExpress.XtraPrinting.ImageAlignment.MiddleCenter;
            this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("xrPictureBox1.ImageSource"));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(14.41676F, 14.41667F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(300.1667F, 81.64582F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.StretchImage;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 25.37498F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 44.54161F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // rpEmployessCard
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(130, 141, 25, 45);
            this.PageHeight = 2970;
            this.PageWidth = 2100;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.ReportPrintOptions.DetailCountOnEmptyDataSource = 12;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "19.1";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.XRPanel panel1;
        private DevExpress.XtraReports.UI.XRBarCode txtBarCode;
        private DevExpress.XtraReports.UI.XRLabel txtEmployessCode;
        private DevExpress.XtraReports.UI.XRLabel txtPositionName;
        private DevExpress.XtraReports.UI.XRLabel txtEmployessName;
        private DevExpress.XtraReports.UI.XRPictureBox pctAvata;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
    }
}
