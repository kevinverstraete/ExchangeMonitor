using ExchangeMonitor.Engine.Controller;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExchangeMonitor
{
    public partial class MainForm : MaterialForm
    {
        private DataController _dataController = new DataController();

        public MainForm()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme =
              new ColorScheme(Primary.Grey800, Primary.Grey900, Primary.Grey500, Accent.LightBlue200, TextShade.WHITE);

            //_dataController.AddTickers("GOOG");
            //_dataController.AddTickers("EURUSD=X");
            _dataController.DataFetched += _dataControllerDataFetched;
        }

        #region AddDataToGrid
        private void _dataControllerDataFetched(object sender, EventArgs e)
        {
            var data = (DataControllerEventArgs)e;
            AddDataToGrid(data.Data);
        }
        private void AddDataToGrid(ExchangeMonitor.Engine.ViewModel.Data data)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ExchangeMonitor.Engine.ViewModel.Data>(AddDataToGrid), new object[] { data });
                return;
            }

            int rowIndex = -1;
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(data.Ticker))
                {
                    rowIndex = row.Index;
                }
            }

            if (rowIndex != -1) SetRowValues(rowIndex, data);
            else SetRowValues(DataGrid.Rows.Add(), data);

            DataGrid.Refresh();
        }
        private void SetRowValues(int index, ExchangeMonitor.Engine.ViewModel.Data data)
        {
            DataGrid.Rows[index].Cells[0].Value = DateTime.Now.ToString();
            DataGrid.Rows[index].Cells[1].Value = data.Ticker;
            DataGrid.Rows[index].Cells[2].Value = data.Name;
            DataGrid.Rows[index].Cells[3].Value = data.Rate.ToString();
            DataGrid.Rows[index].Cells[4].Value = data.BollingerUpper.ToString();
            DataGrid.Rows[index].Cells[5].Value = data.BollingerLower.ToString();
        }
        #endregion AddDataToGrid

        private void TimerPull_Tick(object sender, EventArgs e)
        {
            _dataController.Pull();
        }

        private void btnAddTicker_Click(object sender, EventArgs e)
        {
            pnlAdd.Show();
            tbAdd.Focus();
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Hide();
        }

        private void btnAddOk_Click(object sender, EventArgs e)
        {
            _dataController.AddTickers(tbAdd.Text);
            pnlAdd.Hide();
        }

        private void btnRemoveTicker_Click(object sender, EventArgs e)
        {
            pnlRemove.Show();
            tbRemoveTicker.Focus();
        }

        

        private void btnRemoveCancel_Click(object sender, EventArgs e)
        {
            pnlRemove.Hide();
        }

        private void tbRemoveTicker_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnRemoveOk_Click(object sender, EventArgs e)
        {
            int selectedIndex = DataGrid.CurrentCell.RowIndex;
            if (selectedIndex != null)
            {
                DataGrid.Rows.RemoveAt(selectedIndex);
                //DataGrid.Refresh();
                _dataController.RemoveTicker(tbRemoveTicker.Text);
            }
        }

        
    }
}
