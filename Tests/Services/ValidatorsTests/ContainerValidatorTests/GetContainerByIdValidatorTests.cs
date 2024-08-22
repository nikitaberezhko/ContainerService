using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class GetContainerByIdValidatorTests
{
    private readonly ContainerValidator _validator;

    public GetContainerByIdValidatorTests()
    {
        _validator = new ContainerValidator(
            new Mock<IValidator<CreateContainerModel>>().Object,
            new Mock<IValidator<UpdateContainerModel>>().Object,
            new Mock<IValidator<DeleteContainerModel>>().Object,
            Provider.Get<IValidator<GetContainerByIdModel>>(),
            new Mock<IValidator<GetContainerByIsoModel>>().Object,
            new Mock<IValidator<GetContainersByTypeIdModel>>().Object);
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetContainerByIdModel
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
        var model = new GetContainerByIdModel
        {
            Id = Guid.Empty
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}