using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_TESTER_UI.Models.CompanyDataBase
{
    public class CompanyData
    {
        public string CompanyName { get; set; }
        public string CompanyCode { get; set; }
        public bool? IsCustomer { get; set; }
        public bool? IsVendor { get; set; }
        public string DefaultCurrency { get; set; }
        public bool? IsShippingHold { get; set; }
        public bool? IsTaxExempt { get; set; }
        public List<UserDefinedFields> UserDefinedField { get; set; }
        public string RepairStationNumber { get; set; }
        public string FAANumber { get; set; }
        public string DefaultBillingAddressTitle { get; set; }
        public string DefaultShippingAddressTitle { get; set; }
        public string DefaultAddressTitle { get; set; }
        public string DefaultPhoneTitle { get; set; }
        public string DefaultFaxTitle { get; set; }
        public bool? IsRepairStation { get; set; }
        public bool? IsCreditCardCompany { get; set; }
        public bool? IsAircraftManufacturer { get; set; }
        public bool? IsEngineManufacturer { get; set; }
        public bool? IsAPUManufacturer { get; set; }
        public bool? IsOtherManufacturer { get; set; }
        public bool? IsManufacturer { get; set; }
        public bool? IsIndividual { get; set; }
        public bool? IsSoleProprietorship { get; set; }
        public bool? IsPartnership { get; set; }
        public bool? IsCorporation { get; set; }
        public bool? IsCreditCheckPerformed { get; set; }
        public bool? IsCustomerExemptFromFuelTaxes { get; set; }
        public bool? IsInactive { get; set; }

    }


}

