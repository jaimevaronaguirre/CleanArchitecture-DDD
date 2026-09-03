using CleanArchitecture.Application.Abstractions.Messaging;
using CleanArchitecture.ArchitectureTests.Infrastructure;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace CleanArchitecture.ArchitectureTests.ApplicationTests
{
    public class ApplicationTests : BaseTest
    {
        [Fact]
        public void CommandHandlers_Should_NotPublic()
        {
            var resultados = Types.InAssembly(ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(ICommandHandler<>))
                .Or()
                .ImplementInterface(typeof(ICommandHandler<,>))
                .Should()
                .NotBePublic()
                .GetResult();

            resultados.IsSuccessful.Should().BeTrue();
            
        }

        [Fact]
        public void QueryHandlers_Should_NotPublic()
        {
            var resultados = Types.InAssembly(ApplicationAssembly)
                .That()
                .ImplementInterface(typeof(IQueryHandler<,>))                
                .Should()
                .NotBePublic()
                .GetResult();

            resultados.IsSuccessful.Should().BeTrue();

        }
    }
}
