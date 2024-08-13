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

namespace WareHouse.Employess
{
    public partial class frmInPortExcelError : DevExpress.XtraEditors.XtraForm
    {
        public frmInPortExcelError()
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
           
            string name = "";
            int point = 0;
            string room = "";
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                try
                {
                    name = row.Cells["Name"].Value.ToString();
                    point = int.Parse(row.Cells["Point"].Value.ToString());
                    room = row.Cells["Room"].Value.ToString();
                    
                    if (name == "")
                    {
                        eRror.Add("Dòng " + i + ": Thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = EmployessDAO.Instance.TestNameEr(name);
                        if(test == -1)
                        {
                            int testRoom = EmployessDAO.Instance.TestRoom(room);
                            if(testRoom == 1)
                            {
                                EmployessDAO.Instance.InsertError(name, point, room.ToUpper());
                            }
                            else
                            {
                                eRror.Add("Dòng " + i + ": Mã phòng ban không đúng".ToUpper());
                                slLoi++;
                            }
                        }
                        else
                        {
                            eRror.Add("Dòng " + i + ": Tên hạng mục đã tồn tại".ToUpper());
                            slLoi++;
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

        private void frmInPortExcelError_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormError f = new frmFormError();
            f.Show();
        }
    }
}