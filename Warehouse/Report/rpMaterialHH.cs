using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMaterialHH : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMaterialHH()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtQrcode.DataBindings.Add("Text", DataSource, "Name");
            txtBarCode.DataBindings.Add("Text", DataSource, "Name");
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtNumber.DataBindings.Add("Text", DataSource, "Count");
        }
    }
}
