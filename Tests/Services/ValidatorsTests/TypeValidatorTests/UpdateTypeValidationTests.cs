using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Type;
using Services.Validation.Type;
using Xunit;

namespace Tests.Services.ValidatorsTests.TypeValidatorTests;

public class UpdateTypeValidationTests
{
    private readonly TypeValidator _validator;
    
    public UpdateTypeValidationTests()
    {
        _validator = new TypeValidator(
            new Mock<IValidator<CreateTypeModel>>().Object,
            Provider.Get<IValidator<UpdateTypeModel>>(),
            new Mock<IValidator<DeleteTypeModel>>().Object,
            new Mock<IValidator<GetTypeByIdModel>>().Object,
            new Mock<IValidator<GetAllTypesModel>>().Object);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new UpdateTypeModel
        {
            Id = 1,
            Name = "test",
            PricePerDay = 100
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Id_Less_Than_1()
    {
        // Arrange
        var model = new UpdateTypeModel
        {
            Id = 0,
            Name = "test",
            PricePerDay = 100
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Name_Is_Empty()
    {
        // Arrange
        var model = new UpdateTypeModel
        {
            Id = 1,
            Name = "",
            PricePerDay = 100
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    } 
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PricePerDay_Less_Than_1()
    {
        // Arrange
        var model = new UpdateTypeModel
        {
            Id = 1,
            Name = "test",
            PricePerDay = 0
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}