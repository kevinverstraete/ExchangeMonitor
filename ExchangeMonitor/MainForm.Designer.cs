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
      this.DataGrid = new System.Windows.Forms.DataGridView();
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
      this.DataGrid.Location = new System.Drawing.Point(3, 64);
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
      // Name
      // 
      this.TickerName.HeaderText = "Name";
      this.TickerName.Name = "Name";
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
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1052, 710);
      this.Controls.Add(this.DataGrid);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "MainForm";
      this.Text = "Exchange Monitor";
      ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerLower;

    }
}

