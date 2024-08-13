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
using System.Data.SqlClient;

namespace WareHouse.Employess
{
    public partial class frmPosition : DevExpress.XtraEditors.XtraForm
    {
        public frmPosition()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LockControl();
            LoadData();
        }
        void LoadData()
        {
            GCData.DataSource = EmployessDAO.Instance.GetListPosition();
        }
        void LockControl()
        {
            txtPositionCode.Enabled = false;
            txtPositionName.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            txtPositionCode.Enabled = true;
            txtPositionName.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtPositionName.Text = String.Empty;
            txtPositionCode.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtPositionName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PositionName"]).ToString();
                txtPositionCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PositionCode"]).ToString();
            }
            catch
            {

            }
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            OpenControl();
            IsInsert = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này ?".ToString(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "PositionCode").ToString();
                    EmployessDAO.Instance.DeletePosition(code);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            IsInsert = false;
            txtPositionCode.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtPositionCode.Text;
            string name = txtPositionName.Text;
            if (IsInsert == true)
            {
                try
                {
                    int test = EmployessDAO.Instance.TestPosition(name);
                    if (test == -1)
                    {
                        EmployessDAO.Instance.InsertPosition(code, name);
                        MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                        LoadControl();
                    }
                    else
                    {
                        MessageBox.Show("Tên chức vụ đã tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã đã tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                EmployessDAO.Instance.EditPosition(code, name);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        #endregion

    }
}