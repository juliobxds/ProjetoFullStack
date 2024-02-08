using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoFullStack.Models;

namespace ProjetoFullStack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ClienteModel>> BuscarTodosClientes() {
        return Ok();
        }
    }
}