using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMacTT : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMacTT()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtMachine.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMoldNumber.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtCount.DataBindings.Add("Text", DataSource, "CountPart");
            txtNumber.DataBindings.Add("Text", DataSource, "Count");
            txtDatetime.DataBindings.Add("Text", DataSource, "DateTimeSTR");
            txtBarCode.DataBindings.Add("Text", DataSource, "BarCode");
            txtFactoryCode.DataBindings.Add("Text", DataSource, "FactoryCode");
        }

    }
}
