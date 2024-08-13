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
    public partial class frmMacTKG : Form
    {

        public frmMacTKG()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            this.AcceptButton = btnPrint;
            LockControl();
            txtLine.Text = "75";
            txtRoll.Text = "V";
            LoadPart();
        }
        void LockControl()
        {
            cbLPartCode.Enabled = false;
            cbMachineCode.Enabled = false;
            cbMoldCode.Enabled = false;
            nudCountPart.Enabled = false;
            nudFrom.Enabled = false;
            nudTo.Enabled = false;
            btnPrint.Enabled = false;
            txtLine.Enabled = false;
            txtRoll.Enabled = false;
        }
        void OpenControl()
        {
            cbLPartCode.Enabled = true;
            cbMachineCode.Enabled = true;
            cbMoldCode.Enabled = true;
            nudCountPart.Enabled = true;
            nudFrom.Enabled = true;
            nudTo.Enabled = true;
            btnPrint.Enabled = true;
            txtLine.Enabled = true;
            txtRoll.Enabled = true;
        }
        int kun = 0;
        string[] arrayAB = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"};

     

        void LoadPart()
        {
            cbLPartCode.Properties.DataSource = MacInforDAO.Instance.GetListPart();
            cbLPartCode.Properties.DisplayMember = "PartCode";
            cbLPartCode.Properties.ValueMember = "PartCode";
            LoadMoldCode();
        }
        void LoadMoldCode()
        {
            string partCode = cbLPartCode.Text; ;
            cbMoldCode.DataSource = MacInforDAO.Instance.GetListMoldByPart(partCode);
            cbMoldCode.DisplayMember = "MoldCode";
            cbMoldCode.ValueMember = "MoldCode";
            LoadMachineCode();
        }
        void LoadMachineCode()
        {
            string partCode = cbLPartCode.Text;
            string moldCode = cbMoldCode.Text;
            cbMachineCode.DataSource = MacInforDAO.Instance.GetListMachineByPartMold(partCode, moldCode);
            cbMachineCode.DisplayMember = "MachineCode";
            cbMachineCode.ValueMember = "MachineCode";
        }
        void LoadFactoryCode()
        {
            cbFactoryCode.DataSource = FactoryDAO.Instance.GetListDistinctAllFactory();
            cbFactoryCode.DisplayMember = "FactoryCode";
            cbFactoryCode.ValueMember = "FactoryCode";
        }
        void LoadCountPart()
        {
            string PartCode = cbLPartCode.Text;
            int countpart = 0;
            if (kun == 0)
            {
                countpart = PartDAO.Instance.CountPartByCode(PartCode);
            }
            else
            {
                countpart = (int)PartDAO.Instance.WeightByCode(PartCode);
            }
            nudCountPart.Value = countpart;
        }
        private void cbLPartCode_EditValueChanged(object sender, EventArgs e)
        {
            LoadMoldCode();
            LoadMachineCode();
            LoadCountPart();
            LoadFactoryCode();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            DateTime today = dtpkDate.Value;
            string PartCode = cbLPartCode.Text;
            string FactoryCode = cbFactoryCode.Text;
            int countPart = (int)nudCountPart.Value;
            string PartNameJP = PartDAO.Instance.NamePartByCode(PartCode);
            string MoldCode = cbMoldCode.Text;
            string MachineCode = cbMachineCode.Text;
            string materialCode = PartDAO.Instance.MaterialCodeByCode(PartCode);
            string materialName = PartDAO.Instance.MaterialNameByCode(PartCode);
            string nameVN = PartDAO.Instance.NameVNPart(PartCode);
            int month = today.Month;
            int year = (today.Year)%10;
            if(year == 0)
            {
                year = 10;
            }
            int day = today.Day;
            int t = (int)nudTo.Value;
            int d = (int)nudFrom.Value;
            string LotNo = (arrayAB[year - 1] + arrayAB[month - 1]+day+ txtLine.Text + txtRoll.Text).ToUpper();
            List<ReportMacPart> listR = new List<ReportMacPart>();
            List<MacInforDTO> listM = MacInforDAO.Instance.GetListMacPrint(PartCode, MachineCode, MoldCode).Distinct().ToList();
            int hs = 4;
            int nguyen = d / hs;
            int du = d % hs;
            for (int j = 1; j <= nguyen; j++)
            {
                for (int i = 0; i < hs; i++)
                {
                    int serial = (i * nguyen) + t + (j - 1);
                    foreach (MacInforDTO item in listM)
                    {
                        string QrCode = "&";
                        string BarCode = item.PartCode + "&" + item.MachineCode + "&" + item.MoldNumber + "&" + FactoryCode;
                        listR.Add(new ReportMacPart(PartCode, PartNameJP, item.MoldNumber, item.MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, materialCode, materialName, "", FactoryCode, "", nameVN));
                    }
                }
            }
            if(du>0)
            {
                for (int i = (nguyen * hs + t); i < t + d; i++)
                {
                    int serial = i;
                    foreach (MacInforDTO item in listM)
                    {
                        string QrCode = "&";
                        string BarCode = item.PartCode + "&" + item.MachineCode + "&" + item.MoldNumber + "&" + FactoryCode;
                        listR.Add(new ReportMacPart(PartCode, PartNameJP, item.MoldNumber, item.MachineCode, countPart, BarCode, QrCode, serial.ToString("D4"), LotNo, materialCode, materialName, "", FactoryCode, "",nameVN));
                    }
                }
            }
            if(kun == 0)
            {
                rpMacTKG report = new rpMacTKG();
                report.DataSource = listR;
                report.LoadData();
                report.PrintDialog();
            }
            else
            {
                rpMacTKGIN report = new rpMacTKGIN();
                report.DataSource = listR;
                report.LoadData();
                report.PrintDialog();
            }
            string employess = Kun_Static.accountDTO.UserName;
            MacInforDAO.Instance.InsertHistoryMac(PartCode, DateTime.Now, employess, t, t + d, dtpkDate.Value);
            this.Close();
        }
        private void cbMoldCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMachineCode();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            kun = 0;
            OpenControl();
            try
            {
                LoadCountPart();
            }
            catch 
            {

            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            kun = 1;
            OpenControl();
            try
            {
                LoadCountPart();
            }
            catch
            {

            }
        }
    }
}
