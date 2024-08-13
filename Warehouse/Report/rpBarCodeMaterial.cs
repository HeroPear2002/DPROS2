using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpBarCodeMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        public rpBarCodeMaterial()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtCount.DataBindings.Add("Text", DataSource, "Count");
            txtBarCode.DataBindings.Add("Text", DataSource, "Name");
         
        }

    }
}
