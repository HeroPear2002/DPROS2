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
using System.IO;
using DTO;

namespace WareHouse.Machine
{
    public partial class frmMachineInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmMachineInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control
        string targetPath = @"\\192.168.2.10\datasave\MACHINE";
        void LoadControl()
        {
            LoadDevice();
            LoadDATA2();
        }
        void LoadDATA2()
        {
            GCData2.DataSource = MachineDAO.Instance.GetListMachineInfor();
        }
        void LoadDATA1(int device)
        {
            GCData1.DataSource = MachineDAO.Instance.GetListMachineByDevice(device);
        }
        void LoadDevice()
        {
            cbDevice.DataSource = MachineDAO.Instance.GetListDevice();
            cbDevice.DisplayMember = "Name";
            cbDevice.ValueMember = "Id";
        }
        #endregion
        #region Event
        void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLink.Text = ofd.FileName;
                }
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string linkSource = txtLink.Text;
            string fileName = Path.GetFileName(linkSource);
            string sourcePath = linkSource;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = linkSource;
            string destFile = System.IO.Path.Combine(targetPath, fileName);
            if (linkSource.Length > 0)
            {
                System.IO.File.Copy(sourceFile, destFile, true);
            }
            else
            {
                MessageBox.Show("File không tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            string link = fileName;
            if (MessageBox.Show("bạn muốn thêm thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string Machine = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                    int test = MachineDAO.Instance.TestMachineInfor(Machine);
                    if (test == -1)
                    {
                        MachineDAO.Instance.InsertMachineInfor(Machine, link);
                    }
                    else
                    {
                        MachineDAO.Instance.UpdateMachineInfor(Machine, link);
                    }
                }
                LoadControl();
            }
        }

        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int device = (cbDevice.SelectedItem as ListDeviceDTO).Id;
            LoadDATA1(device);
        }
        private void cbDevice_MouseClick(object sender, MouseEventArgs e)
        {
            int device = (cbDevice.SelectedItem as ListDeviceDTO).Id;
            LoadDATA1(device);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    long id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    MachineDAO.Instance.DeleteMachineInfor(id);
                }
            }
        }
        #endregion


    }
}