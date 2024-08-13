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

namespace WareHouse.PO_and_Order
{
    public partial class frmApproveDelivery : DevExpress.XtraEditors.XtraForm
    {
        public frmApproveDelivery()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;
        string _employess = Kun_Static.EmployessCode;
        private void btnApprove_Click(object sender, EventArgs e)
        {
            string barCode = txtBarCode.Text;
            if (barCode.Contains('&'))
            {
                List<DeliveryDetail> listDE = new List<DeliveryDetail>();
                string[] array = barCode.Split('&');
                long id = long.Parse(array[1]);
                if (DeliveryDAO.Instance.IdDelivery(id) == -1)
                {
                    MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int statDe = DeliveryDAO.Instance.StatusDe(id);
                if(statDe == 0)
                {
                    MessageBox.Show("BBGH này chưa xuất hàng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (statDe == 3)
                {
                    MessageBox.Show("BBGH này đã được giao\n\nbạn hãy kiểm tra lại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DeliveryDAO.Instance.UpdateDeliveryChange(id, DateTime.Now, _employess);
                DeliveryDAO.Instance.UpdateDelivery(id,3,"");
                listDE = DeliveryDAO.Instance.GetListDeliveryDetail(id);
                foreach (DeliveryDetail item in listDE)
                {
                    long idPOInput = POFixDAO.Instance.GetItemPOFix(item.IdPOFix).IdPOInput;
                    int sum = PODAO.Instance.QuantityOutPO(idPOInput);
                    int quantityIn = PODAO.Instance.QuantityInputPO(idPOInput);
                    POFixDAO.Instance.UpdatePOFixByCode(item.IdPOFix, 1, "PO đã giao");
                    if( (sum+item.Quantity)<=quantityIn)
                    {
                        PODAO.Instance.UpdateQuantityOut(idPOInput, (sum + item.Quantity));
                        if((sum + item.Quantity) == quantityIn)
                        {
                            PODAO.Instance.UpdateStatusPO(idPOInput,1);
                        }
                    }
                }
                MessageBox.Show("Xác nhận thành công!".ToUpper());
                txtBarCode.Text = String.Empty;
            }
            else
            {
                MessageBox.Show("Mã vạch không đúng!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmApproveDelivery_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}