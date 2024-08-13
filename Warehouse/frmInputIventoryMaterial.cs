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
    public partial class frmInputIventoryMaterial : Form
    {
        public frmInputIventoryMaterial()
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
            string materialCode = "";
            DateTime date;
            int quantity = 0;
            string Employess = "admin";
            string name = "";
            int IdWh;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    materialCode = row.Cells[1].Value.ToString();
                    date = DateTime.Parse(row.Cells[3].Value.ToString());
                    quantity = int.Parse(row.Cells[4].Value.ToString());
                    name = row.Cells[5].Value.ToString();
                    IdWh = WarehouseMaterialDAO.Instance.IdWarehouseMaterial(name);
                    if (materialCode == "")
                    {
                        eRror.Add("Dòng " + i + ": thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        IventoryMaterialDAO.Instance.InsertInputMaterial(materialCode, date, quantity, IdWh, 0, "Nhập Mới", Employess,"NO");
                        WarehouseMaterialDAO.Instance.UpdateStatus(IdWh, 2);
                        IventoryMaterialDAO.Instance.IsertHistory(materialCode, date, quantity, "Nhập Mới", Employess, name);
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
