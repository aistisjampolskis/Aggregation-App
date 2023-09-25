using AggregationApp.Domain.Apartments;

namespace AggregationApp.Domain.UnitTests.Apartments;

public class PrioritySuggestionServiceTests
{
    [Theory]
    [InlineData(5, "Low")]
    [InlineData(0, "High")]
    [InlineData(1, "High")]
    [InlineData(2, "Medium")]
    public void SuggestPriority_ShouldReturnExpectedPriority(int daysUntilDue, string expectedPriority)
    {
        // Arrange
        var service = new PrioritySuggestionService();
        var dueDate = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(daysUntilDue));
        var apartment = new Apartment("Test task", dueDate, service);

        // Act
        var priority = service.SuggestPriority(apartment);

        // Assert
        Assert.Equal(expectedPriority, priority);
    }
}