using API_TESTER_UI.Database;
using API_TESTER_UI.UserManagement;
using API_TESTER_UI.Utilities.UserManagement;
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
    /// Interaction logic for CreatePermissionProfile.xaml
    /// </summary>
    public partial class CreatePermissionProfile : Page
    {
        public CreatePermissionProfile()
        {
            InitializeComponent();
        }

        private void SubmitCreatePermissionsProfile_Click(object sender, RoutedEventArgs e)
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
                        UserManagementCreatePermissionsProfileInput userManagementChange = new UserManagementCreatePermissionsProfileInput
                        {
                            Username = userName.Text,
                            SessionToken = token,
                            CreatePermissionsProfileName = CreatePermissionsProfileName.Text                            
                        };

                        if (SetUserPermissionsProfileToNew.IsChecked == true)
                            userManagementChange.SetUserPermissionsProfileToNew = Convert.ToBoolean(SetUserPermissionsProfileToNew.IsChecked);
                        
                        var fak = client.CreatePermissionsProfile(userManagementChange);
                        if (fak.StatusMessage.Equals("Failed"))
                        {
                            MessageBox.Show($"{fak.ErrorMessages.FirstOrDefault().ErrorText}", "Create User Permission Profile", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show($"Successfully created {fak.Username} Permission Profile.", "Create User Permission Profile", MessageBoxButton.OK, MessageBoxImage.Information);
                            userName.Text = null;
                            CreatePermissionsProfileName.Text = null;
                            SetUserPermissionsProfileToNew.IsChecked = false ;
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
            userName.Text = null;
            CreatePermissionsProfileName.Text = null;
            SetUserPermissionsProfileToNew.IsChecked = false;
        }
    }
}
