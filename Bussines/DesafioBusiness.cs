using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace interclasse.Business
{
    public class DesafioBusiness
    {
        Database.DesafioDatabase db = new Database.DesafioDatabase();
        

        public List<Models.TbFilme> InserirMuitos(List<Models.TbFilme> filmes)
        {
            foreach (Models.TbFilme filme in filmes)
            {
                if (filme.NmFilme == string.Empty)
                    throw new ArgumentException("Nome obrigatório");
                
                if(filme.DsGenero==string.Empty)
                        throw new ArgumentException("O campo genero é obrigatório");
                
                if(filme.NrDuracao<0)
                       throw new ArgumentException("Duraçao invalida");
                
                 if(filme.VlAvaliacao<0)
                         throw new ArgumentException("Avaliação invalida");
                 
                 if(filme.DtLancamento==new DateTime())
                           throw new ArgumentException("Data invalida");      
            }

            return db.InserirMuitos(filmes);
        }


        public Models.TbFilme InserirCompleto(Models.TbFilme filme)
        {
            if (filme.NmFilme == string.Empty)
                throw new ArgumentException("Nome obrigatório");
               


            if (filme.TbDiretor == null || filme.TbDiretor.Count == 0)
                throw new ArgumentException("Diretor obrigatório");

            if (filme.TbDiretor.FirstOrDefault().NmDiretor == string.Empty)
                throw new ArgumentException("Nome do diretor obrigatório");
              


            if (filme.TbFilmeAtor == null || filme.TbFilmeAtor.Count == 0)
                throw new ArgumentException("Elenco obrigatório");


            filme.TbFilmeAtor.ToList().ForEach(x => {
                if (x.NmPersonagem == string.Empty)
                    throw new ArgumentException("Nome do Personagem obrigatório");

                if (x.IdAtorNavigation == null)
                    throw new ArgumentException("Ator é obrigatório");

                if (x.IdAtorNavigation.NmAtor == string.Empty)
                    throw new ArgumentException("Nome do Ator é obrigatório");
                   
            });

            return db.InserirCompleto(filme);            
        }


        public bool ConsultarDiretorPorNome(string nome)
        {
            Models.TbDiretor diretor = db.ConsultarDiretorPorNome(nome);
            if (diretor == null)
                return false;
            else 
                return true;
        }


        public List<int> IndisponibilizarFilmesDoDiretor(string nomeDiretor)
        {
            return db.IndisponibilizarFilmesDoDiretor(nomeDiretor);
        }


        public bool ValidarPersonagens(string nome, List<string> personagens)
        {
            Models.TbFilme filme = db.ConsultarFilmePorNome(nome);
            if (filme == null)
                return false;

            bool todosExistem = 
                personagens.All(x => filme.TbFilmeAtor
                           .Any(fa => fa.NmPersonagem == x));

            return todosExistem;
        }

        public Models.TbFilme ConsultarFilme(string nome)
        {
            Models.TbFilme filme = db.ConsultarFilmePorNome(nome);
            return filme;
        }

        public List<int> RemoverPersonagens(int filmeId, List<string> personagens)
        {
            return db.RemoverPersonagens(filmeId, personagens);
        }

        public List<Models.TbFilme> ConsultarFilmes(string nome)
        {
            return db.ConsultarFilmes(nome);
        }

        public List<Models.TbAtor> ConsultarAtores(string nome)
        {
            return db.ConsultarAtores(nome);
        }


    }
}