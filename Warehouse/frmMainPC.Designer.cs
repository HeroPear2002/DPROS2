namespace WareHouse
{
    partial class frmMainPC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainPC));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnPOInput = new DevExpress.XtraBars.BarButtonItem();
            this.btnPOOutput = new DevExpress.XtraBars.BarButtonItem();
            this.btnPOFix = new DevExpress.XtraBars.BarButtonItem();
            this.btnBox = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoxInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnEfficBox = new DevExpress.XtraBars.BarButtonItem();
            this.btnCTSX = new DevExpress.XtraBars.BarButtonItem();
            this.btnTableIventory = new DevExpress.XtraBars.BarButtonItem();
            this.btnTDSX = new DevExpress.XtraBars.BarButtonItem();
            this.btnListTableSX = new DevExpress.XtraBars.BarButtonItem();
            this.btnListTableTT = new DevExpress.XtraBars.BarButtonItem();
            this.btnListTableDK = new DevExpress.XtraBars.BarButtonItem();
            this.btnOEE = new DevExpress.XtraBars.BarButtonItem();
            this.btnOrderList = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem17 = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.btnListTableXH = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeliveryNote = new DevExpress.XtraBars.BarButtonItem();
            this.btnFCPart = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartPrice = new DevExpress.XtraBars.BarButtonItem();
            this.btnFCMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.btnFormMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterialPrice = new DevExpress.XtraBars.BarButtonItem();
            this.btnTableMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterialBy = new DevExpress.XtraBars.BarButtonItem();
            this.btnTableExport = new DevExpress.XtraBars.BarButtonItem();
            this.btnReceiptSlip = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbfOrder = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.btnPOInput,
            this.btnPOOutput,
            this.btnPOFix,
            this.btnBox,
            this.btnBoxInfor,
            this.btnEfficBox,
            this.btnCTSX,
            this.btnTableIventory,
            this.btnTDSX,
            this.btnListTableSX,
            this.btnListTableTT,
            this.btnListTableDK,
            this.btnOEE,
            this.btnOrderList,
            this.barButtonItem17,
            this.barHeaderItem1,
            this.btnListTableXH,
            this.btnDeliveryNote,
            this.btnFCPart,
            this.btnChartPrice,
            this.btnFCMaterial,
            this.btnFormMaterial,
            this.btnMaterialPrice,
            this.btnTableMaterial,
            this.btnMaterialBy,
            this.btnTableExport,
            this.btnReceiptSlip});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 35;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.rbfOrder,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1364, 146);
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            // 
            // btnPOInput
            // 
            this.btnPOInput.Caption = "DS PO NHẬN";
            this.btnPOInput.Id = 1;
            this.btnPOInput.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPOInput.ImageOptions.Image")));
            this.btnPOInput.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPOInput.ImageOptions.LargeImage")));
            this.btnPOInput.Name = "btnPOInput";
            this.btnPOInput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPOInput_ItemClick);
            // 
            // btnPOOutput
            // 
            this.btnPOOutput.Caption = "DS PO GIAO";
            this.btnPOOutput.Id = 2;
            this.btnPOOutput.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPOOutput.ImageOptions.Image")));
            this.btnPOOutput.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPOOutput.ImageOptions.LargeImage")));
            this.btnPOOutput.Name = "btnPOOutput";
            this.btnPOOutput.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPOOutput_ItemClick);
            // 
            // btnPOFix
            // 
            this.btnPOFix.Caption = "DS PO FIX";
            this.btnPOFix.Id = 3;
            this.btnPOFix.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPOFix.ImageOptions.Image")));
            this.btnPOFix.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPOFix.ImageOptions.LargeImage")));
            this.btnPOFix.Name = "btnPOFix";
            this.btnPOFix.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPOFix_ItemClick);
            // 
            // btnBox
            // 
            this.btnBox.Caption = "HỘP TRỐNG";
            this.btnBox.Id = 4;
            this.btnBox.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBox.ImageOptions.Image")));
            this.btnBox.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBox.ImageOptions.LargeImage")));
            this.btnBox.Name = "btnBox";
            this.btnBox.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBox_ItemClick);
            // 
            // btnBoxInfor
            // 
            this.btnBoxInfor.Caption = "SETUP HỘP";
            this.btnBoxInfor.Id = 5;
            this.btnBoxInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBoxInfor.ImageOptions.Image")));
            this.btnBoxInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBoxInfor.ImageOptions.LargeImage")));
            this.btnBoxInfor.Name = "btnBoxInfor";
            this.btnBoxInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoxInfor_ItemClick);
            // 
            // btnEfficBox
            // 
            this.btnEfficBox.Caption = "QL HỘP DƯ";
            this.btnEfficBox.Id = 6;
            this.btnEfficBox.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEfficBox.ImageOptions.Image")));
            this.btnEfficBox.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEfficBox.ImageOptions.LargeImage")));
            this.btnEfficBox.Name = "btnEfficBox";
            this.btnEfficBox.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEfficBox_ItemClick);
            // 
            // btnCTSX
            // 
            this.btnCTSX.Caption = "CHỈ THỊ SX";
            this.btnCTSX.Id = 7;
            this.btnCTSX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCTSX.ImageOptions.Image")));
            this.btnCTSX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCTSX.ImageOptions.LargeImage")));
            this.btnCTSX.Name = "btnCTSX";
            this.btnCTSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCTSX_ItemClick);
            // 
            // btnTableIventory
            // 
            this.btnTableIventory.Id = 23;
            this.btnTableIventory.Name = "btnTableIventory";
            // 
            // btnTDSX
            // 
            this.btnTDSX.Caption = "QUẢN LÝ TIẾN ĐỘ SẢN XUẤT";
            this.btnTDSX.Id = 11;
            this.btnTDSX.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTDSX.ImageOptions.SvgImage")));
            this.btnTDSX.Name = "btnTDSX";
            this.btnTDSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTDSX_ItemClick);
            // 
            // btnListTableSX
            // 
            this.btnListTableSX.Caption = "DANH SÁCH SX";
            this.btnListTableSX.Id = 12;
            this.btnListTableSX.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListTableSX.ImageOptions.Image")));
            this.btnListTableSX.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListTableSX.ImageOptions.LargeImage")));
            this.btnListTableSX.Name = "btnListTableSX";
            this.btnListTableSX.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnListTableSX.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListTableSX_ItemClick);
            // 
            // btnListTableTT
            // 
            this.btnListTableTT.Caption = "DANH SÁCH TT";
            this.btnListTableTT.Id = 13;
            this.btnListTableTT.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListTableTT.ImageOptions.Image")));
            this.btnListTableTT.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListTableTT.ImageOptions.LargeImage")));
            this.btnListTableTT.Name = "btnListTableTT";
            this.btnListTableTT.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnListTableTT.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListTableTT_ItemClick);
            // 
            // btnListTableDK
            // 
            this.btnListTableDK.Caption = "DANH SÁCH DK";
            this.btnListTableDK.Id = 14;
            this.btnListTableDK.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListTableDK.ImageOptions.Image")));
            this.btnListTableDK.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListTableDK.ImageOptions.LargeImage")));
            this.btnListTableDK.Name = "btnListTableDK";
            this.btnListTableDK.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnListTableDK.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListTableDK_ItemClick);
            // 
            // btnOEE
            // 
            this.btnOEE.Caption = "HS TỔNG HỢP THIẾT BỊ";
            this.btnOEE.Id = 15;
            this.btnOEE.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOEE.ImageOptions.Image")));
            this.btnOEE.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOEE.ImageOptions.LargeImage")));
            this.btnOEE.Name = "btnOEE";
            this.btnOEE.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOEE_ItemClick);
            // 
            // btnOrderList
            // 
            this.btnOrderList.Caption = "DS ĐƠN HÀNG";
            this.btnOrderList.Id = 16;
            this.btnOrderList.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOrderList.ImageOptions.Image")));
            this.btnOrderList.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnOrderList.ImageOptions.LargeImage")));
            this.btnOrderList.Name = "btnOrderList";
            this.btnOrderList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOrderList_ItemClick);
            // 
            // barButtonItem17
            // 
            this.barButtonItem17.Caption = "CHI TIẾT ĐƠN HÀNG";
            this.barButtonItem17.Id = 17;
            this.barButtonItem17.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem17.ImageOptions.Image")));
            this.barButtonItem17.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem17.ImageOptions.LargeImage")));
            this.barButtonItem17.Name = "barButtonItem17";
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Appearance.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barHeaderItem1.Appearance.Options.UseFont = true;
            this.barHeaderItem1.Caption = "Degner : Dương Đức Anh";
            this.barHeaderItem1.Id = 21;
            this.barHeaderItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barHeaderItem1.ImageOptions.Image")));
            this.barHeaderItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barHeaderItem1.ImageOptions.LargeImage")));
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // btnListTableXH
            // 
            this.btnListTableXH.Caption = "DANH SÁCH XH";
            this.btnListTableXH.Id = 22;
            this.btnListTableXH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListTableXH.ImageOptions.Image")));
            this.btnListTableXH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListTableXH.ImageOptions.LargeImage")));
            this.btnListTableXH.Name = "btnListTableXH";
            this.btnListTableXH.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnListTableXH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListTableXH_ItemClick);
            // 
            // btnDeliveryNote
            // 
            this.btnDeliveryNote.Caption = "DANH SÁCH BBGH";
            this.btnDeliveryNote.Id = 24;
            this.btnDeliveryNote.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnDeliveryNote.ImageOptions.SvgImage")));
            this.btnDeliveryNote.Name = "btnDeliveryNote";
            this.btnDeliveryNote.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeliveryNote_ItemClick);
            // 
            // btnFCPart
            // 
            this.btnFCPart.Caption = "CẬP NHẬT FC ";
            this.btnFCPart.Id = 25;
            this.btnFCPart.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFCPart.ImageOptions.SvgImage")));
            this.btnFCPart.Name = "btnFCPart";
            this.btnFCPart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFCPart_ItemClick);
            // 
            // btnChartPrice
            // 
            this.btnChartPrice.Caption = "BIỂU ĐỒ GIÁ NGUYÊN LIỆU";
            this.btnChartPrice.Id = 26;
            this.btnChartPrice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChartPrice.ImageOptions.SvgImage")));
            this.btnChartPrice.Name = "btnChartPrice";
            this.btnChartPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartPrice_ItemClick);
            // 
            // btnFCMaterial
            // 
            this.btnFCMaterial.Caption = "DANH SÁCH NL CẦN DÙNG";
            this.btnFCMaterial.Id = 27;
            this.btnFCMaterial.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFCMaterial.ImageOptions.SvgImage")));
            this.btnFCMaterial.Name = "btnFCMaterial";
            this.btnFCMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFCMaterial_ItemClick);
            // 
            // btnFormMaterial
            // 
            this.btnFormMaterial.Caption = "TÍNH NHỰA CẦN MUA";
            this.btnFormMaterial.Id = 28;
            this.btnFormMaterial.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnFormMaterial.ImageOptions.SvgImage")));
            this.btnFormMaterial.Name = "btnFormMaterial";
            this.btnFormMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormMaterial_ItemClick);
            // 
            // btnMaterialPrice
            // 
            this.btnMaterialPrice.Caption = "GIÁ THÀNH NGUYÊN LIỆU";
            this.btnMaterialPrice.Id = 29;
            this.btnMaterialPrice.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMaterialPrice.ImageOptions.SvgImage")));
            this.btnMaterialPrice.Name = "btnMaterialPrice";
            this.btnMaterialPrice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterialPrice_ItemClick);
            // 
            // btnTableMaterial
            // 
            this.btnTableMaterial.Caption = "TỒN KHO CUỐI KỲ";
            this.btnTableMaterial.Id = 30;
            this.btnTableMaterial.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTableMaterial.ImageOptions.SvgImage")));
            this.btnTableMaterial.Name = "btnTableMaterial";
            this.btnTableMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTableMaterial_ItemClick);
            // 
            // btnMaterialBy
            // 
            this.btnMaterialBy.Caption = "DS NGUYÊN LIỆU CẦN MUA";
            this.btnMaterialBy.Id = 31;
            this.btnMaterialBy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMaterialBy.ImageOptions.SvgImage")));
            this.btnMaterialBy.Name = "btnMaterialBy";
            this.btnMaterialBy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterialBy_ItemClick);
            // 
            // btnTableExport
            // 
            this.btnTableExport.Caption = "DS NGUYÊN LIỆU GỬI NCC";
            this.btnTableExport.Id = 32;
            this.btnTableExport.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnTableExport.ImageOptions.SvgImage")));
            this.btnTableExport.Name = "btnTableExport";
            this.btnTableExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTableExport_ItemClick);
            // 
            // btnReceiptSlip
            // 
            this.btnReceiptSlip.Caption = "PHIẾU NHẬN NGUYÊN LIỆU";
            this.btnReceiptSlip.Id = 34;
            this.btnReceiptSlip.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnReceiptSlip.ImageOptions.SvgImage")));
            this.btnReceiptSlip.Name = "btnReceiptSlip";
            this.btnReceiptSlip.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReceiptSlip_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "QUẢN LÝ SẢN XUẤT";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPOInput);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPOOutput, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnPOFix, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDeliveryNote, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "QUẢN LÝ PO";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBox);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnBoxInfor, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEfficBox, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "QUẢN LÝ HỘP";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnCTSX);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "CHỈ THỊ SẢN XUẤT";
            // 
            // rbfOrder
            // 
            this.rbfOrder.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6,
            this.ribbonPageGroup7});
            this.rbfOrder.Name = "rbfOrder";
            this.rbfOrder.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btnOrderList);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnMaterialBy, true);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnTableExport, true);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnFCPart, true);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnFCMaterial, true);
            this.ribbonPageGroup6.ItemLinks.Add(this.btnFormMaterial, true);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.Text = "QUẢN LÝ ĐƠN HÀNG";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnMaterialPrice, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnTableMaterial, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnChartPrice, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnReceiptSlip, true);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "NGUYÊN LIỆU";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "TIẾN ĐỘ SẢN XUẤT";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTDSX, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnListTableSX, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnListTableTT);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnListTableXH, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnListTableDK);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "QUẢN LÝ TIẾN ĐỘ SẢN XUẤT";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnOEE);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "HIỂU SUẤT MÁY";
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // frmMainPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 767);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainPC";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D Pro S2 | Ver 2.0.6.1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarButtonItem btnPOInput;
        private DevExpress.XtraBars.BarButtonItem btnPOOutput;
        private DevExpress.XtraBars.BarButtonItem btnPOFix;
        private DevExpress.XtraBars.BarButtonItem btnBox;
        private DevExpress.XtraBars.BarButtonItem btnBoxInfor;
        private DevExpress.XtraBars.BarButtonItem btnEfficBox;
        private DevExpress.XtraBars.BarButtonItem btnCTSX;
        private DevExpress.XtraBars.BarButtonItem btnTableIventory;
        private DevExpress.XtraBars.BarButtonItem btnTDSX;
        private DevExpress.XtraBars.BarButtonItem btnListTableSX;
        private DevExpress.XtraBars.BarButtonItem btnListTableTT;
        private DevExpress.XtraBars.BarButtonItem btnListTableDK;
        private DevExpress.XtraBars.BarButtonItem btnOEE;
        private DevExpress.XtraBars.BarButtonItem btnOrderList;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbfOrder;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem17;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarButtonItem btnListTableXH;
        private DevExpress.XtraBars.BarButtonItem btnDeliveryNote;
        private DevExpress.XtraBars.BarButtonItem btnFCPart;
        private DevExpress.XtraBars.BarButtonItem btnChartPrice;
        private DevExpress.XtraBars.BarButtonItem btnFCMaterial;
        private DevExpress.XtraBars.BarButtonItem btnFormMaterial;
        private DevExpress.XtraBars.BarButtonItem btnMaterialPrice;
        private DevExpress.XtraBars.BarButtonItem btnTableMaterial;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnMaterialBy;
        private DevExpress.XtraBars.BarButtonItem btnTableExport;
   
        private DevExpress.XtraBars.BarButtonItem btnReceiptSlip;
    }
}