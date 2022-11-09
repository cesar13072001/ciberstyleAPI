using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ciberstyleAPI.Models;

namespace ciberstyleAPI.Controllers
{
    public class ConsultaController : ApiController
    {
        private ciberstyleEntities db = new ciberstyleEntities();


        public HttpResponseMessage Get(int id)
        {

            var compras = db.compradetalle(id).ToList();
            if (compras.Count > 0)
            {
                String salida = "";
                String prendas = "";
                String totalT = "";

                foreach (var item in compras as List<compradetalle_Result>)
                {
                    totalT = "Total: S/. "+item.total;
                    prendas += "*Producto: " + item.nombre + " ,cantidad: " + item.cantidad + " ,subtotal: S/. " + item.subtotal + ".* ";
                }
                salida = salida + prendas + totalT;

                return Request.CreateResponse(HttpStatusCode.OK, salida);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "El pedido no fue encontrado");
        }
    }
}
