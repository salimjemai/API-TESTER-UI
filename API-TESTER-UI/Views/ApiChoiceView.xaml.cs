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
using API_TESTER_UI;

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
            // Call the Logout session API
            LogoutFromSession logout = new LogoutFromSession();

            if (MessageBox.Show(this, "Do you wish to close this application?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question)
                 == MessageBoxResult.Yes)
            {
                logout.LogOutFromSessionNoNotification();
                Application.Current.Shutdown();
            }
            

        }

       
        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {

            // call the logout function
            LogoutFromSession logout = new LogoutFromSession();
            logout.LogOutFromSession();

            // close the current window
            this.Close();

            // bring the user back to the main window
            new HomeView().Show();
            
        }

        private void ClearWIPButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
