using System;
using System.Net;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using API_TESTER_UI.Models.CompanyDataBase;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Xml.Serialization;
using DevExpress.Mvvm;

namespace API_TESTER_UI.WebAPI.CompanyDababaseAPI
{
    public class GetCompanyDataReq
    {
        public XmlDocument GetCompanyData(string token, string CWSURL, string companyCode)
        {
            return InvokeServiceGeCompanyData(token, CWSURL, companyCode);
        }

        public XmlDocument InvokeServiceGeCompanyData(string token, string WsdlUrl, string companyCode)
        {
            var requestType = "customerdatabase";
            var apiFunction = "GetCompanyData";

            ProcessRequest processRequest = new ProcessRequest();

            //Calling CreateSOAPWebRequest method    
            HttpWebRequest request = processRequest.CreateSOAPWebRequest(requestType, apiFunction, WsdlUrl);

            XmlDocument SOAPReqBody = new XmlDocument();

            try
            {
                //SOAP Body Request    
                SOAPReqBody.LoadXml(
                    @"<?xml version=""1.0"" encoding=""utf-8""?><soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://schemas.xmlsoap.org/soap/envelope/"" >
                    <soap12:Body>
                      <GetCompanyData xmlns=""http://corridor.aero/cws/"">
                            <companyReference >
                                <SessionToken>" + token + @"</SessionToken>
                                <CompanyCode>"+ companyCode + @"</CompanyCode>
                            </companyReference >
                      </GetCompanyData>
                    </soap12:Body>
                </soap12:Envelope>");
            }
            catch (XmlException e)
            {
                MessageBox.Show($" An error occurred while reading the XML request body, see exception details {e}", "API Request", MessageBoxButton.OK, MessageBoxImage.Error);
            }


            return processRequest.processApiRequest(SOAPReqBody, request);
        }

        public CompanyData CompanyDataReadyToConsume(XmlDocument doc)
        {
            //var StatusMessage = string.Empty;
            List<object> list = new List<object>();
            CompanyData companyData = new CompanyData();
            XNamespace ns = "http://corridor.aero/cws/";
            try
            {

                using (XmlReader reader = new XmlNodeReader(doc.DocumentElement))
                {
                    reader.MoveToContent();
                    XDocument xDocument = XDocument.Load(reader);

                    var companyDataResponse = xDocument.Descendants(ns + "StatusMessage").First();

                    if(companyDataResponse.Value == "Success")
                    {
                        companyData.CompanyName = xDocument.Descendants(ns + "CompanyName").First().Value;
                        companyData.CompanyCode = xDocument.Descendants(ns + "CompanyCode").First().Value;
                        companyData.IsCustomer = Convert.ToBoolean(xDocument.Descendants(ns + "IsCustomer").First().Value);
                        companyData.IsVendor = Convert.ToBoolean(xDocument.Descendants(ns + "IsVendor").First().Value);
                        companyData.DefaultCurrency = xDocument.Descendants(ns + "DefaultCurrency").First().Value;
                        companyData.IsShippingHold = Convert.ToBoolean(xDocument.Descendants(ns + "IsShippingHold").First().Value);
                        companyData.IsTaxExempt = Convert.ToBoolean(xDocument.Descendants(ns + "IsTaxExempt").First().Value);
                        companyData.RepairStationNumber = xDocument.Descendants(ns + "RepairStationNumber").First().Value;
                        companyData.FAANumber = xDocument.Descendants(ns + "FAANumber").First().Value;
                        companyData.DefaultBillingAddressTitle = xDocument.Descendants(ns + "DefaultBillingAddressTitle").First().Value;
                        companyData.DefaultShippingAddressTitle = xDocument.Descendants(ns + "DefaultShippingAddressTitle").First().Value;
                        companyData.DefaultAddressTitle = xDocument.Descendants(ns + "DefaultAddressTitle").First().Value;
                        companyData.DefaultPhoneTitle = xDocument.Descendants(ns + "DefaultPhoneTitle").First().Value;
                        companyData.DefaultFaxTitle = xDocument.Descendants(ns + "DefaultFaxTitle").First().Value;
                        companyData.IsRepairStation = Convert.ToBoolean(xDocument.Descendants(ns + "IsRepairStation").First().Value);
                        companyData.IsCreditCardCompany = Convert.ToBoolean(xDocument.Descendants(ns + "IsCreditCardCompany").First().Value);
                        companyData.IsAircraftManufacturer = Convert.ToBoolean(xDocument.Descendants(ns + "IsAircraftManufacturer").First().Value);
                        companyData.IsEngineManufacturer = Convert.ToBoolean(xDocument.Descendants(ns + "IsEngineManufacturer").First().Value);
                        companyData.IsAPUManufacturer = Convert.ToBoolean(xDocument.Descendants(ns + "IsAPUManufacturer").First().Value);
                        companyData.IsOtherManufacturer = Convert.ToBoolean(xDocument.Descendants(ns + "IsOtherManufacturer").First().Value);
                        companyData.IsManufacturer = Convert.ToBoolean(xDocument.Descendants(ns + "IsManufacturer").First().Value);
                        companyData.IsIndividual = Convert.ToBoolean(xDocument.Descendants(ns + "IsIndividual").First().Value);
                        companyData.IsSoleProprietorship = Convert.ToBoolean(xDocument.Descendants(ns + "IsSoleProprietorship").First().Value);
                        companyData.IsPartnership = Convert.ToBoolean(xDocument.Descendants(ns + "IsPartnership").First().Value);
                        companyData.IsCorporation = Convert.ToBoolean(xDocument.Descendants(ns + "IsCorporation").First().Value);
                        companyData.IsCreditCheckPerformed = Convert.ToBoolean(xDocument.Descendants(ns + "IsCreditCheckPerformed").First().Value);
                        companyData.IsCustomerExemptFromFuelTaxes = Convert.ToBoolean(xDocument.Descendants(ns + "IsCustomerExemptFromFuelTaxes").First().Value);
                        companyData.IsInactive = Convert.ToBoolean(xDocument.Descendants(ns + "IsInactive").First().Value);

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to parse the CompanyData response !!!", "API Tester", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return companyData;
        }
    }
}
