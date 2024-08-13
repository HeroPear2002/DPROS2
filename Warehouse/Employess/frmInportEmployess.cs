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
using DTO;

namespace WareHouse.Employess
{
    public partial class frmInportEmployess : Form
    {
        public frmInportEmployess()
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
            EmployessDTO _em;
            string employessCode = "";
            string employessName = "";
            string rooCode = "";
            DateTime dateInput = DateTime.Now;
            string super = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {

                    employessCode = row.Cells["Employess Code"].Value.ToString();
                    employessName = row.Cells["Employess Name"].Value.ToString();
                    rooCode = row.Cells["Room"].Value.ToString();
                    super = row.Cells["Supper"].Value.ToString();
                    string a = row.Cells["Date Input"].Value.ToString();
                    dateInput = DateTime.Parse(a);
                                 
                    if (employessCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = EmployessDAO.Instance.TestEmployessByCode(employessCode);
                        if (test == 1)
                        {
                            _em = EmployessDAO.Instance.GetThefirtEmployess(employessCode);
                            EmployessDAO.Instance.UpdateEmployess(employessCode.ToUpper(), employessName, _em.DateInput, rooCode, super, _em.Status);
                        }
                        else
                        {
                            EmployessDAO.Instance.InsertEmployess(employessCode, employessName, dateInput, rooCode, super, 0);
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
        private void frmInportEmployess_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
