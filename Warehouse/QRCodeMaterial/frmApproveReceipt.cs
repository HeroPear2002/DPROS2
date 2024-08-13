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

namespace WareHouse.QRCodeMaterial
{
    public partial class frmApproveReceipt : DevExpress.XtraEditors.XtraForm
    {
        public frmApproveReceipt()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;

        void LoadControl()
        {
            txtBarCode.Text = String.Empty;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string RecieptCode = txtBarCode.Text;
            List<ReceiptSlipDTO> listRe = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(RecieptCode);
            if (listRe.Count() == 0)
                return;
            foreach (ReceiptSlipDTO item in listRe)
            {
                POMaterialDAO.Instance.UpdateProgressReality(item.IdDetail, item.QuantityPlan, item.DatePrinter);
                POMaterialDAO.Instance.UpdateProgress(item.IdDetail, 0);
            }
            ReceiptSlipDAO.Instance.UpdateReceiptSlip(RecieptCode, "OK");
            LoadControl();
        }

        private void frmApproveReceipt_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}