using System.Net;
using System.Xml;

namespace API_TESTER_UI
{
    // Deprecated
    public class LoginToSession
    {
        public string Login(string alias, string loginId, string password, string WsdlUrl)
        {
            //Calling InvokeService method    
            return InvokeServiceLoginToSession(alias, loginId, password, WsdlUrl);
        }

        public string InvokeServiceLoginToSession(string schema, string ApiUserName, string ApiUserPwd, string WsdlUrl)
        {

            var requestType = "Session";
            var apiFunction = "Login";

            ProcessRequest processRequest = new ProcessRequest();

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = processRequest.CreateSOAPWebRequest(requestType, apiFunction, WsdlUrl);

            XmlDocument SOAPReqBody = new XmlDocument();

            //SOAP Body Request    
            SOAPReqBody.LoadXml(
                @"<?xml version=""1.0"" encoding=""utf-8""?><soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" >
                    <soap:Body>
                        <Login xmlns = ""http://corridor.aero/cws/"" >
                                <loginData>
                                    <AliasName>" + schema + @"</AliasName>
                                    <LoginID>" + ApiUserName + @"</LoginID>
                                    <LoginPassword>" + ApiUserPwd + @"</LoginPassword>
                                </loginData>
                        </Login>
                    </soap:Body>
                </soap:Envelope> ");

            return processRequest.LoginResponse(SOAPReqBody, request);
        }
    }
}
