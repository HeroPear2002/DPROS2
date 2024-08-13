namespace WareHouse.PC
{
    partial class frmProgress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProgress));
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseFont = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Caption = "Hệ thống đang tải ! ";
            this.progressPanel1.Description = "Xin vui lòng chờ trong ít phút (^_^)";
            this.progressPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel1.Location = new System.Drawing.Point(0, 0);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.progressPanel1.Size = new System.Drawing.Size(329, 151);
            this.progressPanel1.TabIndex = 0;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 151);
            this.Controls.Add(this.progressPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.Timer timer1;
    }
}