namespace WareHouse.Report
{
    partial class rpQRSmall
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
			DevExpress.XtraPrinting.BarCode.QRCodeGenerator qrCodeGenerator1 = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.txtMachineCode = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtMachineName = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.txtCodeFix = new DevExpress.XtraReports.UI.XRLabel();
			this.txtQrCode = new DevExpress.XtraReports.UI.XRBarCode();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.txtMachineCode,
            this.xrLabel1,
            this.xrLabel3,
            this.txtMachineName,
            this.xrLabel5,
            this.txtCodeFix,
            this.txtQrCode});
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 167.7917F;
			this.Detail.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail.KeepTogether = true;
			this.Detail.MultiColumn.ColumnWidth = 475F;
			this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
			this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnWidth;
			this.Detail.Name = "Detail";
			// 
			// txtMachineCode
			// 
			this.txtMachineCode.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
			this.txtMachineCode.Dpi = 254F;
			this.txtMachineCode.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMachineCode.LocationFloat = new DevExpress.Utils.PointFloat(100.0002F, 9.776231E-05F);
			this.txtMachineCode.Multiline = true;
			this.txtMachineCode.Name = "txtMachineCode";
			this.txtMachineCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtMachineCode.SizeF = new System.Drawing.SizeF(196.4193F, 59.22079F);
			this.txtMachineCode.StylePriority.UseBorders = false;
			this.txtMachineCode.StylePriority.UseFont = false;
			this.txtMachineCode.StylePriority.UseTextAlignment = false;
			this.txtMachineCode.Text = "Loại TB";
			this.txtMachineCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
			this.xrLabel1.Dpi = 254F;
			this.xrLabel1.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 6.517487E-05F);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(99.99989F, 59.22079F);
			this.xrLabel1.StylePriority.UseBorders = false;
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UsePadding = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "Mã TB";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel3
			// 
			this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top)));
			this.xrLabel3.Dpi = 254F;
			this.xrLabel3.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 59.22089F);
			this.xrLabel3.Multiline = true;
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(99.99989F, 58.15303F);
			this.xrLabel3.StylePriority.UseBorders = false;
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UsePadding = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "Tên TB";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtMachineName
			// 
			this.txtMachineName.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
			this.txtMachineName.Dpi = 254F;
			this.txtMachineName.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtMachineName.LocationFloat = new DevExpress.Utils.PointFloat(100.0002F, 59.22089F);
			this.txtMachineName.Multiline = true;
			this.txtMachineName.Name = "txtMachineName";
			this.txtMachineName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtMachineName.SizeF = new System.Drawing.SizeF(196.4193F, 58.15303F);
			this.txtMachineName.StylePriority.UseBorders = false;
			this.txtMachineName.StylePriority.UseFont = false;
			this.txtMachineName.StylePriority.UseTextAlignment = false;
			this.txtMachineName.Text = "Loại TB";
			this.txtMachineName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel5
			// 
			this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel5.Dpi = 254F;
			this.xrLabel5.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 117.3739F);
			this.xrLabel5.Multiline = true;
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(99.99989F, 40F);
			this.xrLabel5.StylePriority.UseBorders = false;
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UsePadding = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "MTSCĐ";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtCodeFix
			// 
			this.txtCodeFix.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtCodeFix.Dpi = 254F;
			this.txtCodeFix.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtCodeFix.LocationFloat = new DevExpress.Utils.PointFloat(99.99989F, 117.3739F);
			this.txtCodeFix.Multiline = true;
			this.txtCodeFix.Name = "txtCodeFix";
			this.txtCodeFix.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
			this.txtCodeFix.SizeF = new System.Drawing.SizeF(196.4196F, 40F);
			this.txtCodeFix.StylePriority.UseBorders = false;
			this.txtCodeFix.StylePriority.UseFont = false;
			this.txtCodeFix.StylePriority.UseTextAlignment = false;
			this.txtCodeFix.Text = "Loại TB";
			this.txtCodeFix.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// txtQrCode
			// 
			this.txtQrCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.txtQrCode.AutoModule = true;
			this.txtQrCode.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Top | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.txtQrCode.Dpi = 254F;
			this.txtQrCode.LocationFloat = new DevExpress.Utils.PointFloat(296.4195F, 0F);
			this.txtQrCode.Module = 5.08F;
			this.txtQrCode.Name = "txtQrCode";
			this.txtQrCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
			this.txtQrCode.ShowText = false;
			this.txtQrCode.SizeF = new System.Drawing.SizeF(176.2057F, 157.3739F);
			this.txtQrCode.StylePriority.UseBorders = false;
			this.txtQrCode.StylePriority.UsePadding = false;
			qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
			this.txtQrCode.Symbology = qrCodeGenerator1;
			this.txtQrCode.Text = "BĐ&123456";
			// 
			// TopMargin
			// 
			this.TopMargin.Dpi = 254F;
			this.TopMargin.HeightF = 70F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Dpi = 254F;
			this.BottomMargin.HeightF = 70F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// rpQRSmall
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
			this.Dpi = 254F;
			this.Font = new System.Drawing.Font("Arial", 9.75F);
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 70, 70);
			this.PageHeight = 2970;
			this.PageWidth = 2100;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.ReportPrintOptions.DetailCountOnEmptyDataSource = 12;
			this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
			this.SnapGridSize = 25F;
			this.Version = "19.2";
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel txtMachineCode;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel txtMachineName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel txtCodeFix;
        private DevExpress.XtraReports.UI.XRBarCode txtQrCode;
    }
}
