using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using API_TESTER_UI.Pages.UserManagement;
using Caliburn.Micro;

namespace API_TESTER_UI.WebAPI
{
    public class GetUserReq
    {
        //public string UserName { get; set; }    

        public XmlDocument GetUserInfo(string usernmae, string token, string CWSURL)
        {
            return InvokeServiceGetUser(usernmae, token, CWSURL);
        }

        public XmlDocument InvokeServiceGetUser(string userName, string token, string WsdlUrl)
        {
            var requestType = "usermanagement";
            var apiFunction = "GetUser";

            ProcessRequest processRequest = new ProcessRequest();

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = processRequest.CreateSOAPWebRequest(requestType, apiFunction, WsdlUrl);

            XmlDocument SOAPReqBody = new XmlDocument();

            try
            {
                //SOAP Body Request    
                SOAPReqBody.LoadXml(
                    @"<?xml version=""1.0"" encoding=""utf-8""?><soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                    <soap:Body>
                      <GetUser xmlns=""http://corridor.aero/cws/"">
                            <userReference>
                                <SessionToken>" + token + @"</SessionToken>
                                <Username>" + userName + @"</Username>
                            </userReference>
                      </GetUser>
                    </soap:Body>
                </soap:Envelope>");
            }
            catch (XmlException e)
            {
                MessageBox.Show($" An error occurred while reading the XML request body, see exception details {e}", 
                    "Getting User info", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return processRequest.processApiRequest(SOAPReqBody, request);
        }
    }
}
