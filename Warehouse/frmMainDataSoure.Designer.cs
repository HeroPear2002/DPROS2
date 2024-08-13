namespace WareHouse
{
    partial class frmMainDataSoure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainDataSoure));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnVendor = new DevExpress.XtraBars.BarButtonItem();
            this.btnCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterial = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterialHH = new DevExpress.XtraBars.BarButtonItem();
            this.btnPart = new DevExpress.XtraBars.BarButtonItem();
            this.btnPartInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnMac = new DevExpress.XtraBars.BarButtonItem();
            this.btnBoxNature = new DevExpress.XtraBars.BarButtonItem();
            this.btnAccount = new DevExpress.XtraBars.BarButtonItem();
            this.btnAdmin = new DevExpress.XtraBars.BarButtonItem();
            this.btnLockPart = new DevExpress.XtraBars.BarButtonItem();
            this.btnFormPart = new DevExpress.XtraBars.BarButtonItem();
            this.btnRatio = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistoryMac = new DevExpress.XtraBars.BarButtonItem();
            this.btnFactory = new DevExpress.XtraBars.BarButtonItem();
            this.btnMac4M = new DevExpress.XtraBars.BarButtonItem();
            this.btnPermission = new DevExpress.XtraBars.BarButtonItem();
            this.btnMaterialBegin = new DevExpress.XtraBars.BarButtonItem();
            this.btnMachineDry = new DevExpress.XtraBars.BarButtonItem();
            this.btnReason = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
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
            this.btnVendor,
            this.btnCustomer,
            this.btnMaterial,
            this.btnMaterialHH,
            this.btnPart,
            this.btnPartInfor,
            this.btnMac,
            this.btnBoxNature,
            this.btnAccount,
            this.btnAdmin,
            this.btnLockPart,
            this.btnFormPart,
            this.btnRatio,
            this.btnHistoryMac,
            this.btnFactory,
            this.btnMac4M,
            this.btnPermission,
            this.btnMaterialBegin,
            this.btnMachineDry,
            this.btnReason});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 24;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1364, 146);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnVendor
            // 
            this.btnVendor.Caption = "NHÀ CUNG CẤP";
            this.btnVendor.Id = 1;
            this.btnVendor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnVendor.ImageOptions.SvgImage")));
            this.btnVendor.Name = "btnVendor";
            this.btnVendor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnVendor_ItemClick);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Caption = "KHÁCH HÀNG";
            this.btnCustomer.Id = 2;
            this.btnCustomer.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.Image")));
            this.btnCustomer.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCustomer.ImageOptions.LargeImage")));
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCustomer_ItemClick);
            // 
            // btnMaterial
            // 
            this.btnMaterial.Caption = "NGUYÊN LIỆU";
            this.btnMaterial.Id = 3;
            this.btnMaterial.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterial.ImageOptions.Image")));
            this.btnMaterial.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMaterial.ImageOptions.LargeImage")));
            this.btnMaterial.Name = "btnMaterial";
            this.btnMaterial.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterial_ItemClick);
            // 
            // btnMaterialHH
            // 
            this.btnMaterialHH.Caption = "NGUYÊN LIỆU HỖN HỢP";
            this.btnMaterialHH.Id = 4;
            this.btnMaterialHH.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterialHH.ImageOptions.Image")));
            this.btnMaterialHH.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMaterialHH.ImageOptions.LargeImage")));
            this.btnMaterialHH.Name = "btnMaterialHH";
            this.btnMaterialHH.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterialHH_ItemClick);
            // 
            // btnPart
            // 
            this.btnPart.Caption = "LINH KIỆN";
            this.btnPart.Id = 5;
            this.btnPart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPart.ImageOptions.Image")));
            this.btnPart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPart.ImageOptions.LargeImage")));
            this.btnPart.Name = "btnPart";
            this.btnPart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPart_ItemClick);
            // 
            // btnPartInfor
            // 
            this.btnPartInfor.Caption = "TỶ LỆ HAO HỤT";
            this.btnPartInfor.Id = 6;
            this.btnPartInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPartInfor.ImageOptions.Image")));
            this.btnPartInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPartInfor.ImageOptions.LargeImage")));
            this.btnPartInfor.Name = "btnPartInfor";
            this.btnPartInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPartInfor_ItemClick);
            // 
            // btnMac
            // 
            this.btnMac.Caption = "MÁC CÀI SẢN PHẨM";
            this.btnMac.Id = 7;
            this.btnMac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMac.ImageOptions.Image")));
            this.btnMac.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMac.ImageOptions.LargeImage")));
            this.btnMac.Name = "btnMac";
            this.btnMac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMac_ItemClick);
            // 
            // btnBoxNature
            // 
            this.btnBoxNature.Caption = "HỘP ĐỰNG HÀNG";
            this.btnBoxNature.Id = 8;
            this.btnBoxNature.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnBoxNature.ImageOptions.Image")));
            this.btnBoxNature.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnBoxNature.ImageOptions.LargeImage")));
            this.btnBoxNature.Name = "btnBoxNature";
            this.btnBoxNature.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBoxNature_ItemClick);
            // 
            // btnAccount
            // 
            this.btnAccount.Caption = "TÀI KHOẢN";
            this.btnAccount.Id = 9;
            this.btnAccount.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAccount.ImageOptions.Image")));
            this.btnAccount.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAccount.ImageOptions.LargeImage")));
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAccount_ItemClick);
            // 
            // btnAdmin
            // 
            this.btnAdmin.Caption = "QUẢN TRỊ VIÊN";
            this.btnAdmin.Id = 10;
            this.btnAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdmin.ImageOptions.Image")));
            this.btnAdmin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnAdmin.ImageOptions.LargeImage")));
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAdmin_ItemClick);
            // 
            // btnLockPart
            // 
            this.btnLockPart.Caption = "KHÓA LINH KIỆN ";
            this.btnLockPart.Id = 12;
            this.btnLockPart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLockPart.ImageOptions.Image")));
            this.btnLockPart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnLockPart.ImageOptions.LargeImage")));
            this.btnLockPart.Name = "btnLockPart";
            this.btnLockPart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLockPart_ItemClick);
            // 
            // btnFormPart
            // 
            this.btnFormPart.Caption = "Form QC";
            this.btnFormPart.Id = 13;
            this.btnFormPart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFormPart.ImageOptions.Image")));
            this.btnFormPart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFormPart.ImageOptions.LargeImage")));
            this.btnFormPart.Name = "btnFormPart";
            this.btnFormPart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormPart_ItemClick);
            // 
            // btnRatio
            // 
            this.btnRatio.Caption = "TỶ LỆ TÁI CHẾ";
            this.btnRatio.Id = 14;
            this.btnRatio.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRatio.ImageOptions.Image")));
            this.btnRatio.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRatio.ImageOptions.LargeImage")));
            this.btnRatio.Name = "btnRatio";
            this.btnRatio.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRatio_ItemClick);
            // 
            // btnHistoryMac
            // 
            this.btnHistoryMac.Caption = "LÝ LỊCH IN MÁC";
            this.btnHistoryMac.Id = 15;
            this.btnHistoryMac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryMac.ImageOptions.Image")));
            this.btnHistoryMac.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryMac.ImageOptions.LargeImage")));
            this.btnHistoryMac.Name = "btnHistoryMac";
            this.btnHistoryMac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryMac_ItemClick);
            // 
            // btnFactory
            // 
            this.btnFactory.Caption = "NHÀ MÁY";
            this.btnFactory.Id = 16;
            this.btnFactory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnFactory.ImageOptions.Image")));
            this.btnFactory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnFactory.ImageOptions.LargeImage")));
            this.btnFactory.Name = "btnFactory";
            this.btnFactory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFactory_ItemClick);
            // 
            // btnMac4M
            // 
            this.btnMac4M.Caption = "QUẢN LÝ 4M";
            this.btnMac4M.Id = 17;
            this.btnMac4M.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMac4M.ImageOptions.Image")));
            this.btnMac4M.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMac4M.ImageOptions.LargeImage")));
            this.btnMac4M.Name = "btnMac4M";
            this.btnMac4M.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMac4M_ItemClick);
            // 
            // btnPermission
            // 
            this.btnPermission.Caption = "PHÂN QUYỀN";
            this.btnPermission.Id = 18;
            this.btnPermission.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPermission.ImageOptions.Image")));
            this.btnPermission.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPermission.ImageOptions.LargeImage")));
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPermission_ItemClick);
            // 
            // btnMaterialBegin
            // 
            this.btnMaterialBegin.Caption = "CHUẨN BỊ NL TRƯỚC SX";
            this.btnMaterialBegin.Id = 20;
            this.btnMaterialBegin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMaterialBegin.ImageOptions.Image")));
            this.btnMaterialBegin.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMaterialBegin.ImageOptions.LargeImage")));
            this.btnMaterialBegin.Name = "btnMaterialBegin";
            this.btnMaterialBegin.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMaterialBegin_ItemClick);
            // 
            // btnMachineDry
            // 
            this.btnMachineDry.Caption = "DÁNH SÁCH MÁY SẤY KHAY";
            this.btnMachineDry.Id = 22;
            this.btnMachineDry.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMachineDry.ImageOptions.SvgImage")));
            this.btnMachineDry.Name = "btnMachineDry";
            this.btnMachineDry.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMachineDry_ItemClick);
            // 
            // btnReason
            // 
            this.btnReason.Caption = "DANH SÁCH LÝ DO";
            this.btnReason.Id = 23;
            this.btnReason.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReason.ImageOptions.Image")));
            this.btnReason.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReason.ImageOptions.LargeImage")));
            this.btnReason.Name = "btnReason";
            this.btnReason.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReason_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "DỮ LIỆU NGUỒN";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnVendor);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCustomer, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMaterial, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMachineDry, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnReason, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMaterialHH, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRatio, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMaterialBegin, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPart, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnPartInfor, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnFactory, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnMac, true);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "PHÒNG PC QUẢN LÝ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHistoryMac, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMac4M, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnFormPart, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLockPart, true);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnBoxNature, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "HỆ THỐNG";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAccount);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnAdmin, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnPermission);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 746);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1364, 21);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // frmMainDataSoure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 767);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainDataSoure";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
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
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnVendor;
        private DevExpress.XtraBars.BarButtonItem btnCustomer;
        private DevExpress.XtraBars.BarButtonItem btnMaterial;
        private DevExpress.XtraBars.BarButtonItem btnMaterialHH;
        private DevExpress.XtraBars.BarButtonItem btnPart;
        private DevExpress.XtraBars.BarButtonItem btnPartInfor;
        private DevExpress.XtraBars.BarButtonItem btnMac;
        private DevExpress.XtraBars.BarButtonItem btnBoxNature;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnAccount;
        private DevExpress.XtraBars.BarButtonItem btnAdmin;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarButtonItem btnLockPart;
        private DevExpress.XtraBars.BarButtonItem btnFormPart;
        private DevExpress.XtraBars.BarButtonItem btnRatio;
        private DevExpress.XtraBars.BarButtonItem btnHistoryMac;
        private DevExpress.XtraBars.BarButtonItem btnFactory;
        private DevExpress.XtraBars.BarButtonItem btnMac4M;
        private DevExpress.XtraBars.BarButtonItem btnPermission;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnMaterialBegin;
        private DevExpress.XtraBars.BarButtonItem btnMachineDry;
        private DevExpress.XtraBars.BarButtonItem btnReason;
    }
}