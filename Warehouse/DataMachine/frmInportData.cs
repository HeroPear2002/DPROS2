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

namespace WareHouse.DataMachine
{
    public partial class frmInportData : Form
    {
        public frmInportData()
        {
            InitializeComponent();
            this.AcceptButton = btnSave;
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
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
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
            int i = 0;
            int slLoi = 0;
            string mold = "";
            string machine = "";
            DateTime dateTime;
            int hour = 0;
            float Cycle = 0; float TimeLM = 0; float TimeGA = 0; float TimeIJ = 0; float Cushpos = 0; float H4 = 0; float Core = 0; float Cavity = 0;
            float CycleS = 0; float TimeLMS = 0; float TimeGAS = 0; float TimeIJS = 0; float CushposS = 0; float H4S = 0; float CoreS = 0; float CavityS = 0;
            int dem = 0;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                dem++;
                try
                {
                    if (dem == 1)
                    {
                        CycleS = (float)Convert.ToDouble(row.Cells[4].Value.ToString());
                        TimeLMS = (float)Convert.ToDouble(row.Cells[5].Value.ToString());
                        TimeGAS = (float)Convert.ToDouble(row.Cells[6].Value.ToString());
                        TimeIJS = (float)Convert.ToDouble(row.Cells[7].Value.ToString());
                        CushposS = (float)Convert.ToDouble(row.Cells[8].Value.ToString());
                        H4S = (float)Convert.ToDouble(row.Cells[9].Value.ToString());
                        CoreS = (float)Convert.ToDouble(row.Cells[10].Value.ToString());
                        CavityS = (float)Convert.ToDouble(row.Cells[11].Value.ToString());
                    }
                    if (dem >= 2)
                    {
                        mold = row.Cells[0].Value.ToString();
                        machine = row.Cells[1].Value.ToString();
                        string a = row.Cells[2].Value.ToString();
                        try
                        {
                            string[] array = a.Split('/');
                            string b = array[1] + "/" + array[0] + "/" + array[2];
                            if (array[2].Length > 4)
                            {
                                array[2] = array[2].Substring(0, 4);
                            }
                            dateTime = DateTime.Parse(b, new CultureInfo("en-CA", true));
                        }
                        catch
                        {
                            string[] array = a.Split('-');
                            string b = array[1] + "/" + array[0] + "/" + array[2];
                            if (array[2].Length > 4)
                            {
                                array[2] = array[2].Substring(0, 4);
                            }
                            dateTime = DateTime.Parse(b, new CultureInfo("en-CA", true));
                        }
                        hour = int.Parse(row.Cells[3].Value.ToString());
                        Cycle = (float)Convert.ToDouble(row.Cells[4].Value.ToString());
                        TimeLM = (float)Convert.ToDouble(row.Cells[5].Value.ToString());
                        TimeGA = (float)Convert.ToDouble(row.Cells[6].Value.ToString());
                        TimeIJ = (float)Convert.ToDouble(row.Cells[7].Value.ToString());
                        Cushpos = (float)Convert.ToDouble(row.Cells[8].Value.ToString());
                        H4 = (float)Convert.ToDouble(row.Cells[9].Value.ToString());
                        Core = (float)Convert.ToDouble(row.Cells[10].Value.ToString());
                        Cavity = (float)Convert.ToDouble(row.Cells[11].Value.ToString());
                        if (mold == "")
                        {
                            eRror.Add("Dòng " + i + ": Mã Khuôn Trống".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                            int test = DataMachineDAO.Instance.TestDataMachine(mold, machine, dateTime.Date.AddHours(hour));
                            if (test != -1)
                            {
                                eRror.Add("Dòng " + i + ": Dữ liệu đã tồn tại".ToUpper());
                                slLoi++;
                            }
                            else
                            {
                                DataMachineDAO.Instance.InsertDataMachine(mold, machine, dateTime.Date.AddHours(hour), Cycle, CycleS, TimeLM, TimeLMS, TimeGA, TimeGAS, TimeIJ, TimeIJS, Cushpos, CushposS, H4, H4S, Core, CoreS, Cavity, CavityS,"");
                            }

                        }
                    }

                }
                catch
                {

                }
                txtTTT.Text = "Lỗi: " + (slLoi) + " Lỗi";
            }
            if (eRror.Count != 0)
            {
                eRror.RemoveAt(eRror.Count - 1);
            }
            MessageBox.Show("Nhập Dữ Liệu Xong");
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }
        private void frmInportMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
