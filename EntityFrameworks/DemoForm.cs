using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworks
{
    public partial class DemoForm : Form
    {
        int inc = 0;
        public DemoForm()
        {
            InitializeComponent();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            inc++;
            txtdemo.Text= inc.ToString();
        }
    }
}
