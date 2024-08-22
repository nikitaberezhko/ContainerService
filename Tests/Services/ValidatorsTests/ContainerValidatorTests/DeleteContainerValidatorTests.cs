using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class DeleteContainerValidatorTests
{
    private readonly ContainerValidator _validator;

    public DeleteContainerValidatorTests()
    {
        _validator = new ContainerValidator(
            new Mock<IValidator<CreateContainerModel>>().Object,
            new Mock<IValidator<UpdateContainerModel>>().Object,
            Provider.Get<IValidator<DeleteContainerModel>>(),
            new Mock<IValidator<GetContainerByIdModel>>().Object,
            new Mock<IValidator<GetContainerByIsoModel>>().Object,
            new Mock<IValidator<GetContainersByTypeIdModel>>().Object);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new DeleteContainerModel
        {
            Id = Guid.NewGuid()
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Id_Is_Invalid()
    {
        // Arrange
        var model = new DeleteContainerModel
        {
            Id = Guid.Empty
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}