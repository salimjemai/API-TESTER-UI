using API_TESTER_UI.Database;
using API_TESTER_UI.UserManagement;
using API_TESTER_UI.Utilities.UserManagement;
using API_TESTER_UI.WebAPI;
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

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for ChangeUserPassword.xaml
    /// </summary>
    public partial class ChangeUserPassword
    {
        public UserManagementSoap UserManagementSoap { get; set; }
        public ChangeUserPassword()
        {
            InitializeComponent();
        }

        private void SubmitUpdateUserPassword_Click(object sender, RoutedEventArgs e)
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;
            try
            {

                // Open a connection to get the token info from the DB
                string sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    var isUserNameEmpty = userName.Text.Length > 0 ? false : true;

                    if (token != null && cwsUrl != null)
                    {
                        // create client 
                        var client = SoapClient.GetUserManagementClient(cwsUrl);
                        UserManagementChangePasswordInput userManagementChange = new UserManagementChangePasswordInput
                        {
                            Username = userName.Text,
                            SessionToken = token,
                            Password = Password.Password.ToString(),
                            NewPassword = newPassword.Password.ToString(),
                        };

                        var fak = client.ChangeUserPassword(userManagementChange);
                        if (fak.StatusMessage.Equals("Failed"))
                        {
                            MessageBox.Show($"{fak.ErrorMessages.FirstOrDefault().ErrorText}", "Update User Password", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        { 
                            MessageBox.Show($"Successfully updated {fak.Username} password.", "Update User Password", MessageBoxButton.OK, MessageBoxImage.Information);
                            userName.Text = null;
                            Password.Password = null;
                            newPassword.Password = null;
                            return;
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error occurred while getting the session token info.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occurred while Updating user password.", "Update User Password", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            userName.Text = string.Empty;
            Password.Password = string.Empty;
            newPassword.Password = string.Empty;
        }

    }

}
