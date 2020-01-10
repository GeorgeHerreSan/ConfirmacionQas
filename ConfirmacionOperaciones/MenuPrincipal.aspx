<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MenuPrincipal.aspx.cs" Inherits="Menu" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>Confirmación de Operaciones - Credicorp Capital</title>

    <link href="Css/jquery-ui.css" rel="stylesheet" />
    <%--<script src="js/jquery-1.12.4.js"></script>--%>
    <script src="js/jquery-1.7.2.min.js"></script>
    <script src="js/jquery-ui.js"></script>



    <script src="js/jquery.alerts.js"></script>
    <link href="Css/jquery.alerts.css" rel="stylesheet" />

    <script>
        $(function () {
            $("#tabs").tabs();
        });
        //seteo de formato para calendarios
        $.datepicker.regional['es'] = {
            closeText: 'Cerrar',
            prevText: '< Ant',
            nextText: 'Sig >',
            currentText: 'Hoy',
            monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
            monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
            dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
            dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
            dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
            weekHeader: 'Sm',
            dateFormat: 'dd-mm-yy',
            firstDay: 1,
            isRTL: false,
            showMonthAfterYear: false,
            yearSuffix: ''
        };
        $.datepicker.setDefaults($.datepicker.regional['es']);

        //simultaneas
        $(function () {
            $("#datepickerSimultaneaEnvio").datepicker();
        });
        
        $(function () {
            $("#datepickerSimultaneasConsulta").datepicker();
        });
        $(function () {
            $("#datepickerSimultaneasReenvio").datepicker();
        });


        //forward
        $( function() {
            $("#datepickerForwardConsulta").datepicker();
        });
        $( function() {
            $("#datepickerForwardOpDia").datepicker();
        });
        $( function() {
            $("#datepickerContratoForwardOpDia").datepicker();
        });
        $( function() {
            $("#datepickerForwardConsultaContratos").datepicker();
        });


        //blotter
        $(function () {
            $("#datepickerBlotter").datepicker();
        });

        //consultar aviso vencimiento
        $(function () {
            $("#datepickerForwardConsultaVencimiento").datepicker();
        });



        $(function () {
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
            $("#txtBuscarClientesMantenedor").autocomplete({
                source: availableTags
            });

            $("#txtClienteTabs2").autocomplete({
                source: availableTags
            });

            $("#txtBuscarClientesConsultar").autocomplete({
                source: availableTags
            });

            $("#txtBuscarClientesContratos").autocomplete({
                source: availableTags
            });



            $("#chkSeleccionarTodosSimultaneas").click(

                function () {
                    alert("aqui");
                    var grid = $("#list");
                    grid.jqGrid('setSelection', 25, true);

                    //var marcado = $("#chkSeleccionarTodosSimultaneas").is(":checked");

                    //if(!marcado)
                    //	$("#List :checkbox").attr('checked',true);
                    //else
                    //	$("#List :checkbox").attr('hecked', false);
                }
            );


        });
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
            $('#divDetalleEnvio').dialog({ width: 623, title: "Detalle Envío" });

        }
        function RevisarCambiosCorreos() {
            AgregarFilasTabla();
            $("a[href='#tabs2']").trigger('click');
            BuscarListaDistribucion();
            document.getElementById("txtClienteTabs2").value = "11.111.111-1"
        }
        function AgregarFilasTabla(nombreTabla) {

            var tds = $("#tblListaDistribucion tr:first td").length;
            var trs = $("#tblListaDistribucion tr").length;
            var nuevaFila = "<tr style='color:#a5bc00;'>";
            //for(var i=0;i<tds;i++){
            nuevaFila += "<td>nuevocorreo@gmail.com</td>";
            nuevaFila += "<td><input type='checkbox'/></td>";
            nuevaFila += "<td><input type='checkbox'/></td>";

            //}

            //nuevaFila+="<td>"+(trs+1)+" filas";
            nuevaFila += "</tr>";
            $("#tblListaDistribucion").append(nuevaFila);

            tab = document.getElementById('tblListaDistribucion');
            //tab.getElementsByTagName('tr')[3].style.background = '#d40000';
            tab.getElementsByTagName('tr')[3].style.color = '#d40000';
            document.getElementById('divLeyendaCorreos').style.display = 'block';

            //bloquear elemento borrado.
            $("#chk2").attr('disabled', !$("#chk2").attr('disabled'));
            $("#chk1").attr('disabled', !$("#chk1").attr('disabled'));

        }



    </script>





    <%--alertas--%>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#notificationLink").click(function () {
                $("#notificationContainer").fadeToggle(300);
                $("#notification_count").fadeOut("slow");
                return false;
            });

            //Document Click
            $(document).click(function () {
                $("#notificationContainer").hide();
            });
            //Popup Click
            $("#notificationContainer").click(function () {
                return false
            });

        });
    </script>


    <link href="Css/Estilos.css" rel="stylesheet" />

    <%--grilla--%>
    <link rel="stylesheet" type="text/css" href="css/ui.jqgrid.css" />

    <script src="js/grid.locale-es.js" type="text/javascript"></script>
    <script src="js/jquery.jqGrid.min.js" type="text/javascript"></script>
    <script src="js/jsAcciones.js"></script>


</head>

<body>
    <form id="form1" runat="server">
        <input type="hidden" id="idProductoHidden" />
        <input type="hidden" id="jSonBlotter" runat="server" />
        <div id="divHead">
        </div>

        <div id="contenidoweb">
            <div id="barrasuperior">
                <!-- <table id="login">
            <tr><td><img src="img/user.png" alt="Usuario logueado" id="imguser"></td>
            <td><p id="login">Usuario: SANTIAGO/francisco.bravo</p></td></td></tr>
        </table> -->
                <div id="login">
                    <div id="contimguser">
                        <img src="img/user.png" alt="Usuario logueado" id="imguser"></div>
                    <div id="infouser">
                        <label id="NombreUsuario" runat="server"></label>
                    </div>
                </div>
            </div>


            <div id="divMenuIzquierdo">
                <img src="img/logo-credicorp.png" id="logoimagen">
                <nav class="menu">

                    <nav class="drop-down-menu" id="navSimultaneas" runat="server">
                    </nav>


                    <nav class="drop-down-menu tamaniomenu">
                        <input type="checkbox" class="activate" id="accordion-1" name="accordion-1" />
                        <label for="accordion-1" class="menu-title" id="divlblfwzd">Forward</label>

                        <div class="drop-down">
                            <a href="#" onclick="verfuncionalidad('DivForwardOpDia');">Envío de Operaciones SEBRA</a>
                            <a href="#" onclick="verfuncionalidad('DivForwardBlotter');">Envío de Operaciones BLOTTER</a>
                            <a href="#" onclick="verfuncionalidad('DivReenvioForward');">Reenvío de Operaciones</a>
                            <a href="#" onclick="verfuncionalidad('DivForwardConsultar');">Consultar Operaciones Enviadas</a>
                            <a href="#" onclick="verfuncionalidad('DivForwardVencimiento');">Envío de Aviso Vencimiento</a>
                            <a href="#" onclick="verfuncionalidad('DivForwardConsultarVencimientos');">Consultar Envío Aviso Venc.</a>
                            <a href="#" onclick="verfuncionalidad('DivContratosForwardConsultarDia');">Envío Masivo de Contratos</a>
                        </div>
                    </nav>
                    <nav class="drop-down-menu tamaniomenu">
                        <input type="checkbox" class="activate" id="accordion-2" name="accordion-2" />
                        <label for="accordion-2" class="menu-title" id="divlblfwd">Simultaneas</label>

                        <div class="drop-down">
                            <a href="#" onclick="verfuncionalidad('DivSimultaneaEnvio');">Envío y Re-envío de Operaciones</a>
                            <!--<a href="#" onclick="verfuncionalidad('DivSimultaneaRMasivo');">Re-Envío Masivo</a>-->
                            <a href="#" onclick="verfuncionalidad('DivSimultaneaConsulta');">Consulta de Operaciones y Reportería</a>

                        </div>
                    </nav>

                    <nav class="drop-down-menu tamaniomenu">
                        <input type="checkbox" class="activate" id="accordion-3" name="accordion-3" />
                        <label for="accordion-3" class="menu-title">Mantenedores</label>

                        <div class="drop-down">
                          <a href="#" onclick="verfuncionalidad('DivMantenedorDeCorreos');">Mantenedor de Correos</a>
                          <a href="#" onclick="verfuncionalidad('DivListaDistribucion');">Lista de Distribución</a>
                      </div>
                    </nav>

                    <%--<a class="last" href="#">Otros</a>--%>
                </nav>
            </div>
            <div id="colorfondomenu"></div>


            <hr class="elhr suphr" />

            <div id="divContenido">
                <%--Forward--%>
                <div id="DivForwardOpDia" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Envío Manual de Operaciones - Forward</div>
                    <div class="divContenedor">

                        <div class="lineamientocontenido">
                            <div class="contlavelinput">
                                <div class="labels">Fecha</div>
                            </div>
                            <div class="contlavelinput">
                                <input type="text" placeholder="dd-mm-yyyy" id="datepickerForwardOpDia" readonly class="inputs" />
                            </div>
                            <div class="onlyfloat" style="padding-left: 13px;">
                                <input id="btnCargarOp" type="button" class="botones" value="Cargar" onclick="obtieneJsonforwardDelDia();" />
                            </div>
                        </div>

                    </div>
                </div>
                <div id="DivForwardBlotter" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Envío Manual de Operaciones - Forward</div>
                    <div class="divContenedor">

                        <div class="lineamientocontenido">
                            <div class="contlavelinput">
                                <div class="bajaorden labels">Fecha</div>
                                <div class="bajaorden">
                                    <input type="text" class="inputs" runat="server" id="datepickerBlotter" readonly autocomplete="off" /></div>
                            </div>

                            <div class="contlavelinput">
                                <div class="bajaorden labels">Archivo</div>
                                <div class="">
                                    <asp:FileUpload ID="FileUpload1" Style="padding-top: 1px;" runat="server" /></div>
                            </div>
                            <%--<div class="contlavelinput">--%>
                            <div class="contlavelinput">
                                <div class="bajaorden tam"></div>
                                <div class="labels bajaorden">
                                    <asp:Button ID="BtnCargarBlotter" runat="server" class="botones" Text="Cargar" OnClick="BtnCargarBlotter_Click" /></div>
                            </div>
                            <div class="contlavelinput">
                                <div class="bajaorden tam"></div>
                                <div class="labels bajaorden">
                                    <asp:Label ID="LblMensajeBlotter" runat="server" Text="."></asp:Label></div>
                            </div>
                            <%--</div>--%>
                        </div>
                    </div>

                </div>
                <div id="DivReenvioForward" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Reenvío de Operaciones - Forward</div>
                    <div class="divContenedor">

                        <div class="lineamientocontenido">
                            <div class="contlavelinput">
                                <div class="labels">Folio</div>
                            </div>
                            <div class="contlavelinput">
                                <input type="text" class="inputs" id="txtFolioReenvio" />
                            </div>
                            <div class="onlyfloat">
                                <input type="button" class="botones" value="Buscar" onclick="obtieneJsonforwardReenvio()" />
                            </div>

                            <br />

                        </div>
                    </div>
                </div>

                <div id="DivForwardVencimiento" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Envío de Aviso Vencimiento - Forward</div>
                    <div class="divContenedor">
                        <div class="lineamientocontenido">
                            <div class="lineado" style="font-size: 0.8em;">
                                <input type="radio" class="avisovenradios" id="radioPorvencer" checked="checked" name="radioVencimiento" value="1" />
                                Por vencer(día previo) &nbsp&nbsp
                 <input type="radio" class="avisovenradios" id="radioEnvencimiento" name="radioVencimiento" value="2" />En vencimiento(día en curso) &nbsp&nbsp&nbsp
                 <input id="btnCargarVencimiento" type="button" class="botones" value="Buscar" onclick="cargarVencimientosForward();" />
                            </div>
                        </div>
                        <br />

                    </div>
                </div>
                <div id="DivForwardConsultarVencimientos" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Consultar Aviso de Vencimientos Enviados - Forward</div>
                    <div class="divContenedor">

                        <div class="lineamientocontenido">
                            <div class="contlavelinput">
                                <div class="bajaorden tam"></div>
                                <div class="bajaorden labels">Búsqueda</div>
                            </div>

                            <div class="contlavelinput">
                                <div class="bajaorden labels">Fecha</div>
                                <div class="bajaorden">
                                    <input type="text" class="inputs ajusteopenviadas" id="datepickerForwardConsultaVencimiento" /></div>
                            </div>
                            <div class="contlavelinput">
                                <div class="bajaorden labels">Estado</div>
                                <div class="bajaorden">
                                    <select id="selectEstadoVencimientoForward" style="width: 9em !important;" class="inputs ajusteopenviadas">
                                        <option value="0">Seleccionar</option>
                                        <option value="1">Por Enviar</option>
                                        <option value="2">Enviado</option>
                                    </select></div>
                            </div>

                            <div class="contlavelinput">
                                <div class="bajaorden tam"></div>
                                <input type="button" class="botones" value="Buscar" onclick="obtieneJsonForwardConsultaVen();" />
                            </div>
                        </div>
                        <br />

                        <%--<input type="button" id="exportForward" onclick="exportar()" class="botones oculto" value="Exportar a Excel" />--%>
                    </div>
                </div>

<%-- Contratos forward--%>
     <div id="DivContratosForwardConsultarDia" class="contenedorFunc" style="display:none;" runat="server">
      <div class="tituloDiv">Envío Masivo de Contratos - Forward</div> 
      <div class="divContenedor">
    <div class="lineamientocontenido">
            <div class="contlavelinput">
                <div class="labels">Fecha</div>
            </div>
            <div class="contlavelinput">
                <input type="text" placeholder="dd-mm-yyyy" id="datepickerContratoForwardOpDia" readonly class="inputs" />
            </div>
            <div class="onlyfloat" style="padding-left:13px;"> 
                <input id="BtnEnviarContratosForwardDelDia" type="button" class="botones"  value="Cargar" onclick="obtieneJsonContratoforwardDelDia();" />
            </div>
    </div>
     </div>
  </div>

      <div id="DivForwardConsultar" class="contenedorFunc" style="display:none;" runat="server">
      <div class="tituloDiv" style="padding-bottom: 1%; margin-top:-0.5%">Consultar Operaciones - Forward</div>
      <div class="divContenedor">

        <div class="lineamientocontenido" style="margin-bottom: 0%;">
            <div class="contlavelinput">
                <div class="bajaorden tam"> </div>
                <div class="labels bajaorden">Búsqueda</div>
            </div>

            <div class="contlavelinput">
                <div class="labels bajaorden">Fecha</div>
                <div class="bajaorden"><input type="text" readonly autocomplete="off" class="inputs ajusteopenviadas" id="datepickerForwardConsultaContratos" /></div>
            </div>
            <div class="contlavelinput">
                <div class="bajaorden labels">Rut Cliente</div>
                <div class="bajaorden"><input type="text" class="inputs ajusteopenviadas" id="txtBuscarClientesForwardContratos" maxlength="10" /></div>
            </div>
            <div class="contlavelinput">
                <div class="bajaorden labels">N° Operación</div>
                <div class="bajaorden"><input type="text" class="inputs ajusteopenviadas" id="txtBuscarNumOperacionForwardContratos" /></div>
            </div>
            <div class="contlavelinput">
                <div class="bajaorden labels">Estado Confirmación</div>
                <div class="bajaorden"><select id="selectEstadoForwardConfirmacion" style="width: 9em !important;" class="inputs ajusteopenviadas"><option value="0">Seleccionar</option><option value="1">Enviado</option><option value="2">Confirmado</option><option value="3">No Confirmado</option><option value="4">Eliminado</option></select></div>
            </div>
            <div class="contlavelinput">
                <div class="bajaorden labels">Estado Contrato</div>
                <div class="bajaorden">
                <select id="selectEstadoForwardContratos" style="width: 9em !important;" class="inputs ajusteopenviadas">
                    <option value="9">Seleccionar</option>
                    <option value="0">Creado</option>
                    <option value="1">Enviado</option>
                    <option value="2">No Recepcionado</option>
                    <option value="3">Recepcionado</option>
                    <option value="4">Validación Legal</option>
                    <option value="5">Rechazado</option>
                    <option value="6">Autorizado</option>
                </select></div>
            </div>
         <div class="contlavelinput">
             <div class="bajaorden tam"></div>
              <input type="button" class="botones" id="btnBuscarContratosFWD" value="Buscar" onclick="obtieneJsonForwardConsultaOperaciones();" />
        </div>
        <div class="contlavelinput">
             <div class="bajaorden tam"></div>
              <input type="button" class="botones"  value="Contratos Pendientes" onclick="obtieneJsonForwardConsultaOperacionesPendientes();" />
        </div>
       </div>
               <br />
     </div>
          <%--<input type="button" id="exportForward" style="display:none;" onclick="exportar()" class="botones" value="Exportar a Excel" />--%>
  </div>

    <div id="DivEditarEstado" style="display:none; border: 1px solid black;" title="Editar estado de contrato">
        <div class="divContenedor">
            <div class="contlavelinput" style="text-align:center; width: 100%;">
                    <p><label>Folio Operación</label>
                <input type="text" id="txtFolioContrato" class="inputs ajusteopenviadas" readonly style="background-color: white;"/><br /><br />

                <label>Elija un estado</label> <br />
                <select id="slcCambioEstadoContrato" class="inputs ajusteopenviadas" style="width: 12em !important;">
                    <option value="99">Seleccionar</option>
                    <option value="0">Creado</option>
                    <option value="1">Enviado</option>
                    <option value="2">No Recepcionado</option>
                    <option value="3">Recepcionado</option>
                    <option value="4">Validación Legal</option>
                    <option value="5">Rechazado</option>
                    <option value="6">Autorizado</option>
                </select><br /><br />
                <input type="hidden" id="txtIDContrato" />
                    <br />
                <input type="button" class="botones" value="Actualizar" onclick="editarEstadoContrato();" />
                </p>
            </div>
       </div>
    </div>


<%-- mantenedores --%>
  <div id="DivMantenedorDeCorreos" class="contenedorFunc" style="display:none;" runat="server">
      <div class="tituloDiv" style="padding-bottom: 3%; margin-top:-0.5%">Mantenedor de Correos - Confirmacion Operaciones</div>
       <div class="divContenedor">
            <div class="lineamientocontenido" style="margin-bottom: 1%;">
                <div class="contlavelinput">
                    <div class="bajaorden tam">Rut</div>
                </div> 
                <div class="contlavelinput">
                    <div class="labels bajaorden"><input type="text" class="inputs ajusteopenviadas" oninput="formatoRut(this)" id="txtRutManCorreo" style="width: 70px;height: 15px;"/></div>
                    <div class="labels bajaorden"><input type="button" class="botones" id="btnCargarMantenedorCorreos" value="Cargar" onclick="obtenerGrillaMantenedorCorreos();" /></div>
                    <div class="labels bajaorden"><input type="button" class="botones"  value="Nuevo" onclick="crearCorreos();" /></div>
                </div>
            </div>
        </div>
  </div>

     <div id="crearCorreos" style="display:none; border-collapse: collapse; border: 1px solid;" title="Nuevo Correo">
        <div class="divContenedor">
            <table>
                <tr>
                    <td>Email :</td>
                    <td><input type="text" class="inputs ajusteopenviadas" id="txtemail" /></td>  
                </tr>
                <tr>
                    <td>Alias :</td>
                    <td><input type="text" class="inputs ajusteopenviadas" id="txtalias" /></td>
                </tr>
                <tr style="background-color:white;">
                    <td>Rut :</td>       
                    <td><input type="text" class="inputs ajusteopenviadas" id="txtrutcc" oninput="formatoRut(this)" /></td>  
                </tr>
                <tr>
                   <td>
                       <input type="button" class="botones" id="btnAgregaCorreo" value="Agregar" onclick="agregarCorreo();" />
                   </td>
                </tr>
            </table>          
        </div>  
    </div>

    <!--Modal Modifiar correo-->
    <div id="editaCorreos" style="display:none; border-collapse: collapse; border: 1px solid; width: 355px;" title="Modificar Correo">
        <div class="divContenedor">
            <table style="padding-top:10px;">
                <tr style="background-color:white;">
                    <td>Email  :</td>
                    <td><input type="text" id="txtEmail" style="width: 160px;height: 15px;" /></td>
                </tr>
                <tr>
                     <td>Alias  :</td>
                    <td><input type="text" id="txtAlias" style="width: 160px;height: 15px;" /></td>
                </tr>
                <tr>
                     <td>Estado  :</td>
                    <td>
                        <select id="selEstado">
                          <option value="1">Activo</option>
                          <option value="0">Inactivo</option>
                       </select>
                    </td>
                </tr>
                <tr>
                    <td><input type="hidden" id="valID"/></td>
                    <td><input type="hidden" id="valCli"/></td>
                </tr>
                <tr>
                   <td style="display: block;">
                       <input type="button" class="botones" value="Cambiar" onclick="editarElCorreo();" />
                   </td>
                </tr>
            </table>
        </div>
    </div>

     <div id="DivListaDistribucion" class="contenedorFunc" style="display:none;" runat="server">
        <div class="tituloDiv" style="padding-bottom: 3%; margin-top:-0.5%">Lista de distribución</div>
            <div class="divContenedor">
                <div class="lineamientocontenido" style="margin-bottom: 1%;">
                <div class="contlavelinput">
                    <div class="bajaorden tam">Búsqueda</div>
                </div>
                <div class="contlavelinput">
                    <div class="labels bajaorden"><input type="text" class="inputs ajusteopenviadas" placeholder="Rut Cliente" oninput="formatoRut(this)" autocomplete="off" id="txtRutLista" /></div>
                </div>
                <div class="contlavelinput">
                    <select id="selProductoLista" class="inputs ajusteopenviadas" style="width: 9em !important">
                      <option value="1">Forward</option>
                      <option value="2">Simultaneas</option>
                   </select>
                </div>
                <div class="contlavelinput">
                    <input type="hidden" class="labels bajaorden" placeholder="Secuencia" id="txtSecuenciaLista" style="width: 70px;height: 15px;"/>
                </div>
                <div class="contlavelinput">
                    <input type="button" class="botones" value="Buscar" id="btnBuscarLista" onclick="obtenerListaDistribucion();" />
                    <input type="button" class="botones" value="Crear" id="btnCrearLista" onclick="crearNuevaLista();" />
               </div>
                   <input type="button" id="btnSaveLista" style="display:none;width:180px !important" onclick="guardarLista()" class="botones" value="Guardar" /> 
              </div>
            </div>
       </div>

                <%--Simultaneas--%>
                <div id="DivSimultaneaEnvio" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Envío y Re-envío de Operaciones - Simultaneas</div>
                    <div class="divContenedor">
                        <table class="tablacontenidos">
                            <tr>
                                <td>Búsqueda</td>
                                <td>
                                    <input type="text" class="inputs" placeholder="Fecha" id="datepickerSimultaneaEnvio" /></td>
                                <td>
                                    <input type="button" id="btnCargarSIMd" class="botones" value="Cargar" onclick="obtieneJsonSimultaneasDelDia();" /></td>
                            </tr>
                        </table>
                        <br />

                    </div>
                </div>

                <div id="DivSimultaneaConsulta" class="contenedorFunc" style="display: none;" runat="server">
                    <div class="tituloDiv">Consulta de Operaciones y Reportería - Simultaneas</div>
                    <div class="divContenedor">
                        <table class="tablacontenidos">
                            <tr>
                                <td>Búsqueda</td>
                                <td>
                                    <input type="text" class="inputs" placeholder="Fecha" id="datepickerSimultaneasConsulta" /></td>
                                <td>
                                    <input type="text" class="inputs" placeholder="Cliente" id="txtBuscarClientesSimultaneas" style="width: 75px; height: 15px;" maxlength="10" /></td>
                                <td>
                                    <input type="text" class="inputs" placeholder="N° Operación" id="txtBuscarNumOperacionSimultaneas" style="width: 85px; height: 15px;" /></td>
                                 <td>
                                    <select id="selectEstadoSimultanea" style="width: 9em !important;" class="inputs ajusteopenviadas">
                                        <option value="0">Seleccionar</option>
                                        <option value="1">Enviado</option>
                                        <option value="2">Confirmado</option>
                                        <option value="3">No Confirmado</option>
                                        <option value="4">Eliminado</option>

                                    </select>
                                <td>
                                    <input type="button" class="botones" value="Buscar" id="JsonSimultaneasConsulta" onclick="obtieneJsonSimultaneasConsulta();" /></td>
                            </tr>
                        </table>
                        <br />

                        <input type="button" id="exportSimultaneas" style="display: none;" onclick="exportar()" class="botones" value="Exportar a Excel" />
                    </div>
                </div>
                <div id="DivEditarEstadoSIM" style="display: none; border: 1px solid black;" title="Editar estado de Confirmación">
                    <div class="divContenedor">
                        <div class="contlavelinput" style="text-align: center; width: 100%;">
                            <p>
                                <label>Folio Operación</label>
                                <input type="text" id="txtFolioContratos" class="inputs ajusteopenviadas" readonly style="background-color: white;" /><br />
                                <br />

                                <label>Elija un estado</label>
                                <br />
                                <select id="slcCambioEstadoContratos" class="inputs ajusteopenviadas" style="width: 9em !important;">
                                    <option value="99">Seleccionar</option>
                                    <!-- <option value="0">Creado</option>-->
                                   <option value="1">Enviado</option>
                                        <option value="2">Confirmado</option>
                                        <option value="3">No Confirmado</option>
                                        <option value="4">Eliminado</option>
                                </select><br />
                                <br />
                                <input type="hidden" id="txtIDContratos" />
                                <br />
                                <input type="button" class="botones" value="Actualizar" onclick="editarEstadoContratoSIM();" />
                            </p>
                        </div>
                    </div>
                </div>

                <hr class="elhr subhr" />

                <div id="ajustadorGrilla" class="grilla">
                    <div id="divGrilla">
                        <table id='list'></table>
                        <div id="jqGridPager"></div>
                    </div>
                </div>
                <div id="divBotones">
                    <input type="button" id="BtnExport" style="display: none;" onclick="exportar()" class="botonescarga" value="Exportar a Excel" />
                    <input type="button" id="BtnEnviarConfirmacion" style="display: none;" onclick="enviarConfirmacion()" class="botonescarga" value="Enviar" />
                    <input type="button" id="BtnEnviarConfirmacionSIM" style="display: none;" onclick="enviarConfirmacionSIM()" class="botonescarga" value="Enviar" />
                    <input type="button" id="BtnEnviarConfirmacionBlotter" style="display: none;" onclick="enviarConfirmacionBlotter()" class="botonescarga" value="Enviar" />
                    <input type="button" id="BtnReenviarConfirmacion" style="display: none;" onclick="reenviarConfirmacion()" class="botonescarga" value="Reenviar" />
                    <input type="button" id="BtnEnviarAvisoVencimiento" style="display: none;" onclick="enviarAvisoVencimiento()" class="botonescarga" value="Enviar" />
                    <input type="button" id="btnGuardarCambios" style="display:none;" onclick="guardarLista()" class="botones" value="Guardar" />
                    <input type="button" id="BtnGuardarListaDistribucion" style="display:none;" onclick="crearNuevaListaDistribucion()" class="botones" value="Guardar" />
                    <input type="button" id="BtnGuardarCambiosListaDistribucion" style="display:none;" onclick="guardarCambiosListaDistribucion()" class="botones" value="Guardar" />
                    <input type="button" id="BtnEliminarListaDistribucion" style="display:none;" onclick="eliminarListaDistribucion()" class="botones" value="Eliminar" />
                    <input type="button" id="BtnEnviarContratosForward" style="display:none;" onclick="enviarContratosForward()" class="botonescarga" value="Enviar" />
                </div>
                <%--<div id="divSeleccionarTodos" style="display:none;">Seleccionar Todos <input type="checkbox" id="chkSeleccionarTodosSimultaneas" /></div> --%>
            </div>

            <div id="divFooter">
                Confirmación de Operaciones - Área de Operaciones Financieras
            </div>

            <div id="DivPreload" style="display: none;">
                <img src="Img/preloader.gif" id="imgPreload" style="margin-left: auto; margin-right: auto; margin-top: 230px; display: block;" />
            </div>
            <div id="divAlertas" runat="server" style="position: absolute; right: 119px; z-index: 100; top: 13px; color: rgb(89,123,123) !important">
                <ul id="nav">

                    <li id="notification_li">
                        <span id="notification_count">6</span>
                        <a href="#" id="notificationLink">Notificaciones</a>
                        <div id="notificationContainer">
                            <div id="notificationTitle">Alertas</div>
                            <div id="notificationsBody" class="notifications">
                                <div class="Notificaciones" onclick="RevisarCambiosCorreos();">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:11.111.111-1
                                </div>
                                <div class="Notificaciones">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:22.222.222-2
                                </div>
                                <div class="Notificaciones">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:33.333.333-3
                                </div>
                                <div class="Notificaciones">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:11.111.111-1
                                </div>
                                <div class="Notificaciones">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:22.222.222-2
                                </div>
                                <div class="Notificaciones">
                                    Modificaciones de correo
                                    <br />
                                    Cliente:33.333.333-3
                                </div>


                            </div>
                            <div id="notificationFooter"><a href="#">See All</a></div>
                        </div>
                    </li>
                </ul>

            </div>


            <table id="tablaExp" style="display: none;">
                <tr style="background-color: #E4EFEF; color: #666666">
                    <td>Folio</td>
                    <td>Rut</td>
                    <td>Secuencia</td>
                    <td>Razon Social</td>
                    <td>Fecha Inicio</td>
                    <td>Fecha Vencimiento</td>
                    <td>Monto Moneda Principal</td>
                    <td>TCCierre</td>
                    <td>Monto Moneda Secundaria</td>
                    <td>Modalidad</td>
                    <td>Dias</td>
                    <td>Tipo Movimiento</td>
                    <td>Moneda Principal</td>
                    <td>Moneda Secundaria</td>
                    <td>Ejecutivo</td>
                    <td>Fecha Envio</td>
                    <td>Fecha Confirmacion</td>
                    <td>Fecha Eliminacion</td>
                    <td>Estado</td>
                    <td>Respuesta Conf.</td>
                </tr>
            </table>
    </form>


</body>
</html>