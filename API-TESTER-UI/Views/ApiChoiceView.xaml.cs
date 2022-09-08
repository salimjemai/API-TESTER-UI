using System;
using System.Collections.Generic;
using System.Linq;
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
using API_TESTER_UI.Pages.UserManagement;
using API_TESTER_UI.Pages.CompanyDatabase;
using API_TESTER_UI.WebAPI.Session;
using API_TESTER_UI.Database;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using API_TESTER_UI.Views;

namespace API_TESTER_UI.Views
{
    /// <summary>
    /// Interaction logic for ApiChoice.xaml
    /// </summary>
    public partial class ApiChoiceWindow : Window
    {
        public ApiChoiceWindow()
        {
            InitializeComponent();
        }

        public void closeMethod(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UserManagmentBtn_Click(object sender, RoutedEventArgs e)
        {
            _UserManagementFrame.Navigate(new UserManagementView());
        }

        private void GetUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _GetUserInputFrame.Content = new GetUser();
        }

        //private void LogoutButton_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void GetAirportsButton_Click(object sender, RoutedEventArgs e)
        {
            _GetAircraftsFrame.Content = new GetAircrafts();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            // This clear button should clear any displayed data OR filled up fields to be updated
            //this.Content = null;
            //_GetAircraftsFrame.Content = null;
            //_UserManagementFrame.Content = null;
            //_GetUserInfoFrame.Content = null;
            //_AddUserFrame.Content = null;
            //_ChangeUserPasswordFrame.Content = null;
            //_UpdateUserInfoFrame.Content= null;
            //_ChangePermissionProfileFrame.Content = null;

        }

        public void CloseAirportsFrame()
        {
            _GetAircraftsFrame.Content = null;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            // logout, delete token record then exit
            Application.Current.Shutdown();

        }

        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            // Call the Logout session API
            LogoutFromSession logout = new LogoutFromSession();
            var token = string.Empty;
            var cwsUrl = string.Empty;

            try
            {
                // get the token and CWS URL from the DB
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

                    var logoutResponse = logout.Logout(token, cwsUrl);

                    if (logoutResponse.Contains("Success"))
                    {
                        _Connection.DeleteSession(token);
                    }

                    selectSession.Close();
                }
                closeMethod(sender, e);

                new MainWindow().Show();
            }
            catch(SystemException ex)
            {
                MessageBox.Show(string.Format("An error occurred while logging out: {0}", ex.Message));
            }
        }

    }
}
