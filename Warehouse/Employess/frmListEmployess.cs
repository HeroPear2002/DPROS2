using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using DTO;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using System.Threading;
using DevExpress.XtraSplashScreen;
using System.Windows.Forms;
using System.IO;

namespace WareHouse.Employess
{
    public partial class frmListEmployess : DevExpress.XtraEditors.XtraForm
    {
        public frmListEmployess()
        {
            InitializeComponent();
            LoadControl();
            DataLoad();
        }
        List<TableEmployess> listTe = new List<TableEmployess>();
        int dem = 0;
        int k = 0;
        int check = 0;
        List<EmployessDTO> listEW = new List<EmployessDTO>();
        public List<EmployessDTO> EmploySuper(List<EmployessDTO> listEN, int dem)
        {
            DateTime today = dtpkDate.Value.Date;
            DateTime date1 = today.AddDays(-today.Day).AddDays(1);
            List<EmployessDTO> listET = EmployessDAO.Instance.GetlistEmployess();
            List<EmployessDTO> listETw = new List<EmployessDTO>();
            if (listEN.Count == 0)
            {
                return listEW;
            }
            else
            {
                foreach (EmployessDTO item in listEN)
                {
                    listEW.Add(new EmployessDTO(item.EmployessCode, item.EmployessName, item.DateInput, item.RoomCode, item.Super, dem));
                    foreach (EmployessDTO j in listET.Where(x => x.Super == item.EmployessCode && x.DateInput <= date1))
                    {
                        listETw.Add(new EmployessDTO(j.EmployessCode, j.EmployessName, j.DateInput, j.RoomCode, j.Super, item.Status));
                    }

                }
                listEN = listETw;
                dem++;
                return EmploySuper(listEN, dem);
            }

        }

        void LoadControl()
        {
            int i = 0;
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false);

            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = dtpkDate.Value.Date;
            DateTime date1 = today.AddDays(-today.Day).AddDays(1);
            DateTime date2 = date1.AddMonths(1).AddMilliseconds(-1);
            DateTime dateY1 = date1.AddMonths(-today.Month);
            DateTime dateY2 = dateY1.AddYears(1).AddDays(-1);
            if (today.Month < 12)
            {
                dateY1 = date1.AddMonths(-today.Month);
                dateY2 = dateY1.AddYears(1).AddDays(-1);
            }
            else
            {
                dateY1 = date1;
                dateY2 = dateY1.AddYears(1).AddDays(-1);
            }
            listTe = new List<TableEmployess>();
            listEW = new List<EmployessDTO>();
            List<EmployessDTO> listE = EmploySuper(EmployessDAO.Instance.GetlistEmployess().Where(x => x.Super == "" && x.DateInput <= date1).ToList(), 0);
            k = (int)Math.Ceiling((double)listE.Count / 10);
            List<TableEmployess> listT = new List<TableEmployess>();
            foreach (EmployessDTO item in listE.OrderByDescending(x => x.Status))
            {
                i++;
                int totalErY = 0;
                int totalPlY = 0;
                int totalEr = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, date1, date2);
                int totalPl = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, date1, date2);
                int countEr = 0;
                int countPl = 0;
                if (check == 0)
                {
                    countEr = EmployessDAO.Instance.CountEr(item.EmployessCode, date1, date2);
                    countPl = EmployessDAO.Instance.CountPl(item.EmployessCode, date1, date2);
                    totalErY = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, date1, date2);
                    totalPlY = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, date1, date2);
                }
                else
                {
                    countEr = EmployessDAO.Instance.CountEr(item.EmployessCode, dateY1, dateY2);
                    countPl = EmployessDAO.Instance.CountPl(item.EmployessCode, dateY1, dateY2);
                    totalErY = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, dateY1, dateY2);
                    totalPlY = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, dateY1, dateY2);
                }
                string room = item.RoomCode;
                int totalNow = 100 + totalPl - totalEr;
                float totalAVC = 0;

                int month = (today.Year - item.DateInput.Year) * 12 + (today.Month - item.DateInput.Month);
                if (month >= 12)
                {
                    totalAVC = (float)Math.Round((double)((12 * 100) + (totalPlY - totalErY)) / 12, 1);
                }
                else if (month > 0 && month < 12)
                {
                    if (month > today.Month)
                    {
                        totalAVC = (float)Math.Round((double)((today.Month * 100) + (totalPlY - totalErY)) / today.Month, 1);
                    }
                    else
                    {
                        totalAVC = (float)Math.Round((double)((month * 100) + (totalPlY - totalErY)) / month, 1);
                    }

                }
                else if (month == 0)
                {
                    totalAVC = 100;
                    month = 1;
                }
                else
                {
                    totalNow = 0;
                }
                listT.Add(new TableEmployess(item.EmployessCode, item.EmployessName, totalAVC, totalPlY, totalErY, totalNow, room, countEr, countPl, month, 1, item.Super));
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "/" + listE.Count.ToString());
                Thread.Sleep(1);
            }
            foreach (TableEmployess item in listT)
            {
                List<TableEmployess> listEt = listTe.Where(x => x.Super == item.EmployessCode).ToList();
                if (listEt.Count == 0)
                {
                    listTe.Add(new TableEmployess(item.EmployessCode, item.EmployessName, item.PointDefault, item.PointPl, item.PointEr, item.PointNow, item.RoomCode, item.CountError, item.CountPlus, item.CountMonth, 1, item.Super));
                }
                else
                {

                    float pointSuper = (float)Math.Round((listEt.Average(s => s.PointNow) + item.PointNow) / 2, 1);
                    float pointYear = (float)Math.Round((listEt.Average(s => s.PointDefault) + item.PointDefault) / 2, 1);
                    listTe.Add(new TableEmployess(item.EmployessCode, item.EmployessName, pointYear, item.PointPl, item.PointEr, pointSuper, item.RoomCode, item.CountError, item.CountPlus, item.CountMonth, 1, item.Super));
                }
            }
            SplashScreenManager.CloseForm(false);
        }
        void DataLoad()
        {
            timer1.Start();
            if (dem == k)
            {
                dem = 0;
            }
            List<TableEmployess> listT = new List<TableEmployess>();
            int i = 0;
            foreach (TableEmployess item in listTe.OrderByDescending(x => x.CountMonth))
            {
                i++;
                if (i > dem * 10 && i <= dem * 10 + 10)
                {
                    listT.Add(new TableEmployess(item.EmployessCode, item.EmployessName, item.PointDefault, item.PointPl, item.PointEr, item.PointNow, item.RoomCode, item.CountError, item.CountPlus, item.CountMonth, 1, item.Super));
                }

            }
            GCData.DataSource = listT.OrderByDescending(x => x.CountMonth);
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            int rowHandle = (GCData.FocusedView as GridView).FocusedRowHandle;
            GridView view = sender as GridView;
            if (!(view.IsDataRow(rowHandle))) return;
            DateTime today = DateTime.Now.Date;

            if (e.RowHandle >= 0 && e.Column.FieldName == "PointEr")
            {

                e.Appearance.ForeColor = Color.Red;
            }
            if (e.RowHandle >= 0 && e.Column.FieldName == "PointPl")
            {
                e.Appearance.ForeColor = Color.Blue;
            }
        }

        private void gridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "PointNow" || e.Column.FieldName == "PointDefault")
            {
                DrawProgressBar(e);
            }
        }
        private void DrawProgressBar(DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            int percent = Convert.ToInt32(e.CellValue);
            int v = Convert.ToInt32(e.CellValue);
            if (v > 100)
            {
                v = 100;
            }
            v = v * e.Bounds.Width / 200;
            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, v, e.Bounds.Height);
            Brush b = Brushes.Green;
            if (percent < 60)
                b = Brushes.Red;
            else if (percent < 80)
                b = Brushes.Orange;
            else if (percent < 100)
                b = Brushes.Yellow;
            else if (percent == 100)
                b = Brushes.SpringGreen;
            else
                b = Brushes.GreenYellow;
            e.Graphics.FillRectangle(b, rect);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            dem++;
            DataLoad();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            check = 0;
            timer1.Stop();
            LoadControl();
            GCData.DataSource = listTe.OrderByDescending(x => x.CountMonth);
        }

        private void btnALLView_Click(object sender, EventArgs e)
        {
            check = 1;
            timer1.Stop();
            GCData.DataSource = null;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime today = dtpkDate.Value.Date;
            DateTime date1 = today.AddDays(-today.Day).AddDays(1);
            DateTime date2 = date1.AddMonths(1).AddMilliseconds(-1);
            DateTime dateY1 = date1.AddMonths(-today.Month);
            DateTime dateY2 = dateY1.AddYears(1).AddDays(-1);
            if (today.Month < 12)
            {
                dateY1 = date1.AddMonths(-today.Month);
                dateY2 = dateY1.AddYears(1).AddDays(-1);
            }
            else
            {
                dateY1 = date1;
                dateY2 = dateY1.AddYears(1).AddDays(-1);
            }
            listEW = new List<EmployessDTO>();
            List<EmployessDTO> listE = EmploySuper(EmployessDAO.Instance.GetlistEmployess().Where(x => x.Super == "" && x.DateInput <= date1).ToList(), 0);
            k = (int)Math.Ceiling((double)listE.Count / 10);
            List<TableEmployess> listT = new List<TableEmployess>();
            listTe = new List<TableEmployess>();
            int i = 0;
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false);
            foreach (EmployessDTO item in listE.OrderByDescending(x => x.Status))
            {
                i++;
                int totalErY = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, dateY1, dateY2);
                int totalPlY = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, dateY1, dateY2);
                int totalEr = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, date1, date2);
                int totalPl = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, date1, date2);
                int countEr = EmployessDAO.Instance.CountEr(item.EmployessCode, dateY1, dateY2);
                int countPl = EmployessDAO.Instance.CountPl(item.EmployessCode, dateY1, dateY2);
                string room = item.RoomCode;
                int totalNow = 100 + totalPl - totalEr;
                float totalAVC = 0;

                int month = (today.Year - item.DateInput.Year) * 12 + (today.Month - item.DateInput.Month);
                if (month >= 12)
                {
                    totalAVC = (float)Math.Round((double)((12 * 100) + (totalPlY - totalErY)) / 12, 1);
                }
                else if (month > 0 && month < 12)
                {
                    if (month > today.Month)
                    {
                        totalAVC = (float)Math.Round((double)((today.Month * 100) + (totalPlY - totalErY)) / today.Month, 1);
                    }
                    else
                    {
                        totalAVC = (float)Math.Round((double)((month * 100) + (totalPlY - totalErY)) / month, 1);
                    }

                }
                else if (month == 0)
                {
                    totalAVC = 100;
                    month = 1;
                }
                else
                {
                    totalNow = 0;
                }
                listT.Add(new TableEmployess(item.EmployessCode, item.EmployessName, totalAVC, totalPlY, totalErY, totalNow, room, countEr, countPl, month, 1, item.Super));
                SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "/" + listE.Count.ToString());
                Thread.Sleep(1);
            }
            foreach (TableEmployess item in listT)
            {
                List<TableEmployess> listEt = listTe.Where(x => x.Super == item.EmployessCode).ToList();
                if (listEt.Count == 0)
                {
                    listTe.Add(new TableEmployess(item.EmployessCode, item.EmployessName, item.PointDefault, item.PointPl, item.PointEr, item.PointNow, item.RoomCode, item.CountError, item.CountPlus, item.CountMonth, 1, item.Super));
                }
                else
                {
                    float pointSuper = (float)Math.Round((listEt.Average(s => s.PointNow) + item.PointNow) / 2, 1);
                    float pointYear = (float)Math.Round((listEt.Average(s => s.PointDefault) + item.PointDefault) / 2, 1);
                    listTe.Add(new TableEmployess(item.EmployessCode, item.EmployessName, pointYear, item.PointPl, item.PointEr, pointSuper, item.RoomCode, item.CountError, item.CountPlus, item.CountMonth, 1, item.Super));
                }
            }
            SplashScreenManager.CloseForm(false);
            GCData.DataSource = listTe.OrderByDescending(x => x.CountMonth);
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
        //void LoadControl()
        //{
        //    if (dem == k)
        //    {
        //        dem = 0;
        //    }
        //    gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
        //    System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
        //    DateTime today = dtpkDate.Value.Date;
        //    DateTime date1 = today.AddDays(-today.Day).AddDays(1);
        //    DateTime date2 = date1.AddMonths(1).AddMilliseconds(-1);
        //    DateTime dateY1 = date1.AddMonths(-today.Month);
        //    DateTime dateY2 = dateY1.AddYears(1).AddDays(-1);
        //    List<EmployessDTO> listE = EmployessDAO.Instance.GetlistEmployess();
        //    k = (int)Math.Ceiling((double)listE.Count / 10);
        //    List<TableEmployess> listT = new List<TableEmployess>();
        //    List<TableEmployess> listTe = new List<TableEmployess>();
        //    int i = 0;
        //    foreach (EmployessDTO item in listE.OrderBy(x => x.DateInput))
        //    {
        //        i++;
        //        if (i > dem * 10 && i <= dem * 10 + 10)
        //        {
        //            int totalErY = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, dateY1, dateY2);
        //            int totalPlY = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, dateY1, dateY2);
        //            int totalEr = EmployessDAO.Instance.TotalPoitEr(item.EmployessCode, date1, date2);
        //            int totalPl = EmployessDAO.Instance.TotalPoitPl(item.EmployessCode, date1, date2);
        //            int countEr = EmployessDAO.Instance.CountEr(item.EmployessCode, date1, date2);
        //            int countPl = EmployessDAO.Instance.CountPl(item.EmployessCode, date1, date2);
        //            string room = item.RoomCode;
        //            int totalNow = 100 + totalPl - totalEr;
        //            float totalAVC = 0;

        //            int month = (today.Year - item.DateInput.Year) * 12 + (today.Month - item.DateInput.Month);
        //            if (month >= 12)
        //            {
        //                totalAVC = (float)Math.Round((double)((12 * 100) + (totalPlY - totalErY)) / 12, 1);
        //            }
        //            else if (month > 0 && month < 12)
        //            {
        //                if (month > today.Month)
        //                {
        //                    totalAVC = (float)Math.Round((double)((today.Month * 100) + (totalPlY - totalErY)) / today.Month, 1);
        //                }
        //                else
        //                {
        //                    totalAVC = (float)Math.Round((double)((month * 100) + (totalPlY - totalErY)) / month, 1);
        //                }

        //            }
        //            else if (month == 0)
        //            {
        //                totalAVC = 100;
        //                month = 1;
        //            }
        //            else
        //            {
        //                totalNow = 0;
        //            }
        //            listT.Add(new TableEmployess(item.EmployessCode, item.EmployessName, totalAVC, totalPl, totalEr, totalNow, room, countEr, countPl, month, 1, item.Super));
        //        }
        //    }
        //   
        //    GCData.DataSource = listTe.OrderByDescending(x => x.CountMonth);

        //}
    }
}
