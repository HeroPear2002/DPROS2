using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpBarCodePO : DevExpress.XtraReports.UI.XtraReport
    {
        public rpBarCodePO()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {

            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtBarCodePO.DataBindings.Add("Text", DataSource, "BarCode");
            txtQrcode.DataBindings.Add("Text", DataSource, "BarCode");
        }

    }
}
