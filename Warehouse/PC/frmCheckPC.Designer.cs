namespace WareHouse.PC
{
    partial class frmCheckPC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckPC));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnSaveStatus = new DevExpress.XtraEditors.SimpleButton();
            this.GCData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gcPartCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gcDateImport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcStock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem4 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnSaveStatus);
            this.layoutControl1.Controls.Add(this.GCData);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1205, 353, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1150, 561);
            this.layoutControl1.TabIndex = 8;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnSaveStatus
            // 
            this.btnSaveStatus.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveStatus.Appearance.Options.UseFont = true;
            this.btnSaveStatus.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveStatus.ImageOptions.Image")));
            this.btnSaveStatus.Location = new System.Drawing.Point(347, 12);
            this.btnSaveStatus.Name = "btnSaveStatus";
            this.btnSaveStatus.Size = new System.Drawing.Size(82, 24);
            this.btnSaveStatus.StyleController = this.layoutControl1;
            this.btnSaveStatus.TabIndex = 6;
            this.btnSaveStatus.Text = "Mở khóa";
            this.btnSaveStatus.Click += new System.EventHandler(this.btnSaveStatus_Click);
            // 
            // GCData
            // 
            this.GCData.Location = new System.Drawing.Point(12, 40);
            this.GCData.MainView = this.gridView1;
            this.GCData.Name = "GCData";
            this.GCData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2});
            this.GCData.Size = new System.Drawing.Size(1126, 509);
            this.GCData.TabIndex = 4;
            this.GCData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCData.Click += new System.EventHandler(this.GCData_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gcPartCode,
            this.gcDateImport,
            this.gcStock,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn8,
            this.gridColumn6,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView1.GridControl = this.GCData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gcPartCode
            // 
            this.gcPartCode.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gcPartCode.AppearanceCell.Options.UseFont = true;
            this.gcPartCode.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gcPartCode.AppearanceHeader.Options.UseFont = true;
            this.gcPartCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gcPartCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcPartCode.Caption = "Mã linh kiện";
            this.gcPartCode.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcPartCode.FieldName = "PartCode";
            this.gcPartCode.Name = "gcPartCode";
            this.gcPartCode.Visible = true;
            this.gcPartCode.VisibleIndex = 1;
            this.gcPartCode.Width = 88;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // gcDateImport
            // 
            this.gcDateImport.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gcDateImport.AppearanceCell.Options.UseFont = true;
            this.gcDateImport.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gcDateImport.AppearanceHeader.Options.UseFont = true;
            this.gcDateImport.AppearanceHeader.Options.UseTextOptions = true;
            this.gcDateImport.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcDateImport.Caption = "Ngày nhập";
            this.gcDateImport.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcDateImport.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gcDateImport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gcDateImport.FieldName = "DateInput";
            this.gcDateImport.Name = "gcDateImport";
            this.gcDateImport.Visible = true;
            this.gcDateImport.VisibleIndex = 3;
            this.gcDateImport.Width = 115;
            // 
            // gcStock
            // 
            this.gcStock.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gcStock.AppearanceCell.Options.UseFont = true;
            this.gcStock.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gcStock.AppearanceHeader.Options.UseFont = true;
            this.gcStock.AppearanceHeader.Options.UseTextOptions = true;
            this.gcStock.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gcStock.Caption = "Số lượng tồn";
            this.gcStock.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gcStock.FieldName = "Iventory";
            this.gcStock.Name = "gcStock";
            this.gcStock.Visible = true;
            this.gcStock.VisibleIndex = 4;
            this.gcStock.Width = 83;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Số khuôn";
            this.gridColumn4.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn4.FieldName = "MoldNumber";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 6;
            this.gridColumn4.Width = 65;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Số máy";
            this.gridColumn5.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn5.FieldName = "MachineCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 7;
            this.gridColumn5.Width = 65;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Lot/No";
            this.gridColumn8.ColumnEdit = this.repositoryItemMemoEdit2;
            this.gridColumn8.FieldName = "Lot";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "Vị trí";
            this.gridColumn6.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn6.FieldName = "Name";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 9;
            this.gridColumn6.Width = 76;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gridColumn1.AppearanceCell.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "Ngày Sản Xuất";
            this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn1.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm:ss";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn1.FieldName = "DateManufacturi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 125;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Trạng Thái";
            this.gridColumn2.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn2.FieldName = "NameStatus";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 8;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.emptySpaceItem4,
            this.emptySpaceItem3,
            this.layoutControlItem3});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1150, 561);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GCData;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 28);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1130, 513);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // emptySpaceItem4
            // 
            this.emptySpaceItem4.AllowHotTrack = false;
            this.emptySpaceItem4.Location = new System.Drawing.Point(421, 0);
            this.emptySpaceItem4.Name = "emptySpaceItem4";
            this.emptySpaceItem4.Size = new System.Drawing.Size(709, 28);
            this.emptySpaceItem4.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem3
            // 
            this.emptySpaceItem3.AllowHotTrack = false;
            this.emptySpaceItem3.Location = new System.Drawing.Point(0, 0);
            this.emptySpaceItem3.Name = "emptySpaceItem3";
            this.emptySpaceItem3.Size = new System.Drawing.Size(335, 28);
            this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnSaveStatus;
            this.layoutControlItem3.Location = new System.Drawing.Point(335, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(86, 28);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // frmCheckPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 561);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckPC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Tồn Kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckPC_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl GCData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcPartCode;
        private DevExpress.XtraGrid.Columns.GridColumn gcDateImport;
        private DevExpress.XtraGrid.Columns.GridColumn gcStock;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.SimpleButton btnSaveStatus;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
    }
}