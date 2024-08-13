namespace WareHouse
{
    partial class frmMainDevices
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainDevices));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnDevice = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategoryLong = new DevExpress.XtraBars.BarButtonItem();
            this.btnRelationShipLong = new DevExpress.XtraBars.BarButtonItem();
            this.btnCategoryShort = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistoryLong = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistoryShort = new DevExpress.XtraBars.BarButtonItem();
            this.btnDeviceChart = new DevExpress.XtraBars.BarButtonItem();
            this.btnRelationShipShort = new DevExpress.XtraBars.BarButtonItem();
            this.btnListAllMachine = new DevExpress.XtraBars.BarButtonItem();
            this.btnWeather = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartWeather = new DevExpress.XtraBars.BarButtonItem();
            this.btnCatagoryDefault = new DevExpress.XtraBars.BarButtonItem();
            this.btnSetupDefault = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataCheck = new DevExpress.XtraBars.BarButtonItem();
            this.btnHistoryData = new DevExpress.XtraBars.BarButtonItem();
            this.btnChartData = new DevExpress.XtraBars.BarButtonItem();
            this.btnMachineInfor = new DevExpress.XtraBars.BarButtonItem();
            this.btnLayoutMachine = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbpMachine = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
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
            this.btnDevice,
            this.btnCategoryLong,
            this.btnRelationShipLong,
            this.btnCategoryShort,
            this.btnHistoryLong,
            this.btnHistoryShort,
            this.btnDeviceChart,
            this.btnRelationShipShort,
            this.btnListAllMachine,
            this.btnWeather,
            this.btnChartWeather,
            this.btnCatagoryDefault,
            this.btnSetupDefault,
            this.btnDataCheck,
            this.btnHistoryData,
            this.btnChartData,
            this.btnMachineInfor,
            this.btnLayoutMachine});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 24;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage3,
            this.rbpMachine,
            this.ribbonPage2});
            this.ribbon.Size = new System.Drawing.Size(1214, 146);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.SelectedPageChanged += new System.EventHandler(this.ribbon_SelectedPageChanged);
            // 
            // btnDevice
            // 
            this.btnDevice.Caption = "HẠNG MỤC MM";
            this.btnDevice.Id = 1;
            this.btnDevice.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDevice.ImageOptions.Image")));
            this.btnDevice.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDevice.ImageOptions.LargeImage")));
            this.btnDevice.Name = "btnDevice";
            this.btnDevice.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDevice_ItemClick);
            // 
            // btnCategoryLong
            // 
            this.btnCategoryLong.Caption = "HM KT ĐỊNH KỲ";
            this.btnCategoryLong.Id = 2;
            this.btnCategoryLong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryLong.ImageOptions.Image")));
            this.btnCategoryLong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategoryLong.ImageOptions.LargeImage")));
            this.btnCategoryLong.Name = "btnCategoryLong";
            this.btnCategoryLong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnCategoryLong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategoryLong_ItemClick);
            // 
            // btnRelationShipLong
            // 
            this.btnRelationShipLong.Caption = "THIẾT LẬP ĐỊNH KỲ";
            this.btnRelationShipLong.Id = 3;
            this.btnRelationShipLong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRelationShipLong.ImageOptions.Image")));
            this.btnRelationShipLong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRelationShipLong.ImageOptions.LargeImage")));
            this.btnRelationShipLong.Name = "btnRelationShipLong";
            this.btnRelationShipLong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRelationShipLong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRelationShipLong_ItemClick);
            // 
            // btnCategoryShort
            // 
            this.btnCategoryShort.Caption = "HM KT HÀNG NGÀY";
            this.btnCategoryShort.Id = 4;
            this.btnCategoryShort.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCategoryShort.ImageOptions.Image")));
            this.btnCategoryShort.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCategoryShort.ImageOptions.LargeImage")));
            this.btnCategoryShort.Name = "btnCategoryShort";
            this.btnCategoryShort.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnCategoryShort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCategoryShort_ItemClick);
            // 
            // btnHistoryLong
            // 
            this.btnHistoryLong.Caption = "LÝ LỊCH BD ĐỊNH KỲ";
            this.btnHistoryLong.Id = 5;
            this.btnHistoryLong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryLong.ImageOptions.Image")));
            this.btnHistoryLong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryLong.ImageOptions.LargeImage")));
            this.btnHistoryLong.Name = "btnHistoryLong";
            this.btnHistoryLong.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnHistoryLong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryLong_ItemClick);
            // 
            // btnHistoryShort
            // 
            this.btnHistoryShort.Caption = "LÝ LỊCH BD HÀNG NGÀY";
            this.btnHistoryShort.Id = 6;
            this.btnHistoryShort.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryShort.ImageOptions.Image")));
            this.btnHistoryShort.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryShort.ImageOptions.LargeImage")));
            this.btnHistoryShort.Name = "btnHistoryShort";
            this.btnHistoryShort.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnHistoryShort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryShort_ItemClick);
            // 
            // btnDeviceChart
            // 
            this.btnDeviceChart.Caption = "BIỂU ĐỒ";
            this.btnDeviceChart.Id = 8;
            this.btnDeviceChart.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDeviceChart.ImageOptions.Image")));
            this.btnDeviceChart.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDeviceChart.ImageOptions.LargeImage")));
            this.btnDeviceChart.Name = "btnDeviceChart";
            this.btnDeviceChart.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDeviceChart_ItemClick);
            // 
            // btnRelationShipShort
            // 
            this.btnRelationShipShort.Caption = "THIẾT LẬP HÀNG NGÀY";
            this.btnRelationShipShort.Id = 10;
            this.btnRelationShipShort.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRelationShipShort.ImageOptions.Image")));
            this.btnRelationShipShort.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnRelationShipShort.ImageOptions.LargeImage")));
            this.btnRelationShipShort.Name = "btnRelationShipShort";
            this.btnRelationShipShort.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText;
            this.btnRelationShipShort.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRelationShipShort_ItemClick);
            // 
            // btnListAllMachine
            // 
            this.btnListAllMachine.Caption = "DANH SÁCH THIẾT BỊ";
            this.btnListAllMachine.Id = 11;
            this.btnListAllMachine.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListAllMachine.ImageOptions.Image")));
            this.btnListAllMachine.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnListAllMachine.ImageOptions.LargeImage")));
            this.btnListAllMachine.Name = "btnListAllMachine";
            this.btnListAllMachine.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnListAllMachine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnListAllMachine_ItemClick);
            // 
            // btnWeather
            // 
            this.btnWeather.Caption = "NHIỆT ĐỘ / ĐỘ ẨM";
            this.btnWeather.Id = 12;
            this.btnWeather.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnWeather.ImageOptions.SvgImage")));
            this.btnWeather.Name = "btnWeather";
            this.btnWeather.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWeather_ItemClick);
            // 
            // btnChartWeather
            // 
            this.btnChartWeather.Caption = "BIỂU ĐỒ";
            this.btnChartWeather.Id = 13;
            this.btnChartWeather.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnChartWeather.ImageOptions.SvgImage")));
            this.btnChartWeather.Name = "btnChartWeather";
            this.btnChartWeather.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartWeather_ItemClick);
            // 
            // btnCatagoryDefault
            // 
            this.btnCatagoryDefault.Caption = "HẠNG MỤC KIỂM TRA";
            this.btnCatagoryDefault.Id = 17;
            this.btnCatagoryDefault.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCatagoryDefault.ImageOptions.Image")));
            this.btnCatagoryDefault.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnCatagoryDefault.ImageOptions.LargeImage")));
            this.btnCatagoryDefault.Name = "btnCatagoryDefault";
            this.btnCatagoryDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnCatagoryDefault_ItemClick);
            // 
            // btnSetupDefault
            // 
            this.btnSetupDefault.Caption = "SETUP MÁY & KHUÔN";
            this.btnSetupDefault.Id = 18;
            this.btnSetupDefault.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetupDefault.ImageOptions.Image")));
            this.btnSetupDefault.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSetupDefault.ImageOptions.LargeImage")));
            this.btnSetupDefault.Name = "btnSetupDefault";
            this.btnSetupDefault.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSetupDefault_ItemClick);
            // 
            // btnDataCheck
            // 
            this.btnDataCheck.Caption = "BẢNG KIỂM TRA DL MÁY ";
            this.btnDataCheck.Id = 19;
            this.btnDataCheck.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDataCheck.ImageOptions.Image")));
            this.btnDataCheck.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDataCheck.ImageOptions.LargeImage")));
            this.btnDataCheck.Name = "btnDataCheck";
            this.btnDataCheck.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataCheck_ItemClick);
            // 
            // btnHistoryData
            // 
            this.btnHistoryData.Caption = "LỊCH SỬ KIỂM TRA MÁY ĐÚC";
            this.btnHistoryData.Id = 20;
            this.btnHistoryData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHistoryData.ImageOptions.Image")));
            this.btnHistoryData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnHistoryData.ImageOptions.LargeImage")));
            this.btnHistoryData.Name = "btnHistoryData";
            this.btnHistoryData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHistoryData_ItemClick);
            // 
            // btnChartData
            // 
            this.btnChartData.Caption = "BIỂU ĐỒ";
            this.btnChartData.Id = 21;
            this.btnChartData.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChartData.ImageOptions.Image")));
            this.btnChartData.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnChartData.ImageOptions.LargeImage")));
            this.btnChartData.Name = "btnChartData";
            this.btnChartData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChartData_ItemClick);
            // 
            // btnMachineInfor
            // 
            this.btnMachineInfor.Caption = "THIẾT LẬP THÔNG TIN CHI TIẾT MÁY";
            this.btnMachineInfor.Id = 22;
            this.btnMachineInfor.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnMachineInfor.ImageOptions.SvgImage")));
            this.btnMachineInfor.Name = "btnMachineInfor";
            this.btnMachineInfor.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMachineInfor_ItemClick);
            // 
            // btnLayoutMachine
            // 
            this.btnLayoutMachine.Caption = "LAYOUT THIẾT BỊ";
            this.btnLayoutMachine.Id = 23;
            this.btnLayoutMachine.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLayoutMachine.ImageOptions.SvgImage")));
            this.btnLayoutMachine.Name = "btnLayoutMachine";
            this.btnLayoutMachine.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLayoutMachine_ItemClick);
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup7});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "DỮ LIỆU MÁY";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btnCatagoryDefault);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnSetupDefault, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnDataCheck, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnHistoryData, true);
            this.ribbonPageGroup7.ItemLinks.Add(this.btnChartData, true);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.Text = "DỮ LIỆU MÁY ĐÚC";
            // 
            // rbpMachine
            // 
            this.rbpMachine.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.rbpMachine.Name = "rbpMachine";
            this.rbpMachine.Text = "QUẢN LÝ THIẾT BỊ";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnLayoutMachine);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnMachineInfor, true);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "MÁY MÓC THIẾT BỊ";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCategoryLong);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnCategoryShort);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRelationShipLong, true);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRelationShipShort);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "HẠNG MỤC BẢO DƯỠNG";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHistoryLong);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHistoryShort);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "LÝ LỊCH BẢO DƯỠNG / SỬA CHỮA";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDeviceChart);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnListAllMachine, true);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDevice, true);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "GIÁ TRỊ TIÊU CHUẨN";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "NHÀ XƯỞNG";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnWeather);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnChartWeather, true);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "NHÀ XƯỞNG";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 652);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1214, 21);
            // 
            // xtraTabbedMdiManager
            // 
            this.xtraTabbedMdiManager.MdiParent = this;
            // 
            // frmMainDevices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 673);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "frmMainDevices";
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
        private DevExpress.XtraBars.Ribbon.RibbonPage rbpMachine;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem btnDevice;
        private DevExpress.XtraBars.BarButtonItem btnCategoryLong;
        private DevExpress.XtraBars.BarButtonItem btnRelationShipLong;
        private DevExpress.XtraBars.BarButtonItem btnCategoryShort;
        private DevExpress.XtraBars.BarButtonItem btnHistoryLong;
        private DevExpress.XtraBars.BarButtonItem btnHistoryShort;
        private DevExpress.XtraBars.BarButtonItem btnDeviceChart;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnRelationShipShort;
        private DevExpress.XtraBars.BarButtonItem btnListAllMachine;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnWeather;
        private DevExpress.XtraBars.BarButtonItem btnChartWeather;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager;
        private DevExpress.XtraBars.BarButtonItem btnCatagoryDefault;
        private DevExpress.XtraBars.BarButtonItem btnSetupDefault;
        private DevExpress.XtraBars.BarButtonItem btnDataCheck;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btnHistoryData;
        private DevExpress.XtraBars.BarButtonItem btnChartData;
        private DevExpress.XtraBars.BarButtonItem btnMachineInfor;
        private DevExpress.XtraBars.BarButtonItem btnLayoutMachine;
    }
}