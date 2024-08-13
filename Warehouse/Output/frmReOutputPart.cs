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

namespace WareHouse.Output
{
    public partial class frmReOutputPart : Form
    {
        public frmReOutputPart()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadPartNG();
        }
        void XoaText()
        {
            cbPartCode.Text = String.Empty;
            nudQuantity.Value = 0;
            dtpkDateOut.Text = String.Empty;
            nudTotal.Text = String.Empty;
        }
        void LoadPartNG()
        {
            cbPartCode.DataSource = IventoryPartDAO.Instance.GetListPartNG();
            cbPartCode.DisplayMember = "PartCode";
            cbPartCode.ValueMember = "PartCode";
         
        }
        void LoadTotalNG()
        {
            string partcode = cbPartCode.Text;
            int total = IventoryPartDAO.Instance.TotalPartNG(partcode);
            long idWarehouse = (cbName.SelectedItem as IvenstoryDTO).IdWareHouse;
            int countVt = IventoryPartDAO.Instance.TotalPartNGByIdWH(partcode, idWarehouse);
            nudCountVT.Value = countVt;
            nudTotal.Value = total;
        }
        void LoadWarehouse()
        {
            string partcode = cbPartCode.Text;
            cbName.DataSource = IventoryPartDAO.Instance.GetListPartNGByCode(partcode);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "IdWarehouse";
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string partCode = cbPartCode.Text;
            int quantity = (int)nudQuantity.Value;
            DateTime dateOut = dtpkDateOut.Value;
            long idWarehouse = (cbName.SelectedItem as IvenstoryDTO).IdWareHouse;
            string Employess = Kun_Static.EmployessCode;
            List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListPartNGByCode(partCode);
            int total = (int)nudCountVT.Value;
            if (partCode.Length > 0)
            {
                #region Xuât NG
                if (quantity > 0)
                {
                    if (quantity <= total)
                    {
                        foreach (IvenstoryDTO item in listI.Where(x=>x.IdWareHouse == idWarehouse))
                        {
                            long idInput = item.Id;
                            int totalIventory = item.Iventory;
                            int a = quantity - totalIventory;
                            if (a <= 0)
                            {
                                IventoryPartDAO.Instance.OutputPart(idInput, dateOut, quantity, Employess, "Xuất NG");
                                quantity = 0;
                                if (a == 0)
                                {
                                    WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 1);
                                    IventoryPartDAO.Instance.UpdateInputPart(item.Id, 1);
                                }
                                MessageBox.Show("bạn xuất thành công !".ToUpper());
                                XoaText();
                                return;
                            }
                            else
                            {
                                IventoryPartDAO.Instance.OutputPart(idInput, dateOut, totalIventory, Employess, "Xuất NG");
                                quantity = a;
                                WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 1);
                                IventoryPartDAO.Instance.UpdateInputPart(item.Id, 1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("sô lượng hàng NG tại vị trí không đủ !".ToUpper());
                    }
                }
                else
                {
                    MessageBox.Show("bạn chưa điền số lượng xuất !".ToUpper());
                }
                #endregion
            }
            else
            {
                MessageBox.Show("mã linh kiện không đúng !".ToUpper());
            }

        }

        private void cbPartCode_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadWarehouse();
          
        }

        private void frmReOutputPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void cbPartCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadWarehouse();
           
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTotalNG();
        }
    }
}
