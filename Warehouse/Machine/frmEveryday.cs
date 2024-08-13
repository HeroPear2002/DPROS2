using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Base;
using System.Diagnostics;

namespace WareHouse.Machine
{
    public partial class frmEveryday : Form
    {
        public frmEveryday()
        {
            InitializeComponent();
            LoadControl();

        }
        string urlPath = @"\\192.168.2.10\datasave\FILE";
        void LoadControl()
        {
            LoadStatus();
            LoadData();
            int id = MachineDAO.Instance.GetMachine(Kun_Static.MachineCode).Device;
            string nameMachine = MachineDAO.Instance.GetMachine(Kun_Static.MachineCode).MachineName;
            Group.Text = ("Danh sách hạng mục cần kiểm tra máy : " + Kun_Static.MachineCode + "=> " + nameMachine);
        }
        public EventHandler LamMoi;
        void LoadStatus()
        {
            RepositoryItemComboBox _riEditor = new RepositoryItemComboBox();
            _riEditor.Items.AddRange(new string[] { "OK", "NG", "OK Có DK", "STOP" });
            GCData.RepositoryItems.Add(_riEditor);
            colResult.ColumnEdit = _riEditor;
        }
        void LoadData()
        {
            DateTime today = DateTime.Now;
            DateTime date1 = today.Date;
            DateTime date2 = date1.AddDays(1).AddMilliseconds(-10);
            string MachineCode = Kun_Static.MachineCode;
            List<HistoryDeviceDTO> listH = MachineDAO.Instance.GetListHistoryDeviceShort(date1, date2, MachineCode);
            List<CheckDeviceDTO> listC = MachineDAO.Instance.GetListEveryDay(MachineCode);
            int status = MachineDAO.Instance.StatusMachineByCode(MachineCode);
            if (listH.Count == listC.Count)
            {
                colReality.FieldName = "DataCount";
                colEmployess.Visible = true;
                colResult.Visible = true;
                btnSave.Enabled = false;
                GCData.DataSource = listH;
            }
            else if (listH.Count > 0)
            {
                List<CheckDeviceDTO> listCNew = new List<CheckDeviceDTO>();
                colEmployess.Visible = true;
                foreach (CheckDeviceDTO item in listC)
                {
                    string employess = "";
                    string note = "";
                    string result = "";
                    string reality = "";
                    foreach (HistoryDeviceDTO jtem in listH.Where(x => x.IdRelationShip == item.IdRelationShip))
                    {
                        employess = jtem.Employess;
                        note = jtem.Note;
                        result = jtem.Result;
                        reality = jtem.DataCount;
                    }
                    listCNew.Add(new CheckDeviceDTO(item.IdRelationShip, item.IdCategory, employess.ToUpper(), item.MachineCode, note, item.NameCategory, item.Detail, item.Method, item.Limit, result, item.TimeTT, item.Timer, reality));
                }
                GCData.DataSource = listCNew;
            }
            else
            {
                colResult.Visible = true;
                colEmployess.Visible = false;
                GCData.DataSource = listC;
            }

        }
        bool LoadCondition()
        {
            int dem = 0;
            try
            {
                int i = 0;
                foreach (var item in gridView1.GetSelectedRows())
                {
                    var obj = gridView1.GetRowCellValue(item, "IdCategory");
                    try
                    {
                        int IdRelationShip = int.Parse(obj.ToString());
                        string count = gridView1.GetRowCellValue(item, "Reality").ToString();
                        string Note = gridView1.GetRowCellValue(item, "Note").ToString();
                        string status = gridView1.GetRowCellValue(item, "Result").ToString();
                        int confirm = MachineDAO.Instance.ConfirmCategory(IdRelationShip);
                        if (confirm == 1)
                        {
                            float Reality = (float)Convert.ToDouble(gridView1.GetRowCellValue(item, "Reality").ToString());
                            string detailString = gridView1.GetRowCellValue(item, "Detail").ToString();
                            string[] array = detailString.Split('~');
                            float min = (float)Convert.ToDouble(array[0].Trim());
                            float max = (float)Convert.ToDouble(array[1].Trim());
                            if (Reality < min || Reality > max)
                            {
                                if (status == "OK" || status == "STOP")
                                {
                                    dem++;
                                }
                            }
                            else
                            {
                                gridView1.SetRowCellValue(item, "Result", "OK");
                            }
                        }
                        else
                        {
                            if (status == "NG" || status == "OK Có DK")
                            {
                                if (Note.Length == 0)
                                {
                                    dem++;
                                }
                            }
                            else
                            {
                                if (status.Length == 0)
                                {
                                    dem++;
                                }
                            }
                        }
                    }
                    catch
                    {
                        dem++;
                    }
                    i++;
                }
                if (i == 0)
                {
                    dem++;
                }
            }
            catch
            {
                dem++;
            }
            if (dem == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        int LoadStatusByName(string str)
        {
            if (str == "OK")
            {
                return 1;
            }
            else if (str == "NG")
            {
                return 5;
            }
            else if (str == "OK Có DK")
            {
                return 4;
            }
            else if (str == "STOP")
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
        string LoadStatusById(int id)
        {
            if (id == 1)
            {
                return "OK";
            }
            else if (id == 2)
            {
                return "NG";
            }
            else if (id == 3)
            {
                return "OK Có DK";
            }
            else if (id == 4)
            {
                return "STOP";
            }
            else
            {
                return "";
            }
        }
        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (LoadCondition())
            {
                string Employees = Kun_Static.accountDTO.UserName.ToUpper();
                System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                DateTime today2 = DateTime.Now.Date.AddHours(+24);
                DateTime today = DateTime.Now;
                DateTime today1 = DateTime.Now.Date;
                try
                {
                    if (MessageBox.Show("bạn muốn lưu thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        int sts = 1;
                        foreach (var item in gridView1.GetSelectedRows())
                        {
                            var obj = gridView1.GetRowCellValue(item, "IdRelationShip");
                            int IdRelationShip = int.Parse(obj.ToString());
                            string count = gridView1.GetRowCellValue(item, "Reality").ToString();
                            string Note = gridView1.GetRowCellValue(item, "Note").ToString();
                            string status = gridView1.GetRowCellValue(item, "Result").ToString();
                            int statusHD = LoadStatusByName(status);
                            if (statusHD > sts)
                            {
                                sts = statusHD;
                            }
                            int CheckTest = MachineDAO.Instance.TestCheckHistory(IdRelationShip, today1, today2);
                            if (CheckTest == -1)
                            {
                                MachineDAO.Instance.InsertHistoryDevice(IdRelationShip, count, statusHD, today, Employees, Note, status);
                                MachineDAO.Instance.UpdateStatusRelationShip(IdRelationShip, 0);
                                MachineDAO.Instance.UpdateTimeRelationShip(IdRelationShip, 0);
                            }
                            else
                            {
                                MachineDAO.Instance.UpdateStatusRelationShip(IdRelationShip, 0);
                            }
                        }
                        LoadData();
                        MachineDAO.Instance.UpdateStatusMay(Kun_Static.MachineCode, sts, "");
                    }
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("bạn chưa điền đúng thông tin !".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmEveryDay_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }

        private void GridView1_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
          
           
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if (e.RowHandle >= 0)
            {
                if (e.Column.Name == "colResult")
                {
                    string result = gridView1.GetRowCellValue(e.RowHandle, "Result").ToString();
                    if (result == "NG")
                    {
                        e.Appearance.BackColor = Color.Red;
                    }
                    else if (result == "OK Có DK")
                    {
                        e.Appearance.BackColor = Color.Gray;
                        e.Appearance.ForeColor = Color.White;
                    }
                }
            }
        }

        private void gridView1_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view == null) return;
                if (e.Column.Name == "colReality")
                {
                    string status = view.GetRowCellValue(e.RowHandle, view.Columns["Result"]).ToString();
                    int IdRelationShip = int.Parse(view.GetRowCellValue(e.RowHandle, view.Columns["IdCategory"]).ToString());
                    string count = view.GetRowCellValue(e.RowHandle, view.Columns["Reality"]).ToString();
                    string Note = view.GetRowCellValue(e.RowHandle, view.Columns["Note"]).ToString();
                    int confirm = MachineDAO.Instance.ConfirmCategory(IdRelationShip);
                    if (confirm == 1)
                    {
                        float Reality = (float)Convert.ToDouble(view.GetRowCellValue(e.RowHandle, view.Columns["Reality"]).ToString());
                        string detailString = view.GetRowCellValue(e.RowHandle, view.Columns["Detail"]).ToString();
                        string[] array = detailString.Split('~');
                        float min = (float)Convert.ToDouble(array[0].Trim());
                        float max = (float)Convert.ToDouble(array[1].Trim());
                        if (Reality < min || Reality > max)
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "Result", "NG");
                            status = gridView1.GetRowCellValue(e.RowHandle, "Result").ToString();
                        }
                        else
                        {
                            gridView1.SetRowCellValue(e.RowHandle, "Result", "OK");
                        }
                    }
                }
            }
            catch
            {

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            int id = MachineDAO.Instance.GetMachine(Kun_Static.MachineCode).Device;
            string url = MachineDAO.Instance.GetItemDevice(id).UrlEveryDay;
            if (url.Length > 0)
            {
                string destFile = System.IO.Path.Combine(urlPath, url);
                Process.Start(destFile);
            }
            else
            {
                MessageBox.Show("bạn chưa chọn máy cần xem thông tin chi tiết!\nhoặc máy chưa có thông tin chi tiết".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
