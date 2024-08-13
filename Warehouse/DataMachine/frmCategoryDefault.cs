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

namespace WareHouse.DataMachine
{
    public partial class frmCategoryDefault : DevExpress.XtraEditors.XtraForm
    {
        public frmCategoryDefault()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            LockControl();
        }
        void LoadData()
        {
            GCData.DataSource = DataMachineDAO.Instance.GetListCategoryDefault();
        }
        void LockControl()
        {
            txtName.Enabled = false;
            txtUpper.Enabled = false;
            txtLower.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtName.Enabled = true;
            txtUpper.Enabled = true;
            txtLower.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            txtUpper.Text = String.Empty;
            txtLower.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["Id"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
                txtUpper.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["UpperLimit"]).ToString();
                txtLower.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["LowerLimit"]).ToString();
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
            IsInsert = true;
            OpenControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)== DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    DataMachineDAO.Instance.DeleteCategory(id);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            OpenControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            float upper = (float)Convert.ToDouble(txtUpper.Text);
            float lower = (float)Convert.ToDouble(txtLower.Text);
            if(IsInsert == true)
            {
                DataMachineDAO.Instance.InsertCategory(name, upper, lower);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int id = int.Parse(txtID.Text);
                DataMachineDAO.Instance.UpdateCategory(id,name, upper, lower);
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