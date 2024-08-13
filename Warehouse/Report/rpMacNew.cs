using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMacNew : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMacNew()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtPartDD.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtMachineCode.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMoldNumber.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtQuantity.DataBindings.Add("Text", DataSource, "CountPart");
            txtNumber.DataBindings.Add("Text", DataSource, "Count");
            txtStyleMaterial.DataBindings.Add("Text", DataSource, "LotNo");
            txtDatetime.DataBindings.Add("Text", DataSource, "DateTimeSTR");
            txtBarCode.DataBindings.Add("Text", DataSource, "BarCode");
            txtColor.DataBindings.Add("Text", DataSource, "Color");
            txtPartCode.DataBindings.Add("Text", DataSource, "QrCode");
            txtBoxName.DataBindings.Add("Text", DataSource, "BoxName");
            txtFactoryCode.DataBindings.Add("Text", DataSource, "FactoryCode");
        }
    }
}
