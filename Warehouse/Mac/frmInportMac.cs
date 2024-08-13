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

namespace WareHouse.Mac
{
    public partial class frmInportMac : Form
    {
        public frmInportMac()
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
            string moldCode = "";
            string partCode = "";
            string machineCode = "";
            string rev = "";
            string factory = "";
            string standard = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    moldCode = row.Cells["Mold Code"].Value.ToString();
                    partCode = row.Cells["Part Code"].Value.ToString();
                    machineCode = row.Cells["Machine Code"].Value.ToString();
                    rev = row.Cells["Rev"].Value.ToString();
                    factory = row.Cells["Factory Code"].Value.ToString();
                    standard = row.Cells["Standard"].Value.ToString();
                    if (moldCode == "" || partCode == "" || machineCode == "" || factory == "")
                    {
                        eRror.Add("Dòng " + i + ": Dữ Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = MacInforDAO.Instance.TestMacByAll(partCode, machineCode, moldCode);
                        if (test != -1)
                        {
                            MacInforDAO.Instance.UpdateMac(test, partCode, machineCode, moldCode, rev, factory, standard);
                        }
                        else
                        {
                            MacInforDAO.Instance.InsertMac(partCode, machineCode, moldCode, rev, factory, standard);
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

        private void frmInportMac_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
