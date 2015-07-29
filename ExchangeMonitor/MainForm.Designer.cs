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
            this.btnAddTicker = new System.Windows.Forms.Button();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnAddOk = new System.Windows.Forms.Button();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.btnRemoveTicker = new System.Windows.Forms.Button();
            this.pnlRemove = new System.Windows.Forms.Panel();
            this.tbRemoveTicker = new System.Windows.Forms.TextBox();
            this.lblRemove = new System.Windows.Forms.Label();
            this.btnRemoveCancel = new System.Windows.Forms.Button();
            this.btnRemoveOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.pnlRemove.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LastUpdate,
            this.Ticker,
            this.TickerName,
            this.Rate,
            this.BollingerUpper,
            this.BollingerLower});
            this.DataGrid.Location = new System.Drawing.Point(2, 63);
            this.DataGrid.Margin = new System.Windows.Forms.Padding(2);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.Size = new System.Drawing.Size(785, 377);
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
            // btnAddTicker
            // 
            this.btnAddTicker.Location = new System.Drawing.Point(10, 464);
            this.btnAddTicker.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddTicker.Name = "btnAddTicker";
            this.btnAddTicker.Size = new System.Drawing.Size(106, 19);
            this.btnAddTicker.TabIndex = 1;
            this.btnAddTicker.Text = "Add Ticker";
            this.btnAddTicker.UseVisualStyleBackColor = true;
            this.btnAddTicker.Click += new System.EventHandler(this.btnAddTicker_Click);
            // 
            // pnlAdd
            // 
            this.pnlAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlAdd.Controls.Add(this.btnAddCancel);
            this.pnlAdd.Controls.Add(this.btnAddOk);
            this.pnlAdd.Controls.Add(this.tbAdd);
            this.pnlAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlAdd.Location = new System.Drawing.Point(215, 217);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(201, 123);
            this.pnlAdd.TabIndex = 2;
            this.pnlAdd.Visible = false;
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(117, 54);
            this.btnAddCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCancel.Name = "btnAddCancel";
            this.btnAddCancel.Size = new System.Drawing.Size(56, 19);
            this.btnAddCancel.TabIndex = 2;
            this.btnAddCancel.Text = "Cancel";
            this.btnAddCancel.UseVisualStyleBackColor = true;
            this.btnAddCancel.Click += new System.EventHandler(this.btnAddCancel_Click);
            // 
            // btnAddOk
            // 
            this.btnAddOk.Location = new System.Drawing.Point(24, 54);
            this.btnAddOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddOk.Name = "btnAddOk";
            this.btnAddOk.Size = new System.Drawing.Size(56, 19);
            this.btnAddOk.TabIndex = 1;
            this.btnAddOk.Text = "OK";
            this.btnAddOk.UseVisualStyleBackColor = true;
            this.btnAddOk.Click += new System.EventHandler(this.btnAddOk_Click);
            // 
            // tbAdd
            // 
            this.tbAdd.Location = new System.Drawing.Point(24, 20);
            this.tbAdd.Margin = new System.Windows.Forms.Padding(2);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(150, 20);
            this.tbAdd.TabIndex = 0;
            // 
            // btnRemoveTicker
            // 
            this.btnRemoveTicker.Location = new System.Drawing.Point(137, 464);
            this.btnRemoveTicker.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveTicker.Name = "btnRemoveTicker";
            this.btnRemoveTicker.Size = new System.Drawing.Size(107, 19);
            this.btnRemoveTicker.TabIndex = 3;
            this.btnRemoveTicker.Text = "Remove Ticker";
            this.btnRemoveTicker.UseVisualStyleBackColor = true;
            this.btnRemoveTicker.Click += new System.EventHandler(this.btnRemoveTicker_Click);
            // 
            // pnlRemove
            // 
            this.pnlRemove.Controls.Add(this.tbRemoveTicker);
            this.pnlRemove.Controls.Add(this.lblRemove);
            this.pnlRemove.Controls.Add(this.btnRemoveCancel);
            this.pnlRemove.Controls.Add(this.btnRemoveOk);
            this.pnlRemove.Location = new System.Drawing.Point(215, 131);
            this.pnlRemove.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRemove.Name = "pnlRemove";
            this.pnlRemove.Size = new System.Drawing.Size(200, 81);
            this.pnlRemove.TabIndex = 4;
            this.pnlRemove.Visible = false;
            // 
            // tbRemoveTicker
            // 
            this.tbRemoveTicker.Location = new System.Drawing.Point(70, 15);
            this.tbRemoveTicker.Margin = new System.Windows.Forms.Padding(2);
            this.tbRemoveTicker.Name = "tbRemoveTicker";
            this.tbRemoveTicker.Size = new System.Drawing.Size(76, 20);
            this.tbRemoveTicker.TabIndex = 3;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.Location = new System.Drawing.Point(10, 15);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(47, 13);
            this.lblRemove.TabIndex = 2;
            this.lblRemove.Text = "Remove";
            // 
            // btnRemoveCancel
            // 
            this.btnRemoveCancel.Location = new System.Drawing.Point(130, 52);
            this.btnRemoveCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveCancel.Name = "btnRemoveCancel";
            this.btnRemoveCancel.Size = new System.Drawing.Size(56, 19);
            this.btnRemoveCancel.TabIndex = 1;
            this.btnRemoveCancel.Text = "Cancel";
            this.btnRemoveCancel.UseVisualStyleBackColor = true;
            this.btnRemoveCancel.Click += new System.EventHandler(this.btnRemoveCancel_Click);
            // 
            // btnRemoveOk
            // 
            this.btnRemoveOk.Location = new System.Drawing.Point(13, 52);
            this.btnRemoveOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveOk.Name = "btnRemoveOk";
            this.btnRemoveOk.Size = new System.Drawing.Size(56, 19);
            this.btnRemoveOk.TabIndex = 0;
            this.btnRemoveOk.Text = "OK";
            this.btnRemoveOk.UseVisualStyleBackColor = true;
            this.btnRemoveOk.Click += new System.EventHandler(this.btnRemoveOk_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(789, 577);
            this.Controls.Add(this.pnlRemove);
            this.Controls.Add(this.btnRemoveTicker);
            this.Controls.Add(this.pnlAdd);
            this.Controls.Add(this.btnAddTicker);
            this.Controls.Add(this.DataGrid);
            this.Name = "MainForm";
            this.Text = "Exchange Monitor";
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.pnlAdd.ResumeLayout(false);
            this.pnlAdd.PerformLayout();
            this.pnlRemove.ResumeLayout(false);
            this.pnlRemove.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button btnAddTicker;
        private System.Windows.Forms.Panel pnlAdd;
        private System.Windows.Forms.Button btnAddCancel;
        private System.Windows.Forms.Button btnAddOk;
        private System.Windows.Forms.TextBox tbAdd;
        private System.Windows.Forms.Button btnRemoveTicker;
        private System.Windows.Forms.Panel pnlRemove;
        private System.Windows.Forms.Button btnRemoveCancel;
        private System.Windows.Forms.Button btnRemoveOk;
        private System.Windows.Forms.TextBox tbRemoveTicker;
        private System.Windows.Forms.Label lblRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerLower;

    }
}

