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

namespace WareHouse.Order
{
    public partial class frmFCPart : DevExpress.XtraEditors.XtraForm
    {
        public frmFCPart()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            DateTime today = dtpkBegin.Value.Date;
            DateTime date1 = today.AddDays(1 - today.Day);
            DateTime date2 = date1.AddMonths(6);
            GCData.DataSource = OrderDAO.Instance.GetFCPartDTOs().Where(x=>x.DateFCPart >= date1 && x.DateFCPart <= date2);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmFCInport f = new frmFCInport();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            DateTime today = dtpkBegin.Value.Date;
            DateTime date1 = today.AddDays(1 - today.Day);
            DateTime date2 = date1.AddMonths(6);
            GCData.DataSource = OrderDAO.Instance.GetFCPartDTOs().Where(x => x.DateFCPart >= date1 && x.DateFCPart <= date2);
        }

        private void btnFCMaterial_Click(object sender, EventArgs e)
        {
            DateTime today = dtpkBegin.Value.Date;
            List<FCMaterialDTO> listFC = new List<FCMaterialDTO>();
            for (int i = 0; i <= 6; i++)
            {
                DateTime dateFC = today.AddDays(1-today.Day).AddMonths(i);
                List<FCPartDTO> listPart = new List<FCPartDTO>();
                listPart = OrderDAO.Instance.GetFCPartDTOs().Where(x => x.DateFCPart == dateFC).ToList();
                if(listPart.Count > 0)
                {
                    foreach (FCPartDTO item in listPart)
                    {
                        string materialCode = PartDAO.Instance.MaterialCodeByCode(item.PartCode);
                        float wpart = PartDAO.Instance.WeightByPart(item.PartCode);
                        FCMaterialDTO fCMaterialDTO = listFC.FirstOrDefault(x => x.MaterialCode == materialCode && x.DateFC == dateFC);
                        int quantity = (int)Math.Ceiling(item.Quantity *(wpart/1000));
                        if(fCMaterialDTO == null)
                        {
                            listFC.Add(new FCMaterialDTO(1,materialCode,"", quantity,dateFC));
                        }
                        else
                        {
                            int total = fCMaterialDTO.Quantity + quantity;
                            listFC.Remove(fCMaterialDTO);
                            listFC.Add(new FCMaterialDTO(1, materialCode, "", total, dateFC));
                        }
                    }
                }              
            }
            if(listFC.Count >0)
            {
                foreach (FCMaterialDTO item in listFC)
                {
                    FCMaterialDTO fCMaterialDTO = OrderDAO.Instance.GetItemFcMaterial(item.MaterialCode, item.DateFC);
                    if(fCMaterialDTO == null)
                    {
                        OrderDAO.Instance.InsertFCMaterial(item.MaterialCode, item.Quantity, item.DateFC);
                    }
                    else
                    {
                        if(item.Quantity != fCMaterialDTO.Quantity)
                        {
                            OrderDAO.Instance.UpdateFCMaterial(fCMaterialDTO.Id, item.MaterialCode, item.Quantity, item.DateFC);
                        }
                    }
                }
                MessageBox.Show("Đã tính xong nguyên liệu".ToUpper());
            }
        }
    }
}