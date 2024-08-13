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

namespace WareHouse.QC
{
    public partial class frmInportEquipment : Form
    {
        public frmInportEquipment()
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
            string code = "";
            string name = "";
            string model = "";
            string serial = "";
            string maker = "";
            string status = "";
            DateTime dateInput = DateTime.Now;
            int cycle = 0;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    code = row.Cells[0].Value.ToString();
                    name = row.Cells[1].Value.ToString();
                    model = row.Cells[2].Value.ToString();
                    serial = row.Cells[3].Value.ToString();
                    maker = row.Cells[4].Value.ToString();
                    status = row.Cells[5].Value.ToString();
                    cycle = int.Parse(row.Cells[6].Value.ToString());
                    dateInput = DateTime.Parse(row.Cells[7].Value.ToString());
                    if (code == "")
                    {
                        eRror.Add("Dòng " + i + ": Mã Linh Kiện Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = EquipmentDAO.Instance.TestEquipmentByCode(code);
                        if (test == 1)
                        {
                            EquipmentDAO.Instance.UpdateEquipment(code, name, model, serial, maker, status, cycle, dateInput);
                        }
                        else
                        {
                            EquipmentDAO.Instance.InsertEquipment(code, name, model, serial, maker, status, cycle, 0, dateInput);
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

        private void frmInportEquipment_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
