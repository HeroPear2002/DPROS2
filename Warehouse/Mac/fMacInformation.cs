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
using DevExpress.XtraGrid.Views.Grid;
using DTO;
using WareHouse.Mac;

namespace WareHouse
{
    public partial class fMacInformation : Form
    {

        public fMacInformation()
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
            LoadPart();
            LoadMold();
            LoadMachine();
            LoadFactory();
        }
        void LoadData()
        {
            GCData.DataSource = MacInforDAO.Instance.GetListMac();
        }
        void KhoaDK()
        {
            cbPartCode.Enabled = false;
            cbMoldCode.Enabled = false;
            cbMachineCode.Enabled = false;
            txtRev.Enabled = false;
            cbFactoryCode.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            cbPartCode.Enabled = true;
            cbMoldCode.Enabled = true;
            cbMachineCode.Enabled = true;
            txtRev.Enabled = true;
            cbFactoryCode.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            cbPartCode.Text = String.Empty;
            txtId.Text = String.Empty;
            cbMoldCode.Text = String.Empty;
            cbMachineCode.Text = String.Empty;
            txtRev.Text = String.Empty;
            cbFactoryCode.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                cbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                txtId.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
                cbMoldCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MoldCode"]).ToString();
                cbMachineCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MachineCode"]).ToString();
                txtRev.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Rev"]).ToString();
                cbFactoryCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["FactoryCode"]).ToString();
                string a = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Standard"]).ToString();
                if (a == "OK")
                {
                    ckb4M.Checked = true;
                }
                else
                {
                    ckb4M.Checked = false;
                }
            }
            catch
            {

            }
        }
        void LoadPart()
        {
            cbPartCode.DataSource = PartDAO.Instance.GetListPart();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
        }
        void LoadMold()
        {
            cbMoldCode.DataSource = MoldDAO.Instance.GetListMold();
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
        }
        void LoadMachine()
        {
            cbMachineCode.DataSource = MachineDAO.Instance.GetListMachine();
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        void LoadFactory()
        {
            cbFactoryCode.DataSource = FactoryDAO.Instance.GetListDistinctAllFactory();
            cbFactoryCode.DisplayMember = "FactoryCode";
            cbFactoryCode.ValueMember = "FactoryCode";
        }
        #endregion
        #region Event        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            Isinsert = true;
            XoaText();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MoKhoaDK();
            Isinsert = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string partCode = cbPartCode.Text.ToUpper();
            string machineCode = cbMachineCode.Text.ToUpper();
            string Rev = txtRev.Text;
            if (MachineDAO.Instance.TestMachineByCode(machineCode) == -1)
            {
                MessageBox.Show("Mã máy không đúng bạn hãy kiểm tra lại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string moldCode = cbMoldCode.Text.ToUpper();
            if (MoldDAO.Instance.TestMoldByCode(moldCode) == -1)
            {
                MessageBox.Show("Mã khuôn không đúng bạn hãy kiểm tra lại !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string factoryCode = cbFactoryCode.Text;
            string standard = "NOT";
            if (ckb4M.Checked == true)
            {
                standard = "OK";
            }
            string stylePart = PartDAO.Instance.StylePart(partCode);
            if (Isinsert == true)
            {
                if (stylePart.Length < 6)
                {
                    MessageBox.Show("linh kiện chưa được phê duyệt ! \n\nbạn hãy liên lạc với cấp trên".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int test = MacInforDAO.Instance.TestMacByAll(partCode, machineCode, moldCode);
                    if (test == -1)
                    {
                        MacInforDAO.Instance.InsertMac(partCode, machineCode, moldCode, Rev, factoryCode, standard);
                        MessageBox.Show("thêm thông tin thành công !".ToUpper());
                        LoadControl();
                    }
                }

            }
            else
            {
                int Id = int.Parse(txtId.Text);
                MacInforDAO.Instance.UpdateMac(Id, partCode, machineCode, moldCode, Rev, factoryCode, standard);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?", "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int Id = int.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MacInforDAO.Instance.DeleteMac(Id);
                }
                LoadControl();
            }
        }
        #endregion
        private void btnExport_Click(object sender, EventArgs e)
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
        private void btnPrintCodeBox_Click(object sender, EventArgs e)
        {
            frmPrinterMac f = new frmPrinterMac();
            f.ShowDialog();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportMac f = new frmInportMac();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMac f = new frmFormMac();
            f.ShowDialog();
        }

        private void btnMacNew_Click(object sender, EventArgs e)
        {
            frmPrinterMacNew f = new frmPrinterMacNew();
            f.ShowDialog();
        }

        private void btnPrintMacTKG_Click(object sender, EventArgs e)
        {
            frmMacTKG f = new frmMacTKG();
            f.ShowDialog();
        }

        private void btnCav_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("linh kiện này sẽ phải thêm số CAV khi in mác !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string partCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    MacInforDAO.Instance.UpdateMacInportant(partCode, 1);
                }
                LoadControl();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {

                string PartCode = view.GetRowCellValue(e.RowHandle, view.Columns["PartCode"]).ToString();
                int akun = MacInforDAO.Instance.ImportantMac(PartCode);
                if (akun == 1)
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.White;
                }

            }
        }

        private void btnNotImporttant_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn thay đổi thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string partCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    MacInforDAO.Instance.UpdateMacInportant(partCode, 0);
                }
                LoadControl();
            }
        }

        private void btnPrinTemma_Click(object sender, EventArgs e)
        {
            frmMacTemma f = new frmMacTemma();
            f.ShowDialog();
        }
    }
}
