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
using WareHouse.Report;
using DevExpress.XtraReports.UI;

namespace WareHouse.QRCodeMaterial
{
    public partial class frmReceiptSlip : DevExpress.XtraEditors.XtraForm
    {
        public frmReceiptSlip()
        {
            InitializeComponent();
            LoadControl();
        }
        List<ReceiptSlipDTO> listR = new List<ReceiptSlipDTO>();
        private void LoadControl()
        {
            LoadDate();
            LoadData();
        }

        private void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1 - today.Day);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-10);
        }

        private void LoadData()
        {
            List<ReceiptSlipDTO> listRe = new List<ReceiptSlipDTO>();
            List<String> listS = ReceiptSlipDAO.Instance.DistinctReceipt(dtpkFrom.Value,dtpkTo.Value);
            foreach (var item in listS)
            {
                ReceiptSlipDTO receiptSlipDTO = ReceiptSlipDAO.Instance.ReceiptSlipDTO(item);
                if(receiptSlipDTO != null)
                {
                    listRe.Add(new ReceiptSlipDTO(1,1, item, "", "", 0, receiptSlipDTO.DatePrinter, receiptSlipDTO.Employess, receiptSlipDTO.Note));
                }
            }
            GCData.DataSource = listRe;
        }
        string LoadText()
        {
            string a = "";
            foreach (var item in gridView1.GetSelectedRows())
            {
                a = gridView1.GetRowCellValue(item, "ReceiptCode").ToString();
            }
            return a;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                    ReceiptSlipDAO.Instance.DeleteReceiptSlip(id);
                }
                LoadControl();
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            string ReceiptCode = LoadText();
            if (ReceiptCode.Length == 0)
            {
                MessageBox.Show("bạn chưa chọn mã phiếu cần in".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kun_Static.ReceiptCode = ReceiptCode;
            List<ReceiptSlipDTO> listR = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(ReceiptCode);
            List<ReceiptSlipDTO> listRePrinter = new List<ReceiptSlipDTO>();
            foreach (ReceiptSlipDTO item in listR)
            {

                if (item.QuantityPlan <= 1000)
                {
                    listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, ReceiptCode, item.MaterCode, item.MaterialName, item.QuantityPlan, item.DatePrinter, item.Employess, item.MaterCode + "&" + item.QuantityPlan.ToString()));
                }
                else
                {
                    int du = item.QuantityPlan % 1000;
                    int nguyen = item.QuantityPlan / 1000;
                    for (int i = 1; i <= nguyen; i++)
                    {
                        listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, ReceiptCode, item.MaterCode, item.MaterialName, 1000, item.DatePrinter, item.Employess, item.MaterCode + "&" + "1000"));
                    }
                    if (du > 0)
                    {
                        listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, ReceiptCode, item.MaterCode, item.MaterialName, du, item.DatePrinter, item.Employess, item.MaterCode + "&" + du.ToString()));
                    }
                }
            }
            rpCouponMaterial rpCoupon = new rpCouponMaterial(listRePrinter);
            rpCoupon.Print();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (LoadText().Trim().Length == 0)
                return;
            Kun_Static.ReceiptCode = LoadText();
            frmReceiptSlipDetail f = new frmReceiptSlipDetail();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            frmApproveReceipt f = new frmApproveReceipt();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
    }
}