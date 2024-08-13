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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmInformWH : DevExpress.XtraEditors.XtraForm
    {
        public frmInformWH()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadData();
            nudWeight.Enabled = false;
            btnSave.Enabled = false;
        }
        public EventHandler LamMoi;
        void LoadData()
        {
            string style = "A' OR Style = N'B";
            List<WarehouseMaterial> listW = WarehouseMaterialDAO.Instance.GetListWareHouse(style).Where(x => x.StatusWH == 1 || x.StatusWH == 9).ToList();
            GCData.DataSource = listW;
        }
        private void btnLock_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn khóa/mở vị trí này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int status = int.Parse(gridView1.GetRowCellValue(item, "StatusWH").ToString());
                    if (status == 1)
                    {
                        WarehouseMaterialDAO.Instance.UpdateStatus(id, 9);
                    }
                    else if (status == 9)
                    {
                        WarehouseMaterialDAO.Instance.UpdateStatus(id, 1);
                    }
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            nudWeight.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int weigth = (int)nudWeight.Value;
            if (MessageBox.Show("bạn muốn sửa trọng lượng vị trí này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WarehouseMaterialDAO.Instance.UpdateWeigth(id, weigth);
                }
                LoadControl();
            }
        }

        private void frmInformWH_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn chuyển vị trí này thành đặc biệt?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string style = "B";
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WarehouseMaterialDAO.Instance.UpdateStyle(id, style);
                    WarehouseMaterialDAO.Instance.UpdateWeigth(id, 630);
                }
                LoadControl();
            }
        }

        private void btnChangeNomal_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn chuyển vị trí này thành bình thường?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string style = "A";
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    WarehouseMaterialDAO.Instance.UpdateStyle(id, style);
                }
                LoadControl();
            }
        }
    }
}