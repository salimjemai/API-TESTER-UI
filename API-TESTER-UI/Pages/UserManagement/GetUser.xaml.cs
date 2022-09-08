using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
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
using API_TESTER_UI;
using API_TESTER_UI.Database;
using API_TESTER_UI.WebAPI;
using Ubiety.Dns.Core;

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for GetUser.xaml
    /// </summary>
    public partial class GetUser : Page
    {
        public GetUser()
        {
            InitializeComponent();
        }

        private void SubmitGetUser_Click(object sender, RoutedEventArgs e)
        {

            var token = string.Empty;
            var cwsUrl = string.Empty;
            var userCalledApi = string.Empty;
            try
            {
               XmlDocument response;
               GetUserReq getUserApi = new GetUserReq();

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

                    if (token != null && userName.Text != null && cwsUrl != null)
                    {
                        response = getUserApi.GetUserInfo(userName.Text, token, cwsUrl);
                    }

                    else
                    {
                        MessageBox.Show("Error occurred while getting the session token info.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occurred while getting the user Data.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
            PageContent pageContent = new PageContent();
        }
    }

}
