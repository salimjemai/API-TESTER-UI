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

namespace API_TESTER_UI.Views
{
    /// <summary>
    /// Interaction logic for ApiChoice.xaml
    /// </summary>
    public partial class ApiChoice : Page
    {
        public ApiChoice()
        {
            InitializeComponent();
        }

        private void UserManagmentBtn_Click(object sender, RoutedEventArgs e)
        {
            _UserManagementFrame.Navigate(new UserManagementView());
        }

        private void GetUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _GetUserInfoFrame.Content = new GetUser();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {

        }

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

    //<Frame x:Name="_UserManagementFrame" NavigationUIVisibility="Hidden" />
    //<Frame x:Name="_GetUserInfoFrame" NavigationUIVisibility="Hidden" />
    //<Frame x:Name="_AddUserFrame" NavigationUIVisibility="Hidden" />
    //<Frame x:Name="_ChangeUserPasswordFrame" NavigationUIVisibility="Hidden" />
    //<Frame x:Name="_UpdateUserInfoFrame" NavigationUIVisibility="Hidden" />
    //<Frame x:Name="_ChangePermissionProfileFrame" NavigationUIVisibility="Hidden" />
    }
}
