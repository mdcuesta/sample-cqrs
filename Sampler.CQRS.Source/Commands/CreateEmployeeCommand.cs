using System;
using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class CreateEmployeeCommand : ICommand
    {
        public string EmployeeCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sex { get; set; }

        public DateTime BirthDay { get; set; }

        public string Position { get; set; }
    }
}
