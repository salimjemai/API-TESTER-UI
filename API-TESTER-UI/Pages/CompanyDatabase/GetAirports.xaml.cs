using API_TESTER_UI.Database;
using API_TESTER_UI.WebAPI;
using API_TESTER_UI.WebAPI.CompanyDababase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace API_TESTER_UI.Pages.CompanyDatabase
{
    /// <summary>
    /// Interaction logic for GetAircrafts.xaml
    /// </summary>
    public partial class GetAircrafts : Page
    {
        public string _Airport { get; set; }
        public List<string> AirportsList { get; set; }

        public GetAircrafts()
        {
            InitializeComponent();
            

            var token = string.Empty;
            var cwsUrl = string.Empty;

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

                        this.AirportsGrid.ItemsSource = AirportsList;
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
    }
}
