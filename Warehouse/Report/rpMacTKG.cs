using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMacTKG : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMacTKG()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtNameJP.DataBindings.Add("Text", DataSource, "PartName");
            txtNameEN.DataBindings.Add("Text", DataSource, "Color");
            txtQuantity.DataBindings.Add("Text", DataSource, "CountPart");
            txtNumberAuto.DataBindings.Add("Text", DataSource, "Count");
            txtLotNo.DataBindings.Add("Text", DataSource, "LotNo");
            txtPartCodeKH.DataBindings.Add("Text", DataSource, "DateTimeSTR");
            txtBarCode.DataBindings.Add("Text", DataSource, "BarCode");
            txtCodeDD.DataBindings.Add("Text", DataSource, "PartCode");
            txtFactoryCode.DataBindings.Add("Text", DataSource, "FactoryCode");
        }

    }
}
