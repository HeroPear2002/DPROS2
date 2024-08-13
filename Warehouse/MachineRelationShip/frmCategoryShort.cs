using DevExpress.XtraGrid.Views.Grid;
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
using WareHouse.Common;
using System.IO;

namespace WareHouse.MachineRelationShip
{
    public partial class frmCategoryShort : Form
    {
        public frmCategoryShort()
        {
            InitializeComponent();
            LoadControl();
        }
        private bool IsInsert = false;
        #region Control() 
        void LoadControl()
        {
            LoadData();
            KhoaDK();
            LoadDevice();
        }
        void LoadData()
        {
            GcData.DataSource = MachineDAO.Instance.GetListCategoryShort().OrderBy(x => x.ConfirmCategory);
        }
        void LoadDevice()
        {
            cbDevice.DataSource = MachineDAO.Instance.GetListDevice();
            cbDevice.ValueMember = "Name";
            cbDevice.DisplayMember = "Name";
        }
        void KhoaDK()
        {
            txtName.Enabled = false;
            txtDetail.Enabled = false;
            txtMethod.Enabled = false;
            cbDevice.Enabled = false;
           

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

        }
        void MoKhoaDK()
        {
            txtName.Enabled = true;
            txtDetail.Enabled = true;
            txtMethod.Enabled = true;
            cbDevice.Enabled = true;
          

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

        }
        void XoaText()
        {
            txtDetail.Text = String.Empty;
            txtName.Text = String.Empty;
            txtID.Text = String.Empty;
            txtMethod.Text = String.Empty;
            cbDevice.Text = String.Empty;
          
        }
        void AddText()
        {
            try
            {
                txtDetail.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Detail"]).ToString();
                txtName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameCategory"]).ToString();
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                txtMethod.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Method"]).ToString();
                cbDevice.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Device"]).ToString();
               
            }
            catch
            {

            }
        }
        #endregion
        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {
            XoaText();
            IsInsert = true;
            MoKhoaDK();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            IsInsert = false;
            MoKhoaDK();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MachineDAO.Instance.DeleteCategoryTest(Id);
                    MachineDAO.Instance.DeleteRelationIdCategory(Id);
                }
                LoadControl();
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string detail = txtDetail.Text;
            string method = txtMethod.Text;
            string device = cbDevice.Text;
            string limit = "";
            int confirm = 0;
            if (checkBox.Checked == true)
            {
                confirm = 1;
            }
            else
            {
                confirm = 0;
            }
            int time = 24;
            if (IsInsert == true)
            {
                MachineDAO.Instance.InsertCategoryTest(name, detail, time, method, confirm, device, limit);
                MessageBox.Show("Thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                int Id = int.Parse(txtID.Text);
                MachineDAO.Instance.UpdateCategoryTest(Id, name, detail, time, method, confirm, device, limit);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        #endregion
        private void GcData_Click(object sender, EventArgs e)
        {
            AddText();
            try
            {
                int Id = int.Parse(txtID.Text);
                int confirm = MachineDAO.Instance.ConfirmCategory(Id);
                if (confirm == 1)
                {
                    checkBox.Checked = true;
                }
                else
                {
                    checkBox.Checked = false;
                }
            }
            catch
            {

            }

        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int Id = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Id"]).ToString());
                int confirm = MachineDAO.Instance.ConfirmCategory(Id);

                switch (confirm)
                {
                    case 1:
                        e.Appearance.BackColor = Color.DarkSlateGray;
                        e.Appearance.ForeColor = Color.White;
                        break;

                    default:
                        break;
                }
            }
        }
        private void frmDownload_Click(object sender, EventArgs e)
        {
            frmFormCategoryMachine f = new frmFormCategoryMachine();
            f.ShowDialog();
        }
        private void btnImport_Click(object sender, EventArgs e)
        {
            frmImportCategory f = new frmImportCategory();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xlsx":
                            GcData.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            GcData.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            GcData.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            GcData.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            GcData.ExportToMht(exportFilePath);
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
        }
    }
}
