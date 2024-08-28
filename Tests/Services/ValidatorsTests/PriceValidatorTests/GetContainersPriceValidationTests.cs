using Exceptions.Contracts.Services;
using FluentValidation;
using Services.Models.Request.Price;
using Services.Validation.Price;
using Xunit;

namespace Tests.Services.ValidatorsTests.PriceValidatorTests;

public class GetContainersPriceValidationTests
{
    private readonly PriceValidator _validator;
    
    public GetContainersPriceValidationTests()
    {
        _validator = new PriceValidator(Provider.Get<IValidator<GetContainersPriceModel>>());    
    }

    [Fact]
    public async Task ValidateAsync_Should_Be_Valid_With_Valid_Model()
    {
        // Arrange
        var model = new GetContainersPriceModel
        {
            ContainerIds = new List<Guid> { Guid.NewGuid() }
        };
        
        // Act
        var actual = await _validator.ValidateAsync(model);
        
        // Assert
        Assert.True(actual);
    }
    
    [Fact]
    public async Task ValidateAsync_Should_Throw_ServiceException_If_ContainerTypeIds_Is_Empty()
    {
        // Arrange
        var model = new GetContainersPriceModel
        {
            ContainerIds = new List<Guid>()
        };
        
        // Act
        
        // Assert
        await Assert.ThrowsAsync<ServiceException>(async () => await _validator.ValidateAsync(model));
    }
}