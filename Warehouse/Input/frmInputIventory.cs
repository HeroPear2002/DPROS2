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

namespace WareHouse.Input
{
    public partial class frmInputIventory : Form
    {
        public frmInputIventory()
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
            DateTime dateInput;
            int quantityInput = 0;
            string employess = "admin";
            string molNumber = "";
            string machineCode = "";
            string name = "";
            int idWarehouse;
            string lot = "";
            DateTime dateManufacturi;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    partCode = row.Cells[1].Value.ToString();
                    dateInput = DateTime.Parse(row.Cells[3].Value.ToString());
                    quantityInput = int.Parse(row.Cells[6].Value.ToString());                    
                    molNumber = row.Cells[7].Value.ToString();
                    machineCode = row.Cells[8].Value.ToString();
                    lot = row.Cells[9].Value.ToString();
                    name = row.Cells[4].Value.ToString();
                    idWarehouse = WareHouseDAO.Instance.IdWarehouse(name);
                    dateManufacturi = DateTime.Parse(row.Cells[3].Value.ToString());
                    if (partCode == "")
                    {
                        eRror.Add("Dòng " + i + ": thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateManufacturi, 0, "Nhập Mới",lot,"","","");
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

    }
}
