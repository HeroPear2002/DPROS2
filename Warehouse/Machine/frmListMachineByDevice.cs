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
using WareHouse.Report;
using DevExpress.XtraReports.UI;

namespace WareHouse.Machine
{
    public partial class frmListMachineByDevice : DevExpress.XtraEditors.XtraForm
    {
        public frmListMachineByDevice()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control
        void LoadControl()
        {
            LoadData();
            LockControl();
        }
        void LoadData()
        {
            GCData.DataSource = MachineDAO.Instance.GetListAllMachine();
        }
        void LockControl()
        {
        }
        void OpenControl()
        {
            cbDevice.Enabled = true;
        }
        void LoadDevice()
        {
            cbDevice.DataSource = MachineDAO.Instance.GetListDevice();
            cbDevice.DisplayMember = "Name";
            cbDevice.ValueMember = "Id";
        }
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {

        }

        private void btnSEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            LoadDevice();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int device = (cbDevice.SelectedItem as ListDeviceDTO).Id;
            if (MessageBox.Show("bạn muốn sửa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                    MachineDAO.Instance.UpdateDeviceMachine(code, device);
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnQrCode_Click(object sender, EventArgs e)
        {
            List<MachinceQRCode> listQr = new List<MachinceQRCode>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                MachineDTO machineDTO = null;
                string machineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                string machineName = gridView1.GetRowCellValue(item, "MachineName").ToString();
				string name = "NO"; //gridView1.GetRowCellValue(item, "Name").ToString();
                machineDTO = MachineDAO.Instance.GetMachine(machineCode);
                string serial = machineDTO.MachineInfor;
                string codeFix = machineDTO.CodeTSCD;
          
                string qrCode = machineCode + "&" + codeFix + "&" + serial;
                listQr.Add(new MachinceQRCode(machineCode, machineName, name, serial, codeFix, qrCode));
            }
            rpQrCodeMachine rp = new rpQrCodeMachine();
            rp.DataSource = listQr;
            rp.PrintDialog();
        }

        private void btnEditMachine_Click(object sender, EventArgs e)
        {
            frmEditMachineCode f = new frmEditMachineCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnQRMedium_Click(object sender, EventArgs e)
        {
            List<MachinceQRCode> listQr = new List<MachinceQRCode>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                MachineDTO machineDTO = null;
                string machineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                string machineName = gridView1.GetRowCellValue(item, "MachineName").ToString();
                string name = gridView1.GetRowCellValue(item, "Name").ToString();
                machineDTO = MachineDAO.Instance.GetMachine(machineCode);
                string serial = machineDTO.MachineInfor;
                string codeFix = machineDTO.CodeTSCD;
                string qrCode = machineCode + "&" + codeFix;
                listQr.Add(new MachinceQRCode(machineCode, machineName, name, serial, codeFix, qrCode));
            }
            rpQRMedium rp = new rpQRMedium();
            rp.DataSource = listQr;
            rp.PrintDialog();
        }

        private void btnQRSmall_Click(object sender, EventArgs e)
        {
            List<MachinceQRCode> listQr = new List<MachinceQRCode>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                MachineDTO machineDTO = null;
                string machineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                string machineName = gridView1.GetRowCellValue(item, "MachineName").ToString();
                string name = gridView1.GetRowCellValue(item, "Name").ToString();
                machineDTO = MachineDAO.Instance.GetMachine(machineCode);
                string serial = machineDTO.MachineInfor;
                string codeFix = machineDTO.CodeTSCD;
                string qrCode = machineCode + "&" + codeFix;
                listQr.Add(new MachinceQRCode(machineCode, machineName, name, serial, codeFix, qrCode));
            }
            rpQRSmall rp = new rpQRSmall();
            rp.DataSource = listQr;
            rp.PrintDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string MachineCode = gridView1.GetRowCellValue(item, "MachineCode").ToString();
                    MachineDAO.Instance.DeleteMachine(MachineCode);
                }
                LoadControl();
            }
        }
    }
}