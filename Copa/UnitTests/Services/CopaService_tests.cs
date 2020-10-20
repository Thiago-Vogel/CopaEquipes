using Copa.AppCore.Implementations;
using Copa.AppCore.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests.Services
{
    public class CopaService_tests
    {
        Mock<ICopa_Service> _mock_service;

        public CopaService_tests()
        {
            _mock_service = new Mock<ICopa_Service>();
        }

        [Fact]
        public void Get_ReturnsAnyValue()
        {
            List<Equipe> equipes = new List<Equipe>();
            int i = 0;
            while (i < 8)
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
            var actual = _mock_service.Object.GerarCopa(equipes);
            Assert.NotNull(actual);
        }
    }
}
