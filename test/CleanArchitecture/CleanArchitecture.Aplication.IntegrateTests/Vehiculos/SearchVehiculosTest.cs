using CleanArchitecture.Application.IntegrateTests.Infrastructure;
using CleanArchitecture.Application.Vehiculos.SearchVehiculos;
using FluentAssertions;
using Xunit;

namespace CleanArchitecture.Application.IntegrateTests.Vehiculos
{
    public class SearchVehiculosTest : BaseIntegrationTest
    {
        public SearchVehiculosTest(IntegrationTestWebAppFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task SearchVehiculos_ShouldReturnsEmptyList_WhenDateRangeIsInvalid()
        {
            // Arrange
            var query = new SearchVehiculosQuery(
                new DateOnly(2023, 1, 1),
                new DateOnly(2022, 1, 1)
            );

            // Act
            var result = await Sender.Send(query);

            // Assert
            result.Value.Should().BeEmpty();
            // Add more assertions based on your expected results
        }

        [Fact]
        public async Task SearchVehiculos_ShouldReturnsVehiculos_WhenDateRangeIsValid()
        {
            // Arrange
            var query = new SearchVehiculosQuery(
                new DateOnly(2023, 1, 1),
                new DateOnly(2026, 1, 1)
            );

            // Act
            var result = await Sender.Send(query);

            // Assert
            result.IsSuccess.Should().BeTrue();
            // Add more assertions based on your expected results
        }
    }
}
