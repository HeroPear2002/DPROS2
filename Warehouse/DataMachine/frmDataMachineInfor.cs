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

namespace WareHouse.DataMachine
{
    public partial class frmDataMachineInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmDataMachineInfor()
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
            LoadMold();
            LoadNameCate();
            CleanText();
        }
        void LoadData()
        {
            GCData.DataSource = DataMachineDAO.Instance.GetListDataMachineInfor();
        }
        void LockControl()
        {
            cbMoldCode.Enabled = false;
            cbMachineCode.Enabled = false;
            cbCategory.Enabled = false;
            txtUpData.Enabled = false;
            txtDownData.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbMoldCode.Enabled = true;
            cbMachineCode.Enabled = true;
            cbCategory.Enabled = true;
            txtUpData.Enabled = true;
            txtDownData.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void CleanText()
        {
            cbMoldCode.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            cbCategory.Text = String.Empty;
            txtDownData.Text = String.Empty;
            txtUpData.Text = String.Empty;
            txtID.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                cbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                cbCategory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameCate"]).ToString();
                txtDownData.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DownData"]).ToString();
                txtUpData.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["UpData"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch 
            {


            }
           
        }
        void LoadMold()
        {
            cbMoldCode.DataSource = DataMachineDAO.Instance.MoldCode();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
            LoadMachine();
        }
        void LoadMachine()
        {
            string moldCode = cbMoldCode.Text;
            cbMachineCode.DataSource = DataMachineDAO.Instance.MachineCode(moldCode);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        void LoadNameCate()
        {
            cbCategory.Items.Clear();
            cbCategory.Items.Add("Cycle Time");
            cbCategory.Items.Add("TG làm mát");
            cbCategory.Items.Add("TG gia áp");
            cbCategory.Items.Add("INJ time");
            cbCategory.Items.Add("Nhiệt độ Xi Lanh");
            cbCategory.Items.Add("NĐ máy nước(Core)");
            cbCategory.Items.Add("NĐ máy nước(Cavity)");
            cbCategory.Items.Add("Cush pos");
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IsInsert = true;
            OpenControl();
            CleanText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            OpenControl();
         
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn thực sự muốn xóa thồn tin này?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    DataMachineDAO.Instance.DeleteDataMachineInfor(id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            float up = (float)Convert.ToDouble(txtUpData.Text);
            float down = (float)Convert.ToDouble(txtDownData.Text);
            int id = 0;
            try
            {
                id = int.Parse(txtID.Text);
            }
            catch 
            {
                id = 0;
            }
            DataMachineInforDTO di = new DataMachineInforDTO(id, cbCategory.Text, cbMoldCode.Text, cbMachineCode.Text, up, down);
            if (IsInsert == true)
            {
                DataMachineDAO.Instance.InsertDataMachineInfor(di);
                MessageBox.Show("Thên thông tin thành cồng !".ToUpper());
                LoadControl();
            }
            else
            {
                DataMachineDAO.Instance.UpdateDataMachineInfor(di);
                MessageBox.Show("sửa thông tin thành cồng !".ToUpper());
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

        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachine();
        }
    }
}