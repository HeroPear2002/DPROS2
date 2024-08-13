using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Report;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.WareHouseMaterial
{
    public partial class frmWarehouseMaterial : Form, IMessageFilter
    {

        TypeAssistant assistant;
        public frmWarehouseMaterial()
        {
            InitializeComponent();
            LoadStatusAsync();
            LoadControl();
            LoadGridView();
        }
        int _checkOut = 0;
        private System.Windows.Forms.Timer mTimer;
        int countCon = Kun_Static.CountCon;
        private int count;
        int timeLogout;
        void OutForm()
        {
            mTimer = new System.Windows.Forms.Timer();
            mTimer.Interval = 1000;
            mTimer.Tick += LogoutUser;
            mTimer.Enabled = true;
            count = countCon;
            Application.AddMessageFilter(this);
            timeLogout = countCon; // 15s logout - thay đổi thời gian logout ở đây 
            //label2.Text = timeLogout.ToString();
        }
        private const int WM_MOUSEMOVE = 0x0200;
        public bool PreFilterMessage(ref Message m)
        {
            // Monitor message for keyboard and mouse messages
            bool active = m.Msg == 0x100 || m.Msg == 0x101;  // WM_KEYDOWN/UP
            active = active || m.Msg == 0xA0 || m.Msg == 0x200;  // WM_(NC)MOUSEMOVE
            active = active || m.Msg == 0x10;    // WM_CLOSE, in case dialog closes
            if (active)
            {
                ActivedApp();
            }

            return false;
        }

        public void ActivedApp()
        {
            mTimer.Enabled = false;
            mTimer.Start();
        }

        private void LogoutUser(object sender, EventArgs e)
        {
            // No activity, logout user
            count--;
            // label2.Text = count.ToString();
            if (_checkOut == 0)
            {
                if (count == 0)
                {
                    mTimer.Enabled = false;
                    this.Close();
                }
            }
            else
            {
                count = countCon;
            }
        }
        public int styleInputMaterial = 0;
        string _employess = "";
        async void LoadStatusAsync()
        {
            await LoadWH();
            await LoadSatusWH();
        }
        async void LoadControl()
        {
            Kun_Static.EmployessCode = "";
            LoadAccount();
            LoadBlack();
            A();
            LoadNote();
            Khoa();
            LoadIventoryStyle();
            OutForm();
            await LoadWarning();
            dtpkDateInput.Enabled = false;
        }
        void LoadAccount()
        {
            int type = Kun_Static.accountDTO.Type;
            switch (type)
            {
                case 1:
                    {
                        btnPCCheck.Enabled = true;
                        btnSetup.Enabled = true;
                    }
                    break;
                case 2:
                    {
                        btnPCCheck.Enabled = true;
                    }
                    break;
                default:
                    {
                        btnPCCheck.Enabled = false;
                    }
                    break;
            }
        }
        void Khoa()
        {
            int type = Kun_Static.accountDTO.Type;
            if (type == 1 || type == 2)
            {
                btnInput.Enabled = true;
                btnWHInfor.Enabled = true;
            }
            else
            {
                btnWHInfor.Enabled = false;
                btnInput.Enabled = false;
            }
            btnReInput.Enabled = true;
            btnOutPut.Enabled = true;
            btnSaveInput.Enabled = false;
            btnSaveOutput.Enabled = false;
            txtBarCode.Enabled = false;

            txtBarCodeOut.Enabled = false;
            nudQuantiryOutput.Enabled = false;
        }
        #region LoadControl
        void LoadIventoryStyle()
        {
            GcDataStyle.DataSource = IventoryMaterialDAO.Instance.GetListIventoryStyle();
        }
        void LoadNameInput(int Weight)
        {
            cbNameInput.DataSource = WarehouseMaterialDAO.Instance.GetNameInput(Weight);
            cbNameInput.DisplayMember = "Name";
            cbNameInput.ValueMember = "Id";
        }
        void LoadNameInputTryTest()
        {
            cbNameInput.DataSource = WarehouseMaterialDAO.Instance.GetNameInputTryTest();
            cbNameInput.DisplayMember = "Name";
            cbNameInput.ValueMember = "Id";
        }
        void LoadNameOuput()
        {
            string[] array = txtBarCodeOut.Text.Split('&');
            string materialCode = array[0];
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode);
            cbNameOutput.DataSource = listI;
            cbNameOutput.ValueMember = "IdWh";
            cbNameOutput.DisplayMember = "Name";
        }
        void XoaTextNhap()
        {
            txtBarCode.Text = String.Empty;
            cbMaterialInput.Text = String.Empty;
            nudQuantityInput.Text = String.Empty;
            dtpkDateInput.Text = String.Empty;
            cbNameInput.Text = String.Empty;
        }
        void XoaTextXuat()
        {
            txtBarCodeOut.Text = String.Empty;
            dtpkDateOutput.Text = String.Empty;
            nudQuantiryOutput.Text = String.Empty;
            cbNameOutput.Text = String.Empty;
            txtTotal.Text = String.Empty;
        }
        public static async Task LoadWH()
        {
            await Task.Run(() =>
            {
                List<WarehouseMaterial> listW = WarehouseMaterialDAO.Instance.GetListWareHouse().Where(x => x.StatusWH == 0).ToList();
                if (listW.Count > 0)
                {
                    foreach (WarehouseMaterial item in listW)
                    {
                        WarehouseMaterialDAO.Instance.UpdateStatus((int)item.Id, 1);
                    }
                }

            });
        }
        public static async Task LoadSatusWH()
        {
            await Task.Run(() =>
            {
                List<IventoryMaterialDTO> listW = IventoryMaterialDAO.Instance.GetListIventory();
                foreach (IventoryMaterialDTO item in listW)
                {
                    string MaterialCode = item.MaterialCode;
                    int idWH = (int)item.IdWH;
                    string nature = MaterialDAO.Instance.NatureMaterial(MaterialCode);
                    if (nature == "Chắn sáng")
                    {
                        WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 8);
                    }
                    if (item.QuantityInput <= 0)
                    {
                        IventoryMaterialDAO.Instance.UpdateStatust(item.Id, 1);
                        WarehouseMaterialDAO.Instance.UpdateStatus((int)item.IdWH, 1);
                    }
                }
                List<ReIventoryMaterial> listW1 = IventoryMaterialDAO.Instance.GetListReMaterialByStatusInput1();
                foreach (ReIventoryMaterial item in listW1)
                {
                    int statusInput = IventoryMaterialDAO.Instance.StatusInput(item.IdInput);
                    if (statusInput == 1)
                    {
                        IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(item.Id, 1);
                    }
                }
            });
        }
        #endregion

        #region VẼ Layout Kho
        void A()
        {
            flpX.Controls.Clear();

            List<WarehouseMaterial> khoList = WarehouseMaterialDAO.Instance.GetListAllWareHouse();
            int i = 0;
            foreach (WarehouseMaterial item in khoList)
            {
                i++;
                Button btn = new Button() { Width = WarehouseMaterialDAO.TableWidth, Height = WarehouseMaterialDAO.TableHeight };
                if (i == 28 || ((i - 28) % 56) == 0)
                {
                    btn.Margin = new Padding(0, 0, 0, 5);
                }
                else if (i == 1 || ((i - 1) % 29 == 0))
                {
                    btn.Margin = new Padding(0, 0, 5, 0);
                }
                else
                {
                    btn.Margin = new Padding(0);
                }

                btn.Text = item.Name;
                FontFamily f = new FontFamily("Times New Roman");
                btn.Font = new Font(f, 7);
                btn.Click += btn_Click;
                btn.Tag = item;
                    switch (item.StatusWH)
                    {
                        case 1:
                            btn.BackColor = Color.White;
                            btn.Enabled = false;
                            break;
                        case 2:
                            if (item.Style.ToUpper() == "B")
                            {
                                btn.BackColor = Color.FromArgb(255, 217, 102);
                            }
                            else
                            {
                                btn.BackColor = Color.Blue;
                                btn.ForeColor = Color.White;
                            }
                            break;
                        case 3:
                            btn.BackColor = Color.Red;
                            break;
                        case 4:
                            btn.BackColor = Color.Yellow;
                            break;
                        case 5:
                            btn.BackColor = Color.Green;
                            break;
                        case 6:
                            btn.BackColor = Color.Black;
                            btn.ForeColor = Color.White;
                            break;
                        case 7:
                            btn.BackColor = Color.Pink;
                            btn.ForeColor = Color.Red;
                            break;
                        case 8:
                            btn.BackColor = Color.Purple;
                            btn.ForeColor = Color.White;
                            break;
                        case 9:
                            btn.BackColor = Color.White;
                            btn.ForeColor = Color.White;
                            btn.Text = "";
                            btn.FlatAppearance.BorderSize = 0;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.Enabled = false;
                            break;
                        case 10:
                            btn.BackColor = Color.Orange;
                            btn.ForeColor = Color.Black;
                            break;
                        default:
                            btn.BackColor = Color.White;
                            break;
                    }
                flpX.Controls.Add(btn);
            }
        }
        #endregion
        #region Load Trạng Thái
        void LoadNote()
        {
            float Total = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalAll().ToString());
            float TotalWhite = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalWhite().ToString());
            float TotalOK = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalOK().ToString());
            float TotalGreen = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalGreen().ToString());
            float TotalRed = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalRed().ToString());
            float TotalYellow = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalYellow().ToString());
            float totalBlack = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalBlack().ToString());
            float totalpink = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalPink().ToString());
            float totalPurple = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalPurple().ToString());
            float totalOrange = (float)Convert.ToDouble(WarehouseMaterialDAO.Instance.TotalOrange().ToString());
            lblTotal.Text = Total.ToString();
            float percenOK = (float)Math.Round((TotalOK / Total) * 100, 2);
            lblOK.Text = TotalOK.ToString() + " (" + (percenOK.ToString()) + "% )";
            lblWhite.Text = TotalWhite.ToString() + " (" + (Math.Round(((double)(TotalWhite / Total) * 100), 2)).ToString() + "% )";
            lblYellow.Text = TotalYellow.ToString() + " (" + (Math.Round(((double)(TotalYellow / Total) * 100), 2)).ToString() + "% )";
            lblPcCheck.Text = TotalGreen.ToString() + " (" + (Math.Round(((double)(TotalGreen / Total) * 100), 2)).ToString() + "% )";
            lblRed.Text = TotalRed.ToString() + " (" + (Math.Round(((double)(TotalRed / Total) * 100), 2)).ToString() + "% )";
            lblBlack.Text = totalBlack.ToString() + " (" + (Math.Round(((double)(totalBlack / Total) * 100), 2)).ToString() + "% )";
            lblPink.Text = totalpink.ToString() + " (" + (Math.Round(((double)(totalpink / Total) * 100), 2)).ToString() + "% )";
            lblPurple.Text = totalPurple.ToString() + " (" + (Math.Round(((double)(totalPurple / Total) * 100), 2)).ToString() + "% )";
            lbl10.Text = totalOrange.ToString() + " (" + (Math.Round(((double)(totalOrange / Total) * 100), 2)).ToString() + "% )";
        }
        void ActionOutput()
        {
            string[] array = txtBarCodeOut.Text.Split('&');
            string materialCode = array[0];
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode);
            int dem = 0;
            float a = 0;
            foreach (IventoryMaterialDTO item in listI)
            {
                dem++;
                if (dem == 1)
                {
                    a = item.QuantityInput + IventoryMaterialDAO.Instance.ReQuantitybyIdInput(item.Id) + IventoryMaterialDAO.Instance.ReQuantityHHbyId(item.Id);
                    txtTotal.Text = a.ToString();
                }
                else
                {
                    return;
                }
            }
        }
        public static async Task LoadWarning()
        {
            await Task.Run(() =>
            {
                DateTime today = DateTime.Now.Date;
                DateTime dateFc = today.AddDays(1 - today.Day);
                List<MaterialCodeDTO> listM = IventoryMaterialDAO.Instance.GetMaterialCode();
                List<IventoryMaterialDTO> listINew = new List<IventoryMaterialDTO>();
                List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventory();
                foreach (IventoryMaterialDTO item in listI)
                {
                    float Requantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(item.Id);
                    float RequantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(item.Id);
                    float iventory = item.QuantityInput + Requantity + RequantityHH;
                    if (iventory <= 0)
                    {
                        IventoryMaterialDAO.Instance.UpdateStatust(item.Id, 1);
                        IventoryMaterialDAO.Instance.UpdateStartReInputMaterial(item.Id, 1);
                        IventoryMaterialDAO.Instance.UpdateStartReInputHHByIdInput(item.Id, 1);
                        WarehouseMaterialDAO.Instance.UpdateStatus((int)item.IdWH, 1);
                    }
                    else
                    {
                        listINew.Add(new IventoryMaterialDTO(item.Id, item.IdWH, item.MaterialCode, item.DateInput, item.MaterialName, iventory, item.Name, item.StyleInput, item.Lot, item.Rosh));
                    }
                }
                foreach (MaterialCodeDTO item in listM)
                {
                    string MaterialCode = item.MaterialCode;
                    int yellow = 0;
                    FCMaterialDTO fCMaterialDTO = OrderDAO.Instance.GetItemFcMaterial(MaterialCode, dateFc);
                    if (fCMaterialDTO != null)
                    {
                        yellow = MaterialDAO.Instance.WarningYellow(MaterialCode)* fCMaterialDTO.Quantity / 100;
                    }
                    else
                    {
                        if(MaterialDAO.Instance.WarningYellow(MaterialCode) == 0)
                        {
                            yellow = MaterialDAO.Instance.WarningRed(MaterialCode);
                        }
                    }
                    string nature = MaterialDAO.Instance.NatureMaterial(MaterialCode);
                    string MaterialName = item.MaterialName;
                    float a = listINew.Where(z => z.MaterialCode == MaterialCode).Sum(x => x.QuantityInput);
                    float total = (float)Math.Round(a, 2);
                    int red = yellow / 2;
                    List<IventoryMaterialDTO> listAll = IventoryMaterialDAO.Instance.GetListIventoryByCode(MaterialCode);
                    List<IventoryMaterialDTO> listAll5 = IventoryMaterialDAO.Instance.GetListIventoryByCode5(MaterialCode);
                    int statust = IventoryMaterialDAO.Instance.StatusWHMaterial(MaterialCode);
                    if (statust != 5 && statust != 10)
                    {
                        if (total <= red)
                        {
                            foreach (IventoryMaterialDTO item1 in listAll)
                            {
                                int idWH = (int)item1.IdWH;
                                WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 3);
                            }
                        }
                        else if (total <= yellow && total > red)
                        {
                            foreach (IventoryMaterialDTO item1 in listAll)
                            {
                                int idWH = (int)item1.IdWH;
                                WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 4);
                            }
                        }
                        else
                        {
                            if (nature == "Chắn sáng")
                            {
                                foreach (IventoryMaterialDTO item1 in listAll)
                                {
                                    int idWH = (int)item1.IdWH;
                                    WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 8);
                                }
                            }
                            else
                            {
                                foreach (IventoryMaterialDTO item1 in listAll)
                                {
                                    int idWH = (int)item1.IdWH;
                                    WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 2);

                                }
                            }
                        }
                    }
                    else
                    {
                        if (total > yellow)
                        {
                            foreach (IventoryMaterialDTO item1 in listAll)
                            {
                                int idWH = (int)item1.IdWH;
                                WarehouseMaterialDAO.Instance.UpdateStatus(idWH, 2);
                            }
                        }
                    }
                }
            });
        }
        void LoadBlack()
        {
            DateTime today = DateTime.Now;
            List<IventoryMaterialDTO> listAll = IventoryMaterialDAO.Instance.GetListIventoryNot7();
            foreach (IventoryMaterialDTO item in listAll)
            {
                int dateIventory = (int)(today - item.DateInput).TotalDays;
                if (dateIventory >= 730)
                {
                    WarehouseMaterialDAO.Instance.UpdateStatus((int)item.IdWH, 6);
                }
            }

        }
        void LoadGridView()
        {
            List<IventoryMaterialDTO> listI = IventoryMaterialDAO.Instance.GetListIventory();
            List<IventoryMaterialDTO> listIN = new List<IventoryMaterialDTO>();
            foreach (IventoryMaterialDTO item in listI)
            {
                int status = WarehouseMaterialDAO.Instance.StatusWH(item.IdWH);
                if (status == 3)
                {
                    string materialCode = item.MaterialCode;
                    List<IventoryMaterialDTO> listM = IventoryMaterialDAO.Instance.GetListIventoryByCode(materialCode);
                    float sum = 0;
                    foreach (IventoryMaterialDTO jtem in listM)
                    {
                        float Requantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(item.Id);
                        float RequantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(item.Id);
                        sum += Requantity + RequantityHH + jtem.QuantityInput;
                    }
                    listIN.Add(new IventoryMaterialDTO(item.Id, item.IdWH, item.MaterialCode, item.DateInput, item.MaterialName, sum, item.Name,item.StyleInput, item.Lot, item.Rosh));
                }
            }
            GCData.DataSource = listIN;
        }
        #endregion
        #region ĐK Nhập Kho

        private void btnInput_Click(object sender, EventArgs e)
        {
            frmEmployessCode f = new frmEmployessCode();
            f.ShowDialog();
            _employess = Kun_Static.EmployessCode;
            int test = EmployessDAO.Instance.TestEmployessByCode(_employess);
            if (test == -1 && _employess.Trim().Length == 0)
            {
                Khoa();
                MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReInput.Enabled = false;
            btnSaveOutput.Enabled = false;
            btnSaveInput.Enabled = true;
            txtBarCode.Enabled = true;
            XoaTextNhap();
            styleInputMaterial = 0;
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check > 1)
            {
                dtpkDateInput.Enabled = true;
            }
        }
        private void btnTryTest_Click(object sender, EventArgs e)
        {
            frmEmployessCode f = new frmEmployessCode();
            f.ShowDialog();
             _employess = Kun_Static.EmployessCode;
            int test = EmployessDAO.Instance.TestEmployessByCode(_employess);
            if (test == -1 && _employess.Trim().Length == 0)
            {
                Khoa();
                MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            btnReInput.Enabled = false;
            btnSaveOutput.Enabled = false;
            btnSaveInput.Enabled = true;
            txtBarCode.Enabled = true;
            XoaTextNhap();
            LoadNameInputTryTest();
            styleInputMaterial = 1;
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check > 1)
            {
                dtpkDateInput.Enabled = true;
            }
        }
        private void btnReInput_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            frmReInputMaterial f = new frmReInputMaterial();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        #endregion
        #region ĐK Xuất Kho
        private void btnOutPut_Click(object sender, EventArgs e)
        {
            btnInput.Enabled = false;
            btnReInput.Enabled = false;
            btnSaveOutput.Enabled = true;
            txtBarCodeOut.Enabled = true;
            nudQuantiryOutput.Enabled = true;
            XoaTextXuat();
        }
        #endregion
        #region Input,Output
        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            List<BarcodeMaterial> listMaterial = new List<BarcodeMaterial>();
            string BarCode = txtBarCode.Text;
            string[] arrayList = BarCode.Split('&');
            cbMaterialInput.Text = arrayList[0];
            nudQuantityInput.Text = arrayList[1].ToString();
            string materialCode = cbMaterialInput.Text.ToUpper();
            string nameMaterial = MaterialDAO.Instance.GetNameMaterialByCode(materialCode);
            string Nature = MaterialDAO.Instance.NatureMaterial(materialCode);
            DateTime date = dtpkDateInput.Value;
            float quantity = (float)Math.Round(Convert.ToDouble(nudQuantityInput.Text), 2);
            string stRohs = "NO";
            string Rohs = MaterialDAO.Instance.RohsFile(materialCode);
            string typeInput = "";
            if (Rohs.Length > 0)
            {
                if (Rohs.ToUpper() == "NO NEED")
                {
                    stRohs = "NO NEED";
                }
                else
                {
                    stRohs = "YES";
                }
            }
            else
            {
                stRohs = "NO";
                if (MessageBox.Show(" Nguyên liệu này chưa có giấy chứng nhận RoHs !\n\n bạn vẫn muốn nhập kho ?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
            }
            int IdWh = 0;
            try
            {
                IdWh = (cbNameInput.SelectedItem as WarehouseMaterial).Id;
            }
            catch
            {
                MessageBox.Show("vị trí trống trên kho đã hết\n\n bạn hãy liên lạc với cấp trên để giải quyết".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name = cbNameInput.Text;
            int weightWH = WarehouseMaterialDAO.Instance.WeightWarehouseMaterial(IdWh);
            if (styleInputMaterial == 0)
            {
                typeInput = "Nhựa Tinh";
            }
            else
            {
                typeInput = "Try Test";
                if (quantity > 100 || quantity <= 0)
                {
                    MessageBox.Show("số lượng nhập phải lớn hơn 0 và nhỏ hơn 101".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            string Employess = _employess;
            if (nameMaterial.Length != 0)
            {
                string msg = string.Format(" Mã nguyên liệu : {0} \n\n Tên nguyên liệu : {1} \n\n Số lượng nhập : {2} \n\n Vị trí nhập : {3}".ToUpper(), materialCode, nameMaterial, quantity, name);
                if (MessageBox.Show(msg, "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    IventoryMaterialDAO.Instance.InsertInputMaterial(materialCode, date, quantity, IdWh, 0, typeInput, Employess, stRohs);
                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWh, 2);
                    IventoryMaterialDAO.Instance.IsertHistory(materialCode, date, quantity, typeInput, Employess, name);
                    List<IventoryMaterialDTO> listITC = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode, "TC");
                    List<IventoryMaterialDTO> listIHH = IventoryMaterialDAO.Instance.GetListOutputIventory(materialCode, "HH");
                    long MaxId = IventoryMaterialDAO.Instance.MaxIdInput();
                    if (listITC.Count > 0)
                    {
                        int ratio = MaterialDAO.Instance.RatioByCode(materialCode);
                        int quantityTCMax = (int)(Math.Floor((ratio * quantity) / 100));
                        float totalTC = IventoryMaterialDAO.Instance.TotalIventoryByCode(materialCode, "TC");
                        int quantityTC = 0;
                        int quantityTCAll = 0;
                        if (quantityTCMax >= totalTC)
                        {
                            quantityTC = (int)totalTC;
                            quantityTCAll = (int)totalTC;
                            string msgTC = string.Format(" bạn cần chuyển : {0} kg nhựa tái chế vào vị trí : N'{1}'".ToUpper(), quantityTCAll, name);
                            MessageBox.Show(msgTC, "Thông Báo", MessageBoxButtons.OK);
                            foreach (IventoryMaterialDTO item in listITC)
                            {
                                IventoryMaterialDAO.Instance.OutPutMaterial(item.Id, date, item.QuantityInput, Employess, "Xuất tới " + item.Name, "", "", "");
                            }
                        }
                        else
                        {
                            quantityTC = quantityTCMax;
                            quantityTCAll = quantityTCMax;
                            string msgTC = string.Format(" bạn cần chuyển : {0} kg nhựa tái chế vào vị trí : N'{1}'".ToUpper(), quantityTCAll, name);
                            MessageBox.Show(msgTC, "Thông Báo", MessageBoxButtons.OK);
                            foreach (IventoryMaterialDTO item in listITC)
                            {
                                int a = quantityTC - (int)item.QuantityInput;
                                if (a <= 0)
                                {
                                    IventoryMaterialDAO.Instance.OutPutMaterial(item.Id, date, quantityTC, Employess, "Xuất tới " + item.Name, "", "", "");
                                    break;
                                }
                                else
                                {
                                    IventoryMaterialDAO.Instance.OutPutMaterial(item.Id, date, item.QuantityInput, Employess, "Xuất tới " + item.Name, "", "", "");
                                    quantityTC = a;
                                }
                            }
                        }
                        IventoryMaterialDAO.Instance.InsertReInputMaterial(MaxId, quantityTCAll, IdWh, 0, date, Employess);
                    }
                    listMaterial.Add(new BarcodeMaterial(materialCode, nameMaterial, quantity, name, date.ToString(), Kun_Static.EmployessCode, Nature));
                    LoadControl();
                    AutoPrintMaterial report = new AutoPrintMaterial(listMaterial);
                    report.Print();
                }
            }
            else
            {
                MessageBox.Show("Mã nguyên liệu không đúng !".ToUpper());
            }
        }
        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            string barCode = txtBarCodeOut.Text;
            string[] array = barCode.Split('&');
            if (array.Count() != 7)
            {
                MessageBox.Show("mã vạch chỉ thị sản xuất không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string MaterialCode = array[0];
            string partCode = array[1];
            string machineCode = array[2];
            long idDirec = long.Parse(array[6]);
            string nature = MaterialDAO.Instance.NatureMaterial(MaterialCode);
            string MaterialName = MaterialDAO.Instance.GetNameMaterialByCode(MaterialCode);
            string name = cbNameOutput.Text;
            int IdWh = WarehouseMaterialDAO.Instance.IdWarehouseMaterial(name);
            long IdInput = IventoryMaterialDAO.Instance.IdIventory(MaterialCode);
            int statusWH = IventoryMaterialDAO.Instance.StatusWHMaterial(MaterialCode);
            string lot = IventoryMaterialDAO.Instance.GetLotByID(IdInput);
            List<ReIventoryMaterial> listRe = IventoryMaterialDAO.Instance.GetListReMaterial().Where(x => x.IdInput == IdInput).ToList();
            string rohs = MaterialDAO.Instance.RohsFile(MaterialCode);
            string custumer = PartDAO.Instance.CustomerByCode(partCode);
            if (custumer == "KYOCERA")
            {
                if (MessageBox.Show("Nguyên liệu này cần sử dụng máy trộn".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    return;
                }
            }
            if (lot.Length <= 0)
            {
                MessageBox.Show("Nguyên liệu này chưa có số Lot".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rohs.Length == 0)
            {
                MessageBox.Show("Nguyên liệu này chưa có rohs\n\nbạn hãy liên lạc với cấp trên?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime dateOut = dtpkDateOutput.Value;
            float quantity = 0;
            try
            {
                quantity = (float)Convert.ToDouble(nudQuantiryOutput.Text);
            }
            catch
            {
                quantity = 0;
            }
            ProductDirectives productDirectives = CTSXDAO.Instance.GetItem(idDirec);
            if (productDirectives == null)
            {
                MessageBox.Show("mã chỉ thị sản xuất không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (productDirectives.Status == 2)
            {
                MessageBox.Show("chỉ thị sản xuất đã bị khóa không thể xuất kho!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (((productDirectives.WeightOut + quantity - productDirectives.WeightUse) * 100) / productDirectives.WeightUse > 10)
            {
                MessageBox.Show("mã chỉ thị sản xuất đã xuất đủ số lượng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Kun_Static.IdPOMaterial = idDirec;
                frmReasonCTSX f = new frmReasonCTSX();
                f.ShowDialog();
                if(Kun_Static.CheckOutMateial == 0)
                {
                    LoadControl();
                    return;
                }
                //chỉ cảnh báo và gửi mail
            }
            string Employess = Kun_Static.EmployessCode;
            float totalQuantity = IventoryMaterialDAO.Instance.TotalIventoryByCodeByID(IdInput, MaterialCode);
            float totalQuantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(IdInput);
            float total = (float)Convert.ToDouble(txtTotal.Text);
            float totalreQuantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(IdInput);
            int ratioDefault = MaterialDAO.Instance.RatioByCode(MaterialCode);
            int ratio = (int)((totalreQuantity * 100 )/ totalQuantity);
            float hh = 0;  
            if ((totalQuantity * ratioDefault / 100) < totalreQuantity)
            {
                MessageBox.Show("Vị trí có số lượng tồn tái chế không đúng tỉ lệ".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (nature == "Chắn sáng")
            {
                if (MessageBox.Show("Bạn đang xuất nguyên liệu có tính chắn sáng".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    return;
                }
            }
            List<ReIventoryMaterialHH> listR = IventoryMaterialDAO.Instance.GetListMaterialHHByIdInput(IdInput);
            if (statusWH != 6)
            {
                List<OutputMaterial> listOut = new List<OutputMaterial>();
                if (quantity > 0)
                {
                    if (total >= quantity)
                    {
                        if (totalQuantityHH > 0)
                        {
                            float akun = quantity - totalQuantityHH;
                            if (akun <= 0)
                            {
                                string msg1 = string.Format(" Mã Nguyên liệu : {0}\n\n tên nguyên liệu : {1}\n\n số lượng xuất : {2} kg nhựa hỗn hợp \n\n ngày xuất : {3}\n\n Vị trí : {4}", MaterialCode, MaterialName, quantity, dateOut, name);
                                if (MessageBox.Show(msg1.ToUpper(), "Xuất Kho Nguyên Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                                {
                                    CTSXDAO.Instance.UpdateStatusCTSX(idDirec,1,Kun_Static.NoteCTSX);
                                    OutputMaterial outputMaterial = new OutputMaterial(idDirec,IdInput,MaterialCode, IdWh, 0, quantity, 0, 0, totalQuantityHH, 0,partCode,machineCode);
                                    Kun_Static.outputMaterial = outputMaterial;
                                    frmUseOutput f = new frmUseOutput();
                                    f.Refreshs += new EventHandler(btnUpdate_Click);
                                    f.ShowDialog();
                                    return;
                                }
                                else
                                {
                                    return;
                                }
                            }
                            else
                            {
                                hh = totalQuantityHH;
                                quantity = akun;
                            }
                        }
                        float quantityNew = 0;
                        float reQuantity = (ratio * quantity / 100);// chưa làm trong nhựa tái chế
                        if(reQuantity >= totalreQuantity)
                        {
                            reQuantity = totalreQuantity;
                        }
                        quantityNew = quantity - reQuantity;
                        int k = (int)quantityNew / 25;
                        if (quantityNew / 25 != k && ((25 * (k + 1)) < totalQuantity))
                        {
                            if (MessageBox.Show("bạn đang xuất lẻ bao nhựa \n\nbạn có muốn xuất chẵn số bao nhựa không ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                quantityNew = (25 * (k + 1));
                            }
                        }
                        float reQuantityMax = (ratioDefault * quantity / 100);
                        if(reQuantityMax >= totalreQuantity)
                        {
                            reQuantityMax = totalreQuantity;
                        }
                        string msg = string.Format(" Mã Nguyên liệu : {0}\n\n tên nguyên liệu : {1}\n\n số lượng xuất : {2} kg nhựa tinh \n\n Và : {5} kg nhựa tái chế \n\n Và : {6} kg nhựa Hỗn hợp \n\n ngày xuất : {3}\n\n Vị trí : {4}", MaterialCode, MaterialName, quantityNew, dateOut, name, reQuantity, hh);
                        if (MessageBox.Show(msg.ToUpper(), "Xuất Kho Nguyên Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            CTSXDAO.Instance.UpdateStatusCTSX(idDirec, 1, Kun_Static.NoteCTSX);
                            OutputMaterial outputMaterial = new OutputMaterial(idDirec,IdInput, MaterialCode, IdWh, quantityNew, hh, reQuantity, totalQuantity,totalQuantityHH, reQuantityMax, partCode, machineCode);
                            Kun_Static.outputMaterial = outputMaterial;
                            frmUseOutput f = new frmUseOutput();
                            f.Refreshs += new EventHandler(btnUpdate_Click);
                            f.ShowDialog();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Số lượng xuất quá lớn !".ToUpper());
                    }
                }
                else
                {
                    MessageBox.Show("bạn chưa điền số lượng cần xuất !".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("nguyên liệu này chưa được QC kiểm tra !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void Out()
        {
            //string barCode = txtBarCodeOut.Text;
            //string[] array = barCode.Split('&');
            //string MaterialCode = array[0];
            //string partCode = array[1];
            //string machineCode = array[2];
            //string nature = MaterialDAO.Instance.NatureMaterial(MaterialCode);
            //string MaterialName = MaterialDAO.Instance.GetNameMaterialByCode(MaterialCode);
            //string name = cbNameOutput.Text;
            //int IdWh = WarehouseMaterialDAO.Instance.IdWarehouseMaterial(name);
            //long IdInput = IventoryMaterialDAO.Instance.IdIventory(MaterialCode);
            //int statusWH = IventoryMaterialDAO.Instance.StatusWHMaterial(MaterialCode);
            //string lot = IventoryMaterialDAO.Instance.GetLotByID(IdInput);
            ////long IdReInput = IventoryMaterialDAO.Instance.IdReInputMaterial(IdInput);
            //List<ReIventoryMaterial> listRe = IventoryMaterialDAO.Instance.GetListReMaterial().Where(x => x.IdInput == IdInput).ToList();
            //string rohs = MaterialDAO.Instance.RohsFile(MaterialCode);
            //string custumer = PartDAO.Instance.CustomerByCode(partCode);
            //if (custumer == "KYOCERA")
            //{
            //    if (MessageBox.Show("Nguyên liệu này cần sử dụng máy trộn".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //}
            //if (lot.Length <= 0)
            //{
            //    MessageBox.Show("Nguyên liệu này chưa có số Lot".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (rohs.Length == 0)
            //{
            //    MessageBox.Show("Nguyên liệu này chưa có rohs\n\nbạn hãy liên lạc với cấp trên?".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //DateTime dateOut = dtpkDateOutput.Value;
            //float quantity = 0;
            //try
            //{
            //    quantity = (float)Convert.ToDouble(nudQuantiryOutput.Text);
            //}
            //catch
            //{
            //    quantity = 0;
            //}
            //string Employess = "";
            //string style = "Xuất Kho";
            //float totalQuantity = IventoryMaterialDAO.Instance.TotalIventoryByCodeByID(IdInput, MaterialCode);
            //float totalQuantityHH = IventoryMaterialDAO.Instance.ReQuantityHHbyId(IdInput);
            //float total = (float)Convert.ToDouble(txtTotal.Text);
            //float totalreQuantity = IventoryMaterialDAO.Instance.ReQuantitybyIdInput(IdInput);
            //int ratioDefault = MaterialDAO.Instance.RatioByCode(MaterialCode);
            //int ratio = (int)(totalreQuantity / totalQuantity) * 100;
            //float hh = 0;
            //if ((totalQuantity * ratioDefault / 100) < totalreQuantity)
            //{
            //    MessageBox.Show("Vị trí có số lượng tồn tái chế không đúng tỉ lệ".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //if (nature == "Chắn sáng")
            //{
            //    if (MessageBox.Show("Bạn đang xuất nguyên liệu có tính chắn sáng".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            //    {
            //        return;
            //    }
            //}
            //List<ReIventoryMaterialHH> listR = IventoryMaterialDAO.Instance.GetListMaterialHHByIdInput(IdInput);
            //if (statusWH != 6)
            //{
            //    if (quantity > 0)
            //    {
            //        if (total >= quantity)
            //        {
            //            if (totalQuantityHH > 0)
            //            {
            //                float akun = quantity - totalQuantityHH;
            //                if (akun <= 0)
            //                {
            //                    string msg1 = string.Format(" Mã Nguyên liệu : {0}\n\n tên nguyên liệu : {1}\n\n số lượng xuất : {2} kg nhựa hỗn hợp \n\n ngày xuất : {3}\n\n Vị trí : {4}", MaterialCode, MaterialName, quantity, dateOut, name);
            //                    if (MessageBox.Show(msg1.ToUpper(), "Xuất Kho Nguyên Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //                    {
            //                        foreach (ReIventoryMaterialHH item in listR)
            //                        {
            //                            long idInputHH = item.Id;
            //                            float Iventory = item.QuantityInputHH;
            //                            float b = quantity - Iventory;
            //                            if (b <= 0)
            //                            {
            //                                IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, quantity, Employess, partCode, machineCode, "Nhựa HH","","",0);
            //                                float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
            //                                if (IventoryHH == 0)
            //                                {
            //                                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
            //                                }
            //                                return;
            //                            }
            //                            else
            //                            {

            //                                //IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, Iventory, Employess, partCode, machineCode, "Nhựa HH");
            //                                float IventoryHH = IventoryMaterialDAO.Instance.IventoryMaterialHH(item.Id);
            //                                if (IventoryHH == 0)
            //                                {
            //                                    IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
            //                                }
            //                                quantity = b;
            //                            }
            //                        }
            //                        LoadControl();
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    hh = totalQuantityHH;
            //                    quantity = akun;
            //                }
            //            }
            //            float quantityNew = 0;
            //            float reQuantity = 0;
            //            if ((ratio * quantity / 100) >= totalreQuantity)
            //            {
            //                reQuantity = totalreQuantity;
            //            }
            //            else
            //            {
            //                reQuantity = (ratio * quantity / 100);// chưa làm trong nhựa tái chế
            //            }
            //            quantityNew = quantity - reQuantity;
            //            int k = (int)quantityNew / 25;
            //            if (quantityNew / 25 != k && ((25 * (k + 1)) < totalQuantity))
            //            {
            //                if (MessageBox.Show("bạn đang xuất lẻ bao nhựa \n\nbạn có muốn xuất chẵn số bao nhựa không ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //                {
            //                    quantityNew = (25 * (k + 1));
            //                }
            //            }
            //            string msg = string.Format(" Mã Nguyên liệu : {0}\n\n tên nguyên liệu : {1}\n\n số lượng xuất : {2} kg nhựa tinh \n\n Và : {5} kg nhựa tái chế \n\n Và : {6} kg nhựa Hỗn hợp \n\n ngày xuất : {3}\n\n Vị trí : {4}", MaterialCode, MaterialName, quantityNew, dateOut, name, reQuantity, hh);
            //            if (MessageBox.Show(msg.ToUpper(), "Xuất Kho Nguyên Liệu", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            //            {
            //                List<BillMaterial> listB = new List<BillMaterial>();
            //                if (totalQuantityHH > 0)
            //                {
            //                    foreach (ReIventoryMaterialHH item in listR)
            //                    {
            //                        long idInputHH = item.Id;
            //                        float IventoryHH = item.QuantityInputHH;
            //                        float b = totalQuantityHH - IventoryHH;
            //                        //IventoryMaterialDAO.Instance.InsertReOutputMaterialHH(idInputHH, dateOut, IventoryHH, Employess, partCode, machineCode, "Nhựa HH");
            //                        IventoryMaterialDAO.Instance.UpdateStartReInputHH(idInputHH, 1);
            //                    }
            //                }
            //                IventoryMaterialDAO.Instance.OutPutMaterial(IdInput, dateOut, quantityNew, Employess, style, partCode, machineCode, lot);
            //                float Iventory = IventoryMaterialDAO.Instance.IventoryMaterialById(IdInput);
            //                if (Iventory == 0)
            //                {
            //                    IventoryMaterialDAO.Instance.UpdateStatust(IdInput, 1);
            //                    WarehouseMaterialDAO.Instance.UpdateStatus(IdWh, 1);
            //                }
            //                if (listRe.Count >= 1)
            //                {
            //                    foreach (ReIventoryMaterial item in listRe)
            //                    {
            //                        long ReId = item.Id;
            //                        float ReIventory = item.Quantity;
            //                        float b = reQuantity - ReIventory;
            //                        if (b <= 0)
            //                        {
            //                            //IventoryMaterialDAO.Instance.ReOutPutMaterial(ReId, dateOut, reQuantity, Employess, partCode, machineCode, dateOut.ToString(), "Xuất nhựa TC","","",0);
            //                            float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
            //                            if (IventoryTC == 0)
            //                            {
            //                                IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
            //                            }
            //                            LoadControl();
            //                            return;
            //                        }
            //                        else
            //                        {

            //                            //IventoryMaterialDAO.Instance.ReOutPutMaterial(ReId, dateOut, ReIventory, Employess, partCode, machineCode, dateOut.ToString(), "Xuất nhựa TC");
            //                            float IventoryTC = IventoryMaterialDAO.Instance.ReQuantitybyId(ReId);
            //                            if (IventoryTC == 0)
            //                            {
            //                                IventoryMaterialDAO.Instance.UpdateStartByIdReInputMaterial(ReId, 1);
            //                            }
            //                            reQuantity = b;
            //                        }
            //                    }
            //                }
            //                string barCodeBill = (MaterialCode + "&" + Name + "&" + partCode + "&" + machineCode + "&" + quantity.ToString()).ToUpper();
            //                string dateOutput = dateOut.Day + "/" + dateOut.Month + "/" + dateOut.Year;
            //                LoadControl();
            //            }
            //        }
            //        else
            //        {
            //            MessageBox.Show("Số lượng xuất quá lớn !".ToUpper());
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("bạn chưa điền số lượng cần xuất !".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("nguyên liệu này chưa được QC kiểm tra !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
        #endregion
        #region SenMail
        void SenMail()
        {
        }
        #endregion
        private void btnSetup_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            frmSetupWH f = new frmSetupWH();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int idWh = ((sender as Button).Tag as WarehouseMaterial).Id;
            string name = ((sender as Button).Tag as WarehouseMaterial).Name;
            Kun_Static.IdWhMaterial = idWh;
            Kun_Static.NameWhMaterial = name;
            frmInforWhMaterial f = new frmInforWhMaterial();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void btnPCCheck_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            frmPCCheck f = new frmPCCheck();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        private void txtBarCodeOut_TextChanged(object sender, EventArgs e)
        {
            assistant = new TypeAssistant(350);
            assistant.Idled += LoaDataOutput;
            assistant.TextChanged();
        }
        private void btnOutputHH_Click(object sender, EventArgs e)
        {
            frmEmployessCode frm = new frmEmployessCode();
            frm.ShowDialog();
            string employess = Kun_Static.EmployessCode;
            int test = EmployessDAO.Instance.TestEmployessByCode(employess);
            if (test == -1)
            {
                Khoa();
                MessageBox.Show("mã nhân viên không đúng!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _checkOut = 1;
            frmOutputMaterialHH f = new frmOutputMaterialHH();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();

        }
        void LoaDataOutput(object sender, EventArgs e)
        {
            this.Invoke(
            new MethodInvoker(() =>
            {
                ActionOutput();
                LoadNameOuput();
            }));

        }
        public class TypeAssistant
        {
            public event EventHandler Idled = delegate { };
            public int WaitingMilliSeconds { get; set; }
            System.Threading.Timer waitingTimer;

            public TypeAssistant(int waitingMilliSeconds = 350)
            {
                WaitingMilliSeconds = waitingMilliSeconds;
                waitingTimer = new System.Threading.Timer(p =>
                {
                    Idled(this, EventArgs.Empty);
                });
            }
            public void TextChanged()
            {
                waitingTimer.Change(WaitingMilliSeconds, System.Threading.Timeout.Infinite);
            }
        }
        private void btnRecycling_Click(object sender, EventArgs e)
        {
            _checkOut = 1;
            frmReCycling f = new frmReCycling();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
        void TextChange()
        {
            string BarCode = txtBarCode.Text.ToUpper();
            if (BarCode.Length > 0)
            {
                try
                {
                    string[] arrayList = BarCode.Split('&');
                    cbMaterialInput.Text = arrayList[0];
                    nudQuantityInput.Text = arrayList[1].ToString();
                    int quantity = (int)Math.Round(Convert.ToDouble(nudQuantityInput.Text), 2);
                    LoadNameInput(quantity);
                }
                catch
                {
                    timer1.Stop();
                }
            }
            else
            {
                timer1.Stop();
                return;
            }

        }
        private void txtBarCode_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TextChange();
            timer1.Stop();
        }

        private void btnWHInfor_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _checkOut = 1;
            frmInformWH f = new frmInformWH();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle >= 0)
            {
                e.Appearance.ForeColor = Color.Red;
            }
        }
    }
  
}
