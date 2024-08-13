namespace WareHouse.QRCodeMaterial
{
    partial class frmReceiptSlip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReceiptSlip));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnDetail = new DevExpress.XtraEditors.SimpleButton();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.dtpkTo = new System.Windows.Forms.DateTimePicker();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.GCData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnPrinter = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnConfirm);
            this.layoutControl1.Controls.Add(this.btnDetail);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Controls.Add(this.dtpkTo);
            this.layoutControl1.Controls.Add(this.dtpkFrom);
            this.layoutControl1.Controls.Add(this.GCData);
            this.layoutControl1.Controls.Add(this.btnUpdate);
            this.layoutControl1.Controls.Add(this.btnPrinter);
            this.layoutControl1.Controls.Add(this.btnDelete);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(2898, 294, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1214, 599);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnDetail
            // 
            this.btnDetail.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.ImageOptions.Image")));
            this.btnDetail.Location = new System.Drawing.Point(313, 38);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(110, 22);
            this.btnDetail.StyleController = this.layoutControl1;
            this.btnDetail.TabIndex = 9;
            this.btnDetail.Text = "Xem chi tiết phiếu";
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnView
            // 
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.Location = new System.Drawing.Point(547, 12);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(84, 22);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 8;
            this.btnView.Text = "Xem";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // dtpkTo
            // 
            this.dtpkTo.CustomFormat = "dd/MM/yyyy";
            this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkTo.Location = new System.Drawing.Point(341, 12);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Size = new System.Drawing.Size(202, 21);
            this.dtpkTo.TabIndex = 7;
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFrom.Location = new System.Drawing.Point(69, 12);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(211, 21);
            this.dtpkFrom.TabIndex = 6;
            // 
            // GCData
            // 
            this.GCData.Location = new System.Drawing.Point(12, 64);
            this.GCData.MainView = this.gridView1;
            this.GCData.Name = "GCData";
            this.GCData.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.GCData.Size = new System.Drawing.Size(1190, 523);
            this.GCData.TabIndex = 5;
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
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.GCData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
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
            this.gridColumn1.Caption = "ID";
            this.gridColumn1.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
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
            this.gridColumn2.Caption = "IdDetail";
            this.gridColumn2.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn2.FieldName = "IdDetail";
            this.gridColumn2.Name = "gridColumn2";
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Mã phiếu";
            this.gridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn3.FieldName = "ReceiptCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 118;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Ngày nhận";
            this.gridColumn4.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "DatePrinter";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 135;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "Người nhận";
            this.gridColumn7.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn7.FieldName = "Employess";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 106;
            // 
            // gridColumn8
            // 
            this.gridColumn8.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceCell.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn8.AppearanceHeader.Options.UseFont = true;
            this.gridColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn8.Caption = "Ghi chú";
            this.gridColumn8.ColumnEdit = this.repositoryItemMemoEdit1;
            this.gridColumn8.FieldName = "Note";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 116;
            // 
            // btnUpdate
            // 
            this.btnUpdate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.ImageOptions.Image")));
            this.btnUpdate.Location = new System.Drawing.Point(216, 38);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 22);
            this.btnUpdate.StyleController = this.layoutControl1;
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnPrinter
            // 
            this.btnPrinter.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrinter.ImageOptions.Image")));
            this.btnPrinter.Location = new System.Drawing.Point(114, 38);
            this.btnPrinter.Name = "btnPrinter";
            this.btnPrinter.Size = new System.Drawing.Size(98, 22);
            this.btnPrinter.StyleController = this.layoutControl1;
            this.btnPrinter.TabIndex = 4;
            this.btnPrinter.Text = "In phiếu";
            this.btnPrinter.Click += new System.EventHandler(this.btnPrinter_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(12, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(98, 22);
            this.btnDelete.StyleController = this.layoutControl1;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem9});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1214, 599);
            this.Root.TextVisible = false;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(493, 26);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(701, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnDelete;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(102, 26);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnPrinter;
            this.layoutControlItem2.Location = new System.Drawing.Point(102, 26);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(102, 26);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnUpdate;
            this.layoutControlItem3.Location = new System.Drawing.Point(204, 26);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(97, 26);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.GCData;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 52);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1194, 527);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.dtpkFrom;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(272, 26);
            this.layoutControlItem5.Text = "Từ ngày :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(54, 13);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(623, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(571, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.dtpkTo;
            this.layoutControlItem6.Location = new System.Drawing.Point(272, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(263, 26);
            this.layoutControlItem6.Text = "Đến ngày :";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(54, 13);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnView;
            this.layoutControlItem7.Location = new System.Drawing.Point(535, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(88, 26);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.btnDetail;
            this.layoutControlItem8.Location = new System.Drawing.Point(301, 26);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(114, 26);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // btnConfirm
            // 
            this.btnConfirm.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btnConfirm.Location = new System.Drawing.Point(427, 38);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(74, 22);
            this.btnConfirm.StyleController = this.layoutControl1;
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "Xác nhận";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.btnConfirm;
            this.layoutControlItem9.Location = new System.Drawing.Point(415, 26);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(78, 26);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // frmReceiptSlip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 599);
            this.Controls.Add(this.layoutControl1);
            this.Name = "frmReceiptSlip";
            this.Text = "DANH SÁCH PHIẾU NHẬN NHỰA";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraGrid.GridControl GCData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnPrinter;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraEditors.SimpleButton btnDetail;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
    }
}