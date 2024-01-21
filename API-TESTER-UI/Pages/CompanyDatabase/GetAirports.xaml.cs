using API_TESTER_UI.Database;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using API_TESTER_UI.CompanyDatabase;
using System.Linq;
using API_TESTER_UI.Utilities;
using API_TESTER_UI.Utilities.UserManagement;

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

            try
            {
                Log.Debug($"Getting Airports info ... ");
                XmlDocument airports;
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
                        var client = SoapClient.GetCompanyDatabaseClient(cwsUrl);
                        var airportsRequest = new AirportsReferenceInput
                        {
                            SessionToken = token
                        };
                        var response = client.GetAirports(airportsRequest);
                        var air = response.Airports;

                        Log.Debug($"Airport data ** Airports count: {air.Length}");
                        AirportsGrid.ItemsSource = air.ToList();
                    }
                    else
                    {
                        MessageBox.Show("Error occurred while retrieving the session token info.", "Retrieving session info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception exc)
            {
                Log.Error(exc.Message);
                MessageBox.Show($"Error occurred while getting the airports info. exception detail: {exc}", "Airports details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClosAirportsForm_Click(object sender, RoutedEventArgs e)
        {            
           this.AirportsGrid.ItemsSource = null;
        }
    }

}
