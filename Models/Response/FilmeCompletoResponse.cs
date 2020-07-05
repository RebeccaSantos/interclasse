using System;
using System.Collections;
using System.Collections.Generic;


namespace interclasse.Models.Response
{

    public class Filme    {
        public int id { get; set; }
        public string nome { get; set; } 
        public string genero { get; set; } 
        public decimal? avaliacao { get; set; } 
        public bool disponivel { get; set; } 
        public int? duracao { get; set; } 
        public DateTime lancamento { get; set; } 

    }

    public class Diretor    {
        public int id { get; set; }
        public string nome { get; set; } 
        public DateTime nascimento { get; set; } 

    }

    public class Elenco    {
        public int id { get; set; }
        public string ator { get; set; } 
        public decimal altura { get; set; } 
        public DateTime nascimento { get; set; } 
        public string personagem { get; set; } 

    }

    public class FilmeCompletoResponse    {
        public Filme filme { get; set; } 
        public Diretor diretor { get; set; } 
        public List<Elenco> elenco { get; set; } 

    }

}