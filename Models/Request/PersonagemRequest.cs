using System;
using System.Collections;
using System.Collections.Generic;

namespace interclasse.Models.Request
{
    public class PersonagemRequest
    {
        public string Filme { get; set; }

        public List<string> Personagens { get; set; }
    }
}