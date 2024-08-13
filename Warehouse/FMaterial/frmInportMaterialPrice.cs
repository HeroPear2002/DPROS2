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
using DTO;

namespace WareHouse.FMaterial
{
    public partial class frmInportMaterialPrice : DevExpress.XtraEditors.XtraForm
    {
        public frmInportMaterialPrice()
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
            string MaterialCode = "";
            DateTime DateInput = DateTime.Now;
            Decimal PriceVND = 0;
            string PriceUSD = "";
            int StatusPrice = 0;
            string Note = "";
            int dem = GcData.Rows.Count;
            foreach (DataGridViewRow row in GcData.Rows)
            {
                i++;
                if(i != dem)
                {
                    try
                    {
                        MaterialCode = row.Cells["Material Code"].Value.ToString();
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": Mã Nguyên Liệu không đúng".ToUpper());
                        countError++;
                    }
                    try
                    {
                        DateInput = DateTime.Parse(row.Cells["Month Year"].Value.ToString());
                        if (DateInput.Day < 15)
                        {
                            DateInput = DateInput.AddDays(1 - DateInput.Day);
                        }
                        else
                        {
                            DateInput = DateInput.AddDays(1 - DateInput.Day + 14);
                        }
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": Định dạng ngày tháng năm không đúng".ToUpper());
                        countError++;
                    }
                    try
                    {
                        PriceVND = decimal.Parse(row.Cells["VND"].Value.ToString());
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": Đơn giá VND không đúng".ToUpper());
                        countError++;
                    }
                    try
                    {
                        PriceUSD = row.Cells["USD"].Value.ToString();
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": đơn giá USD không đúng".ToUpper());
                        countError++;
                    }
                    try
                    {
                        Note = row.Cells["Note"].Value.ToString();
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": Ghi chú không đúng".ToUpper());
                        countError++;
                    }
                    if (MaterialCode.Length == 0)
                    {
                        eRror.Add("Dòng " + i + ": mã nguyên liệu trống".ToUpper());
                        countError++;
                    }
                    else
                    {
                        MaterialPriceDTO test = MaterialDAO.Instance.GetItemMaterPrice(MaterialCode, DateInput);
                        if (test == null)
                        {
                            MaterialDAO.Instance.InsertMaPrice(MaterialCode, DateInput, PriceVND, PriceUSD, StatusPrice, Note);

                        }
                        else
                        {
                            eRror.Add("Dòng " + i + ": Thông tin đã tồn tại".ToUpper());
                            countError++;
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

        private void frmInportMaterialPrice_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}