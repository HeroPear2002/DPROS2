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

namespace WareHouse.QC
{
    public partial class frmQCMaterial : Form
    {
        public frmQCMaterial()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            GCData.DataSource = IventoryMaterialDAO.Instance.GetListIventory().OrderBy(x => x.Lot);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn đã kiểm tra Nguyên Liệu này chưa ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int IdWH = int.Parse(gridView1.GetRowCellValue(item, "IdWH").ToString());
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWH,7);
                }
                LoadData();
            }
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn khóa Nguyên Liệu này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int IdWH = int.Parse(gridView1.GetRowCellValue(item, "IdWH").ToString());
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWH, 10);
                }
                LoadData();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.RowHandle >= 0)
            {
                long idWH = int.Parse(view.GetRowCellValue(e.RowHandle,view.Columns["IdWH"]).ToString());
                int status = WarehouseMaterialDAO.Instance.StatusWH(idWH);
                if(status == 6)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
                else if(status == 10)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn mở khóa Nguyên Liệu này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    int IdWH = int.Parse(gridView1.GetRowCellValue(item, "IdWH").ToString());
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWH, 2);
                }
                LoadData();
            }
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
