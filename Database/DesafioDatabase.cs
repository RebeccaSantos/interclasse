using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace interclasse.Database
{
    public class DesafioDatabase
    {
        Models.apidbContext db = new Models.apidbContext();

        public List<Models.TbFilme> InserirMuitos(List<Models.TbFilme> filmes)
        {
            db.TbFilme.AddRange(filmes);
            db.SaveChanges();
            return filmes;
        }


        public Models.TbFilme InserirCompleto(Models.TbFilme filme)
        {
            db.TbFilme.Add(filme);
            db.SaveChanges();
            return filme;
        }


        public Models.TbDiretor ConsultarDiretorPorNome(string nome)
        {
            Models.TbDiretor diretor =
                db.TbDiretor.FirstOrDefault(x => x.NmDiretor == nome);

            return diretor;
        }

        public List<int> IndisponibilizarFilmesDoDiretor(string nomeDiretor)
        {
            List<Models.TbFilme> filmes =
                db.TbFilme.Where(x => x.TbDiretor.Any(d => d.NmDiretor == nomeDiretor))
                          .ToList();

            foreach (Models.TbFilme filme in filmes)
            {
                filme.BtDisponivel = false;
            }
            db.SaveChanges();

            List<int> filmeIds = filmes.Select(x => x.IdFilme).ToList();
            return filmeIds;
        }


        public Models.TbFilme ConsultarFilmePorNome(string nome)
        {
            Models.TbFilme filme = 
                db.TbFilme
                  .Include(x => x.TbFilmeAtor)
                  .FirstOrDefault(x => x.NmFilme == nome);

            return filme;
        }


        public List<int> RemoverPersonagens(int filmeId, List<string> personagens)
        {
            List<Models.TbFilmeAtor> filmeAtores = 
                db.TbFilmeAtor.Where(x => x.IdFilme == filmeId).ToList();

            
            List<int> personagensIds = new List<int>();
            foreach (string personagem in personagens)
            {
                Models.TbFilmeAtor filmeAtor = filmeAtores.FirstOrDefault(x => x.NmPersonagem == personagem);
                if (filmeAtor != null)
                {
                    personagensIds.Add(filmeAtor.IdFilmeAtor);
                    db.TbFilmeAtor.Remove(filmeAtor);
                }
            }

            db.SaveChanges();
            return personagensIds;
        }


        public List<Models.TbFilme> ConsultarFilmes(string nome)
        {
            List<Models.TbFilme> filmes =
                db.TbFilme
                    .Include(x => x.TbDiretor)
                    .Include(x => x.TbFilmeAtor)
                    .ThenInclude(x => x.IdAtorNavigation)
                    .Where(x => x.NmFilme.Contains(nome))
                    .ToList();

            return filmes;
        }


        public List<Models.TbAtor> ConsultarAtores(string nome)
        {
            List<Models.TbAtor> atores =
                db.TbAtor
                    .Include(x => x.TbFilmeAtor)
                    .ThenInclude(x => x.IdFilmeNavigation)
                    .Where(x => x.NmAtor.Contains(nome))
                    .ToList();

            return atores;
        }



    }
}