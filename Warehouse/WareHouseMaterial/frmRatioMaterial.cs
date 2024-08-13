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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmRatioMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmRatioMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadMateralCode();
            LockControl();
            LoadData();
        }
        void LockControl()
        {
            cbMaterial.Enabled = false;
            nudPercen.Enabled = false;
            txtNote.Enabled = false;
            nudRatioInput.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbMaterial.Enabled = true;
            nudPercen.Enabled = true;
            txtNote.Enabled = true;
            nudRatioInput.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void LoadData()
        {
            GCData.DataSource = MaterialDAO.Instance.GetListRatio();
        }
        void ClearText()
        {
            cbMaterial.Text = String.Empty;
            nudPercen.Text = String.Empty;
            txtNote.Text = String.Empty;
            nudRatioInput.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbMaterial.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                nudPercen.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Ratio"]).ToString(); 
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                nudRatioInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RatioInput"]).ToString();
            }
            catch
            {
            }
        }
        void LoadMateralCode()
        {
            cbMaterial.Properties.DataSource = MaterialDAO.Instance.GetListMaterial();
            cbMaterial.Properties.DisplayMember = "MaterialCode";
            cbMaterial.Properties.ValueMember = "MaterialCode";
        }
        #endregion
        #region Event

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
            OpenControl();
            ClearText();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    MaterialDAO.Instance.DeleteRatio(code);
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
            cbMaterial.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = cbMaterial.Text;
            int ratio = (int)nudPercen.Value;
            string note = txtNote.Text;
            int RatioInput = (int)nudRatioInput.Value;
            if (Isinsert == true)
            {
                MaterialDAO.Instance.InsertRatio(code, ratio, note,RatioInput);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                MaterialDAO.Instance.EditRatio(code, ratio, note,RatioInput);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        #endregion

        private void btnEdits_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn sửa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    string Note = gridView1.GetRowCellValue(item, "Note").ToString();
                    int ratio = int.Parse(gridView1.GetRowCellValue(item, "Ratio").ToString());
                    int ratioInput = int.Parse(gridView1.GetRowCellValue(item, "RatioInput").ToString());
                    MaterialDAO.Instance.EditRatio(code, ratio, Note, ratioInput);
                }
                LoadControl();
            }
        }
    }
}