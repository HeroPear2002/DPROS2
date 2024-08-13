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

namespace WareHouse.PO_and_Order
{
    public partial class frmInportPOFix : Form
    {
        List<string> eRror = new List<string>();
        public frmInportPOFix()
        {
            InitializeComponent();
        }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            txtTTT.Text = "";
            eRror = new List<string>();
            int i = 1, slLoi = 0;
            string POCode = "";
            string PartCode = "";
            int quantity = 0;
            int secon = 0;
            DateTime DateDK1;
            DateTime DateDK2;
            DateTime DateOut;
            DateTime DateInput = DateTime.Now;
            string Factory = "";
            string CarNumber = "";
            int dem = dataG.Rows.Count;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                if(i <= dem)
                {
                    string MaPO = row.Cells["Purchasing number"].Value.ToString();
                    try
                    {
                        string[] arrayList = MaPO.Split('-');
                        POCode = arrayList[0] + arrayList[1];
                    }
                    catch 
                    {
                        eRror.Add("Dòng " + i + ": Cột Purchasing number không đúng".ToUpper());
                        slLoi++;
                    } 
                   
                    PartCode = row.Cells["Material number"].Value.ToString();
                    quantity = int.Parse(row.Cells["PO quantity"].Value.ToString());
                    string Price = row.Cells["Unit price"].Value.ToString();
                    Factory = row.Cells["Factory"].Value.ToString();
                    try
                    {
                        CarNumber = row.Cells["Car Number"].Value.ToString();
                    }
                    catch 
                    {
                        eRror.Add("Dòng " + i + ": Cột Car Number không đúng".ToUpper());
                        slLoi++;
                    }
                    CarNumber = row.Cells["Car Number"].Value.ToString();
                    try
                    {
                        DateDK1 = DateTime.Parse(row.Cells["Time Receive"].Value.ToString());
                        secon = (int)(DateDK1 - DateDK1.Date).TotalSeconds;
                    }
                    catch
                    {
                        secon = 0;
                    }
                    string a = row.Cells["Delivery date"].Value.ToString();
                    string[] array = a.Split('.');
                    DateDK2 = DateTime.ParseExact(array[0] + "/" + array[1] + "/" + array[2], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateOut = DateDK2.Date.AddSeconds(secon);
                    if (POCode.Length == 0 || PartCode.Length == 0)
                    {
                        eRror.Add("Dòng " + i + ": Mã PO hoặc Mã linh kiện Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        long IdInput = PODAO.Instance.TestPO(POCode, PartCode, Price);
                        if (IdInput == -1)
                        {
                            eRror.Add("Dòng " + i + ": thông tin của PO không đúng".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            PODTO pODTO = PODAO.Instance.GetItemPOInput(IdInput);
                            int statusPO = pODTO.StatusPO;
                            int sum = POFixDAO.Instance.SumQuantity(IdInput);
                            if (statusPO == 1)
                            {
                                eRror.Add("Dòng " + i + ": PO đã giao".ToUpper());
                                slLoi++;
                            }
                            else if (pODTO.Quantity < (quantity + sum))
                            {
                                eRror.Add("Dòng " + i + ": Số lượng giao quá lớn!".ToUpper());
                                slLoi++;
                            }
                            else
                            {
                                POFixDAO.Instance.InsertPOFix(IdInput, POCode, PartCode, quantity, DateOut, "", 0, DateInput, Factory, CarNumber);
                            }
                        }
                    }
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

        private void cbSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataG.DataSource = ds.Tables[cbSheet.SelectedIndex];
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }

        private void frmInportPOFix_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
