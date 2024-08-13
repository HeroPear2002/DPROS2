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

namespace WareHouse.Order
{
    public partial class frmFCMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmFCMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            GCData.DataSource = OrderDAO.Instance.GetFCMaterialDTOs();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFCInport f = new frmFCInport();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    OrderDAO.Instance.DeleteFCMaterial(id);
                }
                LoadControl();
            }
        }
    }
}