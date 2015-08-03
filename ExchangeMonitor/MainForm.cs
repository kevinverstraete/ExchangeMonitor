using ExchangeMonitor.Engine.Controller;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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

            _dataController.DataFetched += _dataControllerDataFetched;
            LoadTickersFromConfig();
        }

        #region AddDataToGrid
        private void _dataControllerDataFetched(object sender, EventArgs e)
        {
            var data = (DataControllerEventArgs)e;
            AddDataToGrid(data.Data);
        }
        private void AddDataToGrid(ExchangeMonitor.Engine.ViewModel.Data data)
        {
            try
            {
                if (InvokeRequired)
                {
                    this.Invoke(new Action<ExchangeMonitor.Engine.ViewModel.Data>(AddDataToGrid), new object[] { data });
                    return;
                }

                int rowIndex = GetIndexForTicker(data.Ticker);
                if (rowIndex != -1) SetRowValues(rowIndex, data);
                else SetRowValues(DataGrid.Rows.Add(), data);

                DataGrid.Refresh();

            }
            catch (Exception)
            {
                return;
            }
        }

        private int GetIndexForTicker(string ticker)
        {
            foreach (DataGridViewRow row in DataGrid.Rows)
            {
                if (row.Cells[1].Value.ToString().Equals(ticker))
                {
                    return row.Index;
                }
            }
            return -1;
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

        #region AddPanel
        private void btnAddTicker_Click(object sender, EventArgs e)
        {
            tbAdd.Text = "";
            pnlAdd.Show();
            tbAdd.Focus();
        }

        private void btnAddCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Hide();
        }

        private void btnAddOk_Click(object sender, EventArgs e)
        {
            _dataController.AddTicker(tbAdd.Text);
            SaveTickersToConfig();
            pnlAdd.Hide();
        }
        #endregion AddPanel

        #region RemovePanel
        private void btnRemoveTicker_Click(object sender, EventArgs e)
        {
            pnlRemove.Show();
            tbRemoveTicker.Text = "";
            tbRemoveTicker.Focus();
        }

        private void btnRemoveCancel_Click(object sender, EventArgs e)
        {
            pnlRemove.Hide();
        }

        private void btnRemoveOk_Click(object sender, EventArgs e)
        {
            _dataController.RemoveTicker(tbRemoveTicker.Text);
            SaveTickersToConfig();
            int selectedIndex = GetIndexForTicker(tbRemoveTicker.Text);
            if (selectedIndex != -1)
            {
                DataGrid.Rows.RemoveAt(selectedIndex);
            }
            pnlRemove.Hide();
        }
        #endregion RemovePanel      

        #region Config
        public void SaveTickersToConfig()
        {
            ConfigSetValue(_dataController.GetTickers());
        }
        public void LoadTickersFromConfig()
        {
            string[] tickers = ConfigReadValue().Split(',');
            foreach (var item in tickers)
            {
                _dataController.AddTicker(item);
            }
        }
        public static void ConfigSetValue(string value, string key = "Tickers")
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] != null) config.AppSettings.Settings[key].Value = value;
            else config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
        }
        public static string ConfigReadValue(string key = "Tickers")
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings[key] == null) return string.Empty;
            return config.AppSettings.Settings[key].Value;
        }
        #endregion Config
    }
}
