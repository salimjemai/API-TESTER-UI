using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;
using API_TESTER_UI.Database;
using API_TESTER_UI.Models.UserManagement;
using API_TESTER_UI.UserManagement;
using API_TESTER_UI.Utilities.UserManagement;
using API_TESTER_UI.WebAPI;
using DevExpress.Mvvm.Native;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for GetUser.xaml
    /// </summary>
    public partial class GetUser : Page
    {
        private string serviceEndpoint = ConfigurationManager.AppSettings["endpoint"];
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
                        // call web service
                        // create client to use the interface
                        var userClient = SoapClient.GetUserManagementClient(cwsUrl);      

                        UserManagementReferenceInput userManagementReference = new UserManagementReferenceInput
                        {
                            Username = userName.Text,
                            SessionToken = token
                        };
                        var testClient = userClient.GetUser(userManagementReference);
                        if (testClient.StatusMessage.Equals("Failed"))
                        {
                            MessageBox.Show($"{testClient.ErrorMessages.FirstOrDefault().ErrorText}", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        SetupUserOutPut(testClient);
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
            //UserDataGridView.ItemsSource = null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SetupUserOutPut(UserManagementDataOutput userManagementDataOutputs)
        {
            if (userManagementDataOutputs != null && userManagementDataOutputs.Username != null)
            {
                userNameOut.Text = userManagementDataOutputs.Username;
                fullName.Text = userManagementDataOutputs.Fullname;
                description.Text = userManagementDataOutputs.Description;
                department.Text = userManagementDataOutputs.Department;
                userBadge.Text = userManagementDataOutputs.UserBadgeID;
                email.Text = userManagementDataOutputs.Email;
                auth0Email.Text = userManagementDataOutputs.Auth0Email;
                activeDirectoryName.Text = userManagementDataOutputs.ActiveDirectoryName;
                userPermissionProfile.Text = userManagementDataOutputs.UserPermissionsProfile;
                defaultScreen.Text = userManagementDataOutputs.DefaultScreen;
                RegularLaborAccountNumber.Text = userManagementDataOutputs.RegularLaborAccountNumber;
                OvertimeLaborAccountNumber.Text = userManagementDataOutputs.OvertimeLaborAccountNumber;
                DoubleTimeLaborAccountNumber.Text = userManagementDataOutputs.DoubleTimeLaborAccountNumber;
                LaborBurdenAccountNumber.Text = userManagementDataOutputs.LaborBurdenAccountNumber;
                //
                Auth0Required.IsChecked = userManagementDataOutputs.Auth0Required;
                MustChangePassword.IsChecked = !userManagementDataOutputs.MustChangePassword;
                CannotChangePassword.IsChecked = userManagementDataOutputs.CannotChangePassword;
                AccountDisabled.IsChecked = userManagementDataOutputs.AccountDisabled;
                Locator.IsChecked = userManagementDataOutputs.Locator;
                SuspendLocator.IsChecked = userManagementDataOutputs.SuspendLocator;
                CanSelectLocator.IsChecked = userManagementDataOutputs.CanSelectLocator;
                CanSelectToVendorLot.IsChecked = userManagementDataOutputs.CanSelectToVendorLot;
                ReceivingInspector.IsChecked = userManagementDataOutputs.ReceivingInspector;
                TipOfDay.IsChecked = userManagementDataOutputs.TipOfDay;
                LargeButtons.IsChecked = userManagementDataOutputs.LargeButtons;
                DisablePersistence.IsChecked = userManagementDataOutputs.DisablePersistence;
                DefaultIncludeFuelActivity.IsChecked = userManagementDataOutputs.DefaultIncludeFuelActivity;
                OnlyIncludeFuelActivity.IsChecked = userManagementDataOutputs.OnlyIncludeFuelActivity;
                DefaultIncludeServiceActivity.IsChecked = userManagementDataOutputs.DefaultIncludeServiceActivity;
                OnlyIncludeServiceActivity.IsChecked = userManagementDataOutputs.OnlyIncludeServiceActivity;
                DefaultIncludePartSaleActivity.IsChecked = userManagementDataOutputs.DefaultIncludePartSaleActivity;
                OnlyIncludePartSaleActivity.IsChecked = userManagementDataOutputs.OnlyIncludePartSaleActivity;
                DefaultIncludeCateringActivity.IsChecked = userManagementDataOutputs.DefaultIncludeCateringActivity;
                OnlyIncludeCateringActivity.IsChecked = userManagementDataOutputs.OnlyIncludeCateringActivity;
                DefaultIncludeHotelActivity.IsChecked = userManagementDataOutputs.DefaultIncludeHotelActivity;
                OnlyIncludeHotelActivity.IsChecked = userManagementDataOutputs.OnlyIncludeHotelActivity;
                DefaultIncludeTransportationActivity.IsChecked = userManagementDataOutputs.DefaultIncludeTransportationActivity;
                OnlyIncludeTransportationActivity.IsChecked = userManagementDataOutputs.OnlyIncludeTransportationActivity;
                LaunchLogbookResearch.IsChecked = userManagementDataOutputs.LaunchLogbookResearch;
                CanEnterCompliance.IsChecked = userManagementDataOutputs.CanEnterCompliance;
                IncludeAllDefaultLogbookSearchCriteria.IsChecked = userManagementDataOutputs.IncludeAllDefaultLogbookSearchCriteria;
                PurchaseLimit.Text = userManagementDataOutputs.PurchaseLimit;
                RegularCost.Text = userManagementDataOutputs.RegularCost;
                OvertimeCost.Text = userManagementDataOutputs.OvertimeCost;
                DoubleTimeCost.Text = userManagementDataOutputs.DoubleTimeCost;
                RegularBurdenCost.Text = userManagementDataOutputs.RegularBurdenCost;
                OvertimeBurdenCost.Text = userManagementDataOutputs.OvertimeBurdenCost;
                DoubleTimeBurdenCost.Text = userManagementDataOutputs.DoubleTimeBurdenCost;



            }
        }
    }

}
