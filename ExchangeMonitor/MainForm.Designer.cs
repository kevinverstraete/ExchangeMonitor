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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.LastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ticker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TickerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BollingerUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BollingerLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddTicker = new System.Windows.Forms.Button();
            this.pnlAdd = new System.Windows.Forms.Panel();
            this.lblAdd = new System.Windows.Forms.Label();
            this.btnAddCancel = new System.Windows.Forms.Button();
            this.btnAddOk = new System.Windows.Forms.Button();
            this.tbAdd = new System.Windows.Forms.TextBox();
            this.btnRemoveTicker = new System.Windows.Forms.Button();
            this.pnlRemove = new System.Windows.Forms.Panel();
            this.tbRemoveTicker = new System.Windows.Forms.TextBox();
            this.lblRemove = new System.Windows.Forms.Label();
            this.btnRemoveCancel = new System.Windows.Forms.Button();
            this.btnRemoveOk = new System.Windows.Forms.Button();
            this.AlarmGrid = new System.Windows.Forms.DataGridView();
            this.Alarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmdSound = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.pnlAdd.SuspendLayout();
            this.pnlRemove.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlarmGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGrid
            // 
            this.DataGrid.AllowUserToAddRows = false;
            this.DataGrid.AllowUserToDeleteRows = false;
            this.DataGrid.AllowUserToOrderColumns = true;
            this.DataGrid.AllowUserToResizeRows = false;
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
            this.DataGrid.MultiSelect = false;
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.ReadOnly = true;
            this.DataGrid.RowHeadersVisible = false;
            this.DataGrid.RowTemplate.Height = 24;
            this.DataGrid.Size = new System.Drawing.Size(561, 480);
            this.DataGrid.TabIndex = 0;
            // 
            // LastUpdate
            // 
            this.LastUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.LastUpdate.FillWeight = 115.736F;
            this.LastUpdate.HeaderText = "Last Update";
            this.LastUpdate.MinimumWidth = 38;
            this.LastUpdate.Name = "LastUpdate";
            this.LastUpdate.ReadOnly = true;
            this.LastUpdate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.LastUpdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.LastUpdate.Width = 38;
            // 
            // Ticker
            // 
            this.Ticker.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ticker.FillWeight = 96.85278F;
            this.Ticker.HeaderText = "Ticker";
            this.Ticker.Name = "Ticker";
            this.Ticker.ReadOnly = true;
            this.Ticker.Width = 62;
            // 
            // TickerName
            // 
            this.TickerName.FillWeight = 96.85278F;
            this.TickerName.HeaderText = "Name";
            this.TickerName.Name = "TickerName";
            this.TickerName.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.FillWeight = 96.85278F;
            this.Rate.HeaderText = "Rate";
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // BollingerUpper
            // 
            this.BollingerUpper.FillWeight = 96.85278F;
            this.BollingerUpper.HeaderText = "Bollinger Upper";
            this.BollingerUpper.Name = "BollingerUpper";
            this.BollingerUpper.ReadOnly = true;
            // 
            // BollingerLower
            // 
            this.BollingerLower.FillWeight = 96.85278F;
            this.BollingerLower.HeaderText = "Bollinger Lower";
            this.BollingerLower.Name = "BollingerLower";
            this.BollingerLower.ReadOnly = true;
            // 
            // btnAddTicker
            // 
            this.btnAddTicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddTicker.Location = new System.Drawing.Point(11, 547);
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
            this.pnlAdd.Controls.Add(this.lblAdd);
            this.pnlAdd.Controls.Add(this.btnAddCancel);
            this.pnlAdd.Controls.Add(this.btnAddOk);
            this.pnlAdd.Controls.Add(this.tbAdd);
            this.pnlAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlAdd.Location = new System.Drawing.Point(11, 93);
            this.pnlAdd.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAdd.Name = "pnlAdd";
            this.pnlAdd.Size = new System.Drawing.Size(156, 72);
            this.pnlAdd.TabIndex = 1;
            this.pnlAdd.Visible = false;
            // 
            // lblAdd
            // 
            this.lblAdd.AutoSize = true;
            this.lblAdd.ForeColor = System.Drawing.Color.White;
            this.lblAdd.Location = new System.Drawing.Point(9, 20);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(26, 13);
            this.lblAdd.TabIndex = 3;
            this.lblAdd.Text = "Add";
            // 
            // btnAddCancel
            // 
            this.btnAddCancel.Location = new System.Drawing.Point(89, 44);
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
            this.btnAddOk.Location = new System.Drawing.Point(12, 44);
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
            this.tbAdd.Location = new System.Drawing.Point(69, 20);
            this.tbAdd.Margin = new System.Windows.Forms.Padding(2);
            this.tbAdd.Name = "tbAdd";
            this.tbAdd.Size = new System.Drawing.Size(76, 20);
            this.tbAdd.TabIndex = 0;
            // 
            // btnRemoveTicker
            // 
            this.btnRemoveTicker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveTicker.Location = new System.Drawing.Point(121, 547);
            this.btnRemoveTicker.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveTicker.Name = "btnRemoveTicker";
            this.btnRemoveTicker.Size = new System.Drawing.Size(107, 19);
            this.btnRemoveTicker.TabIndex = 2;
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
            this.pnlRemove.Location = new System.Drawing.Point(42, 127);
            this.pnlRemove.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRemove.Name = "pnlRemove";
            this.pnlRemove.Size = new System.Drawing.Size(156, 69);
            this.pnlRemove.TabIndex = 4;
            this.pnlRemove.Visible = false;
            // 
            // tbRemoveTicker
            // 
            this.tbRemoveTicker.Location = new System.Drawing.Point(70, 12);
            this.tbRemoveTicker.Margin = new System.Windows.Forms.Padding(2);
            this.tbRemoveTicker.Name = "tbRemoveTicker";
            this.tbRemoveTicker.Size = new System.Drawing.Size(76, 20);
            this.tbRemoveTicker.TabIndex = 0;
            // 
            // lblRemove
            // 
            this.lblRemove.AutoSize = true;
            this.lblRemove.ForeColor = System.Drawing.Color.White;
            this.lblRemove.Location = new System.Drawing.Point(10, 12);
            this.lblRemove.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRemove.Name = "lblRemove";
            this.lblRemove.Size = new System.Drawing.Size(47, 13);
            this.lblRemove.TabIndex = 2;
            this.lblRemove.Text = "Remove";
            // 
            // btnRemoveCancel
            // 
            this.btnRemoveCancel.Location = new System.Drawing.Point(90, 42);
            this.btnRemoveCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveCancel.Name = "btnRemoveCancel";
            this.btnRemoveCancel.Size = new System.Drawing.Size(56, 19);
            this.btnRemoveCancel.TabIndex = 2;
            this.btnRemoveCancel.Text = "Cancel";
            this.btnRemoveCancel.UseVisualStyleBackColor = true;
            this.btnRemoveCancel.Click += new System.EventHandler(this.btnRemoveCancel_Click);
            // 
            // btnRemoveOk
            // 
            this.btnRemoveOk.Location = new System.Drawing.Point(13, 42);
            this.btnRemoveOk.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveOk.Name = "btnRemoveOk";
            this.btnRemoveOk.Size = new System.Drawing.Size(56, 19);
            this.btnRemoveOk.TabIndex = 1;
            this.btnRemoveOk.Text = "OK";
            this.btnRemoveOk.UseVisualStyleBackColor = true;
            this.btnRemoveOk.Click += new System.EventHandler(this.btnRemoveOk_Click);
            // 
            // AlarmGrid
            // 
            this.AlarmGrid.AllowUserToAddRows = false;
            this.AlarmGrid.AllowUserToDeleteRows = false;
            this.AlarmGrid.AllowUserToOrderColumns = true;
            this.AlarmGrid.AllowUserToResizeColumns = false;
            this.AlarmGrid.AllowUserToResizeRows = false;
            this.AlarmGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlarmGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AlarmGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AlarmGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Alarm});
            this.AlarmGrid.Location = new System.Drawing.Point(568, 63);
            this.AlarmGrid.MultiSelect = false;
            this.AlarmGrid.Name = "AlarmGrid";
            this.AlarmGrid.RowHeadersVisible = false;
            this.AlarmGrid.Size = new System.Drawing.Size(220, 480);
            this.AlarmGrid.TabIndex = 5;
            // 
            // Alarm
            // 
            this.Alarm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Alarm.DefaultCellStyle = dataGridViewCellStyle1;
            this.Alarm.HeaderText = "Alarm";
            this.Alarm.Name = "Alarm";
            this.Alarm.ReadOnly = true;
            // 
            // cmdSound
            // 
            this.cmdSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmdSound.FormattingEnabled = true;
            this.cmdSound.Location = new System.Drawing.Point(596, 547);
            this.cmdSound.Name = "cmdSound";
            this.cmdSound.Size = new System.Drawing.Size(192, 21);
            this.cmdSound.TabIndex = 6;
            this.cmdSound.SelectedIndexChanged += new System.EventHandler(this.cmdSound_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(789, 577);
            this.Controls.Add(this.cmdSound);
            this.Controls.Add(this.AlarmGrid);
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
            ((System.ComponentModel.ISupportInitialize)(this.AlarmGrid)).EndInit();
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
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.DataGridView AlarmGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ticker;
        private System.Windows.Forms.DataGridViewTextBoxColumn TickerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn BollingerLower;
        private System.Windows.Forms.ComboBox cmdSound;

    }
}

