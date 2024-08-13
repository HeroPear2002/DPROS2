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
    public partial class frmInportBoxList : Form
    {
        public frmInportBoxList()
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
            string BoxCode = "";
            string BoxName = "";
            string StyleBox = "";
            int BoxIventory = 0;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {

                    BoxCode = row.Cells["Box Code"].Value.ToString();
                    BoxName = row.Cells["Box Name"].Value.ToString();
                    StyleBox = row.Cells["Style Box"].Value.ToString();
                    BoxIventory = int.Parse(row.Cells["Quantity Box"].Value.ToString());
                    if (BoxCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = BoxDAO.Instance.TestBoxList(BoxCode);
                        if (test == 1)
                        {
                            BoxDAO.Instance.UpdateListBox(BoxCode, BoxName, StyleBox, BoxIventory);
                        }
                        else
                        {
                            BoxDAO.Instance.InsertListBox(BoxCode, BoxName, StyleBox, BoxIventory);
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
        private void frmInportBoxList_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
