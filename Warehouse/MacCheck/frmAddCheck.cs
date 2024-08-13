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
using WareHouse.PO_and_Order;
using DAO;
using DTO;
using WareHouse.MacCheck;

namespace WareHouse.PCGridControl
{
    public partial class frmAddCheck : DevExpress.XtraEditors.XtraForm
    {
        public frmAddCheck()
        {
            InitializeComponent();
            LoadHeader();
        }
        public EventHandler LamMoi;
        List<ListDelivery> _listDe = new List<ListDelivery>();
        void LoadHeader()
        {
           if(Kun_Static.Style == 10)
            {
                lblNote.Text = "bạn đang chọn check mới".ToUpper();
            }
           else if(Kun_Static.Style == 11)
            {
                string header = "bạn đang Check Bổ sung BB, có mã check => " + Kun_Static.CheckCode;
                lblNote.Text = header.ToUpper();
            }
            txtBarCode.Focus();
        }
        void TextChange()
        {
            string barCode = txtBarCode.Text;
            if(barCode.Contains("&"))
            {
                string[] array = barCode.Split('&');
                long idDe = long.Parse(array[1]);
                string deCode = array[0];
                DeliveryNotesDTO deliveryNotesDTO = DeliveryDAO.Instance.GetItemDelivery(idDe);
                if(deliveryNotesDTO != null)
                {
                    int status = deliveryNotesDTO.StatusDe;
                    int count = _listDe.Where(x => x.IdDe == idDe && x.DeCode == deCode).Count();
                    List<CheckDeliveryDTO> listCheck = BoxCheckDAO.Instance.GetCheckDeliveryDTOs(idDe);                   
                    if(count > 0)
                    {
                        timer1.Stop();
                        txtBarCode.Enabled = false;
                        MessageBox.Show("số BBGH đã tồn tại!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBarCode.Enabled = true;
                        txtBarCode.Focus();
                        txtBarCode.SelectAll();
                    }
                  
                   else if(listCheck.Count > 0)
                    {
                        timer1.Stop();
                        txtBarCode.Enabled = false;
                        MessageBox.Show("số BBGH đã được kiểm tra rồi!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtBarCode.Enabled = true;
                        txtBarCode.Focus();
                        txtBarCode.SelectAll();
                    }
                    else
                    {
                        _listDe.Add(new ListDelivery(idDe, deCode));
                    }
                    
                }
                else
                {
                    timer1.Stop();
                    txtBarCode.Enabled = false;
                    MessageBox.Show("số BBGH không đúng!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtBarCode.Enabled = true;
                    txtBarCode.Focus();
                    txtBarCode.SelectAll();
                }
            }
        }
        void LoadData()
        {
            List<ListDelivery> listDe = new List<ListDelivery>();
            foreach (ListDelivery item in _listDe)
            {
                listDe.Add(new ListDelivery(item.IdDe, item.DeCode));
            }
            GCData.DataSource = listDe;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            TextChange();
            txtBarCode.SelectAll();
            timer1.Stop();
            LoadData();
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 200;
            timer1.Start();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn đã lưu danh sách PO cần Check.\ntiếp theo sẽ bắn mã vạch trên thùng hàng!".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sDate = DateTime.Now.ToString("yyyyMMddHHmmss");
                string milli = DateTime.Now.Millisecond.ToString();
                string checkCode = Kun_Static.CheckCode;
                if (Kun_Static.Style == 10)
                {
                    checkCode = sDate + milli;
                }
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    long idDe = long.Parse(gridView1.GetRowCellValue(i, "IdDe").ToString());
                    string deCode = gridView1.GetRowCellValue(i, "DeCode").ToString();
                    List<DeliveryDetail> deliveryDetails = DeliveryDAO.Instance.GetListDeliveryDetail(idDe);
                    foreach (DeliveryDetail item in deliveryDetails)
                    {
                        string factoryCode = item.FactoryCode;
                        BoxCheckDAO.Instance.InsertCheck(checkCode,idDe, Kun_Static.EmployessCode,item.PartCode,0,item.Quantity,factoryCode,"",0,item.POCode);
                    }                   
                }
                Kun_Static.CheckCode = checkCode;
                this.Close();
                frmPOCheck f = new frmPOCheck();
                f.ShowDialog();
            }
        }
        private class ListDelivery
            {
            private long idDe;
            private string deCode;
            public ListDelivery(long IdDe, string DeCode)
            {
                this.IdDe = IdDe;
                this.DeCode = DeCode;
            }
            public long IdDe { get => idDe; set => idDe = value; }
            public string DeCode { get => deCode; set => deCode = value; }
        }

        private void frmAddCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}