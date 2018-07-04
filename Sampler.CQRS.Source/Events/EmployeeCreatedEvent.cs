using System;

namespace Sampler.CQRS.Source.Events
{
    public class EmployeeCreatedEvent
    {
        public int EmployeeId { get; set; }

        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDay { get; set; }

        public string Position { get; set; }
    }
}
