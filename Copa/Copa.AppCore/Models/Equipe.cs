using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Copa.AppCore.Models
{
    public class Equipe
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public int Gols { get; set; }
    }
}
