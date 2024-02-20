using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using ProjetoFullStack.Repositorios.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoFullStack.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase {
        private readonly IClienteRepositorio clienteRepositorio;
        public ClienteController(IClienteRepositorio clienteRepositorio) {
            this.clienteRepositorio = clienteRepositorio;

        }
        [HttpGet("TodosClientes")]
        public async Task<ActionResult<List<ClienteDto>>> BuscarTodosClientes() {
            List<ClienteDto> clientes = await clienteRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet("Id")]
        public async Task<ActionResult<ClienteDto>> BuscarPorId(int id) {
            ClienteDto cliente = await clienteRepositorio.BuscarClientePorId(id);
            return Ok(cliente);
        }
        [HttpPost("Adicionar")]
        public async Task<ActionResult<ClienteDto>> Adicionar([FromBody] ClienteDto cliente) {
            var clienteAdd = await clienteRepositorio.AdicionarCliente(cliente);
            return Ok(clienteAdd);
        }

        [HttpPut("Atualizar")]
        public async Task<ActionResult<ClienteDto>> Atualizar([FromBody] ClienteDto cliente, int id) {
            ClienteModel clienteAtt = await clienteRepositorio.AtualizarCliente(cliente, id);
            return Ok(cliente);
        }

        [HttpDelete("Id")]

        public async Task<ActionResult<ClienteDto>> Deletar(int id) {
            bool apagado = await clienteRepositorio.DeletarCliente(id);
            return Ok(apagado);
        }
    }
}