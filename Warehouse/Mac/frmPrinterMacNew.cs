using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Report;

namespace WareHouse.Mac
{
    public partial class frmPrinterMacNew : Form
    {
        public frmPrinterMacNew()
        {
            InitializeComponent();
        }
        void LoadBox()
        {
            string partCode = txtPartCode.Text;
            cbBoxName.DataSource = BoxNatureDAO.Instance.GetlistBoxbyNote(partCode);
            cbBoxName.DisplayMember = "BoxName";
            cbBoxName.ValueMember = "BoxName";
            LoadCountPart();
        }
        void LoadCountPart()
        {
            string BoxName = cbBoxName.Text;
            string code = txtPartCode.Text;
            int countpart = BoxNatureDAO.Instance.QuantityBoxByName(BoxName, code);
            nudCountPart.Value = countpart;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string PartCode = txtPartCode.Text.ToUpper();
            string PartName = PartDAO.Instance.NamePartByCode(PartCode);
            string MoldNumber = cbMoldNumber.Text;
            string MachineCode = cbMachineCode.Text;
            string FactoryCode = cbFactoryCode.Text;
            string year = dtpkDate.Value.Year.ToString();
            string month = dtpkDate.Value.Month.ToString("D2");
            string date = dtpkDate.Value.Day.ToString("D2");
            string hour = dtpkDate.Value.Hour.ToString("D2");
            string min = dtpkDate.Value.Minute.ToString("D2");
            string secon = dtpkDate.Value.Second.ToString("D2");
            string millisecon = dtpkDate.Value.Millisecond.ToString("D2");
            int t = (int)nudTo.Value;
            int d = (int)nudFrom.Value;
            List<ReportMacPart> listR = new List<ReportMacPart>();
            string avata = PartDAO.Instance.CustomerByCode(PartCode);
            string boxName = cbBoxName.Text;
            int Important = MacInforDAO.Instance.ImportantMac(PartCode);
            if (boxName.Length <= 0)
            {
                MessageBox.Show("bạn chưa điền loại thùng/hộp !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int countPart = (int)nudCountPart.Value;
            string color = txtColor.Text;
            string type = txtType.Text;
            if (color.Length == 0)
            {
                MessageBox.Show("bạn chưa điền màu nguyên liệu".ToUpper());
                return;
            }
            if (type.Length == 0)
            {
                MessageBox.Show("bạn chưa điền loại nguyên liệu".ToUpper());
                return;
            }
            string MoldCode = MacInforDAO.Instance.MoldCodeByMac(PartCode, MachineCode, MoldNumber);
            string standard = MacInforDAO.Instance.StandardCodeByAll(PartCode, MoldCode, MachineCode, FactoryCode);
            int idMac = MacInforDAO.Instance.TestMacByAll(PartCode, MoldCode, MachineCode);
            string nameVN = PartDAO.Instance.NameVNPart(PartCode);
            List<MacInforDTO> listM = MacInforDAO.Instance.GetListMac().Where(x => x.Standard == "OK" && x.PartCode == PartCode && x.MoldCode == MoldCode).ToList();
            if (standard != "OK")
            {
                if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    // Lấy mã máy theo ds 4M
                    if (listM.Where(x => x.StatusM == 1).ToList().Count > 0)
                    {
                        var result = from s in listM where (s.StatusM == 1) select s.MachineCode;
                        foreach (string item in result)
                        {
                            MachineCode = item;
                        }
                    }
                    else
                    {
                        MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            string BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
            if (Important == 1)
            {
                if (txtCav.Value == 0)
                {
                    MessageBox.Show("bạn chưa điền số Cav cần In!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MoldNumber = MoldNumber + "-" + txtCav.Text;
            }
            int hs = 6;
            int nguyen = d / hs;
            int du = d % hs;
            for (int j = 1; j <= nguyen; j++)
            {
                for (int i = 0; i < hs; i++)
                {
                    int serial = (i * nguyen) + t + (j - 1);
                    string datetime = year + month + date;
                    string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                  
                    listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, avata, serial.ToString("D4"), type, LotNo, color, boxName, FactoryCode, "",nameVN));
                }
            }
            if (du > 0)
            {
                for (int i = (nguyen * hs) + t; i < t + d; i++)
                {
                    int serial = i;
                    string datetime = year + month + date;
                    string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                 
                    listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, avata, serial.ToString("D4"), type, LotNo, color, boxName, FactoryCode, "",nameVN));
                }
            }
            rpMacNew report = new rpMacNew();
            report.DataSource = listR;
            report.LoadData();
            report.Print();
            string employess = Kun_Static.accountDTO.UserName;
            MacInforDAO.Instance.InsertHistoryMac(BarCode, DateTime.Now, employess, t, (t + d) - 1, dtpkDate.Value);
            this.Close();
        }

        private void cbBoxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCountPart();
        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TextChange();
            LoadBox();
            txtBarCode.Enabled = false;
            timer1.Stop();
        }
        void TextChange()
        {
            string BarCode = txtBarCode.Text;
            try
            {
                string[] array = BarCode.Split('&');
                txtPartCode.Text = array[1];
                cbMachineCode.Text = array[2];
                cbMoldNumber.Text = array[3];
                nudFrom.Value = int.Parse(array[4]);
                cbFactoryCode.Text = array[5];
            }
            catch
            {
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
