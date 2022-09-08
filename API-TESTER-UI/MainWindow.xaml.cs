using API_TESTER_UI.Views;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using API_TESTER_UI.Database;

// Sql 
using System.Data;
using System.Linq;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows.Controls;

namespace API_TESTER_UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string PlaceholderText { get; set; }
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
            this.Close();
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
                        _Connection.WriteDataIntoSession(_SessionToken, dateNow,IsTokenValid, _LoginID, _CwsUrl, _SchemaAliasNameText);

                        // hide main login window
                        this.Hide();

                        // Open the API Choice interface
                        new ApiChoiceWindow().Show();

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
                        MessageBox.Show($"{MessageBoxImage.Error} Something wrong happened, try again another time!!!");
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
