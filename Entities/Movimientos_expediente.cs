using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesaApi.Entities
{
    public class Movimientos_expediente : DALBase
    {
        public int anio { get; set; }
        public int nro_expediente { get; set; }
        public int nro_paso { get; set; }
        public int cod_estado_expediente { get; set; }
        public int codigo_oficina_origen { get; set; }
        public int codigo_oficina_destino { get; set; }
        public DateTime fecha_pase { get; set; }
        public DateTime fecha_recepcion { get; set; }
        public DateTime fecha_vencimiento { get; set; }
        public string? observaciones { get; set; }
        public bool atendido { get; set; }
        public string usuario { get; set; }
        public int dias_sin_resolver { get; set; }
        public int fojas { get; set; }

        public Movimientos_expediente()
        {
            anio = 0;
            nro_expediente = 0;
            nro_paso = 0;
            cod_estado_expediente = 0;
            codigo_oficina_origen = 0;
            codigo_oficina_destino = 0;
            fecha_pase = DateTime.Now;
            fecha_recepcion = DateTime.Now;
            fecha_vencimiento = DateTime.Now;
            observaciones = string.Empty;
            atendido = false;
            usuario = string.Empty;
            dias_sin_resolver = 0;
            fojas = 0;
        }

        private static List<Movimientos_expediente> mapeo(SqlDataReader dr)
        {
            List<Movimientos_expediente> lst = new List<Movimientos_expediente>();
            Movimientos_expediente obj;
            if (dr.HasRows)
            {
                int anio = dr.GetOrdinal("anio");
                int nro_expediente = dr.GetOrdinal("nro_expediente");
                int nro_paso = dr.GetOrdinal("nro_paso");
                int cod_estado_expediente = dr.GetOrdinal("cod_estado_expediente");
                int codigo_oficina_origen = dr.GetOrdinal("codigo_oficina_origen");
                int codigo_oficina_destino = dr.GetOrdinal("codigo_oficina_destino");
                int fecha_pase = dr.GetOrdinal("fecha_pase");
                int fecha_recepcion = dr.GetOrdinal("fecha_recepcion");
                int fecha_vencimiento = dr.GetOrdinal("fecha_vencimiento");
                int observaciones = dr.GetOrdinal("observaciones");
                int atendido = dr.GetOrdinal("atendido");
                int usuario = dr.GetOrdinal("usuario");
                int dias_sin_resolver = dr.GetOrdinal("dias_sin_resolver");
                int fojas = dr.GetOrdinal("fojas");
                while (dr.Read())
                {
                    obj = new Movimientos_expediente();
                    if (!dr.IsDBNull(anio)) { obj.anio = dr.GetInt32(anio); }
                    if (!dr.IsDBNull(nro_expediente)) { obj.nro_expediente = dr.GetInt32(nro_expediente); }
                    if (!dr.IsDBNull(nro_paso)) { obj.nro_paso = dr.GetInt32(nro_paso); }
                    if (!dr.IsDBNull(cod_estado_expediente)) { obj.cod_estado_expediente = dr.GetInt32(cod_estado_expediente); }
                    if (!dr.IsDBNull(codigo_oficina_origen)) { obj.codigo_oficina_origen = dr.GetInt32(codigo_oficina_origen); }
                    if (!dr.IsDBNull(codigo_oficina_destino)) { obj.codigo_oficina_destino = dr.GetInt32(codigo_oficina_destino); }
                    if (!dr.IsDBNull(fecha_pase)) { obj.fecha_pase = dr.GetDateTime(fecha_pase); }
                    if (!dr.IsDBNull(fecha_recepcion)) { obj.fecha_recepcion = dr.GetDateTime(fecha_recepcion); }
                    if (!dr.IsDBNull(fecha_vencimiento)) { obj.fecha_vencimiento = dr.GetDateTime(fecha_vencimiento); }
                    if (!dr.IsDBNull(observaciones)) { obj.observaciones = dr.GetString(observaciones); }
                    if (!dr.IsDBNull(atendido)) { obj.atendido = dr.GetBoolean(atendido); }
                    if (!dr.IsDBNull(usuario)) { obj.usuario = dr.GetString(usuario); }
                    if (!dr.IsDBNull(dias_sin_resolver)) { obj.dias_sin_resolver = dr.GetInt32(dias_sin_resolver); }
                    if (!dr.IsDBNull(fojas)) { obj.fojas = dr.GetInt32(fojas); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Movimientos_expediente> read()
        {
            try
            {
                List<Movimientos_expediente> lst = new List<Movimientos_expediente>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT *FROM Movimientos_expediente";
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

        public static Movimientos_expediente getByPk(int anio, int nro_expediente, int nro_paso)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Movimientos_expediente WHERE");
                sql.AppendLine("anio = @anio");
                sql.AppendLine("AND nro_expediente = @nro_expediente");
                sql.AppendLine("AND nro_paso = @nro_paso");
                Movimientos_expediente obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", anio);
                    cmd.Parameters.AddWithValue("@nro_expediente", nro_expediente);
                    cmd.Parameters.AddWithValue("@nro_paso", nro_paso);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Movimientos_expediente> lst = mapeo(dr);
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

        public static int insert(Movimientos_expediente obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Movimientos_expediente(");
                sql.AppendLine("anio");
                sql.AppendLine(", nro_expediente");
                sql.AppendLine(", nro_paso");
                sql.AppendLine(", cod_estado_expediente");
                sql.AppendLine(", codigo_oficina_origen");
                sql.AppendLine(", codigo_oficina_destino");
                sql.AppendLine(", fecha_pase");
                sql.AppendLine(", fecha_recepcion");
                sql.AppendLine(", fecha_vencimiento");
                sql.AppendLine(", observaciones");
                sql.AppendLine(", atendido");
                sql.AppendLine(", usuario");
                sql.AppendLine(", dias_sin_resolver");
                sql.AppendLine(", fojas");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@anio");
                sql.AppendLine(", @nro_expediente");
                sql.AppendLine(", @nro_paso");
                sql.AppendLine(", @cod_estado_expediente");
                sql.AppendLine(", @codigo_oficina_origen");
                sql.AppendLine(", @codigo_oficina_destino");
                sql.AppendLine(", @fecha_pase");
                sql.AppendLine(", @fecha_recepcion");
                sql.AppendLine(", @fecha_vencimiento");
                sql.AppendLine(", @observaciones");
                sql.AppendLine(", @atendido");
                sql.AppendLine(", @usuario");
                sql.AppendLine(", @dias_sin_resolver");
                sql.AppendLine(", @fojas");
                sql.AppendLine(")");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@cod_estado_expediente", obj.cod_estado_expediente);
                    cmd.Parameters.AddWithValue("@codigo_oficina_origen", obj.codigo_oficina_origen);
                    cmd.Parameters.AddWithValue("@codigo_oficina_destino", obj.codigo_oficina_destino);
                    cmd.Parameters.AddWithValue("@fecha_pase", obj.fecha_pase);
                    cmd.Parameters.AddWithValue("@fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@dias_sin_resolver", obj.dias_sin_resolver);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Connection.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void update(Movimientos_expediente obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Movimientos_expediente SET");
                sql.AppendLine("cod_estado_expediente=@cod_estado_expediente");
                sql.AppendLine(", codigo_oficina_origen=@codigo_oficina_origen");
                sql.AppendLine(", codigo_oficina_destino=@codigo_oficina_destino");
                sql.AppendLine(", fecha_pase=@fecha_pase");
                sql.AppendLine(", fecha_recepcion=@fecha_recepcion");
                sql.AppendLine(", fecha_vencimiento=@fecha_vencimiento");
                sql.AppendLine(", observaciones=@observaciones");
                sql.AppendLine(", atendido=@atendido");
                sql.AppendLine(", usuario=@usuario");
                sql.AppendLine(", dias_sin_resolver=@dias_sin_resolver");
                sql.AppendLine(", fojas=@fojas");
                sql.AppendLine("WHERE");
                sql.AppendLine("anio=@anio");
                sql.AppendLine("AND nro_expediente=@nro_expediente");
                sql.AppendLine("AND nro_paso=@nro_paso");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Parameters.AddWithValue("@cod_estado_expediente", obj.cod_estado_expediente);
                    cmd.Parameters.AddWithValue("@codigo_oficina_origen", obj.codigo_oficina_origen);
                    cmd.Parameters.AddWithValue("@codigo_oficina_destino", obj.codigo_oficina_destino);
                    cmd.Parameters.AddWithValue("@fecha_pase", obj.fecha_pase);
                    cmd.Parameters.AddWithValue("@fecha_recepcion", obj.fecha_recepcion);
                    cmd.Parameters.AddWithValue("@fecha_vencimiento", obj.fecha_vencimiento);
                    cmd.Parameters.AddWithValue("@observaciones", obj.observaciones);
                    cmd.Parameters.AddWithValue("@atendido", obj.atendido);
                    cmd.Parameters.AddWithValue("@usuario", obj.usuario);
                    cmd.Parameters.AddWithValue("@dias_sin_resolver", obj.dias_sin_resolver);
                    cmd.Parameters.AddWithValue("@fojas", obj.fojas);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Movimientos_expediente obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Movimientos_expediente ");
                sql.AppendLine("WHERE");
                sql.AppendLine("anio=@anio");
                sql.AppendLine("AND nro_expediente=@nro_expediente");
                sql.AppendLine("AND nro_paso=@nro_paso");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@anio", obj.anio);
                    cmd.Parameters.AddWithValue("@nro_expediente", obj.nro_expediente);
                    cmd.Parameters.AddWithValue("@nro_paso", obj.nro_paso);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Inserto1erMovimiento(Movimientos_expediente oME, SqlConnection cn, SqlTransaction trx)
        {
            string strSQL = "";
            //string strList = "";
            int aux_nro_paso = 0;
            SqlCommand cmd = null, 
            cmdInsert = null;
            StringBuilder strSQLInsert = new StringBuilder();

            //if (NewRecord)
            if (oME.nro_paso == 0)
            {
                strSQL = @"SELECT isnull(max(nro_paso),0) 
                           FROM Movimientos_expediente 
                           WHERE anio=@anio 
                           and nro_expediente=@nro_expediente";
                cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSQL;
                cmd.Parameters.AddWithValue("@anio", oME.anio);
                cmd.Parameters.AddWithValue("@nro_expediente", oME.nro_expediente);
                aux_nro_paso = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                oME.nro_paso = aux_nro_paso;
            }
            //else
            //{
            //  oME.nro_paso = aux_nro_paso;
            //  NewRecord = false;
            //}

            try
            {
                strSQLInsert.AppendLine("INSERT INTO MOVIMIENTOS_EXPEDIENTE");
                strSQLInsert.AppendLine("(anio,");
                strSQLInsert.AppendLine("nro_expediente,");
                strSQLInsert.AppendLine("nro_paso,");
                strSQLInsert.AppendLine("cod_estado_expediente,");
                strSQLInsert.AppendLine("codigo_oficina_origen,");
                strSQLInsert.AppendLine("codigo_oficina_destino,");
                strSQLInsert.AppendLine("fecha_pase,");
                //strSQLInsert.AppendLine("fecha_recepcion,");
                //strSQLInsert.AppendLine("fecha_vencimiento,");
                strSQLInsert.AppendLine("observaciones,");
                strSQLInsert.AppendLine("atendido,");
                strSQLInsert.AppendLine("usuario,");
                strSQLInsert.AppendLine("dias_sin_resolver, fojas)");

                strSQLInsert.AppendLine("VALUES");
                strSQLInsert.AppendLine("(@anio,");
                strSQLInsert.AppendLine("@nro_expediente,");
                strSQLInsert.AppendLine("@nro_paso,");
                strSQLInsert.AppendLine("@cod_estado_expediente,");
                strSQLInsert.AppendLine("@codigo_oficina_origen,");
                strSQLInsert.AppendLine("@codigo_oficina_destino,");
                strSQLInsert.AppendLine("@fecha_pase,");
                //strSQLInsert.AppendLine("@fecha_recepcion,");
                //strSQLInsert.AppendLine("@fecha_vencimiento,");
                strSQLInsert.AppendLine("@observaciones,");
                strSQLInsert.AppendLine("@atendido,");
                strSQLInsert.AppendLine("@usuario,");
                strSQLInsert.AppendLine("@dias_sin_resolver, @fojas)");

                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.Transaction = trx;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQLInsert.ToString();
                cmdInsert.Parameters.AddWithValue("@anio", oME.anio);
                cmdInsert.Parameters.AddWithValue("@nro_expediente", oME.nro_expediente);
                cmdInsert.Parameters.AddWithValue("@nro_paso", oME.nro_paso);
                cmdInsert.Parameters.AddWithValue("@cod_estado_expediente", (oME.cod_estado_expediente > 0) ? oME.cod_estado_expediente : 0);
                cmdInsert.Parameters.AddWithValue("@codigo_oficina_origen", (oME.codigo_oficina_origen > 0) ? oME.codigo_oficina_origen : 0);
                cmdInsert.Parameters.AddWithValue("@codigo_oficina_destino", (oME.codigo_oficina_destino > 0) ? oME.codigo_oficina_destino : 0);
                cmdInsert.Parameters.AddWithValue("@fecha_pase", oME.fecha_pase); //!= null ? oME.fecha_pase : "");
                //cmdInsert.Parameters.AddWithValue("@fecha_recepcion", (oME.fecha_recepcion != null) ? oME.fecha_recepcion : "");
                //cmdInsert.Parameters.AddWithValue("@fecha_vencimiento", (oME.fecha_vencimiento != null) ? oME.fecha_vencimiento : "");
                cmdInsert.Parameters.AddWithValue("@observaciones", (oME.observaciones != null) ? oME.observaciones : "");
                cmdInsert.Parameters.AddWithValue("@atendido", oME.atendido);
                cmdInsert.Parameters.AddWithValue("@usuario", (oME.usuario != null) ? oME.usuario : null);
                cmdInsert.Parameters.AddWithValue("@dias_sin_resolver", oME.dias_sin_resolver);
                cmdInsert.Parameters.AddWithValue("@fojas", oME.fojas);
                cmdInsert.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Error cuando graba el Movimiento en el Expediente !!!");

            }
            finally
            {
                cmd = null;
                cmdInsert = null;
            }
        }

    }
}

