namespace WareHouse.PC
{
    partial class CustomAppointmentForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomAppointmentForm));
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.lblLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.edtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.edtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.lblResource = new DevExpress.XtraEditors.LabelControl();
            this.tbLocation = new DevExpress.XtraEditors.TextEdit();
            this.panel1 = new DevExpress.XtraEditors.PanelControl();
            this.edtResource = new DevExpress.XtraScheduler.UI.AppointmentResourceEdit();
            this.edtResources = new DevExpress.XtraScheduler.UI.AppointmentResourcesEdit();
            this.cbReminder = new DevExpress.XtraScheduler.UI.DurationEdit();
            this.edtLabel = new DevExpress.XtraScheduler.UI.AppointmentLabelEdit();
            this.edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtEmployess = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnDoHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnLayHang = new DevExpress.XtraEditors.SimpleButton();
            this.txtNote = new DevExpress.XtraEditors.MemoEdit();
            this.btnEditQuantity = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveEnd = new DevExpress.XtraEditors.SimpleButton();
            this.txtEmployessPro = new System.Windows.Forms.TextBox();
            this.btnEndGame = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSubject
            // 
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.Name = "lblSubject";
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // tbSubject
            // 
            resources.ApplyResources(this.tbSubject, "tbSubject");
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            // 
            // lblLabel
            // 
            resources.ApplyResources(this.lblLabel, "lblLabel");
            this.lblLabel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblLabel.Appearance.Options.UseBackColor = true;
            this.lblLabel.Name = "lblLabel";
            // 
            // lblStartTime
            // 
            resources.ApplyResources(this.lblStartTime, "lblStartTime");
            this.lblStartTime.Name = "lblStartTime";
            // 
            // lblEndTime
            // 
            resources.ApplyResources(this.lblEndTime, "lblEndTime");
            this.lblEndTime.Name = "lblEndTime";
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOk.ImageOptions.Image")));
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.OnBtnOkClick);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.ImageOptions.Image")));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // edtStartDate
            // 
            resources.ApplyResources(this.edtStartDate, "edtStartDate");
            this.edtStartDate.Name = "edtStartDate";
            this.edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            this.edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtStartDate.Properties.Buttons"))))});
            this.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // edtEndDate
            // 
            resources.ApplyResources(this.edtEndDate, "edtEndDate");
            this.edtEndDate.Name = "edtEndDate";
            this.edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            this.edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtEndDate.Properties.Buttons"))))});
            this.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // lblResource
            // 
            resources.ApplyResources(this.lblResource, "lblResource");
            this.lblResource.Name = "lblResource";
            // 
            // tbLocation
            // 
            resources.ApplyResources(this.tbLocation, "tbLocation");
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Properties.AccessibleName = resources.GetString("tbLocation.Properties.AccessibleName");
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panel1.Controls.Add(this.edtResource);
            this.panel1.Controls.Add(this.lblLabel);
            this.panel1.Controls.Add(this.lblResource);
            this.panel1.Controls.Add(this.edtResources);
            this.panel1.Controls.Add(this.cbReminder);
            this.panel1.Controls.Add(this.edtLabel);
            this.panel1.Name = "panel1";
            // 
            // edtResource
            // 
            resources.ApplyResources(this.edtResource, "edtResource");
            this.edtResource.Name = "edtResource";
            this.edtResource.Properties.AccessibleName = resources.GetString("edtResource.Properties.AccessibleName");
            this.edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtResource.Properties.Buttons"))))});
            // 
            // edtResources
            // 
            resources.ApplyResources(this.edtResources, "edtResources");
            this.edtResources.Name = "edtResources";
            this.edtResources.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtResources.Properties.Buttons"))))});
            // 
            // 
            // 
            this.edtResources.ResourcesCheckedListBoxControl.CheckOnClick = true;
            this.edtResources.ResourcesCheckedListBoxControl.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Dock")));
            this.edtResources.ResourcesCheckedListBoxControl.Location = ((System.Drawing.Point)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Location")));
            this.edtResources.ResourcesCheckedListBoxControl.Name = "";
            this.edtResources.ResourcesCheckedListBoxControl.Size = ((System.Drawing.Size)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.Size")));
            this.edtResources.ResourcesCheckedListBoxControl.TabIndex = ((int)(resources.GetObject("edtResources.ResourcesCheckedListBoxControl.TabIndex")));
            // 
            // cbReminder
            // 
            resources.ApplyResources(this.cbReminder, "cbReminder");
            this.cbReminder.Name = "cbReminder";
            this.cbReminder.Properties.AccessibleName = resources.GetString("cbReminder.Properties.AccessibleName");
            this.cbReminder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("cbReminder.Properties.Buttons"))))});
            this.cbReminder.Properties.DisabledStateText = "";
            this.cbReminder.Properties.ShowEmptyItem = false;
            // 
            // edtLabel
            // 
            resources.ApplyResources(this.edtLabel, "edtLabel");
            this.edtLabel.Name = "edtLabel";
            this.edtLabel.Properties.AccessibleName = resources.GetString("edtLabel.Properties.AccessibleName");
            this.edtLabel.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtLabel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtLabel.Properties.Buttons"))))});
            // 
            // edtStartTime
            // 
            resources.ApplyResources(this.edtStartTime, "edtStartTime");
            this.edtStartTime.Name = "edtStartTime";
            this.edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            this.edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // edtEndTime
            // 
            resources.ApplyResources(this.edtEndTime, "edtEndTime");
            this.edtEndTime.Name = "edtEndTime";
            this.edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            this.edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtEmployess);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.cbStatus);
            this.panel4.Controls.Add(this.btnDoHang);
            this.panel4.Controls.Add(this.btnPrint);
            this.panel4.Controls.Add(this.btnLayHang);
            this.panel4.Controls.Add(this.txtNote);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // txtEmployess
            // 
            resources.ApplyResources(this.txtEmployess, "txtEmployess");
            this.txtEmployess.Name = "txtEmployess";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cbStatus
            // 
            resources.ApplyResources(this.cbStatus, "cbStatus");
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Name = "cbStatus";
            // 
            // btnDoHang
            // 
            this.btnDoHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDoHang.ImageOptions.Image")));
            resources.ApplyResources(this.btnDoHang, "btnDoHang");
            this.btnDoHang.Name = "btnDoHang";
            this.btnDoHang.Click += new System.EventHandler(this.btnDoHang_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnLayHang
            // 
            this.btnLayHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLayHang.ImageOptions.Image")));
            resources.ApplyResources(this.btnLayHang, "btnLayHang");
            this.btnLayHang.Name = "btnLayHang";
            this.btnLayHang.Click += new System.EventHandler(this.btnLayHang_Click);
            // 
            // txtNote
            // 
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            // 
            // btnEditQuantity
            // 
            this.btnEditQuantity.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEditQuantity.ImageOptions.Image")));
            resources.ApplyResources(this.btnEditQuantity, "btnEditQuantity");
            this.btnEditQuantity.Name = "btnEditQuantity";
            this.btnEditQuantity.Click += new System.EventHandler(this.btnEditQuantity_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.nudQuantity);
            this.panel3.Controls.Add(this.btnEditQuantity);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nudQuantity
            // 
            resources.ApplyResources(this.nudQuantity, "nudQuantity");
            this.nudQuantity.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            -2147483648});
            this.nudQuantity.Name = "nudQuantity";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.btnSaveEnd);
            this.panel5.Controls.Add(this.txtEmployessPro);
            this.panel5.Controls.Add(this.btnEndGame);
            resources.ApplyResources(this.panel5, "panel5");
            this.panel5.Name = "panel5";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // btnSaveEnd
            // 
            resources.ApplyResources(this.btnSaveEnd, "btnSaveEnd");
            this.btnSaveEnd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveEnd.ImageOptions.Image")));
            this.btnSaveEnd.Name = "btnSaveEnd";
            this.btnSaveEnd.Click += new System.EventHandler(this.btnSaveEnd_Click);
            // 
            // txtEmployessPro
            // 
            resources.ApplyResources(this.txtEmployessPro, "txtEmployessPro");
            this.txtEmployessPro.Name = "txtEmployessPro";
            // 
            // btnEndGame
            // 
            this.btnEndGame.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEndGame.ImageOptions.Image")));
            resources.ApplyResources(this.btnEndGame, "btnEndGame");
            this.btnEndGame.Name = "btnEndGame";
            this.btnEndGame.Click += new System.EventHandler(this.btnEndGame_Click);
            // 
            // CustomAppointmentForm
            // 
            this.AcceptButton = this.btnOk;
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.edtStartTime);
            this.Controls.Add(this.edtStartDate);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblStartTime);
            this.Controls.Add(this.tbSubject);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSubject);
            this.Controls.Add(this.tbLocation);
            this.Controls.Add(this.lblEndTime);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.edtEndDate);
            this.Controls.Add(this.edtEndTime);
            this.Name = "CustomAppointmentForm";
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.OnAppointmentFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CustomAppointmentForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLocation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResources.ResourcesCheckedListBoxControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLabel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNote.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        protected DevExpress.XtraEditors.LabelControl lblSubject;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblLabel;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.SimpleButton btnOk;
        protected DevExpress.XtraEditors.SimpleButton btnCancel;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TimeEdit edtStartTime;
        protected DevExpress.XtraEditors.TimeEdit edtEndTime;
        protected DevExpress.XtraScheduler.UI.AppointmentLabelEdit edtLabel;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected DevExpress.XtraScheduler.UI.AppointmentResourceEdit edtResource;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected DevExpress.XtraScheduler.UI.AppointmentResourcesEdit edtResources;
        protected DevExpress.XtraScheduler.UI.DurationEdit cbReminder;
        private System.ComponentModel.IContainer components = null;
        protected DevExpress.XtraEditors.TextEdit tbLocation;
        protected DevExpress.XtraEditors.PanelControl panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbStatus;
        private DevExpress.XtraEditors.SimpleButton btnDoHang;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnLayHang;
        private DevExpress.XtraEditors.MemoEdit txtNote;
        private System.Windows.Forms.TextBox txtEmployess;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnEditQuantity;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnSaveEnd;
        private System.Windows.Forms.TextBox txtEmployessPro;
        private DevExpress.XtraEditors.SimpleButton btnEndGame;
    }
}