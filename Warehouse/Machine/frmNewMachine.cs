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
using DTO;
using DAO;
using DevExpress.XtraGrid.Views.Grid;

namespace WareHouse.Machine
{
    public partial class frmNewMachine : DevExpress.XtraEditors.XtraForm
    {
        public frmNewMachine()
        {
            InitializeComponent();
            LoadControl();
            gridView1.CustomDrawRowIndicator += gridView1_CustomDrawRowIndicator;
        }
        public EventHandler LamMoi;
        void LoadControl()
        {
            lblMachineCode.Text = "THÔNG TIN CHI TIẾT , MÁY " + Kun_Static.MachineCode;
            LoadForm();
            LoadData();
        }
        void LoadForm()
        {
            string machineCode = Kun_Static.MachineCode;
            MachineDTO machineDTO = MachineDAO.Instance.GetMachine(machineCode);
            List<MachineDetailDTO> listM = MachineDetailDAO.Instance.GetListMachineDetail(machineCode);
            int idDevide = machineDTO.Device;
            int month = (int)Math.Ceiling(((DateTime.Now - machineDTO.DateSX.Value).TotalDays) / 30);
            if (listM.Count > 0)
            {
                int dem = 0;
                long idDetail = 0;
                string dateSx = "";
                foreach (MachineDetailDTO item in listM)
                {
                    dem++;
                    if (dem == 8)
                    {
                        dateSx = machineDTO.DateSX.Value.Day.ToString() + "/" + machineDTO.DateSX.Value.Month.ToString() + "/" + machineDTO.DateSX.Value.Year.ToString();
                        idDetail = item.Id;
                    }
                    if (dem == 11)
                    {
                        int col2 = 0;
                        try
                        {
                            col2 = int.Parse(item.Col2);
                        }
                        catch
                        {
                        }
                        if (col2 != month)
                        {
                            MachineDetailDAO.Instance.UpdateMachineDetail(item.Id, machineCode, "Thời gian sử dụng", month.ToString(), item.Col3);
                            MachineDetailDAO.Instance.UpdateMachineDetail(idDetail, machineCode, item.Col1, dateSx, item.Col3);
                        }
                    }
                }
            }
        }
        void LoadData()
        {
            GCDataMaIn.DataSource = MachineDetailDAO.Instance.GetListMachineDetail(Kun_Static.MachineCode);
        }
        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!gridView1.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gridView1); }));
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string machineCode = Kun_Static.MachineCode;
            if (MessageBox.Show("bạn muốn lưu thông tin này ?".ToUpper(), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    long Id = long.Parse(gridView1.GetRowCellValue(i, "Id").ToString());
                    string Col1 = gridView1.GetRowCellValue(i, "Col1").ToString();
                    string Col2 = gridView1.GetRowCellValue(i, "Col2").ToString();
                    MachineDetailDAO.Instance.UpdateMachineDetail(Id, machineCode, Col1, Col2, "");
                }
                LoadControl();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            #region Machine Detail
            List<MachineDetailDTO> listM = MachineDetailDAO.Instance.GetListMachineDetail(Kun_Static.MachineCode);
            if(listM.Count > 0)
            {

            }
            else
            {
                string MachineCode = Kun_Static.MachineCode;
                string Col1 = "";
                string Col2 = "";
                string Col3 = "";
                MachineDTO machineDTO = MachineDAO.Instance.GetMachine(MachineCode);
                for (int i = 1; i <= 19; i++)
                {
                    switch (i)
                    {
                        case 1:
                            {
                                Col1 = "Tên máy";
                                Col2 = machineDTO.MachineName;
                            }
                            break;
                        case 2:
                            {
                                Col1 = "Mã máy";
                                Col2 = machineDTO.MachineCode;
                            }
                            break;
                        case 3:
                            {
                                Col1 = "Nhà sản xuất";
                                Col2 = machineDTO.MachineMake;
                            }
                            break;
                        case 4:
                            {
                                Col1 = "Ngày sản xuất";
                                Col2 = machineDTO.DateMaker;
                            }
                            break;
                        case 5:
                            {
                                Col1 = "Số seri";
                                Col2 = machineDTO.MachineInfor;
                            }
                            break;
                        case 6:
                            {
                                Col1 = "Ngày nhập";
                                Col2 = machineDTO.DateInput.Value.Day.ToString() + "/" + machineDTO.DateInput.Value.Month.ToString() + "/" + machineDTO.DateInput.Value.Year.ToString();
                            }
                            break;
                        case 7:
                            Col1 = "Nhà cung cấp";
                            Col2 = machineDTO.Vendor;
                            break;
                        case 8:
                            {
                                Col1 = "Ngày sử dụng";
                                Col2 = machineDTO.DateSX.Value.Day.ToString() + "/" + machineDTO.DateSX.Value.Month.ToString() + "/" + machineDTO.DateSX.Value.Year.ToString();
                            }
                            break;
                        case 9:
                            Col1 = "Điện áp sử dụng";
                            Col2 = "";
                            break;
                        case 10:
                            Col1 = "Mã tài sản cố định";
                            Col2 = machineDTO.CodeTSCD;
                            break;
                        case 11:
                            Col1 = "Thời gian sử dụng";
                            Col2 = "";
                            break;
                        default:
                            {
                                Col1 = "";
                                Col2 = "";
                            }
                            break;
                    }
                    MachineDetailDAO.Instance.InsertMachineDetail(MachineCode, Col1, Col2, Col3);
                }
                LoadControl();
            }
            #endregion
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            MachineDetailDAO.Instance.InsertMachineDetail(Kun_Static.MachineCode, "", "", "");
            LoadControl();
        }

        private void frmNewMachine_FormClosing(object sender, FormClosingEventArgs e)
        {
            LamMoi?.Invoke(sender, e);
        }
    }
}