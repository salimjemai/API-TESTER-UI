using API_TESTER_UI.Database;
using System.Data.SqlClient;
using System;
using System.Net;
using System.Windows;
using System.Xml;

namespace API_TESTER_UI.WebAPI.Session
{
    public class LogoutFromSession
    {
        public string Logout(string token, string WsdlUrl)
        {
            //Calling InvokeService method    
            return InvokeServiceLogoutFromSession(token, WsdlUrl);
        }

        public string InvokeServiceLogoutFromSession(string token, string WsdlUrl)
        {

            var requestType = "Session";
            var apiFunction = "Logout";

            ProcessRequest processRequest = new ProcessRequest();

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = processRequest.CreateSOAPWebRequest(requestType, apiFunction, WsdlUrl);

            XmlDocument SOAPReqBody = new XmlDocument();

            //SOAP Body Request    
            SOAPReqBody.LoadXml(
                @"<?xml version=""1.0"" encoding=""utf-8""?><soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                    <soap:Body>
                        <Logout xmlns = ""http://corridor.aero/cws/"" >
                                <logoutData>
                                    <SessionToken>" + token + @"</SessionToken>
                                </logoutData>
                        </Logout>
                    </soap:Body>
                </soap:Envelope> ");

            return processRequest.LogoutResponse(SOAPReqBody, request);
        }

        public void LogOutFromSession()
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;

            try
            {
                // get the token and CWS URL from the DB
                // Open a connection to get the token info from the DB
                string sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    var logoutResponse = Logout(token, cwsUrl);

                    if (logoutResponse.Contains("Success"))
                    {
                        DatabaseHelper.DeleteSession(token);
                    }

                    DatabaseHelper.CloseConnection();
                    selectSession.Close();
                }
                MessageBox.Show("Successfully logged out!", "Logout", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"An error occurred while logging out: {ex.Message}", 
                    "Logout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void LogOutFromSessionNoNotification()
        {
            var token = string.Empty;
            var cwsUrl = string.Empty;

            try
            {
                // get the token and CWS URL from the DB
                // Open a connection to get the token info from the DB
                string sqlQuery = "select SessionToken, CwsUrl from Sessions order by DateCreated desc limit 1";
                using (var selectSession = DatabaseHelper.SelectRecords(sqlQuery))
                {

                    while (selectSession.Read())
                    {
                        token = selectSession.GetString(0);
                        cwsUrl = selectSession.GetString(1);
                    }

                    var logoutResponse = Logout(token, cwsUrl);

                    if (logoutResponse.Contains("Success"))
                    {
                        DatabaseHelper.DeleteSession(token);
                    }

                    DatabaseHelper.CloseConnection();
                    selectSession.Close();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show($"An error occurred while logging out: {ex.Message}",
                    "Logout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
