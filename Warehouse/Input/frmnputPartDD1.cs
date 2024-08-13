using DevExpress.XtraReports.UI;
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
using WareHouse.Report;

namespace WareHouse.Input
{
    public partial class frmReInputPart : Form
    {
        public frmReInputPart()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        public bool NhapLe = false;
        public string notePC = "";
        #region Control()
        void LoadControl()
        {
            this.AcceptButton = btnSave;
            btnAddPCS.Enabled = true;
            LoadBoxAdd();
            XoaText();
        }
        void LoadWarehouse()
        {
            string partCode = cbPart.Text;
            int height = PartDAO.Instance.HeightPartByCode(partCode);
            cbName.DataSource = WareHouseDAO.Instance.GetNameInput(height);
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "Id";
        }
        void XoaText()
        {
            txtBarCode.Text = String.Empty;
            cbMachine.Text = String.Empty;
            cbMold.Text = String.Empty;
            cbName.Text = String.Empty;
            cbPart.Text = String.Empty;
        }
        void LoadBoxAdd()
        {
            txtBarCode.Enabled = true;
            cbName.Enabled = true;
            NhapLe = false;
            lblNote.Text = "bạn đang ở chế độ nhập nguyên pallet \n\nbạn hãy kiểm tra số thùng trước khi Lưu".ToUpper();
        }
        #endregion
        #region Event
        private void btnAddPCS_Click(object sender, EventArgs e)
        {
            txtBarCode.Enabled = true;
            cbName.Enabled = true;
            NhapLe = true;
            nudQuantity.Enabled = true;
            lblNote.Text = "bạn đang ở chế độ nhập lẻ pallet \n\nbạn hãy điền số lượng thùng cần nhập".ToUpper();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<CouponInputPart> listC = new List<CouponInputPart>();
            string barCode = txtBarCode.Text.ToUpper();
            string[] arrayList = barCode.Split('&');
            int leng = arrayList.Count();
            int quantityInput = 0;
            if (barCode.Length != 0)
            {
                #region barcode
                if (leng == 3)
                {
                    cbPart.Text = arrayList[0];
                    cbMachine.Text = arrayList[1];
                    cbMold.Text = arrayList[2];
                }
                else
                {
                    cbPart.Text = arrayList[3];
                    cbMachine.Text = arrayList[9];
                    string moldSTR = arrayList[8];
                    bool a = moldSTR.Contains("-");
                    if (a == true)
                    {
                        string[] array = moldSTR.Split('-');
                        cbMold.Text = array[0];
                    }
                    else
                    {
                        cbMold.Text = moldSTR;
                    }
                }
                #endregion
                DateTime today = DateTime.Now;
                DateTime dateInput = today;
                string employess = frmEmployessCode.EmployessCode.employessCode;
                string partCode = cbPart.Text;
                string molNumber = cbMold.Text;
                string machineCode = cbMachine.Text;
                int quantityPart = PartDAO.Instance.CountPartByCode(partCode);
                int quantityBox = PartDAO.Instance.CountBoxByCode(partCode);
                int idWarehouse = 0;
                try
                {
                    idWarehouse = (cbName.SelectedItem as WareHouseDTO).Id;
                }
                catch
                {
                    MessageBox.Show("kho đã hết vị trí trống \n\nbạn hãy liên lạc với cấp trên để giải quyết !".ToUpper(), "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                long IdOutput = IventoryMaterialDAO.Instance.MaxIDOutput(partCode, machineCode);
                string lot = IventoryMaterialDAO.Instance.GetLotOutput(IdOutput);
                string styleInput = "";
                int Cav = PartDAO.Instance.CavityByCode(partCode);
                string MoldCode = MacInforDAO.Instance.MoldCodeByMac(partCode, machineCode, molNumber);
                int ShotTT = MoldDAO.Instance.ShoTTByCode(MoldCode);
                int TotalShot = MoldDAO.Instance.TotalShotByCode(MoldCode);
                float TimeSX = PartDAO.Instance.CycleTimeByCode(partCode);
                List<RelationShipDTO> listRelationShip = MachineDAO.Instance.GetListRelationShipLong(machineCode);
                #region Số lượng nhập
                if (NhapLe == true)
                {
                    quantityInput = ((int)nudQuantity.Value) * quantityPart;
                    styleInput = "Nhập lẻ";
                }
                else
                {
                    quantityInput = quantityPart * quantityBox;
                    styleInput = "Nhập pallet nguyên";
                }
                #endregion
                DateTime dateManufacturi = dtpDate.Value;
                string msg = string.Format(" mã linh kiện : {0} \n\n ngày sản xuất : {1} \n\n hình thức nhập : {2} \n\n số  lượng nhập : {3} pcs \n\n vị trí nhập : {4}", partCode, dateManufacturi, styleInput, quantityInput, cbName.Text);
                if (quantityInput > 0)
                {
                    if (MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string BoxCode = BoxDAO.Instance.BoxCodeByPart(partCode);
                        int countShot = quantityInput / Cav;
                        int countbox = (int)Math.Ceiling((float)quantityInput / (float)quantityPart);
                        int test = IventoryPartDAO.Instance.TestIdWarehouse(idWarehouse);
                        int isNG = PartDAO.Instance.TestPartLock(partCode,molNumber);
                        if (test == -1)
                        {
                            IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateManufacturi, 0, "Nhập Lại", "", notePC, notePC);
                            if (isNG == 1)
                            {
                                WareHouseDAO.Instance.UpdateStatusWH(idWarehouse, 3);
                            }
                        }
                        MessageBox.Show("nhập kho thành công !".ToUpper());
                        listC.Add(new CouponInputPart(partCode, dateInput, dateManufacturi, cbName.Text));
                        rpCouponPart report = new rpCouponPart();
                        report.DataSource = listC;
                        report.Print();
                        this.Close();
                        LoadControl();
                    }
                }
                else
                {
                    MessageBox.Show("bạn chưa điền số lượng thùng nhập \n\nbạn hãy kiểm tra lại !".ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("mã vạch không đúng \n\nbạn hãy kiểm tra lại !".ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void cbPart_TextChanged(object sender, EventArgs e)
        {
            LoadWarehouse();//có thể thay thế 
        }

        private void frmInputPart_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}
