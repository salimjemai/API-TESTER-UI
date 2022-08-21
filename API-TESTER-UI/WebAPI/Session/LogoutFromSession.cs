using System.Net;
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

            return processRequest.LoginResponse(SOAPReqBody, request);
        }
    }
}
