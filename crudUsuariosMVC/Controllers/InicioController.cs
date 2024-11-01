using crudUsuariosMVC.Data;
using crudUsuariosMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace crudUsuariosMVC.Controllers
{
    public class InicioController : Controller
    {
        
        private readonly ApplicationDbContext _Context;
        //con esto llamamos al applicationDbContext para hacer uso de todos los modelos
        public InicioController(ApplicationDbContext Context)
        {
            
            _Context = Context;
        }

        //metodo asincrono se utilizan para ejecutar operaciones que pueden tomar un tiempo prolongado
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            //ToList es para mandar los datos del modelo contacto al cual es posible acceder por el Context hacia una lista

            return View(await _Context.Contacto2.ToListAsync());
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto2 contacto)
        {

            if (ModelState.IsValid)
            {
                //como desde el formulario de la app no se agrega la fecha de creacion desde el controlador le podemos poner para que automaticamente
                //se agrege un nuevo contacto, se cree con la fecha y hora del servidor.

                //contacto.FechaCreacion = DateTime.Now;

                _Context.Contacto2.Add(contacto);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Crear));
            }

            return View();
        }


        //a diferencia de los demas la funcion editar si lleva parametros(ID) para que asi pueda
        //encontras el usuario correctos mediante su identificador

        //este metodo no es el que se encarga de editar y guardar lo editado en la base de dato
        //se encarga de validar que el contacto y el id existan en caso de que no existan manda error       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto2 contacto)
        {

            if (ModelState.IsValid)
            {                

                _Context.Update(contacto);
                await _Context.SaveChangesAsync();
               return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _Context.Contacto2.Find(id);

            //esto porque puede que no existan registros de contacto con ese id
            if (contacto == null)
            {

                return NotFound();

            }

            return View(contacto);
        }

        public IActionResult Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _Context.Contacto2.Find(id);

            //esto porque puede que no existan registros de contacto con ese id
            if (contacto == null)
            {

                return NotFound();

            }

            return View(contacto);
        }


        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _Context.Contacto2.Find(id);

            //esto porque puede que no existan registros de contacto con ese id
            if (contacto == null)
            {

                return NotFound();

            }

            return View(contacto);
        }
        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> BorrarContacto(int? id)
        {

            var contacto = await _Context.Contacto2.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }

            _Context.Contacto2.Remove(contacto);
            await _Context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
