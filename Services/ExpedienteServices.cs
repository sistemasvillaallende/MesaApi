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
                using (SqlTransaction trx = con.BeginTransaction())
                {
                    try
                    {
                        Expediente.NuevoExpediente(oExp, con, trx);
                        trx.Commit();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        public int NuevoExpedienteConRetorno(Expediente oExp)
        {
            using (SqlConnection con = DALBase.GetConnection())
            {
                int retorno = 0;
                con.Open();
                using (SqlTransaction trx = con.BeginTransaction())
                {
                    try
                    {
                        retorno = Expediente.NuevoExpedienteConRetorno(oExp, con, trx);
                        trx.Commit();
                        return retorno;

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

        }
    }
}
