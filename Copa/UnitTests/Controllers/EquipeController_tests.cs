using AppCore.Implementations;
using AppCore.Models;
using AppCore.Services;
using Copa.AppCore.Implementations;
using Copa.Infrastructure.Services;
using Copa.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Controllers
{
    public class EntidadeController_tests
    {
        Mock<IEquipes_Service> _stub_service;
        Mock<EquipeController> _mock_controller;

        public EntidadeController_tests()
        {
            _stub_service = new Mock<IEquipes_Service>();
            _mock_controller = new Mock<EquipeController>(_stub_service.Object);
        }

        [Fact]
        public void Get_ReturnsAnyValue()
        {
            var actual = _mock_controller.Object.Get(null).Result;
            Assert.NotNull(actual);
        }

    }
}
