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

namespace WareHouse.Employess
{
    public partial class frmPlusAndError : DevExpress.XtraEditors.XtraForm
    {
        public frmPlusAndError()
        {
            InitializeComponent();
            LoadControlEr();
            LoadControlPl();
            LoadRoom();
        }
        void LoadRoom()
        {
            cbRoom.DataSource = EmployessDAO.Instance.GetListRoom();
            cbRoom.DisplayMember = "CodeRo";
            cbRoom.ValueMember = "CodeRo";
        }
        public bool IsinsertEr = false;
        public bool IsinsertPl = false;
        #region Control Er
        void LoadControlEr()
        {
            LockControlEr();
            LoadDataEr();
        }
        void LoadDataEr()
        {
            string room = cbRoom.Text;
            GCError.DataSource = EmployessDAO.Instance.GetListError(room);
        }
        void LockControlEr()
        {
            txtNameEr.Enabled = false;
            nudPointEr.Enabled = false;
            cbRoom.Enabled = true;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControlEr()
        {
            txtNameEr.Enabled = true;
            nudPointEr.Enabled = true;
            cbRoom.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearTextEr()
        {
            txtNameEr.Text = String.Empty;
            nudPointEr.Text = String.Empty;
            txtIdEr.Text = String.Empty;

        }
        void AddTextEr()
        {
            try
            {
                txtNameEr.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameEr"]).ToString();
                nudPointEr.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PointEr"]).ToString();
                txtIdEr.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                cbRoom.Text = gridView2.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RoomCode"]).ToString();
            }
            catch
            {
            }
        }
        #endregion
        #region Event Error
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControlEr();
            IsinsertEr = true;
            ClearTextEr();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControlEr();
            IsinsertEr = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    EmployessDAO.Instance.DeleteError(id);
                }
                LoadControlEr();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nameEr = txtNameEr.Text;
            string testName = nameEr.Replace(" ", "");
            int pointEr = (int)nudPointEr.Value;
            string roomCode = cbRoom.Text;
            // String.IsNullOrWhiteSpace(nameEr);
            if (testName.Length == 0)
            {
                MessageBox.Show("bạn chưa điền thông tin !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsinsertEr == true)
            {
                if (EmployessDAO.Instance.TestNameEr(nameEr) == -1)
                {
                    EmployessDAO.Instance.InsertError(nameEr, pointEr, roomCode);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControlEr();
                }
                else
                {
                    MessageBox.Show("tên hạng mục đã tốn tại !\n \nbạn hãy kiểm tra lại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                long id = long.Parse(txtIdEr.Text);
                EmployessDAO.Instance.UpdateError(id, nameEr, pointEr, roomCode);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControlEr();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadDataEr();
        }
        private void GCError_Click(object sender, EventArgs e)
        {
            AddTextEr();
        }
        private void btnExcelEr_Click(object sender, EventArgs e)
        {
            frmInPortExcelError f = new frmInPortExcelError();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        #endregion

        #region Control PL
        void LoadControlPl()
        {
            LockControlPl();
            LoadDataPl();
        }
        void LoadDataPl()
        {
            string room = cbRoom.Text;
            GCPlus.DataSource = EmployessDAO.Instance.GetListPlus(room);
        }
        void LockControlPl()
        {
            txtNamePl.Enabled = false;
            nudPointPl.Enabled = false;
            cbRoom.Enabled = true;

            btnAddPl.Enabled = true;
            btnEditPl.Enabled = true;
            btnDeletePl.Enabled = true;
            btnSavePl.Enabled = false;
        }
        void OpenControlPl()
        {
            txtNamePl.Enabled = true;
            nudPointPl.Enabled = true;
            cbRoom.Enabled = true;

            btnAddPl.Enabled = false;
            btnEditPl.Enabled = false;
            btnDeletePl.Enabled = false;
            btnSavePl.Enabled = true;
        }
        void ClearTextPl()
        {
            txtNamePl.Text = String.Empty;
            nudPointPl.Text = String.Empty;
            txtIdPl.Text = String.Empty;

        }
        void AddTextPl()
        {
            try
            {
                txtNamePl.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["NamePl"]).ToString();
                nudPointPl.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PointPl"]).ToString();
                txtIdPl.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Id"]).ToString();
                cbRoom.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["RoomCode"]).ToString();
            }
            catch
            {
            }
        }
        #endregion
        #region Event Plus
        private void btnAddPl_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControlPl();
            IsinsertPl = true;
            ClearTextPl();
        }

        private void btnEditPl_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControlPl();
            IsinsertPl = false;
        }

        private void btnDeletePl_Click(object sender, EventArgs e)
        {
            int testAcc = AccountDAO.Instance.PermissionAccount(Kun_Static.accountDTO.UserName);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    long id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                    EmployessDAO.Instance.DeletePlus(id);
                }
            }
        }

        private void btnSavePl_Click(object sender, EventArgs e)
        {
            string namePl = txtNamePl.Text;
            string testName = namePl.Replace(" ", "");
            int pointPl = (int)nudPointPl.Value;
            string roomCode = cbRoom.Text;
            if (testName.Length == 0)
            {
                MessageBox.Show("bạn chưa điền thông tin !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsinsertPl == true)
            {
                if (EmployessDAO.Instance.TestNamePl(namePl) == -1)
                {
                    EmployessDAO.Instance.InsertPlus(namePl, pointPl, roomCode);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControlPl();
                }
                else
                {
                    MessageBox.Show("tên hạng mục đã tốn tại !\n \nbạn hãy kiểm tra lại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                long id = long.Parse(txtIdPl.Text);
                EmployessDAO.Instance.UpdatePlus(id, namePl, pointPl, roomCode);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControlPl();
            }
        }

        private void btnUpdatePl_Click(object sender, EventArgs e)
        {
            LoadDataPl();
        }

        private void GCPlus_Click(object sender, EventArgs e)
        {
            AddTextPl();
        }
        #endregion

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataEr();
            LoadDataPl();
        }


        private void btnExcelPl_Click(object sender, EventArgs e)
        {
            frmInportPlus f = new frmInportPlus();
            f.LamMoi += new EventHandler(btnUpdatePl_Click);
            f.ShowDialog();
        }
    }
}