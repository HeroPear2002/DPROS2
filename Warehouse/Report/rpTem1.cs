using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using System.Collections.Generic;

namespace WareHouse.Report
{
    public partial class rpTem1 : DevExpress.XtraReports.UI.XtraReport
    {
        public rpTem1()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtDateInput.DataBindings.Add("Text", DataSource, "DatePrinter");
            txtQuantityInput.DataBindings.Add("Text", DataSource, "QuantityPlan");
            txtBarCode.DataBindings.Add("Text", DataSource, "Note");
        }
    }
}
