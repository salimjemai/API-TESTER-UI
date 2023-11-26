using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using API_TESTER_UI.Database;
using API_TESTER_UI.Models.UserManagement;
using API_TESTER_UI.SessionWebReference;
using API_TESTER_UI.WebAPI;
using DevExpress.Mvvm.Native;

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for GetUser.xaml
    /// </summary>
    public partial class GetUser : Page
    {
        private static XmlSerializer m_xmlSerializer = new XmlSerializer(typeof(UserDeatils));

        public GetUser()
        {
            InitializeComponent();
        }

        private void SubmitGetUser_Click(object sender, RoutedEventArgs e)
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;
            try
            {
            
               GetUserReq getUserApi = new GetUserReq();

                // Open a connection to get the token info from the DB
                string sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    var isUserNameEmpty = userName.Text.Length > 0 ? false:true;

                    if (token != null  && cwsUrl != null)
                    {
                        // call web service 
                        SessionWebReference.UserManagement userManagement = new SessionWebReference.UserManagement();
                        UserManagementReferenceInput userManagementReference = new UserManagementReferenceInput
                        {
                            Username = userName.Text,
                            SessionToken = token
                        };
                        var fak = userManagement.GetUser(userManagementReference);
                        if (fak.StatusMessage.Equals("Failed"))
                        {
                            MessageBox.Show($"{fak.ErrorMessages.FirstOrDefault().ErrorText}", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        IEnumerable<UserManagementDataOutput> userManagementDataOutputs = fak.YieldToArray();
                        UserDataGridView.ItemsSource = userManagementDataOutputs;
                    }

                    else
                    {
                        MessageBox.Show("Error occurred while getting the session token info.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occurred while getting the user Data.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            UserDataGridView.ItemsSource = null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
