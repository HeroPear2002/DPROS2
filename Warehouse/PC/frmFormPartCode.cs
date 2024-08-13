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
using System.Diagnostics;
using DTO;

namespace WareHouse.PC
{
    public partial class frmFormPartCode : DevExpress.XtraEditors.XtraForm
    {
        public frmFormPartCode()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadPart();
        }
        void LoadData()
        {
            GCData.DataSource = PartDAO.Instance.GetlistFormPart();
        }
        void LockControl()
        {
            cbPartCode.Enabled = false;
            btnLD.Enabled = false;
            btnDK.Enabled = false;
            btnXH.Enabled = false;
            txtNote.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbPartCode.Enabled = true;
            btnLD.Enabled = true;
            btnDK.Enabled = true;
            btnXH.Enabled = true;
            txtNote.Enabled = false;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            cbPartCode.Text = String.Empty;
            txtDK.Text = String.Empty;
            txtLD.Text = String.Empty;
            txtXH.Text = String.Empty;
            txtNote.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["PartCode"]).ToString();
                txtDK.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FormDK"]).ToString();
                txtLD.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FormLD"]).ToString();
                txtXH.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FormXH"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
            }
            catch
            {

            }
        }
        void LoadPart()
        {
            cbPartCode.DataSource = PartDAO.Instance.GetListPart();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
        }
        #endregion
        #region Event
        private void btnLD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtLD.Text = ofd.FileName;
            }
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtDK.Text = ofd.FileName;
            }
        }

        private void btnXH_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtXH.Text = ofd.FileName;
            }
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
            Isinsert = true;
            ClearText();
            OpenControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Isinsert = false;
            cbPartCode.Enabled = false;
            OpenControl();
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
            if (MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult .OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string part = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    PartDAO.Instance.DeleteFormPart(part);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string part = cbPartCode.Text;
            string ld = txtLD.Text;
            string dk = txtDK.Text;
            string xh = txtXH.Text;
            string note = txtNote.Text;
            if(Isinsert == true)
            {
                PartDAO.Instance.InsertFormPart(part, ld, dk, xh, note);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                PartDAO.Instance.UpdateFormpart(part, ld, dk, xh, note);
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

        private void GCData_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        private void btnFormLD_Click(object sender, EventArgs e)
        {
            try
            {
                string a = txtLD.Text;
                if(a.Length > 0)
                {
                    Process.Start(a);
                }
                else
                {
                    MessageBox.Show("bạn chưa chọn linh kiện cần in !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch 
            {
                MessageBox.Show("linh kiện chưa có Form lượt đầu !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFormDK_Click(object sender, EventArgs e)
        {
            try
            {
                string a = txtDK.Text;
                if (a.Length > 0)
                {
                    Process.Start(a);
                }
                else
                {
                    MessageBox.Show("bạn chưa chọn linh kiện cần in !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("linh kiện chưa có Form định kỳ đầu !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFormXH_Click(object sender, EventArgs e)
        {
            try
            {
                string a = txtXH.Text;
                if (a.Length > 0)
                {
                    Process.Start(a);
                }
                else
                {
                    MessageBox.Show("bạn chưa chọn linh kiện cần in !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("linh kiện chưa có Form Xuất hàng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}