using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using API_TESTER_UI.Pages.UserManagement;
using Caliburn.Micro;

namespace API_TESTER_UI.WebAPI.CompanyDababase
{
    public class GetAirports
    {

        public XmlDocument GetAirport(string token, string CWSURL)
        {
            return InvokeServiceGeAirports(token, CWSURL);
        }

        public XmlDocument InvokeServiceGeAirports(string token, string WsdlUrl)
        {
            var requestType = "customerdatabase";
            var apiFunction = "GetAirports";

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
                      <GetAirports xmlns=""http://corridor.aero/cws/"">
                            <airportsReference >
                                <SessionToken>" + token + @"</SessionToken>
                            </airportsReference >
                      </GetAirports>
                    </soap:Body>
                </soap:Envelope>");
            }
            catch (XmlException e)
            {
                MessageBox.Show($" An error occurred while reading the XML request body, see exception details {e}");
            }


            return processRequest.processApiRequest(SOAPReqBody, request);
        }

        public List<string> GetListOfAirports(XmlDocument doc)
        {
            List<string> list = new List<string>();
            XNamespace ns = "http://corridor.aero/cws/";
            try
            {
                using (XmlReader reader = new XmlNodeReader(doc.DocumentElement))
                {
                    reader.MoveToContent();
                    XDocument xDocument = XDocument.Load(reader);

                    var airportName = xDocument.Descendants(ns+"AirportName").ToList();

                    foreach (var d in airportName)
                    {
                        list.Add(d.FirstNode.ToString());
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The Airports API reponse is not successful!!!");
            }

            return list;
        }
    }
}
