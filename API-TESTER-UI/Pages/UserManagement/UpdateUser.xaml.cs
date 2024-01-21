using API_TESTER_UI.Database;
using API_TESTER_UI.UserManagement;
using DevExpress.Mvvm.Native;
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
using API_TESTER_UI.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace API_TESTER_UI.Pages.UserManagement
{
    /// <summary>
    /// Interaction logic for UpdateUser.xaml
    /// </summary>
    public partial class UpdateUser : Page
    {
        public UserManagementSoapClient UserManagementSoap { get; set; }
        public UpdateUser()
        {
            InitializeComponent();
        }


        private async void SubmitUpdateUser_Click(object sender, RoutedEventArgs e)
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;
            UserManagementUpdateData userManagementUpdateData = null;
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

                    var isUserNameEmpty = userName.Text.Length <= 0;

                    if (token != null && cwsUrl != null)
                    {
                        // call web service 
                        var userManagementReference = new UserManagementReferenceInput
                        {
                            Username = userName.Text,
                            SessionToken = token
                        };

                        if (!isUserNameEmpty)
                        {
                            userManagementUpdateData = new UserManagementUpdateData
                            {                                
                                SessionToken = token,
                                Username = userName.Text,
                                Fullname = fullName.Text,
                                Description = description.Text,
                                Department = department.Text,
                                UserBadgeID = userBadge.Text,
                                Email = email.Text,
                                Auth0Email = auth0Email.Text,
                                Password = password.Text,
                                AccessCode = accessCode.Text,
                                ActiveDirectoryName = activeDirectoryName.Text,
                                UserPermissionsProfile = userPermissionProfile.Text,
                                DefaultScreen = defaultScreen.Text,
                                RegularLaborAccountNumber = RegularLaborAccountNumber.Text,
                                OvertimeLaborAccountNumber = OvertimeLaborAccountNumber.Text,
                                DoubleTimeLaborAccountNumber = DoubleTimeLaborAccountNumber.Text,
                                LaborBurdenAccountNumber = LaborBurdenAccountNumber.Text,

                                //
                                Auth0Required = Auth0Required.IsChecked != null && (bool)Auth0Required.IsChecked,
                                MustChangePassword = MustChangePassword.IsChecked != null && (bool)MustChangePassword.IsChecked,
                                MustChangeAccessCode = MustChangeAccessCode.IsChecked != null && (bool)MustChangeAccessCode.IsChecked,
                                CannotChangePassword = CannotChangePassword.IsChecked != null && (bool)CannotChangePassword.IsChecked,
                                AccountDisabled = AccountDisabled.IsChecked != null && (bool)AccountDisabled.IsChecked,
                                Locator = Locator.IsChecked != null && (bool)Locator.IsChecked,
                                SuspendLocator = SuspendLocator.IsChecked != null && (bool)SuspendLocator.IsChecked,
                                CanSelectLocator = (bool)CanSelectLocator.IsChecked,
                                CanSelectToVendorLot = (bool)CanSelectToVendorLot.IsChecked,
                                ReceivingInspector = (bool)ReceivingInspector.IsChecked,
                                TipOfDay = (bool)TipOfDay.IsChecked,
                                LargeButtons = (bool)LargeButtons.IsChecked,
                                DisablePersistence = (bool)DisablePersistence.IsChecked,
                                DefaultIncludeFuelActivity = (bool)DefaultIncludeFuelActivity.IsChecked,
                                OnlyIncludeFuelActivity = (bool)OnlyIncludeFuelActivity.IsChecked,
                                DefaultIncludeServiceActivity = (bool)DefaultIncludeServiceActivity.IsChecked,
                                OnlyIncludeServiceActivity = (bool)OnlyIncludeServiceActivity.IsChecked,
                                DefaultIncludePartSaleActivity = (bool)DefaultIncludePartSaleActivity.IsChecked,
                                OnlyIncludePartSaleActivity = (bool)OnlyIncludePartSaleActivity.IsChecked,
                                DefaultIncludeCateringActivity = (bool)DefaultIncludeCateringActivity.IsChecked,
                                OnlyIncludeCateringActivity = (bool)OnlyIncludeCateringActivity.IsChecked,
                                DefaultIncludeHotelActivity = (bool)DefaultIncludeHotelActivity.IsChecked,
                                OnlyIncludeHotelActivity = (bool)OnlyIncludeHotelActivity.IsChecked,
                                DefaultIncludeTransportationActivity = (bool)DefaultIncludeTransportationActivity.IsChecked,
                                OnlyIncludeTransportationActivity = (bool)OnlyIncludeTransportationActivity.IsChecked,
                                LaunchLogbookResearch = (bool)LaunchLogbookResearch.IsChecked,
                                CanEnterCompliance = (bool)CanEnterCompliance.IsChecked,
                                IncludeAllDefaultLogbookSearchCriteria = (bool)IncludeAllDefaultLogbookSearchCriteria.IsChecked,
                                OnlyDisplayAssignedInWOQMgmt = (bool)OnlyDisplayAssignedInWOQMgmt.IsChecked,
                                NewUsername = NewUsername.Text
                            };

                            if(!string.IsNullOrEmpty(PurchaseLimit.Text))
                                userManagementUpdateData.PurchaseLimit = Convert.ToDouble(PurchaseLimit);
                            if(!string.IsNullOrEmpty(LaborCost.Text)) 
                                userManagementUpdateData.LaborCost = Convert.ToDouble(LaborCost);
                            if(!string.IsNullOrEmpty(RegularCost.Text)) 
                                userManagementUpdateData.RegularCost = Convert.ToDouble(RegularCost);
                            if(!string.IsNullOrEmpty(OvertimeCost.Text))
                                userManagementUpdateData.OvertimeCost = Convert.ToDouble(OvertimeCost);
                            if (!string.IsNullOrEmpty(DoubleTimeCost.Text))
                                userManagementUpdateData.DoubleTimeCost = Convert.ToDouble(DoubleTimeCost);
                            if(!string.IsNullOrEmpty(RegularBurdenCost.Text))
                                userManagementUpdateData.RegularBurdenCost = Convert.ToDouble(RegularBurdenCost);
                            if(!string.IsNullOrEmpty(OvertimeBurdenCost.Text))
                                userManagementUpdateData.OvertimeBurdenCost = Convert.ToDouble(OvertimeBurdenCost);
                            if(!string.IsNullOrEmpty(DoubleTimeBurdenCost.Text))
                                userManagementUpdateData.DoubleTimeBurdenCost = Convert.ToDouble(DoubleTimeBurdenCost);
                        }

                        var response = await UserManagementSoap.UpdateUserAsync(userManagementUpdateData);
                        if (response.StatusMessage.Equals("Failed"))
                        {
                            var error = response.ErrorMessages.Count();

                            MessageBox.Show($"{(error > 1 ? response.ErrorMessages[1].ErrorText : response.ErrorMessages.FirstOrDefault().ErrorText)}", "Update User Data", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                            MessageBox.Show($"Successfully updated {response.Username}'s Data.", "Update User Data", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    else
                    {
                        MessageBox.Show("Error occurred while getting the session token info.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
            catch (Exception exc)
            {
                Log.Exception("Error occurred while Updating the user Data", exc);
                MessageBox.Show("Error occurred while Updating the user Data.", "Update User info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearForm_Click(object sender, RoutedEventArgs e)
        {
            userName.Text = string.Empty;
            fullName.Text = string.Empty;
            description.Text = string.Empty;
            department.Text = string.Empty;
            userBadge.Text = string.Empty;
            email.Text = string.Empty;
            auth0Email.Text = string.Empty;
            password.Text = string.Empty;
            accessCode.Text = string.Empty;
            activeDirectoryName.Text = string.Empty;
            userPermissionProfile.Text = string.Empty;
            defaultScreen.Text = string.Empty;
            PurchaseLimit = null;
            LaborCost = null;
            RegularCost = null;
            OvertimeCost = null;
            DoubleTimeCost = null;
            RegularBurdenCost = null;
            OvertimeBurdenCost = null;
            DoubleTimeBurdenCost = null;
            RegularLaborAccountNumber.Text = string.Empty;
            OvertimeLaborAccountNumber.Text = string.Empty;
            DoubleTimeLaborAccountNumber.Text = string.Empty;
            LaborBurdenAccountNumber.Text = string.Empty;

            //
            Auth0Required.IsChecked = false;
            MustChangePassword.IsChecked = false;
            MustChangeAccessCode.IsChecked = false;
            CannotChangePassword.IsChecked = false;
            AccountDisabled.IsChecked = false;
            Locator.IsChecked = false;
            SuspendLocator.IsChecked = false;
            CanSelectLocator.IsChecked = false;
            CanSelectToVendorLot.IsChecked = false;
            ReceivingInspector.IsChecked = false;
            TipOfDay.IsChecked = false;
            LargeButtons.IsChecked = false;
            DisablePersistence.IsChecked = false;
            DefaultIncludeFuelActivity.IsChecked = false;
            OnlyIncludeFuelActivity.IsChecked = false;
            DefaultIncludeServiceActivity.IsChecked = false;
            OnlyIncludeServiceActivity.IsChecked = false;
            DefaultIncludePartSaleActivity.IsChecked = false;
            OnlyIncludePartSaleActivity.IsChecked = false;
            DefaultIncludeCateringActivity.IsChecked = false;
            OnlyIncludeCateringActivity.IsChecked = false;
            DefaultIncludeHotelActivity.IsChecked = false;
            OnlyIncludeHotelActivity.IsChecked = false;
            DefaultIncludeTransportationActivity.IsChecked = false;
            OnlyIncludeTransportationActivity.IsChecked = false;
            LaunchLogbookResearch.IsChecked = false;
            CanEnterCompliance.IsChecked = false;
            IncludeAllDefaultLogbookSearchCriteria.IsChecked = false;
            OnlyDisplayAssignedInWOQMgmt.IsChecked = false;
            NewUsername.Text = string.Empty;
        }

    }
}
