using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAO;
using DTO;
using System.IO;
using System.Diagnostics;

namespace WareHouse.Product
{
    public partial class frmProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmProduct()
        {
            InitializeComponent();
            LoadControl();
        }
        public bool IsInsert = false;
        #region Control
        void LoadControl()
        {
            LoadRohs();
            LockControl();
            LoadData();
        }
        void LoadData()
        {
            GCData.DataSource = ProductDAO.Instance.ListProduct();
        }
        void LoadRohs()
        {
            List<ProductDTO> listp = ProductDAO.Instance.ListProduct();
            foreach (ProductDTO item in listp)
            {
                if (item.Note.Length > 0)
                {
                    ProductDAO.Instance.UpdateRohsProduct(item.Code, "YES");
                }
                else
                {
                    ProductDAO.Instance.UpdateRohsProduct(item.Code, "NO");
                }
            }

        }
        void LockControl()
        {
            txtCode.Enabled = false;
            txtName.Enabled = false;
            txtCount.Enabled = false;
            txtNote.Enabled = false;
            txtVendor.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void OpenControl()
        {
            txtCode.Enabled = true;
            txtName.Enabled = true;
            txtCount.Enabled = true;
            txtNote.Enabled = true;
            txtVendor.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void CleanText()
        {
            txtCode.Text = String.Empty;
            txtName.Text = String.Empty;
            txtCount.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtVendor.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Code"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Name"]).ToString();
                txtCount.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountConstan"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtVendor.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Vendor"]).ToString();
            }
            catch
            {
            }
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
            txtCode.Enabled = false; ;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "Code").ToString();
                    ProductDAO.Instance.DeleteProduct(code);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string rohs = "";
            string detail = txtNote.Text;
            if (detail.Length > 0)
            {
                rohs = "YES";
            }
            else
            {
                rohs = "NO";
            }
            float count = 0;
            try
            {
                count = (float)Convert.ToDouble(txtCount.Text);
            }
            catch
            {
                MessageBox.Show("bạn điền sai số lượng ".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProductDTO pr = new ProductDTO(txtCode.Text, txtName.Text, count, txtNote.Text, txtVendor.Text, rohs);
            if (IsInsert == true)
            {
                ProductDAO.Instance.InsertProduct(pr);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                ProductDAO.Instance.UpdateProduct(pr);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportProduct f = new frmInportProduct();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

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

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormProduct f = new frmFormProduct();
            f.ShowDialog();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void btnRohs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtNote.Text = ofd.FileName;
            }
        }
        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "Note")
            {
                string materialCode = e.CellValue.ToString();

                try
                {
                    Process.Start(materialCode);
                }
                catch
                {
                    MessageBox.Show("đường link không đúng".ToUpper());
                }
            }
        }
        #endregion


    }
}