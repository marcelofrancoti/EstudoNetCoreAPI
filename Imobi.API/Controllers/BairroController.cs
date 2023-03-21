using Imobi.Business.BusinessConcretas;
using Imobi.Business.Interfaces;
using Imobi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Imobi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BairroController : ControllerBase
    {
        IBairroBusiness _bairroBusiness;
        public BairroController(IBairroBusiness bairroBusiness)
        {
            _bairroBusiness = bairroBusiness;

        }
        // GET: api/<EstadoController>
        [HttpGet]
        public IEnumerable<Bairro> Get()
        {
            Bairro bairro = new Bairro();
            return _bairroBusiness.BuscarTodos();

        }

        // GET api/<EstadoController>/5
        [HttpGet("{Id}")]
        public string Get(int Id)
        {
            return _bairroBusiness.BuscarPorId(Id).BAIRRO_NOME;
            
        }


        // POST api/<BairroController>
        [HttpPost]
        public void Post([FromBody] Bairro bairro)
        {
            _bairroBusiness.Inserir(bairro);
        }

        // PUT api/<BairroController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Bairro bairro)
        {
            _bairroBusiness.Atualizar(bairro);
        }

        // DELETE api/<BairroController>/5
        [HttpDelete("{nome}")]
        public void Delete(string nome)
        {
            _bairroBusiness.Excluir(new Bairro() { BAIRRO_NOME = nome });
        }

    }
}
