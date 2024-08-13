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

namespace WareHouse.PC
{
    public partial class frmCheckPC : Form
    {
        public frmCheckPC()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadData();
            btnSaveStatus.Enabled = false;
        }
        void LoadData()
        {
            GCData.DataSource = IventoryPartDAO.Instance.GetListIventoryPartPC();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            btnSaveStatus.Enabled = true;
        }

        private void btnSaveStatus_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn mở khóa để xuất hàng ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int idWh = int.Parse(gridView1.GetRowCellValue(item, "IdWareHouse").ToString());

                    WareHouseDAO.Instance.UpdateStatusWH(idWh, 2);
                }
                MessageBox.Show("Mở khóa thành công !".ToUpper());
                LoadControl();
            }
        }

        private void frmCheckPC_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
