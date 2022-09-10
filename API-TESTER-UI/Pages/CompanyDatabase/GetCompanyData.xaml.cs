using API_TESTER_UI.Database;
using API_TESTER_UI.Models.CompanyDataBase;
using API_TESTER_UI.WebAPI;
using API_TESTER_UI.WebAPI.CompanyDababaseAPI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Xml;

namespace API_TESTER_UI.Pages.CompanyDatabase
{
    /// <summary>
    /// Interaction logic for GetCompanyData.xaml
    /// </summary>
    public partial class GetCompanyData : UserControl
    {
        public GetCompanyData()
        {
            InitializeComponent();

            _GetAaddressesFrame.Content = null;
            _GetAircraftsFrame.Content = null;
            _GetUserInfoFrame.Content = null;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            bool isCompanyCodeEmpty = false;
            var token = string.Empty;
            var cwsUrl = string.Empty;

            try
            {
                XmlDocument response = new XmlDocument();
                GetCompanyDataReq getCompanyData  =  new GetCompanyDataReq();
                List<CompanyData> companyDatas = new List<CompanyData>();

                // Open a connection to get the token info from the DB
                SqlServerConnection _Connection = new SqlServerConnection();
                string sqlQuery = "select Top(1) SessionToken, CwsUrl from Sessions order by DateCreated desc";
                using (SqlDataReader selectSession = _Connection.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession["SessionToken"].ToString();
                        cwsUrl = selectSession["CwsUrl"].ToString();
                    }

                    isCompanyCodeEmpty = CompanyCode.Text.Length > 0 ? false : true;

                    if (token != null && cwsUrl != null)
                    {
                        switch (isCompanyCodeEmpty)
                        {
                            case true:
                                MessageBox.Show("Company Code cannot be empty", "Get Company data", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;

                            case false:
                                response = getCompanyData.GetCompanyData(token, cwsUrl, CompanyCode.Text);
                                var company = getCompanyData.CompanyDataReadyToConsume(response);
                                companyDatas.Add(new CompanyData
                                {
                                    CompanyCode = company.CompanyCode,
                                    CompanyName = company.CompanyName,
                                    IsCustomer = company.IsCustomer,
                                    IsVendor = company.IsVendor,
                                    DefaultCurrency = company.DefaultCurrency,
                                    IsShippingHold = company.IsShippingHold,
                                    IsTaxExempt = company.IsTaxExempt,
                                    RepairStationNumber = company.RepairStationNumber,
                                    FAANumber = company.FAANumber,
                                    DefaultBillingAddressTitle = company.DefaultBillingAddressTitle,
                                    DefaultShippingAddressTitle = company.DefaultShippingAddressTitle,
                                    DefaultAddressTitle = company.DefaultAddressTitle,
                                    DefaultPhoneTitle = company.DefaultPhoneTitle,
                                    DefaultFaxTitle = company.DefaultFaxTitle,
                                    IsRepairStation = company.IsRepairStation,
                                    IsCreditCardCompany = company.IsCreditCardCompany,
                                    IsAircraftManufacturer = company.IsAircraftManufacturer,
                                    IsEngineManufacturer = company.IsEngineManufacturer,
                                    IsAPUManufacturer = company.IsAPUManufacturer,
                                    IsOtherManufacturer = company.IsOtherManufacturer,
                                    IsManufacturer = company.IsManufacturer,
                                    IsIndividual = company.IsIndividual,
                                    IsSoleProprietorship = company.IsSoleProprietorship,
                                    IsPartnership = company.IsPartnership,
                                    IsCorporation = company.IsCorporation,
                                    IsCreditCheckPerformed = company.IsCreditCheckPerformed,
                                    IsCustomerExemptFromFuelTaxes = company.IsCustomerExemptFromFuelTaxes,
                                    IsInactive = company.IsInactive

                                });

                                CompanyDataGrid.ItemsSource = companyDatas;
                                break;

                        }
                    }

                    else
                    {
                        MessageBox.Show("Error occurred while getting the session token info.", "Get Company Data", MessageBoxButton.OK, MessageBoxImage.Error);

                    }


                }
                // need to close the connection here
                //_Connection.closeConnection();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error occurred while getting the Company Data.", "Get User info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Clear_Click()
        {
            this.Content = null;
        }

        public void Clear_Click(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
