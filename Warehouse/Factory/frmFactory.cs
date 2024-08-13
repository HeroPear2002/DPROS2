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

namespace WareHouse.Factory
{
    public partial class frmFactory : DevExpress.XtraEditors.XtraForm
    {
        public frmFactory()
        {
            InitializeComponent();
            LoadControl();
        }
        bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadCustomer();
        }
        void LoadData()
        {
            GCData.DataSource = FactoryDAO.Instance.GetListAllFactory();
        }
        void LockControl()
        {
            txtFacCode.Enabled = false;
            txtFacName.Enabled = false;
            txtCodeCus.Enabled = false;
            cbCustomerCode.Enabled = false;
            txtNameBillVN.Enabled = false;
            txtNameBillENG.Enabled = false;
            txtPhone.Enabled = false;
            txtAddress.Enabled = false;
            txtFaxNumber.Enabled = false;
            txtMST.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtFacCode.Enabled = true;
            txtFacName.Enabled = true;
            txtCodeCus.Enabled = true;
            cbCustomerCode.Enabled = true;
            txtNameBillVN.Enabled = true;
            txtNameBillENG.Enabled = true;
            txtPhone.Enabled = true;
            txtAddress.Enabled = true;
            txtFaxNumber.Enabled = true;
            txtMST.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            cbCustomerCode.Text = String.Empty;
            txtFacName.Text = String.Empty;
            txtFacCode.Text = String.Empty;
            txtCodeCus.Text = String.Empty;
            txtNameBillVN.Text = String.Empty;
            txtNameBillENG.Text = String.Empty; 
            txtPhone.Text = String.Empty; 
            txtAddress.Text = String.Empty;
            txtFaxNumber.Text = String.Empty;
            txtMST.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbCustomerCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameCustomer"]).ToString();
                txtFacName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryName"]).ToString();
                txtFacCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
                txtCodeCus.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CodeCustomer"]).ToString();
                txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtNameBillVN.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameBillVN"]).ToString();
                txtNameBillENG.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameBillENG"]).ToString();
                txtPhone.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Phone"]).ToString();
                txtAddress.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Address"]).ToString();
                txtFaxNumber.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FaxNumber"]).ToString();
                txtMST.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MST"]).ToString();
            }
            catch
            {

            }
        }
        void LoadCustomer()
        {
            cbCustomerCode.DataSource = CustomerDAO.Instance.GetListCustomerDTO();
            cbCustomerCode.DisplayMember = "CustomerCode";
            cbCustomerCode.ValueMember = "CustomerCode";
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
            IsInsert = true;
            OpenControl();
            ClearText();
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
            if (MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    FactoryDAO.Instance.DeleteFactory(id);
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
            IsInsert = false;
            OpenControl();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string facCode = txtFacCode.Text;
            string facName = txtFacName.Text;
            string cusCode = txtCodeCus.Text;
            string cusName = cbCustomerCode.Text;
            if(CustomerDAO.Instance.TestCustomerDTO(cusName) == -1)
            {
                MessageBox.Show("mã khách hàng không đúng !\n bạn hãy kiểm tra lại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string NameBill = txtNameBillVN.Text;
            string NameBillENG = txtNameBillENG.Text;
            string Address = txtAddress.Text;
            string Phone = txtPhone.Text;
            string FaxNumber = txtFaxNumber.Text;
            string MST = txtMST.Text;
            if (IsInsert == true)
            {
                if (FactoryDAO.Instance.TestFactory(facCode, cusCode) == -1)
                {
                    FactoryDAO.Instance.InsertFactory(facCode, facName, cusCode, cusName, NameBill,NameBillENG, Address, Phone, FaxNumber, MST);
                    LoadControl();
                }
                else
                {
                    MessageBox.Show("thông tin đã tồn tại !\n bạn hãy kiểm tra lại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                int id = int.Parse(txtId.Text);
                FactoryDAO.Instance.UpdateFactory(id, facCode, facName, cusCode, cusName, NameBill, NameBillENG, Address, Phone, FaxNumber, MST);
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