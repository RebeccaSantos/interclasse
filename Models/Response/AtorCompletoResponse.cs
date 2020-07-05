using System;
using System.Collections;
using System.Collections.Generic;

namespace interclasse.Models.Response
{

    public class Ator    {
        public string nome { get; set; } 
        public decimal altura { get; set; } 
        public DateTime nascimento { get; set; } 

    }

    public class Filme2    {
        public string nome { get; set; } 
        public string genero { get; set; } 
        public decimal? avaliacao { get; set; } 
        public bool disponivel { get; set; } 
        public int? duracao { get; set; } 
        public DateTime lancamento { get; set; } 

    }

    public class Personagem    {
        public string nome { get; set; } 

    }

    public class Filme3    {
        public Filme2 filme { get; set; } 
        public Personagem personagem { get; set; } 

    }

    public class AtorCompletoResponse {
        public Ator ator { get; set; } 
        public List<Filme3> filmes { get; set; } 
    }

}