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

namespace WareHouse.QC
{
    public partial class frmHistotyEquipment : Form
    {


        public frmHistotyEquipment( )
        {
 
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            LockControl();
            LoadEquipment();
        }
        void LoadEquipment()
        {
            cbEquipmentCode.DataSource = EquipmentDAO.Instance.GetListEquipment();
            cbEquipmentCode.DisplayMember = "EquipmentCode";
            cbEquipmentCode.ValueMember = "EquipmentCode";
        }
        void LoadData()
        {
            GCData.DataSource = EquipmentDAO.Instance.GetListHistory();

        }
        void LockControl()
        {
            cbEquipmentCode.Enabled = false;
            txtEmployess.Enabled = false;
            txtPeople.Enabled = false;
            dtpkDateIn.Enabled = false;
        

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            cbEquipmentCode.Enabled = true;
            txtEmployess.Enabled = true;
            txtPeople.Enabled = true;
            dtpkDateIn.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void DeleteText()
        {
            cbEquipmentCode.Text = String.Empty;
            txtEmployess.Text = String.Empty;
            txtID.Text = String.Empty;
            txtPeople.Text = String.Empty;
            dtpkDateIn.Text = String.Empty;
           
        }
        void AddText()
        {
            try
            {
                cbEquipmentCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["EquipmentCode"]).ToString();
                txtEmployess.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Employess"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtPeople.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["People"]).ToString();
                dtpkDateIn.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateIn"]).ToString();              
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
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            Isinsert = true;
            DeleteText();
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
            OpenControl();
            Isinsert = false;
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    EquipmentDAO.Instance.DeleteHistoryEquipment(Id);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string EquipmentCode = cbEquipmentCode.Text;
            DateTime DateIn = dtpkDateIn.Value;
            string People = txtPeople.Text;
            string Employess = txtEmployess.Text;
            if (Isinsert == true)
            {
                EquipmentDAO.Instance.InsertHistoryEquipment(EquipmentCode, DateIn, People, Employess);
                MessageBox.Show("thêm thông tin thành công !".ToString());
                LoadControl();
            }
            else
            {
                long id = long.Parse(txtID.Text);
                EquipmentDAO.Instance.UpdateHistoryEquipment(id,EquipmentCode, DateIn, People, Employess);
                MessageBox.Show("sửa thông tin thành công !".ToString());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
    }
}
