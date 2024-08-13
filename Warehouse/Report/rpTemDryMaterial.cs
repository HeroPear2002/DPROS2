using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.FParts
{
    public partial class rpTemDryMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        public rpTemDryMaterial()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            txtBarCode.DataBindings.Add("Text", DataSource, "Note");
            txtQrcode.DataBindings.Add("Text", DataSource, "Note");
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtMachineCode.DataBindings.Add("Text", DataSource, "MachineCode");
            txtWeight.DataBindings.Add("Text", DataSource, "QuantityDry");
            txtDateTime.DataBindings.Add("Text", DataSource, "DateDrying");
            txtEmployess.DataBindings.Add("Text", DataSource, "Employess");
            txtMachineDry.DataBindings.Add("Text", DataSource, "MachineDry");
        }
    }
}
