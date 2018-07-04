using Sampler.CQRS.Core;

namespace Sampler.CQRS.Source.Commands
{
    public class CreateDepartmentCommand : ICommand
    {
        public string Name { get; set; }
    }
}
