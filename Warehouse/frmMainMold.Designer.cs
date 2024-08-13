namespace WareHouse
{
    partial class frmMainMold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainMold));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnError = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoomTest = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategoryMold = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoldInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnListMold = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoldHistory = new DevExpress.XtraBars.BarButtonItem();
            this.btnMold1M = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.btnError,
            this.btnRoomTest,
            this.btnCategoryMold,
            this.btnMoldInfor,
            this.btnListMold,
            this.btnMoldHistory,
            this.btnMold1M});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1296, 146);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnError
            // 
            this.btnError.Caption = "LỖI PHÁT SINH";
            this.btnError.Id = 1;
            this.btnError.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnError.ImageOptions.Image")));
            this.btnError.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnError.ImageOptions.LargeImage")));
            this.btnError.Name = "btnError";
            this.btnError.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnError.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnError_ItemClick);
            // 
            // btnRoomTest
            // 
            this.btnRoomTest.Caption = "BỘ PHẬN KIỂM TRA";
            this.btnRoomTest.Id = 2;
            this.btnRoomTest.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRoomTest.ImageOptions.Image")));
            this.btnRoomTest.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRoomTest.ImageOptions.LargeImage")));
            this.btnRoomTest.Name = "btnRoomTest";
            this.btnRoomTest.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRoomTest.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoomTest_ItemClick);
            // 
            // btnCategoryMold
            // 
            this.btnCategoryMold.Caption = "HM BẢO DƯỠNG";
            this.btnCategoryMold.Id = 3;
            this.btnCategoryMold.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryMold.ImageOptions.Image")));
            this.btnCategoryMold.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategoryMold.ImageOptions.LargeImage")));
            this.btnCategoryMold.Name = "btnCategoryMold";
            this.btnCategoryMold.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnCategoryMold.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategoryMold_ItemClick);
            // 
            // btnMoldInfor
            // 
            this.btnMoldInfor.Caption = "THÔNG TIN KHUÔN";
            this.btnMoldInfor.Id = 4;
            this.btnMoldInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMoldInfor.ImageOptions.LargeImage")));
            this.btnMoldInfor.Name = "btnMoldInfor";
            this.btnMoldInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoldInfor_ItemClick);
            // 
            // btnListMold
            // 
            this.btnListMold.Caption = "DANH SÁCH KHUÔN";
            this.btnListMold.Id = 5;
            this.btnListMold.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListMold.ImageOptions.Image")));
            this.btnListMold.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListMold.ImageOptions.LargeImage")));
            this.btnListMold.Name = "btnListMold";
            this.btnListMold.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListMold_ItemClick);
            // 
            // btnMoldHistory
            // 
            this.btnMoldHistory.Caption = "LÝ LỊCH BẢO DƯỠNG / SỬA CHỮA";
            this.btnMoldHistory.Id = 6;
            this.btnMoldHistory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMoldHistory.ImageOptions.Image")));
            this.btnMoldHistory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMoldHistory.ImageOptions.LargeImage")));
            this.btnMoldHistory.Name = "btnMoldHistory";
            this.btnMoldHistory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMoldHistory_ItemClick);
            // 
            // btnMold1M
            // 
            this.btnMold1M.Caption = "DANH SÁCH KHUÔN TRÊN 1M";
            this.btnMold1M.Id = 7;
            this.btnMold1M.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnMold1M.ImageOptions.Image")));
            this.btnMold1M.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnMold1M.ImageOptions.LargeImage")));
            this.btnMold1M.Name = "btnMold1M";
            this.btnMold1M.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMold1M_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "QUẢN LÝ KHUÔN";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnError);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRoomTest);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCategoryMold);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMoldInfor, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnListMold, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMoldHistory, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMold1M, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "QUẢN LÝ KHUÔN";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 657);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1296, 21);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // frmMainMold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 678);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainMold";
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
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnError;
        private DevExpress.XtraBars.BarButtonItem btnRoomTest;
        private DevExpress.XtraBars.BarButtonItem btnCategoryMold;
        private DevExpress.XtraBars.BarButtonItem btnMoldInfor;
        private DevExpress.XtraBars.BarButtonItem btnListMold;
        private DevExpress.XtraBars.BarButtonItem btnMoldHistory;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarButtonItem btnMold1M;
    }
}