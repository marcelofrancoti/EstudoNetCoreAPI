using Imobi.Business.BusinessConcretas;
using Imobi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Imobi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefoneController : ControllerBase
    {
        TelefoneBusiness _telefoneBusiness = new TelefoneBusiness();

        // GET: api/<TelefoneController>
        [HttpGet]
        public IEnumerable<Telefone> Get()
        {
            return _telefoneBusiness.BuscarTodos();
        }

        // GET api/<TelefoneController>/5
        [HttpGet("{id}")]
        public Telefone Get(int id)
        {
            return _telefoneBusiness.BuscarPorId(id);
        }

        [HttpGet("{ddd}/{numero}")]
        public Telefone GetDDDTelefone(int ddd, int numero)
        {
            return _telefoneBusiness.BuscarTodos().Where<Telefone>(f => f.ddd == ddd && f.numero == numero).FirstOrDefault();
        }


        // POST api/<TelefoneController>
        [HttpPost]
        public void Post([FromBody] Telefone telefone)
        {
            _telefoneBusiness.Inserir(telefone);
        }

        // PUT api/<TelefoneController>/5
        [HttpPut("{id}")]
        public void Put( [FromBody] Telefone telefone)
        {
            _telefoneBusiness.Atualizar(telefone);
        }

        // DELETE api/<TelefoneController>/5
        [HttpDelete("{ddd}/{numero}")]
        public void Delete(int ddd, int numero)
        {
            _telefoneBusiness.Excluir(new Telefone() { ddd = ddd, numero = numero});
        }
    }
}
