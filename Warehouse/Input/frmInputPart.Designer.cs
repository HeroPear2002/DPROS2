namespace WareHouse.Input
{
    partial class frmInputPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInputPart));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblU = new System.Windows.Forms.Label();
            this.btnHU = new DevExpress.XtraEditors.SimpleButton();
            this.lblNote = new System.Windows.Forms.Label();
            this.btnAddPCS = new DevExpress.XtraEditors.SimpleButton();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.cbMold = new System.Windows.Forms.ComboBox();
            this.cbFactoryCode = new System.Windows.Forms.ComboBox();
            this.cbMachine = new System.Windows.Forms.ComboBox();
            this.cbPart = new System.Windows.Forms.ComboBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lblU);
            this.panel1.Controls.Add(this.btnHU);
            this.panel1.Controls.Add(this.lblNote);
            this.panel1.Controls.Add(this.btnAddPCS);
            this.panel1.Controls.Add(this.nudQuantity);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtpDate);
            this.panel1.Controls.Add(this.txtBarCode);
            this.panel1.Controls.Add(this.cbName);
            this.panel1.Controls.Add(this.cbMold);
            this.panel1.Controls.Add(this.cbFactoryCode);
            this.panel1.Controls.Add(this.cbMachine);
            this.panel1.Controls.Add(this.cbPart);
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(513, 521);
            this.panel1.TabIndex = 0;
            // 
            // lblU
            // 
            this.lblU.AutoSize = true;
            this.lblU.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblU.ForeColor = System.Drawing.Color.Yellow;
            this.lblU.Location = new System.Drawing.Point(152, 335);
            this.lblU.Name = "lblU";
            this.lblU.Size = new System.Drawing.Size(204, 19);
            this.lblU.TabIndex = 50;
            this.lblU.Text = "Click vào nếu đây là Hàng Ùn";
            // 
            // btnHU
            // 
            this.btnHU.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHU.Appearance.Options.UseFont = true;
            this.btnHU.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnHU.ImageOptions.Image")));
            this.btnHU.Location = new System.Drawing.Point(23, 325);
            this.btnHU.Name = "btnHU";
            this.btnHU.Size = new System.Drawing.Size(123, 38);
            this.btnHU.TabIndex = 49;
            this.btnHU.Text = "Hàng Ùn";
            this.btnHU.Click += new System.EventHandler(this.btnHU_Click);
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.ForeColor = System.Drawing.Color.Red;
            this.lblNote.Location = new System.Drawing.Point(36, 389);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(0, 19);
            this.lblNote.TabIndex = 48;
            // 
            // btnAddPCS
            // 
            this.btnAddPCS.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPCS.Appearance.Options.UseFont = true;
            this.btnAddPCS.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPCS.ImageOptions.Image")));
            this.btnAddPCS.Location = new System.Drawing.Point(326, 10);
            this.btnAddPCS.Name = "btnAddPCS";
            this.btnAddPCS.Size = new System.Drawing.Size(166, 43);
            this.btnAddPCS.TabIndex = 47;
            this.btnAddPCS.Text = "Nhập Số Hộp";
            this.btnAddPCS.Click += new System.EventHandler(this.btnAddPCS_Click);
            // 
            // nudQuantity
            // 
            this.nudQuantity.Enabled = false;
            this.nudQuantity.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudQuantity.Location = new System.Drawing.Point(143, 236);
            this.nudQuantity.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(349, 29);
            this.nudQuantity.TabIndex = 36;
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Location = new System.Drawing.Point(162, 464);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 38);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Lưu";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 19);
            this.label4.TabIndex = 39;
            this.label4.Text = "Số Lượng  :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 19);
            this.label3.TabIndex = 40;
            this.label3.Text = "Ngày Sản Xuất :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(19, 285);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 19);
            this.label5.TabIndex = 41;
            this.label5.Text = "Vị Trí :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 19);
            this.label6.TabIndex = 41;
            this.label6.Text = "Mã Khuôn :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(287, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 19);
            this.label8.TabIndex = 42;
            this.label8.Text = "Mã Nhà Máy :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(19, 142);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 42;
            this.label7.Text = "Số Máy :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 19);
            this.label2.TabIndex = 43;
            this.label2.Text = "Mã Linh Kiện :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 19);
            this.label1.TabIndex = 44;
            this.label1.Text = "Mã Vạch :";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dtpDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(143, 201);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(349, 29);
            this.dtpDate.TabIndex = 35;
            // 
            // txtBarCode
            // 
            this.txtBarCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.Location = new System.Drawing.Point(143, 62);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(349, 29);
            this.txtBarCode.TabIndex = 1;
            this.txtBarCode.TextChanged += new System.EventHandler(this.txtBarCode_TextChanged);
            // 
            // cbName
            // 
            this.cbName.Enabled = false;
            this.cbName.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(143, 274);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(349, 30);
            this.cbName.TabIndex = 32;
            // 
            // cbMold
            // 
            this.cbMold.Enabled = false;
            this.cbMold.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMold.FormattingEnabled = true;
            this.cbMold.Location = new System.Drawing.Point(143, 166);
            this.cbMold.Name = "cbMold";
            this.cbMold.Size = new System.Drawing.Size(349, 30);
            this.cbMold.TabIndex = 32;
            // 
            // cbFactoryCode
            // 
            this.cbFactoryCode.Enabled = false;
            this.cbFactoryCode.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFactoryCode.FormattingEnabled = true;
            this.cbFactoryCode.Location = new System.Drawing.Point(400, 131);
            this.cbFactoryCode.Name = "cbFactoryCode";
            this.cbFactoryCode.Size = new System.Drawing.Size(92, 30);
            this.cbFactoryCode.TabIndex = 33;
            // 
            // cbMachine
            // 
            this.cbMachine.Enabled = false;
            this.cbMachine.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMachine.FormattingEnabled = true;
            this.cbMachine.Location = new System.Drawing.Point(143, 131);
            this.cbMachine.Name = "cbMachine";
            this.cbMachine.Size = new System.Drawing.Size(134, 30);
            this.cbMachine.TabIndex = 33;
            // 
            // cbPart
            // 
            this.cbPart.Enabled = false;
            this.cbPart.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPart.FormattingEnabled = true;
            this.cbPart.Location = new System.Drawing.Point(143, 96);
            this.cbPart.Name = "cbPart";
            this.cbPart.Size = new System.Drawing.Size(349, 30);
            this.cbPart.TabIndex = 34;
            this.cbPart.TextChanged += new System.EventHandler(this.cbPart_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmInputPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 530);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmInputPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập Kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInputPart_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtBarCode;
        private System.Windows.Forms.ComboBox cbMold;
        private System.Windows.Forms.ComboBox cbMachine;
        private System.Windows.Forms.ComboBox cbPart;
        private System.Windows.Forms.Label lblNote;
        private DevExpress.XtraEditors.SimpleButton btnAddPCS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label lblU;
        private DevExpress.XtraEditors.SimpleButton btnHU;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbFactoryCode;
    }
}