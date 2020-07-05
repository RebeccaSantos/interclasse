using  System;


namespace interclasse.Models.Request
{
    public class FilmeRequest
    {
        public string Filme { get; set; }
        public string Genero { get; set; }
        public decimal Avaliacao { get; set; }
        public int Duracao { get; set; }
        public bool Disponivel { get; set; }
        public DateTime Lancamento { get; set; }
    }
}