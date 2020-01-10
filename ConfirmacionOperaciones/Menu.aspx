<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8"/>
  <meta name="viewport" content="width=device-width, initial-scale=1"/>
  <title>Confirmación de Operaciones - Credicorp Capital</title>
  
  <link href="Css/jquery-ui.css" rel="stylesheet" />
  <%--<script src="js/jquery-1.12.4.js"></script>--%>
  <script src="js/jquery-1.7.2.min.js"></script>

  <script src="js/jquery-ui.js"></script>
  
  <%-- <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>--%>
  <%--<link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">--%>
  <%-- <link rel="stylesheet" href="/resources/demos/style.css">--%>
  <%--<script src="https://code.jquery.com/jquery-1.12.4.js"></script>--%>
  
   <%-- <script src="js/jquery.min.js"></script>--%>

  <script>
     $( function() {
    $( "#tabs" ).tabs();
      });
      //seteo de formato para calendarios
      $.datepicker.regional['es'] = {
         closeText: 'Cerrar',
         prevText: '< Ant',
         nextText: 'Sig >',
         currentText: 'Hoy',
         monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
         monthNamesShort: ['Ene','Feb','Mar','Abr', 'May','Jun','Jul','Ago','Sep', 'Oct','Nov','Dic'],
         dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
         dayNamesShort: ['Dom','Lun','Mar','Mié','Juv','Vie','Sáb'],
         dayNamesMin: ['Do','Lu','Ma','Mi','Ju','Vi','Sá'],
         weekHeader: 'Sm',
         dateFormat: 'dd-mm-yy',
         firstDay: 1,
         isRTL: false,
         showMonthAfterYear: false,
         yearSuffix: ''
         };
      $.datepicker.setDefaults($.datepicker.regional['es']);

      $( function () {
         $( "#datepicker1" ).datepicker();
      });
      $( function() {
         $( "#datepicker2" ).datepicker();
      });
      $( function() {
         $( "#datepicker3" ).datepicker();
      });


      $( function() {
    var availableTags = [
      "11111111-1",
      "22222222-2",
      "33333333-3",
      "44444444-4",
      "55555555-5",
      "66666666-6",
      "77777777-7",
      "88888888-8",
      "99999999-9"
    ];
    $( "#txtBuscarClientesMantenedor" ).autocomplete({
      source: availableTags
      });

    $( "#txtClienteTabs2" ).autocomplete({
      source: availableTags
      });

    $( "#txtBuscarClientesConsultar" ).autocomplete({
      source: availableTags
          });

 $( "#txtBuscarClientesContratos" ).autocomplete({
      source: availableTags
      });




  } );     
      function BuscarCorreos() {
        $('#divEditarCorreo').hide("slow");
        $('#divNuevoCorreo').hide("slow");
        $('#divListaCorreos').show("slow");
      }
      function nuevoCorreo() {
          $('#divEditarCorreo').hide("slow");
          $('#divNuevoCorreo').show("slow");
      }
      function GuardarNuevoCorreo() {
           $('#divNuevoCorreo').hide("slow");
      }
      function CancelarNuevoCorreo() {
          $('#divNuevoCorreo').hide("slow");

      }
      function GuardarEdicionCorreo() {
           $('#divEditarCorreo').hide("slow");
      }
      function CancelarEdicionCorreo() {
          $('#divEditarCorreo').hide("slow");

      }
      function EdicionCorreo(idMail) {

          $('#divNuevoCorreo').hide("slow");
          $('#divEditarCorreo').show("slow");
      }
      function BuscarListaDistribucion() {
        $('#divListaDistribucion').show("slow");
      }
      function BuscarOpracionesDia() {
         $('#divOperacionesDelDia').show("slow");
      }
      function BuscarOpracionesDiasAnteriores() {
        $('#divConsultaOperaciones').show("slow");
      }
      function VerDetalleEnvio() {
          //$('#divDetalleEnvio').show("slow");
          $('#divDetalleEnvio').dialog({ width: 623, title: "Detalle Envío"  }); 

      }
      function RevisarCambiosCorreos()
      {
          AgregarFilasTabla();
          $("a[href='#tabs2']").trigger('click');
          BuscarListaDistribucion();
          document.getElementById("txtClienteTabs2").value = "11.111.111-1"
      }
      function AgregarFilasTabla(nombreTabla) {

            var tds=$("#tblListaDistribucion tr:first td").length;
            var trs=$("#tblListaDistribucion tr").length;
            var nuevaFila="<tr style='color:#a5bc00;'>";
            //for(var i=0;i<tds;i++){
            nuevaFila += "<td>nuevocorreo@gmail.com</td>";
            nuevaFila += "<td><input type='checkbox'/></td>";
            nuevaFila += "<td><input type='checkbox'/></td>";
            
            //}
          
            //nuevaFila+="<td>"+(trs+1)+" filas";
            nuevaFila+="</tr>";
            $("#tblListaDistribucion").append(nuevaFila);

          tab=document.getElementById('tblListaDistribucion');
          //tab.getElementsByTagName('tr')[3].style.background = '#d40000';
          tab.getElementsByTagName('tr')[3].style.color = '#d40000';
          document.getElementById('divLeyendaCorreos').style.display = 'block';

          //bloquear elemento borrado.
          $("#chk2").attr('disabled', !$("#chk2").attr('disabled'));
          $("#chk1").attr('disabled', !$("#chk1").attr('disabled'));

      }



  </script>

       
    
    

    <%--alertas--%> 
    <script type="text/javascript" >
$(document).ready(function()
{
$("#notificationLink").click(function()
{
$("#notificationContainer").fadeToggle(300);
$("#notification_count").fadeOut("slow");
return false;
});

//Document Click
$(document).click(function()
{
$("#notificationContainer").hide();
});
//Popup Click
$("#notificationContainer").click(function()
{
return false
});

});
</script>
    

    <link href="Css/Estilos.css" rel="stylesheet" />
  
    <%--grilla contratos--%>
    <link rel="stylesheet" type="text/css" href="css/ui.jqgrid.css" /> 

    <script src="js/grid.locale-es.js" type="text/javascript"></script> 
    <script src="js/jquery.jqGrid.min.js" type="text/javascript"></script> 
    <script src="js/jsAcciones.js"></script>


</head>
<body>
 
<div id="tabs">
  <ul>
    <li id="liSimultaneas" runat="server"><a href="#DivSimultaneas">Simultaneas</a></li>
    <li id="liForward" runat="server"><a href="#tabs3">Forward</a></li>
    <li id="liPactos" runat="server"><a href="#tabs3">Pactos</a></li>

    <li id="liListaDistribucion" runat="server"><a href="#tabs2">Lista de Distribución</a></li>
    <li id="liMantenedorCorreos" runat="server"><a href="#tabs1">Mantenedor de Correos</a></li>
    <li id="liContratos" runat="server"><a href="#tabs5">Mantenedor de Contratos</a></li>
  </ul>

  <%--Confirmacion de Operaciones--%>

  <div id="DivSimultaneas" style="height:580px !important;" runat="server">
      <div class="divContenedor">
      <table style="padding-bottom:20px;">
          <tr style="background-color:white;">
              <td>Búsqueda</td>
              <td><input type="text" placeholder="Fecha" id="datepickerSimultaneas" style="width: 66px;height: 15px;"/></td>
              <td><input type="text" placeholder="Cliente" id="txtBuscarClientesSimultaneas" style="height: 15px;" /></td>
              <td><input type="text" placeholder="N° Operación" id="txtBuscarNumOperacionSimultaneas" style="height:15px;" /></td>
              <td><input type="button" class="botones"  value="Buscar" onclick="obtieneJsonContratos();" /></td>
              <td><input type="button" class="botones"  value="Cargar Op.día" <%--onclick="obtieneJsonContratos();"--%> /></td> 
              </tr>
      </table>
      <table id='listSimultaneas'></table>
      <div id="jqGridPagerSimultaneas"></div>
           <br />
       
        <input type="button" id="exportSimultaneas" style="display:none;width:120px !important" onclick="exportar()" class="botones" value="Exportar a Excel" /> 
    
       <%-- <div id="DivPreload" style="display:none;"><img src="Img/preloader.gif" id="imgPreload" /></div>--%>
     

     </div>
  </div>


  <div id="tabs1" runat="server" style="height:580px !important;">
      <div class="divContenedor">
      <table style="padding-bottom:20px;">
          <tr style="background-color:white!important;">
              <td>Búsqueda</td>
              <td><input type="text" placeholder="Cliente" style="height:15px;" id="txtBuscarClientesMantenedor" /></td>
              <td><input type="button" class="botones"  value="Buscar" onclick="BuscarCorreos();" /></td>
          </tr>
      </table>
      <div id="divListaCorreos" style="display:none;">
      <table style="border:1px solid #dddddd;width:600px;text-align:center;">
           <tr style="background-color:#758b8b!important; color:white!important;height:25px;">
              <td style="width:480px;">
                  Mail
              </td>
              <td style="width:60px;">
                  Editar
              </td>
              <td style="width:60px;">
                  Eliminar
              </td>
          </tr>
           <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <img src="img/edit.png" style="width:19px;height:16px;" onclick="EdicionCorreo();" />
              </td>
               <td>
                  <img src="img/boton-eliminar-png-1.png" style="width:19px;height:16px;" />
                 <%--<input type="button"  value="Eliminar" />--%>
              </td>

          </tr>
             <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <img src="img/edit.png" style="width:19px;height:16px;" onclick="EdicionCorreo();" />
              </td>
               <td>
                  <img src="img/boton-eliminar-png-1.png" style="width:19px;height:16px;" />
                 <%--<input type="button"  value="Eliminar" />--%>
              </td>

          </tr>
             <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <img src="img/edit.png" style="width:19px;height:16px;" onclick="EdicionCorreo();" />
              </td>
               <td>
                  <img src="img/boton-eliminar-png-1.png" style="width:19px;height:16px;" />
                 <%--<input type="button"  value="Eliminar" />--%>
              </td>

          </tr>
      </table>
      <div style="padding-top:5px;"><input type="button" class="botones" value="Nuevo" onclick="nuevoCorreo();" /></div>
      
      <div id="divNuevoCorreo" style="padding-top:5px;display:none;">
          <table style="border:1px solid #dddddd;width:317px;">
               <tr style="background-color:#758b8b!important; color:white!important;height:25px;">
                  <td colspan="2" style="width:100px;">Nuevo registro</td>
                  
              </tr>
              <tr>
                  <td style="width:100px;">Nombre</td>
                  <td><input type="text" style="width:200px;"/></td>
              </tr>
              <tr>
                  <td>Mail</td>
                  <td><input type="text" style="width:200px;" /></td>
              </tr>
                <tr><td></td>
                  <td> <input type="button" value="Guardar" class="botones" onclick="GuardarNuevoCorreo();" />
                                   <input type="button" class="botones" value="Cancelar" onclick="CancelarNuevoCorreo();" />  
                  </td>                
              </tr>
          </table>
      </div>
      <div id="divEditarCorreo" style="padding-top:5px;display:none;">
          <table style="border:1px solid #dddddd;width:317px;">
              <tr style="background-color:#758b8b!important; color:white!important;height:25px;">
                  <td colspan="2" style="width:100px;">Editar registro</td>
                  
              </tr>
              <tr>
                  <td style="width:100px;">Nombre</td>
                  <td><input type="text" style="width:200px;"/></td>
              </tr>
              <tr>
                  <td>Mail</td>
                  <td><input type="text" style="width:200px;" /></td>
              </tr>
                <tr><td></td>
                  <td> <input type="button" class="botones" value="Guardar" onclick="GuardarEdicionCorreo();" />
                                   <input type="button" class="botones" value="Cancelar" onclick="CancelarEdicionCorreo();" />  
                  </td>                
              </tr>
          </table>
      </div>
      </div>

     </div>
  </div>
  <div id="tabs2" runat="server"  style="height:580px !important;">
     <div class="divContenedor">
     <table style="padding-bottom:20px;">
          <tr style="background-color:white;">
              <td>Búsqueda</td>
              <td><input type="text" id="txtClienteTabs2" placeholder="Cliente" style="height:15px;" /></td>
              <td><select style="height:21px;">
                  <option value="0">Seleccione Producto</option>
                  <option value="1">Pactos</option>
                  <option value="2">Simultáneas</option>
              </select> 

              </td>
              <td><input type="button" class="botones"  value="Buscar" onclick="BuscarListaDistribucion();" /></td>
          </tr>
      </table>
     <div id="divListaDistribucion" style="display:none;">
      <table id="tblListaDistribucion" style="border:1px solid #dddddd;width:600px;text-align:center;">
           <tr style="background-color:#758b8b!important; color:white!important;height:25px;">
              <td style="width:480px;">
                  Mail
              </td>
              <td style="width:60px;">
                  Incluir
              </td>
              <td style="width:60px;">
                  Apoderado
              </td>

          </tr>
           <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <input type="checkbox" checked="checked"/>
              </td>
               <td>
                 <input type="checkbox" checked="checked" />
              </td>

          </tr>
           <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <input type="checkbox"  checked="checked" />
              </td>
               <td>
                 <input type="checkbox" />
              </td>

          </tr>
           <tr>
              <td>
                  pruebaCredicorp@credicorp.cl
              </td>
              <td>
                  <input type="checkbox" id="chk1" />
              </td>
               <td>
                 <input type="checkbox" id="chk2" />
              </td>

          </tr>
      </table>
      <div style="padding-top:5px;"><input type="button" class="botones" value="Guardar" onclick="GuardarListaDistribucion();" /></div>
      
     
     
      </div>
     <div id="divLeyendaCorreos" style="display:none;
                                                        position: absolute;
                                                        float: right;
                                                        padding-left: 610px;
                                                        z-index: 100;
                                                        top: 106px;">
          <div style="width:20px;height:20px;background-color:#a5bc00"> <a style="margin-left:25px;">Nuevo</a> </div>
          <div style="width:20px;height:20px;background-color:#d40000"> <a style="margin-left:25px;">Eliminado</a></div>

      </div>
    </div>
  
  </div>


  
  <%-- Mantenedor de Contratos--%>
  <div id="tabs5" style="height:580px !important;" runat="server">
      <div class="divContenedor">
      <table style="padding-bottom:20px;">
          <tr style="background-color:white;">
              <td>Búsqueda</td>
              <td><select id="selectProductos" style="height:21px;" >
                  <option value="0">Seleccione Producto</option>
                  <option value="1">Forwards</option>
                  <option value="2">Pactos</option>
                  <option value="3">Simultáneas</option>
              </select> 
              </td>
              <td><input type="text" placeholder="Fecha" id="datepicker3" style="width: 66px;height: 15px;"/></td>
              <td><input type="text" placeholder="Cliente" id="txtBuscarClientesContratos" style="height: 15px;" /></td>
              <td><input type="text" placeholder="N° Operación" id="txtBuscarNumOperacionContratos" style="height:15px;" /></td>
              <td><input type="button" class="botones"  value="Buscar" onclick="obtieneJsonContratos();" /></td>
              <td><input type="button" class="botones"  value="Cargar Op.día" <%--onclick="obtieneJsonContratos();"--%> /></td> 
              </tr>
      </table>
      <table id='list'></table>
      <div id="jqGridPager"></div>
           <br />
       
        <input type="button" id="export" style="display:none;width:120px !important" onclick="exportar()" class="botones" value="Exportar a Excel" /> 
    
        <div id="DivPreload" style="display:none;"><img src="Img/preloader.gif" id="imgPreload" /></div>
     

     </div>
  </div>
 
  <div id="divUsuario" runat="server"  style="position: absolute; right: 119px;z-index:100;top:13px;">
   <a>Usuario:</a> <label id="NombreUsuario" runat="server"></label>
   <input type="hidden" id="tipoUsuario" runat="server" />    
  </div> 
  <div id="divAlertas" runat="server" style="position: absolute; right: 119px;z-index:100;top:13px;">
    <ul id="nav">

    <li id="notification_li">
    <span id="notification_count">6</span>
    <a href="#" id="notificationLink">Notificaciones</a>
    <div id="notificationContainer">
    <div id="notificationTitle">Alertas</div>
    <div id="notificationsBody" class="notifications">
        <div class="Notificaciones" onclick="RevisarCambiosCorreos();">Modificaciones de correo <br /> 
                                    Cliente:11.111.111-1
        </div>
        <div class="Notificaciones">Modificaciones de correo <br /> 
                                    Cliente:22.222.222-2
        </div>
        <div class="Notificaciones">Modificaciones de correo <br /> 
                                    Cliente:33.333.333-3
        </div>
        <div class="Notificaciones">Modificaciones de correo <br /> 
                                    Cliente:11.111.111-1
        </div>
        <div class="Notificaciones">Modificaciones de correo <br /> 
                                    Cliente:22.222.222-2
        </div>
        <div class="Notificaciones">Modificaciones de correo <br /> 
                                    Cliente:33.333.333-3
        </div>
       
        
    </div>
    <div id="notificationFooter"><a href="#">See All</a></div>
    </div>
    </li>
    </ul>

    </div>

  <table id="tablaExp" style="display:none;">
            <tr style="background-color:#E4EFEF;color:#666666">
                <td>Numero Operacion</td>
                <td>Rut Cliente</td>
                <td>Nombre Cliente</td>
                <td>Fecha Operacion</td>
                <td>Monto</td>
                <td>Fecha Firma</td>
                <td>Num.dias pendientes</td>
                <td>Estado Contrato</td>
            </tr>
        </table>

</div>

</body>
</html>

