using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {

        //Name Validate

        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", 1, 1, "Sapato");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalid()
        {
            Action action = ()=> new Product(-1, "Product Name", "Description", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = ()=> new Product(1, "CA", "Description", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = ()=> new Product(1, "", "Description", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }

        [Fact]
        public void CreateProduct_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = ()=> new Product(1, null, "Description", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, name is required");
        }

        //Description Validate

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            Action action = ()=> new Product(1, "Product name", "Desc", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, too short, minimum 5 characters");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = ()=> new Product(1, "Product name", "", 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, description is required");
        }

        [Fact]
        public void CreateProduct_WithNullDescriptionValue_DomainExceptionInvalidDescription()
        {
            Action action = ()=> new Product(1, "Product name", null, 1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid description, description is required");
        }
        
        //Price Validate

        [Fact]
        public void CreateProduct_WithPriceSmallerThanZero_DomainExceptionInvalidPrice()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", -1, 1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price value");
        }

        //Stock Validate

        [Fact]
        public void CreateProduct_WithStockSmallerThanZero_DomainExceptionInvalidStock()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", 1, -1, "Sapato");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock value");
        }

        //Image Validate

        [Fact]
        public void CreateProduct_WithImageBiggerThanTwoHundredFifty_DomainExceptionInvalidImage()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", 1, 1, "Sapatafadfhafjgajfhghjagfhjagfhjgahjgfjgahjfgdhjagfhjgahjfgahjsdgfhjagfjhgasdjfgajhfghjafghjafghjagfhjfdasfdasfdasfdasfdasfasdfasfasdfasdfdasfasdfdasfasdfdasfasdfasfasfadsfdasfasdfasfasdfadsfasfdasfasfdasfasfasfasaggjhgjhghjghjgjgjghjgjhgjgjgjhghjgjghjghjghjghjghjgfhjgahjdfgajfgadhjgfja");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", "Description", 1, 1, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact]
        public void CreateProduct_WithNullImage_NoDomainException()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", 1, 1, null);
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImage_NoDomainException()
        {
            Action action = ()=> new Product(1, "Product Name", "Description", 1, 1, "");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}