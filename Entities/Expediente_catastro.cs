using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MesaApi.Entities
{
    public class Expedientes_catastro : DALBase
    {
        public int Nro_expediente { get; set; }
        public DateTime Fecha_expediente { get; set; }
        public DateTime Fecha_entrada_colegio { get; set; }
        public DateTime Fecha_salida_colegio { get; set; }
        public string Profesional { get; set; }
        public int Codigo_estado { get; set; }
        public string Observaciones { get; set; }
        public int Id_uso { get; set; }
        public string Propietario { get; set; }
        public decimal Sup_lote { get; set; }
        public decimal Sup_edificada { get; set; }

        public Expedientes_catastro()
        {
            Nro_expediente = 0;
            Fecha_expediente = DateTime.Now;
            Fecha_entrada_colegio = DateTime.Now;
            Fecha_salida_colegio = DateTime.Now;
            Profesional = string.Empty;
            Codigo_estado = 0;
            Observaciones = string.Empty;
            Id_uso = 0;
            Propietario = string.Empty;
            Sup_lote = 0;
            Sup_edificada = 0;
        }

        private static List<Expedientes_catastro> mapeo(SqlDataReader dr)
        {
            List<Expedientes_catastro> lst = new List<Expedientes_catastro>();
            Expedientes_catastro obj;
            if (dr.HasRows)
            {
                int Nro_expediente = dr.GetOrdinal("Nro_expediente");
                int Fecha_expediente = dr.GetOrdinal("Fecha_expediente");
                int Fecha_entrada_colegio = dr.GetOrdinal("Fecha_entrada_colegio");
                int Fecha_salida_colegio = dr.GetOrdinal("Fecha_salida_colegio");
                int Profesional = dr.GetOrdinal("Profesional");
                int Codigo_estado = dr.GetOrdinal("Codigo_estado");
                int Observaciones = dr.GetOrdinal("Observaciones");
                int Id_uso = dr.GetOrdinal("Id_uso");
                int Propietario = dr.GetOrdinal("Propietario");
                int Sup_lote = dr.GetOrdinal("Sup_lote");
                int Sup_edificada = dr.GetOrdinal("Sup_edificada");
                while (dr.Read())
                {
                    obj = new Expedientes_catastro();
                    if (!dr.IsDBNull(Nro_expediente)) { obj.Nro_expediente = dr.GetInt32(Nro_expediente); }
                    if (!dr.IsDBNull(Fecha_expediente)) { obj.Fecha_expediente = dr.GetDateTime(Fecha_expediente); }
                    if (!dr.IsDBNull(Fecha_entrada_colegio)) { obj.Fecha_entrada_colegio = dr.GetDateTime(Fecha_entrada_colegio); }
                    if (!dr.IsDBNull(Fecha_salida_colegio)) { obj.Fecha_salida_colegio = dr.GetDateTime(Fecha_salida_colegio); }
                    if (!dr.IsDBNull(Profesional)) { obj.Profesional = dr.GetString(Profesional); }
                    if (!dr.IsDBNull(Codigo_estado)) { obj.Codigo_estado = dr.GetInt32(Codigo_estado); }
                    if (!dr.IsDBNull(Observaciones)) { obj.Observaciones = dr.GetString(Observaciones); }
                    if (!dr.IsDBNull(Id_uso)) { obj.Id_uso = dr.GetInt32(Id_uso); }
                    if (!dr.IsDBNull(Propietario)) { obj.Propietario = dr.GetString(Propietario); }
                    if (!dr.IsDBNull(Sup_lote)) { obj.Sup_lote = dr.GetDecimal(Sup_lote); }
                    if (!dr.IsDBNull(Sup_edificada)) { obj.Sup_edificada = dr.GetDecimal(Sup_edificada); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Expedientes_catastro> read()
        {
            try
            {
                List<Expedientes_catastro> lst = new List<Expedientes_catastro>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Expedientes_catastro";
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    lst = mapeo(dr);
                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Expedientes_catastro getByPk(int Nro_expediente)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Expedientes_catastro WHERE");
                sql.AppendLine("Nro_expediente = @Nro_expediente");
                Expedientes_catastro obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_expediente", Nro_expediente);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Expedientes_catastro> lst = mapeo(dr);
                    if (lst.Count != 0)
                        obj = lst[0];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void insertExpedientecatastro(Expedientes_catastro obj, SqlConnection con, SqlTransaction trx)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Expedientes_catastro(");
                sql.AppendLine("Nro_expediente");
                sql.AppendLine(", Fecha_expediente");
                if (obj.Fecha_entrada_colegio.ToString().Length > 0)
                    sql.AppendLine(", Fecha_entrada_colegio");
                if (obj.Fecha_salida_colegio.ToString().Length > 0)
                    sql.AppendLine(", Fecha_salida_colegio");
                sql.AppendLine(", Profesional");
                sql.AppendLine(", Codigo_estado");
                sql.AppendLine(", Observaciones");
                sql.AppendLine(", Id_uso");
                sql.AppendLine(", Propietario");
                sql.AppendLine(", Sup_lote");
                sql.AppendLine(", Sup_edificada");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Nro_expediente");
                sql.AppendLine(", @Fecha_expediente");
                if (obj.Fecha_entrada_colegio.ToString().Length > 0)
                    sql.AppendLine(", @Fecha_entrada_colegio");
                if (obj.Fecha_salida_colegio.ToString().Length > 0)
                    sql.AppendLine(", @Fecha_salida_colegio");
                sql.AppendLine(", @Profesional");
                sql.AppendLine(", @Codigo_estado");
                sql.AppendLine(", @Observaciones");
                sql.AppendLine(", @Id_uso");
                sql.AppendLine(", @Propietario");
                sql.AppendLine(", @Sup_lote");
                sql.AppendLine(", @Sup_edificada");
                sql.AppendLine(")");
                //
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Transaction = trx;
                cmd.CommandText = sql.ToString();
                cmd.Parameters.AddWithValue("@Nro_expediente", obj.Nro_expediente);
                cmd.Parameters.AddWithValue("@Fecha_expediente", obj.Fecha_expediente);
                if (obj.Fecha_entrada_colegio.ToString().Length > 0)
                    cmd.Parameters.AddWithValue("@Fecha_entrada_colegio", obj.Fecha_entrada_colegio);
                if (obj.Fecha_salida_colegio.ToString().Length > 0)
                    cmd.Parameters.AddWithValue("@Fecha_salida_colegio", obj.Fecha_salida_colegio);
                cmd.Parameters.AddWithValue("@Profesional", obj.Profesional);
                cmd.Parameters.AddWithValue("@Codigo_estado", obj.Codigo_estado);
                cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                cmd.Parameters.AddWithValue("@Id_uso", obj.Id_uso);
                cmd.Parameters.AddWithValue("@Propietario", obj.Propietario);
                cmd.Parameters.AddWithValue("@Sup_lote", obj.Sup_lote);
                cmd.Parameters.AddWithValue("@Sup_edificada", obj.Sup_edificada);
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                //// Antes que nada pregunto si el operador ingreso manualmente el nro de expediente
                //if (obj.Nro_expediente > 0)
                //{
                SqlCommand cmdProc = con.CreateCommand();
                cmdProc.Transaction = trx;
                cmdProc.CommandType = CommandType.StoredProcedure;
                cmdProc.CommandText = "ASIGNA_NRO_EXP_CATASTRO";
                cmdProc.Parameters.AddWithValue("@nro_expediente", obj.Nro_expediente);
                cmdProc.ExecuteNonQuery();
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public static void update(Expedientes_catastro obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Expedientes_catastro SET");
                sql.AppendLine("Fecha_expediente=@Fecha_expediente");
                sql.AppendLine(", Fecha_entrada_colegio=@Fecha_entrada_colegio");
                sql.AppendLine(", Fecha_salida_colegio=@Fecha_salida_colegio");
                sql.AppendLine(", Profesional=@Profesional");
                sql.AppendLine(", Codigo_estado=@Codigo_estado");
                sql.AppendLine(", Observaciones=@Observaciones");
                sql.AppendLine(", Id_uso=@Id_uso");
                sql.AppendLine(", Propietario=@Propietario");
                sql.AppendLine(", Sup_lote=@Sup_lote");
                sql.AppendLine(", Sup_edificada=@Sup_edificada");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_expediente=@Nro_expediente");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_expediente", obj.Nro_expediente);
                    cmd.Parameters.AddWithValue("@Fecha_expediente", obj.Fecha_expediente);
                    cmd.Parameters.AddWithValue("@Fecha_entrada_colegio", obj.Fecha_entrada_colegio);
                    cmd.Parameters.AddWithValue("@Fecha_salida_colegio", obj.Fecha_salida_colegio);
                    cmd.Parameters.AddWithValue("@Profesional", obj.Profesional);
                    cmd.Parameters.AddWithValue("@Codigo_estado", obj.Codigo_estado);
                    cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                    cmd.Parameters.AddWithValue("@Id_uso", obj.Id_uso);
                    cmd.Parameters.AddWithValue("@Propietario", obj.Propietario);
                    cmd.Parameters.AddWithValue("@Sup_lote", obj.Sup_lote);
                    cmd.Parameters.AddWithValue("@Sup_edificada", obj.Sup_edificada);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Expedientes_catastro obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Expedientes_catastro ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Nro_expediente=@Nro_expediente");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Nro_expediente", obj.Nro_expediente);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}

