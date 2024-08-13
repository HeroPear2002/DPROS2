using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using System.Collections.Generic;

namespace WareHouse.Report
{
    public partial class AutoPrintMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        List<BarcodeMaterial> _list = new List<BarcodeMaterial>();
        public AutoPrintMaterial()
        {
            InitializeComponent();
          
        }
        public AutoPrintMaterial(List<BarcodeMaterial> list)
        {
            InitializeComponent();
           
            string barCode = "";
            foreach (BarcodeMaterial item in list)
            {
                barCode = item.MaterialCode + "&" + item.Name;
            }
            _list = list;
            txtBarCode.Text = barCode;
            txtQrCode.Text = barCode;
            this.DataSource = _list;
            LoadData();
        }
        public void LoadData()
        {
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtCount.DataBindings.Add("Text", DataSource, "Count");
            txtName.DataBindings.Add("Text", DataSource, "Name");
            txtDateTime.DataBindings.Add("Text", DataSource, "DateInput");
            txtEmployess.DataBindings.Add("Text", DataSource, "Employess");
            txtStatus.DataBindings.Add("Text", DataSource, "Nature");
        }

    }
}
