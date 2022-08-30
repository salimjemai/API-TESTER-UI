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
    }
}
