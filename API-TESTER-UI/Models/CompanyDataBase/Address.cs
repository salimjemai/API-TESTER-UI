using DevExpress.Mvvm.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API_TESTER_UI.Models.CompanyDataBase
{
    public class Address
    {
        public string Title { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public string AddressLines { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string StateAbbreviation { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string CountryAbbreviation { get; set; }
        public string DefaultTaxCode { get; set; }
        public string Comments { get; set; }
        public bool IsDefaultBillingAddress { get; set; }
        public bool IsDefaultShippingAddress { get; set; }
        public bool IsDefaultAddress { get; set; }
        public string StatusMessage { get; set; }
        public string ErrorMessages { get; set; }   


    }
}
