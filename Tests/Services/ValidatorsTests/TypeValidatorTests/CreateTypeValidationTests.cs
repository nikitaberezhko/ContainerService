using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Type;
using Services.Validation.Type;
using Xunit;

namespace Tests.Services.ValidatorsTests.TypeValidatorTests;

public class CreateTypeValidationTests
{
    private readonly TypeValidator _validator;
    
    public CreateTypeValidationTests()
    {
        _validator = new TypeValidator(
            Provider.Get<IValidator<CreateTypeModel>>(),
            new Mock<IValidator<UpdateTypeModel>>().Object,
            new Mock<IValidator<DeleteTypeModel>>().Object,
            new Mock<IValidator<GetTypeByIdModel>>().Object,
            new Mock<IValidator<GetAllTypesModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new CreateTypeModel
        {
            Name = "New container type",
            PricePerDay = 1000
        };

        // Act
        var actual = await _validator.ValidateAsync(model);

        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Name_Is_Empty()
    {
        // Arrange
        var model = new CreateTypeModel
        {
            Name = "",
            PricePerDay = 1000
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PricePerDay_Is_Less_Than_1()
    {
        // Arrange
        var model = new CreateTypeModel
        {
            Name = "New container type",
            PricePerDay = 0
        };

        // Act

        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}