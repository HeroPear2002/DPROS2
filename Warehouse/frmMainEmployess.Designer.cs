namespace WareHouse
{
    partial class frmMainEmployess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainEmployess));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnEmployess = new DevExpress.XtraBars.BarButtonItem();
            this.btnRoom = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategory = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployessInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnPosition = new DevExpress.XtraBars.BarButtonItem();
            this.btnEmployessCard = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
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
            this.btnEmployess,
            this.btnRoom,
            this.btnCategory,
            this.btnEmployessInfor,
            this.btnInfor,
            this.btnPosition,
            this.btnEmployessCard});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbon.MaxItemId = 8;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1364, 146);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // btnEmployess
            // 
            this.btnEmployess.Caption = "DANH SÁCH NHÂN VIÊN";
            this.btnEmployess.Id = 1;
            this.btnEmployess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployess.ImageOptions.Image")));
            this.btnEmployess.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployess.ImageOptions.LargeImage")));
            this.btnEmployess.Name = "btnEmployess";
            this.btnEmployess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployess_ItemClick);
            // 
            // btnRoom
            // 
            this.btnRoom.Caption = "PHÒNG BAN";
            this.btnRoom.Id = 2;
            this.btnRoom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRoom.ImageOptions.Image")));
            this.btnRoom.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRoom.ImageOptions.LargeImage")));
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRoom_ItemClick);
            // 
            // btnCategory
            // 
            this.btnCategory.Caption = "HẠNG MỤC CỘNG / TRỪ ĐIỂM";
            this.btnCategory.Id = 3;
            this.btnCategory.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategory.ImageOptions.Image")));
            this.btnCategory.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategory.ImageOptions.LargeImage")));
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategory_ItemClick);
            // 
            // btnEmployessInfor
            // 
            this.btnEmployessInfor.Caption = "BẢNG THEO DÕI THÀNH TÍCH CNV";
            this.btnEmployessInfor.Id = 4;
            this.btnEmployessInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEmployessInfor.ImageOptions.Image")));
            this.btnEmployessInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnEmployessInfor.ImageOptions.LargeImage")));
            this.btnEmployessInfor.Name = "btnEmployessInfor";
            this.btnEmployessInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployessInfor_ItemClick);
            // 
            // btnInfor
            // 
            this.btnInfor.Caption = "SỔ GHI CHÉP CNV";
            this.btnInfor.Id = 5;
            this.btnInfor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnInfor.ImageOptions.Image")));
            this.btnInfor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnInfor.ImageOptions.LargeImage")));
            this.btnInfor.Name = "btnInfor";
            this.btnInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInfor_ItemClick);
            // 
            // btnPosition
            // 
            this.btnPosition.Caption = "DANH SÁCH CHỨC VỤ";
            this.btnPosition.Id = 6;
            this.btnPosition.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnPosition.ImageOptions.SvgImage")));
            this.btnPosition.Name = "btnPosition";
            this.btnPosition.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPosition_ItemClick);
            // 
            // btnEmployessCard
            // 
            this.btnEmployessCard.Caption = "DANH SÁCH THẺ CNV";
            this.btnEmployessCard.Id = 7;
            this.btnEmployessCard.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnEmployessCard.ImageOptions.SvgImage")));
            this.btnEmployessCard.Name = "btnEmployessCard";
            this.btnEmployessCard.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnEmployessCard_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "QUẢN LÝ  NHÂN VIÊN";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnEmployessInfor);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnEmployess);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnRoom, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnCategory, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnInfor, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "QUẢN LÝ THẺ CNV";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnPosition);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnEmployessCard, true);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "QUẢN LÝ THẺ CNV";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 746);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1364, 21);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // frmMainEmployess
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 767);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmMainEmployess";
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
        private DevExpress.XtraBars.BarButtonItem btnEmployess;
        private DevExpress.XtraBars.BarButtonItem btnRoom;
        private DevExpress.XtraBars.BarButtonItem btnCategory;
        private DevExpress.XtraBars.BarButtonItem btnEmployessInfor;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarButtonItem btnInfor;
        private DevExpress.XtraBars.BarButtonItem btnPosition;
        private DevExpress.XtraBars.BarButtonItem btnEmployessCard;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
    }
}