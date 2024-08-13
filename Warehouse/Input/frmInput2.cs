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
    public partial class frmInput2 : Form
    {
        public frmInput2()
        {
            InitializeComponent();
            LoadControl();
        }
        public EventHandler LamMoi;
        public bool NhapLe = false;
        public string notePC = "Thùng tạm";
        public int testU = 0;
        #region Control()
        void LoadControl()
        {
            LoadUpdate();
            XoaText();
            lblNote.Text = "bạn hãy điền số lượng linh kiện cần nhập".ToUpper();
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
        void LoadWarehouse()
        {
            cbName.DataSource = WareHouseDAO.Instance.GetNameInput2();
            cbName.DisplayMember = "Name";
            cbName.ValueMember = "Id";
        }
        void XoaText()
        {
            txtBarCode.Text = String.Empty;
            cbMachine.Text = String.Empty;
            cbMold.Text = String.Empty;

            cbPart.Text = String.Empty;
        }
        #endregion
        #region Event

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
                    string moldSTR = arrayList[2];
                    cbFactoryCode.Text = arrayList[3];
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
                long IdOutput = IventoryMaterialDAO.Instance.MaxIDOutput(partCode, machineCode);
                string lotMaterial = IventoryMaterialDAO.Instance.GetLotOutput(IdOutput);
              
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
                int testMachine = MachineDAO.Instance.TestMachineByCode(machineCode);
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
                int Cav = PartDAO.Instance.CavityByCode(partCode);
                string MoldCode = MacInforDAO.Instance.MoldCodeByMac(partCode, machineCode, molNumber);
                int ShotTT = MoldDAO.Instance.ShoTTByCode(MoldCode);
                int TotalShot = MoldDAO.Instance.TotalShotByCode(MoldCode);
                float TimeSX = PartDAO.Instance.CycleTimeByCode(partCode);
                
                List<RelationShipDTO> listRelationShip = MachineDAO.Instance.GetListRelationShipLong(machineCode);
                long IdSX = TDSXDAO.Instance.IdSXByALL(machineCode, partCode, molNumber);
                long IdTT = TDSXDAO.Instance.IDTableTTByDate(IdSX, dateInput);
                quantityInput = ((int)nudQuantity.Value);
                DateTime dateManufacturi = dtpDate.Value;
                int statusWH = WareHouseDAO.Instance.StatusWarehouseById(idWarehouse);
                if(statusWH  > 1)
                {
                    MessageBox.Show("Có lỗi khi nhập hệ thống bạn hãy restart lại máy !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string msg = string.Format(" mã linh kiện : {0} \n\n ngày sản xuất : {1} \n\n hình thức nhập : {2} \n\n số  lượng nhập : {3} pcs \n\n vị trí nhập : {4}", partCode, dateManufacturi, "Nhập thùng tạm", quantityInput, cbName.Text);
                if (quantityInput > 0)
                {
                    if (MessageBox.Show(msg.ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
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
                        int countbox = (int)Math.Ceiling((float)quantityInput / (float)quantityPart);
                        int countShot = quantityInput / Cav;
                        IventoryPartDAO.Instance.InputPart(partCode, dateInput, quantityInput, employess, molNumber, machineCode, idWarehouse, dateManufacturi, 0, "Nhập Mới", lotMaterial, notePC, notePC,factoryCode);
                        WareHouseDAO.Instance.UpdateStatusWH(idWarehouse, sttWh);
                        WareHouseDAO.Instance.UpdateYellowWH(idWarehouse, yellow);
                        int totalTime = (int)((quantityInput / Cav) * TimeSX);
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
                        MoldDAO.Instance.UpdateShotByCode(MoldCode, (countShot + ShotTT), (countShot + TotalShot));
                        #region Máy đúc
                        float TimeTT = (countShot * TimeSX) / 3600;
                        foreach (RelationShipDTO item in listRelationShip)
                        {
                            long Id = item.Id;
                            int TimeRe = MachineDAO.Instance.TimeTTByID(Id);
                            MachineDAO.Instance.UpdateTimeRelationShip(Id, TimeTT + TimeRe);
                        }
                        #endregion
                        string qrCode = partCode + "&" + machineCode + "&" + molNumber + "&" +factoryCode +"&"+ lotMaterial;
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
                    MessageBox.Show("bạn chưa điền số lượng linh kiện cần nhập \n\nbạn hãy kiểm tra lại !".ToUpper());
                }
            }
            else
            {
                MessageBox.Show("mã vạch không đúng \n\nbạn hãy kiểm tra lại !".ToUpper());
            }
        }
        #endregion

        private void frmInput2_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
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

        private void cbPart_TextChanged(object sender, EventArgs e)
        {
           LoadWarehouse();//có thể thay thế 
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
                    string moldSTR = arrayList[2];
                    cbFactoryCode.Text = arrayList[3];
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
