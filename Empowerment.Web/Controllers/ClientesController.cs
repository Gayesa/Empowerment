using Empowerment.Web.Data;
using Empowerment.Web.Data.Entities;
using Empowerment.Web.Helpers;
using Empowerment.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClientesController : Controller
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;

        public ClientesController(DataContext context, IUserHelper userHelper, ICombosHelper combosHelper )
        {
            _context = context;
            _userHelper = userHelper;
            _combosHelper = combosHelper;
        }

        // GET: Clientes
        public IActionResult Index()
        {
            return View( _context.Clientes
                .Include(c => c.User)
                .Include(c => c.Inscripciones)
                );
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.User)
                .Include(c => c.Inscripciones)
                .ThenInclude(i => i.Plan)
                .Include(c => c.Inscripciones)
                .ThenInclude(i => i.Seguimientos)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AddUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    FechaInscripcion = model.FechaInscripcion,
                    TipoDocumento = model.TipoDocumento,
                    Documento = model.Documento,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Direccion = model.Direccion,
                    PhoneNumber = model.PhoneNumber,
                    FechaNacimiento = model.FechaNacimiento,
                    LugarNacimiento = model.LugarNacimiento,
                    Edad = model.Edad + " Años",
                    Genero = model.Genero,
                    Peso = model.Peso + " Kgs",
                    Estatura = model.Estatura + " Mts",
                    GradoEscolaridad = model.GradoEscolaridad,
                    InstitucionEducativa = model.InstitucionEducativa,
                    Cultural = model.Cultural,
                    Deportiva = model.Deportiva,
                    Artistica = model.Artistica,
                    Recreativa = model.Recreativa,
                    NombreAcudiente = model.NombreAcudiente,
                    OcupacionAcudiente = model.OcupacionAcudiente,
                    TelefonoAcudiente = model.TelefonoAcudiente,
                    Email = model.Username,
                    UserName = model.Username
                };

                var respuesta = await _userHelper.AddUserAsync(user, model.Password);
                if (respuesta.Succeeded)
                {
                    var userInDB = await _userHelper.GetUserByEmailAsync(model.Username);
                    await _userHelper.AddUserToRoleAsync(userInDB, "Customer");

                    var cliente = new Cliente
                    {
                        Agendas = new List<Agenda>(),
                        Inscripciones = new List<Inscripcion>(),
                        User = userInDB
                    };

                    _context.Clientes.Add(cliente);

                    try
                    {
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError(string.Empty, ex.ToString());
                        return View(model);
                    }
                }
                ModelState.AddModelError(string.Empty, respuesta.Errors.FirstOrDefault().Description);
            }
            return View(model);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        // GET: AddInscripcion/Details/5
        public async Task<IActionResult> AddInscripcion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id.Value);
                
            if (cliente == null)
            {
                return NotFound();
            }

            var model = new AddInscripcionViewModel
            {
                ClienteId = cliente.Id,
                Planes = _combosHelper.GetComboPlanes()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddInscripcion(AddInscripcionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var inscripcion = new Inscripcion
                {
                    Cliente = await _context.Clientes.FindAsync(model.ClienteId),
                    Plan = await _context.Planes.FindAsync(model.TipoPlanId),
                    Vigencia = model.Vigencia,
                    FechaInicio = model.FechaInicio,
                    FechaFin = model.FechaFin,
                    Renovacion = model.Renovacion,
                    Observacion = model.Observacion,
                    Efectivo = model.Efectivo,
                    Tarjeta = model.Tarjeta,
                    Deuda = model.Deuda
                };
                _context.Inscripciones.Add(inscripcion);
                await _context.SaveChangesAsync();
                return RedirectToAction($"Details/{model.ClienteId}");
            }
            return View(model);
        }

        // GET: EditInscripcion
        public async Task<IActionResult> EditInscripcion(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscripcion = await _context.Inscripciones.FindAsync(id.Value);

            if (inscripcion == null)
            {
                return NotFound();
            }

            var model = new AddInscripcionViewModel
            {
                Id = inscripcion.Id,
                ClienteId = inscripcion.Id,
                Planes = _combosHelper.GetComboPlanes()
            };
            return View(model);
        }
    }
}
