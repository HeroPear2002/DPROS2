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

namespace WareHouse.Machine
{
    public partial class frmInportMachine : Form
    {
        public frmInportMachine()
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
            string machineCode = "";
            string machineName = "";
            string machineInfor = "";
            string machineMaker = "";
            DateTime DateInput = DateTime.Now;
            string CodeTSCD = "";
            string Vendor = "";
            DateTime DateSX = DateTime.Now;
            string DateMaker = "";
            int Device = Kun_Static.DeviceId;
            int StatusMachine = 0;
            int dem = dataG.Rows.Count;
            foreach (DataGridViewRow row in dataG.Rows)
            {
                i++;
                if (i < dem)
                {
                    machineCode = row.Cells[0].Value.ToString();
                    machineName = row.Cells[1].Value.ToString();
                    machineInfor = row.Cells[2].Value.ToString();
                    machineMaker = row.Cells[3].Value.ToString();
                    Vendor = row.Cells[4].Value.ToString();
                    DateMaker = row.Cells[5].Value.ToString();
                    string dateI = row.Cells[6].Value.ToString();
                    string dateS = row.Cells[7].Value.ToString();
                    try
                    {
                        DateInput = DateTime.Parse(dateI);

                    }
                    catch
                    {

                    }
                    try
                    {
                        DateSX = DateTime.Parse(dateS);

                    }
                    catch
                    {

                    }
                    CodeTSCD = row.Cells[8].Value.ToString();

                    if (machineCode == "")
                    {
                        eRror.Add("Dòng " + i + ": thông tin Trống".ToUpper());
                        slLoi++;
                    }
                    else
                    {
                        int test = MachineDAO.Instance.TestMachineByCode(machineCode);
                        if (test == 1)
                        {
                            eRror.Add("Dòng " + i + ": mã thiết bị đã tồn tại".ToUpper());
                            slLoi++;
                        }
                        else
                        {
                            MachineDAO.Instance.InsertMachine(machineCode, machineName, machineInfor, machineMaker, DateInput, CodeTSCD, Vendor, DateSX, Device, StatusMachine, DateMaker);
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

        private void btnList_Click(object sender, EventArgs e)
        {
            frmErrorList f = new frmErrorList(eRror);
            f.ShowDialog();
        }

        private void frmInportMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
