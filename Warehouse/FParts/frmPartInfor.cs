using System;
using System.Drawing;
using System.Windows.Forms;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DTO;

namespace WareHouse.FParts
{
    public partial class frmPartInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmPartInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        void LoadControl()
        {
            LoadData();
            LockControl();
            LoadPart();
        }
        void LockControl()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

            glPartCode.Enabled = false;
            txtPercent.Enabled = false;
            txtWeightBy.Enabled = false;
        }
        void OpenControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            glPartCode.Enabled = true;
            txtPercent.Enabled = true;
            txtWeightBy.Enabled = true;
        }
        void ClearText()
        {
            glPartCode.Text = String.Empty;
            txtWeightBy.Text = String.Empty;
            txtPercent.Text = String.Empty;
        }
        void LoadData()
        {
            GCData.DataSource = PartDAO.Instance.GetlistPartInfor();
        }
        void LoadPart()
        {
            glPartCode.Properties.DataSource = PartDAO.Instance.GetListPart();
            glPartCode.Properties.DisplayMember = "PartCode";
            glPartCode.Properties.ValueMember = "PartCode";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Isinsert = true;
            ClearText();
            OpenControl();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn xóa thêm thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView2.GetSelectedRows())
                {
                    string code = gridView2.GetRowCellValue(item, "PartCode").ToString();
                    PartDAO.Instance.DeletePartInfor(code);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Isinsert = false;
            OpenControl();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportPartInfor f= new frmInportPartInfor();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormPartInfor f = new frmFormPartInfor();
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string PartCode = glPartCode.Text;
            string weightBy = txtWeightBy.Text;
            float percen = (float)Convert.ToDouble(txtPercent.Text);
            if(Isinsert == true)
            {
                int test = PartDAO.Instance.TestPartInfor(PartCode);
                if(test == -1)
                {
                    PartDAO.Instance.InsertPartInfor(PartCode, percen, weightBy);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("mã linh kiện đã tồn tại!".ToUpper(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            else {
                PartCode = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                PartDAO.Instance.UpdatePartInfor(PartCode, percen, weightBy);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void AddText()
        {
            try
            {
                glPartCode.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["PartCode"]).ToString();
                txtPercent.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Percentage"]).ToString();
                txtWeightBy.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["WeightBy"]).ToString();
            }
            catch 
            {
            }
        }

        private void txtPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
              (e.KeyChar == '.' && (txtPercent.Text.Length == 0 || txtPercent.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }

        private void txtWeightBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
              (e.KeyChar == '.' && (txtWeightBy.Text.Length == 0 || txtWeightBy.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
    }
}