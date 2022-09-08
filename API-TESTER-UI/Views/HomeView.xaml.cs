using API_TESTER_UI.Database;
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
using System.Windows.Shapes;

namespace API_TESTER_UI.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : Window
    {
        public string PlaceholderText { get; set; }
        public string _SchemaAliasNameText { get; set; }
        public string _LoginID { get; set; }
        public string _Password { get; set; }
        public string _CwsUrl { get; set; }
        public string _SessionToken { get; set; }

        public object NavigationService { get; private set; }


        public HomeView()
        {
            InitializeComponent();
        }
        private void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            // Confirm the user decision
            if (MessageBox.Show(this, "Do you wish to close this application?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
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

            SqlServerConnection _Connection = new SqlServerConnection();

            string connectionString = _Connection.GetConnectionString();
            //SqlConnection connection = new SqlConnection(connectionString);


            var sessionToken = string.Empty;
            var dateNow = DateTime.Now;
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
                        int IsTokenValid = 1;

                        // Insert the session record into the DB
                        _Connection.WriteDataIntoSession(_SessionToken, dateNow, IsTokenValid, _LoginID, _CwsUrl, _SchemaAliasNameText);

                        // hide main login window
                        this.Hide();

                        // Open the API Choice interface
                        new ApiChoiceWindow().Show();

                    }
                    else
                    {
                        MessageBox.Show($"Something wrong happened, try again another time!!!", 
                            "Login warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error occurred while trying to login: {exception.Message}", 
                    "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loginButton2_Click(object sender, RoutedEventArgs e)
        {
            LoginToSession login = new LoginToSession();

            SqlServerConnection _Connection = new SqlServerConnection();

            string connectionString = _Connection.GetConnectionString();
            //SqlConnection connection = new SqlConnection(connectionString);


            var sessionToken = string.Empty;
            var dateNow = DateTime.Now;
            try
            {
                //_SchemaAliasNameText = schemaAliasNameText.Text;
                //_LoginID = LoginID.Text;
                //_Password = LoginPasswordText.Password;
                //_CwsUrl = cwsUrlText.Text;  
                _SchemaAliasNameText = "QA12c_V11_UC_1";
                _LoginID = "cati";
                _Password = "PgacdE";
                _CwsUrl = "http://192.168.201.121/CWS/";

                if (schemaAliasNameText != null && LoginID != null && _Password != null && cwsUrlText != null)
                {
                    sessionToken = login.Login(_SchemaAliasNameText, _LoginID, _Password, _CwsUrl);

                    if (sessionToken != null)
                    {
                        _SessionToken = sessionToken;
                        int IsTokenValid = 1;

                        // Insert the session record into the DB
                        _Connection.WriteDataIntoSession(_SessionToken, dateNow, IsTokenValid, _LoginID, _CwsUrl, _SchemaAliasNameText);

                        // hide main login window
                        this.Hide();

                        // Open the API Choice interface
                        new ApiChoiceWindow().Show();
                    }
                    else
                    {
                        MessageBox.Show($"Something wrong happened, try again another time!!!");
                    }
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show($"{MessageBoxImage.Error} Error occurred while trying to login: {exception.Message}");
            }
        }
    }
    public class PasswordBoxMonitor : DependencyObject
    {
        public static bool GetIsMonitoring(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsMonitoringProperty);
        }

        public static void SetIsMonitoring(DependencyObject obj, bool value)
        {
            obj.SetValue(IsMonitoringProperty, value);
        }

        public static readonly DependencyProperty IsMonitoringProperty =
            DependencyProperty.RegisterAttached("IsMonitoring", typeof(bool), typeof(PasswordBoxMonitor), new UIPropertyMetadata(false, OnIsMonitoringChanged));

        public static int GetPasswordLength(DependencyObject obj)
        {
            return (int)obj.GetValue(PasswordLengthProperty);
        }

        public static void SetPasswordLength(DependencyObject obj, int value)
        {
            obj.SetValue(PasswordLengthProperty, value);
        }

        public static readonly DependencyProperty PasswordLengthProperty =
            DependencyProperty.RegisterAttached("PasswordLength", typeof(int), typeof(PasswordBoxMonitor), new UIPropertyMetadata(0));

        private static void OnIsMonitoringChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pb = d as PasswordBox;
            if (pb == null)
            {
                return;
            }
            if ((bool)e.NewValue)
            {
                pb.PasswordChanged += PasswordChanged;
            }
            else
            {
                pb.PasswordChanged -= PasswordChanged;
            }
        }

        static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pb = sender as PasswordBox;
            if (pb == null)
            {
                return;
            }
            SetPasswordLength(pb, pb.Password.Length);
        }
    }
}
