<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EnviarContratosForward.aspx.cs" Inherits="Forward_EnviarContratosForward" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1">

<html>
  <style>
  .texto{
    font-size: 11px;
  }
  .titulo{
    font-size: 12px;
  }
  .microtexto{
    font-size: 8px;
  }
      .auto-style1 {
          width: 100.0000%;
          height: 107px;
      }
      .auto-style2 {
          font-size: 11px;
          width: 100.0000%;
          height: 32px;
      }
  </style>
    <table style="width: 100%;">
  <tbody>
    <tr>
      <td style="width: 100.00%;">
        <div style="width: 70.00%; float:left;">&nbsp;</div>
        <div style="width: 30.00%; float:left;" class="texto"><asp:Label ID="lblfolio" runat="server"></asp:Label></div>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">
        <div style="text-align: center;" class="titulo"><br /><strong>CONTRATO FORWARDS Y SWAPS DE MONEDA</strong><br /></div>
      </td>
    </tr>
    <tr>
      <td class="auto-style2"><p>En Santiago de Chile, a <asp:Label ID="lblfechaoperacion" runat="server"></asp:Label>
&nbsp;entre Credicorp Capital S.A. Corredores de Bolsa representada por el o los apoderados más adelante individualizados, todos con domicilio en Apoquindo 3721 - Piso 9 en adelante "Credicorp Capital" y 
          <asp:Label ID="lblcliente" runat="server"></asp:Label>
          , Rut:<asp:Label ID="lblrutcliente" runat="server"></asp:Label>
&nbsp;con domicilio en 
          <asp:Label ID="lbldomiciliocliente" runat="server"></asp:Label>
          , en adelante el "Cliente", se conviene en el siguiente contrato:</p></td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><strong>OBJETO:</strong><br /></td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto"><p>El objeto de este contrato es, para cada una de las partes contratantes, precaverse de las fluctuaciones que presentan, considerando un valor respecto del otro, los valores del tipo de cambio del contrato y el 
          <asp:Label ID="lbltipodemoneda" runat="server"></asp:Label>
          , mediante el compromiso que asumen en este acto de hacerse pagos recíprocos. Los pagos recíprocos se determinarán por la obligación que asume una de las partes de efectuar el pago en pesos, equivalente a una determinada cantidad de dólares de acuerdo al tipo de cambio del contrato, y por la obligación que asume la otra de efectuar el pago en 
          <asp:Label ID="lblmonedanemo" runat="server"></asp:Label>
&nbsp;o en 
          <asp:Label ID="lblnombremoneda" runat="server"></asp:Label>
          .</p></td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><strong>DEFINICIONES:</strong><br /></td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div>Para todos los efectos de este contrato se aplicaran las siguientes definiciones:</div>
        <div><strong>a) Dólar:&nbsp;</strong>El Dólar moneda de los Estados Unidos de Norteamérica.</div>
        <div><strong>b)
            <asp:Label ID="lbltipodemoneda2" runat="server"></asp:Label>:</strong>&nbsp;
            <asp:Label ID="lblpaismoneda" runat="server"></asp:Label>.</div>
        <div><asp:Label ID="lbletra1" runat="server"></asp:Label></div>
        <div>
            <strong><asp:Label ID="lbletra2" runat="server"></asp:Label>&nbsp;Tipo de Cambio del Contrato:&nbsp;</strong>El tipo de&nbsp;cambio del dólar a que se refiere el N°6 DEL Capitulo I del Compendio de Normas de cambios&nbsp;Internacionales del Banco Central de Chile ("Dólar Observado"), correspondiente a las transacciones efectuadas por las empresas bancarias durante&nbsp;el día&nbsp;hábil bancario inmediatamente anterior al&nbsp;Día de&nbsp;Liquidación. En caso que el&nbsp;banco Central de Chile&nbsp;decida suprimir o&nbsp;modificar el Dólar observado, o crear&nbsp;nuevos tipos de cambio, para los&nbsp;efectos de&nbsp;este contrato, se empleará aquel tipo de cambio que lo reemplace.</div>
        <div>
            <strong><asp:Label ID="lbletra3" runat="server"></asp:Label>
            &nbsp;Día de Liquidación:&nbsp;</strong>Fecha de Vencimiento del contrato, en caso que dicho día no sea día hábil bancario, en la ciudad de Santiago, el día de liquidación será el siguiente día hábil bancario.</div>
     </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <br />
        <div style="width: 35.00%; float:left;">1 .- VENDEDOR</div>
        <div style="width: 65.00%; float:left;">:
            <asp:Label ID="lblvendedor" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">2 .- COMPRADOR</div>
        <div style="width: 65.00%; float:left;">:
            <asp:Label ID="lblcomprador" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">3 .- TIPO DE TRANSACCION</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lbltiptran" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">4 .- FECHA DE CIERRE</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblfechacierre" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">5 .- FECHA DE VENCIMIENTO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblfechavenc" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">6 .- MODALIDAD DE CUMPLIMIENTO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblmodalidad" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">7 .- CANTIDAD DE MONEDA COMPRADA</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblcantmoneda" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">8 .- TIPO DE CAMBIO FORWARD PACTADO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lbltipoforward" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">9 .- PARIDAD FORWARD PACTADO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblparidadforward" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">10.VALOR FORWARD PACTADO VENDIDO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblvalorpactado" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">11.TIPO DE CAMBIO DE REFERENCIA</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lbltipocambio" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">12.PARIDAD DE REFERENCIA</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lblparidadreferencia" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <div style="width: 35.00%; float:left;">13.LUGAR y FORMA DE CUMPLIMIENTO</div>
        <div style="width: 65.00%; float:left;">: 
            <asp:Label ID="lbllugarforma" runat="server"></asp:Label>
          </div>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><br /><strong>GASTOS:</strong><br /></td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto"><p>Todos los gastos, impuestos, derechos y desembolsos de cualquier naturaleza que se causaren con motivo del otorgamiento de este contrato, su aplicación y su cumplimiento, serán de cargo de cada una de las partes, en montos iguales.</p>
        <br />
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><strong>TERMINO ANTICIPADO:</strong><br />
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto"><p>Cualquiera de las partes podrá poner término anticipado a este contrato en caso de que la otra parte caiga en cesación de pagos o insolvencia. En tal evento la parte que pone término al contrato enviará una comunicación mediante carta certificada a la otra parte, y la liquidación y compensación se practicará dos días después de la fecha de entrega al Correo de la mencionada carta certificada. Para todos los efectos de este contrato ese día será considerado como día de liquidación.</p>
        <br />
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><strong>ARBITRAJE:</strong><br />
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto">
        <p>Cualquier dificultad o controversia que se suscite entre las partes por cualquier motivo o circunstancia, relacionados directa o indirectamente con este contrato, será resuelta en arbitraje ante un árbitro arbitrador o amigable componedor quien resolverá sin forma de juicio y sin ulterior recurso. El árbitro será nombrado de común acuerdo por las partes. A falta de acuerdo de la designación del árbitro la hará la Justicia Ordinaria, a requerimiento de cualquiera de las partes, pero en este caso el árbitro será de derecho, el procedimiento se sujetará a las normas del juicio sumario y las resoluciones que dicte el árbitro serán susceptible a todos los recursos legales.</p>
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="titulo"><strong>CESION DE DERECHOS:</strong><br />
      </td>
    </tr>
    <tr>
      <td style="width: 100.0000%;" class="texto"><p>Ni este contrato, ni los derechos que en él constan o que de él emanen, podrán cederse, endosarse ni transferirse por ninguna de las partes, salvo consentimiento por escrito de las partes, estampadas en los dos estampadas de este contrato.</p>
        <br />
      </td>
    </tr>
  </tbody>
</table>
    <div style="height:70px;"></div>  
         <div style="width: 100.00%;" class="microtexto">
          <div style="width: 25.00%; float:left;">
            <br /><br /><br /><br />
          </div>
          <div style="width: 25.00%;  float:left;">
            <br /><br /><br /><br />
          </div>
          <div style="width: 50.00%;">
            &nbsp;
          </div>
        </div>

        <table style="width: 100.00%;" class="texto">
            <tr>
                <td style="width: 50.00%;" class="texto"><center><asp:Label ID="lblCredicorp" runat="server"></asp:Label></center></td>
                <td style="width: 50.00%;" class="texto"><center>
                    <asp:Label ID="lblcliente2" runat="server"></asp:Label>
                    </center></td>
            </tr>
        </table>

</html>
        </form>
</body>
</html>
