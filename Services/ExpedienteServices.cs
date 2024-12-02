using MesaApi.Entities;
using System.Data.SqlClient;

namespace MesaApi.Services
{
    public class ExpedienteServices : IExpedienteServices
    {
        public void NuevoExpediente(Expediente oExp)
        {
            using (SqlConnection con = DALBase.GetConnection())
            {
                con.Open();
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        Expediente.NuevoExpediente(oExp, con, tran, 1);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public List<Tipos_usos_lote> ListarUsosLote()
        {
            try
            {
                return 
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
