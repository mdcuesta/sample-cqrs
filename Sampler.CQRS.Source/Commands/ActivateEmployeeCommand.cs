using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class ActivateEmployeeCommand : ICommand
    {
        public int EmployeeId { get; set; }

        public string Comment { get; set; }
    }
}
