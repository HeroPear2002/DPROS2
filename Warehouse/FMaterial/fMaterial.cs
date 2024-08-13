using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using WareHouse.FMaterial;
using WareHouse.Properties;
using DTO;
using System.Collections;
using WareHouse.Report;
using DevExpress.XtraReports.UI;

namespace WareHouse
{
    public partial class fMaterial : Form
    {
        public fMaterial()
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
            LoadVenderCode();
        }
        void LoadData()
        {
            GCData.DataSource = MaterialDAO.Instance.GetListMaterial();
        }
        void KhoaDK()
        {
            txbMaterialCode.Enabled = false;
            txbMaterialName.Enabled = false;
            nudQuantity.Enabled = false;
            nudCountYellow.Enabled = false;
            cbVenderCode.Enabled = false;
            txtNature.Enabled = false;
            txtRoHS.Enabled = false;
            btnRohs.Enabled = false;
            txtColorCode.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txbMaterialCode.Enabled = true;
            txbMaterialName.Enabled = true;
            nudQuantity.Enabled = true;
            nudCountYellow.Enabled = true;
            cbVenderCode.Enabled = true;
            txtNature.Enabled = true;
            txtRoHS.Enabled = true;
            btnRohs.Enabled = true;
            txtColorCode.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txbMaterialCode.Text = String.Empty;
            txbMaterialName.Text = String.Empty;
            nudQuantity.Text = String.Empty;
            nudCountYellow.Text = String.Empty;
            cbVenderCode.Text = String.Empty;
            txtNature.Text = String.Empty;
            txtRoHS.Text = String.Empty;
            txtColorCode.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txbMaterialCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                txbMaterialName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialName"]).ToString();
                nudCountYellow.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountRed"]).ToString();
                nudCountYellow.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["CountYellow"]).ToString();
                cbVenderCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["VenderCode"]).ToString();
                txtNature.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Nature"]).ToString();
                txtRoHS.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["RohsFile"]).ToString();
                txtColorCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["ColorCode"]).ToString();
            }
            catch
            {

            }
        }
        void LoadVenderCode()
        {
            cbVenderCode.DataSource = VendorDAO.Instance.GetListVender();
            cbVenderCode.DisplayMember = "VenderCode";
            cbVenderCode.ValueMember = "VenderCode";
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
            Isinsert = true;
            XoaText();
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
            Isinsert = false;
            txbMaterialCode.Enabled = false;
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
                    string MaterialCode = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    MaterialDAO.Instance.DeleteMaterial(MaterialCode);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string materialCode = txbMaterialCode.Text;
            string materialName = txbMaterialName.Text;
            int red = (int)nudQuantity.Value;
            int countYellow = (int)nudCountYellow.Value;
            string venderCode = cbVenderCode.Text;
            string Nature = txtNature.Text;
            string rohs = txtRoHS.Text;
            string ColorCode = txtColorCode.Text;
            if (Isinsert == true)
            {
                if(MaterialDAO.Instance.TestMaterialByCode(materialCode) == 1)
                {
                    MessageBox.Show("mã nguyên liệu đã tồn tại!".ToUpper(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
                MaterialDAO.Instance.InsertMaterial(materialCode, materialName, countYellow, red, venderCode, Nature, rohs, ColorCode);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                MaterialDAO.Instance.UpdateMaterial(materialCode, materialName, countYellow, red, venderCode, Nature, rohs, ColorCode);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }
        #endregion
        #region Inport
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormMaterial f = new frmFormMaterial();
            f.ShowDialog();
        }
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
        private void btnInport_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmInportMaterial f = new frmInportMaterial();
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

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            frmBatrcodeMaterial f = new frmBatrcodeMaterial();
            f.ShowDialog();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                string materialCode = view.GetRowCellValue(e.RowHandle, view.Columns["MaterialCode"]).ToString();
                string status = MaterialDAO.Instance.RohsFile(materialCode);
                if (status.Length > 0)
                {
                    IventoryMaterialDAO.Instance.UpdateRosh(materialCode, "YES");
                }
                else
                {
                    IventoryMaterialDAO.Instance.UpdateRosh(materialCode, "NO");
                }

            }
        }

        private void btnRohs_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtRoHS.Text = ofd.FileName;
            }
        }

        private void btnBarCodeTC_Click(object sender, EventArgs e)
        {
            ArrayList listMaterial = new ArrayList();
            string strDate = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString();
            string MateriCode = txbMaterialCode.Text;
            string name = txbMaterialName.Text;
            for (int i = 1; i <= 80; i++)
            {
                string barcode = MateriCode + "&" + strDate + "&" +i+"&"+"TC";
                listMaterial.Add(new BarcodeMaterial(MateriCode, name, i, barcode, "", strDate, ""));
            }
            rpMaterialTC report = new rpMaterialTC();
            report.DataSource = listMaterial;
            report.LoadData();
            report.PrintDialog();
        }

        private void btnBarCodeHH_Click(object sender, EventArgs e)
        {
            ArrayList listMaterial = new ArrayList();
            string strDate = DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString();
            string MateriCode = txbMaterialCode.Text;
            string name = txbMaterialName.Text;
            for (int i = 1; i <= 80; i++)
            {
                string barcode = MateriCode + "&" + strDate + "&" + i;
                listMaterial.Add(new BarcodeMaterial(MateriCode, name, i, barcode, "", strDate, ""));
            }
            rpMaterialHH report = new rpMaterialHH();
            report.DataSource = listMaterial;
            report.LoadData();
            report.PrintDialog();
        }

        private void btnNoNeed_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn xác nhận nguyên liệu nào không quản lý rohs".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string materialCode = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    MaterialDAO.Instance.UpdateMaterial(materialCode, "NO NEED");
                }
                LoadControl();
            }
        }

        private void btnPrintKanban_Click(object sender, EventArgs e)
        {
            List<MaterialDTO> listM = new List<MaterialDTO>();
            List<PartDTO> listP = new List<PartDTO>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                string materialCode = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                MaterialDTO materialDTO = MaterialDAO.Instance.GetItemMaterial(materialCode);
                listP = PartDAO.Instance.GetListPart(materialCode);
                string part = "";
                foreach (PartDTO itemP in listP)
                {
                    part = part + itemP.PartCode + ";";
                }
                part = part.Substring(0,part.Length - 1);
                listM.Add(new MaterialDTO(materialDTO.MaterialCode, materialDTO.MaterialName,
                    materialDTO.CountYellow, materialDTO.CountRed, materialDTO.VenderCode, materialDTO.Nature,
                    part, materialDTO.ColorCode));
            }
            rpKanbanMaterial rp = new rpKanbanMaterial();
            rp.DataSource = listM;
            rp.Print();
        }
    }
}
