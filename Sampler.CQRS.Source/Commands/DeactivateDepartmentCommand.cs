using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class DeactivateDepartmentCommand : ICommand
    {
        public int DepartmentId { get; set; }

        public string Comment { get; set; }
    }
}
