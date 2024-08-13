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
            LoadUpdate();
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
            cbName.Enabled = false;
            NhapLe = false;
            lblNote.Text = "bạn đang ở chế độ nhập nguyên pallet \n\nbạn hãy kiểm tra số thùng trước khi Lưu".ToUpper();
        }
        void LoadUpdate()
        {
            List<IvenstoryDTO> listI1 = IventoryPartDAO.Instance.GetListIventoryPartStatus(DateTime.Now);
            foreach (IvenstoryDTO item in listI1)
            {
                long id = item.Id;
                int iventory = IventoryPartDAO.Instance.IventoryById(id);
                if (iventory > 0)
                {
                    IventoryPartDAO.Instance.UpdateInputPart(item.Id, 0);
                    WareHouseDAO.Instance.UpdateStatusWH(item.IdWareHouse, 4);
                    IventoryPartDAO.Instance.DeleteNInputPart(item.Id, item.IdWareHouse);
                }
            }
        }
        #endregion
        #region Event
        private void btnAddPCS_Click(object sender, EventArgs e)
        {
            txtBarCode.Enabled = true;
            cbName.Enabled = false;
            NhapLe = true;
            nudQuantity.Enabled = true;
            lblNote.Text = "bạn đang ở chế độ nhập lẻ pallet \n\nbạn hãy điền số lượng thùng cần nhập".ToUpper();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            LoadUpdate();
            List<CouponInputPart> listC = new List<CouponInputPart>();
            string barCode = txtBarCode.Text.ToUpper();
            string[] arrayList = barCode.Split('&');
            int leng = arrayList.Count();
            int quantityInput = 0;
            if (barCode.Length != 0)
            {
                #region barcode
                if (leng == 4)
                {
                    cbPart.Text = arrayList[0];
                    cbMachine.Text = arrayList[1];
                    cbMold.Text = arrayList[2];
                    cbFactoryCode.Text = arrayList[3];
                }
                else if (leng == 5)
                {
                    cbPart.Text = arrayList[0];
                    cbMachine.Text = arrayList[1];
                    cbMold.Text = arrayList[2];
                    cbFactoryCode.Text = "D1";
                }
                else
                {
                    cbPart.Text = arrayList[3];
                    cbMachine.Text = arrayList[9];
                    cbFactoryCode.Text = arrayList[10];
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
                string employess = Kun_Static.EmployessCode;
                string partCode = cbPart.Text;
                string molNumber = cbMold.Text;
                string machineCode = cbMachine.Text;
                string factoryCode = cbFactoryCode.Text;
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
                string nameWH = WareHouseDAO.Instance.NameWarehouse(idWarehouse);
                int testFactory = FactoryDAO.Instance.TestFactoryByFacCode(factoryCode);
                if (PartDAO.Instance.TestPartCode(partCode) == -1)
                {
                    MessageBox.Show("Mã linh kiện không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (testFactory == -1)
                {
                    MessageBox.Show("Mã nhà máy không đúng !\n\nhoặc mác sản phẩm không dúng phiên bản mới".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int statusWH = WareHouseDAO.Instance.StatusWarehouseById(idWarehouse);
                if (statusWH > 1)
                {
                    MessageBox.Show("Có lỗi khi nhập hệ thống bạn hãy restart lại máy !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string dateTest = (dateManufacturi.Day.ToString() + "/" + dateManufacturi.Month.ToString() + "/" + dateManufacturi.Year.ToString());
                string msg = string.Format(" mã linh kiện : {0} \n\n ngày sản xuất : {1} \n\n hình thức nhập : {2} \n\n số  lượng nhập : {3} pcs \n\n vị trí nhập : {4}", partCode, dateManufacturi, styleInput, quantityInput, cbName.Text);
                if (quantityInput > 0)
                {
                    if (MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        string BoxCode = BoxDAO.Instance.BoxCodeByPart(partCode);
                        int countShot = quantityInput / Cav;
                        int countbox = (int)Math.Ceiling((float)quantityInput / (float)quantityPart);
                        int test = IventoryPartDAO.Instance.TestIdWarehouse(idWarehouse);
                        string noteQC = "";
                        int isNG = PartDAO.Instance.TestPartLock(partCode, molNumber, machineCode);
                        string yellow = "O";
                        int sttWh = 4;
                        if (isNG != -1)
                        {
                            sttWh = PartDAO.Instance.sttWhPartLock(isNG);
                            yellow = PartDAO.Instance.YellowPartLock(isNG);
                            noteQC = PartDAO.Instance.NotePartLock(isNG);
                        }
                        if (test == -1)
                        {
                            IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateManufacturi, 0, "Nhập Lại", "", notePC, notePC, factoryCode);
                            WareHouseDAO.Instance.UpdateStatusWH(idWarehouse, sttWh);
                            WareHouseDAO.Instance.UpdateYellowWH(idWarehouse, yellow);
                            if (leng == 5)
                            {
                                MoldDAO.Instance.UpdateShotByCode(MoldCode, (countShot + ShotTT), (countShot + TotalShot));
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldCode, 0);
                            }
                        }
                        string qrCode = partCode + "&" + machineCode + "&" + molNumber + "&" + factoryCode + "&" + lot;
                        MessageBox.Show("nhập kho thành công !".ToUpper());
                        listC.Add(new CouponInputPart(partCode, dateInput, dateManufacturi, nameWH,factoryCode,qrCode));
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
