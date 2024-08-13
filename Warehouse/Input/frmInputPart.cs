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
    public partial class frmInputPart : Form
    {
        public frmInputPart()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;

        public string notePC = "";
        public string noteQC = "";
        public int testU = 0;
        public int testH = 0;
        public int quant = 0;
        #region Control()
        void LoadControl()
        {
            this.AcceptButton = btnSave;
            btnAddPCS.Enabled = true;
            LoadBoxAdd();
            XoaText();
            LoadUpdate();
            timer1.Stop();
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
            quant = 0;
            lblNote.Text = "bạn đang ở chế độ nhập nguyên pallet \n\nbạn hãy kiểm tra số thùng trước khi Lưu".ToUpper();
        }
       async void LoadUpdate()
        {
            await TaskAsyncUpdate();
        }
        async Task TaskAsyncUpdate()
        {
            await Task.Run(() => {
                List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
                foreach (IvenstoryDTO item in listI)
                {
                    long id = item.Id;
                    int idWh = item.IdWareHouse;
                    int iventory = item.Iventory;
                    int status = WareHouseDAO.Instance.StatusWarehouseById(idWh);
                    if (iventory <= 0)
                    {
                        IventoryPartDAO.Instance.UpdateInputPart(id, 1);
                        WareHouseDAO.Instance.UpdateStatusWH(idWh, 1);
                    }
                    if (status <= 1)
                    {
                        IventoryPartDAO.Instance.UpdateInputPart(id, 1);
                    }
                }
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
            });
        }
        #endregion
        #region Event
        private void btnAddPCS_Click(object sender, EventArgs e)
        {
            txtBarCode.Enabled = true;
            cbName.Enabled = true;
            quant = 1;
            nudQuantity.Enabled = true;
            lblNote.Text = "bạn đang ở chế độ nhập lẻ pallet theo số thùng \n\nbạn hãy điền số lượng thùng cần nhập".ToUpper();
        }
        private void btnAddPcsPart_Click(object sender, EventArgs e)
        {
            txtBarCode.Enabled = true;
            cbName.Enabled = true;
            quant = 2;
            nudQuantity.Enabled = true;
            lblNote.Text = "bạn đang ở chế độ nhập lẻ pallet theo số lượng lk \n\nbạn hãy điền số lượng linh kiện cần nhập".ToUpper();
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
                if (leng == 4)
                {
                    cbPart.Text = arrayList[0];
                    cbMachine.Text = arrayList[1];
                    cbMold.Text = arrayList[2];
                    cbFactoryCode.Text = arrayList[3];

                }
                else
                {
                    cbPart.Text = arrayList[3];
                    cbMachine.Text = arrayList[9];
                    string moldSTR = arrayList[8];
                    cbFactoryCode.Text = arrayList[10];
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
                    WareHouseDTO wareHouseDTO = WareHouseDAO.Instance.GetItem(idWarehouse);
                    if (wareHouseDTO.Status > 1)
                    {
                        MessageBox.Show("Có lỗi khi nhập kho \n\nbạn hãy thoát phần mềm rồi nhập lại!".ToUpper(), "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("kho đã hết vị trí trống \n\nbạn hãy liên lạc với cấp trên để giải quyết !".ToUpper(), "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string nameWH = WareHouseDAO.Instance.NameWarehouse(idWarehouse);
                int testMachine = MachineDAO.Instance.TestMachineByCode(machineCode);
                if(PartDAO.Instance.TestPartCode(partCode) == -1)
                {
                    MessageBox.Show("Mã linh kiện không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (testMachine == -1)
                {
                    MessageBox.Show("Mã máy không đúng !\n\nhoặc bạn chọn sai hình thức nhập".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int testFactory = FactoryDAO.Instance.TestFactoryByFacCode(factoryCode);
                if (testFactory == -1)
                {
                    MessageBox.Show("Mã nhà máy không đúng !\n\nhoặc mác cài không đúng phiên bản mới".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DateTime dateManufacturi = dtpDate.Value;
                long IdSX = TDSXDAO.Instance.IdSXByALL(machineCode, partCode, molNumber);
                long IdTT = TDSXDAO.Instance.IDTableTTByDate(IdSX, dateInput);
                string dateTest = (dateManufacturi.Day.ToString() + "/" + dateManufacturi.Month.ToString() + "/" + dateManufacturi.Year.ToString());
                #region Số lượng nhập
                if (quant == 1)
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
                string msg = string.Format(" mã linh kiện : {0} \n\n ngày sản xuất : {1} \n\n hình thức nhập : {2} \n\n số  lượng nhập : {3} pcs \n\n vị trí nhập : {4}".ToUpper(), partCode, dateManufacturi, styleInput, quantityInput, cbName.Text);
                if (quantityInput > 0)
                {
                    if (MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {

                        string BoxCode = BoxDAO.Instance.BoxCodeByPart(partCode);
                        int countShot = quantityInput / Cav;
                        int countbox = (int)Math.Ceiling((float)quantityInput / (float)quantityPart);
                        int test = IventoryPartDAO.Instance.TestIdWarehouse(idWarehouse);
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
                            if (BoxCode != null)
                            {
                                IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateManufacturi, 0, "Nhập Mới", lot, noteQC, notePC, factoryCode);
                                WareHouseDAO.Instance.UpdateStatusWH(idWarehouse, sttWh);
                                WareHouseDAO.Instance.UpdateYellowWH(idWarehouse, yellow);
                                MoldDAO.Instance.UpdateShotByCode(MoldCode, (countShot + ShotTT), (countShot + TotalShot));
                                MoldDAO.Instance.UpdateWainMoldInfor(MoldCode, 0);
                                #region TT Sản xuất
                                if (IdSX != -1)
                                {
                                    if (IdTT == -1)
                                    {

                                    }
                                    else
                                    {
                                        int quantityTT = TDSXDAO.Instance.QuantityTT(IdTT);
                                        DateTime maxTime = TDSXDAO.Instance.MaxTimeTT(IdTT);
                                        if (maxTime >= dateInput)
                                        {
                                            TDSXDAO.Instance.UpdateTableTT(IdTT, dateInput, quantityTT + quantityInput);
                                        }
                                        else
                                        {
                                            TDSXDAO.Instance.UpdateTableTT(IdTT, maxTime, quantityTT + quantityInput);
                                        }
                                    }
                                }
                                #endregion
                                #region Hộp 
                                if (BoxCode.Length > 0)
                                {
                                    int iven = BoxDAO.Instance.IventoryBoxList(BoxCode);
                                    BoxDAO.Instance.UpdateIventoryListBox(BoxCode, (iven - countbox));
                                }
                                #endregion
                                #region Máy đúc
                                float TimeTT = (countShot * TimeSX) / 3600;
                                foreach (RelationShipDTO item in listRelationShip)
                                {
                                    long Id = item.Id;
                                    int TimeRe = MachineDAO.Instance.TimeTTByID(Id);
                                    MachineDAO.Instance.UpdateTimeRelationShip(Id, TimeTT + TimeRe);
                                }
                                #endregion
                            }
                            else
                            {
                                MessageBox.Show("chưa có mã thùng cho linh kiện này !".ToUpper(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        string qrCode = partCode + "&" + machineCode + "&" + molNumber + "&" + factoryCode + "&" + lot;
                        MessageBox.Show("nhập kho thành công !".ToUpper());
                        listC.Add(new CouponInputPart(partCode, dateInput, dateManufacturi, nameWH, factoryCode, qrCode));
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
        private void btnHU_Click(object sender, EventArgs e)
        {
            if (testU == 0)
            {
                testU = 1;
                lblU.Text = "Pallet này là HÀNG ÙN";
                noteQC = "Hàng Ùn";
                notePC = "Hàng Ùn";
            }
            else
            {
                testU = 0;
                lblU.Text = "Pallet này Không là HÀNG ÙN";
                noteQC = "";
            }
        }

        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadTextBox();
            LoadWarehouse();
            timer1.Stop();
        }
        void LoadTextBox()
        {
            string barCode = txtBarCode.Text.ToUpper();
            string[] arrayList = barCode.Split('&');
            int leng = arrayList.Count();
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
                else
                {
                    cbPart.Text = arrayList[3];
                    cbMachine.Text = arrayList[9];
                    string moldSTR = arrayList[8];
                    cbFactoryCode.Text = arrayList[10];
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
            }
        }
    }
}
