using MesaApi.Services;
using Microsoft.AspNetCore.Mvc;
using MesaApi.Entities;

namespace MesaApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ExpedienteController : ControllerBase
    {
        private IExpedienteServices _expediente;
        public ExpedienteController(IExpedienteServices expediente)
        {
            _expediente = expediente;
        }

        [HttpPost]
        public IActionResult NuevoExpediente(Expediente obj)
        {
            try
            {
                _expediente.NuevoExpediente(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult NuevoExpedienteConRetorno(Expediente obj)
        {
            try
            {
                int retorno = _expediente.NuevoExpedienteConRetorno(obj);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


        [HttpPost]
        public IActionResult NuevoExpedienteMultinota(Expediente obj)
        {
            try
            {
                //cod_asunto=77
                //cod_tipo_tramite=2
                //descripcion='Notas y Pedidos
                obj.Cod_tipo_tramite = 2;
                obj.Cod_asunto = 77;

                _expediente.NuevoExpediente(obj);
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }


    }
}
