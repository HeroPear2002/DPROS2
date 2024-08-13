using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpCounpontEmployess : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCounpontEmployess()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            txtEmployessCode.DataBindings.Add("Text", DataSource, "EmployessCode");
            txtEmployessName.DataBindings.Add("Text", DataSource, "EmployessName");
            txtDateInput.DataBindings.Add("Text", DataSource, "DateInput");
            txtDateHis.DataBindings.Add("Text", DataSource, "DateHis");
            txtNote.DataBindings.Add("Text", DataSource, "Note");
            txtPoint.DataBindings.Add("Text", DataSource, "PointEr");
            txtPointNow.DataBindings.Add("Text", DataSource, "PointNow");
            txtNumber.DataBindings.Add("Text", DataSource, "Number");

        }
    }
}
