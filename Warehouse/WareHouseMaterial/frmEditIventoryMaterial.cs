using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmEditIventoryMaterial : Form
    {
        public frmEditIventoryMaterial()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            LoadData();
        }
        void LoadData()
        {
            cbID.Text = frmIventoryMaterial.Iventory.Id.ToString();
            cbMaterial.Text = frmIventoryMaterial.Iventory.MaterialCode;
            nudQuantity.Value = frmIventoryMaterial.Iventory.QuantityInput;
            dtpkDate.Value = frmIventoryMaterial.Iventory.DateInput;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            long Id = long.Parse(cbID.Text);
            string material = cbMaterial.Text;
            int quantityInput = (int)nudQuantity.Value;
            int quantity = quantityInput - frmIventoryMaterial.Iventory.QuantityInput;
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string detail = "Sửa số lượng mã nguyên liệu : " + material +" từ " + frmIventoryMaterial.Iventory.QuantityInput.ToString() + " thành : "  + quantityInput.ToString() +"KG";
            if(MessageBox.Show("bạn muốn sửa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information)== DialogResult.OK)
            {
                IventoryMaterialDAO.Instance.EditIventoryMaterial(Id, material, quantityInput, quantity);
                EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName,detail, frmIventoryMaterial.Iventory.Name);
                LoadControl();
                this.Close();
            }
        }

        private void frmEditIventoryMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
