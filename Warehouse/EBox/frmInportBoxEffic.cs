using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace WareHouse.EBox
{
    public partial class frmInportBoxEffic : Form
    {
        public frmInportBoxEffic()
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
            int i = 0; int slLoi = 0;
            eRror = new List<string>();
            string PartCode;
            int DateLV;
            float DateIventory;
            string DateNew;
            int QuantityPart, CountBox, CountBoxTT;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    PartCode = row.Cells["Part Code"].Value.ToString();
                    string [] array = row.Cells["Date Month"].Value.ToString().Split('/');
                    string [] a = (array[1] + "/" + array[2]).Split(' ');
                    DateNew = a[0];
                    QuantityPart = int.Parse(row.Cells["Quantity Part"].Value.ToString());
                    CountBoxTT = int.Parse(row.Cells["Quantity Box"].Value.ToString());
                    DateIventory = (float)Convert.ToDouble(row.Cells["Date Iventory"].Value.ToString());
                    DateLV = int.Parse(row.Cells["Date Works"].Value.ToString());
                    if (PartCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Thông Tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = BoxDAO.Instance.TestBoxEffic(DateNew, PartCode);
                        int countPart = PartDAO.Instance.CountPartByCode(PartCode);
                        CountBox = (int)Math.Ceiling((((QuantityPart * DateIventory) / DateLV) / countPart)+((0.02*QuantityPart)/countPart));
                        if (test == -1)
                        {
                            BoxDAO.Instance.InsertBoxEffic(DateNew, PartCode,QuantityPart,CountBox,CountBoxTT);
                        }
                        else
                        {
                            BoxDAO.Instance.UpdateBoxEffic(test, DateNew, PartCode, QuantityPart, CountBox, CountBoxTT);
                        }
                    }
                }
                catch
                {

                }
                txtTTT.Text = "Lỗi: " + (slLoi) + " Lỗi";
            }
        
            MessageBox.Show("Nhập Dữ Liệu Xong");
        }
        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }
        private void frmInportBoxEffic_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
