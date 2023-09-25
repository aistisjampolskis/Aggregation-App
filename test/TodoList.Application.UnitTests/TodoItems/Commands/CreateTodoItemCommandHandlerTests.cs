using Moq;
using AggregationApp.Application.Apartments.CreateApartment;
using AggregationApp.Domain.Apartments;
using AggregationApp.Infrastructure.Repositories;

namespace AggregationApp.Application.UnitTests.Apartments.Commands;

public class CreateApartmentCommandHandlerTests
{
    [Fact]
    public async Task Handle_ShouldPersistApartment()
    {
        // Arrange
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockRepository = new Mock<IApartmentRepository>();

        mockRepository.Setup(r => r.AddAsync(It.IsAny<Apartment>())).Returns(Task.CompletedTask);

        // You can either use a real PrioritySuggestionService or mock it.
        // If you just want to test the handler logic, it's often easier to use the real service if it doesn't have external dependencies.
        var priorityService = new PrioritySuggestionService();

        var handler = new CreateApartmentCommandHandler(mockRepository.Object, mockUnitOfWork.Object, priorityService);
        var command = new CreateApartmentCommand
        {
            Title = "Test Task",
            DueDate = DateOnly.MinValue
        };

        // Act
        await handler.Handle(command, CancellationToken.None);

        // Assert
        mockRepository.Verify(r => r.AddAsync(It.IsAny<Apartment>()), Times.Once());
        mockUnitOfWork.Verify(u => u.Commit(), Times.Once());
    }
}