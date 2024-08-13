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
using WareHouse.FParts;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmHistoryDry : DevExpress.XtraEditors.XtraForm
    {
        public frmHistoryDry()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadDate();
            LoadData();
        }
        void LoadDate()
        {
            DateTime today = DateTime.Now.Date;
            dtpkFrom.Value = today.AddDays(1 - today.Day);
            dtpkTo.Value = dtpkFrom.Value.AddMonths(1).AddSeconds(-1);
        }
        void LoadData()
        {
            DateTime date1 = dtpkFrom.Value;
            DateTime date2 = dtpkTo.Value;
            List<DryingDTO> listDry = DryingAndPourDAO.Instance.GetListDrying().Where(x=>x.DateDrying >= date1 && x.DateDrying <= date2).ToList();
            GCData.DataSource = listDry;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnPourMaterial_Click(object sender, EventArgs e)
        {
            frmPourDrying f = new frmPourDrying();
            f.Refreshs += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<DryingDTO> dryingDTOs = new List<DryingDTO>();
            foreach (var item in gridView1.GetSelectedRows())
            {
                long id = long.Parse(gridView1.GetRowCellValue(item,"Id").ToString());
                DryingDTO dryingDTO = DryingAndPourDAO.Instance.GetItemDry(id);
                string qrCode = dryingDTO.MaterialCode + "&" + dryingDTO.Id;
                dryingDTOs.Add(new DryingDTO(dryingDTO.Id, dryingDTO.MaterialCode, dryingDTO.MaterialName, dryingDTO.MachineDry,
                    dryingDTO.QuantityDry, dryingDTO.DateDrying, dryingDTO.DatePour, dryingDTO.Employess, dryingDTO.PartCode, dryingDTO.MachineCode,
                    dryingDTO.StatusDry, qrCode));
            }
            rpTemDryMaterial rpTemDry = new rpTemDryMaterial();
            rpTemDry.DataSource = dryingDTOs;
            rpTemDry.PrintDialog();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                int statusCheck = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusDry"]).ToString());
                if(statusCheck == 0)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }
    }
}