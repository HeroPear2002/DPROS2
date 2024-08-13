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
using System.Collections;
using DTO;

namespace WareHouse.Order
{
    public partial class frmFCInport : DevExpress.XtraEditors.XtraForm
    {
        public frmFCInport()
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
            eRror = new List<string>();
            int i = 0; int slLoi = 0;
            int dem = GCData.Rows.Count;
            DateTime date = DateTime.Now;
            int quantity = 0;
            ArrayList arrayList = new ArrayList();
            foreach (DataGridViewRow item in GCData.Rows)
            {
                i++;
                if (i == 1)
                {
                    for (int j = 0; j <= 5; j++)
                    {
                        string a = item.Cells[j + 2].Value.ToString();
                        arrayList.Add(a);
                    }
                }
                if (i < dem && i > 1)
                {
                    string part = item.Cells[0].Value.ToString();
                    if(part.Length == 0)
                    {
                        eRror.Add("Dòng " + i + ": Mã linh kiện Trống".ToUpper());
                        slLoi++;
                    }
                    for (int j = 0; j <= 5; j++)
                    {
                        date = DateTime.Parse(arrayList[j].ToString());
                        date = date.AddDays(1-date.Day);
       
                        FCPartDTO fCPartDTO = OrderDAO.Instance.GetItemFCPart(part, date);
                        quantity = int.Parse(item.Cells[j + 2].Value.ToString());
                        if (fCPartDTO != null)
                        {
                            //Update 
                            OrderDAO.Instance.UpdateFCPart(fCPartDTO.Id, part, quantity, date, Kun_Static.accountDTO.UserName);
                        }
                        else
                        {
                            //Insert
                            OrderDAO.Instance.InsertFCPart(part, quantity, date, Kun_Static.accountDTO.UserName);
                        }
                    }
                }
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

        private void btnError_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList();
            f.ShowDialog();
        }

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            GCData.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }

        private void frmFCInport_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}