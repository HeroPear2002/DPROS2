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

namespace WareHouse.MachineRelationShip
{
    public partial class frmImportCategory : Form
    {
        public frmImportCategory()
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
            string name = "";
            string detail = "";
            string method = "";
            string device = "";
            string limit = "";
            int timer = 0;
            int confirm = 0;

            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    name = row.Cells[0].Value.ToString();
                    detail = row.Cells[1].Value.ToString();
                    method = row.Cells[2].Value.ToString();
                    timer = int.Parse(row.Cells[3].Value.ToString());
                    confirm = int.Parse(row.Cells[4].Value.ToString());
                    device = row.Cells[5].Value.ToString();
                
                    int _listDeviceDTO = MachineDAO.Instance.GetIdDeviceByName(device);
                    if (_listDeviceDTO == -1)
                    {
                        eRror.Add("Dòng " + i + ": Loại thiết bị không đúng".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        if (name == "")
                        {
                            eRror.Add("Dòng " + i + ": thông tin Trống".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            MachineDAO.Instance.InsertCategoryTest(name, detail, timer, method, confirm, device, limit);
                        }
                    }
                }
                catch
                {

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

        private void frmImportCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
