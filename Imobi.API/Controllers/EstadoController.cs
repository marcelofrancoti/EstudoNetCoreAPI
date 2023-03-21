using Imobi.Business.BusinessConcretas;
using Imobi.Business.Interfaces;
using Imobi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Imobi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {
       
        IEstadoBusiness _estadoBusines;
        public EstadoController(IEstadoBusiness estadoBusiness)
        {
            _estadoBusines = estadoBusiness;
        }

        //GET: api/<EstadoController>
        [HttpGet]
        public IEnumerable<Estado> Get()
        {
            return _estadoBusines.BuscarTodos();
        }

        // GET api/<EstadoController>/5
        [HttpGet("{Uf}")]
        public string Get(string Uf)
        {
            return _estadoBusines.BuscarTodos().Where(_ => _.UF == Uf).FirstOrDefault().DESCRICAO;

        }
    }
}
