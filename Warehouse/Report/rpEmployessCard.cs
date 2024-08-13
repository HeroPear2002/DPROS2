using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpEmployessCard : DevExpress.XtraReports.UI.XtraReport
    {
        public rpEmployessCard()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtEmployessName.DataBindings.Add("Text", DataSource, "EmployessName");
            txtPositionName.DataBindings.Add("Text", DataSource, "PositionName");
            txtEmployessCode.DataBindings.Add("Text", DataSource, "EmployessCode");
            txtBarCode.DataBindings.Add("Text", DataSource, "EmployessCode");
            pctAvata.DataBindings.Add("ImageUrl", DataSource, "LinkImage");
        }
    }
}
