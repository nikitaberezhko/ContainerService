using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Type;
using Services.Validation.Type;
using Xunit;

namespace Tests.Services.ValidatorsTests.TypeValidatorTests;

public class GetAllTypesValidationTests
{
    private readonly TypeValidator _validator;
    
    public GetAllTypesValidationTests()
    {
        _validator = new TypeValidator(
            new Mock<IValidator<CreateTypeModel>>().Object,
            new Mock<IValidator<UpdateTypeModel>>().Object,
            new Mock<IValidator<DeleteTypeModel>>().Object,
            new Mock<IValidator<GetTypeByIdModel>>().Object,
            Provider.Get<IValidator<GetAllTypesModel>>());
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetAllTypesModel
        {
            Page = 1,
            PageSize = 10
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Page_Is_Less_Than_1()
    {
        // Arrange
        var model = new GetAllTypesModel
        {
            Page = 0,
            PageSize = 10
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PageSize_Less_Than_1()
    {
        // Arrange
        var model = new GetAllTypesModel
        {
            Page = 1,
            PageSize = 0
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_PageSize_Greater_Than_50()
    {
        // Arrange
        var model = new GetAllTypesModel
        {
            Page = 1,
            PageSize = 51
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}