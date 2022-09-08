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
                GetAirports getAirports = new GetAirports();

                // Open a connection to get the token info from the DB
                SqlServerConnection _Connection = new SqlServerConnection();
                string sqlQuery = "select Top(1) SessionToken, CwsUrl from Sessions order by DateCreated desc";
                using (SqlDataReader selectSession = _Connection.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession["SessionToken"].ToString();
                        cwsUrl = selectSession["CwsUrl"].ToString();
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
                        MessageBox.Show("Error occurred while getting the user info ..");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"An error occurred while getting the user Data ... {exc.Message}");
            }
        }

        private void ClosAirportsForm_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            //this.AirportsGrid.ItemsSource = null;
        }
    }

}
