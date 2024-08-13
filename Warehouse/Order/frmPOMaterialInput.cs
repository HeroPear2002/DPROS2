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
    public partial class frmPOMaterialInput : DevExpress.XtraEditors.XtraForm
    {
        public frmPOMaterialInput()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadData();
            LoadLocation();
            LoadPayment();
            LoadUnitPrice();
        }
        void LoadData()
        {
            GCData.DataSource = Kun_Static.listMReturn;
        }
        void LoadLocation()
        {
            cbLocation.Controls.Clear();
            cbLocation.Items.Add("Kho Đông Dương 2.");
            cbLocation.Items.Add("Kho NCC.");
        }
        void LoadPayment()
        {
            cbPayment.Controls.Clear();
            cbPayment.Items.Add("CK vào cuối tháng sau của tháng giao hàng.");
            cbPayment.Items.Add("CK thanh toán trước khi giao hàng.");
        }
        void LoadUnitPrice()
        {
            cbUnitprice.Controls.Clear();
            cbUnitprice.Items.Add("VND");
            cbUnitprice.Items.Add("USD");
        }
        int LoadCheck()
        {
            DateTime datePO = dtpkDatePO.Value.Date;
            datePO = datePO.AddDays(1 - datePO.Day);
            DateTime date2 = datePO.AddMonths(1).AddSeconds(-10);
            string unitPrice = cbUnitprice.Text;
            long IdPO = POMaterialDAO.Instance.MaxIdPOMaterial();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string MaterCode = gridView1.GetRowCellValue(i, "MaterialCode").ToString();
                long IdBy = long.Parse(gridView1.GetRowCellValue(i, "Id").ToString());
                int QuantityBy = int.Parse(gridView1.GetRowCellValue(i, "QuantityOrder").ToString());
                MaterialPriceDTO materialPriceDTO = MaterialDAO.Instance.GetItemMaterPrice(MaterCode, datePO, date2);
                if (materialPriceDTO == null)
                {
                    return -1;
                }
                if(QuantityBy <= 0)
                {
                    return -2;
                }
            }
            return 1;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(LoadCheck() == -1)
            {
                MessageBox.Show("bạn chưa có đơn giá nhựa cho tháng này!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (LoadCheck() == -2)
            {
                MessageBox.Show("số lượng cần đặt hàng phải lớn hơn 0!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string supplier = Kun_Static.listMReturn.FirstOrDefault().VenderCode;
            DateTime datePO = dtpkDatePO.Value.Date;
            datePO = datePO.AddDays(1 - datePO.Day);
            DateTime date2 = datePO.AddMonths(1).AddSeconds(-10);
            int year = datePO.Year;
            int month = datePO.Month;
            int number = 1;
            POMaterialDTO pOMaterialDTO = POMaterialDAO.Instance.GetItemPOMaterialDTO(datePO,supplier);
            if(pOMaterialDTO != null)
            {
                string[] a = pOMaterialDTO.POCode.Split('-');
                number = int.Parse(a[3]);
                number = number + 1;
            }
            string location = cbLocation.Text;
            if(location.Length == 0)
            {
                MessageBox.Show("bạn chưa chọn địa điểm nhận hàng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string payMent = cbPayment.Text;
            if (payMent.Length == 0)
            {
                MessageBox.Show("bạn chưa chọn ĐK thanh toán!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string unitPrice = cbUnitprice.Text;
            if (unitPrice.Length == 0)
            {
                MessageBox.Show("bạn chưa chọn đơn vị tiền tệ!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string poCode = "DD2-" + supplier + "-" + year + month.ToString("D2") + "-"+number.ToString("D2");
            POMaterialDTO pOtest= POMaterialDAO.Instance.GetItemPOMaterialDTO(poCode);
            if(pOtest != null)
            {
                MessageBox.Show("có lỗi khi tạo số PO hãy liên lạc IT để khắc phục!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            POMaterialDAO.Instance.InsertPOMAterial(poCode, DateTime.Now, Kun_Static.accountDTO.UserName, location, payMent, dtpkDateInput.Value, "", "", 0, supplier, datePO);
            long IdPO = POMaterialDAO.Instance.MaxIdPOMaterial();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string MaterCode = gridView1.GetRowCellValue(i,"MaterialCode").ToString();
                long IdBy = long.Parse(gridView1.GetRowCellValue(i, "Id").ToString());
                MaterialByDTO materialByDTO = MaterialDAO.Instance.GetItemMaterialBy(IdBy);
                int QuantityOrder = materialByDTO.QuantityOrder;
                int QuantityBy = int.Parse(gridView1.GetRowCellValue(i, "QuantityOrder").ToString());
                if(QuantityOrder + QuantityBy > materialByDTO.QuantityBy)
                {
                    MessageBox.Show("Mã nguyên liệu " + MaterCode + " Số lượng mua quá lớn!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Price = "";
                MaterialPriceDTO materialPriceDTO =  MaterialDAO.Instance.GetItemMaterPrice(MaterCode,datePO,date2);
                if(materialPriceDTO != null)
                {
                    if (unitPrice == "VND")
                    {
                        Price = materialPriceDTO.PriceVND.ToString();
                }
                    else
                    {
                        Price = materialPriceDTO.PriceUSD.ToString();
                    }
                    int StatusDetail = 0;
                    POMaterialDAO.Instance.InsertPOMaterialDetail(IdPO, MaterCode, IdBy, QuantityBy, Price, unitPrice, StatusDetail);
                    MaterialDAO.Instance.UpdateMaterialBy(IdBy, QuantityOrder + QuantityBy);
                }
                else
                {
                    MessageBox.Show("Mã nguyên liệu "+MaterCode+" chưa có đơn giá cho tháng này!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            this.Close();
        }

        private void frmPOMaterialInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}