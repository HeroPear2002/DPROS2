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

namespace WareHouse.FParts
{
    public partial class frmInportPart : Form
    {
        public frmInportPart()
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
            int i = 0;
            int slLoi = 0;
            string partCode = "";
            string partName = "";
            string materialCode = "";
            string customnerCode = "";
            int quantityBox = 0;
            int quantityPart = 0;
            float runner = 0;
            float weight = 0;
            float cycleTime = 0;
            int cavity = 0;
            int height = 0;
            float note = 0;
            string nameVN = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    partCode = row.Cells["Part Code"].Value.ToString();
                    partName = row.Cells["Part Name"].Value.ToString();
                    materialCode = row.Cells["Material Code"].Value.ToString();
                    customnerCode = row.Cells["Customer Code"].Value.ToString();
                    quantityBox = int.Parse(row.Cells["Quantity Box"].Value.ToString());
                    quantityPart = int.Parse(row.Cells["Quantity Part"].Value.ToString()); ;
                    runner = (float)Convert.ToDouble(row.Cells["Weight Runner"].Value.ToString());
                    weight = (float)Convert.ToDouble(row.Cells["Weight Part"].Value.ToString());
                    cycleTime = (float)Convert.ToDouble(row.Cells["Cycle Time"].Value.ToString());
                    cavity = int.Parse(row.Cells["Cavity"].Value.ToString());
                    height = int.Parse(row.Cells["Height"].Value.ToString());
                    nameVN = row.Cells["Name VN"].Value.ToString();
                    if (partCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Mã Linh Kiện Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = PartDAO.Instance.TestPartByCode(partCode);
                        if (test == 1)
                        {
                            PartDAO.Instance.UpdatePart(partCode, partName, materialCode, customnerCode, quantityBox, quantityPart, runner, weight, cycleTime, cavity, height, note, nameVN,"");
                        }
                        else
                        {
                            PartDAO.Instance.InsertPart(partCode, partName, materialCode, customnerCode, quantityBox, quantityPart, runner, weight, cycleTime, cavity, height, note, nameVN);
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

        private void frmInportPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
