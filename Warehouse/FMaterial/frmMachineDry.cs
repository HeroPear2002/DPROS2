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
    public partial class frmMachineDry : DevExpress.XtraEditors.XtraForm
    {
        public frmMachineDry()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        private void LoadControl()
        {
            LoadData();
            LockControl();
        }

        private void LoadData()
        {
            GCData.DataSource = MachineDAO.Instance.GetMachineDry();
        }

        private void LockControl()
        {
            txtDryCode.Enabled = false;
            txtDryName.Enabled = false;
            txtNote.Enabled = false;
            txtWeight.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        private void OpenControl()
        {
            txtDryCode.Enabled = true;
            txtDryName.Enabled = true;
            txtNote.Enabled = true;
            txtWeight.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            txtDryCode.Text = String.Empty;
            txtDryName.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtWeight.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtDryCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["DryCode"]).ToString();
                txtDryName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DryName"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtWeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WeightTray"]).ToString();
            }
            catch 
            {
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearText();
            Isinsert = true;
            OpenControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("bạn muốn xóa thông tin này?","Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string dryCode = gridView1.GetRowCellValue(item, "DryCode").ToString();
                    MachineDAO.Instance.DeleteDry(dryCode);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string dryCode = txtDryCode.Text;
            string dryName = txtDryName.Text;
            float weightTray = (float)Convert.ToDouble(txtWeight.Text);
            string note = txtNote.Text;
            if(Isinsert == true)
            {
                MachineDAO.Instance.InsertDry(dryCode, dryName, weightTray, note);
                MessageBox.Show("thêm thông tin thành công!".ToUpper());
                LoadControl();
            }
            else
            {
                MachineDAO.Instance.UpdateDry(dryCode, dryName, weightTray, note);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
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

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
           (e.KeyChar == '.' && (txtWeight.Text.Length == 0 || txtWeight.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
    }
}