using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMacTemma : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMacTemma()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtCount.DataBindings.Add("Text", DataSource, "CountPart");
            txtNumber.DataBindings.Add("Text", DataSource, "Count");
            txtLotNo.DataBindings.Add("Text", DataSource, "LotNo");
            txtBarCode.DataBindings.Add("Text", DataSource, "BarCode");
            txtFactoryCode.DataBindings.Add("Text", DataSource, "FactoryCode");
        }
    }
}
