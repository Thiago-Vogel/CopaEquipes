using Copa.AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Copa.AppCore.Implementations
{
    public interface IEquipes_Service
    {
        Task<IEnumerable<Equipe>> GetEquipes();
    }
}
