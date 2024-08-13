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

namespace WareHouse.Input
{
    public partial class frmEditIventoryPart : Form
    {
        public frmEditIventoryPart()
        {
            InitializeComponent();
            LockControl();
        }
        public EventHandler LamMoi;
        int status = 0;
        void LockControl()
        {
            LoadControl();
            btnSave.Enabled = false;
            txtNote.Enabled = false;
            nudIventory.Enabled = false;
        }
        void LoadControl()
        {
            cbId.Text = fIventory.IventoryPart.Id.ToString();
            cbPartCode.Text = fIventory.IventoryPart.PartCode;
            cbName.Text = fIventory.IventoryPart.Name;
            nudIventory.Value = fIventory.IventoryPart.Iventory;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            string Employess = Kun_Static.accountDTO.UserName;
            long Id = long.Parse(cbId.Text);
            string partCode = cbPartCode.Text;
            DateTime DateOutput = DateTime.Now;
            int countInput = IventoryPartDAO.Instance.QuantityInput(Id);
            int total = (int)nudIventory.Value - fIventory.IventoryPart.Iventory;
            string note = txtNote.Text;
            string detail = "";
            if (MessageBox.Show("bạn muốn sửa thông tin này ?".ToUpper(),"Thông Báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Information)== DialogResult.OK)
            {
                if(status == 0)
                {
                    detail = "Sửa số lượng mã linh kiện : " + partCode + " từ "+ fIventory.IventoryPart.Iventory.ToString() + " thành: " + nudIventory.Value.ToString();
                    IventoryPartDAO.Instance.EditIventoryPart(Id, partCode, (countInput + total));
                   // IventoryPartDAO.Instance.OutputPartNotProvider(Id, DateOutput, CountOut, Employess, "Sửa tồn kho");
                }
                else
                {
                    detail = "Thêm ghi chú : " + note;
                    IventoryPartDAO.Instance.UpdateNote2InputPart(Id,note);              
                }
                EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, detail, fIventory.IventoryPart.Name);
                LoadControl();
                this.Close();
            }
        }

        private void frmEditIventoryPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnEditQuantity_Click(object sender, EventArgs e)
        {
            txtNote.Enabled = false;
            nudIventory.Enabled = true;
            status = 0;
            btnSave.Enabled = true;
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            nudIventory.Enabled = false;
            txtNote.Enabled = true;
            status = 1;
            btnSave.Enabled = true;
        }
    }
}
