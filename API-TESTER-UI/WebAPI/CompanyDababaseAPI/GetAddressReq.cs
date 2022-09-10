using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using API_TESTER_UI.Models.CompanyDataBase;

namespace API_TESTER_UI.WebAPI.CompanyDababaseAPI
{
    public class GetAddressReq
    {

        public XmlDocument GetAddress(string token, string wsdlUrl, string title, string companyName, string companyCode, string contactName)
        {
            return InvokeServiceGeAddresses(token, wsdlUrl, title, companyName, companyCode, contactName);
        }
        public XmlDocument InvokeServiceGeAddresses(string token, string wsdlUrl, string title, string companyName, string companyCode, string contactName)
        {
            var requestType = "customerdatabase";
            var apiFunction = "GetAddress";

            ProcessRequest processRequest = new ProcessRequest();

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = processRequest.CreateSOAPWebRequest(requestType, apiFunction, wsdlUrl);

            XmlDocument SOAPReqBody = new XmlDocument();

            try
            {
                //SOAP Body Request    
                SOAPReqBody.LoadXml(
                    @"<?xml version=""1.0"" encoding=""utf-8""?><soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/soap/envelope/"" >
                    <soap12:Body>
                      <GetAddress  xmlns=""http://corridor.aero/cws/"">
                            <addressReference >
                                <SessionToken>" + token + @"</SessionToken>
                                <Title>"+title+@"</Title>
                                <CompanyName>"+companyName+@"</CompanyName>
                                <CompanyCode>"+companyCode+@"</CompanyCode>
                                <ContactName>"+contactName+@"</ContactName>
                            </addressReference >
                      </GetAddress >
                    </soap12:Body>
                </soap12:Envelope>");
            }
            catch (XmlException e)
            {
                MessageBox.Show($" An error occurred while reading the XML request body, see exception details {e}", "API Request", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return processRequest.processApiRequest(SOAPReqBody, request);
        }

        public Address GetAddressFields(XmlDocument doc)
        {

            Address address = new Address();
            XNamespace ns = "http://corridor.aero/cws/";
            try
            {
                //XDocument xDocument = XDocument.Load(reader);
                XmlElement root = doc.DocumentElement;
                ns = root.NamespaceURI; 

                if (root.GetElementsByTagName("StatusMessage").Equals("Success"))
                {
                    address.StatusMessage = root.GetAttribute("StatusMessage");
                    address.Title = root.GetElementsByTagName("Title").ToString();
                    address.CompanyName = root.GetElementsByTagName("CompanyName").ToString();
                    address.CompanyCode = root.GetElementsByTagName("CompanyCode").ToString();
                    address.AddressLines = root.GetElementsByTagName("AddressLines").ToString();
                    address.City = root.GetElementsByTagName("City").ToString();
                    address.State = root.GetElementsByTagName("State").ToString();
                    address.StateAbbreviation = root.GetElementsByTagName("StateAbbreviation").ToString();
                    address.PostalCode = root.GetElementsByTagName("PostalCode").ToString();
                    address.Country = root.GetElementsByTagName("Country").ToString();
                    address.CountryAbbreviation = root.GetElementsByTagName("CountryAbbreviation").ToString();
                    address.DefaultTaxCode = root.GetElementsByTagName("DefaultTaxCode").ToString();
                    address.Comments = root.GetElementsByTagName("Comments").ToString();
                    address.IsDefaultBillingAddress = root.GetElementsByTagName("IsDefaultBillingAddress").Equals("false") ? false: true;
                    address.IsDefaultShippingAddress = root.GetElementsByTagName("IsDefaultShippingAddress").Equals("false") ? false : true;
                    address.IsDefaultAddress = root.GetElementsByTagName("IsDefaultAddress").Equals("false") ? false : true;

                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to parse the Address response !!!", "Get Address", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return address;
        }
    }
}
