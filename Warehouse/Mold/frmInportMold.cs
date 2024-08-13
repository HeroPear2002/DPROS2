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

namespace WareHouse.Mold
{
    public partial class frmInportMold : Form
    {
        public frmInportMold()
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
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            txtTTT.Text = "";
            eRror = new List<string>();
            int i = 0;
            int slLoi = 0;
            string moldCode = "";
            string moldName = "";
            string moldNumber = "";
            string MoldModel = "";
            string Maker = "";
            DateTime DateInput = DateTime.Now;
            string InputWhere = "";
            DateTime DateSX  = DateTime.Now;
            int ShotCount = 0;
            string Employess = "";
            string Note = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {

                    moldCode = row.Cells["Mold Code"].Value.ToString();
                    moldName = row.Cells["Mold Name"].Value.ToString();
                    moldNumber = row.Cells["Mold Number"].Value.ToString();
                    MoldModel = row.Cells["Mold Model"].Value.ToString(); 
                    Maker = row.Cells["Maker"].Value.ToString(); 
                    InputWhere = row.Cells[5].Value.ToString(); 
                    ShotCount = int.Parse(row.Cells["Quantity"].Value.ToString()) ;
                    Employess = row.Cells["Employess"].Value.ToString();
                    Note = row.Cells["Note"].Value.ToString();
                    if (moldCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Mã Nguyên Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = MoldDAO.Instance.TestMoldByCode(moldCode);
                        if (test == 1)
                        {
                            MoldDAO.Instance.UpdatetMold(moldCode, moldName, moldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
                        }
                        else
                        {
                            MoldDAO.Instance.InsertMold(moldCode, moldName, moldNumber, MoldModel, Maker, DateInput, InputWhere, DateSX, ShotCount, Employess, Note);
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

        private void frmInportMold_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
