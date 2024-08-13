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
using WareHouse.MachineRelationShip;
using DTO;
using WareHouse.Machine;
using WareHouse.Weather;
using WareHouse.DataMachine;
using System.Threading;
using DAO;

namespace WareHouse
{
    public partial class frmMainDevices : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private static frmMainDevices instance;

        public static frmMainDevices Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new frmMainDevices();
                }
                else
                {
                    instance.Activate();
                }
                return instance;
            }
            set => instance = value;
        }

        public frmMainDevices()
        {
            InitializeComponent();
            LoadMachine();
        }
        public class MainId
        {
            public static int testHistory;
            public static int DeviceId;
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
        async void LoadMachine()
        {
            await LoadMainRelation();
        }
        public static async Task LoadMainRelation()
        {
            await Task.Run(() =>
            {
                DateTime today = DateTime.Now;
                DateTime date1 = today.Date;
                DateTime date2 = today.AddHours(24);
                List<MachineDTO> listMachine = MachineDAO.Instance.GetListMachineAll().Where(x => x.StatusMachine != 10).ToList();
                int hour = today.Hour;
                foreach (MachineDTO item in listMachine)
                {
                    int statusMachine = item.StatusMachine;
                    string Note = "";
                    List<RelationShipDTO> listRe = MachineDAO.Instance.GetListRelationShipAll(item.MachineCode);
                    List<RelationShipDTO> listReShort = listRe.Where(x => x.TimerKH == 24).ToList();
                    List<RelationShipDTO> listReLong = listRe.Where(x => x.TimerKH > 24).ToList();
                    List<HistoryDeviceDTO> listHD = MachineDAO.Instance.GetListHistoryDeviceALL(date1, date2, item.MachineCode);
                    List<HistoryDeviceDTO> listHDShort = listHD.Where(x => x.Timer == 24).ToList();
                    if (listRe.Count == 0)
                    {
                        statusMachine = 6;
                    }
                    else if (listHD.Count == 0 && listReShort.Count > 0 && (item.StatusMachine < 4 || item.StatusMachine > 6))
                    {
                        if (hour >= 12)
                        {
                            statusMachine = 3;
                        }
                        else if (hour >= 8)
                        {
                            statusMachine = 2;
                        }
                    }
                    else if (listHD.Count < listReShort.Count)
                    {
                        if (hour >= 12)
                        {
                            statusMachine = 3;
                        }
                        else if (hour >= 8)
                        {
                            statusMachine = 2;
                        }
                    }
                    else
                    {
                        if (statusMachine < 4)
                        {
                            foreach (RelationShipDTO jtem in listReLong)
                            {
                                long IdRelationShip = jtem.Id;
                                long IdCategory = jtem.IdCategory;
                                int Timecategory = jtem.TimerKH;
                                DateTime? DateCheck = MachineDAO.Instance.MaxDateByIdRelation(IdRelationShip);
                                if (DateCheck == null)
                                {
                                    MachineDAO.Instance.UpdateStatusRelationShip(IdRelationShip, 1);
                                }
                                else
                                {
                                    TimeSpan Hieu = (today - Convert.ToDateTime(DateCheck));
                                    int h = (int)Hieu.TotalHours;
                                    if (item.Device != 1)
                                    {
                                        MachineDAO.Instance.UpdateTimeRelationShip(IdRelationShip, h);
                                    }
                                    float TimeTT = MachineDAO.Instance.TimeTTByID(IdRelationShip);
                                    if (TimeTT / Timecategory >= 0.85)
                                    {
                                        MachineDAO.Instance.UpdateStatusRelationShip(IdRelationShip, 1);
                                        if (statusMachine <= 3)
                                        {
                                            if (hour >= 12)
                                            {
                                                statusMachine = 8;
                                            }
                                            else if (hour >= 8)
                                            {
                                                statusMachine = 7;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (statusMachine < 2)
                                        {
                                            statusMachine = 1;
                                        }
                                        MachineDAO.Instance.UpdateStatusRelationShip(IdRelationShip, 0);
                                    }
                                }
                            }
                        }
                        else if (statusMachine >= 4 && statusMachine <= 6)
                        {
                            List<HistoryDeviceDTO> listH = MachineDAO.Instance.GetListHistoryDeviceShort(date1, date2, item.MachineCode);
                            int sts = 1;
                            if (listH.Count > 0)
                            {
                                foreach (HistoryDeviceDTO ktem in listH)
                                {
                                    if (sts < ktem.StatusHD)
                                    {
                                        sts = ktem.StatusHD;
                                    }
                                }
                                statusMachine = sts;
                            }
                        }
                        else if (listRe.Count == 0)
                        {
                            statusMachine = 6;
                        }
                    }
                    MachineDAO.Instance.UpdateStatusMay(item.MachineCode, statusMachine, Note);
                }
            });
        }
        #region Quản Lý Thiết Bị
        private void btnCategoryShort_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCategoryShort"))
            {
                frmCategoryShort f = new frmCategoryShort();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCategoryShort");
                frmCategoryShort f = new frmCategoryShort();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDevice_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListDevice"))
            {
                frmListDevice f = new frmListDevice();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListDevice");
                frmListDevice f = new frmListDevice();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCategoryLong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCategoryLong"))
            {
                frmCategoryLong f = new frmCategoryLong();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCategoryLong");
                frmCategoryLong f = new frmCategoryLong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnRelationShipLong_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmRelationShipLong"))
            {
                frmRelationShipLong f = new frmRelationShipLong();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmRelationShipLong");
                frmRelationShipLong f = new frmRelationShipLong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnRelationShipShort_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmRelationShipShort"))
            {
                frmRelationShipShort f = new frmRelationShipShort();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmRelationShipShort");
                frmRelationShipShort f = new frmRelationShipShort();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHistoryLong_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainId.testHistory = 1;
            if (!CheckExistForm("frmHistoryMainten"))
            {
                frmHistoryMainten f = new frmHistoryMainten();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryMainten");
                frmHistoryMainten f = new frmHistoryMainten();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnHistoryShort_ItemClick(object sender, ItemClickEventArgs e)
        {
            MainId.testHistory = 0;
            if (!CheckExistForm("frmHistoryMainten"))
            {
                frmHistoryMainten f = new frmHistoryMainten();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryMainten");
                frmHistoryMainten f = new frmHistoryMainten();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnEditHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmHistoryEdit"))
            {
                frmHistoryEdit f = new frmHistoryEdit();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmHistoryEdit");
                frmHistoryEdit f = new frmHistoryEdit();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDeviceChart_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmChartCategoryShort"))
            {
                frmChartCategoryShort f = new frmChartCategoryShort();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmChartCategoryShort");
                frmChartCategoryShort f = new frmChartCategoryShort();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnCategoryInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCategoryInfor"))
            {
                frmCategoryInfor f = new frmCategoryInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCategoryInfor");
                frmCategoryInfor f = new frmCategoryInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnListAllMachine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmListMachineByDevice"))
            {
                frmListMachineByDevice f = new frmListMachineByDevice();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmListMachineByDevice");
                frmListMachineByDevice f = new frmListMachineByDevice();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        #region Nhà Xưởng
        private void btnWeather_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmWeather"))
            {
                frmWeather f = new frmWeather();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmWeather");
                frmWeather f = new frmWeather();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChartWeather_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmWeatherChart"))
            {
                frmWeatherChart f = new frmWeatherChart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmWeatherChart");
                frmWeatherChart f = new frmWeatherChart();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        #region Dữ Liệu Máy

        private void btnCatagoryDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmCategoryDefault"))
            {
                frmCategoryDefault f = new frmCategoryDefault();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmCategoryDefault");
                frmCategoryDefault f = new frmCategoryDefault();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSetupDefault_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmSetupDefault"))
            {
                frmSetupDefault f = new frmSetupDefault();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmSetupDefault");
                frmSetupDefault f = new frmSetupDefault();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDataCheck_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmDataCheck"))
            {
                frmDataCheck f = new frmDataCheck();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmDataCheck");
                frmDataCheck f = new frmDataCheck();
                f.MdiParent = this;
                f.Show();
            }
        }
        private void btnHistoryData_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmDataMachine"))
            {
                frmDataMachine f = new frmDataMachine();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmDataMachine");
                frmDataMachine f = new frmDataMachine();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnChartData_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmDataChart"))
            {
                frmDataChart f = new frmDataChart();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmDataChart");
                frmDataChart f = new frmDataChart();
                f.MdiParent = this;
                f.Show();
            }
        }
        #endregion

        private void ribbon_SelectedPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (Ribbon.SelectedPage == rbpMachine)
                {
                    if (!CheckExistForm("frmLayoutMachine"))
                    {
                        frmLayoutMachine f = new frmLayoutMachine();
                        f.MdiParent = this;
                        f.Show();
                    }
                    else
                    {
                        ActivateChildForm("frmLayoutMachine");
                        frmLayoutMachine f = new frmLayoutMachine();
                        f.MdiParent = this;
                        f.Show();
                    }
                }

            }
            catch (Exception ae)
            {
                MessageBox.Show(ae.Message);
            }
        }

        private void btnMachineInfor_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmMachineInfor"))
            {
                frmMachineInfor f = new frmMachineInfor();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmMachineInfor");
                frmMachineInfor f = new frmMachineInfor();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLayoutMachine_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!CheckExistForm("frmLayoutMachine"))
            {
                frmLayoutMachine f = new frmLayoutMachine();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                ActivateChildForm("frmLayoutMachine");
                frmLayoutMachine f = new frmLayoutMachine();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}