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
using DAO;
using DTO;

namespace WareHouse.Mac
{
    public partial class frmHistoryMac : DevExpress.XtraEditors.XtraForm
    {
        public frmHistoryMac()
        {
            InitializeComponent();
            LoadDate();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now;
            dtpkDate1.Value = today.Date.AddDays(-(today.Day)).AddSeconds(1);
            dtpkDate2.Value = dtpkDate1.Value.AddMonths(1).AddSeconds(-1);
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime Date1 = dtpkDate1.Value;
            DateTime Date2 = dtpkDate2.Value;
            List<HistoryMacDTO> listH = MacInforDAO.Instance.GetListMacbyDate(Date1, Date2);
            List<NewHistoryMac> listNew = new List<NewHistoryMac>();
            foreach (HistoryMacDTO item in listH)
            {
                string barcode = item.PartCode;
                string[] array = { };
                string machineCode = "";
                string moldNumber = "";
                string part = item.PartCode;
                try
                {
                    array = barcode.Split('&');
                    machineCode = array[1];
                    moldNumber = array[2];
                    part = array[0];
                }
                catch
                {
                }
                HistoryMacDTO h = new HistoryMacDTO(part, item.DateIn, item.Employess, item.NumberTo, item.NumberFrom, item.Lot);
                listNew.Add(new NewHistoryMac(h, machineCode, moldNumber));
            }
            GCData.DataSource = listNew;
        }
    }
}