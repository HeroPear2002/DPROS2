using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using System.Collections.Generic;
using DAO;

namespace WareHouse.Report
{
    public partial class rpCouponMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        public rpCouponMaterial()
        {
            InitializeComponent();
        }
        List<CouponMaterial> _listRece = new List<CouponMaterial>();
        public rpCouponMaterial(List<ReceiptSlipDTO> receiptSlipDTOs)
        {
            InitializeComponent();
            int sum = 0;
            string vendor = "";
            foreach (ReceiptSlipDTO item in receiptSlipDTOs)
            {
                sum += item.QuantityPlan;
                vendor = MaterialDAO.Instance.GetItem(item.MaterCode).VenderCode;
                string date = item.DatePrinter.Day + "/" + item.DatePrinter.Month +"/"+ item.DatePrinter.Year;
                _listRece.Add(new CouponMaterial(item.Id, item.IdDetail, item.ReceiptCode, item.MaterCode, item.MaterialName, item.QuantityPlan,date , item.Employess, item.Note));
            }
            txtVendorCode.Text = vendor;
            txtBarCode.Text = Kun_Static.ReceiptCode;
            txtTotal.Text = sum.ToString();
            this.DataSource = _listRece;
            LoadData();
        }
        void LoadData()
        {
            txtMaterialCode.DataBindings.Add("Text", _listRece, "MaterCode");
            txtMaterialName.DataBindings.Add("Text", _listRece, "MaterialName");
            txtDateTime.DataBindings.Add("Text", _listRece, "DatePrinter");
            txtQuantity.DataBindings.Add("Text", _listRece, "QuantityPlan");
        }
        public class CouponMaterial
        {
            public CouponMaterial(long Id, long IdDetail, string ReceiptCode, string MaterCode,
                string MaterialName, int QuantityPlan, string DatePrinter, string Employess, string Note)
            {
                this.Id = Id;
                this.IdDetail = IdDetail;
                this.ReceiptCode = ReceiptCode;
                this.MaterCode = MaterCode;
                this.MaterialName = MaterialName;
                this.QuantityPlan = QuantityPlan;
                this.DatePrinter = DatePrinter;
                this.Employess = Employess;
                this.Note = Note;
            }
            private long id;
            private long idDetail;
            private string receiptCode;
            private string materCode;
            private string materialName;
            private string datePrinter;
            private string employess;
            private string note;
            private int quantityPlan;

            public long Id { get => id; set => id = value; }
            public long IdDetail { get => idDetail; set => idDetail = value; }
            public string ReceiptCode { get => receiptCode; set => receiptCode = value; }

            public string MaterialName { get => materialName; set => materialName = value; }
            public string DatePrinter { get => datePrinter; set => datePrinter = value; }
            public string Employess { get => employess; set => employess = value; }
            public string Note { get => note; set => note = value; }
            public string MaterCode { get => materCode; set => materCode = value; }
            public int QuantityPlan { get => quantityPlan; set => quantityPlan = value; }
        }
    }
}
