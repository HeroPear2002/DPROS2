namespace WareHouse.EBox
{
    partial class frmReBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReBox));
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxCode1 = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxCode1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 55);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã Thùng :";
            // 
            // txtBoxCode1
            // 
            this.txtBoxCode1.Location = new System.Drawing.Point(264, 72);
            this.txtBoxCode1.Name = "txtBoxCode1";
            this.txtBoxCode1.Properties.Appearance.Font = new System.Drawing.Font("Times New Roman", 36F);
            this.txtBoxCode1.Properties.Appearance.Options.UseFont = true;
            this.txtBoxCode1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txtBoxCode1.Size = new System.Drawing.Size(621, 62);
            this.txtBoxCode1.TabIndex = 4;
            this.txtBoxCode1.EditValueChanged += new System.EventHandler(this.txtBoxCode1_EditValueChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmReBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 241);
            this.Controls.Add(this.txtBoxCode1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thùng Về Kho";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReBox_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.txtBoxCode1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit txtBoxCode1;
        private System.Windows.Forms.Timer timer1;
    }
}