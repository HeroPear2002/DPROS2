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
    public partial class frmRelationShipShort : Form
    {
        public frmRelationShipShort()
        {
            InitializeComponent();
            LoadControl();
        }
        #region LoadControl
        void LoadControl()
        {
            LoadCategory();
        }
        void LoadCategoryShort()
        {
            string Device = cbCategory.Text;
            GcDataCategory.DataSource = MachineDAO.Instance.GetListCategoryShortBydevice(Device);
        }
        void LoadCategory()
        {
            cbCategory.DataSource = MachineDAO.Instance.GetListDevice();
            cbCategory.DisplayMember = "Name";
            cbCategory.ValueMember = "Id";
        }
        void LoadMachine()
        {
            int Device = (cbCategory.SelectedItem as ListDeviceDTO).Id;
            GCDataMachine.DataSource = MachineDAO.Instance.GetListMachineByDevice(Device);
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachine();
            LoadCategoryShort();
        }


        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn muốn thêm thông tin?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    // Cập nhật nhiều dòng
                    foreach (var rowHandle in gridView1.GetSelectedRows())
                    {
                        var obj = gridView1.GetRowCellValue(rowHandle, "MachineCode");
                        string MachineCode = obj.ToString();
                        foreach (var item in gridView2.GetSelectedRows())
                        {
                            var objitem = gridView2.GetRowCellValue(item, "Id");
                            long Id = int.Parse(objitem.ToString());
                            long Idtest = MachineDAO.Instance.IdRelationShipByMachine(MachineCode, Id);
                            if (Idtest == -1)
                            {
                                MachineDAO.Instance.InsertRelationShip(MachineCode, Id, 0, 0, 24);
                            }

                        }
                    }
                    LoadControl();
                }
            }
            catch (Exception ex)
            {
                // Memunculkan pesan error
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public class shortMachine
        {
            public static int testTimer;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmListRelationShipShort f = new frmListRelationShipShort();
            f.ShowDialog();
        }
    }
}
