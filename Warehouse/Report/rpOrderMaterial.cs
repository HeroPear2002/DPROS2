using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using DTO;
using System.Collections.Generic;
using DAO;
using System.Globalization;

namespace WareHouse.Report
{
    public partial class rpOrderMaterial : DevExpress.XtraReports.UI.XtraReport
    {
        public rpOrderMaterial()
        {
            InitializeComponent();

        }
        List<POMaterialDetail> _listPOs;
        public rpOrderMaterial(List<POMaterialDetail> listPO)
        {
            InitializeComponent();
            List<POMaterialDetail> _listPO = new List<POMaterialDetail>();
            long i = 0;
            long idPO = 0;
            string unitPrice = "";
            float sum = 0;
            int sumInt = 0;
            int sumQ = 0;
            foreach (POMaterialDetail item in listPO)
            {
                i++;
                var a = Convert.ToDouble(item.Price) * item.QuantityBy;
                var price = Convert.ToDouble(item.Price);
                string b = "";
                string c = "";
                sumQ += item.QuantityBy;
                if (item.UnitPrice == "VND")
                {
                    int h = (int)a;
                    int k = (int)price;
                    b = string.Format("{0:#,##0}", h);
                    c = string.Format("{0:#,##0}", k);
                    sumInt += h;
                }
                else
                {
                    sum += (float)a;
                    if (a.ToString().Contains("."))
                    {
                        string[] arr = a.ToString().Split('.');
                        string fma = "{0:#,##0.";
                        for (int j = 0; j < arr[1].Length; j++)
                        {
                            fma += "0";
                        }
                        b = string.Format(fma + "}", a);
                    }
                    else
                    {
                        b = string.Format("{0:#,##0}",a);
                    }
                    c = string.Format("{0:#,##0.00}", price);
                }
                _listPO.Add(new POMaterialDetail(i, item.IdPO, item.MaterCode, item.MaterialName, item.ColorCode, item.IdBy, item.QuantityBy, c, b, item.StatusDetail));
                idPO = item.IdPO;
                unitPrice = item.UnitPrice;
            }
            this._listPOs = _listPO;
            this.DataSource = _listPOs;
            POMaterialDTO pOMaterialDTO = POMaterialDAO.Instance.GetItemPOMaterialDTO(idPO);
            string supplier = POMaterialDAO.Instance.GetItemPOMaterialDTO(idPO).SupplierCode;
            SupplierDTO supplierDTO = VendorDAO.Instance.GetItemSupplierDTO(supplier);
            string totalMoney = "";
            if (unitPrice == "VND")
            {
                txtHeaderPrice.Text = "Đơn giá(VNĐ)";
                txtHeaderMoneys.Text = "Tổng giá(VNĐ)";
                totalMoney = string.Format("{0:#,##0}", sumInt);
            }
            else
            {
                txtHeaderPrice.Text = "Đơn giá(USD)";
                txtHeaderMoneys.Text = "Tổng giá(USD)";
                if (sum.ToString().Contains("."))
                {
                    string[] arr = sum.ToString().Split('.');
                    string fma = "{0:#,##0.";
                    for (int j = 0; j < arr[1].Length; j++)
                    {
                        fma += "0";
                    }
                    totalMoney = string.Format(fma + "}", sum);
                }
                else
                {
                    totalMoney = string.Format("{0:#,##0}",sum);
                }

            }
            string date = pOMaterialDTO.DateCreate.Day.ToString("D2") + "/" + pOMaterialDTO.DateCreate.Month.ToString("D2") + "/" + pOMaterialDTO.DateCreate.Year;
            string dateInput = pOMaterialDTO.DateInput.Day.ToString("D2") + "/" + pOMaterialDTO.DateInput.Month.ToString("D2") + "/" + pOMaterialDTO.DateInput.Year;
            txtAddressVendor.Text = supplierDTO.Address;
            txtContact.Text = supplierDTO.ContactPerson;
            txtPhoneVendor.Text = supplierDTO.Phone;
            txtFaxVendor.Text = supplierDTO.FaxNumber;
            txtVendorName.Text = supplierDTO.VenderName;
            txtNameVendorENG.Text = supplierDTO.VenderName;
            txtOrderCode.Text = pOMaterialDTO.POCode;
            txtTotalMoney.Text = totalMoney;
            txtTotalQuantity.Text = string.Format("{0:#,##0}", sumQ);
            txtLocation.Text = pOMaterialDTO.Location;
            txtPayment.Text = pOMaterialDTO.Payment;
            txtDateInput.Text = dateInput;
            txtDateTime.Text = date;
            LoadData();
        }
        void LoadData()
        {
            txtAutoNumber.DataBindings.Add("Text", _listPOs, "Id");
            txtMaterialCode.DataBindings.Add("Text", _listPOs, "MaterCode");
            txtMaterialName.DataBindings.Add("Text", _listPOs, "MaterialName");
            txtColor.DataBindings.Add("Text", _listPOs, "ColorCode");
            txtQuantity.DataBindings.Add("Text", _listPOs, "QuantityBy");
            txtPrice.DataBindings.Add("Text", _listPOs, "Price");
            txtIntoMoney.DataBindings.Add("Text", _listPOs, "UnitPrice");
        }
    }
}
