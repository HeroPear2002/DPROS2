using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpCouponPart : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCouponPart()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtDateInput.DataBindings.Add("Text", DataSource, "DateInput");
            txtDateManufacturi.DataBindings.Add("Text", DataSource, "DateManufacturi");
            txtName.DataBindings.Add("Text", DataSource, "Name");
            txtFactoryCode.DataBindings.Add("Text", DataSource, "FactoryCode");
            txtQrcode.DataBindings.Add("Text", DataSource, "QrCode");
        }
    }
}
