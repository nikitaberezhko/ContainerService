using Exceptions.Contracts.Services;
using FluentValidation;
using Moq;
using Services.Models.Request.Container;
using Services.Validation.Container;
using Xunit;

namespace Tests.Services.ValidatorsTests.ContainerValidatorTests;

public class GetContainersByTypeIdValidatorTests
{
    private readonly ContainerValidator _validator;
    
    public GetContainersByTypeIdValidatorTests()
    {
        _validator = new ContainerValidator(
            new Mock<IValidator<CreateContainerModel>>().Object,
            new Mock<IValidator<UpdateContainerModel>>().Object,
            new Mock<IValidator<DeleteContainerModel>>().Object,
            new Mock<IValidator<GetContainerByIdModel>>().Object,
            new Mock<IValidator<GetContainerByIsoModel>>().Object,
            Provider.Get<IValidator<GetContainersByTypeIdModel>>());
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetContainersByTypeIdModel
        {
            TypeId = 1,
            Page = 1,
            PageSize = 10
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_TypeId_Less_Than_0()
    {
        // Arrange
        var model = new GetContainersByTypeIdModel
        {
            TypeId = 0,
            Page = 1,
            PageSize = 10
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_Page_Less_Than_1()
    {
        // Arrange
        var model = new GetContainersByTypeIdModel
        {
            TypeId = 1,
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
        var model = new GetContainersByTypeIdModel
        {
            TypeId = 1,
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
        var model = new GetContainersByTypeIdModel
        {
            TypeId = 1,
            Page = 1,
            PageSize = 51
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    } 
}