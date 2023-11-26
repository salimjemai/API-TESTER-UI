using API_TESTER_UI.Database;
using API_TESTER_UI.WebAPI.CompanyDababase;
using API_TESTER_UI.Models.CompanyDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Data.SQLite;

namespace API_TESTER_UI.Pages.CompanyDatabase
{
    /// <summary>
    /// Interaction logic for GetAircrafts.xaml
    /// </summary>
    public partial class GetAircrafts : Page
    {
        public List<string> AirportsList { get; set; }

        public GetAircrafts()
        {
            InitializeComponent();

            var token = string.Empty;
            var cwsUrl = string.Empty;

            List<Airports> air = new List<Airports>();
            try
            {
                XmlDocument airports;
                GetAirportsReq getAirports = new GetAirportsReq();

                // Open a connection to get the token info from the DB
                string sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    if (token != null && cwsUrl != null)
                    {
                        DataSet data = new DataSet();
                        airports = getAirports.GetAirport(token, cwsUrl);
                        AirportsList = getAirports.GetListOfAirports(airports);

                        foreach(var airport in AirportsList)
                        {
                            air.Add(new Airports { Airport = airport});
                        }

                        AirportsGrid.ItemsSource = air;
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while retrieving the session token info.", "Retrieving session info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error occurred while getting the airports info. exception detail: {exc}", "Airports details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClosAirportsForm_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            //this.AirportsGrid.ItemsSource = null;
        }
    }

}
