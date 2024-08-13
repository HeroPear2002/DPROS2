using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpKanbanMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        public rpKanbanMaterial()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtBarCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtQrcode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtPartCode.DataBindings.Add("Text", DataSource, "RohsFile");
        }
    }
}
