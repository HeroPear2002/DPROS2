using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace WareHouse.Report
{
    public partial class rpCTSX : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCTSX()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtMoldnumber.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtMachine.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMaterialCode.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName.DataBindings.Add("Text", DataSource, "MaterialName");
            txtDateSX.DataBindings.Add("Text", DataSource, "Date");
            txtQuantity.DataBindings.Add("Text", DataSource, "Quantity");
            txtCountBox.DataBindings.Add("Text", DataSource, "QuantityBox");
            txtCountPart.DataBindings.Add("Text", DataSource, "QuantityPart");
            txtTotalWeight.DataBindings.Add("Text", DataSource, "TotalWeight");
            txtTime.DataBindings.Add("Text", DataSource, "Hour");
            txtEmployess.DataBindings.Add("Text", DataSource, "Employess");
            txtNoteSX.DataBindings.Add("Text", DataSource, "NoteSX");
            txtCustomer.DataBindings.Add("Text", DataSource, "Customer");
            txtBarCode.DataBindings.Add("Text", DataSource, "BarCode");
            txtStatus.DataBindings.Add("Text", DataSource, "StatusMold");

            /////////////
            txtPartCode1.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName1.DataBindings.Add("Text", DataSource, "PartName");
            txtMoldnumber1.DataBindings.Add("Text", DataSource, "MoldNumber");
            txtMachine1.DataBindings.Add("Text", DataSource, "MachineCode");
            txtMaterialCode1.DataBindings.Add("Text", DataSource, "MaterialCode");
            txtMaterialName1.DataBindings.Add("Text", DataSource, "MaterialName");
            txtDateSX1.DataBindings.Add("Text", DataSource, "Date");
            txtQuantity1.DataBindings.Add("Text", DataSource, "Quantity");
            txtCountBox1.DataBindings.Add("Text", DataSource, "QuantityBox");
            txtCountPart1.DataBindings.Add("Text", DataSource, "QuantityPart");
            txtTotalWeight1.DataBindings.Add("Text", DataSource, "TotalWeight");
            txtTime1.DataBindings.Add("Text", DataSource, "Hour");
            txtBarCode1.DataBindings.Add("Text", DataSource, "BarCode");
            txtEmployess1.DataBindings.Add("Text", DataSource, "Employess");
            txtNoteNL.DataBindings.Add("Text", DataSource, "NoteNL");
            txtWeightMin.DataBindings.Add("Text", DataSource, "WeightMin");
            txtTimeMin.DataBindings.Add("Text", DataSource, "TimeMin");
            txtQrcode.DataBindings.Add("Text", DataSource, "BarCode");
        }
    }
}
