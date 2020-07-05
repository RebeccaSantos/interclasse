using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace interclasse.Utils
{
    public class DesafioConversor
    {
        

        public List<Models.TbFilme> ParaTbFilme(List<Models.Request.FilmeRequest> req)
        {
            List<Models.TbFilme> filmes = 
                req.Select(x => new Models.TbFilme()
                {
                NmFilme = x.Filme,
                DsGenero = x.Genero,
                NrDuracao = x.Duracao,
                VlAvaliacao = x.Avaliacao,
                BtDisponivel = x.Disponivel,
                DtLancamento = x.Lancamento
                })
                .ToList();

            return filmes;
        }



        public List<Models.Response.FilmeResponse> ParaFilmeResponse(List<Models.TbFilme> filmes)
        {
            List<Models.Response.FilmeResponse> resp = 
                filmes.Select(x => new Models.Response.FilmeResponse()
                {
                Id = x.IdFilme,
                Filme = x.NmFilme,
                Genero = x.DsGenero,
                Duracao = x.NrDuracao,
                Avaliacao = x.VlAvaliacao,
                Disponivel = x.BtDisponivel,
                Lancamento = x.DtLancamento
                })
                .ToList();

            return resp;
        }



        public Models.TbFilme ParaTbFilme(Models.Request.FilmeCompletoRequest req)
        {
            Models.TbFilme filme = new Models.TbFilme();
            filme.NmFilme = req.filme.nome;
            filme.DsGenero = req.filme.genero;
            filme.NrDuracao = req.filme.duracao;
            filme.VlAvaliacao = req.filme.avaliacao;
            filme.BtDisponivel = req.filme.disponivel;
            filme.DtLancamento = req.filme.lancamento;

            filme.TbDiretor = new List<Models.TbDiretor>();
            filme.TbDiretor.Add(new Models.TbDiretor
            {
                NmDiretor = req.diretor.nome,
                DtNascimento = req.diretor.nascimento
            });


            filme.TbFilmeAtor = 
                req.elenco.Select(x => new Models.TbFilmeAtor() 
                {
                    NmPersonagem = x.personagem,

                    IdAtorNavigation = new Models.TbAtor() 
                    {
                        NmAtor = x.ator,
                        DtNascimento = x.nascimento,
                        VlAltura = x.altura
                    }
                }).ToList();
                

            return filme;
        }


        public Models.Response.FilmeCompletoResponse ParaFilmeCompletoResponse(Models.TbFilme filme)
        {
            Models.Response.FilmeCompletoResponse resp = new Models.Response.FilmeCompletoResponse();
            
            resp.filme = new Models.Response.Filme();
            resp.filme.id = filme.IdFilme;
            resp.filme.nome = filme.NmFilme;
            resp.filme.genero = filme.DsGenero;
            resp.filme.duracao = filme.NrDuracao;
            resp.filme.avaliacao = filme.VlAvaliacao;
            resp.filme.disponivel = filme.BtDisponivel;
            resp.filme.lancamento = filme.DtLancamento;


            if (filme.TbDiretor.Count > 0)
            {
                resp.diretor = new Models.Response.Diretor()
                {
                    id = filme.TbDiretor
                    .FirstOrDefault().IdDiretor,
                    nome = filme.TbDiretor
                    .FirstOrDefault().NmDiretor,
                    nascimento = filme.TbDiretor
                    .FirstOrDefault().DtNascimento
                };
            }

            resp.elenco = 
                filme.TbFilmeAtor.Select(x => new Models.Response.Elenco()
                {
                    id = x.IdAtorNavigation.IdAtor,
                    personagem = x.NmPersonagem,
                    ator = x.IdAtorNavigation.NmAtor,
                    altura = x.IdAtorNavigation.VlAltura,
                    nascimento = x.IdAtorNavigation.DtNascimento
                })
                .ToList();

            return resp;
        }


        public List<Models.Response.FilmeCompletoResponse> ParaFilmeCompletoResponse(List<Models.TbFilme> filmes)
        {
            List<Models.Response.FilmeCompletoResponse> resp = new List<Models.Response.FilmeCompletoResponse>();
            foreach (Models.TbFilme filme in filmes)
            {
                 Models.Response.FilmeCompletoResponse r = this.ParaFilmeCompletoResponse(filme);
                 resp.Add(r);
            }
            return resp;
        }



        public Models.Response.PersonagemResponse ParaPersonagemReponse(int filmeId, List<int> personagensId)
        {
            Models.Response.PersonagemResponse resp = new Models.Response.PersonagemResponse();
            resp.Filme = filmeId;
            resp.Personagens = personagensId;

            return resp;
        }



        
        
        public Models.Response.AtorCompletoResponse ParaAtorCompletoReponse(Models.TbAtor ator)
        {
            Models.Response.AtorCompletoResponse resp = new Models.Response.AtorCompletoResponse();
            resp.ator = new Models.Response.Ator();
            resp.ator.nome = ator.NmAtor;
            resp.ator.altura = ator.VlAltura;
            resp.ator.nascimento = ator.DtNascimento;

            resp.filmes = 
                ator.TbFilmeAtor.Select(x => new Models.Response.Filme3()
                {
                    filme = new Models.Response.Filme2()
                    {
                        nome = x.IdFilmeNavigation.NmFilme,
                        genero = x.IdFilmeNavigation.DsGenero,
                        duracao = x.IdFilmeNavigation.NrDuracao,
                        avaliacao = x.IdFilmeNavigation.VlAvaliacao,
                        disponivel = x.IdFilmeNavigation.BtDisponivel,
                        lancamento = x.IdFilmeNavigation.DtLancamento
                    },
                    personagem = new Models.Response.Personagem()
                    {
                        nome = x.NmPersonagem
                    }
                }).ToList();

            return resp;
        }



        public List<Models.Response.AtorCompletoResponse> ParaAtorCompletoReponse(List<Models.TbAtor> atores)
        {
            List<Models.Response.AtorCompletoResponse> resp = new List<Models.Response.AtorCompletoResponse>();
            foreach (Models.TbAtor ator in atores)
            {
                Models.Response.AtorCompletoResponse r = this.ParaAtorCompletoReponse(ator);
                resp.Add(r);
            }
            return resp;
        }

    }
}