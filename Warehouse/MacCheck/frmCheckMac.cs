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
using DAO;
using DTO;

namespace WareHouse.PO_and_Order
{
    public partial class frmCheckMac : DevExpress.XtraEditors.XtraForm
    {
        public frmCheckMac()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDate();
            LoadData();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1-today.Day);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddMilliseconds(-50);
        }
        void LoadData()
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            List<BoxCheckDTO> listB = new List<BoxCheckDTO>();
            listB = BoxCheckDAO.Instance.GetListBoxCheck().Where(x=>x.DateCheck >= date1 && x.DateCheck <= date2).ToList();
            GCData.DataSource = listB;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 10;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}