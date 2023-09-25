using Moq;
using AggregationApp.Application.Apartments;
using AggregationApp.Application.Apartments.GetApartment;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Application.UnitTests.Apartments.Queries;

public class GetApartmentByIdQueryHandlerTests
{
    [Fact]
    public async Task Handle_ShouldReturnCorrectApartment()
    {
        // Arrange
        var Apartment = new Apartment("Test", DateOnly.MinValue, new PrioritySuggestionService());
        var ApartmentDto = new ApartmentsResponse
        {
            Id = Apartment.Id,
            Title = Apartment.Title,
            DueDate = Apartment.DueDate,
            IsCompleted = Apartment.IsCompleted,
            Priority = Apartment.Priority
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
        Assert.Equal(ApartmentDto.Title, result.Title);
        Assert.Equal(ApartmentDto.DueDate, result.DueDate);
        Assert.Equal(ApartmentDto.IsCompleted, result.IsCompleted);
        Assert.Equal(ApartmentDto.Priority, result.Priority);
    }
}