using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using API_TESTER_UI.Database;
using API_TESTER_UI.UserManagement;
using API_TESTER_UI.Utilities;
using API_TESTER_UI.Utilities.UserManagement;

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    ///     Interaction logic for CreatePermissionProfile.xaml
    /// </summary>
    public partial class CreatePermissionProfile : Page
    {
        public CreatePermissionProfile()
        {
            InitializeComponent();
        }

        private async void SubmitCreatePermissionsProfile_Click(object sender, RoutedEventArgs e)
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;
            try
            {
                // Open a connection to get the token info from the DB
                var sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {
                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    var isUserNameEmpty = userName != null && userName.Text.Length <= 0;

                    if (token != null && cwsUrl != null)
                    {
                        // create client 
                        var client = SoapClient.GetUserManagementClient(cwsUrl);
                        var userManagementChange = new UserManagementCreatePermissionsProfileInput
                        {
                            Username = userName?.Text,
                            SessionToken = token,
                            CreatePermissionsProfileName = CreatePermissionsProfileName.Text
                        };

                        if (SetUserPermissionsProfileToNew.IsChecked == true)
                            userManagementChange.SetUserPermissionsProfileToNew =
                                Convert.ToBoolean(SetUserPermissionsProfileToNew.IsChecked);

                        var permissionsProfile = await client.CreatePermissionsProfileAsync(userManagementChange);
                        if (permissionsProfile.StatusMessage.Equals("Failed"))
                        {
                            MessageBox.Show($"{permissionsProfile?.ErrorMessages?.FirstOrDefault()?.ErrorText}",
                                "Create User Permission Profile", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show($"Successfully created {permissionsProfile?.Username} Permission Profile.",
                            "Create User Permission Profile", MessageBoxButton.OK, MessageBoxImage.Information);
                        userName.Text = string.Empty;
                        CreatePermissionsProfileName.Text = string.Empty;
                        SetUserPermissionsProfileToNew.IsChecked = false;
                        return;
                    }

                    MessageBox.Show("Error occurred while getting the session token info.", "Get User info",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception exc)
            {
                Log.Exception("Error occurred while Updating user Permission.", exc);
                MessageBox.Show("Error occurred while Updating user Permission.", "Update User Permission",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            userName.Text = string.Empty;
            CreatePermissionsProfileName.Text = string.Empty;
            SetUserPermissionsProfileToNew.IsChecked = false;
        }
    }
}