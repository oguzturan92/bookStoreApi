using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Book.Commands.Create;
using Application.Interfaces;
using Application.Interfaces.IWriteRepositories;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace BookStore.Tests.Features.Book
{
    public class CreateBookCommandHandlerTests
    {
        private readonly Mock<IBookWriteRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly CreateBookCommandHandler _handler;
        private readonly Mock<IValidator<CreateBookCommandRequest>> _mockValidator;

        public CreateBookCommandHandlerTests()
        {
            _mockRepo = new Mock<IBookWriteRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockValidator = new Mock<IValidator<CreateBookCommandRequest>>();

            _handler = new CreateBookCommandHandler(
                _mockRepo.Object,
                _mockMapper.Object,
                _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenBookIsCreated()
        {
            // Arrange
            var request = new CreateBookCommandRequest
            {
                Title = "Test Kitap",
                Author = "Test Yazar",
                CategoryIds = new List<int> { 1 }
            };

            _mockValidator.Setup(v => v.ValidateAsync(It.IsAny<CreateBookCommandRequest>(), It.IsAny<CancellationToken>()))
                        .ReturnsAsync(new ValidationResult());

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Core.Domain.Entities.Book>()))
                    .Returns(Task.CompletedTask); // çünkü void

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Success.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }
    }
}