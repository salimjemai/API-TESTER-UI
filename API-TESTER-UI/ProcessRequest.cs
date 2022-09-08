using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Xml;

namespace API_TESTER_UI
{
    public class ProcessRequest
    {

        public HttpWebRequest CreateSOAPWebRequest(string requestType, string userChoice, string WsdlUrl)
        {
            HttpWebRequest Req = null;

            try
            {

                //Making Web Request    
                Req = (HttpWebRequest)WebRequest.Create(@WsdlUrl + requestType + ".asmx");

                //SOAPAction    
                Req.Headers.Add(@"SOAPAction:" + "http://corridor.aero/cws/" + userChoice);

                //Content_type    
                Req.ContentType = "text/xml;charset=\"utf-8\"";
                Req.Accept = "text/xml";

                //HTTP method    
                Req.Method = "POST";


            }
            catch (Exception exception)
            {
                MessageBox.Show($"{MessageBoxImage.Error} An error occurred while processed the API reques .. " + exception.Message);
            }

            //return HttpWebRequest    
            return Req;
        }

        // This function will be used to process all other API calls if the Login succeeds
        public XmlDocument processApiRequest(XmlDocument SOAPReqBody, HttpWebRequest request)
        {
            XmlDocument xmlData = new XmlDocument();
            // Save the response in a stream
            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //Geting response from request    
            using (WebResponse ServicResponse = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(ServicResponse.GetResponseStream()))
                {
                    MemoryStream mStream = new MemoryStream();
                    XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
                    XmlDocument document = new XmlDocument();

                    try
                    {
                        //reading stream    
                        string ServiceResult = rd.ReadToEnd();

                        // load the response into the document
                        document.LoadXml(ServiceResult);

                        // Indent the content of the XML document
                        writer.Formatting = Formatting.Indented;

                        // Write the XML into a formatting XML writer
                        document.WriteContentTo(writer);
                        xmlData = document;
                        writer.Flush();
                        mStream.Flush();

                        // Have to rewind the MemoryStream in order to read
                        // its contents.
                        mStream.Position = 0;

                        // Read MemoryStream contents into a StreamReader.
                        StreamReader sReader = new StreamReader(mStream);

                        // Extract the text from the StreamReader.
                        string formattedXml = sReader.ReadToEnd();
                        if (formattedXml.Contains("ErrorMessage"))
                        {
                            //Display all the book titles.
                            XmlNodeList elemList = document.GetElementsByTagName("ErrorMessage");
                            for (int i = 0; i < elemList.Count; i++)
                            {
                                MessageBox.Show(elemList[i].InnerText);
                            }
                            //MessageBox.Show(formattedXml);
                            //var endIt = Console.ReadLine();
                            //if (endIt.Length > 0)
                            //{
                            //    // exit application
                            //    Environment.Exit(0);
                            //}
                        }
                        else
                        {
                            //writting stream result on console    
                            //MessageBox.Show(formattedXml);
                            xmlData = document;
                            //Console.ReadLine();
                        }

                    }
                    catch (XmlException)
                    {
                        // Handle exception
                        MessageBox.Show($"{MessageBoxImage.Error} An error occurred while processing the API request ... ");
                    }
                    mStream.Close();
                    writer.Close();
                }
            }
            return xmlData;
        }

        public string LoginResponse(XmlDocument SOAPReqBody, HttpWebRequest request)
        {
            var response = "";
            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //Geting response from request    
            using (WebResponse ServicResponse = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(ServicResponse.GetResponseStream()))
                {
                    MemoryStream mStream = new MemoryStream();
                    XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
                    XmlDocument document = new XmlDocument();

                    try
                    {
                        //reading stream    
                        string ServiceResult = rd.ReadToEnd();

                        // load the response into the document
                        document.LoadXml(ServiceResult);

                        // Indent the content of the XML document
                        writer.Formatting = Formatting.Indented;

                        // Write the XML into a formatting XML writer
                        document.WriteContentTo(writer);
                        writer.Flush();
                        mStream.Flush();

                        // Have to rewind the MemoryStream in order to read
                        // its contents.
                        mStream.Position = 0;

                        // Read MemoryStream contents into a StreamReader.
                        StreamReader sReader = new StreamReader(mStream);

                        // Extract the text from the StreamReader.
                        string formattedXml = sReader.ReadToEnd();

                        //writting stream result on console    
                        var th = formattedXml.ToArray();
                        var isTokenthere = formattedXml.Contains("SessionToken");

                        if (isTokenthere && formattedXml.Length > 0)
                        {
                            var startIndex = 399;
                            var tokenLength = 36;
                            response = formattedXml.Substring(startIndex, tokenLength);
                        }
                    }
                    catch (XmlException t)
                    {
                        throw new Exception("An error occurred while logging in, please check your login or password and try again ..");
                    }
                    mStream.Close();
                    writer.Close();
                }
            }

            return response;
        }

        public string LogoutResponse(XmlDocument SOAPReqBody, HttpWebRequest request)
        {
            var formattedXml = "";
            using (Stream stream = request.GetRequestStream())
            {
                SOAPReqBody.Save(stream);
            }

            //Geting response from request    
            using (WebResponse ServicResponse = request.GetResponse())
            {
                using (StreamReader rd = new StreamReader(ServicResponse.GetResponseStream()))
                {
                    MemoryStream mStream = new MemoryStream();
                    XmlTextWriter writer = new XmlTextWriter(mStream, Encoding.Unicode);
                    XmlDocument document = new XmlDocument();

                    try
                    {
                        //reading stream    
                        string ServiceResult = rd.ReadToEnd();

                        // load the response into the document
                        document.LoadXml(ServiceResult);

                        // Indent the content of the XML document
                        writer.Formatting = Formatting.Indented;

                        // Write the XML into a formatting XML writer
                        document.WriteContentTo(writer);
                        writer.Flush();
                        mStream.Flush();

                        // Have to rewind the MemoryStream in order to read
                        // its contents.
                        mStream.Position = 0;

                        // Read MemoryStream contents into a StreamReader.
                        StreamReader sReader = new StreamReader(mStream);

                        // Extract the text from the StreamReader.
                        formattedXml = sReader.ReadToEnd();

                       
                    }
                    catch (XmlException t)
                    {
                        MessageBox.Show("An error occurred while logging in, please check your login or password and try again ..");
                    }
                    mStream.Close();
                    writer.Close();
                }
            }
            return formattedXml;
        }

        // Convert the bool  variable variables if true=1 else 0
        public int convertedBoolForUpdateUser(bool boolVar)
        {
            // Convert bool to int 0 or 1
            int convertedBool = boolVar ? 1 : 0;

            return convertedBool;
        }

        
    }
}
