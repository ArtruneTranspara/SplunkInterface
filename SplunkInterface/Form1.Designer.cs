namespace SplunkInterface
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonRun = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxQuery = new System.Windows.Forms.TextBox();
            this.ListBoxResults = new System.Windows.Forms.ListBox();
            this.comboBoxCallType = new System.Windows.Forms.ComboBox();
            this.textBoxEarliestDate = new System.Windows.Forms.TextBox();
            this.textBoxLatestDate = new System.Windows.Forms.TextBox();
            this.textBoxBucketSize = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(12, 75);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(778, 31);
            this.ButtonRun.TabIndex = 0;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Query";
            // 
            // textBoxQuery
            // 
            this.textBoxQuery.Location = new System.Drawing.Point(70, 39);
            this.textBoxQuery.Name = "textBoxQuery";
            this.textBoxQuery.Size = new System.Drawing.Size(1048, 20);
            this.textBoxQuery.TabIndex = 8;
            this.textBoxQuery.Text = "index=main earliest=\"04/24/2019:12:25:00\"  latest=\"04/24/2019:12:31:00\" |bucket _" +
    "time span=5m | stats avg(WIN_D88BDT7F7NO_Memory_Available MBytes) as Value by _t" +
    "ime";
            // 
            // ListBoxResults
            // 
            this.ListBoxResults.FormattingEnabled = true;
            this.ListBoxResults.Location = new System.Drawing.Point(2, 112);
            this.ListBoxResults.Name = "ListBoxResults";
            this.ListBoxResults.Size = new System.Drawing.Size(1116, 277);
            this.ListBoxResults.TabIndex = 10;
            // 
            // comboBoxCallType
            // 
            this.comboBoxCallType.FormattingEnabled = true;
            this.comboBoxCallType.Items.AddRange(new object[] {
            "VerifyConnection",
            "GetCurrentValue",
            "GetHistoricalValue",
            "GetTrendData",
            "OpenQuery"});
            this.comboBoxCallType.Location = new System.Drawing.Point(796, 81);
            this.comboBoxCallType.Name = "comboBoxCallType";
            this.comboBoxCallType.Size = new System.Drawing.Size(322, 21);
            this.comboBoxCallType.TabIndex = 11;
            this.comboBoxCallType.SelectedIndexChanged += new System.EventHandler(this.comboBoxCallType_SelectedIndexChanged);
            // 
            // textBoxEarliestDate
            // 
            this.textBoxEarliestDate.Location = new System.Drawing.Point(12, 13);
            this.textBoxEarliestDate.Name = "textBoxEarliestDate";
            this.textBoxEarliestDate.Size = new System.Drawing.Size(172, 20);
            this.textBoxEarliestDate.TabIndex = 12;
            this.textBoxEarliestDate.Text = "Earliest Date";
            // 
            // textBoxLatestDate
            // 
            this.textBoxLatestDate.Location = new System.Drawing.Point(200, 13);
            this.textBoxLatestDate.Name = "textBoxLatestDate";
            this.textBoxLatestDate.Size = new System.Drawing.Size(172, 20);
            this.textBoxLatestDate.TabIndex = 13;
            this.textBoxLatestDate.Text = "Latest Date";
            // 
            // textBoxBucketSize
            // 
            this.textBoxBucketSize.Location = new System.Drawing.Point(389, 12);
            this.textBoxBucketSize.Name = "textBoxBucketSize";
            this.textBoxBucketSize.Size = new System.Drawing.Size(172, 20);
            this.textBoxBucketSize.TabIndex = 14;
            this.textBoxBucketSize.Text = "Bucket Size, eg 5m";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 409);
            this.Controls.Add(this.textBoxBucketSize);
            this.Controls.Add(this.textBoxLatestDate);
            this.Controls.Add(this.textBoxEarliestDate);
            this.Controls.Add(this.comboBoxCallType);
            this.Controls.Add(this.ListBoxResults);
            this.Controls.Add(this.textBoxQuery);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ButtonRun);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonRun;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxQuery;
        private System.Windows.Forms.ListBox ListBoxResults;
        private System.Windows.Forms.ComboBox comboBoxCallType;
        private System.Windows.Forms.TextBox textBoxEarliestDate;
        private System.Windows.Forms.TextBox textBoxLatestDate;
        private System.Windows.Forms.TextBox textBoxBucketSize;
    }
}

