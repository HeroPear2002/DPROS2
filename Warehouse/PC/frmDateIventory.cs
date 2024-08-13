using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.PC
{
    public partial class frmDateIventory : Form
    {
        public frmDateIventory()
        {
            InitializeComponent();
            LoadControl();
        }
        #region Control
        void LoadControl()
        {
            LockControl();
            DeleteData();
            LoadData();
        }
        void LockControl()
        {

        }
        void DeleteData()
        {
            List<TotalLKDTO> listT = TableCountDateDAO.Instance.GetListTable();
            foreach (TotalLKDTO item in listT)
            {
                DateTime today = DateTime.Today;
                if(item.Date < today.AddDays(-1))
                {
                    TableCountDateDAO.Instance.DeleteTableCoutDate(item.Id);
                }
            }
        }
        void LoadData()
        {
            GCData.DataSource = TableCountDateDAO.Instance.GetListTable();
        }
        #endregion

        #region Event


        #endregion

        private void btnInputPO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InportDateIventory f = new InportDateIventory();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmProgress f = new frmProgress();
            Thread t = new Thread(() =>
            {
                LoadUpdate();
            });
            f.ShowDialog();
            LoadControl();
        }
        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Today;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                DateTime date = DateTime.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["Date"]).ToString());
                if (date > today)
                {

                }
                else
                {
                    e.Appearance.BackColor = Color.Gray;
                    e.Appearance.ForeColor = Color.Black;
                }

            }
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int rowHandle = (GCData.FocusedView as GridView).FocusedRowHandle;
            GridView view = sender as GridView;
            if (!(view.IsDataRow(rowHandle))) return;
            if (e.RowHandle >= 0 && e.Column.FieldName == "CountDate")
            {
                int countDate = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["CountDate"]).ToString());
                if (countDate == 3 || countDate == 4)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (countDate == 2)
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (countDate == 1)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.Yellow;
                }
                else if (countDate == 0)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
            }
            if (e.RowHandle >= 0 && e.Column.FieldName == "CountDateNow")
            {
                int countDate = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["CountDateNow"]).ToString());
                if (countDate == 3 || countDate == 4)
                {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (countDate == 2)
                {
                    e.Appearance.BackColor = Color.Orange;
                    e.Appearance.ForeColor = Color.Black;
                }
                else if (countDate == 1)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.Yellow;
                }
                else if (countDate == 0)
                {
                    e.Appearance.BackColor = Color.Black;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
        void LoadUpdate()
        {
            DateTime Date1 = DateTime.Now.Date;
            DateTime Date2 = Date1.AddDays(15);
            List<TotalLKDTO> listTotal = TableCountDateDAO.Instance.GetListTable();
            var noduplicates = listTotal.Select(x => x.PartCode).Distinct().ToList();

            foreach (var item1 in noduplicates)
            {
                int dem = 0;
                int TotalNow = 0;
                string product = item1;
                int day1 = 0;
                int day2 = 0;
                int day3 = 0;
                int day4 = 0;
                foreach (TotalLKDTO item in listTotal.Where(x => x.PartCode == product).Where(y=>y.Date>=Date1).Where(y => y.Date <= Date2))
                {

                    DateTime dateL = item.Date;
                    string sd = item.Date.DayOfWeek.ToString();
                    if (sd == "Sunday")
                    {
                        // làm sau
                    }
                    else
                    {
                        switch (sd)
                        {
                            case "Wednesday":
                                {
                                    day1 = 1; day2 = 2; day3 = 3; day4 = 5;
                                }
                                break;
                            case "Thursday":
                                {
                                    day1 = 1; day2 = 2; day3 = 4; day4 = 5;
                                }
                                break;
                            case "Friday":
                                {
                                    day1 = 1; day2 = 3; day3 = 4; day4 = 5;
                                }
                                break;
                            case "Saturday":
                                {
                                    day1 = 2; day2 = 3; day3 = 4; day4 = 5;
                                }
                                break;
                            default:
                                {
                                    day1 = 1; day2 = 2; day3 = 3; day4 = 4;
                                }
                                break;
                        }
                    }
                    int tongtonNow = 0;
                    int total5 = listTotal.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day4 +1)).Sum(x => x.Output);
                    int total4 = listTotal.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day3 +1)).Sum(x => x.Output);
                    int total3 = listTotal.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day2 +1)).Sum(x => x.Output);
                    int total2 = listTotal.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day1 +1)).Sum(x => x.Output);
                    int total1 = listTotal.Where(x => x.PartCode == product).Where(x => x.Date == dateL.AddDays(1)).Sum(x => x.Output);
                    int outp = listTotal.Where(x => x.PartCode == product).Where(x => x.Date == dateL.AddDays(-1)).Sum(x => x.Output);
                    if (dem == 0)
                    {
                        tongtonNow = IventoryPartDAO.Instance.TotallPartAllStatus(product);
                    }
                    else
                    {
                        tongtonNow = TotalNow;
                    }
                    int Input = IventoryPartDAO.Instance.TotalInputbyDate(item.PartCode, item.Date.AddHours(8), item.Date.AddHours(8).AddDays(1));
                    int InputNow = item.InputNow;
                    int CountDateNow = item.CountDateNow;
                    TotalNow = tongtonNow ;
                    #region Count DateNow
                    if ((TotalNow - total1) < 0)
                    {
                        CountDateNow = 0;
                    }
                    else if ((TotalNow - total2) < 0)
                    {
                        CountDateNow = 1;
                    }
                    else if ((TotalNow - total3) < 0)
                    {
                        CountDateNow = 2;
                    }
                    else if ((TotalNow - total4) < 0)
                    {
                        CountDateNow = 3;
                    }
                    else if ((TotalNow - total5) < 0)
                    {
                        CountDateNow = 4;

                    }
                    else if (TotalNow == total5)
                    {
                        CountDateNow = 5;
                    }
                    else
                    {
                        CountDateNow = 5;
                    }
                    #endregion
                    TableCountDateDAO.Instance.UpdateTableCountDateNow(item.Id, TotalNow, Input, CountDateNow);
                    dem++;
                }
            }
        }

        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
