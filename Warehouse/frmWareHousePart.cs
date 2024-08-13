using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using WareHouse.PC;

namespace WareHouse
{
    public partial class frmWareHousePart : Form
    {

        public frmWareHousePart()
        {

            InitializeComponent();
            LoadControl();
        }
        void LoadControl()
        {
            LoadWarehouse();
            LoadNote();
            LoadWarning();
            A();
            LoadAccount();
        }
        void LoadAccount()
        {
            if(Kun_Static.accountDTO.UserName == "admin")
            {
                btnAdmin.Enabled = true;
            }
            else if(Kun_Static.accountDTO.Type <= 2)
            {
                btnOpenCK.Enabled = true;
            }
            else
            {
                btnOpenCK.Enabled = false;
                btnAdmin.Enabled = false;
            }
        }
        #region VẼ KHO
        void A()
        {
            flpX.Controls.Clear();
            flpX.Height = 37 * WareHouseDAO.TableHeight + 100;
            
            int i = 0;
            List<WareHouseDTO> khoList = WareHouseDAO.Instance.GetListAllWareHouse();
            foreach (WareHouseDTO item in khoList)
            {
                i++;
                Button btn = new Button() { Width = WareHouseDAO.TableWidth, Height = WareHouseDAO.TableHeight };
                if (i == 40 || ((i-40) % 160==0))
                {
                    btn.Margin = new Padding(0, 0, 0, 10);
                }
                else if(i==1 ||((i-1)%40 == 0))
                {
                    btn.Margin = new Padding(0, 0, 10, 0);
                }
                else
                {
                    btn.Margin = new Padding(0);
                }
                btn.Text = item.Name;
                FontFamily f = new FontFamily("Microsoft Sans Serif");
                btn.Font = new Font(f, 8);
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case 0:
                        btn.BackColor = Color.White;
                        btn.Enabled = false;
                        break;
                    case 1:
                        btn.BackColor = Color.White;
                        btn.Enabled = false;
                        break;
                    case 2:
                        btn.BackColor = Color.DodgerBlue;
                        break;
                    case 3:
                        btn.BackColor = Color.Red;
                        break;
                    case 5:
                        if (item.Height > 1)
                        {
                            btn.BackColor = Color.YellowGreen;
                            btn.Enabled = false;
                        }
                        else
                        {
                            btn.BackColor = Color.White;
                            btn.Text = "";
                            btn.FlatAppearance.BorderSize = 0;
                            btn.FlatStyle = FlatStyle.Flat;
                            btn.Enabled = false;
                        }
                        break;
                    case 6:
                        btn.BackColor = Color.Yellow;
                        break;
                    case 7:
                        btn.BackColor = Color.Pink;
                        break;
                    case 8:
                        btn.BackColor = Color.Black;
                        btn.ForeColor = Color.White;
                        break;
                    case 9:
                        btn.BackColor = Color.Purple;
                        btn.ForeColor = Color.White;
                        break;
                    case 10:
                        btn.BackColor = Color.DarkBlue;
                        btn.ForeColor = Color.White;
                        btn.Enabled = false;
                        break;
                    default:
                        btn.BackColor = Color.Orange;
                        break;
                }
                flpX.Controls.Add(btn);
            }
        }
       
        #endregion
     
        private void btnSetup_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmWarehouseSetup f = new frmWarehouseSetup();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadControl();
        }
  
        private void btn_Click(object sender, EventArgs e)
        {
            int idWh = ((sender as Button).Tag as WareHouseDTO).Id;
            Kun_Static.IdWh = idWh;
            frmInforWarehousePart f = new frmInforWarehousePart();
            f.ShowDialog();
        }
        #region Trạng thái kho
        void LoadNote()
        {
            float totalAll = WareHouseDAO.Instance.TotalAll();
            float totalWhite = WareHouseDAO.Instance.TotalWhite();
            float totalBlue = WareHouseDAO.Instance.TotalBlue();
            float totalGreen = WareHouseDAO.Instance.TotalGreen();
            float totalBlack = WareHouseDAO.Instance.TotalBlack();
            float totalYellow = WareHouseDAO.Instance.TotalYellow();
            float totalPink = WareHouseDAO.Instance.TotalPink();
            float totalRed = WareHouseDAO.Instance.TotalRed();
            float totalOrange = WareHouseDAO.Instance.TotalOrange();
            float totalPurple = WareHouseDAO.Instance.TotalPurpel();
            float totalDarkBlue = WareHouseDAO.Instance.TotalDarkBlue();
            lblTotal.Text = totalAll.ToString();
            lblWhite.Text = totalWhite.ToString() + " (" +(Math.Round((totalWhite/totalAll)*100,2))+"% )";
            lblChecking.Text = totalOrange.ToString() + " (" + (Math.Round((totalOrange / totalAll) * 100, 2)) + "% )";
            lblGreen.Text = totalGreen.ToString() + " (" + (Math.Round((totalGreen / totalAll) * 100, 2)) + "% )";
            lblNG.Text = totalRed.ToString() + " (" + (Math.Round((totalRed / totalAll) * 100, 2)) + "% )";
            lblOK.Text = totalBlue.ToString() + " (" + (Math.Round((totalBlue / totalAll) * 100, 2)) + "% )";
            lblOK3.Text = totalBlack.ToString() + " (" + (Math.Round((totalBlack / totalAll) * 100, 2)) + "% )";
            lblQC3.Text = totalYellow.ToString() + " (" + (Math.Round((totalYellow / totalAll) * 100, 2)) + "% )";
            lblQC7.Text = totalPink.ToString() + " (" + (Math.Round((totalPink / totalAll) * 100, 2)) + "% )";
            lblPurple.Text = totalPurple.ToString() + " (" + (Math.Round((totalPurple / totalAll) * 100, 2)) + "% )";
            lbl10.Text = totalDarkBlue.ToString() + " (" + (Math.Round((totalDarkBlue / totalAll) * 100, 2)) + "% )";
        }
        void LoadWarning()
        {
            List<IvenstoryDTO> listI = IventoryPartDAO.Instance.GetListIvenstoryPart();
            DateTime today = DateTime.Now;
            foreach (IvenstoryDTO item in listI)
            {
                int idWH = item.IdWareHouse;
                string status = item.NameStatus;
                int total = (int)(today - item.DateManufacturi).TotalDays;
                switch(status)
                {
                    case "OK":
                        {
                            if(total >=90)
                            {
                                WareHouseDAO.Instance.UpdateStatusWH(idWH, 8);
                            }
                        }
                        break;
                    case "Checking":
                        {
                            if (total >= 3 && total < 7)
                            {
                                WareHouseDAO.Instance.UpdateStatusWH(idWH, 6);
                            }
                            if(total >=7)
                            {
                                WareHouseDAO.Instance.UpdateStatusWH(idWH, 7);
                            }
                        }
                        break;
                    case "Cảnh Báo Vàng":
                        {
                            if (total >= 7)
                            {
                                WareHouseDAO.Instance.UpdateStatusWH(idWH, 7);
                            }
                        }
                        break;
                }
            }
        }
        void LoadWarehouse()
        {
            Thread thread = new Thread(() => {
                while (true)
                {
                    Thread.Sleep(1000);
                    LoadStatus();
                }
            });
            thread.IsBackground = true;
            thread.Start();
        }
        void LoadStatus()
        {
            List<WareHouseDTO> listW = WareHouseDAO.Instance.GetlistWarehouseByStatus();
            foreach (WareHouseDTO item in listW)
            {
                long id = IventoryPartDAO.Instance.MaxIdInput(item.Id);
                if(id !=-1)
                {
                    int statusIn = IventoryPartDAO.Instance.StatusInput(id);
                    if (statusIn != 0)
                    {
                        WareHouseDAO.Instance.UpdateStatusWH(item.Id, 1);
                        //WareHouseDAO.Instance.UpdateYellowWH(item.Id, "O");
                    }
                }
            }
            
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmPainWarehouse f = new frmPainWarehouse();
            f.ShowDialog();
           
        }

        private void btnOpenCK_Click(object sender, EventArgs e)
        {
            string user = Kun_Static.accountDTO.UserName;
            int check = AccountDAO.Instance.CheckAccount(2, Kun_Static.accountDTO.Type, user);
            if (check < 1)
            {
                MessageBox.Show("bạn không có quyền truy cập!".ToUpper(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Kun_Static.IdWh = 8;
            frmEmployessCode f = new frmEmployessCode();
            f.LamMoi += new EventHandler(btnUpdate_Click);
            f.ShowDialog();
        }
    }
}
