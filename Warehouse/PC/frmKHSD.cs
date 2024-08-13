using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
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
using WareHouse.Model;
using WareHouse.PCGridControl;

namespace WareHouse.PC
{
    public partial class frmKHSD : Form
    {
        #region InitialDataConstants
        List<MachineDTO> Users = MachineDAO.Instance.GetListMachineByDevice(1);
        public string[] StatusUsers = new string[] { "Sản xuất","Thực tế","Định kỳ","Xuất hàng"};
        #endregion
        public frmKHSD()
        {
            InitializeComponent();
            LoadControl();
            CultureInfo culture = CultureInfo.CreateSpecificCulture("vi");
            culture.DateTimeFormat.ShortTimePattern = "HH:mm";

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }
        void LoadControl()
        {
            InitResoucer();
            InitAppointments();
            schedulerControl1.Start = DateTime.Now;
            schedulerControl1.GroupType = SchedulerGroupType.Resource;
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.Appearance.Appointment.ForeColor = Color.Gray;
            //schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Never;
            schedulerControl1.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.DayView.ShowMoreButtons = false;
            schedulerControl1.DayView.ShowMoreButtonsOnEachColumn = false;
            schedulerControl1.TimelineView.ShowMoreButtons = false;
            schedulerControl1.TimelineView.Scales.Clear();
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleDay());
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleHour());
            schedulerControl1.TimelineView.Scales[1].Width = 50;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.AppointmentHeight = 20;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Disabled;
            UpdateControls();
            schedulerControl1.TimelineView.ResourcesPerPage =15;
            schedulerControl1.CustomizeAppointmentFlyout += scheduler_CustomizeAppointmentFlyout;
        }
        #region InitialDataLoad
        void InitResoucer()
        {
            List<Resources> listR = ResoucesDAO.Instance.GetListResource();
            this.schedulerDataStorage1.Resources.Mappings.Id = "Id";
            this.schedulerDataStorage1.Resources.Mappings.Caption = "Description";
            this.schedulerDataStorage1.Resources.Mappings.ParentId = "ParentId";
            this.schedulerDataStorage1.Resources.DataSource = listR;
        }
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

            CustomEventList eventList = new CustomEventList();
            GenerateEvents(eventList);
            this.schedulerDataStorage1.Appointments.DataSource = eventList;
          
        }
        void GenerateEvents(CustomEventList eventList)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
            int count = schedulerDataStorage1.Resources.Count;
            DateTime today = DateTime.Today.AddHours(10);
            DateTime date1 = today.AddMonths(-1);
            DateTime date2 = today.AddMonths(1);
            for (int i = 0; i < count; i++)
            {
                Resource resource = schedulerDataStorage1.Resources[i];
                string machinecode = resource.Caption;
                List<KHBDDTO> listK = TDSXDAO.Instance.GetlistKHBDbyDate(machinecode, date1, date2);
                foreach (KHBDDTO item in listK)
                {
                    int test = item.ConfirmBD;
                    int timeTest = (item.EndTime - item.StartTime).Hours;
                    if (test == 0)
                    {
                        eventList.Add(CreateEvent(eventList, item.PartCode + "/" + item.CountBD, resource.Id, 1, 5, item.StartTime, item.EndTime, "100%"));
                    }
                    else
                    {
                        eventList.Add(CreateEvent(eventList, item.PartCode, resource.Id, 1, 10, item.StartTime, item.EndTime, "100%"));
                    }
                }
                List<KHSDDTO> listKk = TDSXDAO.Instance.GetlistKHSDbyDate(machinecode, date1, date2);
                foreach (KHSDDTO item in listKk)
                {
                    int test = item.ConfirmSD;               
                    int timeTest = (item.EndTime - item.StartTime).Hours;
                    if (test == 0)
                    {
                        eventList.Add(CreateEvent(eventList, item.PartCode + "/" + item.CountSD, resource.Id, 1, 7, item.StartTime, item.EndTime, "100%"));
                    }
                    else
                    {
                        eventList.Add(CreateEvent(eventList, item.PartCode, resource.Id, 1, 10, item.StartTime, item.EndTime, "100%"));
                    }
                }
            }
        }
        CustomEvent CreateEvent(CustomEventList eventList, string subject, object resourceId, int status, int label, DateTime starttime, DateTime endtime, string des)
        {
            CustomEvent apt = new CustomEvent(eventList);
            apt.Subject = subject;
            apt.OwnerId = resourceId;
            apt.StartTime = starttime;
            apt.EndTime = endtime;
            apt.Status = status;
            apt.Label = label;
            apt.Location = des;
            return apt;
        }
        #endregion

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
                string[] s = tlvi.Appointment.Subject.Split(' ');

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
        static Font fnt = new Font("Segoe UI", 10f);

        public static void scheduler_CustomizeAppointmentFlyout(object sender, CustomizeAppointmentFlyoutEventArgs e)
        {
            e.ShowSubject = true;
            e.Subject = String.Format("{0} - {1:f}", e.Subject, e.Location);
            e.SubjectAppearance.Font = fnt;
            e.ShowReminder = false;
            e.ShowLocation = false;
            e.ShowEndDate = true;
            e.ShowStartDate = true;
            e.ShowStatus = false;
            e.Appearance.BackColor = Color.Gray;
        }
        private void btnListKHSD_Click(object sender, EventArgs e)
        {
            frmListKHSD f = new frmListKHSD();
            f.ShowDialog();
        }
    }
}
