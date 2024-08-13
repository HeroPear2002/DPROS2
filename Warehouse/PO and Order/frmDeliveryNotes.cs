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
using WareHouse.Report;
using DevExpress.XtraReports.UI;
using DAO;
using DTO;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.PO_and_Order
{
    public partial class frmDeliveryNotes : DevExpress.XtraEditors.XtraForm
    {
        public frmDeliveryNotes()
        {
            InitializeComponent();
            LoadDate();
            LoadControl();
        }
        void LoadControl()
        {
            LoadStatus();
            LoadData();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1 - today.Day);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-10);
        }
        void LoadStatus()
        {
            List<DeliveryNotesDTO> listDe = new List<DeliveryNotesDTO>();
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            listDe = DeliveryDAO.Instance.GetListALLDelivery().Where(x => x.StatusDe == 1).ToList();
            foreach (DeliveryNotesDTO item in listDe)
            {
                int a = (int)(DateTime.Now - (DateTime)item.DateDelivery).TotalHours;
                if (a >= 12)
                {
                    DeliveryDAO.Instance.UpdateDelivery(item.Id, 2,"BB chưa được giao");
                }
            }
            List<DeliveryNotesDTO> listDes = new List<DeliveryNotesDTO>();
            listDes = DeliveryDAO.Instance.GetListALLDelivery().Where(x => x.StatusDe == 0).ToList();
            foreach (DeliveryNotesDTO item in listDes)
            {
                List<DeliveryDetail> listDetail = new List<DeliveryDetail>();
                listDetail = DeliveryDAO.Instance.GetListDeliveryDetail(item.Id);
                int count = 0;
                foreach (DeliveryDetail jtem in listDetail)
                {
                    if (jtem.StatusDetail == 0 && (jtem.QuantityOut != jtem.Quantity))
                    {
                        POFixDAO.Instance.UpdatePOFixByCode(jtem.IdPOFix, 2, "");
                        count++;
                    }
                }
                if (item.EmployessOut.Length > 0 && count == 0)
                {
                    DeliveryDAO.Instance.UpdateDelivery(item.Id, 1, "");
                }
            }
        }
        void LoadData()
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            GCData.DataSource = DeliveryDAO.Instance.GetListALLDelivery(date1, date2).OrderByDescending(x=>x.DateInput);
        }
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                List<DeliveryPrint> listDP = new List<DeliveryPrint>();
                long id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                string DeCode = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DeCode"]).ToString() + "&" + id;
                DateTime dateDelivery = DateTime.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateDelivery"]).ToString());
                string dateOut = dateDelivery.Day.ToString("D2") + "/" + dateDelivery.Month.ToString("D2") + "/" + dateDelivery.Year.ToString("D2");
                string time = dateDelivery.Hour.ToString("D2") + ":" + dateDelivery.Minute.ToString("D2");
                Kun_Static.IdDe = id;
                List<DeliveryDetail> listDetail = DeliveryDAO.Instance.GetListDeliveryDetail(id);
                int i = 0;
                int sum = 0;
                foreach (DeliveryDetail item in listDetail)
                {
                    i++;
                    POFixDTO pOFixDTO = POFixDAO.Instance.GetItemPOFix(item.IdPOFix);
                    string PartName = PartDAO.Instance.NamePartByCode(item.PartCode);
                    int countPart = PartDAO.Instance.CountPartByCode(item.PartCode);
                    int countBox = (int)Math.Ceiling((Double)item.Quantity / countPart);
                    if(countPart == 0)
                    {
                        countBox = 0;
                    }
                    listDP.Add(new DeliveryPrint(i, DeCode.ToUpper(), item.POCode, item.PartCode, PartName, item.Quantity, countPart, countBox, pOFixDTO.FactoryCustomer, dateOut, time, pOFixDTO.CarNumber));
                    sum += countBox;
                }
                Kun_Static.TotalBox = sum;
                rpDelivery report = new rpDelivery();
                report.DataSource = listDP;
                report.LoadData();
                report.PrintDialog();
            }
            catch (Exception)
            {
            }
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
            if (MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    DeliveryDAO.Instance.DeleteDelivery(id);
                    DeliveryDAO.Instance.DeleteDeliveryDetailIdDe(id);
                    POFixDAO.Instance.UpdatePOFixByIdDe(id, 0, "");
                }
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnDeliveryDetail_Click(object sender, EventArgs e)
        {
            long id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
            Kun_Static.IdDe = id;
            frmDeliveryDetail f = new frmDeliveryDetail();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            DateTime today = DateTime.Now.Date;
            if (e.RowHandle >= 0)
            {
                int statusDe = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusDe"]).ToString());
                if (statusDe == 0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
                else if (statusDe == 2)
                {
                    e.Appearance.BackColor = Color.Red;
                }

            }
        }

        private void GCData_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Kun_Static.Style = 9;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
    }
}