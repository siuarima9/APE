using System;
using APE.Application.Interfaces;
using APE.Application.ViewModels.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace APE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteAppService _clienteAppService;

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        [HttpPost]
        public IActionResult CadastrarCliente([FromBody] CadastrarClienteViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Model invalida");
                }

                _clienteAppService.Inserir(viewModel);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        [HttpDelete]
        public IActionResult DeletarCliente(Guid id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult ConexaoOk()
        {
            try
            {
                return Ok(_clienteAppService.ListarComContato());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


    }
}