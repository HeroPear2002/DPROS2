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

namespace WareHouse.FMaterial
{
    public partial class frmReason : DevExpress.XtraEditors.XtraForm
    {
        public frmReason()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        int _id = 0;
        #region LoadControl
        void LoadControl()
        {
            LockControl();
            LoadData();
        }

        private void LoadData()
        {
            GCData.DataSource = MaterialDAO.Instance.GetReason();
        }

        private void LockControl()
        {
            txtDetail.Enabled = false;
            txtNote.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        private void OpenControl()
        {
            txtDetail.Enabled = true;
            txtNote.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtDetail.Text = String.Empty;
            txtNote.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtDetail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ReasonDetail"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                _id = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn xóa những thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    MaterialDAO.Instance.DeleteReason(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string detail = txtDetail.Text;
            string note = txtNote.Text;
            if(Isinsert == true)
            {
                MaterialDAO.Instance.InsertReason(detail,note);
                MessageBox.Show("thêm thông tin thành công!".ToUpper());
                LoadControl();
            }
            else
            {
                MaterialDAO.Instance.UpdateReason(detail, note,_id);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
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