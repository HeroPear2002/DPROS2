namespace WareHouse.PC
{
    partial class frmKHBD
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
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKHBD));
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
            this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnListKHBD = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem13 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
            this.schedulerControl1.Location = new System.Drawing.Point(12, 38);
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.Size = new System.Drawing.Size(1129, 510);
            this.schedulerControl1.Start = new System.DateTime(2008, 12, 3, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.GanttView.Enabled = false;
            this.schedulerControl1.Views.MonthView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.CustomDrawAppointment += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointment);
            this.schedulerControl1.CustomDrawAppointmentBackground += new DevExpress.XtraScheduler.CustomDrawObjectEventHandler(this.schedulerControl1_CustomDrawAppointmentBackground);
            // 
            // dateNavigator1
            // 
            this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateNavigator1.CellPadding = new System.Windows.Forms.Padding(2);
            this.dateNavigator1.DateTime = new System.DateTime(2008, 12, 3, 0, 0, 0, 0);
            this.dateNavigator1.EditValue = new System.DateTime(2008, 12, 3, 0, 0, 0, 0);
            this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.dateNavigator1.Location = new System.Drawing.Point(1145, 38);
            this.dateNavigator1.Name = "dateNavigator1";
            this.dateNavigator1.SchedulerControl = this.schedulerControl1;
            this.dateNavigator1.Size = new System.Drawing.Size(193, 510);
            this.dateNavigator1.StyleController = this.layoutControl1;
            this.dateNavigator1.TabIndex = 2;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnListKHBD);
            this.layoutControl1.Controls.Add(this.dateNavigator1);
            this.layoutControl1.Controls.Add(this.schedulerControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(455, 347, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1350, 560);
            this.layoutControl1.TabIndex = 3;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnListKHBD
            // 
            this.btnListKHBD.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListKHBD.ImageOptions.Image")));
            this.btnListKHBD.Location = new System.Drawing.Point(12, 12);
            this.btnListKHBD.Name = "btnListKHBD";
            this.btnListKHBD.Size = new System.Drawing.Size(107, 22);
            this.btnListKHBD.StyleController = this.layoutControl1;
            this.btnListKHBD.TabIndex = 11;
            this.btnListKHBD.Text = "Danh sạch KHBD";
            this.btnListKHBD.Click += new System.EventHandler(this.btnListKHBD_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem13,
            this.emptySpaceItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1350, 560);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.schedulerControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1133, 514);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dateNavigator1;
            this.layoutControlItem2.Location = new System.Drawing.Point(1133, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(197, 514);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem13
            // 
            this.layoutControlItem13.Control = this.btnListKHBD;
            this.layoutControlItem13.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem13.Name = "layoutControlItem13";
            this.layoutControlItem13.Size = new System.Drawing.Size(111, 26);
            this.layoutControlItem13.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem13.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(111, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1219, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // frmKHBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 560);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmKHBD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kế Hoạch Ban Đầu ";
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
        private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraEditors.SimpleButton btnListKHBD;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem13;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
    }
}