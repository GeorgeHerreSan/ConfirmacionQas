﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppCode
{
    public class Simultaneas
    {
        String id;
        String cOD_PER;
        String index;
        String fEC_VCTO_TP;
        String nEMO;
        String rUT_CLI;
        String sEC_RUT_CLI;
        String sEC_MOVTO;
        String rSO_RAZ_SOCIAL;
        String cANTIDAD;
        String cANTIDAD_ACUM_VC;
        String cOD_AGENTE;
        String cOD_CORR_CONTRA;
        String cOD_SUC;
        String fEC_LIQ_ANTICIP;
        String fEC_LIQUID;
        String fEC_TRANS;
        String fOLIO_COMP_ADJ;
        String fOLIO_TRANS;
        String iND_TIT_CUS;
        String iNTERES_DIA;
        String lIN_COMP_ADJ;
        String mONTO;
        String mONTO_ACUM_VC;
        String pRECIO;
        String sPREAD;
        String tASA;
        String tIPO_COMP_ADJ;
        String tIPO_OPERAC;
        String iND_LIQUID;
        String pRECIO_CONTADO;
        String iND_SIMUL;
        String sEC_MOVTO_CTDO;
        String iNDEXM;
        String iD_OP;
        String fECHA_CREACION;


        String numeroOperacion;
        String rutCliente;
        String nombreCliente;
        String fechaOperacion;
        String monto;
        String fechaFirma;
        String numeroDiasPendientes;
        String estado;
        //atributos simultaneas
        String fechaInicio;
        String instrumento;
        String cantidad;
        String precioPH;
        String montoPH;
        String fechaVencimiento;
        String operacionaPlazo;
        String tasaFinsnciamiento;

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
        public string INDEXM { get { return iNDEXM; } set { iNDEXM = value; } }

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
      public string Index { get { return index; } set { index = value; } }
        public string COD_PER { get { return cOD_PER; } set { cOD_PER = value; } }

        public string FEC_VCTO_TP { get { return fEC_VCTO_TP; } set { fEC_VCTO_TP = value; } }


        public string NEMO { get { return nEMO; } set { nEMO = value; } }

        public string RUT_CLI { get { return rUT_CLI; } set { rUT_CLI = value; } }


        public string SEC_RUT_CLI { get { return sEC_RUT_CLI; } set { sEC_RUT_CLI = value; } }

        public string SEC_MOVTO { get { return sEC_MOVTO; } set { sEC_MOVTO = value; } }

        public string RSO_RAZ_SOCIAL { get { return rSO_RAZ_SOCIAL; } set { rSO_RAZ_SOCIAL = value; } }


        public string CANTIDAD { get { return cANTIDAD; } set { cANTIDAD = value; } }

        public string CANTIDAD_ACUM_VC { get { return cANTIDAD_ACUM_VC; } set { cANTIDAD_ACUM_VC = value; } }


        public string COD_AGENTE { get { return cOD_AGENTE; } set { cOD_AGENTE = value; } }

        public string COD_CORR_CONTRA { get { return cOD_CORR_CONTRA; } set { cOD_CORR_CONTRA = value; } }


        public string COD_SUC { get { return cOD_SUC; } set { cOD_SUC = value; } }


        public string FEC_LIQ_ANTICIP { get { return fEC_LIQ_ANTICIP; } set { fEC_LIQ_ANTICIP = value; } }


        public string FEC_LIQUID { get { return fEC_LIQUID; } set { fEC_LIQUID = value; } }

        public string FEC_TRANS { get { return fEC_TRANS; } set { fEC_TRANS = value; } }


        public string FOLIO_COMP_ADJ { get { return fOLIO_COMP_ADJ; } set { fOLIO_COMP_ADJ = value; } }

        public string FOLIO_TRANS { get { return fOLIO_TRANS; } set { fOLIO_TRANS = value; } }

        public string IND_TIT_CUS { get { return iND_TIT_CUS; } set { iND_TIT_CUS = value; } }

        public string INTERES_DIA { get { return iNTERES_DIA; } set { iNTERES_DIA = value; } }

        public string LIN_COMP_ADJ { get { return lIN_COMP_ADJ; } set { lIN_COMP_ADJ = value; } }

        public string MONTO { get { return mONTO; } set { mONTO = value; } }

        public string MONTO_ACUM_VC { get { return mONTO_ACUM_VC; } set { mONTO_ACUM_VC = value; } }

        public string PRECIO { get { return pRECIO; } set { pRECIO = value; } }


        public string SPREAD { get { return sPREAD; } set { sPREAD = value; } }

        public string TASA { get { return tASA; } set { tASA = value; } }
        public string TIPO_COMP_ADJ { get { return tIPO_COMP_ADJ; } set { tIPO_COMP_ADJ = value; } }
        public string TIPO_OPERAC { get { return tIPO_OPERAC; } set { tIPO_OPERAC = value; } }
        public string IND_LIQUID { get { return iND_LIQUID; } set { iND_LIQUID = value; } }
        public string PRECIO_CONTADO { get { return pRECIO_CONTADO; } set { pRECIO_CONTADO  = value; } }
        public string IND_SIMUL { get { return iND_SIMUL; } set { iND_SIMUL = value; } }

        public string ID_OP { get { return iD_OP; } set { iD_OP = value; } }
        public string FECHA_CREACION { get { return fECHA_CREACION; } set { fECHA_CREACION = value; } }



        // public string SEC_MOVTO_CTDO { get { return sEC_MOVTO_CTDO; } set { sEC_MOVTO_CTDO = value; } }

        //public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        //public string Instrumento { get => instrumento; set => instrumento = value; }
        //public string Cantidad { get => cantidad; set => cantidad = value; }
        //public string PrecioPH { get => precioPH; set => precioPH = value; }
        //public string MontoPH { get => montoPH; set => montoPH = value; }
        //public string FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        //public string OperacionaPlazo { get => operacionaPlazo; set => operacionaPlazo = value; }
        //public string TasaFinsnciamiento { get => tasaFinsnciamiento; set => tasaFinsnciamiento = value; }

        public List<Simultaneas> ObtenerOpDelDiaSimultaneas(string fecha, string fechax)
        {
            List<Simultaneas> listasimultaneas = new List<Simultaneas>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);


            SqlParameter[] parameters = new SqlParameter[2];
           // parameters[0] = conect.agregaParametros("@producto", producto);
            parameters[0] = conect.agregaParametros("@fecha", fecha);
            parameters[1] = conect.agregaParametros("@fecha2", fechax);
            //parameters[3] = conect.agregaParametros("@nOperacion", "");
            dt = conect.EjecutarSP_Parametros("SP_CO_SIM_OBTENER_FECHA", parameters);

           // Sql

            int indexxs = 0;
            foreach (DataRow row in dt.Rows)
            {

                indexxs++;

                // int indexs=
                Simultaneas con = new Simultaneas();
                // con.Index = row[indexxs].ToString();
                con.FEC_TRANS = row["FEC_TRANS"].ToString();
                con.FEC_VCTO_TP = row["FEC_VCTO_TP"].ToString();
                con.FOLIO_TRANS = row["FOLIO_TRANS"].ToString();
                con.NEMO = row["NEMO"].ToString();
                con.RUT_CLI = row["RUT_CLI"].ToString();
                con.SEC_RUT_CLI = row["SEC_RUT_CLI"].ToString();
                con.RSO_RAZ_SOCIAL = row["RSO_RAZ_SOCIAL"].ToString();
                con.COD_AGENTE = row["COD_AGENTE"].ToString();
                con.CANTIDAD = row["CANTIDAD"].ToString();
                con.PRECIO = row["PRECIO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.MONTO = row["MONTO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.PRECIO_CONTADO = row["PRECIO_CONTADO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.MONTO_ACUM_VC = row["MONTO_ACUM_VC"].ToString();//.Replace(".","@").Replace(",",".").Replace("@", ",");
                con.TIPO_OPERAC = row["TIPO_OPERAC"].ToString();


              
               // con.COD_PER = row["COD_PER"].ToString();
                
                
               //con.SEC_MOVTO = row["SEC_MOVTO"].ToString();
               // con.CANTIDAD_ACUM_VC = row["CANTIDAD_ACUM_VC"].ToString();
               // con.COD_CORR_CONTRA = row["COD_CORR_CONTRA"].ToString();
               // con.COD_SUC = row["COD_SUC"].ToString();
               // con.FEC_LIQ_ANTICIP = row["FEC_LIQ_ANTICIP"].ToString();
               // con.FEC_LIQUID = row["FEC_LIQUID"].ToString();
                
               // con.FOLIO_COMP_ADJ = row["FOLIO_COMP_ADJ"].ToString();
                
               // con.IND_TIT_CUS = row["IND_TIT_CUS"].ToString();
               // con.INTERES_DIA = row["INTERES_DIA"].ToString();
               // con.LIN_COMP_ADJ = row["LIN_COMP_ADJ"].ToString();
               // con.SPREAD = row["SPREAD"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
               // con.TASA = row["TASA"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
               // con.TIPO_COMP_ADJ = row["TIPO_COMP_ADJ"].ToString();
               // con.IND_LIQUID = row["IND_LIQUID"].ToString();
               // con.IND_SIMUL = row["IND_SIMUL"].ToString();
               // //con.SEC_MOVTO_CTDO = row["SEC_MOVTO_CTDO "].ToString();

                listasimultaneas.Add(con);

            }

            return listasimultaneas;


        }


        public List<Simultaneas> ObtenerConsultaSimultaneas(string producto, string fecha, string cliente, string nOperacion, string estado)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-ES");

            List<Simultaneas> listasimultaneas = new List<Simultaneas>();

            String conexion_string = ConfigurationManager.ConnectionStrings["CadenaConexion"].ToString();
            DataTable dt = new DataTable();
            Conexion conect = new Conexion(conexion_string);
            if (fecha != "") {
                DateTime f = Convert.ToDateTime(fecha);
                int yyyy = f.Year;
                int dd = f.Day;
                string mm = f.ToString("MM");
                string fechaT = (yyyy + "-" + mm + "-" + dd).ToString();

                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = conect.agregaParametros("@producto", producto);
                parameters[1] = conect.agregaParametros("@fecha", fechaT);
                parameters[2] = conect.agregaParametros("@cliente", cliente);
                parameters[3] = conect.agregaParametros("@nOperacion", nOperacion);
                parameters[4] = conect.agregaParametros("@estado", estado);
                dt = conect.EjecutarSP_Parametros("SP_CO_SIM_CONSULTAR_OPERACIONES", parameters);
            }
            else {
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = conect.agregaParametros("@producto", producto);
                parameters[1] = conect.agregaParametros("@fecha", fecha);
                parameters[2] = conect.agregaParametros("@cliente", cliente);
                parameters[3] = conect.agregaParametros("@nOperacion", nOperacion);
                parameters[4] = conect.agregaParametros("@estado", estado);
                dt = conect.EjecutarSP_Parametros("SP_CO_SIM_CONSULTAR_OPERACIONES", parameters);
            }
            

            foreach (DataRow row in dt.Rows)
            {
                Simultaneas con = new Simultaneas();
                con.INDEXM = row["INDEXM"].ToString();
                con.FEC_TRANS = row["FEC_TRANS"].ToString();
                con.FEC_VCTO_TP = row["FEC_VCTO_TP"].ToString();
                con.FOLIO_TRANS = row["FOLIO_TRANS"].ToString();
                con.NEMO = row["NEMO"].ToString();
                con.RUT_CLI = row["RUT_CLI"].ToString();
                con.SEC_RUT_CLI = row["SEC_RUT_CLI"].ToString();
                con.RSO_RAZ_SOCIAL = row["RSO_RAZ_SOCIAL"].ToString();
                con.COD_AGENTE = row["COD_AGENTE"].ToString();
                con.CANTIDAD = row["CANTIDAD"].ToString();
                con.PRECIO = row["PRECIO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.MONTO = row["MONTO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.PRECIO_CONTADO = row["PRECIO_CONTADO"].ToString();//.Replace(".", "@").Replace(",", ".").Replace("@", ",");
                con.MONTO_ACUM_VC = row["MONTO_ACUM_VC"].ToString();//.Replace(".","@").Replace(",",".").Replace("@", ",");
                con.TIPO_OPERAC = row["TIPO_OPERAC"].ToString();
                con.ID_OP = row["ID_OP"].ToString();
                con.FECHA_CREACION = row["FECHA_CREACION"].ToString();

                /* con.NumeroOperacion = row["NumeroOperacion"].ToString();
                 con.RutCliente = row["RutCliente"].ToString();
                 con.NombreCliente = row["NombreCliente"].ToString();
                 con.FechaOperacion = row["FechaOperacion"].ToString();
                 //con.Monto = row["Monto"].ToString().Replace(".", "@").Replace(",", ".").Replace("@", ",");
                 con.FechaFirma = row["FechaFirma"].ToString();
                 con.NumeroDiasPendientes = row["NumeroDiasPendientes"].ToString();*/
                con.Estado = row["Estado"].ToString();

                listasimultaneas.Add(con);

            }

            return listasimultaneas;
        }

    }
}
