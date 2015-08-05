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
using System.Media;
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

            PopulateSounds();
            _dataController.DataFetched += _dataControllerDataFetched;
            _dataController.BollingerAlarm += _dataControllerBollingerAlarm;
            LoadFromConfig();
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

        #region Alarm
        void _dataControllerBollingerAlarm(object sender, EventArgs e)
        {
            var data = (DataControllerEventArgs)e;
            AddAalarm(data.Data);
        }
        private void AddAalarm(ExchangeMonitor.Engine.ViewModel.Data data)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ExchangeMonitor.Engine.ViewModel.Data>(AddAalarm), new object[] { data });
                return;
            }
            try
            {
                var color = Color.LightGray;
                var result = new StringBuilder();
                result.Append("[").Append(DateTime.Now.ToString()).Append("] ").Append(data.Ticker).Append(Environment.NewLine);
                if (data.BollingerUpper < data.Rate) 
                {
                    result.Append("Went over Bollinger.").Append(Environment.NewLine);
                    PlaySound();
                    color = Color.LightGreen;
                }
                else if (data.BollingerLower > data.Rate)
                {
                    result.Append("Went under Bollinger.").Append(Environment.NewLine);
                    PlaySound();
                    color = Color.LightPink;
                }
                else
                {
                    result.Append("Restored within Bollinger").Append(Environment.NewLine);
                }
                result.Append("Rate: ").Append(data.Rate.ToString()).Append(Environment.NewLine);
                result.Append("Bol. Upper: ").Append(data.BollingerUpper.ToString()).Append(Environment.NewLine);
                result.Append("Bol. Lower: ").Append(data.BollingerLower.ToString());
                AddAalarm(result.ToString(), color);
            }
            catch
            {
                return;
            }
        }
        private void AddAalarm(string data, Color color)
        {
            AlarmGrid.Rows.Insert(0);
            AlarmGrid.Rows[0].Cells[0].Value = data;
            AlarmGrid.Rows[0].Cells[0].Selected = true;
            AlarmGrid.Rows[0].DefaultCellStyle.BackColor = color;
            AlarmGrid.Refresh();
        }
        private void PopulateSounds()
        {
            cmdSound.Items.Add("No Sound");
            cmdSound.Items.Add("Bike Horn");
            cmdSound.Items.Add("Industrial");
            cmdSound.Items.Add("Red Alert");
            cmdSound.Items.Add("Strange");
            cmdSound.Items.Add("Train Horn");
        }
        private void PlaySound()
        {
            var item = cmdSound.SelectedItem;
            if (item != null)
            {
                var text = item.ToString();
                if (text == "Bike Horn") PlaySound(Sounds.BikeHorn);
                else if (text == "Industrial") PlaySound(Sounds.Industrial);
                else if (text == "Red Alert") PlaySound(Sounds.RedAlert);
                else if (text == "Strange") PlaySound(Sounds.Strange);
                else if (text == "Train Horn") PlaySound(Sounds.TrainHornLow);
            }
        }

        private void PlaySound(System.IO.UnmanagedMemoryStream sound)
        {
            var player = new SoundPlayer(sound);
            player.Play();
        }
        private void cmdSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveToConfig();
        }
        #endregion Alarm

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
            SaveToConfig();
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
            SaveToConfig();
            int selectedIndex = GetIndexForTicker(tbRemoveTicker.Text);
            if (selectedIndex != -1)
            {
                DataGrid.Rows.RemoveAt(selectedIndex);
            }
            pnlRemove.Hide();
        }
        #endregion RemovePanel      

        #region Config
        public void SaveToConfig()
        {
            ConfigSetValue(_dataController.GetTickers());
            ConfigSetValue(cmdSound.SelectedItem.ToString(), "Sound");
        }
        public void LoadFromConfig()
        {
            string[] tickers = ConfigReadValue().Split(',');
            foreach (var item in tickers)
            {
                _dataController.AddTicker(item);
            }
            string sound = ConfigReadValue("Sound");
            if (cmdSound.Items.Contains(sound)) cmdSound.SelectedIndex = cmdSound.Items.IndexOf(sound);
            else cmdSound.SelectedIndex = 2;
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
