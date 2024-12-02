using MesaApi.Entities;
using System.Data.SqlClient;

namespace MesaApi.Services
{
    public interface IExpediente_catastroServices
    {
        public List<Tipos_usos_lote> ListarUsosLote();
        public void insertExpedientecatastro(Expedientes_catastro obj);
    }

}
