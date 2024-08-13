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
    public partial class frmFormMaterialInventoty : DevExpress.XtraEditors.XtraForm
    {
        public frmFormMaterialInventoty()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }
    }
}