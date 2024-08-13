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

namespace WareHouse.PO_and_Order
{
    public partial class frmPOOutput : Form
    {
        public frmPOOutput()
        {
            InitializeComponent();
            LoadControl();

        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1-(today.Day));
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-10);
        }
        void LoadControl()
        {
            LoadDate();
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            LoadData(date1,date2);
        }
        void LoadData(DateTime date1, DateTime date2)
        {
            GCData.DataSource = PODAO.Instance.GetListOutput(date1, date2);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            LoadData(date1, date2);
        }


       
    }
}
