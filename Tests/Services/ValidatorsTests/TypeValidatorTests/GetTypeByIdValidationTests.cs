using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Type;
using Services.Validation.Type;
using Xunit;

namespace Tests.Services.ValidatorsTests.TypeValidatorTests;

public class GetTypeByIdValidationTests
{
    private readonly TypeValidator _validator;
    
    public GetTypeByIdValidationTests()
    {
        _validator = new TypeValidator(
            new Mock<IValidator<CreateTypeModel>>().Object,
            new Mock<IValidator<UpdateTypeModel>>().Object,
            new Mock<IValidator<DeleteTypeModel>>().Object,
            Provider.Get<IValidator<GetTypeByIdModel>>(),
            new Mock<IValidator<GetAllTypesModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetTypeByIdModel
        {
            Id = 1
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
        var model = new GetTypeByIdModel
        {
            Id = 0
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}