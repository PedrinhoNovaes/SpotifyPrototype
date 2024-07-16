using Microsoft.AspNetCore.Mvc;
using Moq;
using SpotifyPrototype.Application.Streaming.Dto;
using SpotifyPrototype.Application.Streaming;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyPrototype.Api.Controllers;

namespace SpotifyPrototype.Tests
{
    public class AutorTests
    {
        [Fact]
        public void GetAutor_DeveRetornarNotFound_QuandoAutorNaoEncontrado()
        {
            // Arrange
            var mockAutorService = new Mock<AutorService>();
            mockAutorService.Setup(x => x.Obter(It.IsAny<Guid>())).Returns((AutorDto)null);
            var controller = new AutorController(mockAutorService.Object, null);

            // Act
            var result = controller.GetAutor(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void SeveAutor_DeveRetornarCreated_QuandoModeloValido()
        {
            // Arrange
            var mockAutorService = new Mock<AutorService>();
            mockAutorService.Setup(x => x.Criar(It.IsAny<AutorDto>())).Returns(new AutorDto { Id = Guid.NewGuid() });
            var controller = new AutorController(mockAutorService.Object, null);
            var autorDto = new AutorDto();

            controller.ModelState.Clear();

            // Act
            var result = controller.SeveAutor(autorDto);

            // Assert
            Assert.IsType<CreatedAtRouteResult>(result); // Use Assert.IsType
            var createdAtRoute = (CreatedAtRouteResult)result;
            Assert.Equal("DefaultApi", createdAtRoute.RouteName);
        }

        [Fact]
        public void SeveAutor_DeveRetornarBadRequest_QuandoModeloInvalido()
        {
            // Arrange
            var mockAutorService = new Mock<AutorService>();
            var controller = new AutorController(mockAutorService.Object, null);
            controller.ModelState.AddModelError("Propriedade", "Mensagem de erro");

            // Act
            var result = controller.SeveAutor(new AutorDto());

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
