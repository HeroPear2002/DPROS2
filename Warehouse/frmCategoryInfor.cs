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

namespace WareHouse
{
    public partial class frmCategoryInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmCategoryInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadCategory();
        }
        void LoadData()
        {
            GCData.DataSource = MachineDAO.Instance.GetlistCategoryInfor();
        }
        void LockControl()
        {
            cbCategory.Enabled = false;
            cbMachineCode.Enabled = false;
            txtUp.Enabled = false;
            txtNote.Enabled = false;
            txtDown.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbCategory.Enabled = true;
            cbMachineCode.Enabled = true;
            txtUp.Enabled = true;
            txtNote.Enabled = true;
            txtDown.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void CleanText()
        {
            cbCategory.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            txtUp.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtDown.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbCategory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["CategoryName"]).ToString();
                cbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                txtUp.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountUp"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtDown.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountDown"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch
            {
            }
        }
        void LoadCategory()
        {
            cbCategory.DataSource = MachineDAO.Instance.GetListCategory1();
            cbCategory.DisplayMember = "NameCategory";
            cbCategory.ValueMember = "Id";
        }
        void LoadMachineCode()
        {
            long idCategory = (cbCategory.SelectedItem as CategoryTestDTO).Id;
            cbMachineCode.DataSource = MachineDAO.Instance.GetListMachineByIdCategory(idCategory);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        #region Control
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Isinsert = true;
            OpenControl();
            CleanText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Isinsert = false;
            OpenControl();
         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    MachineDAO.Instance.DeleteCategoryInfor(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string category = cbCategory.Text;
            string machine = cbMachineCode.Text;
            float up = (float)Math.Round(Convert.ToDouble(txtUp.Text), 2);
            float down = (float)Math.Round(Convert.ToDouble(txtDown.Text), 2);
            string note = txtNote.Text;
            if(Isinsert == true)
            {
                MachineDAO.Instance.InsertCategoryInfor(category, up, down, note, machine);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int id = int.Parse(txtID.Text);
                MachineDAO.Instance.UpdateCategoryInfor(id,category, up, down, note, machine);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
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

        private void cbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadMachineCode();
        }
        #endregion
    }
}