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

namespace WareHouse.FParts
{
    public partial class frmLockPart : DevExpress.XtraEditors.XtraForm
    {
   
        public frmLockPart()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadPartCode();
            LoadData();
            LoadStatusWH();
        }
        void LoadPartCode()
        {
            cbPart.DataSource = MacInforDAO.Instance.GetListPart();
            cbPart.DisplayMember = "PartCode";
            cbPart.ValueMember = "PartCode";
        }
        void LoadMoldCode()
        {
            string PartCode = cbPart.Text;
            cbMoldNumber.DataSource = MacInforDAO.Instance.GetListMoldByPart(PartCode);
            cbMoldNumber.DisplayMember = "MoldCode";
            cbMoldNumber.ValueMember = "MoldCode";
        }
        void LoadMachineCode()
        {
            string PartCode = cbPart.Text;
            string MoldCode = cbMoldNumber.Text;
            cbMachineCode.DataSource = MacInforDAO.Instance.GetListMachineByPartMold(PartCode, MoldCode);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        void LoadData()
        {
            GCPartLock.DataSource = PartDAO.Instance.GetlistPartLock();
        }
        void LockControl()
        {
            cbPart.Enabled = false;
            cbMoldNumber.Enabled = false;
            cbMachineCode.Enabled = false;
            cbStatusWh.Enabled = false;
            txtNote.Enabled = false;


            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            cbPart.Enabled = true;
            cbMoldNumber.Enabled = true;
            cbMachineCode.Enabled = true;
            cbStatusWh.Enabled = true;
            txtNote.Enabled = true;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

        }
        void LoadStatusWH()
        {
            cbStatusWh.DataSource = WareHouseDAO.Instance.StatusWarehousePartLock();
            cbStatusWh.DisplayMember = "NameStatus";
            cbStatusWh.ValueMember = "Id";
        }

        void ClearText()
        {
            cbPart.Text = String.Empty;
            cbMoldNumber.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            cbStatusWh.Text = String.Empty;
            txtNote.Text = String.Empty;

        }
        void AddText()
        {
            try
            {
                cbPart.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                cbMoldNumber.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                cbMachineCode.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                cbStatusWh.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                txtNote.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                string a = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Yellow"]).ToString();
                if (a == "O")
                {
                    cBYellow.Checked = false;
                }
                else
                {
                    cBYellow.Checked = true;
                }
            }
            catch
            {
            }
        }
        #endregion
        #region Event
        private void GCPartLock_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void cbMoldNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachineCode();
        }
        private void cbPart_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMoldCode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearText();
            OpenControl();
            IsInsert = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thống tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    int id = int.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    PartDAO.Instance.DeletePartLock(id);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            IsInsert = false;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string partCode = cbPart.Text;
            string moldCode = cbMoldNumber.Text;
            string moldNumber = MoldDAO.Instance.MoldNumber(moldCode);
            string machineCode = cbMachineCode.Text;
            int statusWh = (cbStatusWh.SelectedItem as StatusWarehouseDTO).Id;
            string sttName = cbStatusWh.Text;
            string note = txtNote.Text;
            string yellow = "O";
            if (cBYellow.Checked == true)
            {
                yellow = "NO";
            }
            int testPartCode = PartDAO.Instance.TestPartCode(partCode);
            int testMachinecode = MachineDAO.Instance.TestMachineByCode(machineCode);
            int testPartLock = PartDAO.Instance.TestPartLock(partCode, moldNumber, machineCode);
            if (testPartCode == -1 || testMachinecode == -1 || sttName.Length == 0)
            {
                MessageBox.Show("gặp lỗi khi thao tác hệ thống \nbạn hãy thử lại 1".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsInsert == true)
            {
                if (testPartLock == -1)
                {
                    PartDAO.Instance.InsertPartLock(partCode, moldNumber, machineCode, note, statusWh, yellow);
                    MessageBox.Show("Thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("dữ liệu này đã tồn tại!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }


        #endregion


    }
}