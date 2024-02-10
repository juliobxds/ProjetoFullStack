using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using ProjetoFullStack.Domain.DTOS;
using ProjetoFullStack.Domain.Models;
using ProjetoFullStack.Repositorios;
using ProjetoFullStack.Repositorios.Interfaces;
using ProjetoFullStack.ViewModels;
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
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes() {
            List<ClienteModel> clientes = await clienteRepositorio.BuscarTodosClientes();
            return Ok(clientes);
        }

        [HttpGet]
        public async Task<ActionResult<ClienteModel>> BuscarPorId(int id) {

            ClienteModel cliente = await clienteRepositorio.BuscarClientePorId(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult> AdicionarCliente(ClienteModel cliente) {
            ClienteModel clienteAtt = await clienteRepositorio.AdicionarCliente(cliente);
            return Ok(clienteAtt);

        }

    }
}