namespace WareHouse.Report
{
    partial class rpQrCodeMachine
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
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.txtCodeFix = new DevExpress.XtraReports.UI.XRLabel();
            this.txtName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMachineName = new DevExpress.XtraReports.UI.XRLabel();
            this.txtMachineCode = new DevExpress.XtraReports.UI.XRLabel();
            this.txtQrCode = new DevExpress.XtraReports.UI.XRBarCode();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.xrLabel2,
            this.xrLabel4,
            this.txtCodeFix,
            this.txtName,
            this.txtMachineName,
            this.txtMachineCode,
            this.txtQrCode});
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 908.4026F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.KeepTogether = true;
            this.Detail.MultiColumn.ColumnCount = 2;
            this.Detail.MultiColumn.ColumnSpacing = 40F;
            this.Detail.MultiColumn.ColumnWidth = 900F;
            this.Detail.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
            this.Detail.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
            this.Detail.Name = "Detail";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Dpi = 254F;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(11.41662F, 577.8748F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(182.5627F, 108.4791F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UsePadding = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Loại TB";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 254F;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(11.41694F, 686.3541F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(182.5625F, 113.9824F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UsePadding = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Tên TB";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 254F;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(11.41662F, 800.3364F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(15, 5, 0, 0, 254F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(182.5625F, 100.7535F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UsePadding = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "Mã TSCĐ";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtCodeFix
            // 
            this.txtCodeFix.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtCodeFix.Dpi = 254F;
            this.txtCodeFix.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeFix.LocationFloat = new DevExpress.Utils.PointFloat(193.9794F, 800.3364F);
            this.txtCodeFix.Multiline = true;
            this.txtCodeFix.Name = "txtCodeFix";
            this.txtCodeFix.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtCodeFix.SizeF = new System.Drawing.SizeF(420.5623F, 100.7532F);
            this.txtCodeFix.StylePriority.UseBorders = false;
            this.txtCodeFix.StylePriority.UseFont = false;
            this.txtCodeFix.StylePriority.UseTextAlignment = false;
            this.txtCodeFix.Text = "Mã TSCĐ";
            this.txtCodeFix.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtName.Dpi = 254F;
            this.txtName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.LocationFloat = new DevExpress.Utils.PointFloat(193.9793F, 577.8748F);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtName.SizeF = new System.Drawing.SizeF(420.562F, 108.4792F);
            this.txtName.StylePriority.UseBorders = false;
            this.txtName.StylePriority.UseFont = false;
            this.txtName.StylePriority.UseTextAlignment = false;
            this.txtName.Text = "Loại TB";
            this.txtName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtMachineName
            // 
            this.txtMachineName.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtMachineName.Dpi = 254F;
            this.txtMachineName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMachineName.LocationFloat = new DevExpress.Utils.PointFloat(193.9794F, 686.3541F);
            this.txtMachineName.Multiline = true;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.txtMachineName.SizeF = new System.Drawing.SizeF(420.5623F, 113.9824F);
            this.txtMachineName.StylePriority.UseBorders = false;
            this.txtMachineName.StylePriority.UseFont = false;
            this.txtMachineName.StylePriority.UseTextAlignment = false;
            this.txtMachineName.Text = "Tên TB";
            this.txtMachineName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // txtMachineCode
            // 
            this.txtMachineCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtMachineCode.CanGrow = false;
            this.txtMachineCode.Dpi = 254F;
            this.txtMachineCode.Font = new System.Drawing.Font("Arial Black", 125F, System.Drawing.FontStyle.Bold);
            this.txtMachineCode.LocationFloat = new DevExpress.Utils.PointFloat(11.41662F, 0F);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.txtMachineCode.SizeF = new System.Drawing.SizeF(938.5832F, 577.8748F);
            this.txtMachineCode.StylePriority.UseBorders = false;
            this.txtMachineCode.StylePriority.UseFont = false;
            this.txtMachineCode.StylePriority.UsePadding = false;
            this.txtMachineCode.StylePriority.UseTextAlignment = false;
            this.txtMachineCode.Text = "A1";
            this.txtMachineCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtMachineCode.TextTrimming = System.Drawing.StringTrimming.None;
            this.txtMachineCode.WordWrap = false;
            // 
            // txtQrCode
            // 
            this.txtQrCode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.txtQrCode.AutoModule = true;
            this.txtQrCode.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.txtQrCode.Dpi = 254F;
            this.txtQrCode.LocationFloat = new DevExpress.Utils.PointFloat(614.5416F, 577.8748F);
            this.txtQrCode.Module = 1F;
            this.txtQrCode.Name = "txtQrCode";
            this.txtQrCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.txtQrCode.ShowText = false;
            this.txtQrCode.SizeF = new System.Drawing.SizeF(335.4589F, 323.2151F);
            this.txtQrCode.StylePriority.UseBorders = false;
            this.txtQrCode.StylePriority.UsePadding = false;
            this.txtQrCode.StylePriority.UseTextAlignment = false;
            qrCodeGenerator1.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            qrCodeGenerator1.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.Q;
            this.txtQrCode.Symbology = qrCodeGenerator1;
            this.txtQrCode.Text = "A1&&5114";
            this.txtQrCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 80F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 80F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // rpQrCodeMachine
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(80, 80, 80, 80);
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
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel txtCodeFix;
        private DevExpress.XtraReports.UI.XRLabel txtName;
        private DevExpress.XtraReports.UI.XRLabel txtMachineName;
        private DevExpress.XtraReports.UI.XRLabel txtMachineCode;
        private DevExpress.XtraReports.UI.XRBarCode txtQrCode;
    }
}
