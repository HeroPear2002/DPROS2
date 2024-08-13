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
using DTO;
using System.IO;

namespace WareHouse
{
    public partial class frmAdminHistory : DevExpress.XtraEditors.XtraForm
    {
        private static frmAdminHistory instance;

        public static frmAdminHistory Instance { get {
                if(instance == null || instance.IsDisposed)
                {
                    instance = new frmAdminHistory();
                }
                else
                {
                    instance.Activate();
                }
                return instance; } set => instance = value; }

        public frmAdminHistory()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            GCData.DataSource = EditHistoryDAO.Instance.GetListData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventoryStart1();
            //foreach (IventoryMaterialDTO item in listI)
            //{
            //    IventoryMaterialDAO.Instance.UpdateStartReInputMaterial(item.Id,1);
            //}
            LoadControl();
            MessageBox.Show("Cập nhật thành công !".ToUpper());
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