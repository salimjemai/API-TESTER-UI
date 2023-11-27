using API_TESTER_UI.Accounting;
using API_TESTER_UI.Aircraftownership;
using API_TESTER_UI.CompanyDatabase;
using API_TESTER_UI.Session;
using API_TESTER_UI.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace API_TESTER_UI.Utilities.UserManagement
{
    public static class SoapClient
    {

        public static UserManagementSoapClient GetUserManagementClient(string cwsUrl)
        {
            var cwsEndpointServ = $"{cwsUrl}UserManagement.asmx";
            return new UserManagementSoapClient(GetDefaultBinding(), new EndpointAddress(cwsEndpointServ));
        }

        public static CompanyDatabaseSoapClient GetCompanyDatabaseClient(string cwsUrl)
        {
            var cwsEndpointServ = $"{cwsUrl}customerdatabase.asmx";
            return new CompanyDatabaseSoapClient(GetDefaultBinding(), new EndpointAddress(cwsEndpointServ));
        }

        public static SessionSoapClient GetSessionSoapClient(string cwsUrl)
        {
            var cwsEndpointServ = $"{cwsUrl}session.asmx";
            return new SessionSoapClient(GetDefaultBinding(), new EndpointAddress(cwsEndpointServ));
        }

        public static AircraftOwnershipSoapClient GetAircraftOwnershipSoapClient(string cwsUrl)
        {
            var cwsEndpointServ = $"{cwsUrl}aircraftownership.asmx";
            return new AircraftOwnershipSoapClient(GetDefaultBinding(), new EndpointAddress(cwsEndpointServ));
        }

        public static AccountingSoapClient GetAccountingSoapClient(string cwsUrl)
        {
            var cwsEndpointServ = $"{cwsUrl}accounting.asmx";
            return new AccountingSoapClient(GetDefaultBinding(), new EndpointAddress(cwsEndpointServ));
        }

        private static Binding GetDefaultBinding()
        {
            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferSize = int.MaxValue,
                SendTimeout = new TimeSpan(0, 5, 0)
            };

            return binding;
        }
    }
}
