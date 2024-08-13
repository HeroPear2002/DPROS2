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

namespace WareHouse.Product
{
    public partial class frmInportInput : Form
    {
        public frmInportInput()
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
            int i = 0, slLoi = 0;
            string Code = "";
            string em = "";
            float countConstan;
            string Note = "";
            DateTime today;

            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    Code = row.Cells["Code"].Value.ToString();                
                    em = row.Cells["Employess"].Value.ToString();
                    countConstan = (float)Convert.ToDouble(row.Cells["Quantity"].Value.ToString());
                    Note = row.Cells["Note"].Value.ToString();
                    string a = row.Cells["Date"].Value.ToString();
                    string[] array = a.Split('/');
                    string b = array[1] + "/" + array[0] + "/" + array[2];
                    if (array[2].Length > 4)
                    {
                        array[2] = array[2].Substring(0, 4);
                    }
                    today = DateTime.Parse(b, new CultureInfo("en-CA", true));
                    if (Code == "")
                    {
                        eRror.Add("Dòng " + i + ": Dữ Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = ProductDAO.Instance.TestProduct(Code);
                        if(test == 1)
                        {
                            ProductDAO.Instance.InsertIputProduct(Code, today, em, 0, Note, countConstan);
                        }
                        else
                        {
                            eRror.Add("Dòng " + i + ":  Mã linh kiện không đúng".ToUpper());
                            slLoi++;
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

        private void frmInportInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender,e);
        }
    }
}
