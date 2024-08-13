using DevExpress.XtraEditors;
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

namespace WareHouse
{
    public partial class fSupplier : Form
    {

        public fSupplier()
        {
     
            InitializeComponent();
            LoadControl();
        }
        public bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            KhoaDK();
        }
        void LoadData()
        {
            GCData.DataSource = VendorDAO.Instance.GetListVender();
        }
        void KhoaDK()
        {
            txbVenderCode.Enabled = false;
            txtVenderName.Enabled = false;
            txbAddress.Enabled = false;
            txbPhone.Enabled = false;
            txtContactPerson.Enabled = false;
            txtFaxNumber.Enabled = false;

            btnAddSupplier.Enabled = true;
            btnEditSupplier.Enabled = true;
            btnDeleteSupplier.Enabled = true;
            btnSaveSupplier.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbVenderCode.Enabled = true;
            txtVenderName.Enabled = true;
            txbAddress.Enabled = true;
            txbPhone.Enabled = true;
            txtContactPerson.Enabled = true;
            txtFaxNumber.Enabled = true;

            btnAddSupplier.Enabled = false;
            btnEditSupplier.Enabled = false;
            btnDeleteSupplier.Enabled = false;
            btnSaveSupplier.Enabled = true;
        }
        void XoaText()
        {
            txbVenderCode.Text = String.Empty;
            txtVenderName.Text = String.Empty;
            txbAddress.Text = String.Empty;
            txbPhone.Text = String.Empty;
            txtContactPerson.Text = String.Empty; 
            txtFaxNumber.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbVenderCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["VenderCode"]).ToString();
                txtVenderName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["VenderName"]).ToString();
                txbAddress.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Address"]).ToString();
                txbPhone.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Phone"]).ToString();
                txtContactPerson.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ContactPerson"]).ToString();
                txtFaxNumber.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FaxNumber"]).ToString();
            }
            catch 
            {

            }
        }
        #endregion
        #region Event
        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            XoaText();
            Isinsert = true;
        }

        private void btnEditSupplier_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            txbVenderCode.Enabled = false;
            Isinsert = false;
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            string venderCode = txbVenderCode.Text;
            string venderName = txtVenderName.Text;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;
            string contact = txtContactPerson.Text;
            string fax = txtFaxNumber.Text;
            if(Isinsert == true)
            {
                VendorDAO.Instance.InsertVendor(venderCode, venderName, address, phone,contact,fax);
                XtraMessageBox.Show("thêm thông tin thành công!".ToUpper());
                LoadControl();
            }
            else
            {
                VendorDAO.Instance.UpdateVendor(venderCode, venderName, address, phone,contact,fax);
                XtraMessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnDeleteSupplier_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (XtraMessageBox.Show("bạn thực sự muốn xóa thông tin này?","Thông Báo",MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string vendercode = gridView1.GetRowCellValue(item, "VenderCode").ToString();
                    VendorDAO.Instance.DeleteVendor(vendercode);
                }
                LoadControl();
            }
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        #endregion
        #region Inport
        private void btnDownload_Click(object sender, EventArgs e)
        {

        }

        private void btnInport_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        #endregion


    }
}
