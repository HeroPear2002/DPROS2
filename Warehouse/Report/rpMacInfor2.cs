using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpMacInfor2 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpMacInfor2()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtMachine.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMoldNumber.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtCount.DataBindings.Add("Text", DataSource, "CountPart");
            txtQrcode.DataBindings.Add("Text", DataSource, "QrCode");
            txtNumber.DataBindings.Add("Text", DataSource, "Count");
            txtLotNo.DataBindings.Add("Text", DataSource, "LotNo");
            txtDatetime.DataBindings.Add("Text", DataSource, "DateTimeSTR");
            txtFactory.DataBindings.Add("Text", DataSource, "FactoryCode");
            txtFactoryName.DataBindings.Add("Text", DataSource, "FactoryName");
            txtRev.DataBindings.Add("Text", DataSource, "BoxName");
            txtNameVN.DataBindings.Add("Text", DataSource, "NameVN");
        }
    }
}
