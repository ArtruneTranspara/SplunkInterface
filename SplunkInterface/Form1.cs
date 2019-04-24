using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplunkInterface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ButtonRun_Click(object sender, EventArgs e)
        {

            ListBoxResults.Text = "Running";
           await Program.run(textBoxQuery.Text.ToString(), ListBoxResults);
            //index=main | stats latest(_time) as _time, latest(WIN_D88BDT7F7NO_Memory_Available MBytes)
            //index=main|bucket _time span=5m | stats avg(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value by _time
            //index=main earliest=-24h@h latest=now | fields + WIN_D88BDT7F7NO_Memory_Available MBytes
        }
    }
}
