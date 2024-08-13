using DevExpress.XtraReports.Serialization;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Employess;
using WareHouse.Model;
using WareHouse.PCGridControl;

namespace WareHouse.PC
{
    public partial class frmKHNL : Form
    {
        public frmKHNL()
        {
            InitializeComponent();
            ChangeACC();
            LoadControl();
            timer1.Start();
        }
        void ChangeACC()
        {
            int type = Kun_Static.accountDTO.Type;
             if (type == 1)
            {
                btnStart.Enabled = true;
          
                btnStop.Enabled = true;
                btnAddResource.Enabled = true;
            }
        }
        void LoadControl()
        {
            ChangeACC();
            InitAppointments();
            InitResoucer();
            InitLable();
            schedulerControl1.Start = dtpkToday.Value;
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.TimelineView.CellsAutoHeightOptions.Enabled = false;
            schedulerControl1.Appearance.Appointment.ForeColor = Color.Black;
            schedulerControl1.Appearance.Appointment.FontSizeDelta = 1;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.OptionsCustomization.AllowAppointmentConflicts = AppointmentConflictsMode.Allowed;
            schedulerControl1.DayView.ShowMoreButtons = false;
            schedulerControl1.DayView.ShowMoreButtonsOnEachColumn = false;
            schedulerControl1.TimelineView.ShowMoreButtons = false;
            schedulerControl1.TimelineView.Scales.Clear();
            schedulerControl1.DateNavigationBar.Visible = false;
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleDay());
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleHour());
            schedulerControl1.TimelineView.Scales[1].Width = 60;
            schedulerControl1.TimelineView.SelectionBar.Visible = false;
            schedulerControl1.TimelineView.TimelineScrollBarVisible = false;
            schedulerControl1.TimelineView.ResourcesPerPage = 12;
            schedulerControl1.TimelineView.ShowResourceHeaders = false;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.AppointmentHeight = 20;
            //schedulerControl1.TimelineView.AppointmentDisplayOptions.AppointmentAutoHeight = true;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StretchAppointments = true;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.ShowClippedText = true;
            schedulerControl1.Appearance.Appointment.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            schedulerControl1.TimelineView.NavigationButtonVisibility = NavigationButtonVisibility.Never;
            UpdateControls();
            LoadConfirm();
        }
        #region InitialDataLoad
        void InitAppointments()
        {
            this.schedulerDataStorage1.Appointments.Mappings.Start = "StartTime";
            this.schedulerDataStorage1.Appointments.Mappings.End = "EndTime";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "OwnerId";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerDataStorage1.Appointments.Mappings.Type = "EventType";
            this.schedulerDataStorage1.Appointments.Mappings.PercentComplete = "PercentComplete";
            //this.schedulerDataStorage1.Appointments.Mappings.PercentComplete = "PercentComplete";
            CustomEventList eventList = new CustomEventList();
            GenerateEvents(eventList);
            this.schedulerDataStorage1.Appointments.DataSource = eventList;

        }
        void InitResoucer()
        {
            List<Resources>listR = ResoucesDAO.Instance.GetListResource();
            this.schedulerDataStorage1.Resources.Mappings.Id = "Id";
            this.schedulerDataStorage1.Resources.Mappings.Caption = "Description";
            this.schedulerDataStorage1.Resources.Mappings.ParentId = "ParentId";
            this.schedulerDataStorage1.Resources.DataSource = listR.OrderBy(x =>x.Description);
        }
        void InitLable()
        {
            this.schedulerDataStorage1.Labels.Mappings.Id = "Id";
            this.schedulerDataStorage1.Labels.Mappings.Color = "Color";
            this.schedulerDataStorage1.Labels.Mappings.DisplayName = "DisplayName";
            this.schedulerDataStorage1.Labels.Mappings.MenuCaption = "MenuCaption";
            this.schedulerDataStorage1.Labels.DataSource = TDSXDAO.Instance.GetListLable();
        }
        void GenerateEvents(CustomEventList eventList)
        {
            SplashScreenManager.ShowForm(this, typeof(frmWaitForm), true, true, false);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            DateTime timeNow = DateTime.Now;
            DateTime today = dtpkToday.Value.Date.AddSeconds(2);
            DateTime date1 = today.AddDays(-3);
            DateTime date2 = today.AddDays(2);
            int i = 0;
            List<TableSX> listK = TDSXDAO.Instance.GetListTableSX(date1,date2);
            foreach (TableSX item in listK)
            {
                i++;
                string MoldCode = MacInforDAO.Instance.MoldCodeByMac(item.PartCode, item.MachineCode, item.MoldNumber);
                int totalShot = MoldDAO.Instance.TotalShotByCode(MoldCode);
                string akun = "";
                if (totalShot > 1000000)
                {
                    akun = "&" + totalShot.ToString();
                }
                eventList.Add(CreateEvent(eventList, item.PartCode + "&" + item.MoldNumber + "&" + item.MachineCode + "&" + item.Quantity.ToString() + akun, item.IdResource, 1, item.ColorSX, item.StartTime, item.EndTime, "100%", "", item.Id));

                List<TableTT> listTT = TDSXDAO.Instance.GetListTableTT(item.Id);
                foreach (TableTT item1 in listTT)
                {
                    string part = TDSXDAO.Instance.PartCodeByID(item.Id);
                    string mold = TDSXDAO.Instance.MoldNumberByID(item.Id);
                    string machine = TDSXDAO.Instance.MachineByID(item.Id);
                    string des = (Math.Round(((double)item1.Quantity / item.Quantity), 2) * 100).ToString() + "%";
                    if (item1.ConfirmTT == 1)
                    {
                        eventList.Add(CreateEvent(eventList, part + "-" + mold + "-" + machine + "-" + item1.Quantity.ToString() + "-" + des, item1.IdResource, 1, item1.ColorTT, item1.StartTime, item1.EndTime, des, "", item1.Id));
                    }
                    else
                    {
                        eventList.Add(CreateEvent(eventList, "Dừng máy", item1.IdResource, 1, item1.ColorTT, item1.StartTime, item1.EndTime, item1.Note, "", item1.Id));
                    }
                }

                List<TableDK> listDK = TDSXDAO.Instance.GetListTableDK(item.Id);

                foreach (TableDK item1 in listDK)
                {
                    int color = item1.ColorDK;
                    if (timeNow > item1.StartTime && item1.ConfirmDK == 1 && item1.ColorDK != 10)
                    {
                        color = 1;
                    }
                    string part = TDSXDAO.Instance.PartCodeByID(item.Id);
                    string mold = TDSXDAO.Instance.MoldNumberByID(item.Id);
                    string machine = TDSXDAO.Instance.MachineByID(item.Id);
                    string note = " - " + item1.Note;
                    eventList.Add(CreateEvent(eventList, part + "-" + mold + note, item1.IdResource, 1, color, item1.StartTime, item1.EndTime, "", "", item1.Id));
                }

                List<TableXH> listXH = TDSXDAO.Instance.GetListTableXH(item.Id);
                foreach (TableXH item1 in listXH)
                {
                    int color = item1.ColorXH;
                    if (timeNow > item1.WarnTime && item1.ConfirmXH == 1 && item1.ColorXH != 10)
                    {
                        color = 1;
                    }
                    string part = TDSXDAO.Instance.PartCodeByID(item.Id);
                    string mold = TDSXDAO.Instance.MoldNumberByID(item.Id);
                    string machine = TDSXDAO.Instance.MachineByID(item.Id);
                    string note = " - " + item1.Note;

                    eventList.Add(CreateEvent(eventList, part + "-" + mold + note, item1.IdResource, 1, color, item1.StartTime, item1.EndTime, "", "", item1.Id));
                }
            }
            SplashScreenManager.CloseForm(false);
        }
        CustomEvent CreateEvent(CustomEventList eventList, string subject, object resourceId, int status, int label, DateTime starttime, DateTime endtime, string loca, string des, long id)
        {
            CustomEvent apt = new CustomEvent(eventList);
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            apt.StartTime = starttime;
            apt.EndTime = endtime;
            apt.Status = status;
            apt.Label = label;
            apt.Location = loca;
            apt.Description = des;
            apt.PercentComplete = id;
            return apt;
        }
        #endregion
        void LoadConfirm()
        {
            DateTime today = DateTime.Now;
            GCData2.DataSource = TDSXDAO.Instance.GetListWarnTimeTableXH(today);
            GCData1.DataSource = TDSXDAO.Instance.GetTableDKByDate(today);
        }
        #region Update Controls
        private void UpdateControls()
        {
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.GroupType = SchedulerGroupType.Date;
        }
        #endregion
        #region #CustomDrawAppointment
        private void schedulerControl1_CustomDrawAppointment(object sender, CustomDrawObjectEventArgs e)
        {
            TimeLineAppointmentViewInfo tlvi = e.ObjectInfo as TimeLineAppointmentViewInfo;
            // This code works only for the Timeline View.
            if (tlvi != null)
            {
                Rectangle r = e.Bounds;
                r.X += 3;
                r.Y += 3;
                string[] s = tlvi.Appointment.Subject.Split('/');

                for (int i = 0; i < s.Length; i++)
                {
                    e.Cache.DrawString(s[i], tlvi.Appearance.Font, new SolidBrush(Color.Black),
 r, StringFormat.GenericDefault);
                    SizeF shift = e.Graphics.MeasureString(s[i] + " ", tlvi.Appearance.Font);
                    r.X += (int)shift.Width;
                }

                e.Handled = true;
            }
        }
        #endregion #CustomDrawAppointment

        #region #CustomDrawAppointmentBackground
        private void schedulerControl1_CustomDrawAppointmentBackground(object sender, CustomDrawObjectEventArgs e)
        {
            DevExpress.XtraScheduler.Drawing.AppointmentViewInfo aptViewInfo = e.ObjectInfo
 as DevExpress.XtraScheduler.Drawing.AppointmentViewInfo;
            if (aptViewInfo == null)
                return;
            if (aptViewInfo.Selected)
            {
                Rectangle r = e.Bounds;
                Brush brRect = aptViewInfo.Status.GetBrush();
                e.Graphics.FillRectangle(brRect, r);
                e.Graphics.DrawRectangle(new Pen(Color.Blue, 2), r);
                e.Handled = true;
            }
        }
        #endregion #CustomDrawAppointmentBackground

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 300000;
            LoadControl();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadConfirm();
        }
        private void schedulerControl1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.Menu.Id == SchedulerMenuItemId.DefaultMenu)
            {

                // Disable the "New Recurring Appointment" menu item.
                e.Menu.DisableMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringAppointment);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoDate);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.GotoToday);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleEnable);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.TimeScaleVisible);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewAllDayEvent);

                // Hide the "New Recurring Event" menu item.
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.NewRecurringEvent);

                // Enable the "Go To Today" menu item.
                //e.Menu.EnableMenuItem(SchedulerMenuItemId.GotoToday);

                // Find the "New Appointment" menu item and rename it.
                SchedulerMenuItem item = e.Menu.GetMenuItemById(SchedulerMenuItemId.NewAppointment);
                if (item != null) item.Caption = "&Băt đầu sản xuất";

                SchedulerPopupMenu itemChangeViewTo = e.Menu.GetPopupMenuById(SchedulerMenuItemId.SwitchViewMenu);
                itemChangeViewTo.Visible = false;

                //SchedulerMenuItem gotoday = e.Menu.GetMenuItemById(SchedulerMenuItemId.GotoToday);
                //if (gotoday != null) gotoday.Caption = "&Ngày hôm này";

                //SchedulerMenuItem gotodate = e.Menu.GetMenuItemById(SchedulerMenuItemId.GotoDate);
                //if (gotodate != null) gotodate.Caption = "&Ngày khác";
            }
            // Check if it's the appointment menu.
            if (e.Menu.Id == SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.LabelSubMenu);
                e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
            }
        }
        static Font fnt = new Font("Times New Roman", 10f);

        private void btnAddResource_Click(object sender, EventArgs e)
        {
            frmResources f = new frmResources();
            f.ShowDialog();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(3, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmTableSX f = new frmTableSX();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            frmEndSX f = new frmEndSX();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(3, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmStopANDStartMachine f = new frmStopANDStartMachine();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnDK_Click(object sender, EventArgs e)
        {
            frmEndDK f = new frmEndDK();
            f.Lammoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnXH_Click(object sender, EventArgs e)
        {
            frmEndXH f = new frmEndXH();
            f.Lammoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void schedulerControl1_CustomizeAppointmentFlyout(object sender, CustomizeAppointmentFlyoutEventArgs e)
        {
            //e.ShowSubject = true;
            //e.Subject = String.Format("{0} - {1:f}", e.Subject, e.Location);
            //e.SubjectAppearance.Font = fnt;
            //e.ShowReminder = false;
            //e.ShowLocation = false;
            //e.ShowEndDate = true;
            //e.ShowStartDate = true;
            //e.ShowStatus = false;
            //e.Appearance.BackColor = Color.Gray;
        }

        private void schedulerControl1_AllowAppointmentConflicts(object sender, AppointmentConflictEventArgs e)
        {
            e.Conflicts.Clear();
            FillConflictedAppointmentsCollection(e.Conflicts, e.Interval, ((SchedulerControl)sender).Storage.Appointments.Items, e.AppointmentClone);
        }
        void FillConflictedAppointmentsCollection(AppointmentBaseCollection conflicts, TimeInterval interval,
    AppointmentBaseCollection collection, Appointment currApt)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                Appointment apt = collection[i];
                if (new TimeInterval(apt.Start, apt.End).IntersectsWith(interval) & !(apt.Start == interval.End || apt.End == interval.Start))
                {
                    if (Object.Equals(apt.ResourceId, currApt.ResourceId))
                    {
                        conflicts.Add(apt);
                    }
                }
                if (apt.Type == AppointmentType.Pattern)
                {
                    FillConflictedAppointmentsCollection(conflicts, interval, apt.GetExceptions(), currApt);
                }
            }
        }

        private void dtpkToday_ValueChanged(object sender, EventArgs e)
        {
            LoadControl();
        }

        private void schedulerControl1_EditAppointmentFormShowing(object sender, AppointmentFormEventArgs e)
        {
            DevExpress.XtraScheduler.SchedulerControl scheduler = ((DevExpress.XtraScheduler.SchedulerControl)(sender));
            WareHouse.PC.CustomAppointmentForm form = new WareHouse.PC.CustomAppointmentForm(scheduler, e.Appointment, e.OpenRecurrenceForm);
            try
            {
                form.LamMoi += new EventHandler(btnUpdate_Click);
                e.DialogResult = form.ShowDialog();
                e.Handled = true;
            }
            finally
            {
                form.Dispose();
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            if (e.RowHandle >= 0) // chỉ xử lý trong cột họ tên thôi 
            {
                e.Appearance.BackColor = Color.Red;
                e.Appearance.ForeColor = Color.Black;
            }
        }

        private void schedulerControl1_AppointmentViewInfoCustomizing(object sender, AppointmentViewInfoCustomizingEventArgs e)
        {
            e.ViewInfo.Appearance.FontSizeDelta = 0;
        }
    }
}
