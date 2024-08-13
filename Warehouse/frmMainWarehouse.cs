using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DTO;
using WareHouse.WareHouseMaterial;
using WareHouse.Input;
using WareHouse.Statistic;
using WareHouse.QC;
using WareHouse.Product;
using System.Threading;
using DAO;
using System.Net.Mail;
using System.Net;
using System.Globalization;
using WareHouse.PO_and_Order;
using WareHouse.PCGridControl;
using WareHouse.Common;

namespace WareHouse
{
    public partial class frmMainWarehouse : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainWarehouse instance;

        public static frmMainWarehouse Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmMainWarehouse();
                }
                else
                {
                    instance.Activate();
                }
                return instance;
            }
            set => instance = value;
        }

        public frmMainWarehouse()
        {
            InitializeComponent();
            LoadThreadStatusQC();
            ChangeAccount();
            LoadWarehouse();
        }
        async void ChangeAccount()
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(4, Kun_Static.accountDTO.Type, user);
            if (check >= 1)
            {
                await SenMailQC();
            }

        }
        async void LoadWarehouse()
        {
            await LoadStatus();
        }
        async Task LoadStatus()
        {
            await Task.Run(() =>
            {
                List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
                foreach (IvenstoryDTO item in listI.Where(x => x.Iventory == 0).ToList())
                {
                    long id = item.Id;
                    int idWh = item.IdWareHouse;
                    IventoryPartDAO.Instance.UpdateInputPart(id, 1);
                    WareHouseDAO.Instance.UpdateStatusWH(idWh, 1);
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
                        EditHistoryDAO.Instance.Insert(DateTime.Now, Kun_Static.accountDTO.UserName, "Chuyển Id Input " + item.Id + " về 0 , Update vị trí về 4 , Xóa vị trí còn lại", item.Name);
                    }
                }
            });
        }
        #region CheckForm
        private bool CheckExistForm(string name)
        {
            bool check = false;
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    check = true;
                    break;
                }

            }
            return check;
        }
        private void ActivateChildForm(string name)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == name)
                {
                    frm.Close();
                    break;
                }
            }
        }

        #endregion
        #region Gửi Mail QC
       async void LoadThreadStatusQC()
        {
            await LoadStatusCheck();
        }
        static async Task SenMailQC()
        {
            await Task.Run(() =>
            {

                List<string> listMail = new List<string>();
                DateTime today = DateTime.Now;
                List<EquipmentDTO> lisE = EquipmentDAO.Instance.GetListEquipment();
                foreach (EquipmentDTO item in lisE)
                {
                    int statusCheck = EquipmentDAO.Instance.StatusCheck(item.EquipmentCode);
                    int statusMail = EquipmentDAO.Instance.StatusMail(item.EquipmentCode);
                    if (statusMail == 0 && (statusCheck == 1 || statusCheck == 2))
                    {
                        listMail.Add(item.EquipmentCode + ";");
                    }
                }
                #region gửi mail
                List<AccountDTO> listEmail = AccountDAO.Instance.GetAccount().Where(x => (x.Type == Kun_Static.accountDTO.Type || x.Type == 8) && x.EMail.Length > 5).ToList();
                if (listMail.Count > 0 && listEmail.Count > 0)
                {
                    string message = "Mã thiết bị đến thời kì hiệu chuẩn : ";
                    foreach (var item in listMail)
                    {
                        message += item +";";
                    }
                    string to = "";
                    string subject = "Hiểu chuẩn thiết bị phòng QC";
                    foreach (AccountDTO item in listEmail)
                    {
                        to += item.EMail +" ";
                       
                    }
                    SendEMail.SendGMail(to, subject, message);
                }
                #endregion

            });
        }
        async Task LoadStatusCheck()
        {
            await Task.Run(()=>{
                DateTime today = DateTime.Now;
                List<EquipmentDTO> lisE = EquipmentDAO.Instance.GetListEquipment();
                foreach (EquipmentDTO item in lisE)
                {
                    try
                    {
                        DateTime maxDate = DateTime.Parse(DataProvider.Instance.ExecuteScalar("SELECT MAX(DateIn) FROM dbo.HistoryEquipment WHERE EquipmentCode = N'" + item.EquipmentCode + "'").ToString());
                        System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                        EquipmentDAO.Instance.UpdateDatecheckEquipment(item.EquipmentCode, maxDate);
                        int cycle = EquipmentDAO.Instance.Cycle(item.EquipmentCode);
                        int day = cycle - ((int)(today - maxDate).TotalDays);
                        if (day <= 15)
                        {
                            EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 2);
                        }
                        else if (day <= 30)
                        {
                            EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 1);
                        }
                        else
                        {
                            EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 0);
                        }
                    }
                    catch
                    {
                        EquipmentDAO.Instance.UpdateStatusCheckEquipment(item.EquipmentCode, 3);
                    }
                }
            });           
        }
        #endregion
        #region Warehouse Material
        private void btnWHMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmWarehouseMaterial"))
            {
                frmWarehouseMaterial f = new frmWarehouseMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmWarehouseMaterial");
                frmWarehouseMaterial f = new frmWarehouseMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnIventoryMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmIventoryMaterial"))
            {
                frmIventoryMaterial f = new frmIventoryMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmIventoryMaterial");
                frmIventoryMaterial f = new frmIventoryMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInputMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmInputMaterial"))
            {
                frmInputMaterial f = new frmInputMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmInputMaterial");
                frmInputMaterial f = new frmInputMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnOutputMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (!CheckExistForm("frmOutputMaterial"))
            {
                frmOutputMaterial f = new frmOutputMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmOutputMaterial");
                frmOutputMaterial f = new frmOutputMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmDryingMaterial"))
            {
                frmHistoryDryingMaterial f = new frmHistoryDryingMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmDryingMaterial");
                frmHistoryDryingMaterial f = new frmHistoryDryingMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnReOutput_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmReOutputMaterial"))
            {
                frmReOutputMaterial f = new frmReOutputMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmReOutputMaterial");
                frmReOutputMaterial f = new frmReOutputMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnReInputMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmReInputMaterial"))
            {
                frmReInputStaticMaterial f = new frmReInputStaticMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmReOutputMaterial");
                frmReInputStaticMaterial f = new frmReInputStaticMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInputMaterialHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticReInputHH"))
            {
                frmStatisticReInputHH f = new frmStatisticReInputHH();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticReInputHH");
                frmStatisticReInputHH f = new frmStatisticReInputHH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnOutputMaterialHH_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticReOutPutHH"))
            {
                frmStatisticReOutPutHH f = new frmStatisticReOutPutHH();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticReOutPutHH");
                frmStatisticReOutPutHH f = new frmStatisticReOutPutHH();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion
        #region Warehouse Part
        private void btnInventoryDate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmIventoryByDate"))
            {
                frmIventoryByDate f = new frmIventoryByDate();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmIventoryByDate");
                frmIventoryByDate f = new frmIventoryByDate();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnWHPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmWareHousePart"))
            {
                frmWareHousePart f = new frmWareHousePart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmWareHousePart");
                frmWareHousePart f = new frmWareHousePart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnIventoryPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("fIventory"))
            {
                fIventory f = new fIventory();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("fIventory");
                fIventory f = new fIventory();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInputPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticInputPart"))
            {
                frmStatisticInputPart f = new frmStatisticInputPart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticInputPart");
                frmStatisticInputPart f = new frmStatisticInputPart();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnOutputPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticOutputPart"))
            {
                frmStatisticOutputPart f = new frmStatisticOutputPart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticOutputPart");
                frmStatisticOutputPart f = new frmStatisticOutputPart();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion
        #region QC
        private void btnQCPart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmQCCheck"))
            {
                frmQCCheck f = new frmQCCheck();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmQCCheck");
                frmQCCheck f = new frmQCCheck();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnQCMaterial_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmQCMaterial"))
            {
                frmQCMaterial f = new frmQCMaterial();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmQCMaterial");
                frmQCMaterial f = new frmQCMaterial();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmEquipment"))
            {
                frmEquipment f = new frmEquipment();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmEquipment");
                frmEquipment f = new frmEquipment();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHistoryEquipment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmHistotyEquipment"))
            {
                frmHistotyEquipment f = new frmHistotyEquipment();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistotyEquipment");
                frmHistotyEquipment f = new frmHistotyEquipment();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmHistoryQC"))
            {
                frmHistoryQC f = new frmHistoryQC();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryQC");
                frmHistoryQC f = new frmHistoryQC();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion
        #region Quản lý Linh Kiện Dự Bị
        private void btnProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmProduct"))
            {
                frmProduct f = new frmProduct();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmProduct");
                frmProduct f = new frmProduct();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnIventoryPro_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmIventoryPro"))
            {
                frmIventoryPro f = new frmIventoryPro();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmIventoryPro");
                frmIventoryPro f = new frmIventoryPro();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCuopont_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmOutputDetail"))
            {
                frmOutputDetail f = new frmOutputDetail();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmOutputDetail");
                frmOutputDetail f = new frmOutputDetail();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInputPro_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticInputPro"))
            {
                frmStatisticInputPro f = new frmStatisticInputPro();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticInputPro");
                frmStatisticInputPro f = new frmStatisticInputPro();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnOutpro_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmStatisticOutputProduct"))
            {
                frmStatisticOutputProduct f = new frmStatisticOutputProduct();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmStatisticOutputProduct");
                frmStatisticOutputProduct f = new frmStatisticOutputProduct();
                f.MdiParent = this;
                f.Show();
            }
        }



        #endregion

        private void btnBoxCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCheckMac"))
            {
                frmCheckMac f = new frmCheckMac();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCheckMac");
                frmCheckMac f = new frmCheckMac();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDry_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmHistoryDry"))
            {
                frmHistoryDry f = new frmHistoryDry();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryDry");
                frmHistoryDry f = new frmHistoryDry();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnCheckOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCheckOutput"))
            {
                frmCheckOutput f = new frmCheckOutput();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCheckOutput");
                frmCheckOutput f = new frmCheckOutput();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}