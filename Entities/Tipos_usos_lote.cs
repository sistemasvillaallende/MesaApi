using System.Data.SqlClient;
using System.Data;

namespace MesaApi.Entities
{
    public class Tipos_usos_lote : DALBase
    {
        public int id_uso { get; set; } = 0;
        public string descripcion { get; set; } = string.Empty;

        public static List<Tipos_usos_lote> ListarUsosLote()
        {

            try
            {
                List<Tipos_usos_lote> lst = new List<Tipos_usos_lote>();
                using (SqlConnection con = GetConnectionSIIMVA())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Tipo_Uso_Inm";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    Tipos_usos_lote? obj;
                    //obj = new Tipos_usos();
                    //obj.text = "TODOS los Tipos de Uso";
                    //obj.value = "0";
                    //lst.Add(obj);
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            obj = new();
                            if (!dr.IsDBNull(0)) { obj.id_uso = dr.GetInt32(0); }
                            if (!dr.IsDBNull(1)) { obj.descripcion = dr.GetString(1); }
                            lst.Add(obj);
                        }
                    }
                    return lst;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}
