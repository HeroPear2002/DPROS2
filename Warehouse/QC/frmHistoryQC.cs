using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse.QC
{
    public partial class frmHistoryQC : Form
    {
        public frmHistoryQC()
        {
            InitializeComponent();
            LoadDate();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(-today.Day + 1);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-1);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;

            GCData.DataSource = IventoryPartDAO.Instance.GetListHistoryQC(date1, date2);
        }
    }
}
