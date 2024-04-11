using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Samurai.Api.Controllers;
using Samurai.Repo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samurai.Tests.Controllers
{
    public class SamuraiControllerTests
    {
        [Fact]
        public void GetAll_ShouldReturnStatusCode200_WhenSamuraiExists()
        {

            // Arrange
            var mockRepository = new Mock<ISamuraiRepository>();
            var mockMappingService = new Mock<IMappingService>();
            var controller = new SamuraiController(mockRepository.Object, mockMappingService.Object);

            // Act
            var result = controller.GetAll() as ObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);

        }
    }
}
