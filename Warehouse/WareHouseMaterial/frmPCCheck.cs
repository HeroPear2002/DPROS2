using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmPCCheck : Form
    {
        public frmPCCheck()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            List<IventoryMaterialDTO> listINew = new List<IventoryMaterialDTO>();
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventoryByCode34();
            foreach (IventoryMaterialDTO item in listI)
            {
                float Requantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(item.Id);
                float RequantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(item.Id);
                float iventory = item.QuantityInput + Requantity + RequantityHH;
                if (iventory <= 0)
                {
                    IventoryMaterialDAO.Instance.UpdateStatust(item.Id, 1);
                    IventoryMaterialDAO.Instance.UpdateStartReInputMaterial(item.Id, 1);
                    IventoryMaterialDAO.Instance.UpdateStartReInputHHByIdInput(item.Id, 1);
                    WarehouseMaterialDAO.Instance.UpdateStatus((int)item.IdWH, 1);
                }
                else
                {
                    listINew.Add(new IventoryMaterialDTO(item.Id, item.IdWH, item.MaterialCode, item.DateInput, item.MaterialName, iventory, item.Name,item.StyleInput, item.Lot, item.Rosh));
                }
            }
            GCData.DataSource = listINew;
        }
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int testAcc = AccountDAO.Instance.PermissionAccount(user);
            if (testAcc < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show("bạn đã đặt đơn hàng cho mã nhựa này rồi chứ ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                foreach (var item in gridView1.GetSelectedRows())
                {
                    string materialCode = gridView1.GetRowCellValue(item, "MaterialCode").ToString();
                    List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventoryByCode(materialCode);
                    foreach (IventoryMaterialDTO items in listI)
                    {
                        int idWH = (int)items.IdWH;
                        WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 5);
                    }
                }
                LoadControl();
            }
        }

        private void frmPCCheck_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
