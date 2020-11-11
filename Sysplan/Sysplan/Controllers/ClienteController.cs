using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sysplan.Models;


namespace Sysplan.Controllers
{
    public class ClienteController : Controller
    {

        private readonly IClienteDAL icliente;
        public ClienteController(IClienteDAL cliente)
        {
            icliente = cliente;
        }

        public IActionResult Index()
        {
            List<Cliente> listaCliente = new List<Cliente>();

            listaCliente = icliente.GetAllCliente().ToList();

            return View(listaCliente);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cliente cliente = icliente.Getcliente(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                icliente.Addcliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = icliente.Getcliente(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                icliente.Updatecliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Cliente cliente = icliente.Getcliente(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            icliente.Deletecliente(id);
            return RedirectToAction("Index");
        }
    }
}
