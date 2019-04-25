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

           

            if (Program.client.loggedIn)
            {
                try { 
                 ListBoxResults.Items.Add("Running");
                 await Program.client.search(textBoxQuery.Text.ToString(), ListBoxResults);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    Console.WriteLine("Attempting to reconnect");
                    await Program.client.prep("Administrator", "pa$$word1", "192.168.1.103", "8089");
                    await Program.client.search(textBoxQuery.Text.ToString(), ListBoxResults);
                }
            }




            // VARIABLE STUFF: INDEX, WIN_D88DT7F7NO_memory_available Mbytes, earliest and lastest times

            //latest value (current)
            //index=main | stats latest(_time) as _time, latest(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value


            //value over time (trend)
            //index=main earliest="04/24/2019:12:25:00"  latest="04/24/2019:12:31:00" |bucket _time span=5m | stats avg(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value by _time



            //value in time (historical) AVG OF ALL
            //index=main earliest="04/24/2019:12:16:00"  latest="04/24/2019:12:20:00" | stats avg(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value


            //value in time (historical) closest to latest
            // index = main earliest = "04/24/2019:12:16:00"  latest = "04/24/2019:12:20:00" | stats latest(_time) as _time, latest(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value


            //index=main earliest=-24h@h latest=now | fields + WIN_D88BDT7F7NO_Memory_Available MBytes as Value
        }
    }
}
