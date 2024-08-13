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
    public partial class frmRoom : DevExpress.XtraEditors.XtraForm
    {
        public frmRoom()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
        }
        void LoadData()
        {
            GCData.DataSource = EmployessDAO.Instance.GetListRoom();
        }
        void LockControl()
        {
            txtCode.Enabled = false;
            txtName.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtCode.Enabled = true;
            txtName.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["CodeRo"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameRo"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {
            }
        }
        #endregion

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenControl();
            ClearText();
            Isinsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    EmployessDAO.Instance.DeleteRoom(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = txtCode.Text;
            string name = txtName.Text;
            if(Isinsert == true)
            {
                EmployessDAO.Instance.InsertRoom(code, name);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int id = int.Parse(txtID.Text);
                EmployessDAO.Instance.UpdateRoom(id,code, name);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
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