using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Copa.Web.Controllers;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Controllers
{
    public class CopaController_tests
    {
        Mock<ICopa_Service> _stub_service;
        Mock<CopaController> _mock_controller;

        public CopaController_tests()
        {
            _stub_service = new Mock<ICopa_Service>();
            _mock_controller = new Mock<CopaController>(_stub_service.Object);
        }

        [Fact]
        public void Get_ReturnsAnyValue()
        {
            List<Equipe> equipes = new List<Equipe>();
            int i = 0;
            while(i < 8)
            {
                Equipe e = new Equipe()
                {
                    Id = i.ToString(),
                    Nome = "teste" + i.ToString(),
                    Sigla = "tst" + i.ToString(),
                    Gols = i
                };
                equipes.Add(e);
                i++;
            }

            var actual = _mock_controller.Object.GerarCopa(equipes.ToArray());
            Assert.NotNull(actual);
        }

    }
}
