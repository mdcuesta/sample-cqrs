using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Xunit;

namespace Sampler.CQRS.Core.Tests
{
    public class QueryDispatcherTests
    {
        private IServiceProvider serviceProvider;
        private QueryDispatcher target;

        public QueryDispatcherTests()
        {
            this.serviceProvider = Substitute.For<IServiceProvider>();
            this.target = new QueryDispatcher(this.serviceProvider);
        }

        [Fact]
        public void ShouldDispatch()
        {
            var query = Substitute.For<IQuery>();
            var expected = Substitute.For<IQueryResult>();
            var handler = Substitute.For<IQueryHandler<IQuery, IQueryResult>>();

            handler.Retrieve(query).Returns(expected);
            this.serviceProvider.GetService<IQueryHandler<IQuery, IQueryResult>>().Returns(handler);

            IQueryResult actual = this.target.Dispatch<IQuery, IQueryResult>(query);
            actual.Should().Be(expected);
        }
    }
}
