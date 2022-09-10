using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using API_TESTER_UI.Database;
using System.Xml;
using API_TESTER_UI.Models.CompanyDataBase;
using API_TESTER_UI.WebAPI.CompanyDababase;
using API_TESTER_UI.WebAPI.CompanyDababaseAPI;
using Newtonsoft.Json.Linq;

namespace API_TESTER_UI.Pages.CompanyDatabase
{
    /// <summary>
    /// Interaction logic for GetAddress.xaml
    /// </summary>
    public partial class GetAddress : UserControl
    {
        //public List<Address> AddressesList { get; set; }

        public GetAddress()
        {
            InitializeComponent();
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = AddressTitle.Text.Length > 0 ? AddressTitle.Text: null;
                string companyName = CompanyName.Text.Length > 0? CompanyName.Text:null;
                string companyCode = CompanyCode.Text.Length > 0? CompanyCode.Text:null;
                string contactName = ContactName.Text.Length > 0 ? ContactName.Text : null;

                XmlDocument addressesXmlDocument;
                GetAddressReq getAddressReq = new GetAddressReq();
                var token = string.Empty;
                var cwsUrl = string.Empty;
                List<Address> addressesList = new List<Address>();

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

                    {
                        addressesXmlDocument = getAddressReq.GetAddress(token, cwsUrl, title, companyName, companyCode,contactName);

                        var address = getAddressReq.GetAddressFields(addressesXmlDocument);

                        addressesList.Add(address);
                        
                        AddressGrid.ItemsSource = addressesList;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error occurred while getting the airports info. exception detail: {exc}", "Airports details", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void Clear_OnClick()
        {
            this.Content = null;
        }
        public void Clear_OnClick(object sender, RoutedEventArgs e)
        {
            this.Content = null;
        }
    }
}
