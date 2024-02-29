namespace Final_Project.Models
{
    using System;

    public class Contract
    {
        public int Id { get; set; }
        public int PropertyId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Navigation properties
        public virtual Property Property { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
    }

}
