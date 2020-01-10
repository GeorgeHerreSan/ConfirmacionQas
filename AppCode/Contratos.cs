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
    public class Contratos
    {
        String numeroOperacion;
        String rutCliente;
        String nombreCliente;
        String fechaOperacion;
        String monto;
        String fechaFirma;
        String numeroDiasPendientes;
        String estado;
        

        public string NumeroOperacion
        {
            get
            {
                return numeroOperacion;
            }

            set
            {
                numeroOperacion = value;
            }
        }

        public string RutCliente
        {
            get
            {
                return rutCliente;
            }

            set
            {
                rutCliente = value;
            }
        }

        public string FechaOperacion
        {
            get
            {
                return fechaOperacion;
            }

            set
            {
                fechaOperacion = value;
            }
        }

        public string Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public string FechaFirma
        {
            get
            {
                return fechaFirma;
            }

            set
            {
                fechaFirma = value;
            }
        }

        public string NumeroDiasPendientes
        {
            get
            {
                return numeroDiasPendientes;
            }

            set
            {
                numeroDiasPendientes = value;
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

        public string NombreCliente
        {
            get
            {
                return nombreCliente;
            }

            set
            {
                nombreCliente = value;
            }
        }

        public List<Contratos> ObtenerContratos(string producto, string fecha, string cliente, string nOperacion)
        {
            List<Contratos> listaContratos = new List<Contratos>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = conect.agregaParametros("@producto", producto);
            parameters[1] = conect.agregaParametros("@fecha", fecha); 
            parameters[2] = conect.agregaParametros("@cliente", cliente);
            parameters[3] = conect.agregaParametros("@nOperacion", nOperacion);
            dt = conect.EjecutarSP_Parametros("SP_ConsultaContratos", parameters);

            foreach (DataRow row in dt.Rows)
            {
                Contratos con = new Contratos();
                con.NumeroOperacion = row["NumeroOperacion"].ToString();
                con.RutCliente = row["RutCliente"].ToString();
                con.NombreCliente = row["NombreCliente"].ToString();
                con.FechaOperacion = row["FechaOperacion"].ToString();
                con.Monto= row["Monto"].ToString().Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.FechaFirma = row["FechaFirma"].ToString();
                con.NumeroDiasPendientes = row["NumeroDiasPendientes"].ToString();
                con.Estado = row["Estado"].ToString();
                listaContratos.Add(con);

            }

            return listaContratos;
        }


    }
}
