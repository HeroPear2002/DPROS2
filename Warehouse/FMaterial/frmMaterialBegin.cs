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
using System.Data.SqlClient;
using System.IO;
using DTO;

namespace WareHouse.FMaterial
{
    public partial class frmMaterialBegin : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialBegin()
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
            LoadMaterial();
        }
        void LoadMaterial()
        {
            cbMaterialCode.DataSource = MaterialDAO.Instance.GetListMaterial();
            cbMaterialCode.ValueMember = "MaterialCode";
            cbMaterialCode.DisplayMember = "MaterialCode";
        }
        void LoadData()
        {
            GCData.DataSource = MaterialDAO.Instance.GetListMaterialBegin();
        }
        void LockControl()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

            cbMaterialCode.Enabled = false;
            txtWeightMin.Enabled = false;
            txtTimeMin.Enabled = false;
        }
        void OpenControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            cbMaterialCode.Enabled = true;
            txtWeightMin.Enabled = true;
            txtTimeMin.Enabled = true;
        }
        void ClearText()
        {
            cbMaterialCode.Text = String.Empty;
            txtWeightMin.Text = String.Empty;
            txtTimeMin.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbMaterialCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                txtWeightMin.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WeightMin"]).ToString();
                txtTimeMin.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["TimeMin"]).ToString();
            }
            catch
            {
            }
        }
        #endregion
        #region Event

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMaterialBegin f = new frmFormMaterialBegin();
            f.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ClearText();
            IsInsert = true;
            OpenControl();
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
            cbMaterialCode.Enabled = false;
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string code = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    MaterialDAO.Instance.DeleteMaterialBegin(code);
                }
                LoadControl();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string code = cbMaterialCode.Text;
            string weight = txtWeightMin.Text;
            string timeMin = txtTimeMin.Text;
            if (IsInsert == true)
            {
                try
                {
                    MaterialDAO.Instance.InsertMaterialBegin(code, weight, timeMin);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        MessageBox.Show("mã nguyên liệu đã tồn tại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MaterialDAO.Instance.UpdateMaterialBegin(code, weight, timeMin);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
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

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmImportMaterialBegin f = new frmImportMaterialBegin();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        #endregion
    }
}