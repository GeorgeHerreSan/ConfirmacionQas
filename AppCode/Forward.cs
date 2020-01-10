using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCode
{
    public class Forward
    {
        String id;
        String folio;
        String rut;
        String secuencia;
        String razonSocial;
        String fechaInicio;
        String fechaVencimiento;
        String mtoMonPrinc;
        String tcCierre;
        String mtoMonSecu;
        String modalidad;
        String dias;
        String tipoMov;
        String cod_Mon_Cierre;
        String cod_Mon_Secu;
        String paridad_Cierre;
        String margen;
        String ejecutivo;
        String clasificacion;
        String usuarioCreador;
        String codMoneda1;
        String codMoneda2;
        String tcTransf;
        String codSecEco;
        String fecha_Inicio;
        String estado;
        String fechaEnvioConfirmacion;
        String fechaConfirmacion;
        String fechaEliminacion;
        String respuestaConfirmacion;
        String origen;
        String recibimosPagamos;
        String monedaAnticipo;
        String diast;
        String fechaContrato;
        String ulrContratro;
        String estadoContrato;


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

        public string Folio
        {
            get
            {
                return folio;
            }

            set
            {
                folio = value;
            }
        }

        public string Rut
        {
            get
            {
                return rut;
            }

            set
            {
                rut = value;
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

        public string RazonSocial
        {
            get
            {
                return razonSocial;
            }

            set
            {
                razonSocial = value;
            }
        }

        public string FechaInicio
        {
            get
            {
                return fechaInicio;
            }

            set
            {
                fechaInicio = value;
            }
        }

        public string FechaVencimiento
        {
            get
            {
                return fechaVencimiento;
            }

            set
            {
                fechaVencimiento = value;
            }
        }

        public string MtoMonPrinc
        {
            get
            {
                return mtoMonPrinc;
            }

            set
            {
                mtoMonPrinc = value;
            }
        }

        public string TcCierre
        {
            get
            {
                return tcCierre;
            }

            set
            {
                tcCierre = value;
            }
        }

        public string MtoMonSecu
        {
            get
            {
                return mtoMonSecu;
            }

            set
            {
                mtoMonSecu = value;
            }
        }

        public string Modalidad
        {
            get
            {
                return modalidad;
            }

            set
            {
                modalidad = value;
            }
        }

        public string Dias
        {
            get
            {
                return dias;
            }

            set
            {
                dias = value;
            }
        }

        public string TipoMov
        {
            get
            {
                return tipoMov;
            }

            set
            {
                tipoMov = value;
            }
        }

        public string Cod_Mon_Princ
        {
            get
            {
                return cod_Mon_Cierre;
            }

            set
            {
                cod_Mon_Cierre = value;
            }
        }

        public string Cod_Mon_Secu
        {
            get
            {
                return cod_Mon_Secu;
            }

            set
            {
                cod_Mon_Secu = value;
            }
        }

        public string Paridad_Cierre
        {
            get
            {
                return paridad_Cierre;
            }

            set
            {
                paridad_Cierre = value;
            }
        }

        public string Margen
        {
            get
            {
                return margen;
            }

            set
            {
                margen = value;
            }
        }

        public string Ejecutivo
        {
            get
            {
                return ejecutivo;
            }

            set
            {
                ejecutivo = value;
            }
        }

        public string Clasificacion
        {
            get
            {
                return clasificacion;
            }

            set
            {
                clasificacion = value;
            }
        }

        public string UsuarioCreador
        {
            get
            {
                return usuarioCreador;
            }

            set
            {
                usuarioCreador = value;
            }
        }

        public string CodMoneda1
        {
            get
            {
                return codMoneda1;
            }

            set
            {
                codMoneda1 = value;
            }
        }

        public string CodMoneda2
        {
            get
            {
                return codMoneda2;
            }

            set
            {
                codMoneda2 = value;
            }
        }

        public string TcTransf
        {
            get
            {
                return tcTransf;
            }

            set
            {
                tcTransf = value;
            }
        }

        public string CodSecEco
        {
            get
            {
                return codSecEco;
            }

            set
            {
                codSecEco = value;
            }
        }

        public string Fecha_Inicio
        {
            get
            {
                return fecha_Inicio;
            }

            set
            {
                fecha_Inicio = value;
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

        public string FechaEnvioConfirmacion
        {
            get
            {
                return fechaEnvioConfirmacion;
            }

            set
            {
                fechaEnvioConfirmacion = value;
            }
        }

        public string FechaConfirmacion
        {
            get
            {
                return fechaConfirmacion;
            }

            set
            {
                fechaConfirmacion = value;
            }
        }

        public string FechaEliminacion
        {
            get
            {
                return fechaEliminacion;
            }

            set
            {
                fechaEliminacion = value;
            }
        }

        public string RespuestaConfirmacion
        {
            get
            {
                return respuestaConfirmacion;
            }

            set
            {
                respuestaConfirmacion = value;
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

        public string Diast
        {
            get
            {
                return diast;
            }

            set
            {
                diast = value;
            }
        }

        public string FechaContrato
        {
            get
            {
                return fechaContrato;
            }

            set
            {
                fechaContrato = value;
            }
        }

        public string UlrContratro
        {
            get
            {
                return ulrContratro;
            }

            set
            {
                ulrContratro = value;
            }
        }

        public string EstadoContrato
        {
            get
            {
                return estadoContrato;
            }

            set
            {
                estadoContrato = value;
            }
        }

        //public string Diast { get => diast; set => diast = value; }
        //public string FechaContrato { get => fechaContrato; set => fechaContrato = value; }
        //public string UlrContratro { get => ulrContratro; set => ulrContratro = value; }
        //public string EstadoContrato { get => estadoContrato; set => estadoContrato = value; }

        //public string Folio { get => folio; set => folio = value; }
        //public string Rut { get => rut; set => rut = value; }
        //public string Secuencia { get => secuencia; set => secuencia = value; }
        //public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        //public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        //public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        //public string MtoMonPrinc { get => mtoMonPrinc; set => mtoMonPrinc = value; }
        //public string TcCierre { get => tcCierre; set => tcCierre = value; }
        //public string MtoMonSecu { get => mtoMonSecu; set => mtoMonSecu = value; }
        //public string Modalidad { get => modalidad; set => modalidad = value; }
        //public string Dias { get => dias; set => dias = value; }
        //public string TipoMov { get => tipoMov; set => tipoMov = value; }
        //public string Cod_Mon_Princ { get => cod_Mon_Cierre; set => cod_Mon_Cierre = value; }
        //public string Cod_Mon_Secu { get => cod_Mon_Secu; set => cod_Mon_Secu = value; }
        //public string Margen { get => margen; set => margen = value; }
        //public string Ejecutivo { get => ejecutivo; set => ejecutivo = value; }
        //public string Clasificacion { get => clasificacion; set => clasificacion = value; }
        //public string UsuarioCreador { get => usuarioCreador; set => usuarioCreador = value; }
        //public string CodMoneda1 { get => codMoneda1; set => codMoneda1 = value; }
        //public string CodMoneda2 { get => codMoneda2; set => codMoneda2 = value; }
        //public string TcTransf { get => tcTransf; set => tcTransf = value; }
        //public string CodSecEco { get => codSecEco; set => codSecEco = value; }
        //public string Fecha_Inicio { get => fecha_Inicio; set => fecha_Inicio = value; }
        //public string Estado { get => estado; set => estado = value; }
        //public string Paridad_Cierre { get => paridad_Cierre; set => paridad_Cierre = value; }
        //public string Id { get => id; set => id = value; }
        //public string FechaEnvioConfirmacion { get => fechaEnvioConfirmacion; set => fechaEnvioConfirmacion = value; }
        //public string Origen { get => origen; set => origen = value; }
        //public string FechaConfirmacion { get => fechaConfirmacion; set => fechaConfirmacion = value; }
        //public string FechaEliminacion { get => fechaEliminacion; set => fechaEliminacion = value; }
        //public string RespuestaConfirmacion { get => respuestaConfirmacion; set => respuestaConfirmacion = value; }

        public List<Forward> ObtenerOpDelDiaForward(string producto, string fecha)
        {
            List<Forward> listaForward = new List<Forward>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];          
            parameters[0] = conect.agregaParametros("@fecha", fecha);
            dt = conect.EjecutarSP_Parametros("[SP_CO_OBTENER_OP_POR_FECHA]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Forward con = new Forward();
                //con.Id = row["Id"].ToString();
                con.Folio = row["Folio"].ToString();
                con.Rut = row["Rut"].ToString();
                con.Secuencia = row["Secuencia"].ToString();
                con.RazonSocial = row["RazonSocial"].ToString();
                con.FechaInicio = row["FechaInicio"].ToString();
                con.FechaVencimiento = row["FechaVcto"].ToString();
                con.MtoMonPrinc = row["MtoMonPrinc"].ToString();
                con.TcCierre = row["TcCierre"].ToString();
                con.MtoMonSecu = row["MtoMonSecu"].ToString();
                con.Modalidad = row["Modalidad"].ToString();
                con.Dias = row["Dias"].ToString();
                con.TipoMov = row["TipoMov"].ToString();
                con.Cod_Mon_Princ = row["CodMonPrinc"].ToString();
                con.Cod_Mon_Secu = row["CodMonSecu"].ToString();
                con.Paridad_Cierre = row["ParidadCierre"].ToString();
                con.Margen = row["Margen"].ToString();
                con.Ejecutivo = row["Ejecutivo"].ToString();
                con.Clasificacion = row["Clasificacion"].ToString();
                con.UsuarioCreador = row["UsuarioCreador"].ToString();
                con.CodMoneda1 = row["CodMoneda"].ToString();
                //con.CodMoneda2 = row["CodMoneda2"].ToString();
                con.TcTransf = row["TcTransf"].ToString();
                con.CodSecEco = row["CodSecEco"].ToString();
                //con.Fecha_Inicio = row["Fecha_Inicio"].ToString();
                //con.Estado = row["Estado"].ToString();
                con.Origen = "SIGA"; /*siga crm*/
                listaForward.Add(con);
            }
            return listaForward;
        }

        public List<Forward> ObtenerOpDelDiaContratoForward(string producto, string fecha)
        {
            List<Forward> listaForward = new List<Forward>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@fecha", fecha);
            dt = conect.EjecutarSP_Parametros("[SP_CO_OBTENER_OP_POR_FECHA_CONTRATOS]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Forward con = new Forward();
                //con.Id = row["Id"].ToString();
                con.Folio = row["Folio"].ToString();
                con.Rut = row["Rut"].ToString();
                con.Secuencia = row["Secuencia"].ToString();
                con.RazonSocial = row["RazonSocial"].ToString();
                con.FechaInicio = row["FechaInicio"].ToString();
                con.FechaVencimiento = row["FechaVcto"].ToString();
                con.MtoMonPrinc = row["MtoMonPrinc"].ToString();
                con.TcCierre = row["TcCierre"].ToString();
                con.MtoMonSecu = row["MtoMonSecu"].ToString();
                con.Modalidad = row["Modalidad"].ToString();
                con.Dias = row["Dias"].ToString();
                con.TipoMov = row["TipoMov"].ToString();
                con.Cod_Mon_Princ = row["CodMonPrinc"].ToString();
                con.Cod_Mon_Secu = row["CodMonSecu"].ToString();
                con.Paridad_Cierre = row["ParidadCierre"].ToString();
                con.Margen = row["Margen"].ToString();
                con.Ejecutivo = row["Ejecutivo"].ToString();
                con.Clasificacion = row["Clasificacion"].ToString();
                con.UsuarioCreador = row["UsuarioCreador"].ToString();
                con.CodMoneda1 = row["CodMoneda"].ToString();
                //con.CodMoneda2 = row["CodMoneda2"].ToString();
                con.TcTransf = row["TcTransf"].ToString();
                con.CodSecEco = row["CodSecEco"].ToString();
                //con.Fecha_Inicio = row["Fecha_Inicio"].ToString();
                //con.Estado = row["Estado"].ToString();
                con.Origen = "SIGA"; /*siga crm*/
                listaForward.Add(con);
            }
            return listaForward;
        }

        public DataTable CrearOperacionBlotter(String idProducto
                                                     , String fechaInicio
                                                     , String Folio
                                                     , String fechaVencimiento
                                                     , String rut
                                                     , String secuencia
                                                     , String nombreCliente
                                                     , String tipoMovimiento
                                                     , String monedaPrincipal
                                                     , String montoPrincipal
                                                     , String monedaSecundario
                                                     , String tcCierreForward
                                                     , String montoSecundario
                                                     , String cumplimiento
                                                     , String agente
                                                     , String montoLiquidacion
                                                     , String margen
                                                     , String cartera
                                                     , String vehiculo
                                                     , String folioAsociado
                                                     , String comentario
                                                     , String fixingDate
                                                     , String fechaAnticipo
                                                     , String tasaAnticipo
                                                     , String recibimosPagamos
                                                     , String monedaAnticipo)
        {
            try
            {
                string conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
                Conexion conect = new Conexion(conexion_string);
                DataTable dt = new DataTable();
                SqlParameter[] parameters = new SqlParameter[26];
                parameters[0] = conect.agregaParametros("@idProducto", idProducto);
                parameters[1] = conect.agregaParametros("@fechaInicio", fechaInicio);
                parameters[2] = conect.agregaParametros("@folio", Folio);
                parameters[3] = conect.agregaParametros("@fechaVencimiento", fechaVencimiento);
                parameters[4] = conect.agregaParametros("@rutCliente", rut);
                parameters[5] = conect.agregaParametros("@secuencia", secuencia);
                parameters[6] = conect.agregaParametros("@nombreCliente", nombreCliente);
                parameters[7] = conect.agregaParametros("@tipoMovimiento", tipoMovimiento);
                parameters[8] = conect.agregaParametros("@monedaPrincipal", monedaPrincipal);
                parameters[9] = conect.agregaParametros("@montoPrincipal", montoPrincipal);
                parameters[10] = conect.agregaParametros("@monedaSecundaria", monedaSecundario);
                parameters[11] = conect.agregaParametros("@tcCierreForward", tcCierreForward);
                parameters[12] = conect.agregaParametros("@montoSecundaria", montoSecundario);
                parameters[13] = conect.agregaParametros("@cumplimiento", cumplimiento);
                parameters[14] = conect.agregaParametros("@agente", agente);
                parameters[15] = conect.agregaParametros("@montoLiquidación", montoLiquidacion);
                parameters[16] = conect.agregaParametros("@margen", margen);
                parameters[17] = conect.agregaParametros("@cartera", cartera);
                parameters[18] = conect.agregaParametros("@vehiculo", vehiculo);
                parameters[19] = conect.agregaParametros("@folioAsociado", folioAsociado);
                parameters[20] = conect.agregaParametros("@comentario", comentario);
                parameters[21] = conect.agregaParametros("@fixingDate", fixingDate);
                parameters[22] = conect.agregaParametros("@fechaAnticipo", fechaAnticipo);
                parameters[23] = conect.agregaParametros("@tasaAnticipo", tasaAnticipo);
                parameters[24] = conect.agregaParametros("@recibimosPagamos", recibimosPagamos);
                parameters[25] = conect.agregaParametros("@monedaAnticipo", monedaAnticipo);
   
                dt = conect.EjecutarSP_Parametros("SP_CO_CARGAR_BLOTTER", parameters);
                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }


        public List<Forward> ObtenerVencimientosForward(string producto, string fecha)
        {
            List<Forward> listaForward = new List<Forward>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = conect.agregaParametros("@xFecha", fecha);

            dt = conect.EjecutarSP_Parametros("[Sp_CO_Trae_FWD_VenCartera]", parameters);
            foreach (DataRow row in dt.Rows)
            {
                Forward con = new Forward();
                //con.Id = row["Id"].ToString();
                con.Folio = row["Folio"].ToString();
                con.Rut = row["Rut"].ToString();
                con.Secuencia = row["Secuencia"].ToString();
                con.RazonSocial = row["RazonSocial"].ToString();
                con.FechaInicio = row["FechaOperacion"].ToString();
                con.FechaVencimiento = row["FechaVcto"].ToString();
                con.MtoMonPrinc = row["MtoMonPrinc"].ToString();
                con.TcCierre = row["TcCierre"].ToString();
                con.MtoMonSecu = row["MtoMonSecu"].ToString();
                con.Modalidad = row["Modalidad"].ToString();
                con.Dias = row["Dias"].ToString();
                con.TipoMov = row["TipoMov"].ToString();
                con.Cod_Mon_Princ = row["CodMonPrinc"].ToString();
                con.Cod_Mon_Secu = row["CodMonSecu"].ToString();
                con.Paridad_Cierre = row["ParidadCierre"].ToString();
                con.Margen = row["Margen"].ToString();
                con.Ejecutivo = row["Ejecutivo"].ToString();
                con.Clasificacion = row["Clasificacion"].ToString();
                con.UsuarioCreador = row["UsuarioCreador"].ToString();
                con.CodMoneda1 = row["codigoMonedaPrinc"].ToString();
                con.CodMoneda2 = row["codigoMonedaSecun"].ToString();
                con.TcTransf = row["TcTransf"].ToString();
                con.CodSecEco = row["CodSecEco"].ToString();
                //con.Fecha_Inicio = row["Fecha_Inicio"].ToString();
                //con.Estado = row["Estado"].ToString();
                con.Origen = "SIGA"; /*siga crm*/
                listaForward.Add(con);
            }
            return listaForward;
        }



        public bool registroEnvioVencimiento(string producto, string folio)
        {
            try
            { 
            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            Conexion conect = new Conexion(conexion_string);     
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = conect.agregaParametros("@producto", "1");
            parameters[1] = conect.agregaParametros("@folio", folio);
            conect.EjecutarSP_Parametros("SP_CO_REGISTRA_ENVIO_VENCIMIENTO", parameters);
            return true;
        }
            catch
            {
                return false;
            }
        }
    }


}
