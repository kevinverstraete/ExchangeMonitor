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
            this.PullTimer = new System.Windows.Forms.Timer(this.components);
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TickerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BollingerUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BollingerLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
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
            this.DataGrid.Location = new System.Drawing.Point(2, 52);
            this.DataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.Size = new System.Drawing.Size(785, 388);
            this.DataGrid.TabIndex = 0;
            // 
            // PullTimer
            // 
            this.PullTimer.Enabled = true;
            this.PullTimer.Interval = 3000;
            this.PullTimer.Tick += new System.EventHandler(this.timer1_Tick);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 577);
            this.Controls.Add(this.DataGrid);
            this.Name = "MainForm";
            this.Text = "Exchange Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
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

    }
}

