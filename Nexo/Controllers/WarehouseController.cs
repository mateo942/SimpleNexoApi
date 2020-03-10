using InsERT.Moria.ModelOrganizacyjny;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Nexo.Controllers
{
    public class WarehouseController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var warehouseRepository = WebApiApplication.Uchwyt.PodajObiektTypu<IMagazyny>();

            var results = warehouseRepository.Dane.Wszystkie().Select(x => x.Id);

            return Ok(results);
        }
    }
}