using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using API_TESTER_UI.Utilities.UserManagement;
using System.Windows.Forms;
using System.Web.UI.HtmlControls;
using System.Windows;
using WebBrowser = System.Windows.Controls.WebBrowser;

namespace API_TESTER_UI.Views
{
    /// <summary>
    /// Interaction logic for ApiChoice.xaml
    /// </summary>
    public partial class ApiChoiceWindow : Window
    {
        public System.Windows.Window apiChoiceWindow { get; set; }

        public ApiChoiceWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            System.Windows.Application.Current.Shutdown();
        }

        private void UserManagmentBtn_Click(object sender, RoutedEventArgs e)
        {
            _UserManagementFrame.Navigate(new UserManagementView());
        }

        private void GetUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _GetUserInputFrame.Content = new GetUser();
            _UpdateUserInfoFrame.Content = null;
            _AddUserFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void UpdateUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _UpdateUserInfoFrame.Content = new UpdateUser();
            _GetUserInputFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
            _AddUserFrame.Content = null;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            _AddUserFrame.Content = new AddUser();
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void ChangeUserPassword_Click(object sender, RoutedEventArgs e)
        {
            _ChangeUserPasswordFrame.Content = new ChangeUserPassword();
            _AddUserFrame.Content = null;
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void CreateUserPermissionProfile_Click(object sender, RoutedEventArgs e)
        {
            _CreatePermissionProfileFrame.Content = new CreatePermissionProfile();
            _ChangeUserPasswordFrame.Content = null;
            _AddUserFrame.Content = null;
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
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

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show(this, "Do you wish to close this application?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question)
                 == MessageBoxResult.Yes)
            {
                var logoutResponse = SoapClient.LogOut();
                System.Windows.Application.Current.Shutdown();
            }
            

        }

       
        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            _ = SoapClient.LogOut();

            // close the current window
            this.Close();

            // bring the user back to the main window
            new HomeView().Show();
            
        }

        private void ClearWIPButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Help.html");
        }

        private void Version_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Version 1.0.1", "API Tester version", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
