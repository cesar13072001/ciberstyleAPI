using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ciberstyleAPI.Models;

namespace ciberstyleAPI.Controllers
{
    public class ReclamoController : ApiController
    {
        private ciberstyleEntities db = new ciberstyleEntities();

        // GET: api/Reclamo/Consulta/5


        [HttpGet]
        [ActionName("Idpago")]
        public HttpResponseMessage GetConsulta(int id)
        {
            var result = db.Reclamos.Where(x => x.idpago == id).ToList();

            if (result.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Reclamo no registrado");
        }


        [HttpGet]
        [ActionName("Idreclamo")]
        // GET: api/Reclamo/5
        public HttpResponseMessage GetReclamo(string id)
        {
            var result = db.Reclamos.Where(x => x.idreclamo == id).ToList();

            if (result.Count > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Reclamo no encontrado");
        }

        [HttpPost]
        [ActionName("Agregar")]
        // POST: api/Reclamo
        public HttpResponseMessage Post([FromBody] Reclamos reclamo)
        {
            reclamo.idreclamo = reclamo.idpago + "-" + reclamo.telefono;
            reclamo.estado = "Recibido";
            reclamo.fecha = DateTime.Now.ToString("dd/MM/yyyy");
            db.Reclamos.Add(reclamo);
            int result = db.SaveChanges();
            if (result > 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, reclamo);
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, "Error al registrar su reclamo");
        }

    }
}
