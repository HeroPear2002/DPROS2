using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Mold;

namespace WareHouse
{
    public partial class fMold : Form
    {

        public fMold()
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
            GCData.DataSource = MoldDAO.Instance.GetListMold();
        }
        void KhoaDK()
        {
            txbMoldCode.Enabled = false;
            txbMoldName.Enabled = false;
            txbMoldNumber.Enabled = false;
            txtModel.Enabled = false;
            txtMaker.Enabled = false;
            txtInputWhere.Enabled = false;
            txtEmployess.Enabled = false;
            txtNote.Enabled = false;
            dtpkDateInput.Enabled = false;
            dtpkDateSX.Enabled = false;
            nudShot.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbMoldCode.Enabled = true;
            txbMoldName.Enabled = true;
            txbMoldNumber.Enabled = true;
            txtModel.Enabled = true;
            txtMaker.Enabled = true;
            txtInputWhere.Enabled = true;
            txtEmployess.Enabled = true;
            txtNote.Enabled = true;
            dtpkDateInput.Enabled = true;
            dtpkDateSX.Enabled = true;
            nudShot.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txbMoldCode.Text = String.Empty;
            txbMoldName.Text = String.Empty;
            txbMoldNumber.Text = String.Empty;
            txtModel.Text = String.Empty;
            txtMaker.Text = String.Empty;
            txtInputWhere.Text = String.Empty;
            txtEmployess.Text = String.Empty;
            txtNote.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
            dtpkDateSX.Text = String.Empty;
            nudShot.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                txbMoldName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldName"]).ToString();
                txbMoldNumber.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldNumber"]).ToString();
                txtModel.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldModel"]).ToString(); ;
                txtMaker.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Maker"]).ToString(); ;
                txtInputWhere.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["InputWhere"]).ToString(); ;
                txtEmployess.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Employess"]).ToString(); ;
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString(); ;
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString(); ;
                dtpkDateSX.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateSX"]).ToString(); ;
                nudShot.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ShotCount"]).ToString(); ;
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
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            XoaText();
            IsInsert = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string moldCode= txbMoldCode.Text;
            string moldName = txbMoldName.Text;
            string moldNumber = txbMoldNumber.Text;
            string MoldModel = txtModel.Text;
            string Maker = txtMaker.Text;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime DateInput = dtpkDateInput.Value;
            string InputWhere = txtInputWhere.Text;
            DateTime DateSX = dtpkDateSX.Value;
            int ShotCount = (int)nudShot.Value;
            string Employess = txtEmployess.Text;
            string Note = txtNote.Text;
            if (IsInsert == true)
            {
                MoldDAO.Instance.InsertMold(moldCode,moldName,moldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
                MessageBox.Show("thêm thông tin thành công!".ToUpper());
                LoadControl();
            }
            else
            {
                MoldDAO.Instance.UpdatetMold(moldCode, moldName, moldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            txbMoldCode.Enabled = false;
            IsInsert = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(5, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string MoldCode = gridView1.GetRowCellValue(item, "MoldCode").ToString();
                    MoldDAO.Instance.DeleteMold(MoldCode);
                }
                LoadControl();
            }
        }
        #endregion
        #region Inport/Export

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMold f = new frmFormMold();
            f.ShowDialog();
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportMold f = new frmInportMold();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        #endregion

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
    }
}
