using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;

using Krs.Ats.IBNet;
using Krs.Ats.IBNet.Contracts;

namespace Kts.Ats.HistoricalDataTestApp
{
    public partial class HistoricalDataTestApp : Form
    {
        private static IBClient client;

        public HistoricalDataTestApp()
        {
            InitializeComponent();
            client = null;
            gbDownloadConfiguration.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                client = new IBClient();
                client.ThrowExceptions = true;
                client.Connect(tbIPAddress.Text, Convert.ToInt32(tbPort.Text), 0);
                client.HistoricalData += client_HistoricalData;
                btnConnect.Text = "Disconnect";
                gbDownloadConfiguration.Enabled = true;
            }
            else
            {
                client.Disconnect();
                client.Dispose();
                client = null;
                btnConnect.Text = "Connect";
                gbDownloadConfiguration.Enabled = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            //New Contract Creation Features
            Contract KTOS = new Contract("GOOG", "Smart", SecurityType.Stock, "USD");

            TimeSpan HistoricalTimeSpan = new TimeSpan(10, 0, 0, 0);
            DateTime HistoricalEndTime = new DateTime();
            HistoricalEndTime = DateTime.Now;

            client.RequestHistoricalData(14, KTOS, HistoricalEndTime, HistoricalTimeSpan, BarSize.OneDay, HistoricalDataType.BidAsk, 1);
        }

        void client_HistoricalData(object sender, HistoricalDataEventArgs e)
        {
            string[] NewRow = new string[] { e.RequestId.ToString(), e.RecordNumber.ToString(), e.RecordTotal.ToString(), e.Date.ToString(), e.Open.ToString(), e.High.ToString(), e.Low.ToString(), e.Close.ToString(), e.Wap.ToString(), e.Volume.ToString(), e.Trades.ToString(), e.HasGaps.ToString() };
            dgvHistoricalData.Invoke((MethodInvoker)delegate { dgvHistoricalData.Rows.Add(NewRow); });
        }
    }
}
