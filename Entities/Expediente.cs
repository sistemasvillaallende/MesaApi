using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MesaApi.Entities
{
    public class Expediente : DALBase
    {
        public int Anio { get; set; }
        public int Nro_expediente { get; set; }
        public DateTime Fecha_alta_registro { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public int Id_persona { get; set; }
        public string Nombre { get; set; }
        public string Domicilio { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Cod_tipo_documento { get; set; }
        public int Nro_documento { get; set; }
        public int Cod_tipo_tramite { get; set; }
        public int Cod_asunto { get; set; }
        public int Cod_oficina_origen { get; set; }
        public int Cod_oficina_destino { get; set; }
        public int Cod_estado_expediente { get; set; }
        public string Observaciones { get; set; }
        public bool Pase { get; set; }
        public bool Anulado { get; set; }
        public bool Ejecutado { get; set; }
        public DateTime Fecha_fin_tramite { get; set; }
        public string Usuario { get; set; }
        public string Celular { get; set; }
        public string Cuit { get; set; }
        public int Fojas { get; set; }
        public int Anio_padre { get; set; }
        public int Nro_expediente_padre { get; set; }
        public bool Atendido { get; set; }
        public int Nro_anexo { get; set; }
        public DateTime Fecha_atendido { get; set; }
        public Persona objPersona { get; set; }
        public List<Movimientos_expediente> lstMovimientos { get; set; }

        public Expediente()
        {
            Anio = 0;
            Nro_expediente = 0;
            Fecha_alta_registro = DateTime.Now;
            Fecha_ingreso = DateTime.Now;
            Id_persona = 0;
            Nombre = string.Empty;
            Domicilio = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Cod_tipo_documento = 0;
            Nro_documento = 0;
            Cod_tipo_tramite = 0;
            Cod_asunto = 0;
            Cod_oficina_origen = 0;
            Cod_oficina_destino = 0;
            Cod_estado_expediente = 0;
            Observaciones = string.Empty;
            Pase = false;
            Anulado = false;
            Ejecutado = false;
            Fecha_fin_tramite = DateTime.Now;
            Usuario = string.Empty;
            Celular = string.Empty;
            Cuit = string.Empty;
            Fojas = 0;
            Anio_padre = 0;
            Nro_expediente_padre = 0;
            Atendido = false;
            Nro_anexo = 0;
            Fecha_atendido = DateTime.Now;
            objPersona = new Persona();
            lstMovimientos = new List<Movimientos_expediente>();
        }

        private static List<Expediente> mapeo(SqlDataReader dr)
        {
            List<Expediente> lst = new List<Expediente>();
            Expediente obj;
            if (dr.HasRows)
            {
                int Anio = dr.GetOrdinal("Anio");
                int Nro_expediente = dr.GetOrdinal("Nro_expediente");
                int Fecha_alta_registro = dr.GetOrdinal("Fecha_alta_registro");
                int Fecha_ingreso = dr.GetOrdinal("Fecha_ingreso");
                int Id_persona = dr.GetOrdinal("Id_persona");
                int Nombre = dr.GetOrdinal("Nombre");
                int Domicilio = dr.GetOrdinal("Domicilio");
                int Telefono = dr.GetOrdinal("Telefono");
                int Email = dr.GetOrdinal("Email");
                int Cod_tipo_documento = dr.GetOrdinal("Cod_tipo_documento");
                int Nro_documento = dr.GetOrdinal("Nro_documento");
                int Cod_tipo_tramite = dr.GetOrdinal("Cod_tipo_tramite");
                int Cod_asunto = dr.GetOrdinal("Cod_asunto");
                int Cod_oficina_origen = dr.GetOrdinal("Cod_oficina_origen");
                int Cod_oficina_destino = dr.GetOrdinal("Cod_oficina_destino");
                int Cod_estado_expediente = dr.GetOrdinal("Cod_estado_expediente");
                int Observaciones = dr.GetOrdinal("Observaciones");
                int Pase = dr.GetOrdinal("Pase");
                int Anulado = dr.GetOrdinal("Anulado");
                int Ejecutado = dr.GetOrdinal("Ejecutado");
                int Fecha_fin_tramite = dr.GetOrdinal("Fecha_fin_tramite");
                int Usuario = dr.GetOrdinal("Usuario");
                int Celular = dr.GetOrdinal("Celular");
                int Cuit = dr.GetOrdinal("Cuit");
                int Fojas = dr.GetOrdinal("Fojas");
                int Anio_padre = dr.GetOrdinal("Anio_padre");
                int Nro_expediente_padre = dr.GetOrdinal("Nro_expediente_padre");
                int Atendido = dr.GetOrdinal("Atendido");
                int Nro_anexo = dr.GetOrdinal("Nro_anexo");
                int Fecha_atendido = dr.GetOrdinal("Fecha_atendido");
                while (dr.Read())
                {
                    obj = new Expediente();
                    if (!dr.IsDBNull(Anio)) { obj.Anio = dr.GetInt32(Anio); }
                    if (!dr.IsDBNull(Nro_expediente)) { obj.Nro_expediente = dr.GetInt32(Nro_expediente); }
                    if (!dr.IsDBNull(Fecha_alta_registro)) { obj.Fecha_alta_registro = dr.GetDateTime(Fecha_alta_registro); }
                    if (!dr.IsDBNull(Fecha_ingreso)) { obj.Fecha_ingreso = dr.GetDateTime(Fecha_ingreso); }
                    if (!dr.IsDBNull(Id_persona)) { obj.Id_persona = dr.GetInt32(Id_persona); }
                    if (!dr.IsDBNull(Nombre)) { obj.Nombre = dr.GetString(Nombre); }
                    if (!dr.IsDBNull(Domicilio)) { obj.Domicilio = dr.GetString(Domicilio); }
                    if (!dr.IsDBNull(Telefono)) { obj.Telefono = dr.GetString(Telefono); }
                    if (!dr.IsDBNull(Email)) { obj.Email = dr.GetString(Email); }
                    if (!dr.IsDBNull(Cod_tipo_documento)) { obj.Cod_tipo_documento = dr.GetInt32(Cod_tipo_documento); }
                    if (!dr.IsDBNull(Nro_documento)) { obj.Nro_documento = dr.GetInt32(Nro_documento); }
                    if (!dr.IsDBNull(Cod_tipo_tramite)) { obj.Cod_tipo_tramite = dr.GetInt32(Cod_tipo_tramite); }
                    if (!dr.IsDBNull(Cod_asunto)) { obj.Cod_asunto = dr.GetInt32(Cod_asunto); }
                    if (!dr.IsDBNull(Cod_oficina_origen)) { obj.Cod_oficina_origen = dr.GetInt32(Cod_oficina_origen); }
                    if (!dr.IsDBNull(Cod_oficina_destino)) { obj.Cod_oficina_destino = dr.GetInt32(Cod_oficina_destino); }
                    if (!dr.IsDBNull(Cod_estado_expediente)) { obj.Cod_estado_expediente = dr.GetInt32(Cod_estado_expediente); }
                    if (!dr.IsDBNull(Observaciones)) { obj.Observaciones = dr.GetString(Observaciones); }
                    if (!dr.IsDBNull(Pase)) { obj.Pase = dr.GetBoolean(Pase); }
                    if (!dr.IsDBNull(Anulado)) { obj.Anulado = dr.GetBoolean(Anulado); }
                    if (!dr.IsDBNull(Ejecutado)) { obj.Ejecutado = dr.GetBoolean(Ejecutado); }
                    if (!dr.IsDBNull(Fecha_fin_tramite)) { obj.Fecha_fin_tramite = dr.GetDateTime(Fecha_fin_tramite); }
                    if (!dr.IsDBNull(Usuario)) { obj.Usuario = dr.GetString(Usuario); }
                    if (!dr.IsDBNull(Celular)) { obj.Celular = dr.GetString(Celular); }
                    if (!dr.IsDBNull(Cuit)) { obj.Cuit = dr.GetString(Cuit); }
                    if (!dr.IsDBNull(Fojas)) { obj.Fojas = dr.GetInt32(Fojas); }
                    if (!dr.IsDBNull(Anio_padre)) { obj.Anio_padre = dr.GetInt32(Anio_padre); }
                    if (!dr.IsDBNull(Nro_expediente_padre)) { obj.Nro_expediente_padre = dr.GetInt32(Nro_expediente_padre); }
                    if (!dr.IsDBNull(Atendido)) { obj.Atendido = dr.GetBoolean(Atendido); }
                    if (!dr.IsDBNull(Nro_anexo)) { obj.Nro_anexo = dr.GetInt32(Nro_anexo); }
                    if (!dr.IsDBNull(Fecha_atendido)) { obj.Fecha_atendido = dr.GetDateTime(Fecha_atendido); }
                    lst.Add(obj);
                }
            }
            return lst;
        }

        public static List<Expediente> read()
        {
            try
            {
                List<Expediente> lst = new List<Expediente>();
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "SELECT * FROM Expediente";
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

        public static Expediente getByPk(int Anio, int Nro_expediente)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("SELECT *FROM Expediente WHERE");
                sql.AppendLine("Anio = @Anio");
                sql.AppendLine("AND Nro_expediente = @Nro_expediente");
                Expediente obj = null;
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Anio", Anio);
                    cmd.Parameters.AddWithValue("@Nro_expediente", Nro_expediente);
                    cmd.Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Expediente> lst = mapeo(dr);
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

        public static bool insert(Expediente obj)
        {
            try
            {
                bool ret = false;
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("INSERT INTO Expediente(");
                sql.AppendLine("Anio");
                sql.AppendLine(", Nro_expediente");
                sql.AppendLine(", Fecha_alta_registro");
                sql.AppendLine(", Fecha_ingreso");
                sql.AppendLine(", Id_persona");
                sql.AppendLine(", Nombre");
                sql.AppendLine(", Domicilio");
                sql.AppendLine(", Telefono");
                sql.AppendLine(", Email");
                sql.AppendLine(", Cod_tipo_documento");
                sql.AppendLine(", Nro_documento");
                sql.AppendLine(", Cod_tipo_tramite");
                sql.AppendLine(", Cod_asunto");
                sql.AppendLine(", Cod_oficina_origen");
                sql.AppendLine(", Cod_oficina_destino");
                sql.AppendLine(", Cod_estado_expediente");
                sql.AppendLine(", Observaciones");
                sql.AppendLine(", Pase");
                sql.AppendLine(", Anulado");
                sql.AppendLine(", Ejecutado");
                sql.AppendLine(", Fecha_fin_tramite");
                sql.AppendLine(", Usuario");
                sql.AppendLine(", Celular");
                sql.AppendLine(", Cuit");
                sql.AppendLine(", Fojas");
                sql.AppendLine(", Anio_padre");
                sql.AppendLine(", Nro_expediente_padre");
                sql.AppendLine(", Atendido");
                sql.AppendLine(", Nro_anexo");
                sql.AppendLine(", Fecha_atendido");
                sql.AppendLine(")");
                sql.AppendLine("VALUES");
                sql.AppendLine("(");
                sql.AppendLine("@Anio");
                sql.AppendLine(", @Nro_expediente");
                sql.AppendLine(", @Fecha_alta_registro");
                sql.AppendLine(", @Fecha_ingreso");
                sql.AppendLine(", @Id_persona");
                sql.AppendLine(", @Nombre");
                sql.AppendLine(", @Domicilio");
                sql.AppendLine(", @Telefono");
                sql.AppendLine(", @Email");
                sql.AppendLine(", @Cod_tipo_documento");
                sql.AppendLine(", @Nro_documento");
                sql.AppendLine(", @Cod_tipo_tramite");
                sql.AppendLine(", @Cod_asunto");
                sql.AppendLine(", @Cod_oficina_origen");
                sql.AppendLine(", @Cod_oficina_destino");
                sql.AppendLine(", @Cod_estado_expediente");
                sql.AppendLine(", @Observaciones");
                sql.AppendLine(", @Pase");
                sql.AppendLine(", @Anulado");
                sql.AppendLine(", @Ejecutado");
                sql.AppendLine(", @Fecha_fin_tramite");
                sql.AppendLine(", @Usuario");
                sql.AppendLine(", @Celular");
                sql.AppendLine(", @Cuit");
                sql.AppendLine(", @Fojas");
                sql.AppendLine(", @Anio_padre");
                sql.AppendLine(", @Nro_expediente_padre");
                sql.AppendLine(", @Atendido");
                sql.AppendLine(", @Nro_anexo");
                sql.AppendLine(", @Fecha_atendido");
                sql.AppendLine(")");


                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    // Iniciar una transacción
                    using (SqlTransaction trx = con.BeginTransaction())
                    {
                        try
                        {
                            SqlCommand cmd = con.CreateCommand();
                            cmd.Transaction = trx;
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = sql.ToString();
                            cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                            cmd.Parameters.AddWithValue("@Nro_expediente", obj.Nro_expediente);
                            cmd.Parameters.AddWithValue("@Fecha_alta_registro", obj.Fecha_alta_registro);
                            cmd.Parameters.AddWithValue("@Fecha_ingreso", obj.Fecha_ingreso);
                            cmd.Parameters.AddWithValue("@Id_persona", obj.Id_persona);
                            cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                            cmd.Parameters.AddWithValue("@Domicilio", obj.Domicilio);
                            cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                            cmd.Parameters.AddWithValue("@Email", obj.Email);
                            cmd.Parameters.AddWithValue("@Cod_tipo_documento", obj.Cod_tipo_documento);
                            cmd.Parameters.AddWithValue("@Nro_documento", obj.Nro_documento);
                            cmd.Parameters.AddWithValue("@Cod_tipo_tramite", obj.Cod_tipo_tramite);
                            cmd.Parameters.AddWithValue("@Cod_asunto", obj.Cod_asunto);
                            cmd.Parameters.AddWithValue("@Cod_oficina_origen", obj.Cod_oficina_origen);
                            cmd.Parameters.AddWithValue("@Cod_oficina_destino", obj.Cod_oficina_destino);
                            cmd.Parameters.AddWithValue("@Cod_estado_expediente", obj.Cod_estado_expediente);
                            cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                            cmd.Parameters.AddWithValue("@Pase", obj.Pase);
                            cmd.Parameters.AddWithValue("@Anulado", obj.Anulado);
                            cmd.Parameters.AddWithValue("@Ejecutado", obj.Ejecutado);
                            cmd.Parameters.AddWithValue("@Fecha_fin_tramite", obj.Fecha_fin_tramite);
                            cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                            cmd.Parameters.AddWithValue("@Celular", obj.Celular);
                            cmd.Parameters.AddWithValue("@Cuit", obj.Cuit);
                            cmd.Parameters.AddWithValue("@Fojas", obj.Fojas);
                            cmd.Parameters.AddWithValue("@Anio_padre", obj.Anio_padre);
                            cmd.Parameters.AddWithValue("@Nro_expediente_padre", obj.Nro_expediente_padre);
                            cmd.Parameters.AddWithValue("@Atendido", obj.Atendido);
                            cmd.Parameters.AddWithValue("@Nro_anexo", obj.Nro_anexo);
                            cmd.Parameters.AddWithValue("@Fecha_atendido", obj.Fecha_atendido);
                            cmd.ExecuteNonQuery();
                            ret = true;
                            trx.Commit();
                            return ret;
                        }
                        catch (Exception)
                        {
                            trx.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int GetNroExpediente()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            int nroExpediente = configuration.GetValue<int>("nro_expediente_base");
            return nroExpediente;
        }

        //public static void NuevoExpediente(Entities.Expediente oExp, Entities.Persona oPer,
        // SqlConnection cn, SqlTransaction trx, int opcion)
        //aux_nro_expediente_base = 
        //Convert.ToInt16(ConfigurationManager.AppSettings["Nro_expediente_base"]);
        public static void NuevoExpediente(Expediente oExp, SqlConnection cn, SqlTransaction trx, int opcion)
        {
            StringBuilder strInsert = new StringBuilder();
            int aux_nro_expediente = 0;
            int aux_nro_expediente_base = 0;
            //levanto el parametro del nro base de expediente
            aux_nro_expediente_base = GetNroExpediente();
            Movimientos_expediente oMExp;
            try
            {
                string SQL = @"SELECT ISNULL(max(nro_expediente),0) as nro_expediente 
                               FROM EXPEDIENTE WHERE anio=@anio";

                //1er
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL.ToString();
                cmd.Parameters.AddWithValue("@anio", oExp.Anio);
                aux_nro_expediente = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
                //Si es el primer registro del año
                //Seteo por defecto a 10001 o en base al nro de expediente parametro
                if (aux_nro_expediente == 1)
                    aux_nro_expediente = aux_nro_expediente_base;
                oExp.Nro_expediente = aux_nro_expediente;
                //Doy de Alta o Actualizo Persona segun corresponda
                if (opcion == 0)
                    Persona.InsertPersona(oExp.objPersona, cn, trx);
                else
                    Persona.UpdatePersona(oExp.objPersona, cn, trx);
                //2do
                strInsert.AppendLine("insert into Expediente");
                strInsert.AppendLine("(anio,");
                strInsert.AppendLine("nro_expediente,");
                strInsert.AppendLine("fecha_alta_registro,");
                strInsert.AppendLine("fecha_ingreso,");
                strInsert.AppendLine("id_persona,");
                strInsert.AppendLine("nombre,");
                strInsert.AppendLine("cod_tipo_tramite,");
                strInsert.AppendLine("cod_asunto,");
                strInsert.AppendLine("cod_oficina_origen,");
                strInsert.AppendLine("cod_oficina_destino,");
                strInsert.AppendLine("cod_estado_expediente,");
                strInsert.AppendLine("observaciones,");
                strInsert.AppendLine("pase,");
                strInsert.AppendLine("anulado,");
                strInsert.AppendLine("ejecutado,");
                strInsert.AppendLine("email,");
                strInsert.AppendLine("usuario,");
                strInsert.AppendLine("celular,");
                strInsert.AppendLine("cuit, fojas, anio_padre, nro_expediente_padre, atendido, nro_anexo )");
                strInsert.AppendLine("VALUES");
                strInsert.AppendLine("(@anio,");
                strInsert.AppendLine("@nro_expediente,");
                strInsert.AppendLine("@fecha_alta_registro,");
                strInsert.AppendLine("@fecha_ingreso,");
                strInsert.AppendLine("@id_persona,");
                strInsert.AppendLine("@nombre,");
                strInsert.AppendLine("@cod_tipo_tramite,");
                strInsert.AppendLine("@cod_asunto,");
                strInsert.AppendLine("@cod_oficina_origen,");
                strInsert.AppendLine("@cod_oficina_destino,");
                strInsert.AppendLine("@cod_estado_expediente,");
                strInsert.AppendLine("@observaciones,");
                strInsert.AppendLine("@pase,");
                strInsert.AppendLine("@anulado,");
                strInsert.AppendLine("@ejecutado,");
                strInsert.AppendLine("@email,");
                strInsert.AppendLine("@usuario,");
                strInsert.AppendLine("@celular,");
                strInsert.AppendLine("@cuit, @fojas, @anio_padre, @nro_expediente_padre, @atendido, @nro_anexo )");
                //strInsert.AppendLine("@web,");
                //strInsert.AppendLine("@tieneadjunto)");
                SqlCommand cmdInsert = cn.CreateCommand();
                cmdInsert.Transaction = trx;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strInsert.ToString();
                cmdInsert.Parameters.AddWithValue("@anio", oExp.Anio);
                cmdInsert.Parameters.AddWithValue("@nro_expediente", oExp.Nro_expediente);
                cmdInsert.Parameters.AddWithValue("@fecha_alta_registro", oExp.Fecha_alta_registro);
                cmdInsert.Parameters.AddWithValue("@fecha_ingreso", oExp.Fecha_ingreso);
                //cmdInsert.Parameters.AddWithValue("@id_persona", (oExp.id_persona > 0) ? oExp.id_persona : 0);
                cmdInsert.Parameters.AddWithValue("@id_persona", oExp.objPersona.id_persona);
                cmdInsert.Parameters.AddWithValue("@nombre", (oExp.objPersona.nombre != null) ? oExp.objPersona.nombre : null);
                cmdInsert.Parameters.AddWithValue("@cod_tipo_tramite", oExp.Cod_tipo_tramite);
                cmdInsert.Parameters.AddWithValue("@cod_asunto", oExp.Cod_asunto);
                cmdInsert.Parameters.AddWithValue("@cod_oficina_origen", oExp.Cod_oficina_origen);
                cmdInsert.Parameters.AddWithValue("@cod_oficina_destino", oExp.Cod_oficina_destino);
                cmdInsert.Parameters.AddWithValue("@cod_estado_expediente", oExp.Cod_estado_expediente);
                cmdInsert.Parameters.AddWithValue("@observaciones", oExp.Observaciones ?? "");
                cmdInsert.Parameters.AddWithValue("@pase", oExp.Pase);
                cmdInsert.Parameters.AddWithValue("@anulado", oExp.Anulado);
                cmdInsert.Parameters.AddWithValue("@ejecutado", oExp.Ejecutado);
                cmdInsert.Parameters.AddWithValue("@email", oExp.Email);
                cmdInsert.Parameters.AddWithValue("@usuario", (oExp.Usuario != null) ? oExp.Usuario : "");
                cmdInsert.Parameters.AddWithValue("@celular", (oExp.Celular != null) ? oExp.Celular : "");
                cmdInsert.Parameters.AddWithValue("@cuit", oExp.objPersona.cuit);
                cmdInsert.Parameters.AddWithValue("@fojas", oExp.Fojas);
                cmdInsert.Parameters.AddWithValue("@anio_padre", oExp.Anio_padre);
                cmdInsert.Parameters.AddWithValue("@nro_expediente_padre", oExp.Nro_expediente_padre);
                cmdInsert.Parameters.AddWithValue("@atendido", oExp.Atendido);
                cmdInsert.Parameters.AddWithValue("@nro_anexo", oExp.Nro_anexo);
                //cmdInsert.Parameters.AddWithValue("@web", oExp.web);
                //cmdInsert.Parameters.AddWithValue("@tieneadjunto", oExp.tieneadjunto);
                cmdInsert.ExecuteNonQuery();
                //3er paso
                //inserto el 1er movimiento
                oMExp = new Movimientos_expediente
                {
                    anio = oExp.Anio,
                    nro_expediente = oExp.Nro_expediente,
                    nro_paso = 0,
                    cod_estado_expediente = oExp.Cod_estado_expediente,
                    codigo_oficina_origen = oExp.Cod_oficina_origen,
                    codigo_oficina_destino = oExp.Cod_oficina_destino,
                    fecha_pase = DateTime.Today,
                    observaciones = oExp.Observaciones,
                    atendido = false,
                    usuario = oExp.Usuario ?? "",
                    dias_sin_resolver = 0,
                    fojas = oExp.Fojas
                };
                Movimientos_expediente.Inserto1erMovimiento(oMExp, cn, trx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la insercion!!!");
            }
        }


        public static int NuevoExpedienteConRetorno(Expediente oExp, SqlConnection cn, SqlTransaction trx, int opcion)
        {
            StringBuilder strInsert = new StringBuilder();
            int aux_nro_expediente = 0;
            int aux_nro_expediente_base = GetNroExpediente();
            Movimientos_expediente oMExp;

            try
            {
                string SQL = @"SELECT ISNULL(max(nro_expediente),0) as nro_expediente 
                       FROM EXPEDIENTE WHERE anio=@anio";

                // 1er
                SqlCommand cmd = cn.CreateCommand();
                cmd.Transaction = trx;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = SQL;
                cmd.Parameters.AddWithValue("@anio", oExp.Anio);
                aux_nro_expediente = Convert.ToInt32(cmd.ExecuteScalar()) + 1;

                // Si es el primer registro del año
                // Seteo por defecto a 10001 o en base al nro de expediente parametro
                if (aux_nro_expediente == 1)
                    aux_nro_expediente = aux_nro_expediente_base;

                oExp.Nro_expediente = aux_nro_expediente;

                // Doy de Alta o Actualizo Persona segun corresponda
                if (opcion == 0)
                    Persona.InsertPersona(oExp.objPersona, cn, trx);
                else
                    Persona.UpdatePersona(oExp.objPersona, cn, trx);

                // 2do
                strInsert.AppendLine("insert into Expediente");
                strInsert.AppendLine("(anio, nro_expediente, fecha_alta_registro, fecha_ingreso, id_persona, " +
                    "nombre, cod_tipo_tramite, cod_asunto, cod_oficina_origen, cod_oficina_destino, cod_estado_expediente, " +
                    "observaciones, pase, anulado, ejecutado, email, usuario, celular, cuit, fojas, anio_padre, nro_expediente_padre, " +
                    "atendido, nro_anexo)");
                strInsert.AppendLine("VALUES");
                strInsert.AppendLine("(@anio, @nro_expediente, @fecha_alta_registro, @fecha_ingreso, @id_persona, " +
                    "@nombre, @cod_tipo_tramite, @cod_asunto, @cod_oficina_origen, @cod_oficina_destino, @cod_estado_expediente, " +
                    "@observaciones, @pase, @anulado, @ejecutado, @email, @usuario, @celular, @cuit, @fojas, @anio_padre, @nro_expediente_padre," +
                    " @atendido, @nro_anexo)");

                SqlCommand cmdInsert = cn.CreateCommand();
                cmdInsert.Transaction = trx;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strInsert.ToString();

                cmdInsert.Parameters.AddWithValue("@anio", oExp.Anio);
                cmdInsert.Parameters.AddWithValue("@nro_expediente", oExp.Nro_expediente);
                cmdInsert.Parameters.AddWithValue("@fecha_alta_registro", oExp.Fecha_alta_registro);
                cmdInsert.Parameters.AddWithValue("@fecha_ingreso", oExp.Fecha_ingreso);
                cmdInsert.Parameters.AddWithValue("@id_persona", oExp.objPersona.id_persona);
                cmdInsert.Parameters.AddWithValue("@nombre", oExp.objPersona.nombre ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@cod_tipo_tramite", oExp.Cod_tipo_tramite);
                cmdInsert.Parameters.AddWithValue("@cod_asunto", oExp.Cod_asunto);
                cmdInsert.Parameters.AddWithValue("@cod_oficina_origen", oExp.Cod_oficina_origen);
                cmdInsert.Parameters.AddWithValue("@cod_oficina_destino", oExp.Cod_oficina_destino);
                cmdInsert.Parameters.AddWithValue("@cod_estado_expediente", oExp.Cod_estado_expediente);
                cmdInsert.Parameters.AddWithValue("@observaciones", oExp.Observaciones ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@pase", oExp.Pase);
                cmdInsert.Parameters.AddWithValue("@anulado", oExp.Anulado);
                cmdInsert.Parameters.AddWithValue("@ejecutado", oExp.Ejecutado);
                cmdInsert.Parameters.AddWithValue("@email", oExp.Email);
                cmdInsert.Parameters.AddWithValue("@usuario", oExp.Usuario ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@celular", oExp.Celular ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@cuit", oExp.objPersona.cuit);
                cmdInsert.Parameters.AddWithValue("@fojas", oExp.Fojas);
                cmdInsert.Parameters.AddWithValue("@anio_padre", oExp.Anio_padre);
                cmdInsert.Parameters.AddWithValue("@nro_expediente_padre", oExp.Nro_expediente_padre);
                cmdInsert.Parameters.AddWithValue("@atendido", oExp.Atendido);
                cmdInsert.Parameters.AddWithValue("@nro_anexo", oExp.Nro_anexo);

                cmdInsert.ExecuteNonQuery();

                // 3er paso
                // inserto el 1er movimiento
                oMExp = new Movimientos_expediente
                {
                    anio = oExp.Anio,
                    nro_expediente = oExp.Nro_expediente,
                    nro_paso = 0,
                    cod_estado_expediente = oExp.Cod_estado_expediente,
                    codigo_oficina_origen = oExp.Cod_oficina_origen,
                    codigo_oficina_destino = oExp.Cod_oficina_destino,
                    fecha_pase = DateTime.Today,
                    observaciones = oExp.Observaciones,
                    atendido = false,
                    usuario = oExp.Usuario ?? "",
                    dias_sin_resolver = 0,
                    fojas = oExp.Fojas
                };

                Movimientos_expediente.Inserto1erMovimiento(oMExp, cn, trx);
                // Retorno el nro_expediente y anio combinados como entero
                return int.Parse($"{oExp.Nro_expediente}{oExp.Anio}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en la inserción, metodo NuevoExpedienteConRetorno!!!");
            }
        }


        public static void update(Expediente obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("UPDATE  Expediente SET");
                sql.AppendLine("Fecha_alta_registro=@Fecha_alta_registro");
                sql.AppendLine(", Fecha_ingreso=@Fecha_ingreso");
                sql.AppendLine(", Id_persona=@Id_persona");
                sql.AppendLine(", Nombre=@Nombre");
                sql.AppendLine(", Domicilio=@Domicilio");
                sql.AppendLine(", Telefono=@Telefono");
                sql.AppendLine(", Email=@Email");
                sql.AppendLine(", Cod_tipo_documento=@Cod_tipo_documento");
                sql.AppendLine(", Nro_documento=@Nro_documento");
                sql.AppendLine(", Cod_tipo_tramite=@Cod_tipo_tramite");
                sql.AppendLine(", Cod_asunto=@Cod_asunto");
                sql.AppendLine(", Cod_oficina_origen=@Cod_oficina_origen");
                sql.AppendLine(", Cod_oficina_destino=@Cod_oficina_destino");
                sql.AppendLine(", Cod_estado_expediente=@Cod_estado_expediente");
                sql.AppendLine(", Observaciones=@Observaciones");
                sql.AppendLine(", Pase=@Pase");
                sql.AppendLine(", Anulado=@Anulado");
                sql.AppendLine(", Ejecutado=@Ejecutado");
                sql.AppendLine(", Fecha_fin_tramite=@Fecha_fin_tramite");
                sql.AppendLine(", Usuario=@Usuario");
                sql.AppendLine(", Celular=@Celular");
                sql.AppendLine(", Cuit=@Cuit");
                sql.AppendLine(", Fojas=@Fojas");
                sql.AppendLine(", Anio_padre=@Anio_padre");
                sql.AppendLine(", Nro_expediente_padre=@Nro_expediente_padre");
                sql.AppendLine(", Atendido=@Atendido");
                sql.AppendLine(", Nro_anexo=@Nro_anexo");
                sql.AppendLine(", Fecha_atendido=@Fecha_atendido");
                sql.AppendLine("WHERE");
                sql.AppendLine("Anio=@Anio");
                sql.AppendLine("AND Nro_expediente=@Nro_expediente");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
                    cmd.Parameters.AddWithValue("@Nro_expediente", obj.Nro_expediente);
                    cmd.Parameters.AddWithValue("@Fecha_alta_registro", obj.Fecha_alta_registro);
                    cmd.Parameters.AddWithValue("@Fecha_ingreso", obj.Fecha_ingreso);
                    cmd.Parameters.AddWithValue("@Id_persona", obj.Id_persona);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Domicilio", obj.Domicilio);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                    cmd.Parameters.AddWithValue("@Email", obj.Email);
                    cmd.Parameters.AddWithValue("@Cod_tipo_documento", obj.Cod_tipo_documento);
                    cmd.Parameters.AddWithValue("@Nro_documento", obj.Nro_documento);
                    cmd.Parameters.AddWithValue("@Cod_tipo_tramite", obj.Cod_tipo_tramite);
                    cmd.Parameters.AddWithValue("@Cod_asunto", obj.Cod_asunto);
                    cmd.Parameters.AddWithValue("@Cod_oficina_origen", obj.Cod_oficina_origen);
                    cmd.Parameters.AddWithValue("@Cod_oficina_destino", obj.Cod_oficina_destino);
                    cmd.Parameters.AddWithValue("@Cod_estado_expediente", obj.Cod_estado_expediente);
                    cmd.Parameters.AddWithValue("@Observaciones", obj.Observaciones);
                    cmd.Parameters.AddWithValue("@Pase", obj.Pase);
                    cmd.Parameters.AddWithValue("@Anulado", obj.Anulado);
                    cmd.Parameters.AddWithValue("@Ejecutado", obj.Ejecutado);
                    cmd.Parameters.AddWithValue("@Fecha_fin_tramite", obj.Fecha_fin_tramite);
                    cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                    cmd.Parameters.AddWithValue("@Celular", obj.Celular);
                    cmd.Parameters.AddWithValue("@Cuit", obj.Cuit);
                    cmd.Parameters.AddWithValue("@Fojas", obj.Fojas);
                    cmd.Parameters.AddWithValue("@Anio_padre", obj.Anio_padre);
                    cmd.Parameters.AddWithValue("@Nro_expediente_padre", obj.Nro_expediente_padre);
                    cmd.Parameters.AddWithValue("@Atendido", obj.Atendido);
                    cmd.Parameters.AddWithValue("@Nro_anexo", obj.Nro_anexo);
                    cmd.Parameters.AddWithValue("@Fecha_atendido", obj.Fecha_atendido);
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void delete(Expediente obj)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendLine("DELETE  Expediente ");
                sql.AppendLine("WHERE");
                sql.AppendLine("Anio=@Anio");
                sql.AppendLine("AND Nro_expediente=@Nro_expediente");
                using (SqlConnection con = GetConnection())
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = sql.ToString();
                    cmd.Parameters.AddWithValue("@Anio", obj.Anio);
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

