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

namespace WareHouse.FParts
{
    public partial class frmFormPartInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmFormPartInfor()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }
    }
}