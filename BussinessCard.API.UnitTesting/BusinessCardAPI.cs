using BusinessCard.Application.Commands.BusinessCard.Create;
using BusinessCard.Application.Commands.BusinessCard.Delete;
using BusinessCard.Application.Common;
using BusinessCard.Application.DTOs.BusinessCard;
using BusinessCard.Application.Extensions;
using BusinessCard.Application.Queries.BusinessCard;
using BusinessCard.Application.ReadModels.BusinessCard;
using BusinessCard.Domain.Enums;
using BusinessCard.Server.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;


namespace BusinessCard.Tests
{
    public class BusinessCardControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly BusinessCardController _controller;

        public BusinessCardControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new BusinessCardController(_mediatorMock.Object);
        }

        [Fact]
        public async Task Create_ShouldReturnOk_WhenBusinessCardIsCreated()
        {
            // Arrange
            var request = new CreateBusinessCardRequestDto
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1990, 1, 1),
                CountryCode = "+1",
                Number = "1234567890",
                Street = "123 Main St",
                City = "Anytown",
                ZipCode = "12345",
                Photo = null
            };

            var createResult = new Result<Guid> { Data = Guid.NewGuid() };
            createResult.Successful();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateBusinessCardCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(createResult);

            // Act
            var result = await _controller.Create(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task Create_ShouldReturnBadRequest_WhenCreationFails()
        {
            // Arrange
            var request = new CreateBusinessCardRequestDto
            {
                Name = "John Doe",
                Email = "johndoe@example.com",
                Gender = Gender.Male,
                DateOfBirth = new DateTime(1990, 1, 1),
                CountryCode = "+1",
                Number = "1234567890",
                Street = "123 Main St",
                City = "Anytown",
                ZipCode = "12345",
                Photo = null
            };

            var createResult = new Result<Guid> { };
            createResult.Failed();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<CreateBusinessCardCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(createResult);

            // Act
            var result = await _controller.Create(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnOk_WhenBusinessCardIsDeleted()
        {
            // Arrange
            var deleteResult = new Result<bool>();
            deleteResult.Successful();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteBusinessCardCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(deleteResult);

            // Act
            var result = await _controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_ShouldReturnBadRequest_WhenDeletionFails()
        {
            // Arrange
            var deleteResult = new Result<bool>();
            deleteResult.Failed();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<DeleteBusinessCardCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(deleteResult);

            // Act
            var result = await _controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Search_ShouldReturnOk_WhenSearchIsSuccessful()
        {
            // Arrange
            var searchResult = new Result<List<BusinessCardReadModel>> { Data = new List<BusinessCardReadModel>() };
            searchResult.Successful();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetBusinessCardsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(searchResult);

            // Act
            var result = await _controller.Search(new DataTablesParameters());

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Search_ShouldReturnBadRequest_WhenSearchFails()
        {
            // Arrange
            var searchResult = new Result<List<BusinessCardReadModel>> { };
            searchResult.Failed();

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<GetBusinessCardsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(searchResult);

            // Act
            var result = await _controller.Search(new DataTablesParameters());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
