    using System.Collections.Generic;

namespace Final_Project.Models
{
    public class Property
    {
        public int Id { get; set; }
        public string LOGO { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int PropertyTypeId { get; set; }
        public int PropertySize { get; set; }
        public int NumBedrooms { get; set; }
        public int NumBathrooms { get; set; }
        public int PropertyStatusId { get; set; }
        public int EmployeeId { get; set; }

        // Navigation properties
        public virtual PropertyType PropertyType { get; set; }
        public virtual PropertyStatus PropertyStatus { get; set; }
        public virtual Employee Employee { get; set; }
    }

}
