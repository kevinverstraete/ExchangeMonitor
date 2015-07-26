namespace ExchangeMonitor
{
    partial class MainForm
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
      this.components = new System.ComponentModel.Container();
      this.DataGrid = new System.Windows.Forms.DataGridView();
      this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.TickerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BollingerUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.BollingerLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.PullTimer = new System.Windows.Forms.Timer(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.panel1 = new System.Windows.Forms.Panel();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.button4 = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.button5 = new System.Windows.Forms.Button();
      this.button6 = new System.Windows.Forms.Button();
      this.lblRemove = new System.Windows.Forms.Label();
      this.textBox2 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
      this.panel1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // DataGrid
      // 
      this.DataGrid.AllowUserToAddRows = false;
      this.DataGrid.AllowUserToDeleteRows = false;
      this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastUpdate,
            this.Ticker,
            this.TickerName,
            this.Rate,
            this.BollingerUpper,
            this.BollingerLower});
      this.DataGrid.Location = new System.Drawing.Point(3, 64);
      this.DataGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.DataGrid.Name = "DataGrid";
      this.DataGrid.ReadOnly = true;
      this.DataGrid.RowHeadersVisible = false;
      this.DataGrid.RowTemplate.Height = 24;
      this.DataGrid.Size = new System.Drawing.Size(1047, 478);
      this.DataGrid.TabIndex = 0;
      // 
      // LastUpdate
      // 
      this.LastUpdate.HeaderText = "Last Update";
      this.LastUpdate.Name = "LastUpdate";
      this.LastUpdate.ReadOnly = true;
      // 
      // Ticker
      // 
      this.Ticker.HeaderText = "Ticker";
      this.Ticker.Name = "Ticker";
      this.Ticker.ReadOnly = true;
      // 
      // TickerName
      // 
      this.TickerName.HeaderText = "Name";
      this.TickerName.Name = "TickerName";
      this.TickerName.ReadOnly = true;
      // 
      // Rate
      // 
      this.Rate.HeaderText = "Rate";
      this.Rate.Name = "Rate";
      this.Rate.ReadOnly = true;
      // 
      // BollingerUpper
      // 
      this.BollingerUpper.HeaderText = "Bollinger Upper";
      this.BollingerUpper.Name = "BollingerUpper";
      this.BollingerUpper.ReadOnly = true;
      // 
      // BollingerLower
      // 
      this.BollingerLower.HeaderText = "Bollinger Lower";
      this.BollingerLower.Name = "BollingerLower";
      this.BollingerLower.ReadOnly = true;
      // 
      // PullTimer
      // 
      this.PullTimer.Enabled = true;
      this.PullTimer.Interval = 2000;
      this.PullTimer.Tick += new System.EventHandler(this.TimerPull_Tick);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(13, 571);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(141, 23);
      this.button1.TabIndex = 1;
      this.button1.Text = "Add Ticker";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // panel1
      // 
      this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel1.Controls.Add(this.button3);
      this.panel1.Controls.Add(this.button2);
      this.panel1.Controls.Add(this.textBox1);
      this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.panel1.Location = new System.Drawing.Point(287, 267);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(267, 151);
      this.panel1.TabIndex = 2;
      this.panel1.Visible = false;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(32, 25);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(199, 22);
      this.textBox1.TabIndex = 0;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(32, 66);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(75, 23);
      this.button2.TabIndex = 1;
      this.button2.Text = "OK";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.button2_Click);
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(156, 66);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(75, 23);
      this.button3.TabIndex = 2;
      this.button3.Text = "Cancel";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click);
      // 
      // button4
      // 
      this.button4.Location = new System.Drawing.Point(183, 571);
      this.button4.Name = "button4";
      this.button4.Size = new System.Drawing.Size(143, 23);
      this.button4.TabIndex = 3;
      this.button4.Text = "Remove Ticker";
      this.button4.UseVisualStyleBackColor = true;
      this.button4.Click += new System.EventHandler(this.button4_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.textBox2);
      this.panel2.Controls.Add(this.lblRemove);
      this.panel2.Controls.Add(this.button6);
      this.panel2.Controls.Add(this.button5);
      this.panel2.Location = new System.Drawing.Point(287, 161);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(267, 100);
      this.panel2.TabIndex = 4;
      this.panel2.Visible = false;
      // 
      // button5
      // 
      this.button5.Location = new System.Drawing.Point(17, 64);
      this.button5.Name = "button5";
      this.button5.Size = new System.Drawing.Size(75, 23);
      this.button5.TabIndex = 0;
      this.button5.Text = "OK";
      this.button5.UseVisualStyleBackColor = true;
      // 
      // button6
      // 
      this.button6.Location = new System.Drawing.Point(173, 64);
      this.button6.Name = "button6";
      this.button6.Size = new System.Drawing.Size(75, 23);
      this.button6.TabIndex = 1;
      this.button6.Text = "Cancel";
      this.button6.UseVisualStyleBackColor = true;
      // 
      // lblRemove
      // 
      this.lblRemove.AutoSize = true;
      this.lblRemove.Location = new System.Drawing.Point(14, 19);
      this.lblRemove.Name = "lblRemove";
      this.lblRemove.Size = new System.Drawing.Size(60, 17);
      this.lblRemove.TabIndex = 2;
      this.lblRemove.Text = "Remove";
      // 
      // textBox2
      // 
      this.textBox2.Location = new System.Drawing.Point(93, 19);
      this.textBox2.Name = "textBox2";
      this.textBox2.Size = new System.Drawing.Size(100, 22);
      this.textBox2.TabIndex = 3;
      this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1052, 710);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.button4);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.DataGrid);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "MainForm";
      this.Text = "Exchange Monitor";
      ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Timer PullTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerLower;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblRemove;

    }
}

