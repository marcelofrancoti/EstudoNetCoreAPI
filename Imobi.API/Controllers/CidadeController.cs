using Imobi.Business.BusinessConcretas;
using Imobi.Business.Interfaces;
using Imobi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Imobi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CidadeController : ControllerBase 
    {

        ICidadeBusiness _cidade;

        public CidadeController(ICidadeBusiness cidadeBusiness) {

            _cidade = cidadeBusiness;
        }

        // GET: api/<CidadeController>
        [HttpGet]
        public IEnumerable<Cidade> Get()
        {
            return _cidade.BuscarTodos();    
        }

        // GET api/<CidadeController>/5
        [HttpGet("{Nome}")]
        public string Get(string Nome)
        {
            return _cidade.BuscarTodos().Where<Cidade>(f => f.NOME_CIDADE == Nome).FirstOrDefault().NOME_CIDADE;
        }

        // GET api/<CidadeController>/5
        [HttpGet("{Id}")]
        public string Get(int Id)
        {
            return _cidade.BuscarPorId(Id).NOME_CIDADE;

        }

        // POST api/<CidadeController>
        [HttpPost]
        public void Post([FromBody] Cidade cidade)
        {
            _cidade.Inserir(cidade);
        }

        // PUT api/<CidadeController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Cidade cidade)
        {
            _cidade.Atualizar(cidade);
        }

        // DELETE api/<TelefoneController>/5
        [HttpDelete("{nome}")]
        public void Delete(string nome, int id)
        {
            _cidade.Excluir(new Cidade() { NOME_CIDADE = nome, ESTADO_ID = id });
        }



    }
}
