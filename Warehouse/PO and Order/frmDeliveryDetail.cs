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
using DAO;
using DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.PO_and_Order
{
    public partial class frmDeliveryDetail : DevExpress.XtraEditors.XtraForm
    {
        public frmDeliveryDetail()
        {
            InitializeComponent();
            LoadDeCode();
            LoadControl();
            LoadColum();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        void LoadColum()
        {
            gridView1.Columns["QuantityOut"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QuantityOut", "{0}");
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }
        public EventHandler LamMoi;
        DeliveryDetail deliveryDetail = null;
        void LoadControl()
        {
            btnAdd.Enabled = false;
            LoadData();
            LoadPOFix();
            LoadCheck();
        }
        void LoadData()
        {
            List<DeliveryDetail> listDe = new List<DeliveryDetail>();
            listDe = DeliveryDAO.Instance.GetListDeliveryDetail(Kun_Static.IdDe);
            foreach (DeliveryDetail item in listDe)
            {
                if(item.Quantity == item.QuantityOut && item.StatusDetail == 0)
                {
                    DeliveryDAO.Instance.UpdateDeliveryDetail(item.Id,1,item.Quantity);
                }
                else if(item.Quantity != item.QuantityOut && item.StatusDetail == 1)
                {
                    DeliveryDAO.Instance.UpdateDeliveryDetail(item.Id, 0, item.QuantityOut);
                }
            }
            GCData.DataSource = listDe;
        }
        void LoadDeCode()
        {
            this.Name = "CHI TIẾT BBGH SỐ " + Kun_Static.IdDe.ToString();
        }
        void LoadPOFix()
        {
            deliveryDetail = DeliveryDAO.Instance.GetItemDeliveryDtail(Kun_Static.IdDe);
            List<POFixDTO> listP = POFixDAO.Instance.GetListPOFix06().Where(x=>x.FactoryCode == deliveryDetail.FactoryCode && x.CarNumber == deliveryDetail.CarNumber && x.FactoryCustomer == deliveryDetail.FactoryCustomer && x.DateOut == deliveryDetail.DateOut).ToList();
            lkPOFix.Properties.DataSource = listP;
            lkPOFix.Properties.DisplayMember = "POCode";
            lkPOFix.Properties.ValueMember = "Id";
        }
        void LoadCheck()
        {
            List<DeliveryDetail> listDe = new List<DeliveryDetail>();
            listDe = DeliveryDAO.Instance.GetListDeliveryDetail(Kun_Static.IdDe);
            int count = 0;
            int status = DeliveryDAO.Instance.StatusDe(Kun_Static.IdDe);
            foreach (DeliveryDetail item in listDe)
            {
                if(item.QuantityOut == item.Quantity && status != 3)
                {
                    POFixDAO.Instance.UpdatePOFixByCode(item.IdPOFix,3, "PO đã xuất");
                }
                if (item.QuantityOut != item.Quantity)
                {
                    POFixDAO.Instance.UpdatePOFixByCode(item.IdPOFix, 2, "");
                    if (item.StatusDetail == 0 )
                    {
                        count++;
                    }
                }
                if(status == 3)
                {
                    POFixDAO.Instance.UpdatePOFixByCode(item.IdPOFix, 1, "PO đã giao");
                }
            }
            if (count == 0 && DeliveryDAO.Instance.StatusDe(Kun_Static.IdDe) == 0)
            {
                DeliveryDAO.Instance.UpdateDelivery(Kun_Static.IdDe, 1,"");
            }
            else if(count > 0 && DeliveryDAO.Instance.StatusDe(Kun_Static.IdDe) != 0)
            {
                DeliveryDAO.Instance.UpdateDelivery(Kun_Static.IdDe, 0,"BB chưa được xuất");
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int statusDe = DeliveryDAO.Instance.StatusDe(Kun_Static.IdDe);
            if(statusDe == 3)
            {
                MessageBox.Show("BBGH đã xuất kho thành công không thể thêm PO!".ToUpper(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                long idPOFix = long.Parse(txtId.Text);
                DeliveryDAO.Instance.InsertDeliveryDetail(idPOFix, Kun_Static.IdDe, "", 0, 0);
                POFixDAO.Instance.UpdatePOFixByCode(idPOFix, 2, "");
                MessageBox.Show("thêm thông tin thành công!".ToUpper());
            }
            LoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    long idPOFix = long.Parse(gridView1.GetRowCellValue(item, "IdPOFix").ToString());
                    string poCode = gridView1.GetRowCellValue(item, "POCode").ToString();
                    int statusDetail = int.Parse(gridView1.GetRowCellValue(item, "StatusDetail").ToString());
                    if(statusDetail == 1)
                    {
                        MessageBox.Show("PO "+poCode+ " đã xuất kho không thể xóa?".ToUpper(), "Thông báo", MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        DeliveryDAO.Instance.DeleteDeliveryDetail(id);
                        POFixDAO.Instance.UpdatePOFixById(idPOFix, 0, "");
                    }
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }

        private void frmDeliveryDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void lkPOFix_EditValueChanged(object sender, EventArgs e)
        {
            txtId.Text = lkPOFix.EditValue.ToString();
            long id = long.Parse(txtId.Text);
            string fact = POFixDAO.Instance.GetItemPOFix(id).FactoryCustomer.ToUpper();
            string car = POFixDAO.Instance.GetItemPOFix(id).CarNumber.ToUpper();
            DeliveryDetail deliveryDetail =  DeliveryDAO.Instance.GetItemDeliveryDtail(Kun_Static.IdDe);
            if(deliveryDetail == null)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                string carNumber = deliveryDetail.CarNumber.ToUpper();
                string factory = deliveryDetail.FactoryCustomer.ToUpper();
                if (car == carNumber)
                {
                    if (fact == factory)
                    {
                        btnAdd.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("mã nhà máy không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("số xe không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }   
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Now.Date;
            if (e.RowHandle >= 0)
            {
                int statusDe = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusDetail"]).ToString());
                if (statusDe == 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void btnConnext_Click(object sender, EventArgs e)
        {
            string a = "";
            foreach (var item in gridView1.GetSelectedRows())
            {
                string po = gridView1.GetRowCellValue(item, "POCode").ToString();
                a += po + ",";
            }
            txtString.Text = a.Substring(0, a.Length - 1);
        }
    }
}