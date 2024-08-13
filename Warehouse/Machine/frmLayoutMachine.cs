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
using DAO;
using DTO;

namespace WareHouse.Machine
{
    public partial class frmLayoutMachine : DevExpress.XtraEditors.XtraForm
    {
        public frmLayoutMachine()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadRelationShipAsync();
            LoadLayout();
            btnUpdate.ItemClick += btnUpdate_Click;
            //OpenControl();
        }
        async void LoadRelationShipAsync()
        {
            await LoadMainRelation();
        }
        //void OpenControl()
        //{
        //    btnInfoMachine.Enabled = true;
        //    btnEveryDay.Enabled = true;
        //    btnMainten.Enabled = true;
        //    btnHistory.Enabled = true;
        //}
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
            // LoadStatusMachine();
        }
        private void btn_Click(object sender, EventArgs e)
        {
            string machineCode = ((sender as Button).Tag as MachineDTO).MachineCode;
            Kun_Static.MachineCode = machineCode;
            int status = MachineDAO.Instance.StatusMachineByCode(machineCode);
            int idCheck = Kun_Static.idCheck;
            if (idCheck == 1)
            {
                frmEveryday f = new frmEveryday();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else if (idCheck == 2)
            {
                frmEveryMainten f = new frmEveryMainten();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else if (idCheck == 3)
            {
                frmNewMachine f = new frmNewMachine();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else if (idCheck == 4)
            {
                frmHistoryEdit f = new frmHistoryEdit();
                f.LamMoi += new EventHandler(btnUpdate_Click);
                f.ShowDialog();
            }
            else
            {
                MessageBox.Show("bạn chưa chọn hạng mục cần kiểm tra rồi chọn mới chọn máy!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void LoadLayout()
        {
            flpLayout.Controls.Clear();
            List<MachineDTO> listM = MachineDAO.Instance.GetListMachineAll().Where(m => m.StatusMachine != 10).OrderByDescending(k => k.StatusMachine).ToList();
            int x = 100;
            int y = 30;
            foreach (MachineDTO item in listM)
            {
                Button btn = new Button() { Width = x, Height = y };
                btn.Margin = new Padding(0, 0, 3, 3);
                btn.Text = item.MachineCode;
                btn.Tag = item;
                btn.Click += btn_Click;
                btn.TextAlign = ContentAlignment.MiddleCenter;
                FontFamily f = new FontFamily("Times New Roman");
                int status = item.StatusMachine;
                btn.Font = new Font(f, 10);
                switch (status)
                {
                    case 0:
                        btn.BackColor = Color.White;

                        break;
                    case 1:
                        btn.BackColor = Color.White;

                        break;
                    case 2:
                        btn.BackColor = Color.Yellow;

                        break;
                    case 3:
                        btn.BackColor = Color.Orange;

                        break;
                    case 4:
                        btn.BackColor = Color.Gray;

                        break;
                    case 5:
                        btn.BackColor = Color.Red;
                        break;
                    case 6:
                        btn.BackColor = Color.Black;
                        btn.ForeColor = Color.White;
                        break;
                    case 7:
                        btn.BackColor = Color.GreenYellow;
                        break;
                    case 8:
                        btn.BackColor = Color.Purple;
                        break;
                    default:
                        btn.BackColor = Color.Orange;
                        break;
                }
                flpLayout.Controls.Add(btn);
            }
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
                            List<HistoryDeviceDTO> listH = MachineDAO.Instance.GetListHistoryDeviceShort(date1, date2, item.MachineCode);

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
        void LoadStatusMachine()
        {
            DateTime today = DateTime.Now;
            DateTime date1 = today.Date;
            DateTime date2 = today.AddHours(24);
            MachineDTO machineDTO = MachineDAO.Instance.GetMachine(Kun_Static.MachineCode);
            int hour = today.Hour;
            int statusMachine = machineDTO.StatusMachine;
            string Note = "";
            List<RelationShipDTO> listRe = MachineDAO.Instance.GetListRelationShipAll(machineDTO.MachineCode);
            List<RelationShipDTO> listReShort = listRe.Where(x => x.TimerKH == 24).ToList();
            List<RelationShipDTO> listReLong = listRe.Where(x => x.TimerKH > 24).ToList();
            List<HistoryDeviceDTO> listHD = MachineDAO.Instance.GetListHistoryDeviceALL(date1, date2, machineDTO.MachineCode);
            List<HistoryDeviceDTO> listHDShort = listHD.Where(x => x.Timer == 24).ToList();
            if (listRe.Count == 0)
            {
                statusMachine = 6;
            }
            else if (listHD.Count == 0 && (machineDTO.StatusMachine < 4 || machineDTO.StatusMachine > 6))
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
            else if (listHD.Count < listHDShort.Count)
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
                            if (machineDTO.Device != 1)
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
                    List<HistoryDeviceDTO> listH = MachineDAO.Instance.GetListHistoryDeviceShort(date1, date2, Kun_Static.MachineCode);
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
            MachineDAO.Instance.UpdateStatusMay(machineDTO.MachineCode, statusMachine, Note);

        }

        private void btnEveryDay_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.idCheck = 1;
            btnInfoMachine.Enabled = true;
            btnEveryDay.Enabled = false; ;
            btnMainten.Enabled = true;
            btnHistory.Enabled = true;
            frmScanQRCode f = new frmScanQRCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnMainten_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.idCheck = 2;
            btnInfoMachine.Enabled = true;
            btnEveryDay.Enabled = true;
            btnMainten.Enabled = false;
            btnHistory.Enabled = true;
            frmScanQRCode f = new frmScanQRCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnHistory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.idCheck = 4;
            btnInfoMachine.Enabled = true;
            btnEveryDay.Enabled = true;
            btnMainten.Enabled = true;
            btnHistory.Enabled = false;
        }

        private void btnInfoMachine_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kun_Static.idCheck = 3;
            btnEveryDay.Enabled = true;
            btnMainten.Enabled = true;
            btnHistory.Enabled = true;
            btnInfoMachine.Enabled = false;
        }
    }
}