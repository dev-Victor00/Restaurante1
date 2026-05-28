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


        [HttpGet]
        public ActionResult Form(int? idRestaurante)
        {
            ML.Restaurante restaurante = new ML.Restaurante();
            if (idRestaurante == null)
            {

            }
            else
            {
                ML.Result result = BL.Restaurante.GetById(idRestaurante.Value);
                if (result.Correct)
                {
                    restaurante = (ML.Restaurante)result.Object;
                }
                else
                {
                    ViewBag.Error = result.Messages;
                }
            }
            return View(restaurante);
        }

        public ActionResult Form(ML.Restaurante restaurante, HttpPostedFileBase restauranteLogo)
        {
            if (restauranteLogo != null && restauranteLogo.ContentLength > 0)
            {
                byte[] logoConvertido;
                using (var reader = new System.IO.BinaryReader(restauranteLogo.InputStream))
                {
                    logoConvertido = reader.ReadBytes(restauranteLogo.ContentLength);
                }
                restaurante.Logo = logoConvertido;
            }

            ML.Result result = new ML.Result();

            if (restaurante.IdRestaurante == 0)
            {
                result = BL.Restaurante.Add(restaurante);
                if (result.Correct)
                {
                    ViewBag.Message = "El restaurante se registró correctamente.";
                }
                else
                {
                    ViewBag.Message = "Error al registrar el restaurante: " + result.Messages;
                }
            }
            else
            {
                result = BL.Restaurante.Update(restaurante);
                if (result.Correct)
                {
                    ViewBag.Message = "El restaurante se registró correctamente.";
                }
                else
                {
                    ViewBag.Message = "Error al registrar el restaurante: " + result.Messages;
                }
            }

            if (result.Correct)
            {
                return RedirectToAction("GetAll");
            }
            else
            {
                return View(restaurante);
            }
        }

    }
}