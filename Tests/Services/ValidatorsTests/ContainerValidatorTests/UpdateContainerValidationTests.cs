using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class UpdateContainerValidationTests
{
    private readonly ContainerValidator _validator;

    public UpdateContainerValidationTests()
    {
        _validator = new ContainerValidator(
            new Mock<IValidator<CreateContainerModel>>().Object,
            Provider.Get<IValidator<UpdateContainerModel>>(),
            new Mock<IValidator<DeleteContainerModel>>().Object,
            new Mock<IValidator<GetContainerByIdModel>>().Object,
            new Mock<IValidator<GetContainerByIsoModel>>().Object,
            new Mock<IValidator<GetContainersByTypeIdModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model_And_EngagedUntil_Null()
    {
        // Arrange
        var model = new UpdateContainerModel
        {
            Id = Guid.NewGuid(),
            TypeId = 1,
            IsoNumber = "ABC123",
            EngagedUntil = null,
            IsEngaged = false
        };

        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model_And_EngagedUntil_Not_Null()
    {
        // Arrange
        var model = new UpdateContainerModel
        {
            Id = Guid.NewGuid(),
            TypeId = 1,
            IsoNumber = "ABC123",
            EngagedUntil = DateTime.Now,
            IsEngaged = true
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
        var model = new UpdateContainerModel
        {
            Id = Guid.Empty,
            TypeId = 1,
            IsoNumber = "ABC123",
            EngagedUntil = DateTime.Now,
            IsEngaged = true
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Iso_Number_Is_Empty()
    {
        // Arrange
        var model = new UpdateContainerModel
        {
            Id = Guid.NewGuid(),
            TypeId = 1,
            IsoNumber = "",
            EngagedUntil = DateTime.Now,
            IsEngaged = true
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_EngagedUntil_Is_Less_Than_2020_01_01()
    {
        // Arrange
        var model = new UpdateContainerModel
        {
            Id = Guid.NewGuid(),
            TypeId = 1,
            IsoNumber = "ABC123",
            EngagedUntil = new DateTime(2019, 12, 31),
            IsEngaged = true
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}