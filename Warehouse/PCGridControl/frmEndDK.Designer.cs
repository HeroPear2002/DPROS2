namespace WareHouse.PCGridControl
{
    partial class frmEndDK
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndDK));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.GCData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbMold = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel7);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 307);
            this.panel1.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.GCData);
            this.panel7.Location = new System.Drawing.Point(6, 126);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(870, 168);
            this.panel7.TabIndex = 5;
            // 
            // GCData
            // 
            this.GCData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCData.Location = new System.Drawing.Point(0, 0);
            this.GCData.MainView = this.gridView1;
            this.GCData.Name = "GCData";
            this.GCData.Size = new System.Drawing.Size(870, 168);
            this.GCData.TabIndex = 0;
            this.GCData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.GCData.Click += new System.EventHandler(this.GCData_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.gridView1.GridControl = this.GCData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
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
            this.gridColumn1.Caption = "Mã linh kiện";
            this.gridColumn1.FieldName = "PartCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 109;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Số khuôn";
            this.gridColumn2.FieldName = "MoldNumber";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 77;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Mã máy";
            this.gridColumn3.FieldName = "MachineCode";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 77;
            // 
            // gridColumn4
            // 
            this.gridColumn4.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceCell.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn4.AppearanceHeader.Options.UseFont = true;
            this.gridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn4.Caption = "Bắt đầu";
            this.gridColumn4.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn4.FieldName = "StartTime";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 213;
            // 
            // gridColumn5
            // 
            this.gridColumn5.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceCell.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn5.AppearanceHeader.Options.UseFont = true;
            this.gridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn5.Caption = "Kết thúc";
            this.gridColumn5.DisplayFormat.FormatString = "dd/MM/yyyy HH:mm";
            this.gridColumn5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumn5.FieldName = "EndTime";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 218;
            // 
            // gridColumn6
            // 
            this.gridColumn6.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceCell.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn6.AppearanceHeader.Options.UseFont = true;
            this.gridColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn6.Caption = "ID";
            this.gridColumn6.FieldName = "Id";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 80;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtId);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(444, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(432, 34);
            this.panel5.TabIndex = 0;
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(83, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(346, 26);
            this.txtId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(3, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "ID :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cbMold);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(444, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(432, 34);
            this.panel4.TabIndex = 1;
            // 
            // cbMold
            // 
            this.cbMold.FormattingEnabled = true;
            this.cbMold.Location = new System.Drawing.Point(83, 3);
            this.cbMold.Name = "cbMold";
            this.cbMold.Size = new System.Drawing.Size(346, 27);
            this.cbMold.TabIndex = 1;
            this.cbMold.SelectedIndexChanged += new System.EventHandler(this.cbMold_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số khuôn :";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.btnSave);
            this.panel6.Controls.Add(this.btnDelete);
            this.panel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(6, 86);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(870, 34);
            this.panel6.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(354, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 31);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(438, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 31);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Hủy";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbMachine);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(6, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(432, 34);
            this.panel3.TabIndex = 2;
            // 
            // cbMachine
            // 
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(83, 3);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(346, 27);
            this.cbMachine.TabIndex = 2;
            this.cbMachine.SelectedIndexChanged += new System.EventHandler(this.cbMachine_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã máy :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbPart);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 34);
            this.panel2.TabIndex = 0;
            // 
            // cbPart
            // 
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Location = new System.Drawing.Point(112, 3);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(317, 27);
            this.cbPart.TabIndex = 0;
            this.cbPart.SelectedIndexChanged += new System.EventHandler(this.cbPart_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã linh kiện :";
            // 
            // frmEndDK
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 315);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEndDK";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Xác nhận đo hàng";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEndDK_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ComboBox cbMold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel6;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbMachine;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private DevExpress.XtraGrid.GridControl GCData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
    }
}