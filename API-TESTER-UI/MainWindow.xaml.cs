using API_TESTER_UI.Views;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Windows;

namespace API_TESTER_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string _SchemaAliasNameText { get; set; }
        public string _LoginID { get; set; }
        public string _Password { get; set; }
        public string _CwsUrl { get; set; } 
        public string _SessionToken { get; set; }

        public object NavigationService { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            //Close();
            _ApiChoiceFrame.Navigate(new ApiChoice());
        }

        private void ClearButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (schemaAliasNameText.Text.Length > 0 || LoginID.Text.Length > 0 ||
                LoginPasswordText.Password.Length > 0 || cwsUrlText.Text.Length > 0)
            {
                schemaAliasNameText.Clear();
                LoginID.Clear();
                LoginPasswordText.Clear();
                cwsUrlText.Clear();
            }
        }

        private async void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            LoginToSession login = new LoginToSession();
            var sessionToken = string.Empty;
            try
            {
                _SchemaAliasNameText = schemaAliasNameText.Text;
                _LoginID = LoginID.Text;
                _Password = LoginPasswordText.Password;
                _CwsUrl = cwsUrlText.Text;  

                if (schemaAliasNameText != null && LoginID != null && LoginPasswordText != null && cwsUrlText != null)
                {
                    sessionToken = login.Login(schemaAliasNameText.Text, LoginID.Text, LoginPasswordText.Password,
                        cwsUrlText.Text);

                    if (sessionToken != null)
                    {
                        _SessionToken = sessionToken;   
                        _ApiChoiceFrame.Navigate(new ApiChoice());
                    }
                    else
                    {
                        MessageBox.Show($"{MessageBoxImage.Error} Something wrong happened, try again another time!!!");
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"{MessageBoxImage.Error} Error occurred while trying to login: {exception.Message}");
            }
        }

        private void LogoutButton_OnClick(object sender, RoutedEventArgs e)
        {
            LoginToSession logout = new LoginToSession();
            var response = "";
            try
            {
                if (response.Contains("Success"))
                {
                    MessageBox.Show($"{MessageBoxImage.Information} You are logged out of the API.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"{MessageBoxImage.Stop} An error occurred while logging out ... {exception.Message}");
                throw;
            }
        }

        private void cwsUrlText_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void _ApiChoiceFrame_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
