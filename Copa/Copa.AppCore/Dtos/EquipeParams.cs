﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Copa.AppCore.Dtos
{
    public class EquipeParams
    {
        public string id { get; set; }
        public string nome { get; set; }
        public string sigla { get; set; }
        public int gols { get; set; }
    }
}
