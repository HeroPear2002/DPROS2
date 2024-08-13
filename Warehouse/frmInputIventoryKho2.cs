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

namespace WareHouse
{
    public partial class frmInputIventoryKho2 : Form
    {
        public frmInputIventoryKho2()
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
            string lot = "";
            int idWarehouse;
            //DateTime dateManufacturi;
            int test = 0;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    partCode = row.Cells[1].Value.ToString();
                    dateInput = DateTime.Parse(row.Cells[3].Value.ToString());
                    quantityInput = int.Parse(row.Cells[4].Value.ToString());
                    molNumber = row.Cells[5].Value.ToString();
                    machineCode = row.Cells[6].Value.ToString();
                    name = row.Cells[4].Value.ToString();
                    idWarehouse = int.Parse(row.Cells[8].Value.ToString());
                    lot = row.Cells[9].Value.ToString();
                    //dateManufacturi = DateTime.Parse(row.Cells[2].Value.ToString());
                    if (partCode == "")
                    {
                        eRror.Add("Dòng " + i + ": thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        test = WareHouseDAO.Instance.IdWarehouseById(idWarehouse);
                        if (test > 0)
                        {
                            eRror.Add("Dòng " + i + ": Kho có hàng rồi".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateInput, 0, "Nhập Mới", lot, "", "","");
                            WareHouseDAO.Instance.UpdateStatusWH(idWarehouse, 4);
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
    }
}
