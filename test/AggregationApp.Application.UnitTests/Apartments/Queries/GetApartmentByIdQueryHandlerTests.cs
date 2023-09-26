using Moq;
using AggregationApp.Application.Apartments;
using AggregationApp.Application.Apartments.GetApartment;
using AggregationApp.Domain.Apartments;
using System.Globalization;

namespace AggregationApp.Application.UnitTests.Apartments.Queries;

public class GetApartmentByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnCorrectApartment()
    {
        string dateString = "2020-06-21T01:00:00";
        DateTime parsedDateTime;
        DateTime.TryParseExact(dateString, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDateTime);
        // Arrange
        var Apartment = new Apartment("Alytaus regiono tinklas", "Butas", "Ne GV", 35282, (decimal)0.034, parsedDateTime, (decimal)0);
        var ApartmentDto = new ApartmentResponse
        {
            Id = Apartment.Id,
            TINKLAS = Apartment.TINKLAS,
            OBT_PAVADINIMAS = Apartment.OBT_PAVADINIMAS,
            OBJ_GV_TIPAS = Apartment.OBJ_GV_TIPAS,
            OBJ_NUMERIS = Apartment.OBJ_NUMERIS,
            P_PLUS = Apartment.P_PLUS,
            PL_T = Apartment.PL_T,
            P_MINUS = Apartment.P_MINUS,

        };

        var mockRepository = new Mock<IApartmentRepository>();

        mockRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(Apartment);

        var handler = new GetApartmentByIdQueryHandler(mockRepository.Object);

        var query = new GetApartmentByIdQuery
        {
            Id = 1
        };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(ApartmentDto.TINKLAS, result.TINKLAS);
    }
}