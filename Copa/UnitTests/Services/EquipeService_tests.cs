using AppCore.Implementations;
using AppCore.Models;
using AppCore.Services;
using Copa.AppCore.Implementations;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests.Services
{
    public class EquipeService_tests
    {
        Mock<IEquipes_Service> _mock_service;

        public EquipeService_tests()
        {
            _mock_service = new Mock<IEquipes_Service>();
        }

        [Fact]
        public void Get_ReturnsAnyValue()
        {
            var actual = _mock_service.Object.GetEquipes().Result;
            Assert.NotNull(actual);
        }
    }
}

