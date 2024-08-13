using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.Model;
using WareHouse.PCGridControl;


namespace WareHouse.PC
{
    public partial class frmKHBD : Form
    {
        #region InitialDataConstants
        public static Random RandomInstance = new Random();
        public static string[] Users = new string[] {"A1", "A2", "A3",
                                                 "A4", "A5", "A6", "A7", "A8",
                                                 "A9", "B1", "B2", "B3", "B4",
                                                 "B5", "B6", "B7", "B8"};
        #endregion

        //Color[] colorArray = { Color.Red, Color.Green, Color.Blue, Color.Black };
        public frmKHBD()
        {
            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            FillResources(schedulerDataStorage1, 17);
            InitAppointments();
            schedulerControl1.Start = DateTime.Now;
            schedulerControl1.ActiveViewType = SchedulerViewType.Timeline;
            schedulerControl1.Appearance.Appointment.ForeColor = Color.Gray;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.TimelineView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.DayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Never;
            schedulerControl1.DayView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            schedulerControl1.DayView.ShowMoreButtons = false;
            schedulerControl1.DayView.ShowMoreButtonsOnEachColumn = false;
            schedulerControl1.TimelineView.ShowMoreButtons = false;
            schedulerControl1.TimelineView.Scales.Clear();
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleDay());
            schedulerControl1.TimelineView.Scales.Add(new TimeScaleHour());
            schedulerControl1.TimelineView.Scales[1].Width = 60;
            UpdateControls();
        }
        #region InitialDataLoad
        void FillResources(SchedulerDataStorage storage, int count)
        {
            // thay thế mã máy ở đây
            
            int cnt = Math.Min(count, Users.Length);
            for (int i = 1; i <= cnt; i++)
                storage.Resources.Items.Add(storage.CreateResource(Guid.NewGuid(), Users[i - 1]));
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
                    if(test == 0)
                    {
                        eventList.Add(CreateEvent(eventList, item.PartCode + "/" + item.CountBD, resource.Id, 1, 5, item.StartTime, item.EndTime, "100%"));
                    }
                    else
                    {
                        eventList.Add(CreateEvent(eventList,item.PartCode, resource.Id, 1, 10, item.StartTime, item.EndTime, "100%"));
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

        private void btnListKHBD_Click(object sender, EventArgs e)
        {
            frmListKHBD f = new frmListKHBD();
            f.Show();
        }
    }
}
