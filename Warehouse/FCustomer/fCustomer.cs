using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse
{
    public partial class fCustomer : Form
    {
        public fCustomer()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadData();
            KhoaDK();
        }
        void LoadData()
        {
            GCData.DataSource = CustomerDAO.Instance.GetListCustomerDTO();
        }
        void KhoaDK()
        {
            txbCustomerCode.Enabled = false;
            txbCustomerName.Enabled = false;
            txbAddress.Enabled = false;
            txbPhone.Enabled = false;
            nudPOInput.Enabled = false;
            nudPOFix.Enabled = false;
            nudOther.Enabled = false;

            btnAddSupplier.Enabled = true;
            btnEditCustomer.Enabled = true;
            btnDeleteSupplier.Enabled = true;
            btnSaveSupplier.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbCustomerCode.Enabled = true;
            txbCustomerName.Enabled = true;
            txbAddress.Enabled = true;
            txbPhone.Enabled = true;
            nudPOInput.Enabled = true;
            nudPOFix.Enabled = true;
            nudOther.Enabled = true;

            btnAddSupplier.Enabled = false;
            btnEditCustomer.Enabled = false;
            btnDeleteSupplier.Enabled = false;
            btnSaveSupplier.Enabled = true;
        }
        void XoaText()
        {
            txbCustomerCode.Text = String.Empty;
            txbCustomerName.Text = String.Empty;
            txbAddress.Text = String.Empty;
            txbPhone.Text = String.Empty;
            nudPOInput.Text = String.Empty;
            nudPOFix.Text = String.Empty;
            nudOther.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbCustomerCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CustomerCode"]).ToString();
                txbCustomerName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CustomerName"]).ToString();
                txbAddress.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Address"]).ToString();
                txbPhone.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Phone"]).ToString();
                nudPOInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WarnPOInput"]).ToString();
                nudPOFix.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WarnPOFix"]).ToString();
                nudOther.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Other"]).ToString();
            }
            catch 
            {
            }
        }
        #endregion
        #region Envent
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
            IsInsert = true;
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            txbCustomerCode.Enabled = false;
            IsInsert = false;
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
            if (XtraMessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel)== DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string CustomerCode = gridView1.GetRowCellValue(item, "CustomerCode").ToString();
                    CustomerDAO.Instance.DeleteCustomer(CustomerCode);
                }
                LoadControl();
            }
        }

        private void btnSaveSupplier_Click(object sender, EventArgs e)
        {
            string customercode = txbCustomerCode.Text;
            string customername = txbCustomerName.Text;
            string address = txbAddress.Text;
            string phone = txbPhone.Text;
            int poinput = (int)nudPOInput.Value;
            int pofix = (int)nudPOFix.Value;
            int other = (int)nudOther.Value;
            if (IsInsert == true)
            {
                if(CustomerDAO.Instance.TestCustomerDTO(customercode) == 1)
                {
                    XtraMessageBox.Show("mã khách hàng đã tồn tại !".ToUpper(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                CustomerDAO.Instance.InsertCustomer(customercode, customername, address, phone,poinput,pofix,other);
                XtraMessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                CustomerDAO.Instance.UpdateCustomer(customercode, customername, address, phone, poinput, pofix, other);
                XtraMessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        #endregion
        #region Inport Excel
        private void btnDownload_Click(object sender, EventArgs e)
        {
            #region Xuất Excel
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            GCData.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            GCData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            GCData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            GCData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            GCData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            GCData.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch
                        {
                            String msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                            MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        String msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        MessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            #endregion
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
