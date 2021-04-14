using ClientesDB.Config;
using ClientesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientesDB.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ClienteContexto _clienteContexto;

        public ClientesController(IOptions<ConfigDB> opcoes)
        {
            _clienteContexto = new ClienteContexto(opcoes);

        }
        public async Task<IActionResult> Index()
        {
            return View(await _clienteContexto.Clientes.Find(a => true).ToListAsync());

        }

        [HttpGet]
        public IActionResult NovoCliente()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovoCliente(Cliente cliente)
        {
            cliente.ClientId = Guid.NewGuid();
            await _clienteContexto.Clientes.InsertOneAsync(cliente);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> AtualizarCliente(Guid clienteId)
        {
            Cliente cliente = await _clienteContexto.Clientes.Find(a => a.ClientId == clienteId).FirstOrDefaultAsync();
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarCliente(Cliente cliente)
        {
            await _clienteContexto.Clientes.ReplaceOneAsync(a => a.ClientId == cliente.ClientId, cliente);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> ExluirCLiente(Guid clientId)
        {
            await _clienteContexto.Clientes.DeleteOneAsync(a => a.ClientId == clientId);
            return RedirectToAction(nameof(Index));
        }
    }
}
