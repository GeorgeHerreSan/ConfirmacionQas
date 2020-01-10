<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnviarConfirmacionBlotter.aspx.cs" Inherits="Forward_EnviarConfirmacionBlotter" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style4 {
            width: 30%;
            height:30px;
            border: 1px;
            font-size:small;
        }
        .auto-style5 {
            width: 30%;
            border: 1px;
        }
        .auto-rest{
            width: 70%;
            border: 1px;
            font-size:small;
        }
        .auto-style10 {
            width: 222px;
            height: 28px;
        }
        .autotable{
            text-align: center; border: 1px ; margin-left: 100px; margin-right:100px; margin-bottom:20px; padding-bottom:20px;
        }
        .auto-style12 {
            border-style: none;
            border-color: inherit;
            border-width: 1px;
            width: 30%;
            height: 40px;
        }
        .auto-style13 {
            border-style: none;
            border-color: inherit;
            border-width: 1px;
            width: 70%;
            height: 40px;
        }
        .auto-style15 {
            height: 86px;
        }
        .auto-style16 {
            height: 36px;
        }
        .auto-style17 {
            text-align: left;
            font-size:small;
        }
        .auto-style18 {
            color: #0066FF;
            text-decoration: underline;
        }
        .fondofooter{
            width: 100%;
            font-size: 11px;
            color: #4e4e4e;
            background-color: #bebebe;
        }
        </style>
</head>
<body>
<div style="width: 100%;top:0px;">

    <form id="form1" style="top:0px;">
        <asp:Panel ID="Panel1" runat="server">

        <div id="divcontenido" runat="server" style="height:auto; margin-left:100px; margin-right:100px;top:0px;">

            <table style="text-align: left; width: 100%;">
                    <tr>
                        <td style="padding-bottom:30px;" class="auto-style16">
                            <b>CONFIRMACION </b><br/>
                            DE OPERACION A FUTURO EN MONEDA EXTRANJERA<br/><br/>
                        <b>NÚMERO DE OPERACIÓN: &nbsp; <asp:Label ID="LblNumeroOP" runat="server"></asp:Label></b>
                        </td>
                    </tr>
            </table>

        <table style="width:100%;border-collapse:collapse;">
            <tr>
                <td class="auto-style4">Fecha</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblFechaInicio" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style4">UF</td>
                <td class="auto-rest">
                    <asp:Label ID="lblUF" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Precio Rerencial de Mercado</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblPrecioReferencialMercado" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Vendedor</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblVendedor" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Operador</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblOperadorI" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Comprador</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblComprador" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Operador</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblOperadorII" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Tipo Operación</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblTipoOperacion" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Monto</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblMonto" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Tasa</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblTasa" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Precio Futuro</td>
                <td class="auto-rest" >
                    <asp:Label ID="lblPrecioFuturo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Monto Final</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblMontoFinal" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Plazo</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblPlazo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Fecha Vencimiento</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblFechaVencimiento" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Modalidad de Pago</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblModalidadPago" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Fecha Valuta</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblFechaValuta" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Valor Referencial de Salida</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblValorReferencialSalida" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style4" >Fixing</td>
                <td class="auto-rest"  >
                    <asp:Label ID="lblFixing" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
            <br /><br /><br /><br /><br />

     <div class="fondofooter">
         <p>En señal de conformidad a las condiciones en el adjunto señaladas, que corresponde al cierre de operación vía telefónica, agradecemos presionar el
            <b>botón confirmar</b> incluidos en el cuerpo del correo o enviar copia firmada de esta confirmación a la siguiente casilla electrónica: <br />
            <u>confirmacioneschile@credicorpcapital.com</u>
             <br /><br />
            En caso de disconformidad agradecemos marcar una de las opciones en la sección <b>Rechazos</b>, si estas no se ajustan, favor marcar opción otros y será
            contactado por nuestra área de operaciones financieras.
         </p>
        <p>
            <br />
            <table style="width:100%; font-size:11px;">
                <tr>
                    <td style="width:50%; text-align:left;">
                        Departamento de Operaciones Financieras <br />
                        <b>CREDICORPCAPITAL S.A.</b> <br />
                        Corredores de Bolsa
                    </td>
                    <td style="width:50%; text-align:center;">
                        <asp:Label ID="lblNombreEmpresaFirma" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
        </p>
    </div>
             </asp:Panel>
    </form>


</div>

   </body>
</html>