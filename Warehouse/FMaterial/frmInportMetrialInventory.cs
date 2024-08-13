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
using System.IO;
using ExcelDataReader;
using DAO;
using DTO;

namespace WareHouse.FMaterial
{
    public partial class frmInportMetrialInventory : DevExpress.XtraEditors.XtraForm
    {
        public frmInportMetrialInventory()
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
            int Quantity = 0;
            string Note = "";
            int dem = GcData.Rows.Count;
            MaterialInforDAO.Instance.DeleteTableMaterial();
            foreach (DataGridViewRow row in GcData.Rows)
            {
                i++;
                if (i < dem)
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
                        Quantity = int.Parse(row.Cells["Quantity"].Value.ToString());
                    }
                    catch
                    {
                        eRror.Add("Dòng " + i + ": số lượng tồn không đúng".ToUpper());
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
                        MaterialInforDAO.Instance.InsertTableMaterial(MaterialCode, Quantity, Note);   
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
        private void frmInportMetrialInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender,e);
        }
    }
}