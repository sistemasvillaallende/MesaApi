using MesaApi.Entities;
using System.Data.SqlClient;

namespace MesaApi.Services
{
    public class Expediente_catastroServices : IExpediente_catastroServices
    {
        public List<Tipos_usos_lote> ListarUsosLote()
        {
            try
            {
                return Tipos_usos_lote.ListarUsosLote();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void insertExpedientecatastro(Expedientes_catastro obj)
        {
            try
            {
                using SqlConnection con = DALBase.GetConnection();
                con.Open();
                using (SqlTransaction trx = con.BeginTransaction())
                {
                    try
                    {
                        // 1º Paso: guardo el  registro de historia para el expediente
                        //Agregar el metodo que hace el movimiento catastro
                        //
                        //
                        //




                        //2ºPaso: Pregunto si es un expediente catastro nuevo
                        //y registro los datos en el maestro Expediente_catastro
                        if (obj.Nro_expediente == 0)
                            Expedientes_catastro.insertExpedientecatastro(obj, con, trx);
                        trx.Commit();
                    }
                    catch (Exception)
                    {
                        trx.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
