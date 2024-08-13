using DevExpress.XtraReports.UI;
using System;
using System.Collections;
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
using WareHouse.Report;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmReInputMaterial : Form
    {

        public frmReInputMaterial()
        {

            InitializeComponent();
        }

        public EventHandler LamMoi;
        int checkAdd = 0;

        #region Control()
        void LoadControl()
        {
            LockControl();
        }
        void LockControl()
        {
            checkAdd = 0;
            btnInputNomal.Enabled = true;
            btnInputSpection.Enabled = true;
            txtBarCode.Enabled = false;
            txtMaterialName.Enabled = false;
            cbName.Enabled = false;
            nudQuantity.Enabled = false;
            txtMachine.Enabled = false;
            dtpkDateInput.Enabled = false;
            txtCountBox.Enabled = false;
        }
        void OpenControl()
        {
            txtBarCode.Enabled = true;
            txtMaterialName.Enabled = false;
            cbName.Enabled = true;
            nudQuantity.Enabled = true;
            txtMachine.Enabled = true;
            dtpkDateInput.Enabled = true;
            txtCountBox.Enabled = true;
        }
        void ClearText()
        {
            txtBarCode.SelectAll();
            txtMaterialName.Text = String.Empty;
            nudQuantity.Text = String.Empty;
            cbName.Text = string.Empty;
            txtCountBox.Text = "0";
        }
        void LoadMaterialCode()
        {
            string barCode = txtBarCode.Text;
            if (!barCode.Contains('&'))
            {
                LoadControl();
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaterialCode.Text = barCode.Split('&')[0];
            string materialCode = txtMaterialCode.Text;
            if (MaterialDAO.Instance.TestMaterialByCode(materialCode) != 1)
            {
                LockControl();
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            LoadNameMaterial(materialCode);
        }
        void LoadNameInput()
        {
            if (checkAdd == 0)
            {
                string materialCode = txtMaterialCode.Text;
                List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode);
                cbName.DataSource = listI;
                cbName.ValueMember = "IdWh";
                cbName.DisplayMember = "Name";
            }
            else
            {
                int Weight = 630;
                string style = "B";
                cbName.DataSource = WarehouseMaterialDAO.Instance.GetNameInput(Weight, style);
                cbName.ValueMember = "Id";
                cbName.DisplayMember = "Name";
            }
        }
        void LoadNameMaterial(string materialCode)
        {
            txtMaterialName.Text = MaterialDAO.Instance.GetNameMaterialByCode(materialCode);
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmEmployessCode frmE = new frmEmployessCode();
            frmE.ShowDialog();
            string Employess = Kun_Static.EmployessCode;
            int test = EmployessDAO.Instance.TestEmployessByCode(Employess);
            if (test == -1 && Employess.Trim().Length == 0)
            {
                LockControl();
                MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string materialCode = txtMaterialCode.Text;
            string materialName = MaterialDAO.Instance.GetNameMaterialByCode(materialCode);
            DateTime date = dtpkDateInput.Value;
            int quantity = (int)nudQuantity.Value;
            if (quantity <= 0)
            {
                MessageBox.Show("bạn chưa điền số lượng nhập !".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            string name = cbName.Text;
            string Nature = MaterialDAO.Instance.NatureMaterial(materialCode);
            string note = txtMachine.Text;
            int countBox = int.Parse(txtCountBox.Text);
            if (checkAdd == 0)
            {
                if (countBox <= 0)
                {
                    MessageBox.Show("bạn chưa điền số bao !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int IdWh = (int)(cbName.SelectedItem as IventoryMaterialDTO).IdWH;
                long Id = IventoryMaterialDAO.Instance.IdInputMaterial(materialCode, IdWh);
                string msg = string.Format(" Mã nguyên liệu : {0}\n\n Tên nguyên liệu {1}\n\n số lượng nhập : {2} \n\n vị trí {3}", materialCode, materialName, quantity, name);
                if (MessageBox.Show(msg.ToUpper(), "Thông tin nhập nhựa".ToUpper(), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    Kun_Static.CountBoxCycle = countBox;
                    Kun_Static.NameWhMaterial = name.ToUpper();
                    Kun_Static.CheckAdd = "";
                    frmCheckMacReCycle frm = new frmCheckMacReCycle();
                    frm.ShowDialog();
                    if (Kun_Static.CheckCycle != 0)
                    {
                        string typeInput = "Nhựa Hỗn Hợp";
                        IventoryMaterialDAO.Instance.IsertHistory(materialCode.ToUpper(), date, quantity, typeInput, Employess, name);
                        IventoryMaterialDAO.Instance.InsertReInputMaterialHH(Id, quantity, 0, date, Employess, note);
                    }
                }
                this.Close();
            }
            else
            {
                int IdWh = 0;
                string stRohs = "NO";
                try
                {
                    IdWh = (cbName.SelectedItem as WarehouseMaterial).Id;
                }
                catch
                {
                    MessageBox.Show("vị trí trống trên kho đã hết\n\n bạn hãy liên lạc với cấp trên để giải quyết".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string msg = string.Format(" Mã nguyên liệu : {0} \n\n Tên nguyên liệu : {1} \n\n Số lượng nhập : {2} \n\n Vị trí nhập : {3}".ToUpper(), materialCode, materialName, quantity, name);
                if (MessageBox.Show(msg, "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    IventoryMaterialDAO.Instance.InsertInputMaterial(materialCode, date, quantity, IdWh, 0, "HH", Employess, stRohs);
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWh, 2);
                    this.Close();
                }
            }
        }

        private void frmReInputMaterial_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadMaterialCode();
            LoadNameInput();
            txtBarCode.Enabled = false;
            nudQuantity.Focus();
            timer1.Stop();
        }

        private void btnInputNomal_Click(object sender, EventArgs e)
        {
            checkAdd = 0;
            OpenControl();
            ClearText();
            btnInputNomal.Enabled = false;
            btnInputSpection.Enabled = true;
        }

        private void btnInputSpection_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 2)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            OpenControl();
            checkAdd = 1;
            txtMachine.Enabled = false;
            btnInputSpection.Enabled = false;
            btnInputNomal.Enabled = true;
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
