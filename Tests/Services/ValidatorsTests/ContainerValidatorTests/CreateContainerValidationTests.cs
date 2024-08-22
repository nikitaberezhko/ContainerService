using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class CreateContainerValidationTests
{
    private readonly ContainerValidator _validator;

    public CreateContainerValidationTests()
    {
        _validator = new ContainerValidator(
            Provider.Get<IValidator<CreateContainerModel>>(),
            new Mock<IValidator<UpdateContainerModel>>().Object,
            new Mock<IValidator<DeleteContainerModel>>().Object,
            new Mock<IValidator<GetContainerByIdModel>>().Object,
            new Mock<IValidator<GetContainerByIsoModel>>().Object,
            new Mock<IValidator<GetContainersByTypeIdModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new CreateContainerModel
        {
            TypeId = 1,
            IsoNumber = "ABC123"
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_TypeId_Less_Than_1()
    {
        // Arrange
        var model = new CreateContainerModel
        {
            TypeId = 0,
            IsoNumber = "ABC123"
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_IsoNumber_Is_Empty()
    {
        // Arrange
        var model = new CreateContainerModel
        {
            TypeId = 1,
            IsoNumber = ""
        };

        // Act

        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    } 
}