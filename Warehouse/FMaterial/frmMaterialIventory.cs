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

namespace WareHouse.FMaterial
{
    public partial class frmMaterialIventory : DevExpress.XtraEditors.XtraForm
    {
        public frmMaterialIventory()
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
        void LoadMaterial()
        {
            glMaterial.Properties.DataSource = MaterialDAO.Instance.GetListMaterial();
            glMaterial.Properties.ValueMember = "MaterialCode";
            glMaterial.Properties.DisplayMember = "MaterialCode";
        }
        void LoadData()
        {
            GCData.DataSource = MaterialInforDAO.Instance.GetTableInventoryMaterials();
        }
        void LockControl()
        {
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            btnSave.Enabled = false;

            glMaterial.Enabled = false;
            txtNote.Enabled = false;
            nudQuantity.Enabled = false;
        }
        void OpenControl()
        {
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            btnSave.Enabled = true;

            glMaterial.Enabled = true;
            txtNote.Enabled = true;
            nudQuantity.Enabled = true;
        }
        void ClearText()
        {
            glMaterial.Text = String.Empty;
            txtNote.Text = String.Empty;
            nudQuantity.Text = String.Empty;
        }
        void AddText()
        {
            try
            {
                glMaterial.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle,gridView1.Columns["MaterialCode"]).ToString();
                txtNote.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Note"]).ToString();
                nudQuantity.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["QuantityInventory"]).ToString();
            }
            catch 
            {
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
            if(MessageBox.Show("bạn muốn xóa thông tin này ?".ToUpper(),"Thông báo",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string material = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    MaterialInforDAO.Instance.DeleteTableMaterial(material);
                }
                LoadControl();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            OpenControl();
            Isinsert = false;
            glMaterial.Enabled = false ;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string material = glMaterial.Text;
            int quantity = (int)nudQuantity.Value;
            string note = txtNote.Text;
           
            if(Isinsert == true)
            {
                TableInventoryMaterial tableInventoryMaterial = MaterialInforDAO.Instance.GetItemTableMaterial(material);
                if(tableInventoryMaterial != null)
                {
                    MessageBox.Show("Mã nguyên liệu đã tồn tại!".ToUpper(),"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    MaterialInforDAO.Instance.InsertTableMaterial(material, quantity, note);
                    MessageBox.Show("thêm thông tin thành công!".ToUpper());
                    LoadControl();
                    return;
                }
            }
            else
            {
                material = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["MaterialCode"]).ToString();
                MaterialInforDAO.Instance.UpdateTableMaterial(material, quantity, note);
                MessageBox.Show("sửa thông tin thành công!".ToUpper());
                LoadControl();
                return;
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

        private void btnInport_Click(object sender, EventArgs e)
        {
            frmInportMetrialInventory f = new frmInportMetrialInventory();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnForm_Click(object sender, EventArgs e)
        {
            frmFormMaterialInventoty f = new frmFormMaterialInventoty();
            f.ShowDialog();
        }

        private void GCData_Click(object sender, EventArgs e)
        {
            AddText();
        }

        #endregion
    }
}