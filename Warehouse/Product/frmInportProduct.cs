using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.Product
{
    public partial class frmInportProduct : Form
    {
        public frmInportProduct()
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
            string Name = "";
            float countConstan;
            string rohs = "";
            string Vendor = "";
            string a = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    Code = row.Cells["Code"].Value.ToString();
                    Name = row.Cells["Name"].Value.ToString();
                    countConstan = (float)Convert.ToDouble(row.Cells["Constan"].Value.ToString());
                    Vendor = row.Cells["Vendor"].Value.ToString();
                    rohs = row.Cells["ROHS"].Value.ToString();
                    if (Code == "")
                    {
                        eRror.Add("Dòng " + i + ": Dữ Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        if (rohs.Length > 0)
                        {
                            a = "YES";
                        }
                        else
                        {
                            a = "NO";
                        }
                        ProductDTO pr = new ProductDTO(Code, Name, countConstan, rohs, Vendor, a);
                        int test = ProductDAO.Instance.TestProduct(Code);
                        if (test == 1)
                        {
                            ProductDAO.Instance.UpdateProduct(pr);
                        }
                        else
                        {
                            ProductDAO.Instance.InsertProduct(pr);
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

        private void frmInportProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
