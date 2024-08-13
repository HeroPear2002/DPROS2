using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WareHouse
{
    public partial class frmErrorList : Form
    {
        List<string> errorList;
        public frmErrorList()
        {
            InitializeComponent();
        }
        public frmErrorList(List<string> errorlist)
        {
            errorList = errorlist;
            InitializeComponent();
        }

        private void frmErrorList_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < errorList.Count; i++)
            {
                listBox1.Items.Add(errorList[i]);
            }
        }
    }
}
