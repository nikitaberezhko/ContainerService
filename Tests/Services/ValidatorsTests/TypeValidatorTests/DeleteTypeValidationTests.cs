using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Type;
using Services.Validation.Type;
using Xunit;

namespace Tests.Services.ValidatorsTests.TypeValidatorTests;

public class DeleteTypeValidationTests
{
    private readonly TypeValidator _validator;
    
    public DeleteTypeValidationTests()
    {
        _validator = new TypeValidator(
            new Mock<IValidator<CreateTypeModel>>().Object,
            new Mock<IValidator<UpdateTypeModel>>().Object,
            Provider.Get<IValidator<DeleteTypeModel>>(),
            new Mock<IValidator<GetTypeByIdModel>>().Object,
            new Mock<IValidator<GetAllTypesModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new DeleteTypeModel{ Id = 1 };

        // Act
        var actual = await _validator.ValidateAsync(model);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Id_Is_Less_Than_1()
    {
        // Arrange
        var model = new DeleteTypeModel{ Id = 0 };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}