using MesaApi.Entities;
using System.Data.SqlClient;

namespace MesaApi.Services
{
    public interface IExpedienteServices
    {
        public void NuevoExpediente(Expediente oExp);
       
    }
}
