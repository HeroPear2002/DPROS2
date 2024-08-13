using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Employess;

namespace WareHouse.MachineRelationShip
{
    public partial class frmRelationShipLong : Form
    {
        public frmRelationShipLong()
        {
            InitializeComponent();
            LoadControl();
        }
        #region LoadControl
        void LoadControl()
        {
            LoadCategory();
        }
        void LoadCategoryLong()
        {
           string Device = cbCategory.Text;
            GcDataCategory.DataSource = MachineDAO.Instance.GetListCategoryLongBydevice(Device);
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
            LoadCategoryLong();
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
                            int timeKH = int.Parse(gridView2.GetRowCellValue(item, "Timer").ToString());
                            long Idtest = MachineDAO.Instance.IdRelationShipByMachine(MachineCode, Id);
                            if (Idtest == -1)
                            {
                                MachineDAO.Instance.InsertRelationShip(MachineCode, Id, 0, 0, timeKH);
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmListRelationShipLong f = new frmListRelationShipLong();
            f.ShowDialog();
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            List<RelationShipDTO> listR = MachineDAO.Instance.GetListRelationShip();
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false);
            int i = 0;
            foreach (RelationShipDTO item in listR)
            {
                i++;
                int TimeKh = MachineDAO.Instance.TimeKHCategory(item.IdCategory);
                if(TimeKh == -1)
                {
                    MachineDAO.Instance.DeleteRelationIdCategory(item.IdCategory);
                }
                else
                {
                    MachineDAO.Instance.UpdateTimeKHRelationShip(item.Id, TimeKh);
                }
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "/" + listR.Count.ToString());
                Thread.Sleep(1);
            }
            SplashScreenManager.CloseForm(false);
        }
    }
}
