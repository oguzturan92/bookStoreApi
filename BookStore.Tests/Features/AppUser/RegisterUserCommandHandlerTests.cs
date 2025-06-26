using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.AppUserDtos;
using Application.Features.Auth.Commands.Register;
using Application.Services;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace BookStore.Tests.Features.AppUser
{
    public class RegisterUserCommandHandlerTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IValidator<RegisterUserCommandRequest>> _mockValidator;
        private readonly RegisterUserCommandHandler _handler;

        public RegisterUserCommandHandlerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockValidator = new Mock<IValidator<RegisterUserCommandRequest>>();

            _handler = new RegisterUserCommandHandler(_mockUserService.Object, _mockValidator.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenRegistrationIsValid()
        {
            // Arrange
            var request = new RegisterUserCommandRequest
            {
                Name = "Ali",
                SurName = "Yılmaz",
                Email = "ali@example.com",
                UserName = "ali123",
                Password = "123456",
                RePassword = "123456"
            };

            // Validation başarılı
            _mockValidator.Setup(v => v.ValidateAsync(It.IsAny<RegisterUserCommandRequest>(), It.IsAny<CancellationToken>()))
                          .ReturnsAsync(new ValidationResult());

            // Kayıt başarılı
            _mockUserService.Setup(s => s.RegisterAsync(It.IsAny<RegisterUserDto>()))
                            .ReturnsAsync((true, null));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Success.Should().BeTrue();
            result.Errors.Should().BeNullOrEmpty();
        }

        [Fact]
        public async Task Handle_ShouldReturnError_WhenValidationFails()
        {
            // Arrange
            var request = new RegisterUserCommandRequest
            {
                Name = "",
                Email = "email"
            };

            var validationFailures = new List<ValidationFailure>
            {
                new ValidationFailure("Name", "İsim boş olamaz"),
                new ValidationFailure("Email", "Email formatı geçersiz")
            };

            _mockValidator.Setup(v => v.ValidateAsync(request, It.IsAny<CancellationToken>()))
                          .ReturnsAsync(new ValidationResult(validationFailures));

            // Act
            var result = await _handler.Handle(request, CancellationToken.None);

            // Assert
            result.Success.Should().BeFalse();
            result.Errors.Should().Contain("İsim boş olamaz");
            result.Errors.Should().Contain("Email formatı geçersiz");
        }
    }
}