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
                        tran.Commit();
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
                using (SqlTransaction tran = con.BeginTransaction())
                {
                    try
                    {
                        retorno = Expediente.NuevoExpedienteConRetorno(oExp, con, tran, 1);
                        tran.Commit();
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
