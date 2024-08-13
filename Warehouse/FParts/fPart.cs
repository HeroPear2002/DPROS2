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
using DevExpress.XtraReports.UI;
using DTO;
using WareHouse.FParts;
using WareHouse.Report;

namespace WareHouse
{
    public partial class fPart : Form
    {
        public fPart()
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
            LoadMaterial();
            LoadCustomer();
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        }
        void LoadData()
        {
            GCData.DataSource = PartDAO.Instance.GetListPart();
        }
        void KhoaDK()
        {
            txbPartCode.Enabled = false;
            txbPartName.Enabled = false;
            cbNamematerial.Enabled = false;
            cbCustonerCode.Enabled = false;
            nudCountPart.Enabled = false;
            nudCountBox.Enabled = false;
            nudCountCavi.Enabled = false;
            txbParrtWeight.Enabled = false;
            txbRunnerWeight.Enabled = false;
            txbCycleTime.Enabled = false;
            nudHeight.Enabled = false;
            txtNote.Enabled = false;
            txtNameVN.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbPartCode.Enabled = true;
            txbPartName.Enabled = true;
            cbNamematerial.Enabled = true;
            cbCustonerCode.Enabled = true;
            nudCountPart.Enabled = true;
            nudCountBox.Enabled = true;
            nudCountCavi.Enabled = true;
            txbParrtWeight.Enabled = true;
            txbRunnerWeight.Enabled = true;
            txbCycleTime.Enabled = true;
            nudHeight.Enabled = true;
            txtNote.Enabled = true;
            txtNameVN.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txbPartCode.Text = String.Empty;
            txbPartName.Text = String.Empty;
            cbNamematerial.Text = String.Empty;
            cbCustonerCode.Text = String.Empty;
            nudCountPart.Text = String.Empty;
            nudCountBox.Text = String.Empty;
            nudCountCavi.Text = String.Empty;
            txbParrtWeight.Text = String.Empty;
            txbRunnerWeight.Text = String.Empty;
            txbCycleTime.Text = String.Empty;
            nudHeight.Text = String.Empty;
            txtNote.Text = String.Empty;
            txtNameVN.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbPartCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartCode"]).ToString();
                txbPartName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PartName"]).ToString();
                cbNamematerial.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                cbCustonerCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CustomerCode"]).ToString();
                nudCountPart.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountPart"]).ToString();
                nudCountBox.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountBox"]).ToString();
                nudCountCavi.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Cavity"]).ToString();
                txbParrtWeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WeightPart"]).ToString();
                txbRunnerWeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["WeightRunner"]).ToString();
                txbCycleTime.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CycleTime"]).ToString();
                nudHeight.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Height"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                txtNameVN.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["NameVN"]).ToString();
            }
            catch
            {

            }
        }
        void LoadCustomer()
        {
            cbCustonerCode.DataSource = CustomerDAO.Instance.GetListCustomerDTO();
            cbCustonerCode.DisplayMember = "CustomerCode";
            cbCustonerCode.ValueMember = "CustomerCode";
        }
        void LoadMaterial()
        {
            cbNamematerial.Properties.DataSource = MaterialDAO.Instance.GetListMaterial();
            cbNamematerial.Properties.ValueMember = "MaterialCode";
            cbNamematerial.Properties.DisplayMember = "MaterialCode";
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
            MoKhoaDK();
            XoaText();
            IsInsert = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string partcode = txbPartCode.Text;
            string partName = txbPartName.Text;
            string materialcode = cbNamematerial.Text;
            string customer = cbCustonerCode.Text;
            string nameVN = txtNameVN.Text;
            int countBox = (int)nudCountBox.Value;
            int countPart = (int)nudCountPart.Value;
            float weight = (float)Convert.ToDouble(txbParrtWeight.Text);
            float runner = (float)Convert.ToDouble(txbRunnerWeight.Text);
            float cycleTime = (float)Convert.ToDouble(txbCycleTime.Text);
            int Cav = (int)nudCountCavi.Value;
            int height = (int)nudHeight.Value;
            float Note = (float)Convert.ToDouble(txtNote.Text);
            if (partcode == "" || partName == "" || materialcode == "")
            {
                MessageBox.Show("bạn chưa điền đầy đủ thông tin !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsInsert == true)
            {
                PartDAO.Instance.InsertPart(partcode, partName, materialcode, customer, countBox, countPart, runner, weight, cycleTime, Cav, height, Note, nameVN);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                PartDAO.Instance.UpdatePart(partcode, partName, materialcode, customer, countBox, countPart, runner, weight, cycleTime, Cav, height, Note, nameVN, "");
                MessageBox.Show("Sửa thông tin thành công !".ToUpper());
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
            MoKhoaDK();
            txbPartCode.Enabled = false;
            IsInsert = false;

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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string PartCode = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    PartDAO.Instance.DeletetPart(PartCode);
                }
                LoadControl();
            }
        }
        #endregion
        #region Inport/Export
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormPart f = new frmFormPart();
            f.ShowDialog();
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
            frmInportPart f = new frmInportPart();
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn đã xác nhận các linh kiện được phép sản xuất!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string Code = gridView1.GetRowCellValue(item, "PartCode").ToString();
                    PartDAO.Instance.ConfirmPart(Code, "Phê duyệt");
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
                string akun = PartDAO.Instance.StylePart(PartCode);
                if (akun.Length <= 6)
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.White;
                }

            }
        }
    }
}
