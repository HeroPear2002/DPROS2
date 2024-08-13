using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpQrCodeMold : DevExpress.XtraReports.UI.XtraReport
    {
        public rpQrCodeMold()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtMoldCode.DataBindings.Add("Text", DataSource, "MoldCode");
            txtMoldName.DataBindings.Add("Text", DataSource, "MoldName");
            txtMoldNumber.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtDateSX.DataBindings.Add("Text", DataSource, "DateSX");
            txtShotTC.DataBindings.Add("Text", DataSource, "ShotTC");
            txtShotTT.DataBindings.Add("Text", DataSource, "ShotTT");
            txtTotalShot.DataBindings.Add("Text", DataSource, "TotalShot");
            txtQrcode.DataBindings.Add("Text", DataSource, "QrCode");
            txtCav.DataBindings.Add("Text", DataSource, "Cav");
        }

    }
}
