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
    public partial class frmPrinterMac : Form
    {

        public frmPrinterMac()
        {
            InitializeComponent();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string employess = Kun_Static.accountDTO.UserName;
            string PartCode = txtPartCode.Text.ToUpper();
            int countPart = (int)nudCountPart.Value;
            string PartName = PartDAO.Instance.NamePartByCode(PartCode);
            string MoldNumber = cbMoldNumber.Text;
            string MachineCode = cbMachineCode.Text;
            string FactoryCode = cbFactory.Text;
            string FactoryName = FactoryDAO.Instance.GetFactoryNameByCode(FactoryCode);
            string Rev = MacInforDAO.Instance.RevMac(PartCode, MachineCode, MoldNumber);
            string year = dtpkDate.Value.Year.ToString();
            string month = dtpkDate.Value.Month.ToString("D2");
            string date = dtpkDate.Value.Day.ToString("D2");
            string hour = dtpkDate.Value.Hour.ToString("D2");
            string min = dtpkDate.Value.Minute.ToString("D2");
            string secon = dtpkDate.Value.Second.ToString("D2");
            string millisecon = dtpkDate.Value.Millisecond.ToString("D2");
            string MoldCode = MacInforDAO.Instance.MoldCodeByMac(PartCode, MachineCode, MoldNumber);

            string standard = MacInforDAO.Instance.StandardCodeByAll(PartCode, MoldCode, MachineCode, FactoryCode);
            int idMac = MacInforDAO.Instance.TestMacByAll(PartCode, MoldCode, MachineCode);
            string nameVN = PartDAO.Instance.NameVNPart(PartCode);
            List<MacInforDTO> listM = MacInforDAO.Instance.GetListMac().Where(x => x.Standard == "OK" && x.PartCode == PartCode && x.MoldCode == MoldCode).ToList();
            if (standard != "OK")
            {
                if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác với máy đã đủ 4M!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                        MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M \nhoặc bạn chưa ưu tiên máy để in mác".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            int Important = MacInforDAO.Instance.ImportantMac(PartCode);
            if (Important == 1)
            {
                int t = (int)nudTo.Value;
                int cav = PartDAO.Instance.CavityByCode(PartCode);
                int d = (int)nudFrom.Value;
                int hs = 10;
                int nguyen = d / hs;
                int du = d % hs;
                string MoldNumberNew = "";
                List<ReportMacPart> listR = new List<ReportMacPart>();
                string BarCode = "";
                for (int o = 1; o <= cav; o++)
                {
                    if (du > 0)
                    {
                        nguyen = nguyen + 1;
                    }
                    MoldNumberNew = MoldNumber + "-" + o.ToString();
                    BarCode = PartCode + "&" + MachineCode + "&" + MoldNumberNew + "&" + FactoryCode;
                    for (int j = 1; j <= nguyen; j++)
                    {
                        for (int i = 0; i < hs; i++)
                        {
                            int serial = (i * nguyen) + t + (j - 1);
                            string datetime = year + month + date;
                            string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                            string QrCode = "";

                            QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
                            listR.Add(new ReportMacPart(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
                        }
                    }
                   
                    if (Kun_Static.accountDTO.Type != 1)
                    {
                        MacInforDAO.Instance.InsertHistoryMac(BarCode, DateTime.Now, employess, t, (t + d) - 1, dtpkDate.Value);
                    }
                }
                if (FactoryCode == "D1")
                {
                    rpMacInfor report = new rpMacInfor();
                    report.DataSource = listR;
                    report.LoadData();
                    report.Print();
                    this.Close();
                }
                else if (FactoryCode == "D2")
                {
                    rpMacInfor2 report = new rpMacInfor2();
                    report.DataSource = listR;
                    report.LoadData();
                    report.Print();
                    this.Close();
                }
            }
            else
            {
                string BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
                int t = (int)nudTo.Value;
                int d = (int)nudFrom.Value;
                int hs = 10;
                int nguyen = d / hs;
                int du = d % hs;
                List<ReportMacPart> listR = new List<ReportMacPart>();
                for (int j = 1; j <= nguyen; j++)
                {
                    for (int i = 0; i < hs; i++)
                    {
                        int serial = (i * nguyen) + t + (j - 1);
                        string datetime = year + month + date;
                        string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                        string QrCode = "";

                        QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
                        listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
                    }
                }
                if (du > 0)
                {
                    for (int i = (nguyen * hs) + t; i < t + d; i++)
                    {
                        int serial = i;
                        string datetime = year + month + date;
                        string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                        string QrCode = "";

                        QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
                        listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", Rev, FactoryCode, FactoryName, nameVN));
                    }
                }
                if (Kun_Static.accountDTO.Type != 1)
                {
                    MacInforDAO.Instance.InsertHistoryMac(BarCode, DateTime.Now, employess, t, (t + d) - 1, dtpkDate.Value);
                }
                if (FactoryCode == "D1")
                {
                    rpMacInfor report = new rpMacInfor();
                    report.DataSource = listR;
                    report.LoadData();
                    report.Print();
                    this.Close();
                }
                else if (FactoryCode == "D2")
                {
                    rpMacInfor2 report = new rpMacInfor2();
                    report.DataSource = listR;
                    report.LoadData();
                    report.Print();
                    this.Close();
                }
            }
        }
        private void btnPrintMacT_Click(object sender, EventArgs e)
        {
            nudCountPart.Enabled = true;
            if (MessageBox.Show("Bạn chọn NO để sửa số lượng chọn YES để tiếp tục in Mác?".ToUpper(), "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                btnPrint.Enabled = false;
                return;
            }
            if (MessageBox.Show("bạn muốn in mác thùng tạm ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string PartCode = txtPartCode.Text.ToUpper();
                int countPart = (int)nudCountPart.Value;
                string PartName = PartDAO.Instance.NamePartByCode(PartCode);
                string MoldNumber = cbMoldNumber.Text;
                string MachineCode = cbMachineCode.Text;
                string FactoryCode = cbFactory.Text;
                string FactoryName = FactoryDAO.Instance.GetFactoryNameByCode(FactoryCode);
                string year = dtpkDate.Value.Year.ToString();
                string month = dtpkDate.Value.Month.ToString("D2");
                string date = dtpkDate.Value.Day.ToString("D2");
                string hour = dtpkDate.Value.Hour.ToString("D2");
                string min = dtpkDate.Value.Minute.ToString("D2");
                string secon = dtpkDate.Value.Second.ToString("D2");
                string millisecon = dtpkDate.Value.Millisecond.ToString("D2");
                string MoldCode = MacInforDAO.Instance.MoldCodeByMac(PartCode, MachineCode, MoldNumber);
                string standard = MacInforDAO.Instance.StandardCodeByAll(PartCode, MoldCode, MachineCode, FactoryCode);
                int idMac = MacInforDAO.Instance.TestMacByAll(PartCode, MoldCode, MachineCode);
                List<MacInforDTO> listM = MacInforDAO.Instance.GetListMac().Where(x => x.Standard == "OK" && x.PartCode == PartCode && x.MoldCode == MoldCode).ToList();
                if (standard != "OK")
                {
                    if (MessageBox.Show("Linh kiện không đủ tiêu chuẩn 4M \nbạn vẫn muốn in mác với máy đã đủ 4M!".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
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
                            MessageBox.Show("mã sản phẩm này chưa có tiêu chuẩn 4M \nhoặc bạn chưa ưu tiên máy để in mác".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                int Important = MacInforDAO.Instance.ImportantMac(PartCode);
                string nameVN = PartDAO.Instance.NameVNPart(PartCode);
                if (Important == 1)
                {
                    int t = (int)nudTo.Value;
                    int cav = PartDAO.Instance.CavityByCode(PartCode);
                    int d = (int)nudFrom.Value;
                    int hs = 12;
                    int nguyen = d / hs;
                    int du = d % hs;
                    string MoldNumberNew = "";
                    List<ReportMacPart> listR = new List<ReportMacPart>();
                    string BarCode = "";
                    for (int o = 1; o <= cav; o++)
                    {
                        MoldNumberNew = MoldNumber + "-" + o.ToString();
                        BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
                        for (int j = 1; j <= nguyen; j++)
                        {
                            for (int i = 0; i < hs; i++)
                            {
                                int serial = (i * nguyen) + t + (j - 1);
                                string datetime = year + month + date;
                                string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                                string QrCode = "";

                                QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
                                listR.Add(new ReportMacPart(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
                            }
                        }
                        if (du > 0)
                        {
                            for (int i = (nguyen * 12) + t; i < t + d; i++)
                            {
                                int serial = i;
                                string datetime = year + month + date;
                                string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                                string QrCode = "";
                                QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumberNew + "&" + MachineCode + "&" + FactoryCode + "&&";
                                listR.Add(new ReportMacPart(PartCode, PartName, MoldNumberNew, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
                            }
                        }

                        rpMacTT report = new rpMacTT();
                        report.DataSource = listR;
                        report.LoadData();
                        report.Print();
                        if (Kun_Static.accountDTO.Type != 1)
                        {
                            MacInforDAO.Instance.InsertHistoryMac(BarCode, DateTime.Now, Kun_Static.accountDTO.UserName, t, (t + d) - 1, dtpkDate.Value);
                        }
                        this.Close();
                    }
                }
                else
                {
                    int t = (int)nudTo.Value;
                    int d = (int)nudFrom.Value;
                    int hs = 12;
                    int nguyen = d / hs;
                    int du = d % hs;
                    List<ReportMacPart> listR = new List<ReportMacPart>();
                    string BarCode = PartCode + "&" + MachineCode + "&" + MoldNumber + "&" + FactoryCode;
                    for (int j = 1; j <= nguyen; j++)
                    {
                        for (int i = 0; i < hs; i++)
                        {
                            int serial = (i * nguyen) + t + (j - 1);
                            string datetime = year + month + date;
                            string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                            string QrCode = "";

                            QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
                            listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
                        }
                    }
                    if (du > 0)
                    {
                        for (int i = (nguyen * 12) + t; i < t + d; i++)
                        {
                            int serial = i;
                            string datetime = year + month + date;
                            string LotNo = year + month + date + "-" + ((int)nudLot.Value).ToString("D4");
                            string QrCode = "";
                            QrCode = "&" + serial.ToString("D4") + "&&" + PartCode + "&" + FactoryName + "&" + (datetime + hour + min + secon + millisecon) + "&" + LotNo + "&" + countPart + "&" + MoldNumber + "&" + MachineCode + "&" + FactoryCode + "&&";
                            listR.Add(new ReportMacPart(PartCode, PartName, MoldNumber, MachineCode, countPart, BarCode, QrCode.ToUpper(), serial.ToString("D4"), LotNo, datetime, "", "", FactoryCode, FactoryName, nameVN));
                        }
                    }

                    rpMacTT report = new rpMacTT();
                    report.DataSource = listR;
                    report.LoadData();
                    report.Print();
                    if(Kun_Static.accountDTO.Type != 1)
                    {
                        MacInforDAO.Instance.InsertHistoryMac(BarCode, DateTime.Now, Kun_Static.accountDTO.UserName, t, (t + d) - 1, dtpkDate.Value);
                    }
                    this.Close();
                }
            }
            else
            {
                btnPrint.Enabled = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TextChange();
            txtBarCode.Enabled = false;
            timer1.Stop();
        }
        void TextChange()
        {
            string BarCode = txtBarCode.Text.ToUpper();
            if (BarCode.Length > 0)
            {
                try
                {
                    string[] array = BarCode.Split('&');
                    txtPartCode.Text = array[1];
                    cbMachineCode.Text = array[2];
                    cbMoldNumber.Text = array[3];
                    cbFactory.Text = array[5];
                    float quantityPart = PartDAO.Instance.CountPartByCode(array[1]);
                    int Important = MacInforDAO.Instance.ImportantMac(array[1]);
                    int a = int.Parse(array[4]);
                    if (Important == 1)
                    {
                        int cav = PartDAO.Instance.CavityByCode(array[1]);
                        a = a / cav;
                    }
                    nudFrom.Value = a;
                    nudCountPart.Value = int.Parse(quantityPart.ToString());

                }
                catch
                {
                    timer1.Stop();
                    MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
