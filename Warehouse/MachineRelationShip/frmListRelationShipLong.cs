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
using DTO;

namespace WareHouse.MachineRelationShip
{
    public partial class frmListRelationShipLong : Form
    {
        public frmListRelationShipLong()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadCategoryMachine();
        }
        void LoadCategoryMachine()
        {
            cbCategoriMachine.DataSource = MachineDAO.Instance.GetListDevice();
            cbCategoriMachine.DisplayMember = "Name";
            cbCategoriMachine.ValueMember = "Id";
        }
        void LoadData()
        {
            int Device = (cbCategoriMachine.SelectedItem as ListDeviceDTO).Id;
            GCData.DataSource = MachineDAO.Instance.GetListRelationLong(Device);
        }
        private void cbCategoriMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.DataRowCount == 0)
                {
                    MessageBox.Show("Bạn chưa chọn hàng mục cần xóa !".ToUpper());
                }
                else
                {
                    if (MessageBox.Show("Bạn muốn Xóa thông tin?".ToUpper(), "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        // Cập nhật nhiều dòng
                        foreach (var rowHandle in gridView1.GetSelectedRows())
                        {
                            var obj = gridView1.GetRowCellValue(rowHandle, "Id");
                            int Id = int.Parse(obj.ToString());
                            MachineDAO.Instance.DeleteRelationShip(Id);
                        }

                    }
                    LoadControl();
                }
            }
            catch
            {

            }
        }
    }
}
