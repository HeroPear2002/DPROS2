using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DTO;

namespace WareHouse.Mold
{
    public partial class frmMoldError : Form
    {

        public frmMoldError()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;

        void LoadControl()
        {
            KhoaDK();
            LoadData();
        }
        #region Control
        void LoadData()
        {
            int ErrorId = frmMainMold.MainId.MoldErrorId;
            if (ErrorId == 3)
            {
                ckCheck.Enabled = true;
            }
            else
            {
                ckCheck.Enabled = false;
            }
            GCData.DataSource = MoldDAO.Instance.GetErrorMold(ErrorId);
        }
        void KhoaDK()
        {
            txtID.Enabled = false;
            txtNameError.Enabled = false;
            ckCheck.Checked = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
        }
        void MoKhoDK()
        {

            txtNameError.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
        }
        void XoaText()
        {
            txtNameError.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtNameError.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameError"]).ToString();
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                if (a == "1")
                {
                    ckCheck.Checked = true;
                }
                else
                {
                    ckCheck.Checked = false;
                }
            }
            catch
            {

            }
        }
        #endregion

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoDK();
            XoaText();
            IsInsert = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoDK();
            IsInsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MoldDAO.Instance.DeleteErrorMold(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Name = txtNameError.Text;
            int ErrorId = frmMainMold.MainId.MoldErrorId;
            string note = "";
            if (ckCheck.Checked == true)
            {
                note = "1";
            }
            if (IsInsert == true)
            {
                int test = MoldDAO.Instance.IdErrorMold(Name);
                if (test == -1)
                {
                    MoldDAO.Instance.InsertErrorMold(Name, ErrorId, note);
                    MessageBox.Show("Thêm Thông tin thành công !".ToUpper());
                    XoaText();
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("Thêm Thông tin đã tồn tại!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                int Id = int.Parse(txtID.Text);
                MoldDAO.Instance.UpdateErrorMold(Id, Name, ErrorId, note);
                MessageBox.Show("Sửa Thông tin thành công !".ToUpper());
                XoaText();
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        #endregion

        private void GcData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string note = view.GetRowCellValue(e.RowHandle, view.Columns["Note"]).ToString();
                if (note == "1")
                {
                    e.Appearance.BackColor = Color.Gray;
                }
            }
        }
    }
}
