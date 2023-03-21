using Imobi.Business.Interfaces;
using Imobi.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Imobi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaDePagamentoController : ControllerBase
    {

        IFormaDePagamentoBusiness _formaPag;

        public FormaDePagamentoController(IFormaDePagamentoBusiness formaDePagamentoController)
        {
            _formaPag = formaDePagamentoController;
        }

        // GET: api/<EstadoController>
        [HttpGet]
        public List<FormaDePagamento> Get()
        {
            FormaDePagamento formaDePagamento = new FormaDePagamento();
            var listaFormaDePagamento = _formaPag.selectTodasFormaDePagamento();

            return listaFormaDePagamento;
        }

        // GET api/<EstadoController>/5
        [HttpGet("{Descricao}")]
        public string Get(string Descricao)
        {
            var formaDePagamentoRetorno = _formaPag.selectFormaDePagamento_Descricao(Descricao);
            return formaDePagamentoRetorno;
        }
    }
}
