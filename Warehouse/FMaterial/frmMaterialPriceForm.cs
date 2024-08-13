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

namespace WareHouse.FMaterial
{
    public partial class frmMaterialPriceForm : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialPriceForm()
        {
            InitializeComponent();
        }

        private void btnDowload_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }
    }
}