using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CrudMVC.Models;

namespace CrudMVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Data()
        {
            List<Usuarios> personas = new List<Usuarios>();
            var db = new DBCRUDEntities();

            personas = db.Usuarios.ToList();

            return Json(new { data = personas }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Usuarios userData)
        {
            //return Json(userData);

            var db = new DBCRUDEntities(); // sin using
            if (userData.IdUsuario == 0)
            {
                db.Usuarios.Add(userData);
                userData.FechaRegistro = DateTime.Now;
            }
            else
            {
                var existingPersona = db.Usuarios.Find(userData.IdUsuario);
                if (existingPersona != null)
                {
                    existingPersona.Nombre = userData.Nombre;
                    existingPersona.Apellido = userData.Apellido;
                    existingPersona.Correo = userData.Correo;
                    
                }
            }
            db.SaveChanges();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdUsuario)
        {
            var db = new DBCRUDEntities();
            var existsUser = db.Usuarios.Find(IdUsuario);
            bool result = true;

            if (existsUser != null)
            {
                db.Usuarios.Remove(existsUser);
                db.SaveChanges();
            } 
            else
            {
                result = false;
            }
            return Json(new { success = result }, JsonRequestBehavior.AllowGet);
        }
    }
}