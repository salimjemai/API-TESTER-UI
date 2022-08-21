using System;
using System.Collections.Generic;
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
using API_TESTER_UI.WebAPI;

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
            MainWindow main = new MainWindow();
            GetUserApi getUserApi = new GetUserApi();

            var cwsUrl = main._CwsUrl;
            var token = main._SessionToken;

            if (token != null && userName.Text != null && cwsUrl != null)
                getUserApi.GetUserInfo(userName.Text, token, cwsUrl);

            else
            {
                MessageBox.Show("Error occurred while getting the user info ..");
            }
        }
    }

}
