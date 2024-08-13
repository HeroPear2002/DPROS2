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

namespace WareHouse.WareHouseMaterial
{
    public partial class frmCheckMacReCycle : DevExpress.XtraEditors.XtraForm
    {
        public frmCheckMacReCycle()
        {
            InitializeComponent();
        }
        List<CheckCycleList> _listC = new List<CheckCycleList>();
        int _check = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(gridView1.RowCount != _listC.Count)
            {
                MessageBox.Show("bạn chưa bắn đủ số lượng bao cần kiểm tra".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (_check == 0)
                {
                    if (_listC.Count != Kun_Static.CountBoxCycle)
                    {
                        Kun_Static.CheckCycle = 0;
                    }
                    else
                    {
                        Kun_Static.CheckCycle = 1;
                    }
                }
                else
                {
                    Kun_Static.CheckCycle = 0;
                }
                this.Close();
            }

        }
        void LoadTimer1()
        {
            if (!txtBarCodeLocation.Text.Contains("&"))
            {
                timer1.Stop();
                MessageBox.Show("mã vạch không đúng".ToUpper(),"ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            txtBarCodeBox.Focus();
            txtBarCodeBox.SelectAll();
        }
        void LoadTimer2()
        {
            int checkCyle = 0;
            if (_listC.Count() > (Kun_Static.CountBoxCycle - 1))
            {
                timer2.Stop();
                MessageBox.Show("bạn đã bắn đủ số lượng mác hãy ấn Lưu hoàn thành việc nhập\n\nẤn hủy để kiểm tra lại số bao cần nhập".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!txtBarCodeBox.Text.Contains("&"))
            {
                timer2.Stop();
                MessageBox.Show("mã vạch không đúng".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkCyle++;
                return;
            }
            string Name = Kun_Static.NameWhMaterial;
            string codeLocation = txtBarCodeLocation.Text;
            string codeBox = txtBarCodeBox.Text;
            string check = codeBox.Split('&')[0] + "&" + Name.ToUpper();
            if (Kun_Static.CheckAdd == "TC" && codeBox.Split('&')[3].ToUpper() != "TC")
            {
                timer2.Stop();
                MessageBox.Show("mã vạch không đúng \n\n bạn hãy bắn mã khác".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkCyle++;
                return;
            }
            if (check.ToUpper() != codeLocation.ToUpper())
            {
                timer2.Stop();
                MessageBox.Show("mã vạch không đúng".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkCyle++;
                return;
            }
            List<CheckCycleList> listC = _listC.Where(x => x.BarCode == codeBox).ToList();
            if (listC.Count > 0)
            {
                timer2.Stop();
                MessageBox.Show("mã vạch đã check rồi \n\n bạn hãy bắn mã khác".ToUpper(), "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                checkCyle++;
                return;
            }
            _listC.Add(new CheckCycleList(codeBox.Split('&')[0], Name.ToUpper(), codeBox));
            _check = checkCyle;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Kun_Static.CheckCycle = 0;
            this.Close();
        }

        private void txtBarCodeLocation_TextChanged(object sender, EventArgs e)
        {
            timer1.Interval = 300;
            timer1.Start();
        }

        private void txtBarCodeBox_TextChanged(object sender, EventArgs e)
        {
            timer2.Interval = 200;
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadTimer1();
            timer1.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LoadTimer2();
            txtBarCodeBox.SelectAll();
            List<CheckCycleList> listC = new List<CheckCycleList>();
            foreach (CheckCycleList item in _listC)
            {
                listC.Add(new CheckCycleList( item.MaterialCode, item.Name, item.BarCode));
            }
            GCData.DataSource = listC;
            timer2.Stop();
        }
        private class CheckCycleList
        {
            private string materialCode;
            private string name;
            private string barCode;

            public CheckCycleList(string materialCode, string name, string barCode)
            {
                MaterialCode = materialCode;
                Name = name;
                BarCode = barCode;
            }

            public string MaterialCode { get => materialCode; set => materialCode = value; }
            public string Name { get => name; set => name = value; }
            public string BarCode { get => barCode; set => barCode = value; }
        }

    }
}