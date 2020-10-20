using Copa.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Copa.AppCore.Implementations
{
    public interface ICopa_Service
    {
        IEnumerable<Equipe> GerarCopa(IEnumerable<Equipe> equipes);
    }
}
