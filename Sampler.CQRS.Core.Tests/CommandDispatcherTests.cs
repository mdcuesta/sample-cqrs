using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Sampler.CQRS.Core.Tests
{
    public class CommandDispatcherTests
    {
        private IServiceProvider serviceProvider;
        private CommandDispatcher target;

        public CommandDispatcherTests()
        {
            this.serviceProvider = Substitute.For<IServiceProvider>();
            this.target = new CommandDispatcher(this.serviceProvider);
        }

        [Fact]
        public void ShouldDispatch()
        {
            var command = Substitute.For<ICommand>();
            var handler = Substitute.For<ICommandHandler<ICommand>>();

            var expected = new CommandResult(true);
            handler.Execute(command).Returns(expected);
            this.serviceProvider.GetService<ICommandHandler<ICommand>>().Returns(handler);

            CommandResult actual = this.target.Dispatch(command);
            actual.Should().Be(expected);
        }
    }
}
