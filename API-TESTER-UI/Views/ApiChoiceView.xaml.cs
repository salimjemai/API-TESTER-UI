﻿using System;
using API_TESTER_UI.Pages.UserManagement;
using API_TESTER_UI.Pages.CompanyDatabase;
using API_TESTER_UI.Utilities.UserManagement;
using System.Windows;

namespace API_TESTER_UI.Views
{
    /// <summary>
    /// Interaction logic for ApiChoice.xaml
    /// </summary>
    public partial class ApiChoiceWindow : Window
    {
        public System.Windows.Window apiChoiceWindow { get; set; }

        public ApiChoiceWindow()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            System.Windows.Application.Current.Shutdown();
        }

        private void UserManagmentBtn_Click(object sender, RoutedEventArgs e)
        {
            _UserManagementFrame.Navigate(new UserManagementView());
        }

        private void GetUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _GetUserInputFrame.Content = new GetUser();
            _UpdateUserInfoFrame.Content = null;
            _AddUserFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void UpdateUserInfoPage_Click(object sender, RoutedEventArgs e)
        {
            _UpdateUserInfoFrame.Content = new UpdateUser();
            _GetUserInputFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
            _AddUserFrame.Content = null;
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            _AddUserFrame.Content = new AddUser();
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
            _ChangeUserPasswordFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void ChangeUserPassword_Click(object sender, RoutedEventArgs e)
        {
            _ChangeUserPasswordFrame.Content = new ChangeUserPassword();
            _AddUserFrame.Content = null;
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
            _CreatePermissionProfileFrame.Content = null;
        }

        private void CreateUserPermissionProfile_Click(object sender, RoutedEventArgs e)
        {
            _CreatePermissionProfileFrame.Content = new CreatePermissionProfile();
            _ChangeUserPasswordFrame.Content = null;
            _AddUserFrame.Content = null;
            _UpdateUserInfoFrame.Content = null;
            _GetUserInputFrame.Content = null;
        }

        private void GetAirportsButton_Click(object sender, RoutedEventArgs e)
        {
            _GetAircraftsFrame.Content = new GetAircrafts();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public void CloseAirportsFrame()
        {
            _GetAircraftsFrame.Content = null;
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Do you wish to close this application?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var logoutResponse = SoapClient.LogOut();
                Application.Current.Shutdown();
            }
            

        }

       
        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure ?", "Confirm", MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                _ = SoapClient.LogOut();

                // close the current window
                this.Hide();

                // bring the user back to the main window
                //new HomeView().Show();
            }
        }

        private void ClearWIPButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("Help.html");
        }

        private void Version_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show($"Version 1.0.1", "API Tester version", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
