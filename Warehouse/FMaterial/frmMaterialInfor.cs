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
using DTO;

namespace WareHouse.FMaterial
{
    public partial class frmMaterialInfor : Form
    {
        public frmMaterialInfor()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadMaterialCode();
            LoadMaterialInfor();
        }
        void LoadData()
        {
            GCData.DataSource = MaterialInforDAO.Instance.GetlistMaterial();
        }
        void LockControl()
        {
            txtMaterialCode.Enabled = false;
            txtMaterialInfor.Enabled = false;
            nudCount.Enabled = false;

            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            txtMaterialCode.Enabled = true;
            txtMaterialInfor.Enabled = true;
            nudCount.Enabled = true;

            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            txtID.Text = String.Empty;
            txtMaterialCode.Text = String.Empty;
            txtMaterialInfor.Text = String.Empty;
            nudCount.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["Id"]).ToString();
                txtMaterialCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                txtMaterialInfor.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialInfor"]).ToString();
                nudCount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Count"]).ToString();
            }
            catch
            {
            }
        }
        void LoadMaterialCode()
        {
            txtMaterialCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMaterialCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AddItems(data);
            txtMaterialCode.AutoCompleteCustomSource = data;
        }
        void LoadMaterialInfor()
        {
            txtMaterialInfor.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtMaterialInfor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AddItems(data);
            txtMaterialInfor.AutoCompleteCustomSource = data;
        }
        void AddItems(AutoCompleteStringCollection  col)
        {
            List<MaterialDTO> listM = MaterialDAO.Instance.GetListMaterial();
            foreach (MaterialDTO item in listM)
            {
                col.Add(item.MaterialCode);
            }
        }
        #endregion
        #region Envent
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            DeleteText();
            IsInsert = true;
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
            OpenControl();
            IsInsert = false;
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MaterialInforDAO.Instance.Delete(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string material = txtMaterialInfor.Text;
            string code = txtMaterialCode.Text;
            float count = (float)Convert.ToDouble(nudCount.Text);
            int test = MaterialInforDAO.Instance.testMaterialCode(code, material);
            if(IsInsert == true)
            {
                if(test == -1)
                {
                    MaterialInforDAO.Instance.Insert(material, code, count);
                    MessageBox.Show("thêm thông tin thành công !".ToUpper());
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("thông tin đã tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                int Id = int.Parse(txtID.Text);
                MaterialInforDAO.Instance.Update(Id,material, code, count);
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
