﻿using API_TESTER_UI.Database;
using API_TESTER_UI.WebAPI.CompanyDababase;
using API_TESTER_UI.Models.CompanyDataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using API_TESTER_UI.WebAPI.CompanyDababaseAPI;
using API_TESTER_UI.Pages.UserManagement;

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

            _GetAaddressesFrame.Content = null;
            _GetUserInfoFrame.Content = null;
            _GetCompanyDataFrame.Content = null;

            var token = string.Empty;
            var cwsUrl = string.Empty;

            List<Airports> air = new List<Airports>();
            try
            {
                XmlDocument airports;
                GetAirportsReq getAirports = new GetAirportsReq();

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
