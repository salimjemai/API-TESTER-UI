using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API_TESTER_UI.Models.UserManagement
{
    public class UserDeatils
    {
        
        public string StatusMessage { get; set; }

        
        
        public string ErrorMessages { get; set; }

        
        public string UserName { get; set; }

        
        public long UserKey { get; set; }

        
        public long? PurchaseLimit { get; set; }

        
        public long? RegularCost { get; set; }

        
        public long? OvertimeCost { get; set; }

        
        public long? DoubleTimeCost { get; set; }

        
        public long? RegularBurdenCost { get; set; }

        
        public long? OvertimeBurdenCost { get; set; }

        
        public long? DoubleTimeBurdenCost { get; set; }

        
        public string Fullname { get; set; }

        
        public string Description { get; set; }

        
        public string Department { get; set; }

        
        public string UserBadgeID { get; set; }

        
        public bool? CorridorIDRequired { get; set; }

        
        
        public UDF UserDefinedFields { get; set; }

        
        public bool? MustChangePassword { get; set; }

        
        public bool? CannotChangePassword { get; set; }

        
        public bool? AccountDisabled { get; set; }

        
        public bool? Locator { get; set; }

        
        public bool? SuspendLocator { get; set; }

        
        public bool? CanSelectLocator { get; set; }

        
        public bool? CanSelectToVendorLot { get; set; }

        
        public bool? ReceivingInspector { get; set; }

        
        public bool? TipOfDay { get; set; }

        
        public bool? LargeButtons { get; set; }

        
        public bool? DisablePersistence { get; set; }

        
        public bool? DefaultIncludeFuelActivity { get; set; }

        
        public bool? OnlyIncludeFuelActivity { get; set; }

        
        public bool? DefaultIncludeServiceActivity { get; set; }

        
        public bool? OnlyIncludeServiceActivity { get; set; }

        
        public bool? DefaultIncludePartSaleActivity { get; set; }

        
        public bool? OnlyIncludePartSaleActivity { get; set; }

        
        public bool? DefaultIncludeCateringActivity { get; set; }

        
        public bool? OnlyIncludeCateringActivity { get; set; }

        
        public bool? DefaultIncludeHotelActivity { get; set; }

        
        public bool? OnlyIncludeHotelActivity { get; set; }

        
        public bool? DefaultIncludeTransportationActivity { get; set; }

        
        public bool? OnlyIncludeTransportationActivity { get; set; }

        
        public bool? LaunchLogbookResearch { get; set; }

        
        public bool? CanEnterCompliance { get; set; }

        
        public bool? IncludeAllDefaultLogbookSearchCriteria { get; set; }
    }

    #region UDF
    [XmlType("UserDefinedFields")]
    public class UDF
    {
        
         public string Name { get; set; }

        
        public string Value { get; set; }
    }
    #endregion

    [XmlRoot("GetUserResult")]
    public class GetUserResult
    {
        [XmlArray]
        public UserDeatils UserDeatils { get; set; }
    }
}
