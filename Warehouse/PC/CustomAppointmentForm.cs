using System;
using System.Drawing;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils.Controls;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Localization;
using DevExpress.XtraScheduler.Native;
using DevExpress.XtraScheduler.UI;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors.Native;
using DevExpress.Utils.Internal;
using System.Collections.Generic;
using DevExpress.XtraScheduler.Internal;
using DAO;
using System.Diagnostics;
using System.Globalization;

namespace WareHouse.PC
{
    public partial class CustomAppointmentForm : XtraForm, IDXManagerPopupMenu
    {

        bool openRecurrenceForm;
        readonly ISchedulerStorage storage;
        readonly SchedulerControl control;
        Icon recurringIcon;
        Icon normalIcon;
        readonly AppointmentFormController controller;
        IDXMenuManager menuManager;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public CustomAppointmentForm()
        {
            InitializeComponent();
        }
        public EventHandler LamMoi;
        public bool IsConfirm = false;
        public CustomAppointmentForm(SchedulerControl control, Appointment apt)
            : this(control, apt, false)
        {
        }
        public CustomAppointmentForm(SchedulerControl control, Appointment apt, bool openRecurrenceForm)
        {
            Guard.ArgumentNotNull(control, "control");
            Guard.ArgumentNotNull(control.DataStorage, "control.DataStorage");
            Guard.ArgumentNotNull(apt, "apt");

            this.openRecurrenceForm = openRecurrenceForm;
            this.controller = CreateController(control, apt);
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            SetupPredefinedConstraints();

            LoadIcons();

            this.control = control;
            this.storage = control.DataStorage;

            //this.edtShowTimeAs.Storage = this.storage;
            this.edtLabel.Storage = this.storage;
            this.edtResource.SchedulerControl = control;
            this.edtResource.Storage = this.storage;
            this.edtResources.SchedulerControl = control;

            SubscribeControllerEvents(Controller);
            SubscribeEditorsEvents();
            BindControllerToControls();
            LoadControl();
        }

        protected override FormShowMode ShowMode { get { return FormShowMode.AfterInitialization; } }
        [Browsable(false)]
        public IDXMenuManager MenuManager { get { return this.menuManager; } private set { this.menuManager = value; } }
        protected internal AppointmentFormController Controller { get { return this.controller; } }
        protected internal SchedulerControl Control { get { return this.control; } }
        protected internal ISchedulerStorage Storage { get { return this.storage; } }
        protected internal bool IsNewAppointment { get { return this.controller != null ? this.controller.IsNewAppointment : true; } }
        protected internal Icon RecurringIcon { get { return this.recurringIcon; } }
        protected internal Icon NormalIcon { get { return this.normalIcon; } }
        protected internal bool OpenRecurrenceForm { get { return this.openRecurrenceForm; } }
        [DXDescription("DevExpress.XtraScheduler.UI.AppointmentForm,ReadOnly")]
        [DXCategory(CategoryName.Behavior)]
        [DefaultValue(false)]
        public bool ReadOnly
        {
            get { return Controller != null && Controller.ReadOnly; }
            set
            {
                if (Controller.ReadOnly == value)
                    return;
                Controller.ReadOnly = value;
            }
        }

        public virtual void LoadFormData(Appointment appointment)
        {
            //do nothing
        }
        public virtual bool SaveFormData(Appointment appointment)
        {
            return true;
        }
        public virtual bool IsAppointmentChanged(Appointment appointment)
        {
            return false;
        }
        public virtual void SetMenuManager(IDXMenuManager menuManager)
        {
            MenuManagerUtils.SetMenuManager(Controls, menuManager);
            this.menuManager = menuManager;
        }

        protected internal virtual void SetupPredefinedConstraints()
        {
            //this.tbProgress.Properties.Minimum = AppointmentProcessValues.Min;
            //this.tbProgress.Properties.Maximum = AppointmentProcessValues.Max;
            //this.tbProgress.Properties.SmallChange = AppointmentProcessValues.Step;
            //this.edtResources.Visible = true;
        }
        protected virtual void BindControllerToControls()
        {
            BindControllerToIcon();
            BindProperties(this.tbSubject, "Text", "Subject");
            BindProperties(this.tbLocation, "Text", "Location");
            //BindProperties(this.tbDescription, "Text", "Description");
            //BindProperties(this.edtShowTimeAs, "Status", "Status");
            BindProperties(this.edtStartDate, "EditValue", "DisplayStartDate");
            BindProperties(this.edtStartDate, "Enabled", "IsDateTimeEditable");
            BindProperties(this.edtStartTime, "EditValue", "DisplayStartTime");
            BindProperties(this.edtStartTime, "Visible", "IsTimeVisible");
            BindProperties(this.edtStartTime, "Enabled", "IsTimeVisible");
            BindProperties(this.edtEndDate, "EditValue", "DisplayEndDate", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndDate, "Enabled", "IsDateTimeEditable", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "EditValue", "DisplayEndTime", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Visible", "IsTimeVisible", DataSourceUpdateMode.Never);
            BindProperties(this.edtEndTime, "Enabled", "IsTimeVisible", DataSourceUpdateMode.Never);
            //BindProperties(this.chkAllDay, "Checked", "AllDay");
            //BindProperties(this.chkAllDay, "Enabled", "IsDateTimeEditable");

            BindProperties(this.edtResource, "ResourceId", "ResourceId");
            BindProperties(this.edtResource, "Enabled", "CanEditResource");
            BindToBoolPropertyAndInvert(this.edtResource, "Visible", "ResourceSharing");

            BindProperties(this.edtResources, "ResourceIds", "ResourceIds");
            BindProperties(this.edtResources, "Visible", "ResourceSharing");
            BindProperties(this.edtResources, "Enabled", "CanEditResource");
            BindProperties(this.lblResource, "Enabled", "CanEditResource");

            BindProperties(this.edtLabel, "Label", "Label");
            //BindProperties(this.chkReminder, "Enabled", "ReminderVisible");
            //BindProperties(this.chkReminder, "Visible", "ReminderVisible");
            //BindProperties(this.chkReminder, "Checked", "HasReminder");
            BindProperties(this.cbReminder, "Enabled", "HasReminder");
            BindProperties(this.cbReminder, "Visible", "ReminderVisible");
            BindProperties(this.cbReminder, "Duration", "ReminderTimeBeforeStart");

            //BindProperties(this.tbProgress, "Value", "PercentComplete");
            //BindProperties(this.lblPercentCompleteValue, "Text", "PercentComplete", ObjectToStringConverter);
            //BindProperties(this.progressPanel, "Visible", "ShouldEditTaskProgress");
            BindToBoolPropertyAndInvert(this.btnOk, "Enabled", "ReadOnly");
            //BindToBoolPropertyAndInvert(this.btnRecurrence, "Enabled", "ReadOnly");
            //BindProperties(this.btnDelete, "Enabled", "CanDeleteAppointment");
            //BindProperties(this.btnRecurrence, "Visible", "ShouldShowRecurrenceButton");
        }
        protected virtual void BindControllerToIcon()
        {
            Binding binding = new Binding("Icon", Controller, "AppointmentType");
            binding.Format += AppointmentTypeToIconConverter;
            DataBindings.Add(binding);
        }
        protected virtual void ObjectToStringConverter(object o, ConvertEventArgs e)
        {
            e.Value = e.Value.ToString();
        }
        protected virtual void AppointmentTypeToIconConverter(object o, ConvertEventArgs e)
        {
            AppointmentType type = (AppointmentType)e.Value;
            if (type == AppointmentType.Pattern)
                e.Value = RecurringIcon;
            else
                e.Value = NormalIcon;
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty)
        {
            BindProperties(target, targetProperty, sourceProperty, DataSourceUpdateMode.OnPropertyChanged);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, DataSourceUpdateMode updateMode)
        {
            target.DataBindings.Add(targetProperty, Controller, sourceProperty, true, updateMode);
        }
        protected virtual void BindProperties(Control target, string targetProperty, string sourceProperty, ConvertEventHandler objectToStringConverter)
        {
            Binding binding = new Binding(targetProperty, Controller, sourceProperty, true);
            binding.Format += objectToStringConverter;
            target.DataBindings.Add(binding);
        }
        protected virtual void BindToBoolPropertyAndInvert(Control target, string targetProperty, string sourceProperty)
        {
            target.DataBindings.Add(new BoolInvertBinding(targetProperty, Controller, sourceProperty));
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (Controller == null)
                return;
            DataBindings.Add("Text", Controller, "Caption");
            SubscribeControlsEvents();
            LoadFormData(Controller.EditedAppointmentCopy);
            RecalculateLayoutOfControlsAffectedByProgressPanel();
        }
        protected virtual AppointmentFormController CreateController(SchedulerControl control, Appointment apt)
        {
            return new AppointmentFormController(control, apt);
        }
        void SubscribeEditorsEvents()
        {
            this.cbReminder.EditValueChanging += OnCbReminderEditValueChanging;
        }
        void SubscribeControllerEvents(AppointmentFormController controller)
        {
            if (controller == null)
                return;
            controller.PropertyChanged += OnControllerPropertyChanged;
        }
        void OnControllerPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "ReadOnly")
                UpdateReadonly();
        }
        protected virtual void UpdateReadonly()
        {
            if (Controller == null)
                return;
            IList<Control> controls = GetAllControls(this);
            foreach (Control control in controls)
            {
                BaseEdit editor = control as BaseEdit;
                if (editor == null)
                    continue;
                editor.ReadOnly = Controller.ReadOnly;
            }
            this.btnOk.Enabled = !Controller.ReadOnly;
            //this.btnRecurrence.Enabled = !Controller.ReadOnly;
        }

        List<Control> GetAllControls(Control rootControl)
        {
            List<Control> result = new List<Control>();
            foreach (Control control in rootControl.Controls)
            {
                result.Add(control);
                IList<Control> childControls = GetAllControls(control);
                result.AddRange(childControls);
            }
            return result;
        }
        protected internal virtual void LoadIcons()
        {
            Assembly asm = typeof(SchedulerControl).Assembly;
            this.recurringIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.RecurringAppointment, asm);
            this.normalIcon = ResourceImageHelper.CreateIconFromResources(SchedulerIconNames.Appointment, asm);
        }
        protected internal virtual void SubscribeControlsEvents()
        {
            this.edtEndDate.Validating += new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating += new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue += new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating += new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating += new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating += new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue += new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        protected internal virtual void UnsubscribeControlsEvents()
        {
            this.edtEndDate.Validating -= new CancelEventHandler(OnEdtEndDateValidating);
            this.edtEndDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndDateInvalidValue);
            this.edtEndTime.Validating -= new CancelEventHandler(OnEdtEndTimeValidating);
            this.edtEndTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtEndTimeInvalidValue);
            this.cbReminder.InvalidValue -= new InvalidValueExceptionEventHandler(OnCbReminderInvalidValue);
            this.cbReminder.Validating -= new CancelEventHandler(OnCbReminderValidating);
            this.edtStartDate.Validating -= new CancelEventHandler(OnEdtStartDateValidating);
            this.edtStartDate.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartDateInvalidValue);
            this.edtStartTime.Validating -= new CancelEventHandler(OnEdtStartTimeValidating);
            this.edtStartTime.InvalidValue -= new InvalidValueExceptionEventHandler(OnEdtStartTimeInvalidValue);
        }
        void OnBtnOkClick(object sender, EventArgs e)
        {
            long id = Controller.PercentComplete;
            string des = edtResource.Text;
            int idRe = (int)Controller.ResourceId;
            string employess = txtEmployess.Text;
            int test = EmployessDAO.Instance.TestEmployessByCode(employess);
            if (test == -1)
            {
                MessageBox.Show("mã nhân viên không đúng !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (IsConfirm == true)
            {
                int color = 5;
                if (cbStatus.Text == "NG")
                {
                    color = 1;
                }
                if (des == "3.Định kỳ")
                {
                    DateTime startTime = TDSXDAO.Instance.StartTime(id);
                    long iddk = TDSXDAO.Instance.IdDKById(id, idRe);
                    TDSXDAO.Instance.UpdateConfirmTableDK(iddk, startTime, 2, color, txtNote.Text, employess);
                    TDSXDAO.Instance.UpdateColorTableDK(id, color, 2);
                    MessageBox.Show("OK");
                    this.Close();
                }
                else if (des == "4.Xuất hàng")
                {
                    DateTime startTime = TDSXDAO.Instance.DateStartTimeXH(id);
                    long iddk = TDSXDAO.Instance.IdXHById(id, idRe);
                    TDSXDAO.Instance.UpdateConfirmTableXH(iddk, startTime, 2, color, txtNote.Text, employess);
                    TDSXDAO.Instance.UpdateColorTableXH(id, color, 2);
                    MessageBox.Show("OK");
                    this.Close();
                }
            }
            else
            {
                if (des == "3.Định kỳ")
                {
                    TDSXDAO.Instance.UpdateColorTableDK(id, 10, 1);
                    MessageBox.Show("OK");
                    this.Close();
                }
                else if (des == "4.Xuất hàng")
                {
                    TDSXDAO.Instance.UpdateColorTableXH(id, 10, 1);
                    MessageBox.Show("OK");
                    this.Close();
                }
            }
        }
        protected internal virtual void OnEdtStartTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtStartDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtStartDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnEdtEndDateValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndDate.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndDateInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual void OnEdtEndTimeValidating(object sender, CancelEventArgs e)
        {
            e.Cancel = !IsValidInterval();
            if (!e.Cancel)
                this.edtEndTime.DataBindings["EditValue"].WriteValue();
        }
        protected internal virtual void OnEdtEndTimeInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            if (!AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay))
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidEndDate);
            else
                e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_DateOutsideLimitInterval);
        }
        protected internal virtual bool IsValidInterval()
        {
            return AppointmentFormControllerBase.ValidateInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay) &&
                Controller.ValidateLimitInterval(this.edtStartDate.DateTime.Date, this.edtStartTime.Time.TimeOfDay, this.edtEndDate.DateTime.Date, this.edtEndTime.Time.TimeOfDay);
        }
        protected internal virtual void OnOkButton()
        {
            if (!ValidateDateAndTime())
                return;
            if (!SaveFormData(Controller.EditedAppointmentCopy))
                return;
            if (!Controller.IsConflictResolved())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_Conflict), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_Conflict), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (!Controller.IsTimeValid())
            {
                ShowMessageBox(SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidAppointmentTime), Controller.GetMessageBoxCaption(SchedulerStringId.Msg_InvalidAppointmentTime), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (IsAppointmentChanged(Controller.EditedAppointmentCopy) || Controller.IsAppointmentChanged() || Controller.IsNewAppointment)
                Controller.ApplyChanges();

            DialogResult = DialogResult.OK;
        }
        private bool ValidateDateAndTime()
        {
            this.edtEndDate.DoValidate();
            this.edtEndTime.DoValidate();
            this.edtStartDate.DoValidate();
            this.edtStartTime.DoValidate();

            return String.IsNullOrEmpty(this.edtEndTime.ErrorText) && String.IsNullOrEmpty(this.edtEndDate.ErrorText) && String.IsNullOrEmpty(this.edtStartDate.ErrorText) && String.IsNullOrEmpty(this.edtStartTime.ErrorText);
        }
        protected internal virtual DialogResult ShowMessageBox(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return XtraMessageBox.Show(this, text, caption, buttons, icon);
        }
        void OnBtnDeleteClick(object sender, EventArgs e)
        {
            OnDeleteButton();
        }
        protected internal virtual void OnDeleteButton()
        {
            if (IsNewAppointment)
                return;

            Controller.DeleteAppointment();

            DialogResult = DialogResult.Abort;
            Close();
        }
        void OnBtnRecurrenceClick(object sender, EventArgs e)
        {
            OnRecurrenceButton();
        }
        protected internal virtual void OnRecurrenceButton()
        {
            if (!Controller.ShouldShowRecurrenceButton)
                return;

            Appointment patternCopy = Controller.PrepareToRecurrenceEdit();

            DialogResult result;
            using (Form form = CreateAppointmentRecurrenceForm(patternCopy, Control.OptionsView.FirstDayOfWeek))
            {
                result = ShowRecurrenceForm(form);
            }

            if (result == DialogResult.Abort)
            {
                Controller.RemoveRecurrence();
            }
            else if (result == DialogResult.OK)
            {
                Controller.ApplyRecurrence(patternCopy);
            }
        }
        protected virtual DialogResult ShowRecurrenceForm(Form form)
        {
            return FormTouchUIAdapter.ShowDialog(form, this);
        }
        protected internal virtual Form CreateAppointmentRecurrenceForm(Appointment patternCopy, FirstDayOfWeek firstDayOfWeek)
        {
            AppointmentRecurrenceForm form = new AppointmentRecurrenceForm(patternCopy, firstDayOfWeek, Controller);
            form.SetMenuManager(MenuManager);
            form.LookAndFeel.ParentLookAndFeel = LookAndFeel;
            form.ShowExceptionsRemoveMsgBox = this.controller.AreExceptionsPresent();
            return form;
        }
        internal void OnAppointmentFormActivated(object sender, EventArgs e)
        {
            if (this.openRecurrenceForm)
            {
                this.openRecurrenceForm = false;
                OnRecurrenceButton();
            }
        }
        protected internal virtual void OnCbReminderValidating(object sender, CancelEventArgs e)
        {
            TimeSpan span = this.cbReminder.Duration;
            e.Cancel = (span == TimeSpan.MinValue) || (span.Ticks < 0);
            if (!e.Cancel)
                this.cbReminder.DataBindings["Duration"].WriteValue();
        }
        protected internal virtual void OnCbReminderInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ErrorText = SchedulerLocalizer.GetString(SchedulerStringId.Msg_InvalidReminderTimeBeforeStart);
        }
        protected internal virtual void RecalculateLayoutOfControlsAffectedByProgressPanel()
        {
            //if (this.progressPanel.Visible)
            //    return;
            //int intDeltaY = this.progressPanel.Height;
            //this.tbDescription.Location = new Point(this.tbDescription.Location.X, this.tbDescription.Location.Y - intDeltaY);
            //this.tbDescription.Size = new Size(this.tbDescription.Size.Width, this.tbDescription.Size.Height + intDeltaY);
        }
        void OnCbReminderEditValueChanging(object sender, ChangingEventArgs e)
        {
            if (e.NewValue is TimeSpan)
                return;
            string stringValue = e.NewValue as String;
            TimeSpan duration = HumanReadableTimeSpanHelper.Parse(stringValue);
            if (duration.Ticks < 0)
                e.NewValue = TimeSpan.FromTicks(0);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomAppointmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
        void LoadControl()
        {
            edtEndDate.Enabled = false;
            edtEndTime.Enabled = false;
            edtStartDate.Enabled = false;
            edtEndTime.Enabled = false;
            cbStatus.DataSource = WareHouseDAO.Instance.StatusAppointment();
            cbStatus.DisplayMember = "NameStatus";
            cbStatus.ValueMember = "NameStatus";
        }
        private void btnLayHang_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
            btnDoHang.Enabled = false;
            IsConfirm = false;
            txtEmployess.Enabled = true;
            CheckMinId();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string[] array = tbSubject.Text.Split('-');
            string desRe = edtResource.Text;
            if (desRe == "3.Định kỳ")
            {
                string dk = PartDAO.Instance.DK(array[0]);
                try
                {
                    Process.Start(dk);
                }
                catch
                {
                    MessageBox.Show("không thể in Form".ToUpper());
                }
            }
            else if (desRe == "4.Xuất hàng")
            {
                string dk = PartDAO.Instance.XH(array[0]);
                try
                {
                    Process.Start(dk);
                }
                catch
                {
                    MessageBox.Show("không thể in Form".ToUpper());
                }
            }
            else
            {
                string ld = PartDAO.Instance.LD(array[0]);
                try
                {
                    Process.Start(ld);
                }
                catch
                {
                    MessageBox.Show("không thể in Form".ToUpper());
                }
            }
        }

        private void btnDoHang_Click(object sender, EventArgs e)
        {
            btnOk.Enabled = true;
            btnLayHang.Enabled = false;
            IsConfirm = true;
            cbStatus.Enabled = true;
            txtEmployess.Enabled = true;
            CheckMinId();
        }
        void CheckMinId()
        {
            string desRe = edtResource.Text;
            long id = Controller.PercentComplete;
            int idRe = (int)Controller.ResourceId;
            if (desRe == "3.Định kỳ")
            {
                int confirm = TDSXDAO.Instance.ConfirmDK(id);
                int color = TDSXDAO.Instance.ColorDK(id);
                long minId = TDSXDAO.Instance.MinIdByConfirm(1, idRe);
                if (confirm == 2 && color != 1)
                {
                    MessageBox.Show("mốc này đã được kiểm tra rồi".ToUpper());
                    this.Close();
                }
                else if (id < minId)
                {
                    MessageBox.Show("bạn chưa kiểm xác nhận đo hàng mốc trước".ToUpper());
                    this.Close();
                }
                else if (id > minId)
                {
                    MessageBox.Show("Đã kiểm tra mốc này".ToUpper());
                    this.Close();
                }

            }
            else if (desRe == "4.Xuất hàng")
            {
                int confirm = TDSXDAO.Instance.ConfirmXH(id);
                int color = TDSXDAO.Instance.ColorXH(id);
                long minId = TDSXDAO.Instance.MinIdXHByConfirm(1, idRe);
                if (confirm == 2 && color != 1)
                {
                    MessageBox.Show("mốc này đã được kiểm tra rồi".ToUpper());
                    this.Close();
                }
                else if (id != minId)
                {
                    MessageBox.Show("bạn chưa kiểm xác nhận đo hàng mốc trước".ToUpper());
                    this.Close();
                }
                else if (id > minId)
                {
                    MessageBox.Show("Đã kiểm tra mốc này".ToUpper());
                    this.Close();
                }
            }
        }

        private void btnEditQuantity_Click(object sender, EventArgs e)
        {
            string desRe = edtResource.Text;
            if (desRe == "1.Sản xuất")
            {
                btnSave.Enabled = true;
                nudQuantity.Enabled = true;
                btnOk.Enabled = false;

            }
            else
            {
                MessageBox.Show("bạn không thể sửa số lượng sản xuất tại mốc đo của QC!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string[] array = tbSubject.Text.Split('&');
            long id = Controller.PercentComplete;
            int confirm = TDSXDAO.Instance.ConfirmSXById(id);//
            int color = TDSXDAO.Instance.ColorSXById(id);
            int quantityOld = int.Parse(array[3]);
            long IdTT = TDSXDAO.Instance.IDTableTT(id);
            string MachineCode = TDSXDAO.Instance.MachineByID(id);
            long maxId = TDSXDAO.Instance.MaxIdSX(MachineCode);
            int idResourceXH = TDSXDAO.Instance.IdResourceXH(id);
            int idResourceDK = TDSXDAO.Instance.IdResourceDK(id);
            DateTime MaxEndtimeDK = TDSXDAO.Instance.MaxEndTimeDK(id);
            DateTime MaxEndtimeXH = TDSXDAO.Instance.MaxEndTimeXH(id);
            DateTime MaxEndtimeTT = TDSXDAO.Instance.MaxEndTimeTTByIdSX(id);
            DateTime MinStartSX = TDSXDAO.Instance.MaxStartTimeSX(MachineCode);
            DateTime MinSTime = TDSXDAO.Instance.MinStartTimeSX(id);
            string employess = txtEmployess.Text;
            DateTime start = (DateTime)Controller.Start;
            int quantity = (int)nudQuantity.Value;
            string partCode = array[0].ToUpper();
            if (quantity == 0)
            {
                MessageBox.Show("bạn chưa điền số lượng cần sửa !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int Cav = PartDAO.Instance.CavityByCode(partCode);
            int second = (int)(((quantity + quantityOld) * PartDAO.Instance.CycleTimeByCode(partCode)) / Cav);
            DateTime end = start.AddSeconds(second);
            if (end >= MinSTime && id != maxId)
            {
                MessageBox.Show("Sản lượng sản xuất không đúng !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TDSXDAO.Instance.UpdateTableSX(id, (quantity + quantityOld), end, color, confirm);
            TDSXDAO.Instance.UpdateMaxTimeTableTT(IdTT, end);
            if (end < MaxEndtimeDK)
            {
                TDSXDAO.Instance.DeleteTableDKByDate(end.AddMinutes(-5), id);
            }
            else if (end > MaxEndtimeDK)
            {
                if ((end - MaxEndtimeDK).TotalHours >= 2)
                {
                    int n = (int)Math.Floor(((end - MaxEndtimeDK).TotalHours) / 2);
                    // Thêm kiểm tra định kỳ
                    for (int i = 1; i <= n; i++)
                    {
                        TDSXDAO.Instance.InsertTableDK(idResourceDK, id, MaxEndtimeDK.AddHours(i * 2), MaxEndtimeDK.AddHours(i * 2).AddMinutes(5), 8, 1, MaxEndtimeDK.AddHours((i + 1) * 2), employess);
                    }
                }
            }
            if (end < MaxEndtimeXH)
            {
                TDSXDAO.Instance.DeleteTableXHByDate(end.AddMinutes(-10), id);

                TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
            }
            else if (end > MaxEndtimeXH)
            {
                TDSXDAO.Instance.DeleteTableXHByDate(MaxEndtimeXH.AddMinutes(5), id);
                int m = (int)Math.Ceiling(((end - MaxEndtimeXH).TotalHours) / 12);
                double k = ((end - MaxEndtimeXH).TotalHours);
                if (k <= 12)
                {
                    TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                }
                else
                {
                    for (int i = 1; i <= m; i++)
                    {
                        if (i != m)
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, MaxEndtimeXH.AddHours(12 * i), MaxEndtimeXH.AddHours(12 * i).AddMinutes(5), 8, 1, MaxEndtimeXH.AddHours(12 * i).AddHours(12), employess);
                        }
                        else
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                        }
                    }
                }
            }
            MessageBox.Show("Cập nhật thành công !".ToUpper());
            this.Close();
        }

        private void btnEndGame_Click(object sender, EventArgs e)
        {
            string desRe = edtResource.Text;
            if (desRe == "1.Sản xuất")
            {
                txtEmployessPro.Enabled = true;
                btnSaveEnd.Enabled = true;
                edtEndDate.Enabled = true;
                edtEndTime.Enabled = true;
            }
            else
            {
                MessageBox.Show("bạn hãy chọn đúng thanh sản xuất để kết thúc".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSaveEnd_Click(object sender, EventArgs e)
        {
            string[] array = tbSubject.Text.Split('&');
            string partCode = array[0];
            long id = Controller.PercentComplete;
            int confirm = TDSXDAO.Instance.ConfirmSXById(id);
            if (confirm == 0)
            {
                MessageBox.Show("hạng mục này đã được kết thúc sản xuất rồi \n bạn hãy kiểm tra lại!".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int Quantity = int.Parse(array[3]);
            long IdTT = TDSXDAO.Instance.IDTableTT(id);
            DateTime MaxEndTimeTT = TDSXDAO.Instance.MaxEndTimeTTByIdSX(id);
            int idResourceXH = TDSXDAO.Instance.IdResourceXH(id);
            int idResourceDK = TDSXDAO.Instance.IdResourceDK(id);
            DateTime MaxEndtimeDK = TDSXDAO.Instance.MaxEndTimeDK(id);
            DateTime MaxEndtimeXH = TDSXDAO.Instance.MaxEndTimeXH(id);
            string employess = txtEmployessPro.Text;
            int test = EmployessDAO.Instance.TestEmployessByCode(employess);
            if (test == -1)
            {
                MessageBox.Show("mã nhân viên không đúng !".ToUpper(), "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Quantity == 0)
            {
                MessageBox.Show("bạn chưa điền số lượng lin kiện cần sản xuất !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TimeSpan times = DateTime.Parse(edtStartTime.Text, new CultureInfo("en-CA", true)) - DateTime.Parse(edtStartTime.Text, new CultureInfo("en-CA", true)).Date;
            DateTime start = DateTime.Parse(edtStartDate.Text, new CultureInfo("en-CA", true)).AddSeconds(times.TotalSeconds);
            TimeSpan timeE = DateTime.Parse(edtEndTime.Text, new CultureInfo("en-CA", true)) - DateTime.Parse(edtEndTime.Text, new CultureInfo("en-CA", true)).Date;
            DateTime end = DateTime.Parse(edtEndDate.Text, new CultureInfo("en-CA", true)).AddSeconds(timeE.TotalSeconds);
            if (end <= start || end < MaxEndTimeTT)
            {
                MessageBox.Show("thời gian kết thúc không đúng !", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            TDSXDAO.Instance.UpdateTableSX(id, Quantity, end, 6, 0);
            TDSXDAO.Instance.UpdateMaxTimeTableTT(IdTT, end);
            if (end < MaxEndtimeDK)
            {
                TDSXDAO.Instance.DeleteTableDKByDate(end.AddMinutes(-5), id);
            }
            else if (end > MaxEndtimeDK)
            {
                if ((end - MaxEndtimeDK).TotalHours >= 2)
                {
                    int n = (int)Math.Floor(((end - MaxEndtimeDK).TotalHours) / 2);
                    // Thêm kiểm tra định kỳ
                    for (int i = 1; i <= n; i++)
                    {
                        TDSXDAO.Instance.InsertTableDK(idResourceDK, id, MaxEndtimeDK.AddHours(i * 2), MaxEndtimeDK.AddHours(i * 2).AddMinutes(5), 8, 1, MaxEndtimeDK.AddHours((i + 1) * 2), employess);
                    }
                }

            }
            if (end < MaxEndtimeXH)
            {

                TDSXDAO.Instance.DeleteTableXHByDate(end.AddMinutes(-10), id);
                TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
            }
            else if (end > MaxEndtimeXH)
            {
                TDSXDAO.Instance.DeleteTableXHByDate(MaxEndtimeXH.AddMinutes(5), id);
                int m = (int)Math.Ceiling(((end - MaxEndtimeXH).TotalHours) / 12);
                double k = ((end - MaxEndtimeXH).TotalHours);
                if (k <= 12)
                {
                    TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                }
                else
                {
                    for (int i = 1; i <= m; i++)
                    {
                        if (i != m)
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, MaxEndtimeXH.AddHours(12 * i), MaxEndtimeXH.AddHours(12 * i).AddMinutes(5), 8, 1, MaxEndtimeXH.AddHours(12 * i).AddHours(12), employess);
                        }
                        else
                        {
                            TDSXDAO.Instance.InsertTableXH(idResourceXH, id, end.AddMinutes(-5), end, 8, 1, end.AddHours(12), employess);
                        }
                    }
                }
            }
            MessageBox.Show("Cập nhật thành công !".ToUpper());
            try
            {
                string xh = PartDAO.Instance.XH(partCode);
                Process.Start(xh);
            }
            catch
            {
                MessageBox.Show("mã linh kiện chưa có Form xuất hàng".ToUpper());
            }
            this.Close();
        }
    }
}