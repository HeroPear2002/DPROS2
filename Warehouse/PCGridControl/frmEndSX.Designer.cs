namespace WareHouse.PCGridControl
{
    partial class frmEndSX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEndSX));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GCData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panel8 = new System.Windows.Forms.Panel();
            this.txtPartCode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.dtpkEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.dtpkStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txtMachine = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.txtEmployess = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtMoldNumber = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(995, 310);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GCData);
            this.panel2.Location = new System.Drawing.Point(4, 150);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(988, 151);
            this.panel2.TabIndex = 2;
            // 
            // GCData
            // 
            this.GCData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GCData.Location = new System.Drawing.Point(0, 0);
            this.GCData.MainView = this.gridView1;
            this.GCData.Name = "GCData";
            this.GCData.Size = new System.Drawing.Size(988, 151);
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
            this.gridColumn6,
            this.gridColumn7});
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
            this.gridColumn1.Caption = "Mã máy";
            this.gridColumn1.FieldName = "MachineCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 74;
            // 
            // gridColumn2
            // 
            this.gridColumn2.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceCell.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn2.AppearanceHeader.Options.UseFont = true;
            this.gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn2.Caption = "Mã linh kiện";
            this.gridColumn2.FieldName = "PartCode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 146;
            // 
            // gridColumn3
            // 
            this.gridColumn3.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceCell.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn3.AppearanceHeader.Options.UseFont = true;
            this.gridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn3.Caption = "Số khuôn";
            this.gridColumn3.FieldName = "MoldNumber";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 3;
            this.gridColumn3.Width = 70;
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
            this.gridColumn4.Width = 208;
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
            this.gridColumn6.Caption = "Số lượng";
            this.gridColumn6.FieldName = "Quantity";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 94;
            // 
            // gridColumn7
            // 
            this.gridColumn7.AppearanceCell.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceCell.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn7.AppearanceHeader.Options.UseFont = true;
            this.gridColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn7.Caption = "ID";
            this.gridColumn7.FieldName = "Id";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 7;
            this.gridColumn7.Width = 82;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.panel8);
            this.panel3.Controls.Add(this.panel10);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.panel9);
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.panel12);
            this.panel3.Controls.Add(this.panel11);
            this.panel3.Controls.Add(this.panel7);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(902, 145);
            this.panel3.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.Location = new System.Drawing.Point(644, 56);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 28);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Hủy";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.txtPartCode);
            this.panel8.Controls.Add(this.label6);
            this.panel8.Enabled = false;
            this.panel8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(315, 70);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(300, 28);
            this.panel8.TabIndex = 0;
            // 
            // txtPartCode
            // 
            this.txtPartCode.Location = new System.Drawing.Point(109, 1);
            this.txtPartCode.Name = "txtPartCode";
            this.txtPartCode.Size = new System.Drawing.Size(188, 26);
            this.txtPartCode.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "Mã linh kiện :";
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.dtpkEnd);
            this.panel10.Controls.Add(this.label8);
            this.panel10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel10.Location = new System.Drawing.Point(315, 103);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(300, 28);
            this.panel10.TabIndex = 0;
            // 
            // dtpkEnd
            // 
            this.dtpkEnd.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpkEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkEnd.Location = new System.Drawing.Point(109, 1);
            this.dtpkEnd.Name = "dtpkEnd";
            this.dtpkEnd.Size = new System.Drawing.Size(188, 26);
            this.dtpkEnd.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 19);
            this.label8.TabIndex = 0;
            this.label8.Text = "Kết thúc :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Enabled = false;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(644, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.dtpkStart);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Enabled = false;
            this.panel9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(3, 104);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(303, 28);
            this.panel9.TabIndex = 0;
            // 
            // dtpkStart
            // 
            this.dtpkStart.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpkStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkStart.Location = new System.Drawing.Point(75, 1);
            this.dtpkStart.Name = "dtpkStart";
            this.dtpkStart.Size = new System.Drawing.Size(225, 26);
            this.dtpkStart.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 19);
            this.label7.TabIndex = 0;
            this.label7.Text = "Bắt đầu :";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txtMachine);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Enabled = false;
            this.panel6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(3, 70);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(303, 28);
            this.panel6.TabIndex = 0;
            // 
            // txtMachine
            // 
            this.txtMachine.Location = new System.Drawing.Point(75, 1);
            this.txtMachine.Name = "txtMachine";
            this.txtMachine.Size = new System.Drawing.Size(225, 26);
            this.txtMachine.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã máy :";
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.txtEmployess);
            this.panel12.Controls.Add(this.label9);
            this.panel12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel12.Location = new System.Drawing.Point(315, 2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(300, 28);
            this.panel12.TabIndex = 0;
            // 
            // txtEmployess
            // 
            this.txtEmployess.Location = new System.Drawing.Point(109, 2);
            this.txtEmployess.Name = "txtEmployess";
            this.txtEmployess.Size = new System.Drawing.Size(188, 26);
            this.txtEmployess.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 19);
            this.label9.TabIndex = 0;
            this.label9.Text = "Mã nhân viên :";
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.txtID);
            this.panel11.Controls.Add(this.label1);
            this.panel11.Enabled = false;
            this.panel11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel11.Location = new System.Drawing.Point(644, 104);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(240, 28);
            this.panel11.TabIndex = 0;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 1);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(188, 26);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID :";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.txtMoldNumber);
            this.panel7.Controls.Add(this.label5);
            this.panel7.Enabled = false;
            this.panel7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel7.Location = new System.Drawing.Point(315, 36);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(300, 28);
            this.panel7.TabIndex = 0;
            // 
            // txtMoldNumber
            // 
            this.txtMoldNumber.Location = new System.Drawing.Point(109, 2);
            this.txtMoldNumber.Name = "txtMoldNumber";
            this.txtMoldNumber.Size = new System.Drawing.Size(188, 26);
            this.txtMoldNumber.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Số khuôn :";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.nudQuantity);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Enabled = false;
            this.panel5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 36);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(303, 28);
            this.panel5.TabIndex = 1;
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(75, 2);
            this.nudQuantity.Maximum = new decimal(new int[] {
            -727379968,
            232,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(225, 26);
            this.nudQuantity.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Số lượng :";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txtBarCode);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(303, 28);
            this.panel4.TabIndex = 0;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Location = new System.Drawing.Point(75, 1);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(225, 26);
            this.txtBarCode.TabIndex = 0;
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã vạch :";
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmEndSX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 334);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEndSX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kết thúc sản xuất";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEndSX_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel12.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl GCData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TextBox txtPartCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.DateTimePicker dtpkEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.DateTimePicker dtpkStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtMachine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox txtMoldNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.TextBox txtEmployess;
        private System.Windows.Forms.Label label9;
    }
}