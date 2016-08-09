using System;

namespace TimeClockData
{
    public class CompanyModel
    {
        public Guid CompanyId { get; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Website { get; set; }
    }
}
