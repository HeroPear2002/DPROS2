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
using DevExpress.XtraGrid.Views.Grid;
using DTO;

namespace WareHouse.FMaterial
{
    public partial class frmPriceMaterial : DevExpress.XtraEditors.XtraForm
    {
        public frmPriceMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        bool Isinsert = false;
        #region Control
        void LoadControl()
        {
            LockControl();
            LoadData();
            LoadMaterial();
        }
        void LockControl()
        {
            glMaterial.Enabled = false;
            txtPriceVND.Enabled = false;
            txtPriceUSD.Enabled = false;
            txtNote.Enabled = false;
            dtpkDateInput.Enabled = true;

            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

        }
        void OpenControl()
        {
            glMaterial.Enabled = true;
            txtPriceVND.Enabled = true;
            txtPriceUSD.Enabled = true;
            txtNote.Enabled = true;
            dtpkDateInput.Enabled = true;

            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;
        }
        void ClearText()
        {
            glMaterial.Text = String.Empty;
            txtPriceVND.Text = String.Empty;
            txtPriceUSD.Text = String.Empty;
            txtNote.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                glMaterial.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                txtPriceVND.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PriceVND"]).ToString();
                txtPriceUSD.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["PriceUSD"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                dtpkDateInput.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["DateInput"]).ToString();
            }
            catch
            {
            }
        }
        void LoadData()
        {
            DateTime today = dtpkDateInput.Value.Date;
            today = today.AddDays(1 - today.Day);
            List<MaterialPriceDTO> listM = new List<MaterialPriceDTO>();
            listM = MaterialDAO.Instance.GetListAllMaterPrice();
            GCData.DataSource = listM.Where(x=>x.DateInput >= today && x.DateInput <= today.AddMonths(1).AddSeconds(-10));
        }
        void LoadMaterial()
        {
            glMaterial.Properties.DataSource = MaterialDAO.Instance.GetListMaterial();
            glMaterial.Properties.DisplayMember = "MaterialCode";
            glMaterial.Properties.ValueMember = "MaterialCode";
        }
        DateTime LoadDate(DateTime date)
        {
            DateTime today = date;
            if(date.Day < 15)
            {
                today = date.Date;
                today = today.AddDays(1 - today.Day);
                return today;
            }
            else
            {
                today = date.Date;
                today = today.AddDays(1 - today.Day + 15);
                return today;
            }
        }
        #endregion
        #region Event

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = true;
            ClearText();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("bạn muốn xóa thông tin này?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MaterialDAO.Instance.DeleteMaPrice(id);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string MaterialCode = glMaterial.Text;
            DateTime DateInput = LoadDate(dtpkDateInput.Value);
            if (DateInput.Day < 15)
            {
                DateInput = DateInput.AddDays(1 - DateInput.Day);
            }
            else
            {
                DateInput = DateInput.AddDays(1 - DateInput.Day + 14);
            }
            Decimal PriceVND = decimal.Parse(txtPriceVND.Text);
            string PriceUSD = txtPriceUSD.Text;
            int StatusPrice = 0;
            string Note = txtNote.Text;
            MaterialPriceDTO materialPriceDTO = null;
            if (Isinsert == true)
            {
                materialPriceDTO = MaterialDAO.Instance.GetItemMaterPrice(MaterialCode, DateInput);
                if(materialPriceDTO != null)
                {
                    MessageBox.Show("thông tin đã tồn tại".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MaterialDAO.Instance.InsertMaPrice(MaterialCode, DateInput, PriceVND, PriceUSD, StatusPrice, Note);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                }
            }
            else
            {
                long id = long.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString());
                MaterialDAO.Instance.UpdateMaPrice(id,MaterialCode, DateInput, PriceVND, PriceUSD, StatusPrice, Note);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn muốn phê duyệt thông tin này?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    long id = long.Parse(gridView1.GetRowCellValue(item, "Id").ToString());
                    MaterialDAO.Instance.UpdateMaPrice(id,1);
                }
                LoadControl();
            }
        }

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportMaterialPrice f = new frmInportMaterialPrice();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            frmMaterialPriceForm f = new frmMaterialPriceForm();
            f.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Common.ExportExcel.Export(GCData);
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }
        #endregion

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if(e.RowHandle >= 0)
            {
                int status = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["StatusPrice"]).ToString());
                if(status == 0)
                {
                    e.Appearance.BackColor = Color.Orange;
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            List<MaterialPriceDTO> listM = new List<MaterialPriceDTO>();
            listM = MaterialDAO.Instance.GetListAllMaterPrice();
            GCData.DataSource = listM;
        }

        private void txtPriceUSD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && (e.KeyChar != '.' ||
             (e.KeyChar == '.' && (txtPriceUSD.Text.Length == 0 || txtPriceUSD.Text.IndexOf('.') != -1))))
                e.Handled = true;
        }
    }
}