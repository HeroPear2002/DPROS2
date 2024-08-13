using System;
using System.Linq;
using System.Windows.Forms;
using DTO;
using WareHouse.PCGridControl;
using WareHouse.PO_and_Order;

namespace WareHouse
{
    public partial class frmMainMenu : DevExpress.XtraEditors.XtraForm
    {
        public frmMainMenu()
        {
            InitializeComponent();
            ChangeAccount();
        }
        void ChangeAccount()
        {
            int type = Kun_Static.accountDTO.Type;//admin,PC,Pro,QC,Mold,Normal
            if (type == 1)
            {
                btnSystems.Enabled = true;
            }
        }
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            //QL KHO
            frmMainWarehouse.Instance.Show();
        }

        private void btnPC_Click(object sender, EventArgs e)
        {
            //QLSX
            frmMainPC.Instance.Show();
        }

        private void btnMold_Click(object sender, EventArgs e)
        {
            //QL KHUÔN
            frmMainMold.Instance.Show();
        }

        private void btnDevice_Click(object sender, EventArgs e)
        {
            //QL THIẾT BỊ
            frmMainDevices.Instance.Show();
        }

        private void btnEmployess_Click(object sender, EventArgs e)
        {
            //QL CNV
            frmMainEmployess.Instance.Show();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            //DL NGUỒN
            frmMainDataSoure.Instance.Show();
        }

        private void btnSystems_Click(object sender, EventArgs e)
        {
            frmAdminHistory.Instance.Show();
        }
        private void btnCheckDelivery_Click(object sender, EventArgs e)
        {
            frmCheckOutput f = new frmCheckOutput();
            f.ShowDialog();
        }

       
    }
}