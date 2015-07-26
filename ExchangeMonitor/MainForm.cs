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

            _dataController.AddTickers("GOOG");
            _dataController.AddTickers("EURUSD=X");
            _dataController.DataFetched += _dataControllerDataFetched;
        }

        private void _dataControllerDataFetched(object sender, EventArgs e) {
          var data = (DataControllerEventArgs)e;
            AddDataToGrid(data.Data);
        }

        private void AddDataToGrid(ExchangeMonitor.Engine.ViewModel.Data data) {
             int rowIndex = -1;
            foreach (DataGridViewRow row in DataGrid.Rows) {
              if (row.Cells[1].Value.ToString().Equals(data.Ticker)) {
                rowIndex = row.Index;
              }
            }

            string[] rowToAdd = new string[] { "Dude", "wheres", "my", "car" };
            try {
              
            DataGrid.Rows.Add(rowToAdd);
            }
            catch (Exception ex) {
              
              throw;
            }
            DataGrid.Refresh();
        }

        private void SetRowValues(int index, ExchangeMonitor.Engine.ViewModel.Data data) {
          DataGrid.Rows[index].Cells[0].Value = DateTime.Now.ToString();
          DataGrid.Rows[index].Cells[1].Value = data.Ticker;
          DataGrid.Rows[index].Cells[2].Value = data.Name;
          DataGrid.Rows[index].Cells[3].Value = data.Rate.ToString();
          DataGrid.Rows[index].Cells[4].Value = data.BollingerUpper.ToString();
          DataGrid.Rows[index].Cells[5].Value = data.BollingerLower.ToString();
        }
    }
}
