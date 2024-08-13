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

namespace WareHouse.PO_and_Order
{
    public partial class frmInportPO : Form
    {
        public frmInportPO()
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
            int i = 1, slLoi = 0;
            string POCode = "";
            string PartCode = "";
            int QuantityIn;
            string FactoryCode = "";
            DateTime DateInput = DateTime.Now;
            string Price = "";
            DateTime DateOut;
            string Customer = "";
            int dem = dataG.Rows.Count;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                if(i < dem)
                {
                    POCode = "";
                    string MaPO = row.Cells["Purchasing number"].Value.ToString();
                    string[] arrayList = MaPO.Split('-');
                    foreach (var item in arrayList)
                    {
                        POCode += item.ToUpper();
                    }
                    PartCode = row.Cells["Material number"].Value.ToString();
                    string fact = row.Cells["Vendor"].Value.ToString();
                    FactoryCode = FactoryDAO.Instance.FactoryCodeByCode(fact);
                    string a = row.Cells["Delivery date"].Value.ToString();
                    string[] array = a.Split('.');
                    if (array.Count() == 1)
                    {
                        DateOut = DateTime.Parse(a);
                    }
                    else
                    {
                        DateOut = DateTime.ParseExact(array[0] + "/" + array[1] + "/" + array[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    QuantityIn = int.Parse(row.Cells["PO quantity"].Value.ToString());
                    Customer = row.Cells["Customer"].Value.ToString();
                    Price = row.Cells["Unit Price"].Value.ToString();
                    string b = row.Cells["Date Input"].Value.ToString();

                    if (b.Length > 5)
                    {
                        string[] arrayB = b.Split('.');
                        DateInput = DateTime.ParseExact(arrayB[0] + "/" + arrayB[1] + "/" + arrayB[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        DateInput = DateTime.Now;
                    }
                    if (POCode == "" || PartCode == "" || QuantityIn == 0 || DateInput.ToString() == "" || FactoryCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Dữ Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        long test = PODAO.Instance.TestPO(POCode, PartCode, Price);
                        if (test > -1)
                        {
                            eRror.Add("Dòng " + i + " : " + "MÃ PO " + POCode + " Có mã lk (" + PartCode + ") ĐÃ TỒN TẠI".ToUpper());
                            slLoi++;
                        }
                        else if (CustomerDAO.Instance.TestCustomerDTO(Customer) == -1)
                        {
                            eRror.Add("Dòng " + i + ": Mã khách hàng không đúng".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            PODAO.Instance.InsertPO(POCode, PartCode, QuantityIn, DateInput, 0, FactoryCode, Price, DateOut, Customer);
                        }
                    }
                }
                txtTTT.Text = "Lỗi: " + (slLoi) + " Lỗi";
            }
            if (eRror.Count == 0)
            {
                MessageBox.Show("Nhập Dữ Liệu Xong".ToUpper());
                this.Close();
            }
            else
            {
                MessageBox.Show("Có lỗi khi nhập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }

        private void frmInportPO_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
