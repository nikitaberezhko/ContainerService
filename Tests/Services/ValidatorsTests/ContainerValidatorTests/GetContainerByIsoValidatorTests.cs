using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class GetContainerByIsoValidatorTests
{
    private readonly ContainerValidator _validator;

    public GetContainerByIsoValidatorTests()
    {
        _validator = new ContainerValidator(
            new Mock<IValidator<CreateContainerModel>>().Object,
            new Mock<IValidator<UpdateContainerModel>>().Object,
            new Mock<IValidator<DeleteContainerModel>>().Object,
            new Mock<IValidator<GetContainerByIdModel>>().Object,
            Provider.Get<IValidator<GetContainerByIsoModel>>(),
            new Mock<IValidator<GetContainersByTypeIdModel>>().Object);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetContainerByIsoModel
        {
            IsoNumber = "ABC123"
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_IsoNumber_Is_Empty()
    {
        // Arrange
        var model = new GetContainerByIsoModel
        {
            IsoNumber = ""
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}