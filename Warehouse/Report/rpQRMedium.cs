using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpQRMedium : DevExpress.XtraReports.UI.XtraReport
    {
        public rpQRMedium()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            txtMachineCode.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMachineName.DataBindings.Add("Text", DataSource, "MachineName");
            txtCodeFix.DataBindings.Add("Text", DataSource, "CodeTSCD");
            txtQrCode.DataBindings.Add("Text", DataSource, "QrCode");
        }

    }
}
