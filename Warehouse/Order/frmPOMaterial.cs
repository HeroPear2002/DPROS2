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
using WareHouse.Report;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.Mail;
using System.Net;
using WareHouse.Common;

namespace WareHouse.Order
{
    public partial class frmPOMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmPOMaterial()
        {
            InitializeComponent();
            LoadControl();
        }

        void LoadControl()
        {
            LoadDate();
            LoadStatus();
            LoadData();
        }
        void LoadData()
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            GCData.DataSource = POMaterialDAO.Instance.GetPOMaterialDTOs().Where(x => x.DateCreate >= date1 && x.DateCreate <= date2);
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1 - today.Day);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-10);
        }
        async void LoadStatus()
        {
            await LoadStatus(dtpkFrom.Value, dtpkTo.Value);
        }
        public static async Task LoadStatus(DateTime date1, DateTime date2)
        {
            await Task.Run(() =>
            {
                List<ListMailPOMaterial> _listMail = new List<ListMailPOMaterial>();
                List<POMaterialDTO> listPO = POMaterialDAO.Instance.GetPOMaterialDTOs().Where(x => x.DateCreate >= date1 && x.DateCreate <= date2).ToList();
                DateTime today = DateTime.Now;
                foreach (POMaterialDTO item in listPO)
                {
                    DateTime? minDate = POMaterialDAO.Instance.MinDatePlan(item.Id);
                    if (minDate != null)
                    {
                        int a = (int)(today - (DateTime)minDate).TotalDays;
                        if (a >= -1 && item.Declaration.Length == 0)
                        {
                            POMaterialDAO.Instance.UpdatePOMAterial(item.Id, 1);
                            _listMail.Add(new ListMailPOMaterial(1, item.POCode));
                        }
                        else
                        {
                            DateTime? maxDate = POMaterialDAO.Instance.MaxDatePlan(item.Id);
                            if (maxDate != null)
                            {
                                int b = (int)(today - (DateTime)maxDate).TotalDays;
                                if (b >= 3 && item.Bill.Length == 0)
                                {
                                    POMaterialDAO.Instance.UpdatePOMAterial(item.Id, 2);
                                    _listMail.Add(new ListMailPOMaterial(2, item.POCode));
                                }
                            }
                        }
                    }
                    else if(item.StatusPO == 0)
                    {
                        List<ProgressDetailDTO> listP = POMaterialDAO.Instance.GetProgressDetailDTOs(item.Id).Where(x => x.DatePlan != null).ToList();
                        foreach (ProgressDetailDTO jtem in listP)
                        {
                            int day = (int)(today - (DateTime)jtem.DatePlan).TotalDays;
                            if (today.Hour >= 8 && day >= 1 && jtem.DateReality == null)
                            {
                                POMaterialDAO.Instance.UpdateProgress(item.Id, 1);
                                _listMail.Add(new ListMailPOMaterial(3, item.POCode));
                                break;
                            }
                        }
                    }
                }
                #region SEND MAIL
                List<ListMailPOMaterial> listP1 = _listMail.Where(x => x.StatusMail == 1).ToList();
                List<ListMailPOMaterial> listP2 = _listMail.Where(x => x.StatusMail == 2).ToList();
                List<ListMailPOMaterial> listP3 = _listMail.Where(x => x.StatusMail == 3).ToList();
                string message1 = "";
                string message2 = "";
                string message3 = "";
                int dk = 0;
                if (listP1.Count > 0)
                {
                    dk = 1;
                    message1 = "đơn hàng chưa có tờ khai : \n";
                    foreach (ListMailPOMaterial item in listP1)
                    {
                        message1 += item.PoCode + " ;";
                    }
                }
                if (listP2.Count > 0)
                {
                    dk = 2;
                    message2 = "đơn hàng chưa có hóa đơn : \n";
                    foreach (ListMailPOMaterial item in listP2)
                    {
                        message2 += item.PoCode + " ;";
                    }
                }
                if (listP3.Count > 0)
                {
                    dk = 3;
                    message3 = "đơn hàng có lượng nguyên liệu chưa nhận : \n";
                    foreach (ListMailPOMaterial item in listP3)
                    {
                        message3 += item.PoCode + " ;";
                    }
                }
                List<AccountDTO> listEmail = AccountDAO.Instance.GetAccountEmail(2);
                if (dk > 0 && listEmail.Count > 0)
                {
                    string message = message1 + "\n\n\n\n" + message2 + "\n\n\n\n" + message3;
                    string to = "";
                    string subject = "Cảnh báo PO Nguyên Liệu";
                    foreach (AccountDTO item in listEmail)
                    {
                      to += item.EMail + ",";
                    }
                    SendEMail.SendGMail(to, subject, message);
                }
                #endregion
            });
        }
        #region gửi mail
        public static async Task SendMail()
        {
            await Task.Run(() =>
            {

            });
        }
        #endregion
        private void btnDetail_Click(object sender, EventArgs e)
        {
            long Id = long.Parse(txtID.Text);
            Kun_Static.IdPOMaterial = Id;
            frmDetailPOMaterial f = new frmDetailPOMaterial();
            f.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    List<POMaterialDetail> listPO = POMaterialDAO.Instance.GetPOMaterialDetails(id);
                    foreach (POMaterialDetail jtem in listPO)
                    {
                        int quantityOrder = MaterialDAO.Instance.GetItemMaterialBy(jtem.IdBy).QuantityOrder;
                        POMaterialDAO.Instance.DeletePODetail(jtem.Id);
                        MaterialDAO.Instance.UpdateMaterialBy(jtem.IdBy, quantityOrder - jtem.QuantityBy);
                    }
                    POMaterialDAO.Instance.DeletePOMAterial(id);
                    POMaterialDAO.Instance.DeletePO(id);

                }
                LoadControl();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                long IdPO = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                List<POMaterialDetail> listPO = new List<POMaterialDetail>();
                listPO = POMaterialDAO.Instance.GetPOMaterialDetails(IdPO);
                rpOrderMaterial rp = new rpOrderMaterial(listPO);
                rp.PrintDialog();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn PO!\n\nHoặc bạn chưa có chi tiết đơn hàng".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            try
            {
                txtID.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch
            {
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("bạn muốn sửa thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    string Declaration = gridView1.GetRowCellValue(item, "Declaration").ToString();
                    string Bill = gridView1.GetRowCellValue(item, "Bill").ToString();
                    POMaterialDAO.Instance.UpdatePOMaterial(id, Declaration, Bill, 0);
                }
                LoadControl();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusPO"]).ToString());
                if (status == 1)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if (status == 2)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }

        private void btnPrinVAT_Click(object sender, EventArgs e)
        {
            try
            {
                long IdPO = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                List<POMaterialDetail> listPO = new List<POMaterialDetail>();
                listPO = POMaterialDAO.Instance.GetPOMaterialDetails(IdPO);
                rpOrderMaterialVAT rp = new rpOrderMaterialVAT(listPO);
                rp.PrintDialog();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn PO!\n\nHoặc bạn chưa có chi tiết đơn hàng".ToUpper(), "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}