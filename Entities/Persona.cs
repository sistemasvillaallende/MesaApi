using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace MesaApi.Entities
{
    public class Persona
    {
        public int id_persona { get; set; }
        public string cuit { get; set; }
        public int cod_tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public string fecha_alta_registro { get; set; }
        public string fecha_nacimiento { get; set; }
        public string sexo { get; set; }
        public int cod_estado_civil { get; set; }
        public string nombre { get; set; }
        public string tel_particular { get; set; }
        public string tel_celular { get; set; }
        public string nom_calle { get; set; }
        public string nro_domicilio { get; set; }
        public string nom_barrio { get; set; }
        public string cod_postal { get; set; }
        public string ciudad { get; set; }
        public string provincia { get; set; }
        public int cod_tipo_contacto { get; set; }
        public int cod_tipo_actividad { get; set; }
        public string observaciones { get; set; }
        public string email { get; set; }


        public Persona()
        {
            id_persona = 0;
            cuit = "";
            cod_tipo_documento = 0;
            nro_documento = "";
            fecha_alta_registro = "";
            sexo = "";
            fecha_nacimiento = "";
            nombre = "";
            tel_particular = "";
            tel_celular = "";
            nom_calle = "";
            nro_domicilio = "";
            nom_barrio = "";
            cod_postal = "";
            ciudad = "";
            provincia = "";
            cod_tipo_contacto = 0;
            cod_tipo_actividad = 0;
            observaciones = "";
            email = "";
        }



        public static void InsertPersona(Entities.Persona oPer, SqlConnection cn, SqlTransaction trx)
        {

            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmdInsert;

            try
            {
                strSQL.AppendLine("INSERT INTO PERSONAS ");
                strSQL.AppendLine("(cuit,");
                strSQL.AppendLine("cod_tipo_documento,");
                strSQL.AppendLine("nro_documento,");
                strSQL.AppendLine("fecha_alta_registro,");
                strSQL.AppendLine("sexo,");
                if (oPer.fecha_nacimiento.Length > 0)
                    strSQL.AppendLine("fecha_nacimiento,");
                if (oPer.cod_estado_civil > 0)
                    strSQL.AppendLine("cod_estado_civil,");
                strSQL.AppendLine("nombre,");
                if (oPer.tel_particular.Length > 0)
                    strSQL.AppendLine("tel_particular,");
                if (oPer.tel_celular.Length > 0)
                    strSQL.AppendLine("tel_celular,");
                if (oPer.nom_calle.Length > 0)
                    strSQL.AppendLine("nom_calle,");
                if (oPer.email.Length > 0)
                    strSQL.AppendLine("email, ");

                //char[] MyChar = { ',' };
                string sql = "";
                sql = strSQL.ToString();
                strSQL.Clear();
                strSQL.AppendLine(sql.Remove(sql.Trim().Length - 1, 1));
                strSQL.AppendLine(")");
                //Asigno Valores 
                strSQL.AppendLine("VALUES ");
                strSQL.AppendLine("(@cuit,");
                strSQL.AppendLine("@cod_tipo_documento,");
                strSQL.AppendLine("@nro_documento,");
                strSQL.AppendLine("@fecha_alta_registro,");
                strSQL.AppendLine("@sexo,");
                if (oPer.fecha_nacimiento.Length > 0)
                    strSQL.AppendLine("@fecha_nacimiento,");
                if (oPer.cod_estado_civil > 0)
                    strSQL.AppendLine("@cod_estado_civil,");
                strSQL.AppendLine("@nombre,");
                if (oPer.tel_particular.Length > 0)
                    strSQL.AppendLine("@tel_particular,");
                if (oPer.tel_celular.Length > 0)
                    strSQL.AppendLine("@tel_celular,");
                if (oPer.nom_calle.Length > 0)
                    strSQL.AppendLine("@nom_calle,");
                if (oPer.email.Length > 0)
                    strSQL.AppendLine("@email,");


                //Con esto le Saco la Ultima ,
                string sql1 = "";
                sql1 = strSQL.ToString();
                strSQL.Clear();
                strSQL.AppendLine(sql1.Remove(sql1.Trim().Length - 1, 1));
                //Aca cierro con ) el values
                strSQL.AppendLine("); ");
                strSQL.AppendLine("SELECT SCOPE_IDENTITY()");


                cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = strSQL.ToString();
                cmdInsert.Transaction = trx;


                cmdInsert.Parameters.Add(new SqlParameter("@cuit", oPer.cuit));
                cmdInsert.Parameters.Add(new SqlParameter("@cod_tipo_documento", oPer.cod_tipo_documento));
                cmdInsert.Parameters.Add(new SqlParameter("@nro_documento", oPer.nro_documento));
                cmdInsert.Parameters.Add(new SqlParameter("@fecha_alta_registro", oPer.fecha_alta_registro != null ? oPer.fecha_alta_registro : null));
                cmdInsert.Parameters.Add(new SqlParameter("@sexo", oPer.sexo != null ? oPer.sexo : "0"));
                if (oPer.fecha_nacimiento.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@fecha_nacimiento", oPer.fecha_nacimiento));
                if (oPer.cod_estado_civil > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@cod_estado_civil", oPer.cod_estado_civil));
                cmdInsert.Parameters.Add(new SqlParameter("@nombre", oPer.nombre));
                if (oPer.tel_particular.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@tel_particular", oPer.tel_particular != null ? oPer.tel_particular : null));
                if (oPer.tel_celular.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@tel_celular", oPer.tel_celular != null ? oPer.tel_celular : null));
                if (oPer.nom_calle.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@nom_calle", oPer.nom_calle != null ? oPer.nom_calle : null));
                if (oPer.email.Length > 0)
                    cmdInsert.Parameters.Add(new SqlParameter("@email", oPer.email != null ? oPer.email : null));
                oPer.id_persona = Convert.ToInt32(cmdInsert.ExecuteScalar());
            }
            catch (Exception ex)
            {
                strSQL = null;
                cmdInsert = null;
                throw new Exception(ex.Message + " Error en la insercion!!!");
            }

        }


        public static void UpdatePersona(Entities.Persona oPer, SqlConnection cn, SqlTransaction trx)
        {

            StringBuilder strSQL = new StringBuilder();
            SqlCommand cmdUpdate;

            try
            {
                strSQL.AppendLine("UPDATE PERSONAS SET ");

                if (oPer.sexo.Length > 0)
                    strSQL.AppendLine("sexo=@sexo,");
                if (oPer.fecha_nacimiento.Length > 0)
                    strSQL.AppendLine("fecha_nacimiento=@fecha_nacimiento,");
                if (oPer.cod_estado_civil > 0)
                    strSQL.AppendLine("cod_estado_civil=@cod_estado_civil,");
                if (oPer.nombre.Length > 0)
                    strSQL.AppendLine("nombre=@nombre,");
                if (oPer.tel_particular.Length > 0)
                    strSQL.AppendLine("tel_particular=@tel_particular,");
                if (oPer.tel_celular.Length > 0)
                    strSQL.AppendLine("tel_celular=@tel_celular,");
                if (oPer.nom_calle.Length > 0)
                    strSQL.AppendLine("nom_calle=@nom_calle,");
                if (oPer.email.Length > 0)
                    strSQL.AppendLine("email=@email,");


                char[] MyChar = { ',' };
                string sql = "";
                sql = strSQL.ToString();
                strSQL.Clear();
                strSQL.AppendLine(sql.Remove(sql.Trim().Length - 1, 1));

                strSQL.AppendLine("WHERE id_persona=@id_persona");
                //Asigno Valores 

                //Fecha_orden_compra

                cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = strSQL.ToString();
                cmdUpdate.Transaction = trx;

                cmdUpdate.Parameters.Add(new SqlParameter("@cuit", oPer.cuit));
                cmdUpdate.Parameters.Add(new SqlParameter("@id_persona", oPer.id_persona));

                if (oPer.sexo.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@sexo", oPer.sexo != null ? oPer.sexo : "0"));
                if (oPer.fecha_nacimiento.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@fecha_nacimiento", oPer.fecha_nacimiento));
                if (oPer.cod_estado_civil > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@cod_estado_civil", oPer.cod_estado_civil));
                if (oPer.nombre.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@nombre", oPer.nombre));
                if (oPer.tel_particular.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@tel_particular", oPer.tel_particular != null ? oPer.tel_particular : null));
                if (oPer.tel_celular.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@tel_celular", oPer.tel_celular != null ? oPer.tel_celular : null));
                if (oPer.nom_calle.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@nom_calle", oPer.nom_calle != null ? oPer.nom_calle : null));
                if (oPer.email.Length > 0)
                    cmdUpdate.Parameters.Add(new SqlParameter("@email", oPer.email != null ? oPer.email : null));

                cmdUpdate.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " Error en el Update!!!");
                strSQL = null;
                cmdUpdate = null;
                throw;
            }

        }

    }

}