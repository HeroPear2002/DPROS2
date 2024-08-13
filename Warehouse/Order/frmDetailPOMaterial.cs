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
using WareHouse.Report;
using DevExpress.XtraReports.UI;

namespace WareHouse.Order
{
    public partial class frmDetailPOMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmDetailPOMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDataDetail();
            LoadProgress();
        }
        void LoadDataDetail()
        {
            long IdPO = Kun_Static.IdPOMaterial;
            GCDataPO.DataSource = POMaterialDAO.Instance.GetPOMaterialDetails(IdPO);
        }
        void LoadProgress()
        {
            btnPlan.Enabled = false;
            btnReality.Enabled = false;
            btnDelete.Enabled = false;
            LoadStatus();
            GCDataDetail.DataSource = POMaterialDAO.Instance.GetProgressDetailDTOs(Kun_Static.IdPOMaterial).OrderBy(x => x.IdDetail);
        }
        void LoadStatus()
        {
            DateTime today = DateTime.Now;
            List<ProgressDetailDTO> listP = POMaterialDAO.Instance.GetProgressDetailDTOs(Kun_Static.IdPOMaterial).Where(x => x.DatePlan != null).ToList();
            foreach (ProgressDetailDTO item in listP)
            {
                int day = (int)(today - (DateTime)item.DatePlan).TotalDays;
                if (today.Hour >= 8 && day >= 1 && item.DateReality == null)
                {
                    POMaterialDAO.Instance.UpdateProgress(item.Id, 1);
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int dem = gridView1.SelectedRowsCount;
            if (dem > 0)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long idDetail = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    int quantity = int.Parse(gridView1.GetRowCellValue(item, "QuantityBy").ToString());
                    int sum = POMaterialDAO.Instance.SumQuantityPlanProgress(Kun_Static.IdPOMaterial, idDetail);
                    if (sum >= quantity)
                    {
                        string MaterCode = gridView1.GetRowCellValue(item, "MaterCode").ToString();
                        MessageBox.Show("mã nguyên liệu : ".ToUpper() + MaterCode + " đã có kế hoạch về hết số lượng!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        POMaterialDAO.Instance.InsertProgress(idDetail, 0, 0, Kun_Static.accountDTO.UserName, 0);
                    }

                }
                LoadProgress();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu nào!".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in gridView2.GetSelectedRows())
            {
                i++;
                int sum = 0;
                long IdDetail = long.Parse(gridView2.GetRowCellValue(item, "IdDetail").ToString());
                long Id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                int quantityPla = int.Parse(gridView2.GetRowCellValue(item, "QuantityPlan").ToString());
                string dPlan = gridView2.GetRowCellValue(item, "DatePlan").ToString();
                if (dPlan.Length == 0 || quantityPla == 0)
                {
                    string msg = "dòng thứ : " + i + " bạn chưa điền đúng thông tin!";
                    MessageBox.Show(msg.ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime datePlan = DateTime.Parse(dPlan);
                    sum = POMaterialDAO.Instance.SumQuantityPlanProgress(Kun_Static.IdPOMaterial, IdDetail, Id);
                    if (sum + quantityPla <= POMaterialDAO.Instance.GetItemPOMaterialDetail(Kun_Static.IdPOMaterial, IdDetail).QuantityBy)
                    {
                        POMaterialDAO.Instance.UpdateProgressPlan(Id, quantityPla, datePlan);
                    }
                    else
                    {
                        string msg = "dòng thứ : " + i + " số lượng quá lớn!";
                        MessageBox.Show(msg.ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadProgress();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (var item in gridView2.GetSelectedRows())
            {
                long id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                POMaterialDAO.Instance.DeleteProgress(id);
            }
            LoadProgress();
        }

        private void btnReality_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (var item in gridView2.GetSelectedRows())
            {
                i++;
                long IdDetail = long.Parse(gridView2.GetRowCellValue(item, "IdDetail").ToString());
                long Id = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                int quantityReality = int.Parse(gridView2.GetRowCellValue(item, "QuantityReality").ToString());
                string dReality = gridView2.GetRowCellValue(item, "DateReality").ToString();
                if (dReality.Length == 0 || quantityReality == 0)
                {
                    string msg = "dòng thứ : " + i + " bạn chưa điền đúng thông tin!";
                    MessageBox.Show(msg.ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DateTime dateReality = DateTime.Parse(dReality);
                    POMaterialDAO.Instance.UpdateProgressReality(Id, quantityReality, dateReality);
                    POMaterialDAO.Instance.UpdateProgress(Id, 0);
                }
            }
            LoadProgress();
        }

        private void GCDataDetail_Click(object sender, EventArgs e)
        {
            btnReality.Enabled = true;
            btnPlan.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, "StatusProDetail").ToString());
                if (status == 1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCDataDetail);
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn thêm + in thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                List<ReceiptSlipDTO> listRe = new List<ReceiptSlipDTO>();
                DateTime today = DateTime.Now;
                int check = 0;
                string strDate = today.ToString("yyyyMMddHHmmss");
                string milli = DateTime.Now.Millisecond.ToString();
                string receiptCode = strDate + milli;
                listRe = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(receiptCode);
                if (listRe.Count() == 0)
                {
                    listRe = new List<ReceiptSlipDTO>();
                    int dem = 0;
                    foreach (var item in gridView2.GetSelectedRows())
                    {
                        dem++;
                        long IdDe = long.Parse(gridView2.GetRowCellValue(item, "Id").ToString());
                        listRe = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(IdDe);
                        if(listRe.Count() == 0)
                        {
                            ReceiptSlipDAO.Instance.InsertReceiptSlip(receiptCode, IdDe, today, Kun_Static.accountDTO.UserName, "");
                        }
                        else
                        {
                            check++;
                            string msg = string.Format("dòng thứ {0} đã tồn tại", dem);
                            MessageBox.Show(msg.ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    check++;
                    MessageBox.Show("có lỗi khi thêm thông tin\n\nbạn hãy thử lại".ToUpper(), "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;                
                }
                List<ReceiptSlipDTO>listReByCode = new List<ReceiptSlipDTO>();
                List<ReceiptSlipDTO> listRePrinter = new List<ReceiptSlipDTO>();
                listReByCode = ReceiptSlipDAO.Instance.GetReceiptSlipDTOs(receiptCode);
                Kun_Static.ReceiptCode = receiptCode;
                foreach (ReceiptSlipDTO item in listReByCode)
                {
                    if(item.QuantityPlan <= 1000)
                    {
                        listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, receiptCode, item.MaterCode, item.MaterialName, item.QuantityPlan, item.DatePrinter, item.Employess, item.MaterCode + "&"+item.QuantityPlan.ToString()));
                    }
                    else
                    {
                        int du = item.QuantityPlan % 1000;
                        int nguyen = item.QuantityPlan / 1000;
                        for (int i = 1; i <= nguyen; i++)
                        {
                            listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, receiptCode, item.MaterCode, item.MaterialName, 1000, item.DatePrinter, item.Employess, item.MaterCode + "&" + "1000"));
                        }
                        if(du > 0)
                        {
                            listRePrinter.Add(new ReceiptSlipDTO(item.Id, item.IdDetail, receiptCode, item.MaterCode, item.MaterialName, du, item.DatePrinter, item.Employess, item.MaterCode + "&" + du.ToString()));
                        }
                    }
                }
                if(check == 0)
                {
                    rpCouponMaterial rpCoupon = new rpCouponMaterial(listRePrinter);
                    rpCoupon.PrintDialog();
                }
            }
        }
    }
}