using System;

namespace Sampler.CQRS.Caching.Models
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime? Birthday { get; set; }

        public string Position { get; set; }

        public string Comment { get; set; }

        public bool IsActive { get; set; }
    }

    public class DepartmentEmployee
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public int EmployeeId { get; set; }
    }
}
