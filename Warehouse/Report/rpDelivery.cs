using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using DAO;

namespace WareHouse.Report
{
    public partial class rpDelivery : DevExpress.XtraReports.UI.XtraReport
    {
        public rpDelivery()
        {
            InitializeComponent();
            LoadData();
            LoadControl();
        }
        public void LoadData()
        {
            LoadTable();
            LoadCompany();
        }
        POFixDTO pOFixDTO = null;
        FactoryDTO factoryDTO = null;
        void LoadControl()
        {
            txtTotalBox.Text = Kun_Static.TotalBox.ToString();
        }
        void LoadCompany()
        {
            long idDe = Kun_Static.IdDe;
            pOFixDTO = POFixDAO.Instance.GetItemPOFixByIdDe(idDe);
            string factCode = pOFixDTO.FactoryCode;
            long idInput = pOFixDTO.IdPOInput;
            string customer = PODAO.Instance.Customer(idInput);
            string cusName = CustomerDAO.Instance.GetItemCustomerDTO(customer).CustomerName;
            factoryDTO = FactoryDAO.Instance.GetItemFactory(factCode, customer);
            string nameVN = factoryDTO.NameBillVN;
            string nameENG = factoryDTO.NameBillENG;
            string address = factoryDTO.Address;
            string phone = factoryDTO.Phone;
            string fax = factoryDTO.FaxNumber;
            txtAddress.Text = factoryDTO.Address;
            txtNameBillVN.Text = nameVN;
            txtNameENG.Text = nameENG;
            txtNameCustomer.Text = cusName;
        }
        void LoadTable()
        {
            txtAutoNumber.DataBindings.Add("Text", DataSource, "Id");
            txtBarCode.DataBindings.Add("Text", DataSource, "DeCode");
            txtQrcode.DataBindings.Add("Text", DataSource, "DeCode");
            txtFactory.DataBindings.Add("Text", DataSource, "Factory");
            txtDateOut.DataBindings.Add("Text", DataSource, "DateOut");
            txtTime.DataBindings.Add("Text", DataSource, "Time");
            txtCarNumber.DataBindings.Add("Text", DataSource, "CarNumber");
            txtPOCode.DataBindings.Add("Text", DataSource, "POCode");
            txtQuantity.DataBindings.Add("Text", DataSource, "Quantity");
            txtPartCode.DataBindings.Add("Text", DataSource, "PartCode");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
            txtCountPart.DataBindings.Add("Text", DataSource, "CountPart");
            txtCountBox.DataBindings.Add("Text", DataSource, "CountBox");
            txtPartName.DataBindings.Add("Text", DataSource, "PartName");
        }
    }
}
