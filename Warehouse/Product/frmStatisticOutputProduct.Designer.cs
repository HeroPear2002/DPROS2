namespace WareHouse.Product
{
    partial class frmStatisticOutputProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStatisticOutputProduct));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.GCData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnOutput = new DevExpress.XtraEditors.SimpleButton();
            this.dtpkDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpkDate1 = new System.Windows.Forms.DateTimePicker();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.cbCode = new System.Windows.Forms.ComboBox();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GCData);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Controls.Add(this.btnOutput);
            this.layoutControl1.Controls.Add(this.dtpkDate2);
            this.layoutControl1.Controls.Add(this.dtpkDate1);
            this.layoutControl1.Controls.Add(this.txtCount);
            this.layoutControl1.Controls.Add(this.cbCode);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1088, 452, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1040, 660);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // GCData
            // 
            this.GCData.Location = new System.Drawing.Point(12, 150);
            this.GCData.MainView = this.gridView1;
            this.GCData.Name = "GCData";
            this.GCData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.GCData.Size = new System.Drawing.Size(1016, 498);
            this.GCData.TabIndex = 10;
            this.GCData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.GCData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Mã L/K";
            this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn1.FieldName = "ProductCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Ngày nhập";
            this.gridColumn2.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn2.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn2.FieldName = "DateInput";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Ngày xuất";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn3.FieldName = "DateOutput";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Số lượng xuất";
            this.gridColumn4.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn4.FieldName = "CountOut";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Người xuất";
            this.gridColumn5.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn5.FieldName = "Employess";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            // 
            // btnView
            // 
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.Location = new System.Drawing.Point(771, 112);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(105, 22);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 9;
            this.btnView.Text = "Xem";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.ImageOptions.Image")));
            this.btnOutput.Location = new System.Drawing.Point(771, 43);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(103, 22);
            this.btnOutput.StyleController = this.layoutControl1;
            this.btnOutput.TabIndex = 8;
            this.btnOutput.Text = "Xuất Kho";
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // dtpkDate2
            // 
            this.dtpkDate2.CustomFormat = "dd/MM/yyyy";
            this.dtpkDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkDate2.Location = new System.Drawing.Point(491, 112);
            this.dtpkDate2.Name = "dtpkDate2";
            this.dtpkDate2.Size = new System.Drawing.Size(276, 21);
            this.dtpkDate2.TabIndex = 7;
            // 
            // dtpkDate1
            // 
            this.dtpkDate1.CustomFormat = "dd/MM/yyyy";
            this.dtpkDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkDate1.Location = new System.Drawing.Point(109, 112);
            this.dtpkDate1.Name = "dtpkDate1";
            this.dtpkDate1.Size = new System.Drawing.Size(293, 21);
            this.dtpkDate1.TabIndex = 6;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(489, 43);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(278, 20);
            this.txtCount.TabIndex = 5;
            // 
            // cbCode
            // 
            this.cbCode.FormattingEnabled = true;
            this.cbCode.Location = new System.Drawing.Point(109, 43);
            this.cbCode.Name = "cbCode";
            this.cbCode.Size = new System.Drawing.Size(291, 21);
            this.cbCode.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup1,
            this.layoutControlGroup2,
            this.layoutControlItem7});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1040, 660);
            this.Root.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem2,
            this.layoutControlItem5});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1020, 69);
            this.layoutControlGroup1.Text = "Xuất kho";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.cbCode;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem1.Size = new System.Drawing.Size(380, 26);
            this.layoutControlItem1.Text = "Mã L/K :";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.txtCount;
            this.layoutControlItem2.Location = new System.Drawing.Point(380, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem2.Size = new System.Drawing.Size(367, 26);
            this.layoutControlItem2.Text = "Số lượng xuất :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(74, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(854, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(142, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOutput;
            this.layoutControlItem5.Location = new System.Drawing.Point(747, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(107, 26);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem3,
            this.layoutControlItem4,
            this.layoutControlItem3,
            this.layoutControlItem6});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 69);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Size = new System.Drawing.Size(1020, 69);
            this.layoutControlGroup2.Text = "Xem thông tin ";
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(856, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(140, 26);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dtpkDate2;
            this.layoutControlItem4.Location = new System.Drawing.Point(382, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem4.Size = new System.Drawing.Size(365, 26);
            this.layoutControlItem4.Text = "Đến ngày :";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dtpkDate1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2);
            this.layoutControlItem3.Size = new System.Drawing.Size(382, 26);
            this.layoutControlItem3.Text = "Từ ngày :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(74, 13);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.btnView;
            this.layoutControlItem6.Location = new System.Drawing.Point(747, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(109, 26);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.GCData;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 138);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(1020, 502);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // frmStatisticOutputProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 660);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmStatisticOutputProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông kê Xuất";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraGrid.GridControl GCData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraEditors.SimpleButton btnOutput;
        private System.Windows.Forms.DateTimePicker dtpkDate2;
        private System.Windows.Forms.DateTimePicker dtpkDate1;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ComboBox cbCode;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
    }
}