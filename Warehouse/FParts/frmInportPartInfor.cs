using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ExcelDataReader;
using System.IO;
using DAO;

namespace WareHouse.FParts
{
    public partial class frmInportPartInfor : DevExpress.XtraEditors.XtraForm
    {
        public frmInportPartInfor()
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
                    txtUrl.Text = ofd.FileName;
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtError.Text = "";
            eRror = new List<string>();
            int i = 0;
            int countError = 0;
            string partCode = "";
            float ratio = 0;
            string weight = "0";
            int dem = GcData.Rows.Count;
          
            foreach (DataGridViewRow row in GcData.Rows)
            {
                i++;
                if (i < dem)
                {
                    try
                    {
                        partCode = row.Cells["Part Code"].Value.ToString();
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": Mã linh kiện không đúng".ToUpper());
                        countError++;
                    }


                    try
                    {
                        ratio = (float)Convert.ToDouble(row.Cells["Ratio"].Value.ToString());
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": tỉ lệ không đúng".ToUpper());
                        countError++;
                    }
                    try
                    {
                        weight = row.Cells["Weight"].Value.ToString();
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": trọng lượng không đúng".ToUpper());
                        countError++;
                    }
                    if (partCode.Length == 0)
                    {
                        eRror.Add("Dòng " + i + ": mã linh kiện trống".ToUpper());
                        countError++;
                    }
                    else
                    {
                        int test = PartDAO.Instance.TestPartInfor(partCode);
                        if (test == -1)
                        {
                            PartDAO.Instance.InsertPartInfor(partCode, ratio, weight);
                       
                        }
                        else
                        {
                            PartDAO.Instance.UpdatePartInfor(partCode, ratio, weight);
                        }
                    }
                }
            }
            txtError.Text = "Lỗi :" + countError + " Lỗi";
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

        private void btnListError_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GcData.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }

        private void frmInportPartInfor_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}