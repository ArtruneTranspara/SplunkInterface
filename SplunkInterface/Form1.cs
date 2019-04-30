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
            comboBoxCallType.SelectedIndex = 0;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void ButtonRun_Click(object sender, EventArgs e)
        {
            ListBoxResults.Items.Clear();
            try
            {
                 SearchType searchType = (SearchType)comboBoxCallType.SelectedIndex;
                
                 switch(searchType)
                  {
                    case SearchType.OPEN_QUERY:
                        var res = await Program.client.OpenQuery(textBoxQuery.Text.ToString());
                        SplunkClient.PrintResults(res, ListBoxResults);
                        break;
                    case SearchType.VERIFY_CONNECTION:
                        var verify = await Program.client.VerifyConnectionAsync();
                        MessageBox.Show(verify ? "Connection succesful": "Connection failed");
                        break;
                    case SearchType.GET_CURRENT_VALUE:
                        res = await Program.client.GetCurrentValueAsync(textBoxQuery.Text.ToString());
                        SplunkClient.PrintResults(res, ListBoxResults);
                        break;
                    case SearchType.GET_HISTORICAL_VALUE:
                        res = await Program.client.getHistoricalValueAsync(textBoxQuery.Text.ToString(), textBoxEarliestDate.Text, textBoxLatestDate.Text);
                        SplunkClient.PrintResults(res, ListBoxResults);
                        break;
                    case SearchType.GET_TREND_DATA:
                        res = await Program.client.getTrendDataAsync(textBoxQuery.Text.ToString(), textBoxEarliestDate.Text, textBoxLatestDate.Text, textBoxBucketSize.Text);
                        SplunkClient.PrintResults(res, ListBoxResults);
                        break;
                }
     


             }
             catch (Exception ex)
             {
                await Program.client.LoginAsync();
                Console.WriteLine(ex);
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

        private void comboBoxCallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBoxResults.Items.Clear();
            ListBoxResults.Items.Add("");
        }
    }
}
