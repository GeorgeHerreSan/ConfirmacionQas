<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PaginaError.aspx.cs" Inherits="PaginaError" %>
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
  
 

  <script src="js/jquery.alerts.js"></script>
  <link href="Css/jquery.alerts.css" rel="stylesheet" />
    
  <script>
      function alertausuario() {
          jAlert("Usuario sin privilegios para acceder.","Error");
      }

  </script>

    <link href="Css/Estilos.css" rel="stylesheet" />
  
    <%--grilla--%>
    <link rel="stylesheet" type="text/css" href="css/ui.jqgrid.css" /> 


</head>
 
<body onload="alertausuario();">
 <form id="form2" runat="server">
    <input type="hidden" id="idProductoHidden" />  
    <input type="hidden" id="Hidden1" runat="server" />
<div id="divHead" >
</div>

  <div id="contenidoweb">
    <div id="barrasuperior">
        <!-- <table id="login">
            <tr><td><img src="img/user.png" alt="Usuario logueado" id="imguser"></td>
            <td><p id="login">Usuario: SANTIAGO/francisco.bravo</p></td></td></tr>
        </table> -->
        <div id="login">
                <div id="contimguser"><img src="img/user.png" alt="Usuario logueado" id="imguser"></div>
                <div id="infouser"><label id="NombreUsuario" runat="server"></label></div>
        </div>
  </div>


<div id="divMenuIzquierdo">
    <img src="img/logo-credicorp.png" id="logoimagen">
<nav class="menu">

    <nav class="drop-down-menu tamaniomenu" >
      <input type="checkbox" class="activate" id="accordion-2" name="accordion-2"/>
      <label for="accordion-2" class="menu-title" id="divlblfwd">Forward</label>
      
    <div class="drop-down">
        <a href="#" >Envío de Operaciones SEBRA</a>
        <a href="#" >Envío de Operaciones BLOTTER</a>
        <a href="#" >Reenvío de Operaciones</a>
        <a href="#" >Consultar Operaciones Enviadas</a>
        <a href="#" >Envío de Aviso Vencimiento</a>
        <a href="#" >Consultar Envío Aviso Venc.</a>      
    </div>
    </nav>

    <nav class="drop-down-menu tamaniomenu" >
      <input type="checkbox" class="activate" id="accordion-2" name="accordion-2"/>
      <label for="accordion-2" class="menu-title" id="divlblfwd">Forward</label>
      
    <div class="drop-down">
        <a href="#" >Envío de Operaciones</a>
        <a href="#" >Reenvio</a>      
    </div>
    </nav>

   
    <nav class="drop-down-menu tamaniomenu">
      <input type="checkbox" class="activate" id="accordion-3" name="accordion-3"/>
      <label for="accordion-3" class="menu-title">Mantenedores</label>
      
      <div class="drop-down">
        <a href="#">Mantenedor de Correos</a>
        <a href="#">Administrador Lista de Distribución</a>
      </div>
    </nav>

    <%--<a class="last" href="#">Otros</a>--%>
  </nav>
</div>
    <div id="colorfondomenu"></div>
      

<hr class="elhr suphr"/>
      <center><h1>Usuario sin privilegios</h1></center>
      <div id="divContenido"></div>


    <div id="ajustadorGrilla" class="grilla">
        <div id="divGrilla">
        <table id='list'></table>
        <div id="jqGridPager"></div>
        </div>
     </div>
    <div id="divBotones"> 
    </div>
        <%--<div id="divSeleccionarTodos" style="display:none;">Seleccionar Todos <input type="checkbox" id="chkSeleccionarTodosSimultaneas" /></div> --%>

</div>

<div id="divFooter">
      Confirmación de Operaciones - Área de Operaciones Financieras
  </div>

<div id="DivPreload" style="display:none;">
      <img src="Img/preloader.gif" id="imgPreload" style="margin-left: auto;
           margin-right: auto;margin-top:230px;
           display: block;" />
  </div>

     </form>


</body>
</html>