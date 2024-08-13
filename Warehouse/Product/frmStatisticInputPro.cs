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
using DTO;
using DAO;
using System.Globalization;
using System.IO;
using WareHouse.DataMachine;

namespace WareHouse.Product
{
    public partial class frmStatisticInputPro : DevExpress.XtraEditors.XtraForm
    {

        public frmStatisticInputPro()
        {
            InitializeComponent();
            LoadControl();
            
        }
        #region LoadControl
        void LoadControl()
        {
            LoadProduct();
            LoadData();
            LoadDate();
        }
        void LoadProduct()
        {
            List<ProductDTO> listP = ProductDAO.Instance.ListProduct();
            cbProductCode.DataSource = listP;
            cbProductCode.DisplayMember = "Code";
            cbProductCode.ValueMember = "Code";
        }
        void LoadData()
        {
            GCData.DataSource = ProductDAO.Instance.ListInputProduct();
        }
        void LoadDate()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = DateTime.Now.Date;
            dtpkTo.Value = today.AddDays(-today.Day+1);
            dtpkFrom.Value = dtpkTo.Value.AddMonths(1).AddDays(-1).AddHours(23);
        }
        #endregion
        #region Event
        private void btnView_Click(object sender, EventArgs e)
        {
            GCData.DataSource = ProductDAO.Instance.ListInputProductByDate(dtpkTo.Value, dtpkFrom.Value);

        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string code = cbProductCode.Text;
            DateTime date = dtpkDateInput.Value;
            string em = Kun_Static.accountDTO.UserName;
            string note = txtNote.Text;
            float count = (float)Math.Round(Convert.ToDouble(txtCountInput.Text),2);
            if(MessageBox.Show("bạn muốn nhập kho !".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question) == DialogResult.OK)
            {
                ProductDAO.Instance.InsertIputProduct(code, date, em, 0, note, count);
                LoadControl();
            }
       
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportInput f = new frmInportInput();
            f.LamMoi += new EventHandler(btnView_Click);
            f.ShowDialog();
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

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmFormInputProduct f = new frmFormInputProduct();
            f.ShowDialog();
        }
    }
}