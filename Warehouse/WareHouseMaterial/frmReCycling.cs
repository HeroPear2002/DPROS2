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
using DTO;
using DAO;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmReCycling : DevExpress.XtraEditors.XtraForm
    {

        public frmReCycling()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        int checkAdd = 0;
        int _checkWH = 0;
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
            txtMaterialCode.Enabled = false;
            txtMaterialName.Enabled = false;
            cbNameWH.Enabled = false;
            dtpkDate.Enabled = false;
            nudQuantity.Enabled = false;
            nudTotalMax.Enabled = false;
            btnSave.Enabled = false;
            txtCountBox.Enabled = false;
        }
        void OpenControl()
        {
            txtMaterialCode.Focus();
            txtBarCode.Enabled = true;
            txtMaterialName.Enabled = true;
            cbNameWH.Enabled = true;
            dtpkDate.Enabled = true;
            nudQuantity.Enabled = true;
            nudTotalMax.Enabled = false;
            btnSave.Enabled = true;
        }
        void LoadNameInput()
        {
            if (checkAdd == 0)
            {
                string materialCode = txtMaterialCode.Text;
                List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode);
                cbNameWH.DataSource = listI;
                cbNameWH.ValueMember = "IdWh";
                cbNameWH.DisplayMember = "Name";
            }
            else
            {
                int Weight = 630;
                string style = "B";
                cbNameWH.DataSource = WarehouseMaterialDAO.Instance.GetNameInput(Weight, style);
                cbNameWH.ValueMember = "Id";
                cbNameWH.DisplayMember = "Name";
                nudTotalMax.Text = Weight.ToString();
            }
        }
        void LoadBarcode()
        {
            timer1.Stop();
            string barCode = txtBarCode.Text;
            if (!barCode.Contains('&'))
            {
                _checkWH = 1;
                LoadControl();
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtMaterialCode.Text = barCode.Split('&')[0];
            txtMaterialName.Text = MaterialDAO.Instance.GetNameMaterialByCode(txtMaterialCode.Text);
            _checkWH = 0;
            string materialCode = barCode.Split('&')[0];
            nudQuantity.Focus();
            LoadNameInput();
        }
        void LoadTotal(string materialCode)
        {
            if (checkAdd == 1)
            {
                nudTotalMax.Text = "630";
            }
            else
            {
                int IdWh = (int)(cbNameWH.SelectedItem as IventoryMaterialDTO).IdWH;
                long IdInput = IventoryMaterialDAO.Instance.IdInputMaterial(materialCode, IdWh);
                float total = IventoryMaterialDAO.Instance.QuantityInputMaterial(materialCode, IdWh);
                float reQuantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(IdInput);
                int ratioInput = MaterialDAO.Instance.RatioInputByCode(materialCode);
                float a = (int)((total * ratioInput) / 100);
                if (a > reQuantity)
                {
                    nudTotalMax.Text = ((float)Math.Round(a - reQuantity, 2)).ToString();
                }
                else
                {
                    nudTotalMax.Text = "0";
                }
            }
        }
        void ClearText()
        {
            txtBarCode.SelectAll();
            txtMaterialCode.Text = String.Empty;
            txtMaterialName.Text = String.Empty;
            nudQuantity.Text = String.Empty;
            nudTotalMax.Text = String.Empty;
            cbNameWH.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            frmEmployessCode frmE = new frmEmployessCode();
            frmE.ShowDialog();
            string Employess = Kun_Static.EmployessCode;
            int test = EmployessDAO.Instance.TestEmployessByCode(Employess);
            if (test == -1)
            {
                LockControl();
                MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string barCode = txtBarCode.Text;
            string materialCode = txtMaterialCode.Text.ToUpper();
            string materialName = MaterialDAO.Instance.GetNameMaterialByCode(materialCode);
            DateTime date = dtpkDate.Value;
            float quantity = (float)Convert.ToDouble(nudQuantity.Text);
            float totalQuantity = (float)Convert.ToDouble(nudTotalMax.Text);
            string name = cbNameWH.Text;
            string Nature = MaterialDAO.Instance.NatureMaterial(materialCode);
            int IdWh = WarehouseMaterialDAO.Instance.IdWarehouseMaterial(name);
            int countBox = int.Parse(txtCountBox.Text);
            if (quantity == 0 || quantity > totalQuantity)
            {
                MessageBox.Show("bạn chưa điền số lượng nhập !\n\nHoặc số lượng nhập quá lớn".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkAdd == 0)
            {
                if (countBox <= 0)
                {
                    MessageBox.Show("bạn chưa điền số bao !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long IdInput = IventoryMaterialDAO.Instance.IdInputMaterial(materialCode, IdWh);
                long Id = IventoryMaterialDAO.Instance.IdReInputMaterial(IdInput);
                float reQuantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(IdInput);
                string msg = string.Format(" Mã nguyên liệu : {0}\n\n Tên nguyên liệu : {1}\n\n số lượng nhập : {2} kg\n\n vị trí : {3}", materialCode, materialName, quantity, name);
                if (MessageBox.Show(msg.ToUpper(), "Thông tin nhập nhựa".ToUpper(), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    // Load Form Check Mã Vạch
                    Kun_Static.CountBoxCycle = countBox;
                    Kun_Static.NameWhMaterial = name.ToUpper();
                    Kun_Static.CheckAdd = "TC";
                    frmCheckMacReCycle frm = new frmCheckMacReCycle();
                    frm.ShowDialog();
                    if (Kun_Static.CheckCycle != 0)
                    {
                        IventoryMaterialDAO.Instance.InsertReInputMaterial(IdInput, quantity, IdWh, 0, date, Employess);
                        IventoryMaterialDAO.Instance.IsertHistory(materialCode.ToUpper(), date, quantity, "Nhựa TC", Employess, name);
                        LoadControl();
                        this.Close();
                    }
                }
            }
            else
            {
                string stRohs = "YES";
                try
                {
                    IdWh = (cbNameWH.SelectedItem as WarehouseMaterial).Id;
                }
                catch
                {
                    MessageBox.Show("vị trí trống trên kho đã hết\n\n bạn hãy liên lạc với cấp trên để giải quyết".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string msg = string.Format(" Mã nguyên liệu : {0} \n\n Tên nguyên liệu : {1} \n\n Số lượng nhập : {2} \n\n Vị trí nhập : {3}".ToUpper(), materialCode, materialName, quantity, name);
                if (MessageBox.Show(msg, "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    IventoryMaterialDAO.Instance.InsertInputMaterial(materialCode, date, quantity, IdWh, 0, "TC", Employess, stRohs);
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWh, 2);
                    LoadControl();
                    this.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReCycling_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadBarcode();
            txtBarCode.Enabled = false;
            timer1.Stop();
        }

        private void cbNameWH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_checkWH == 0)
            {
                string materialCode = txtMaterialCode.Text;
                LoadTotal(materialCode);
            }
        }

        private void btnInputNomal_Click(object sender, EventArgs e)
        {
            checkAdd = 0;
            btnInputSpection.Enabled = true;
            btnInputNomal.Enabled = false;
            txtCountBox.Enabled = true;
            OpenControl();
            ClearText();
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
            checkAdd = 1;
            OpenControl();
            ClearText();
            btnInputSpection.Enabled = false;
            btnInputNomal.Enabled = true;
        }
    }
}