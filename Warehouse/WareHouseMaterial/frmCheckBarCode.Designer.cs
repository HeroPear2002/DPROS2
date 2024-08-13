namespace WareHouse.WareHouseMaterial
{
    partial class frmCheckBarCode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCheckBarCode));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTem3 = new System.Windows.Forms.Label();
            this.txtTem3 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTem2 = new System.Windows.Forms.Label();
            this.txtTem2 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 248);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblTem3);
            this.panel3.Controls.Add(this.txtTem3);
            this.panel3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 99);
            this.panel3.TabIndex = 1;
            // 
            // lblTem3
            // 
            this.lblTem3.AutoSize = true;
            this.lblTem3.Location = new System.Drawing.Point(4, 17);
            this.lblTem3.Name = "lblTem3";
            this.lblTem3.Size = new System.Drawing.Size(137, 19);
            this.lblTem3.TabIndex = 1;
            this.lblTem3.Text = "MÃ VẠCH TEM 3 :";
            // 
            // txtTem3
            // 
            this.txtTem3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTem3.Location = new System.Drawing.Point(4, 42);
            this.txtTem3.Multiline = true;
            this.txtTem3.Name = "txtTem3";
            this.txtTem3.Size = new System.Drawing.Size(501, 54);
            this.txtTem3.TabIndex = 1;
            this.txtTem3.TextChanged += new System.EventHandler(this.txtTem3_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.lblTem2);
            this.panel2.Controls.Add(this.txtTem2);
            this.panel2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 99);
            this.panel2.TabIndex = 0;
            // 
            // lblTem2
            // 
            this.lblTem2.AutoSize = true;
            this.lblTem2.Location = new System.Drawing.Point(4, 17);
            this.lblTem2.Name = "lblTem2";
            this.lblTem2.Size = new System.Drawing.Size(137, 19);
            this.lblTem2.TabIndex = 1;
            this.lblTem2.Text = "MÃ VẠCH TEM 2 :";
            // 
            // txtTem2
            // 
            this.txtTem2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTem2.Location = new System.Drawing.Point(4, 42);
            this.txtTem2.Multiline = true;
            this.txtTem2.Name = "txtTem2";
            this.txtTem2.Size = new System.Drawing.Size(501, 54);
            this.txtTem2.TabIndex = 0;
            this.txtTem2.TextChanged += new System.EventHandler(this.txtTem2_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCheckBarCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 260);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCheckBarCode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KIỂM TRA MÃ VẠCH";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTem3;
        private System.Windows.Forms.TextBox txtTem3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTem2;
        private System.Windows.Forms.TextBox txtTem2;
        private System.Windows.Forms.Timer timer1;
    }
}