namespace Kts.Ats.HistoricalDataTestApp
{
    partial class HistoricalDataTestApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoricalDataTestApp));
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSymbol = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDuration = new System.Windows.Forms.ComboBox();
            this.cbDurationUnits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDownload = new System.Windows.Forms.Button();
            this.dgvHistoricalData = new System.Windows.Forms.DataGridView();
            this.requestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.high = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.low = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.close = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasGaps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDownloadConfiguration = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricalData)).BeginInit();
            this.gbDownloadConfiguration.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(15, 17);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(72, 20);
            this.tbIPAddress.TabIndex = 0;
            this.tbIPAddress.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP Address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(185, 17);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(41, 20);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "27782";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(304, 17);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Symbol";
            // 
            // tbSymbol
            // 
            this.tbSymbol.Location = new System.Drawing.Point(16, 28);
            this.tbSymbol.Name = "tbSymbol";
            this.tbSymbol.Size = new System.Drawing.Size(41, 20);
            this.tbSymbol.TabIndex = 5;
            this.tbSymbol.Text = "7496";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "ddd, MMMM dd, yyyy      hh:mm:ss tt";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(161, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(244, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "End Time";
            // 
            // cbDuration
            // 
            this.cbDuration.FormattingEnabled = true;
            this.cbDuration.Items.AddRange(new object[] {
            "1",
            "5",
            "15",
            "30",
            "60",
            "1",
            "7",
            "14",
            "30",
            "180",
            "365"});
            this.cbDuration.Location = new System.Drawing.Point(265, 54);
            this.cbDuration.Name = "cbDuration";
            this.cbDuration.Size = new System.Drawing.Size(52, 21);
            this.cbDuration.TabIndex = 9;
            this.cbDuration.Text = "30";
            // 
            // cbDurationUnits
            // 
            this.cbDurationUnits.FormattingEnabled = true;
            this.cbDurationUnits.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days",
            "Years"});
            this.cbDurationUnits.Location = new System.Drawing.Point(332, 54);
            this.cbDurationUnits.Name = "cbDurationUnits";
            this.cbDurationUnits.Size = new System.Drawing.Size(73, 21);
            this.cbDurationUnits.TabIndex = 10;
            this.cbDurationUnits.Text = "Days";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(411, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Duration";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "11";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1 secs",
            "5 secs",
            "15 secs",
            "30 secs",
            "1 min",
            "2 mins",
            "5 mins",
            "15 mins",
            "30 mins",
            "1 hour",
            "1 day",
            "1 week",
            "1 month",
            "1 year"});
            this.comboBox1.Location = new System.Drawing.Point(284, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.Text = "1 Day";
            this.comboBox1.ValueMember = "11";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(411, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Bar Size";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(16, 79);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 14;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // dgvHistoricalData
            // 
            this.dgvHistoricalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistoricalData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.requestId,
            this.recordNumber,
            this.recordTotal,
            this.date,
            this.open,
            this.high,
            this.low,
            this.close,
            this.wap,
            this.volume,
            this.trades,
            this.hasGaps});
            this.dgvHistoricalData.Location = new System.Drawing.Point(12, 177);
            this.dgvHistoricalData.Name = "dgvHistoricalData";
            this.dgvHistoricalData.Size = new System.Drawing.Size(813, 459);
            this.dgvHistoricalData.TabIndex = 15;
            // 
            // requestId
            // 
            this.requestId.HeaderText = "Request Id";
            this.requestId.Name = "requestId";
            this.requestId.ReadOnly = true;
            this.requestId.Width = 55;
            // 
            // recordNumber
            // 
            this.recordNumber.HeaderText = "Record Number";
            this.recordNumber.Name = "recordNumber";
            this.recordNumber.ReadOnly = true;
            this.recordNumber.Width = 55;
            // 
            // recordTotal
            // 
            this.recordTotal.HeaderText = "Record Total";
            this.recordTotal.Name = "recordTotal";
            this.recordTotal.ReadOnly = true;
            this.recordTotal.Width = 55;
            // 
            // date
            // 
            this.date.HeaderText = "Date";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            this.date.Width = 140;
            // 
            // open
            // 
            this.open.HeaderText = "Open";
            this.open.Name = "open";
            this.open.ReadOnly = true;
            this.open.Width = 55;
            // 
            // high
            // 
            this.high.HeaderText = "High";
            this.high.Name = "high";
            this.high.ReadOnly = true;
            this.high.Width = 55;
            // 
            // low
            // 
            this.low.HeaderText = "Low";
            this.low.Name = "low";
            this.low.ReadOnly = true;
            this.low.Width = 55;
            // 
            // close
            // 
            this.close.HeaderText = "Close";
            this.close.Name = "close";
            this.close.ReadOnly = true;
            this.close.Width = 55;
            // 
            // wap
            // 
            this.wap.HeaderText = "WAP";
            this.wap.Name = "wap";
            this.wap.ReadOnly = true;
            this.wap.Width = 55;
            // 
            // volume
            // 
            this.volume.HeaderText = "Volume";
            this.volume.Name = "volume";
            this.volume.ReadOnly = true;
            this.volume.Width = 55;
            // 
            // trades
            // 
            this.trades.HeaderText = "Trades";
            this.trades.Name = "trades";
            this.trades.ReadOnly = true;
            this.trades.Width = 55;
            // 
            // hasGaps
            // 
            this.hasGaps.HeaderText = "Has Gaps";
            this.hasGaps.Name = "hasGaps";
            this.hasGaps.ReadOnly = true;
            this.hasGaps.Width = 55;
            // 
            // gbDownloadConfiguration
            // 
            this.gbDownloadConfiguration.Controls.Add(this.tbSymbol);
            this.gbDownloadConfiguration.Controls.Add(this.label3);
            this.gbDownloadConfiguration.Controls.Add(this.btnDownload);
            this.gbDownloadConfiguration.Controls.Add(this.dateTimePicker1);
            this.gbDownloadConfiguration.Controls.Add(this.label6);
            this.gbDownloadConfiguration.Controls.Add(this.label4);
            this.gbDownloadConfiguration.Controls.Add(this.comboBox1);
            this.gbDownloadConfiguration.Controls.Add(this.cbDuration);
            this.gbDownloadConfiguration.Controls.Add(this.label5);
            this.gbDownloadConfiguration.Controls.Add(this.cbDurationUnits);
            this.gbDownloadConfiguration.Location = new System.Drawing.Point(12, 46);
            this.gbDownloadConfiguration.Name = "gbDownloadConfiguration";
            this.gbDownloadConfiguration.Size = new System.Drawing.Size(477, 125);
            this.gbDownloadConfiguration.TabIndex = 16;
            this.gbDownloadConfiguration.TabStop = false;
            this.gbDownloadConfiguration.Text = "Download Configuration";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(514, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(282, 151);
            this.textBox1.TabIndex = 17;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // HistoricalDataTestApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 653);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gbDownloadConfiguration);
            this.Controls.Add(this.dgvHistoricalData);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbIPAddress);
            this.Name = "HistoricalDataTestApp";
            this.Text = "Historical Data Test App";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistoricalData)).EndInit();
            this.gbDownloadConfiguration.ResumeLayout(false);
            this.gbDownloadConfiguration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbSymbol;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDuration;
        private System.Windows.Forms.ComboBox cbDurationUnits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.DataGridView dgvHistoricalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn requestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn open;
        private System.Windows.Forms.DataGridViewTextBoxColumn high;
        private System.Windows.Forms.DataGridViewTextBoxColumn low;
        private System.Windows.Forms.DataGridViewTextBoxColumn close;
        private System.Windows.Forms.DataGridViewTextBoxColumn wap;
        private System.Windows.Forms.DataGridViewTextBoxColumn volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn trades;
        private System.Windows.Forms.DataGridViewTextBoxColumn hasGaps;
        private System.Windows.Forms.GroupBox gbDownloadConfiguration;
        private System.Windows.Forms.TextBox textBox1;
    }
}

