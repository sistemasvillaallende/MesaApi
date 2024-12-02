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
            _expediente.NuevoExpediente(obj);
            return Ok(obj);
        }
    }
}
