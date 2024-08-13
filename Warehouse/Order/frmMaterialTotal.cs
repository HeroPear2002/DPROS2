using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DTO;
using DAO;

namespace WareHouse.Order
{
    public partial class frmMaterialTotal : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialTotal()
        {
            InitializeComponent();
        }
        string[] arrayList = { "Lượng sử dụng","Lượng tồn kho an toàn","Lượng tồn kho hiện tại", "Lượng mua" };
        int QuantityBy(string materialCode, DateTime date)
        {
            FCMaterialDTO fCMaterialDTO = OrderDAO.Instance.GetItemFcMaterial(materialCode, date);
            if (fCMaterialDTO == null)
            {
                return 0;
            }
            return fCMaterialDTO.Quantity;
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime today = dtpkDate.Value.Date;
            DateTime date = today.AddDays(1 - today.Day);
            List<FormMaterial> listFM = new List<FormMaterial>();
            Col1.Caption = "T"+ today.Month.ToString()+"."+ today.Year.ToString();
            Col2.Caption = "T" + (today.AddMonths(1).Month).ToString() + "." + today.AddMonths(1).Year.ToString();
            Col3.Caption = "T" + (today.AddMonths(2).Month.ToString()) + "." + today.AddMonths(2).Year.ToString();
            Col4.Caption = "T" + (today.AddMonths(3).Month.ToString()) + "." + today.AddMonths(3).Year.ToString();
            Col5.Caption = "T" + (today.AddMonths(4).Month.ToString()) + "." + today.AddMonths(4).Year.ToString();
            Col6.Caption = "T" + (today.AddMonths(5).Month.ToString()) + "." + today.AddMonths(5).Year.ToString();
            List<MaterialCodeDTO> listFC = OrderDAO.Instance.GetOnLyMaterialDTOs(date,date.AddMonths(5));
            int Month1 = 0;
            int Month2 = 0;
            int Month3 = 0;
            int Month4 = 0;
            int Month5 = 0;
            int Month6 = 0;
            foreach (MaterialCodeDTO item in listFC)
            {
                int dem = 0;
                TableInventoryMaterial tableInventoryMaterial = MaterialInforDAO.Instance.GetItemTableMaterial(item.MaterialCode);
                foreach (var jtem in arrayList)
                {
                    if(dem == 0)
                    {
                        Month1 = QuantityBy(item.MaterialCode,date);
                        Month2 = QuantityBy(item.MaterialCode, date.AddMonths(1));
                        Month3 = QuantityBy(item.MaterialCode, date.AddMonths(2));
                        Month4 = QuantityBy(item.MaterialCode, date.AddMonths(3));
                        Month5 = QuantityBy(item.MaterialCode, date.AddMonths(4));
                        Month6 = QuantityBy(item.MaterialCode, date.AddMonths(5));
                    }
                    else if(dem == 1)
                    {
                        Month1 = QuantityBy(item.MaterialCode, date) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        Month2 = QuantityBy(item.MaterialCode, date.AddMonths(1)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        Month3 = QuantityBy(item.MaterialCode, date.AddMonths(2)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        Month4 = QuantityBy(item.MaterialCode, date.AddMonths(3)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        Month5 = QuantityBy(item.MaterialCode, date.AddMonths(4)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        Month6 = QuantityBy(item.MaterialCode, date.AddMonths(5)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                    }
                    else if (dem == 2)
                    {
                        if(tableInventoryMaterial != null)
                        {
                            Month1 = tableInventoryMaterial.QuantityInventory;
                            Month2 = QuantityBy(item.MaterialCode, date) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month3 = QuantityBy(item.MaterialCode, date.AddMonths(1)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month4 = QuantityBy(item.MaterialCode, date.AddMonths(2)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month5 = QuantityBy(item.MaterialCode, date.AddMonths(3)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month6 = QuantityBy(item.MaterialCode, date.AddMonths(4)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        }
                        else
                        {
                            FCMaterialDTO fCMaterialDTO = OrderDAO.Instance.GetItemFcMaterial(item.MaterialCode, date.AddMonths(-1));
                            if(fCMaterialDTO != null)
                            {
                                Month1 = fCMaterialDTO.Quantity;
                            }
                            else
                            {
                                Month1 = 0;
                            } 
                            Month2 = QuantityBy(item.MaterialCode, date) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month3 = QuantityBy(item.MaterialCode, date.AddMonths(1)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month4 = QuantityBy(item.MaterialCode, date.AddMonths(2)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month5 = QuantityBy(item.MaterialCode, date.AddMonths(3)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                            Month6 = QuantityBy(item.MaterialCode, date.AddMonths(4)) * (MaterialDAO.Instance.WarningYellow(item.MaterialCode)) / 100;
                        }
                      
                    }
                    else if (dem == 3)
                    {
                        Month1 = listFM.SingleOrDefault(x=>x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month1 
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month1 
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month1;
                        if((Month1 / 25) * 25 != Month1)
                        {
                            Month1 = (Month1 / 25 + 1) * 25;
                        }
                        if(Month1 < 0)
                        {
                            Month1 = 0;
                        }
                        Month2 = listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month2
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month2
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month2;
                        if ((Month2 / 25) * 25 != Month2)
                        {
                            Month2 = (Month2 / 25 + 1) * 25;
                        }
                         if (Month2 < 0)
                        {
                            Month2 = 0;
                        }
                        Month3 = listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month3
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month3
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month3;
                        if ((Month3 / 25) * 25 != Month3)
                        {
                            Month3 = (Month3 / 25 + 1) * 25;
                        }
                         if (Month3 < 0)
                        {
                            Month3 = 0;
                        }
                        Month4 = listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month4
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month4
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month4;
                        if ((Month4 / 25) * 25 != Month4)
                        {
                            Month4 = (Month4 / 25 + 1) * 25;
                        }
                         if (Month4 < 0)
                        {
                            Month4 = 0;
                        }
                        Month5 = listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month5
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month5
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month5;
                        if ((Month5 / 25) * 25 != Month5)
                        {
                            Month5 = (Month5 / 25 + 1) * 25;
                        }
                         if (Month5 < 0)
                        {
                            Month5 = 0;
                        }
                        Month6 = listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 0).Month6
                            + listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 1).Month6
                            - listFM.SingleOrDefault(x => x.MaterialCode == item.MaterialCode && x.IdCate == 2).Month6;
                        if ((Month6 / 25) * 25 != Month6)
                        {
                            Month6 = (Month6 / 25 + 1) * 25;
                        }
                         if (Month6 < 0)
                        {
                            Month6 = 0;
                        }
                    }
                    listFM.Add(new FormMaterial(item.MaterialCode, item.MaterialName, jtem,dem, Month1, Month2, Month3, Month4, Month5, Month6));
                    dem++;
                }
            }
            GCData.DataSource = listFM;
            for (int i = 0; i < 6; i++)
            {
                DateTime newDate = date.AddMonths(i);
                int quantityUse = 0;
                foreach (FormMaterial item in listFM.Where(x => x.IdCate == 3))
                {
                    string materialCode = item.MaterialCode;
                    switch(i)
                    {
                        case 0:
                            quantityUse = item.Month1;
                            break;
                        case 1:
                            quantityUse = item.Month2;
                            break;
                        case 2:
                            quantityUse = item.Month3;
                            break;
                        case 3:
                            quantityUse = item.Month4;
                            break;
                        case 4:
                            quantityUse = item.Month5;
                            break;
                        case 5:
                            quantityUse = item.Month6;
                            break;
                        default:
                            break;
                    }                    
                    MaterialByDTO materialByDTO = MaterialDAO.Instance.GetItemMaterialBy(materialCode, newDate);
                    if(materialByDTO != null)
                    {
                        if(quantityUse != materialByDTO.QuantityBy)
                        {
                            MaterialDAO.Instance.UpdateMaterialBy(materialByDTO.Id, materialCode, quantityUse, materialByDTO.QuantityOrder,newDate, "");
                        }
                    }
                    else
                    {
                        //Thêm thông tin Nhựa cần mua ở đây
                        MaterialDAO.Instance.InsertMaterialBy(materialCode, quantityUse,0, newDate, "");
                    }                  
                }
            }
            MessageBox.Show("thêm thông tin thành công!".ToUpper());
        }
    }
}