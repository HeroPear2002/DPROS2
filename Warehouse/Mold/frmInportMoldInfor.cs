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

namespace WareHouse.Mold
{
    public partial class frmInportMoldInfor : Form
    {
        public frmInportMoldInfor()
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
            string MoldCode = "";
            int ShotTC = 0;
            int ShotTT = 0;
            int TotalShot = 0;
            string Category = "";
            string Note = "";
            string status = "";
            string cav = "";
            string cavNG = "";
            string plan = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {

                    MoldCode = row.Cells[0].Value.ToString();
                    ShotTC = int.Parse(row.Cells[1].Value.ToString());
                    ShotTT = int.Parse(row.Cells[2].Value.ToString());
                    TotalShot = int.Parse(row.Cells[3].Value.ToString());
                    Category = row.Cells[4].Value.ToString();
                    Note = row.Cells[5].Value.ToString();
                    status = row.Cells[6].Value.ToString();
                    cav = row.Cells[7].Value.ToString();
                    cavNG = row.Cells[8].Value.ToString();
                    plan = row.Cells[9].Value.ToString();
                    if (MoldCode == "")
                    {
                        eRror.Add("Dòng " + i + ": Dữ Liệu Liệu Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = MoldDAO.Instance.TestMoldInforByCode(MoldCode);
                        if (test == 1)
                        {
                            MoldDAO.Instance.UpdateMoldInfor(MoldCode, ShotTC, ShotTT, TotalShot, Category, Note,status,cav,cavNG,plan);
                        }
                        else
                        {
                            MoldDAO.Instance.InsertMoldInfor(MoldCode, ShotTC, ShotTT, TotalShot, 0, Category, Note, status, cav, cavNG, plan,DateTime.Now,0);
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

        private void frmInportMoldInfor_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
