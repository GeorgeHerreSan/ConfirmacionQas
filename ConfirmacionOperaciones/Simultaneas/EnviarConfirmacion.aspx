<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnviarConfirmacion.aspx.cs" Inherits="Simultanea_EnviarConfirmacion" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1">
 <style type="text/css">
     td.Forms {
         white-space: nowrap;
     }

     .auto-style4 {
         width: 30%;
         height: 30px;
         border: 1px;
         font-size: small;
     }

     .auto-rest {
         width: 70%;
         border: 1px;
         font-size: small;
     }

     .autotable {
         text-align: center;
         border: 1px;
         margin-left: 100px;
         margin-right: 100px;
         margin-bottom: 20px;
         padding-bottom: 20px;
     }

     .fondofooter {
         width: 100%;
         font-size: 11px;
         color: #4e4e4e;
         background-color: #bebebe;
     }

     .texto {
         font-size: 13px;
         font: Arial;
     }

    .p {
         font-size: 10px;
         font: Arial;
     }

     .lab {
         font-size: 10px;
         font: Arial;
     }

     div {
         font-size: 12px;
         font: Arial;
     }

     .auto-style20 {
         border-style: none;
         border-color: inherit;
         border-width: 1px;
         width: 18%;
         font-size: small;
     }

     .auto-style21 {
         border-style: none;
         border-color: inherit;
         border-width: 1px;
         width: 18%;
         height: 30px;
     }

     .auto-style22 {
         border-style: none;
         border-color: inherit;
         border-width: 1px;
         width: 45%;
         height: 30px;
     }

     .auto-style23 {
         border-style: none;
         border-color: inherit;
         border-width: 1px;
         width: 40%;
         height: 30px;
     }
 </style>

<p style="text-align:right;" class="texto">Santiago,
    <asp:Label ID="lblFechaHoy" runat="server"></asp:Label>
&nbsp;</p>
<div class="texto">
<p><strong>Señores&nbsp;</strong></p>
<p><strong>Credicorp Capital S.A. Corredores de Bolsa</strong></p>
<p><u>Presente,</u></p>
<p>
  <br />
  <br />
</p>
<p style="text-align:right;"><u>REF: Operación de Compraventa a Plazo de Valores</u></p>
<p>
  <br />
</p>
<p>De mi consideración:&nbsp;</p>
<p>Por medio de la presente solicito a ustedes realizar la siguiente operación de compraventa a plazo de valores (“Simultánea”):</p>
<p>
  <br />
</p>
</div>
<table  cellspacing="1" cellpadding="3" border=1 style="width: 100%;  height:40px; border: 1px solid black;   border-collapse: collapse;text-align: center; font-size: 9px;">
  <tbody>
    <tr>
        <td ><strong>Folio</strong></td>
      <td >Fecha Inicio</td>
      <td>Instrumento</td>
      <td >Cantidad</td>
      <td >Precio PH</td>
      <td >Monto PH</td>
      <td >Fecha
        <br />Vencimiento
      </td>
     <!-- <td class="auto-style4">Operación
        <br />a Plazo
      </td>-->
      <td>Tasa
        <br />Financiamiento
      </td>
        <td>Comisión</td>
        <td>Operación a <br /> Plazo</td>
    </tr>
    <tr>
        <td>
          <asp:Label ID="lblFolio" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblFecha" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblIntrumento" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblCantidad" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblPrecioPH" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblMontoPH" runat="server"></asp:Label>
        <br />
      </td>
      <td>
          <asp:Label ID="lblFechaVen" runat="server"></asp:Label>
        <br />
      </td>
     <!-- <td class="auto-style4">
          <asp:Label ID="lblOpPlazo" runat="server"></asp:Label>
        <br />
      </td>-->
      <td>
          <asp:Label ID="lblTasaFinan" runat="server"></asp:Label>
        <br />
      </td>
         <td>
          <asp:Label ID="lblComision" runat="server"></asp:Label>
        <br />
      </td>
         <td>
          <asp:Label ID="lblOperacion" runat="server"></asp:Label>
        <br />
      </td>
    </tr>
  </tbody>
</table>
            
  <br />
<div class="texto">
<p>Asimismo, faculto expresamente a Credicorp Capital S.A. Corredores de Bolsa para constituir en garantía los valores que entrego en este acto con el objeto de respaldar la operación Simultánea, en los términos señalados en las Condiciones Generales de las Operaciones de Compraventa a Plazo de Valores suscrita con anterioridad a esta fecha, en el Reglamento y Manual de Operaciones en Acciones de la Bolsa de Valores respectiva y en las normas dictadas al respecto por la Comisión para el Mercado Financiero.</p>
  <br />
<p>Por último, declaro expresamente estar en conocimiento y aceptar desde ya, que en caso de incumplimiento de las obligaciones que asumo en virtud de esta operación simultánea, Credicorp Capital S.A. Corredores de Bolsa procederá a ejecutar las garantías constituidas en los términos establecidos en la normativa aplicable.</p>
  <br />
<p>Atentamente,</p>
    </div>
<table border="0" style="width: 100%;">
  <tbody>
    <tr>
      <td style="width: 15.0000%;">
        <br />
      </td>
      <td style="width: 15.0000%;">
        <br />
             <br /> <br /> <br /><br /> <br /><br /> <br /><br /><br /> <br />
      </td>
      <td style="width: 40.0000%; text-align:center; font-size: 15px;">_____________________________
        <br /><strong>
          <asp:Label ID="lblCliente" runat="server"></asp:Label>
          <br />
          <asp:Label ID="lblRutCliente" runat="server"></asp:Label>
          </strong>&nbsp;</td>
        
          <asp:Label ID="lblporcentaje" runat="server">&nbsp;<br />&nbsp;<br />&nbsp;<br /></asp:Label>
          
      <td style="width: 15.0000%;">
        <br />
      </td>
    </tr>
  </tbody>
</table>

    </form>

</body>

</html>