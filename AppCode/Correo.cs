using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace AppCode
{
    public class Correo
    {
        String id;
        String id_cliente;
        String email;
        String alias;
        String estado;
        String origen;
        String secuencia;
        String apoderado;

        public string Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Id_cliente
        {
            get
            {
                return id_cliente;
            }

            set
            {
                id_cliente = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }

            set
            {
                alias = value;
            }
        }

        public string Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public string Origen
        {
            get
            {
                return origen;
            }

            set
            {
                origen = value;
            }
        }

        public string Secuencia
        {
            get
            {
                return secuencia;
            }

            set
            {
                secuencia = value;
            }
        }

        public string Apoderado
        {
            get
            {
                return apoderado;
            }

            set
            {
                apoderado = value;
            }
        }

        //public string Id { get => id; set => id = value; }
        //public string Id_cliente { get => id_cliente; set => id_cliente = value; }
        //public string Email { get => email; set => email = value; }
        //public string Alias { get => alias; set => alias = value; }
        //public string Estado { get => estado; set => estado = value; }
        //public string Origen { get => origen; set => origen = value; }
        //public string Secuencia { get => secuencia; set => secuencia = value; }
        //public string Apoderado { get => apoderado; set => apoderado = value; }


        public DataTable ObtenerCorreoCliente(String idProducto, String idcliente)
        {
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = conect.agregaParametros("@idProducto", idProducto);
            parameters[1] = conect.agregaParametros("@idCliente", idcliente.Trim());
            dt = conect.EjecutarSP_Parametros("SP_CO_OBTENER_CORREOS_CLIENTES", parameters);
            return dt;
        }

        public List<Correo> ObtenerListaCorreos(string rut)
        {
            List<Correo> listaForward = new List<Correo>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", rut);
            dt = conect.EjecutarSP_Parametros("[SP_CO_OBTENER_CORREOS]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Correo con = new Correo();
                con.Id = row["ID"].ToString();
                con.id_cliente = row["ID_CLIENTE"].ToString();
                con.Email = row["CORREO"].ToString();
                con.Alias = row["ALIAS"].ToString();
                con.Estado = row["ESTADO"].ToString();
                //con.elorigen = row["ORIGEN"].ToString();
                string origen = row["ORIGEN"].ToString();
                if (origen == "1")
                {
                    con.Origen = "Local";
                }
                else
                {
                    con.Origen = "CRM";/*siga crm*/
                }
                listaForward.Add(con);
            }
            return listaForward;
        }

        public string EliminarCorreo(string id)
        {
            string resultado = "";

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@ID", id);
            dt = conect.EjecutarSP_Parametros("SP_CO_ELIMINAR_CORREO", parameters);
            return resultado;
        }

        public string nuevoCorreo(string Email, string Alias, string Rut)
        {
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = conect.agregaParametros("@CORREO", Email);
            parameters[1] = conect.agregaParametros("@ALIAS", Alias);
            parameters[2] = conect.agregaParametros("@ID_CLIENTE", Rut);
            dt = conect.EjecutarSP_Parametros("[SP_CO_CREAR_CORREO]", parameters);
            string retorno = "";
            foreach (DataRow row in dt.Rows)
            {
                retorno = row["retorno"].ToString();
            }
            return retorno;
        }

        public DataTable editarCorreos(string Email, string Alias, string Estado, string ID, string Rut)
        {
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = conect.agregaParametros("@CORREO", Email);
            parameters[1] = conect.agregaParametros("@ALIAS", Alias);
            parameters[2] = conect.agregaParametros("@ID_CLIENTE", Rut);
            parameters[3] = conect.agregaParametros("@ESTADO", Estado);
            parameters[4] = conect.agregaParametros("@ID", ID);
            dt = conect.EjecutarSP_Parametros("SP_CO_EDITAR_CLIENTES", parameters);
            return dt;
        }

        public List<Correo> generaListaDistribucion(string Rut, string Lista, string Secuencia)
        {
            List<Correo> listaCorreos = new List<Correo>();
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", Rut);
            parameters[1] = conect.agregaParametros("@ID_PRODUCTO", Lista);
            parameters[2] = conect.agregaParametros("@SECUENCIA", Secuencia);
            dt = conect.EjecutarSP_Parametros("[SP_CO_OBTENER_LISTA_DISTRIBUCION]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Correo con = new Correo();
                con.Id = row["ID"].ToString();
                con.id_cliente = row["ID_CLIENTE"].ToString();
                con.Email = row["CORREO"].ToString();
                con.Alias = row["ALIAS"].ToString();
                con.Apoderado = row["APODERADO"].ToString();
                con.Secuencia = row["SECUENCIA"].ToString();
                //con.Estado = row["ESTADO"].ToString();
                string estado = row["ESTADO"].ToString();
                if (estado == "1")
                {
                    con.Estado = "Activo";
                }
                else if(estado == "-1")
                {
                    con.Estado = "Creado";
                }
                else
                {
                    con.Estado = "Eliminado";
                }
                
                listaCorreos.Add(con);
            }
            return listaCorreos;
        }


        public List<Correo> generaNuevaListaDistribucion(string Rut, string Lista)
        {
            List<Correo> listaCorreos = new List<Correo>();
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", Rut);
            //parameters[1] = conect.agregaParametros("@ID_PRODUCTO", Lista);
            dt = conect.EjecutarSP_Parametros("[SP_CO_PRE_LISTA_DISTRIBUCION]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Correo con = new Correo();
                con.Id = row["ID"].ToString();
                con.id_cliente = row["ID_CLIENTE"].ToString();
                con.Email = row["CORREO"].ToString();
                con.Alias = row["ALIAS"].ToString();
                con.Origen = row["ORIGEN"].ToString();
                listaCorreos.Add(con);
            }
            return listaCorreos;
        }

        public string insertarNuevaListaDeDistribucion(string Idcorreo, string IdCliente, string Email, string Alias, string Origen, string Secuencia, string Apoderado, string Producto)
        {
            string resultado = "";

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", IdCliente);
            parameters[1] = conect.agregaParametros("@ID_PRODUCTO", Producto);
            parameters[2] = conect.agregaParametros("@ID_CORREO", Idcorreo);
            parameters[3] = conect.agregaParametros("@APODERADO", Apoderado);
            parameters[4] = conect.agregaParametros("@secuencia", Secuencia);

            dt = conect.EjecutarSP_Parametros("[SP_CO_INSERTAR_LISTA_DISTRIBUCION]", parameters);
            resultado = dt.ToString();
            return resultado;
        }

        public string EliminarListaDistribucion(string Rut, string Producto, string Secuencia)
        {
            string resultado = "";

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", Rut);
            parameters[1] = conect.agregaParametros("@ID_PRODUCTO", Producto);
            parameters[2] = conect.agregaParametros("@secuencia", Secuencia);

            dt = conect.EjecutarSP_Parametros("[SP_CO_ELIMINAR_LISTA_DISTRIBUCION]", parameters);
            resultado = dt.ToString();
            return resultado;
        }


        public string actualizarListaDistribucion(string Idlist, string IdCliente, string Email, string Alias, string Secuencia, string Apoderado, string Incluido, string Producto)
        {
            string resultado = "";

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);

            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = conect.agregaParametros("@ID_CLIENTE", IdCliente);
            parameters[1] = conect.agregaParametros("@ID_PRODUCTO", Producto);
            parameters[2] = conect.agregaParametros("@ID_CORREO", Idlist);
            parameters[3] = conect.agregaParametros("@APODERADO", Apoderado);
            parameters[4] = conect.agregaParametros("@secuencia", Secuencia);
            //parameters[5] = conect.agregaParametros("@INCLUIDO", Incluido);
            //parameters[6] = conect.agregaParametros("@secuencia", Secuencia);
            //parameters[7] = conect.agregaParametros("@secuencia", Producto);
            if (Incluido == "0")
            {
                dt = conect.EjecutarSP_Parametros("[SP_CO_BORRAR_LISTA_DISTRIBUCION]", parameters);
            }
            else if (Incluido == "1" && Apoderado == "0" || Incluido == "1" && Apoderado == "1")
            {
                //dt = conect.EjecutarSP_Parametros("[SP_CO_INSERTAR_LISTA_DISTRIBUCION]", parameters);
                dt = conect.EjecutarSP_Parametros("[SP_CO_ACTUALIZAR_LISTA_DISTRIBUCION]", parameters);
            }
            //else if(Incluido == "1" && Apoderado == "1")
            //{
            //    dt = conect.EjecutarSP_Parametros("[SP_CO_INSERTAR_LISTA_DISTRIBUCION]", parameters);
            //    dt = conect.EjecutarSP_Parametros("[SP_CO_ACTUALIZAR_LISTA_DISTRIBUCION]", parameters);
            //}
            else
            {
                //dt = conect.EjecutarSP_Parametros("[SP_CO_BORRAR_LISTA_DISTRIBUCION]", parameters);
            }
            //dt = conect.EjecutarSP_Parametros("[SP_CO_ACTUALIZAR_LISTA_DISTRIBUCION]", parameters);
            resultado = dt.ToString();
            return resultado;
        }

        public List<Correo> ObetenerDataCorreo(string IdCorreo, string Rut)
        {
            List<Correo> infoCorreo = new List<Correo>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = conect.agregaParametros("@ID", IdCorreo);
            parameters[1] = conect.agregaParametros("@ID_CLIENTE", Rut);
            dt = conect.EjecutarSP_Parametros("[SP_CO_OBTENER_UNICO_CORREO]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Correo con = new Correo();
                con.Email = row["CORREO"].ToString();
                con.Alias = row["ALIAS"].ToString();
                con.Estado = row["ESTADO"].ToString();
                //con.elorigen = row["ORIGEN"].ToString();
                con.Origen = "SIGA"; /*siga crm*/
                infoCorreo.Add(con);
            }
            return infoCorreo;
        }

    }
}
