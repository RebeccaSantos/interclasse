using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace interclasse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class controlerinterclasse : ControllerBase
    {
        Utils.DesafioConversor conversor = new Utils.DesafioConversor();
        Business.DesafioBusiness  business = new Business.DesafioBusiness();

        
        [HttpPost("muitosfilmes")]
        public ActionResult<List<Models.Response.FilmeResponse>> InserirMuitosFilmes(List<Models.Request.FilmeRequest> req)
        {
            try
            {
                List<Models.TbFilme> filmes = conversor.ParaTbFilme(req);
                business.InserirMuitos(filmes);
                
                List<Models.Response.FilmeResponse> resp = conversor.ParaFilmeResponse(filmes);
                return resp;    
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }



        [HttpPost("filmecompleto")]
        public ActionResult<Models.Response.FilmeCompletoResponse> InserirFilmeCompleto(Models.Request.FilmeCompletoRequest req)
        {
            try
            {
                Models.TbFilme filme = conversor.ParaTbFilme(req);
                business.InserirCompleto(filme);
                
                Models.Response.FilmeCompletoResponse resp = conversor.ParaFilmeCompletoResponse(filme);
                return resp;    
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }



        [HttpPut("indisponibilizar")]
        public ActionResult<List<int>> Indisponibilizar(Models.Request.DiretorRequest req)
        {
            try 
            {
                bool existe = business.ConsultarDiretorPorNome(req.Diretor);
                if (!existe)
                    return NotFound();

                List<int> filmeIds = business.IndisponibilizarFilmesDoDiretor(req.Diretor);
                return filmeIds;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }
        


        [HttpDelete("personagens")]
        public ActionResult<Models.Response.PersonagemResponse> DeletarPersonagens(Models.Request.PersonagemRequest req)
        {
            try 
            {
                bool existe = business.ValidarPersonagens(req.Filme, req.Personagens);
                if (!existe)
                    return NotFound();

                Models.TbFilme filme = business.ConsultarFilme(req.Filme);
                List<int> personagensId = business.RemoverPersonagens(filme.IdFilme, req.Personagens);

                Models.Response.PersonagemResponse resp = conversor.ParaPersonagemReponse(filme.IdFilme, personagensId);
                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }
        
        
        
        
        [HttpGet("consultarfilmes")]
        public ActionResult<List<Models.Response.FilmeCompletoResponse>> ConsultarFilmes(string nome)
        {
            try
            {
                List<Models.TbFilme> filmes = business.ConsultarFilmes(nome);
                if (filmes.Count == 0)
                    return NotFound();

                List<Models.Response.FilmeCompletoResponse> resp = conversor.ParaFilmeCompletoResponse(filmes);
                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }



        [HttpGet("consultaratores")]
        public ActionResult<List<Models.Response.AtorCompletoResponse>> ConsultarAtores(string nome)
        {
            try
            {
                List<Models.TbAtor> atores = business.ConsultarAtores(nome);
                if (atores.Count == 0)
                    return NotFound();

                List<Models.Response.AtorCompletoResponse> resp = conversor.ParaAtorCompletoReponse(atores);
                return resp;
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }


    }



}