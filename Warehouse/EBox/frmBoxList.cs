using DevExpress.XtraReports.UI;
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
using WareHouse.Report;

namespace WareHouse.EBox
{
    public partial class frmBoxList : Form
    {
        public frmBoxList()
        {
            InitializeComponent();
            LoadControl();
            LoadColum();
        }
        public bool IsInsert = false;
        void LoadColum()
        {
            gridView1.Columns["BoxIventory"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "BoxIventory", "Tổng = {0}");
        }
        #region Control
        void LoadControl()
        {
            DeleteReBox();
            LoadData();
            KhoaDK();
            XoaText();
       
        }
        void LoadData()
        {
            GCData.DataSource = BoxDAO.Instance.GetListBox();
        }

        void KhoaDK()
        {
            txtBoxCode.Enabled = false;
            txtBoxName.Enabled = false;
            txtStyle.Enabled = false;
            nudIventory.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;
        }
        void MoKhoaDK()
        {
            txtBoxCode.Enabled = true;
            txtBoxName.Enabled = true;
            txtStyle.Enabled = true;
            nudIventory.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void XoaText()
        {
            txtBoxCode.Text = String.Empty;
            txtBoxName.Text = String.Empty;
            txtStyle.Text = String.Empty;
            nudIventory.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                txtBoxCode.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["BoxCode"]).ToString();
                txtBoxName.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["BoxName"]).ToString();
                txtStyle.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["StyleBox"]).ToString();
                nudIventory.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["BoxIventory"]).ToString();
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
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            IsInsert = true;
            XoaText();
            MoKhoaDK();
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
            IsInsert = false;
            txtBoxCode.Enabled = false;
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
            if (MessageBox.Show("bạn thực sự muốn xóa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string BoxCode = gridView1.GetRowCellValue(item, "BoxCode").ToString();
                    BoxDAO.Instance.DeleteListBox(BoxCode);
                }
                LoadControl();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string BoxCode = txtBoxCode.Text;
            string BoxName = txtBoxName.Text;
            string style = txtStyle.Text;
            int iventory = (int)nudIventory.Value;
            if(IsInsert == true)
            {
                BoxDAO.Instance.InsertListBox(BoxCode, BoxName, style, iventory);
                MessageBox.Show("thêm thông tin thành công !".ToUpper());
                LoadControl();
            }
            else
            {
                BoxDAO.Instance.UpdateListBox(BoxCode, BoxName, style, iventory);
                MessageBox.Show("sửa thông tin thành công !".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnReBox_Click(object sender, EventArgs e)
        {
            frmReBox f = new frmReBox();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnBarCode_Click(object sender, EventArgs e)
        {
            List<BoxListDTO> listB = new List<BoxListDTO>();
           
            if(txtBoxCode.Text.Length >0)
            {
                for (int i = 0; i < 52; i++)
                {
                    listB.Add(new BoxListDTO(txtBoxCode.Text, txtBoxName.Text, txtStyle.Text, (int)nudIventory.Value));
                }
                rpBarCodeBox report = new rpBarCodeBox();
                report.DataSource = listB;
                report.PrintDialog();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn mã hộp cần in !".ToUpper());
            }
        }
        #endregion
        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormBoxList f = new frmFormBoxList();
            f.ShowDialog();
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
            frmInportBoxList f = new frmInportBoxList();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
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
        public class BoxList
        {
            public static string boxCode;
        }
        private void GCData_DoubleClick(object sender, EventArgs e)
        {
            BoxList.boxCode = txtBoxCode.Text;
            frmBoxTotal f = new frmBoxTotal();
            f.ShowDialog();
        }
        void DeleteReBox()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Today;
            BoxDAO.Instance.DeleteReBox(today.AddMonths(-2));
        }
    }
}
