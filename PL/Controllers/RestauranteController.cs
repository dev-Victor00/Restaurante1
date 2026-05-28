using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RestauranteController : Controller
    {
        // GET: Restaurante
        public ActionResult GetAll()
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            ML.Result result = BL.Restaurante.GetAll();
            if (result.Correct)
            {
                restaurante.Restaurantes = result.Objects;
            }
            else
            {
                ViewBag.Error = result.Messages;
            }


            return View(restaurante);
        }
        [HttpPost]
        public ActionResult Delete(int idRestaurante)
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            restaurante.IdRestaurante = idRestaurante;

            ML.Result result = BL.Restaurante.Delete(restaurante.IdRestaurante);

            if (result.Correct)
            {
                return RedirectToAction("GetAll", "Restaurante");
            }
            else
            {
                ViewBag.Error += result.Messages;
                return RedirectToAction("GetAll", "Restaurante");
            }
        }
    }
}