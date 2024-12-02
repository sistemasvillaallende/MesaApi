using MesaApi.Entities;
using MesaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MesaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Expediente_catastroController : Controller
    {
        private IExpediente_catastroServices _expedientecatastro;

        public Expediente_catastroController(IExpediente_catastroServices expedientecatastro)
        {
            _expedientecatastro = expedientecatastro;
        }


        [HttpPost]
        public IActionResult NuevoExpedientCastroe(Expedientes_catastro obj)
        {

            try
            {
                if (obj.Codigo_estado == 0)
                {
                    return BadRequest(new { message = "No Selecciono un Tipo de Movimiento Catastral " });
                }
                if (obj.Fecha_entrada_colegio.ToString().Length > 0)
                {
                    return BadRequest(new { message = "Debe ingresar Fecha de Ingreso Colegio de Arquitecto..." });
                }
                if (obj.Id_uso==0)
                {
                    return BadRequest(new { message = "Debe Seleccionar Tipo de Uso del Inmueble..." });
                }
                if (obj.Nro_expediente == 0)
                {
                    _expedientecatastro.insertExpedientecatastro(obj);
                }
                return Ok(new { message = "Se inserto el expediente catastro" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error en el alta de expediente catastro", details = ex.Message });
            }

        }

    }
}
