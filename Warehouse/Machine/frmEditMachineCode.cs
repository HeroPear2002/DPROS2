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

namespace WareHouse.Machine
{
    public partial class frmEditMachineCode : DevExpress.XtraEditors.XtraForm
    {
        public frmEditMachineCode()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadMachine();
            ClearText();
        }
        void ClearText()
        {
            txtMachineCode.Text = String.Empty;
            glMachineCode.Text = String.Empty;
        }
        void LoadMachine()
        {
            glMachineCode.Properties.DataSource = MachineDAO.Instance.GetListAllMachine();
            glMachineCode.Properties.DisplayMember = "MachineCode";
            glMachineCode.Properties.ValueMember = "MachineCode";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string machineOlD = glMachineCode.Text;
            string machineNew = txtMachineCode.Text;
            int test = MachineDAO.Instance.TestMachineByCode(machineNew);
            if (test == -1)
            {
                MachineDAO.Instance.UpdateMachine(machineOlD, machineNew);
                MachineDAO.Instance.UpdateMachineInfor(machineOlD, machineNew);
                MachineDAO.Instance.UpdateRelationShip(machineOlD, machineNew);
                MachineDAO.Instance.UpdateHistoryEdit(machineOlD, machineNew);
                MachineDAO.Instance.UpdateMachineDetail(machineOlD, machineNew);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
            else
            {
                MessageBox.Show("mã máy đã tồn tại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmEditMachineCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}