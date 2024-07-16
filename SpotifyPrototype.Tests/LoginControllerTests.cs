using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SpotifyPrototype.Admin.Controllers;
using SpotifyPrototype.Admin.Models;
using SpotifyPrototype.Application;
using SpotifyPrototype.Domain.Admin.Aggregates;
using SpotifyPrototype.Repository.Repository.Admin;
using System.Reflection;



namespace SpotifyPrototype.Tests
{
    public class LoginControllerTests
    {
        [Fact]
        public async Task Login_ValidModel_ReturnsViewResult()
        {
            // Arrange
            var mockUsuarioAdminService = new Mock<UsuarioAdminService>(); // Mocking directly the service
            var controller = new AccountController(mockUsuarioAdminService.Object);
            var loginRequest = new LoginRequest { Email = "test@example.com", Senha = "password" };

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Login_InvalidModel_ReturnsViewResultWithModelError()
        {
            // Arrange
            var mockUsuarioAdminService = new Mock<UsuarioAdminService>(); // Mocking directly the service
            var controller = new AccountController(mockUsuarioAdminService.Object);
            controller.ModelState.AddModelError("Email", "Required"); // Simulating invalid model state
            var loginRequest = new LoginRequest();

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(viewResult.ViewData.ModelState.IsValid);
        }

        [Fact]
        public async Task Login_ValidCredentials_ReturnsRedirectToActionResult()
        {
            // Arrange
            var mockUsuarioAdminService = new Mock<UsuarioAdminService>();

            var expectedUsuarioAdmin = new UsuarioAdmin { Id = Guid.NewGuid(), Email = "test@example.com", Nome = "Test User" };

            mockUsuarioAdminService.Setup(service => service.Autenticate(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(expectedUsuarioAdmin);

            // Use reflection to access the private constructor (not recommended)
            var controllerField = typeof(AccountController).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(UsuarioAdminService) }, null);
            var controller = (AccountController)controllerField.Invoke(new object[] { mockUsuarioAdminService.Object });

            var loginRequest = new SpotifyPrototype.Admin.Models.LoginRequest { Email = "test@example.com", Senha = "password" };

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);

            // Verify that Autenticate was called with the correct arguments
            mockUsuarioAdminService.Verify(service => service.Autenticate(loginRequest.Email, loginRequest.Senha));
        }


        [Fact]
        public async Task Login_AuthenticationFails_ReturnsViewResultWithModelError()
        {
            // Arrange
            var mockUsuarioAdminService = new Mock<UsuarioAdminService>(); // Mocking directly the service
            var controller = new AccountController(mockUsuarioAdminService.Object);
            var loginRequest = new LoginRequest { Email = "test@example.com", Senha = "wrongpassword" };

            // Act
            var result = await controller.Login(loginRequest);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.False(viewResult.ViewData.ModelState.IsValid);
            Assert.Equal("Email ou senha incorreta.", viewResult.ViewData.ModelState["Erro_login"].Errors[0].ErrorMessage);
        }
    }
}
