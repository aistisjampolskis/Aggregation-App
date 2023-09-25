using FluentAssertions;
using Moq;
using AggregationApp.Domain.Apartments;

namespace AggregationApp.Domain.UnitTests.Apartments;

public class ApartmentTests
{
    [Fact]
    public void MarkAsCompleted_Should_Raise_ApartmentCompletedEvent()
    {
        // Arrange
        var Apartment = new Apartment("Test", DateOnly.FromDateTime(DateTime.UtcNow), new PrioritySuggestionService());

        // Act
        Apartment.MarkAsCompleted();

        // Assert
        var ApartmentCompletedEvent = Apartment.DomainEvents.OfType<ApartmentCompletedEvent>().SingleOrDefault();
        ApartmentCompletedEvent.Should().NotBeNull();
        ApartmentCompletedEvent!.Apartment.Should().Be(Apartment);
    }
}