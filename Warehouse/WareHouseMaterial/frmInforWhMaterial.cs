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
using System.Globalization;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmInforWhMaterial : DevExpress.XtraEditors.XtraForm
    {
        int idWh = Kun_Static.IdWhMaterial;
        int statusWH = 0;
        public EventHandler LamMoi;
        public frmInforWhMaterial()
        {
            InitializeComponent();
            LoadControl();
            LoadColum();
        }
        void LoadColum()
        {
            gridView2.Columns["Quantity"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "Quantity", "Tổng = {0}");
            gridView3.Columns["QuantityInputHH"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "QuantityInputHH", "Tổng = {0}");
        }

        void LoadControl()
        {
            LoadDataCycle();
            ChangeAccout();
            LockControl();
        }
        void ChangeAccout()
        {
            if (Kun_Static.accountDTO.Type == 2 || Kun_Static.accountDTO.Type == 1)
            {
                btnOutNb.Enabled = true;
                btnReSaveNb.Enabled = true;
                btnReOutHH.Enabled = true;
            }
            else
            {
                btnOutNb.Enabled = false;
                btnReSaveNb.Enabled = false;
                btnReOutHH.Enabled = false;
            }
        }
        void LockControl()
        {
            btnSaveNb.Enabled = false;
            btnReSaveNb.Enabled = false;
            btnReSaveHH.Enabled = false;

            txtQuantityNb.Enabled = false;
            txtReQuantityNb.Enabled = false;
            txtReQuantityHH.Enabled = false;

        }
        void ClearText()
        {
            txtIdNb.Text = String.Empty;
            txtReIdNb.Text = String.Empty;
            txtReIdHH.Text = String.Empty;

            txtQuantityNb.Text = String.Empty;
            txtReQuantityNb.Text = String.Empty;
            txtReQuantityHH.Text = String.Empty;
        }
        void AddTextNB()
        {
            try
            {
                txtQuantityNb.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["QuantityInput"]).ToString();
                txtIdNb.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["Id"]).ToString();
            }
            catch
            {

            }
        }
        void AddTextReNB()
        {
            try
            {
                txtReQuantityNb.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Quantity"]).ToString();
                txtReIdNb.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, gridView2.Columns["Id"]).ToString();
            }
            catch
            {

            }
        }
        void AddTextReHH()
        {
            try
            {
                txtReQuantityHH.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["QuantityInputHH"]).ToString();
                txtReIdHH.Text = gridView3.GetRowCellValue(gridView3.FocusedRowHandle, gridView3.Columns["Id"]).ToString();
            }
            catch
            {

            }
        }
        private void frmInforWhMaterial_Load(object sender, EventArgs e)
        {
            LoadDataCycle();
        }
        void LoadDataCycle()
        {
            LoadStatust();
            this.Text = "Thông tin vị trí ".ToUpper() + Kun_Static.NameWhMaterial;
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventoryByIdWh(idWh);
            long idInput = 0;
            if(listI.Count == 0)
            {
                WarehouseMaterialDAO.Instance.UpdateStatus(idWh, 1);
            }
            foreach (IventoryMaterialDTO item in listI)
            {
                idInput = item.Id;
            }
            GcData.DataSource = listI;
            GCDataCycle.DataSource = IventoryMaterialDAO.Instance.GetInforReMaterial(idInput);
            List<IventoryReMaterialHH> listHH = IventoryMaterialDAO.Instance.GetInforReMaterialHH(idInput);
            foreach (IventoryReMaterialHH item in listHH)
            {
                if(item.QuantityInputHH <= 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(item.Id,1);
                }
            }
            GCDataHH.DataSource = listHH;
        }
        void LoadStatust()
        {
            List<IventoryReMaterial> listRe = IventoryMaterialDAO.Instance.GetInforReMaterial(idWh);
            List<IventoryReMaterialHH> listReHH = IventoryMaterialDAO.Instance.GetInforReMaterialHH(idWh);
            foreach (IventoryReMaterial item in listRe)
            {
                if (item.Quantity <= 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(item.Id, 1);
                }
            }
            foreach (IventoryReMaterialHH item in listReHH)
            {
                if (item.QuantityInputHH <= 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(item.Id, 1);
                }
            }
        }
        private void GCDataCycle_Click(object sender, EventArgs e)
        {
            ClearText();
            AddTextReNB();
        }
        private void GcData_Click(object sender, EventArgs e)
        {
            ClearText();
            AddTextNB();
        }
        private void GCDataHH_Click(object sender, EventArgs e)
        {
            ClearText();
            AddTextReHH();
        }
        private void btnOutNb_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnSaveNb.Enabled = true;
            txtQuantityNb.Enabled = true;
        }

        private void btnReOutNb_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReSaveNb.Enabled = true;
            txtReQuantityNb.Enabled = true;
        }

        private void btnReOutHH_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReSaveHH.Enabled = true;
            txtReQuantityHH.Enabled = true;
        }

        private void btnSaveNb_Click(object sender, EventArgs e)
        {
            try
            {
                statusWH = WarehouseMaterialDAO.Instance.StatusWH(idWh);
                long IdInput = long.Parse(txtIdNb.Text);
                DateTime dateOut = DateTime.Now;
                float quantity = (float)Convert.ToDouble(txtQuantityNb.Text);
                float Iventory0 = IventoryMaterialDAO.Instance.IventoryMaterialById(IdInput);
                if (quantity > Iventory0)
                {
                    string msg = string.Format("bạn chỉ được xuất số lượng bằng {0} trong lần xuất này", Iventory0);
                    MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (quantity <= 0)
                {
                    MessageBox.Show("bạn không được xuất số lượng âm".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Employess = Kun_Static.accountDTO.UserName;
                string style = "Xuất nội bộ";
                if(statusWH == 10)
                {
                    style = "Xuất NL NG";
                }
                IventoryMaterialDAO.Instance.OutPutMaterial(IdInput, dateOut, quantity, Employess, style, "", "", "");
                float Iventory = IventoryMaterialDAO.Instance.IventoryMaterialById(IdInput);
                if (quantity == Iventory0)
                {
                    List<IventoryReMaterial> listRe = IventoryMaterialDAO.Instance.GetInforReMaterial(IdInput);
                    List<IventoryReMaterialHH> listHH = IventoryMaterialDAO.Instance.GetInforReMaterialHH(IdInput);
                    if(listRe.Count > 0)
                    {
                        foreach (IventoryReMaterial item in listRe)
                        {
                            IventoryMaterialDAO.Instance.OutputMaterialCycle(item.Id, dateOut, item.Quantity, Employess, "", "", style,"","",0);
                            IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(item.Id, 1);
                        }
                    }
                     if(listHH.Count > 0)
                    {
                        foreach (IventoryReMaterialHH item in listHH)
                        {
                            IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(item.Id, dateOut, item.QuantityInputHH, Employess, "", "", style,"","",0);
                            IventoryMaterialDAO.Instance.UpdateStartReInputHH(item.Id, 1);
                        }
                    }
                    IventoryMaterialDAO.Instance.UpdateStatust(IdInput, 1);
                    WarehouseMaterialDAO.Instance.UpdateStatus(idWh, 1);
                  
                }
                MessageBox.Show("Xuất thành công !".ToUpper());
                LoadControl();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu cần xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnReSaveNb_Click(object sender, EventArgs e)
        {
            try
            {
                statusWH = WarehouseMaterialDAO.Instance.StatusWH(idWh);
                long IdReInput = long.Parse(txtReIdNb.Text);
                DateTime dateOut = DateTime.Now;
                float quantity = (float)Convert.ToDouble(txtReQuantityNb.Text);
                float Iventory0 = IventoryMaterialDAO.Instance.ReQuantitybyId(IdReInput);
                if (quantity > Iventory0)
                {
                    string msg = string.Format("bạn chỉ được xuất số lượng bằng {0} trong lần xuất này", Iventory0);
                    MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (quantity <= 0)
                {
                    MessageBox.Show("bạn không được xuất số lượng âm".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Employess = Kun_Static.accountDTO.UserName;
                string style = "Xuất nội bộ";
                if (statusWH == 10)
                {
                    style = "Xuất NL NG";
                }
                IventoryMaterialDAO.Instance.OutputMaterialCycle(IdReInput, dateOut, quantity, Employess, "", "", style,"","",0);
                float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(IdReInput);
                if (IventoryTC == 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(IdReInput, 1);
                }
                MessageBox.Show("Xuất thành công !".ToUpper());
                LoadControl();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu cần xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void btnReSaveHH_Click(object sender, EventArgs e)
        {
            try
            {
                statusWH = WarehouseMaterialDAO.Instance.StatusWH(idWh);
                long idInputHH = long.Parse(txtReIdHH.Text);
                DateTime dateOut = DateTime.Now;
                float quantity = (float)Convert.ToDouble(txtReQuantityHH.Text);
                float Iventory0 = IventoryMaterialDAO.Instance.IventoryMaterialHH(idInputHH);
                if (quantity > Iventory0)
                {
                    string msg = string.Format("bạn chỉ được xuất số lượng bằng {0} trong lần xuất này", Iventory0);
                    MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (quantity <= 0)
                {
                    MessageBox.Show("bạn không được xuất số lượng âm".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string Employess = Kun_Static.accountDTO.UserName;
                string style = "Xuất nội bộ";
                if (statusWH == 10)
                {
                    style = "Xuất NL NG";
                }
                IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, quantity, Employess, "", "", style,"","",0);
                float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(idInputHH);
                if (IventoryHH == 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
                }
                MessageBox.Show("Xuất thành công !".ToUpper());
                LoadControl();
            }
            catch
            {
                MessageBox.Show("bạn chưa chọn nguyên liệu cần xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void frmInforWhMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Kun_Static.IdWhMaterial = 0;
            Kun_Static.NameWhMaterial = "";
            LamMoi?.Invoke(sender, e);
        }
    }
}