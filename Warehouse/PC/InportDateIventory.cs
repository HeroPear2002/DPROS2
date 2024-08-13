using ExcelDataReader;
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

namespace WareHouse.PC
{
    public partial class InportDateIventory : Form
    {
        List<TotalLKDTO> listfirtData = new List<TotalLKDTO>();
        public InportDateIventory()
        {
            InitializeComponent();
        }
        List<string> eRror = new List<string>();
        DataSet ds;
        public EventHandler LamMoi;
        void ReadData()
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx|Excel Workbook 97-2003|*.xls", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtLink.Text = ofd.FileName;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))

                    {
                        IExcelDataReader reader;
                        if (ofd.FilterIndex == 2)
                        {
                            reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        }
                        else
                        {
                            reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        }

                        ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                        {
                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                            {
                                UseHeaderRow = true
                            }
                        });

                        cbSheet.Items.Clear();
                        foreach (DataTable dt in ds.Tables)
                        {
                            cbSheet.Items.Add(dt.TableName);
                        }
                        reader.Close();

                    }
                }
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            ReadData();
        }
        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataG.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtTTT.Text = "";
            eRror = new List<string>();  
            string partCode = "";
            DateTime date;
            int countOutput;
            DateTime today = DateTime.Today;
            DateTime DateTest = DateTime.Now.Date;
            int day = DateTest.Day;
            int month = DateTest.Month;
            int year = DateTest.Year;
            DateTime firtDate = DateTest.AddDays(-day + 1);
            int datefinal = DateTest.AddDays(-day + 1).AddMonths(1).AddDays(-1).Day;
            List<FixPODTO> listF = new List<FixPODTO>();
            List<FixPODTO> listk = new List<FixPODTO>();
            List<TotalPODTO> listT = new List<TotalPODTO>();
            foreach (DataGridViewRow row in dataG.Rows)
            {
                
                try
                {
                    partCode = row.Cells["Material number"].Value.ToString();
                    string a = row.Cells["Delivery date"].Value.ToString();
                    string[] array = a.Split('.');
                    date = DateTime.ParseExact(array[0] + "/" + array[1] + "/" + array[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    countOutput = int.Parse(row.Cells["PO quantity"].Value.ToString());
                    if (date >= DateTest && date <= DateTest.AddDays(15))
                    {
                        listF.Add(new FixPODTO(partCode, date, countOutput));
                    }
                }
                catch
                {

                }
            }
            if(listF.Count ==0)
            {
                MessageBox.Show(" có lỗi khi upload PO \n\n bạn hãy upload lại !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var kun = (from listf in listF select listf.PartCode + "&" + listf.Date).Distinct();
            int k = kun.Count();
            foreach (var item in kun)
            {
                string[] arrayList = item.ToString().Split('&');
                string product = arrayList[0];
                DateTime date0 = DateTime.Parse(arrayList[1]);
                listT.Add(new TotalPODTO(product, date0));
            }
            foreach (TotalPODTO item in listT)
            {
                int total = listF.Where(x => x.PartCode == item.ProductCode).Where(x => x.Date == item.Date).Sum(x => x.CountOutput);
                listk.Add(new FixPODTO(item.ProductCode, item.Date, total));
            }
            List<TotalLKDTO> listTotal = new List<TotalLKDTO>();
            List<TotalLKDTO> listData = new List<TotalLKDTO>();
            var noduplicates = listk.Select(x => x.PartCode).Distinct().ToList();
            #region list
            int CountDate = 0;
            int CountDateNow = 0;
            foreach (var item in noduplicates)
            {
                string product = item;
                int tongton = (int)IventoryPartDAO.Instance.TotallPartAllStatus(product);
                int tongtonNow = (int)IventoryPartDAO.Instance.TotallPartAllStatus(product);
                string MachineCode = "";
                int countInput = IventoryPartDAO.Instance.TotalInputbyDate(product, DateTest.AddHours(8), DateTest.AddHours(8).AddDays(1));
                int countInputNow = 0;
                int dateNote = PartDAO.Instance.DateNote(product);
                int day1 = 0;
                int day2 = 0;
                int day3 = 0;
                int day4 = 0;
                int dem = 0;
                for (int l = day; l <= day + 15; l++)
                {
                    dem++;

                    DateTime dateL = firtDate.AddDays(l);
                    if (dem == 1)
                    {
                        countInputNow = IventoryPartDAO.Instance.TotalInputbyDate(product, dateL.AddHours(8), dateL.AddHours(8).AddDays(1));
                        countInput = 0;
                    }
                    else
                    {
                        countInputNow = 0;
                    }
                    string sd = dateL.DayOfWeek.ToString();
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
                        int totalDate = listk.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(dateNote)).Sum(x => x.CountOutput);
                        int total5 = listk.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day4 +1)).Sum(x => x.CountOutput);
                        int total4 = listk.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day3 +1)).Sum(x => x.CountOutput);
                        int total3 = listk.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day2 +1)).Sum(x => x.CountOutput);
                        int total2 = listk.Where(x => x.PartCode == product).Where(x => x.Date >= dateL.AddDays(1)).Where(x => x.Date <= dateL.AddDays(day1 +1)).Sum(x => x.CountOutput);
                        int total1 = listk.Where(x => x.PartCode == product).Where(x => x.Date == dateL.AddDays(1)).Sum(x => x.CountOutput);
                        int countOut = listk.Where(x => x.PartCode == product).Where(x => x.Date == dateL).Sum(x => x.CountOutput);
                        int countOut1 = listk.Where(x => x.PartCode == product).Where(x => x.Date == dateL.AddDays(day1)).Sum(x => x.CountOutput);
                        int totalLK = tongton ;
                        int totalLKNow = tongtonNow /*+ countInputNow*/ ;
                        #region Count Date
                        if(dateNote ==5)
                        {
                            if ((tongton - total1) < 0)
                            {
                                CountDate = 0;
                                countInput = total5 - totalLK;
                            }
                            else if ((tongton - total2) < 0)
                            {
                                CountDate = 1;
                                countInput = total5 - totalLK;
                            }
                            else if ((tongton - total3) < 0)
                            {
                                CountDate = 2;
                                countInput = total5 - totalLK;
                            }
                            else if ((tongton - total4) < 0)
                            {
                                CountDate = 3;
                                countInput = total5 - totalLK;
                            }
                            else if ((tongton - total5) < 0)
                            {
                                CountDate = 4;
                                countInput = total5 - totalLK;
                            }
                            else if (tongton == total5)
                            {
                                CountDate = 5;
                                countInput = 0;
                            }
                            else
                            {
                                CountDate = 5;
                                countInput = 0;
                            }
                        }
                        else
                        {
                            if ((tongton - totalDate) < 0)
                            {
                                CountDate = 3;
                                countInput = totalDate - totalLK;
                            }
                            else
                            {
                                CountDate = dateNote;
                                countInput = 0;
                            }
                        }
                      
                        #endregion
                        #region Count DateNow
                        if(dateNote == 5)
                        {
                            if ((tongtonNow - total1) < 0)
                            {
                                CountDateNow = 0;
                            }
                            else if ((tongtonNow - total2) < 0)
                            {
                                CountDateNow = 1;
                            }
                            else if ((tongtonNow - total3) < 0)
                            {
                                CountDateNow = 2;
                            }
                            else if ((tongtonNow - total4) < 0)
                            {
                                CountDateNow = 3;
                            }
                            else if ((tongtonNow - total5) < 0)
                            {
                                CountDateNow = 4;

                            }
                            else if (tongtonNow == total5)
                            {
                                CountDateNow = 5;
                            }
                            else
                            {
                                CountDateNow = 5;
                            }
                        }
                        else
                        {
                            if ((tongtonNow - totalDate) < 0)
                            {
                                CountDateNow = 3;
                            }
                            else
                            {
                                CountDateNow = dateNote;
                            }
                        }
                        #endregion
                        listTotal.Add(new TotalLKDTO(1, product, dateL, countOut, countInput, totalLK, CountDate, MachineCode, "", totalLKNow, countInputNow, CountDateNow));
                        tongton = tongton + countInput - countOut1;
                        tongtonNow = tongtonNow  - countOut1;
                    }
                }
            }
            #endregion
            foreach (TotalLKDTO item in listTotal)
            {
                listfirtData.Add(new TotalLKDTO(1, item.PartCode, item.Date, item.Output, item.Input, item.Total, item.CountDate, item.MachineCode, item.MoldCode, item.TotalNow, item.InputNow, item.CountDateNow));
            }
            foreach (TotalLKDTO item in listfirtData)
            {
                string product = item.PartCode;
                DateTime dateNew = item.Date;
                long Id = TableCountDateDAO.Instance.GetIdTableByDate(product, dateNew);
                if (Id == -1)
                {
                    TableCountDateDAO.Instance.InsertTableCountDate(item.PartCode, item.Date, item.Output, item.Input, item.Total, item.CountDate, item.TotalNow, item.InputNow, item.CountDateNow);
                }
                else
                {
                   TableCountDateDAO.Instance.UpdateTableCountDate(Id, item.Output, item.Input, item.Total, item.CountDate, item.TotalNow, item.InputNow, item.CountDateNow);
                }
            }
            MessageBox.Show("Nhập Dữ Liệu Xong");
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }

        private void InportDateIventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
