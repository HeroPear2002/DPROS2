using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace WareHouse.PO_and_Order
{
    public partial class frmPOFixForm : DevExpress.XtraEditors.XtraForm
    {
        public frmPOFixForm()
        {
            InitializeComponent();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }
    }
}