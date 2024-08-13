using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace WareHouse.PCGridControl
{
    public partial class frmConfirmTableDK : Form
    {
        public frmConfirmTableDK()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            btnOke.Enabled = false;
            DateTime today = DateTime.Now;
            GCData.DataSource = TDSXDAO.Instance.GetListWarnTimeTableXH(today);
        }
        private void btnOke_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn xác nhận đo hàng !".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    TDSXDAO.Instance.UpdateConfirmTableXH(id, 2);
                }
                LoadControl();
            }
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            btnOke.Enabled = true;
        }
    }
}
