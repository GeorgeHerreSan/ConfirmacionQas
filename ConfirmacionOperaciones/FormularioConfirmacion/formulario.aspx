<%@ Page Language="C#" AutoEventWireup="true" CodeFile="formulario.aspx.cs" Inherits="formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        #contenedor{
            border: black 1px solid;
            text-align:center;
            width:50%;
            top:50%;
		    left:50%;
            padding: 20px 20px 20px 20px;
        }
    </style>
   <%-- <script type="text/javascript" src="lib/jquery-3.4.1.min.js"></script>--%>
    <script src="../js/jquery-1.7.2.min.js"></script>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function obvalores(respuesta) {
            var parametros = {
                "btnrespuesta": respuesta,
                "folio": document.getElementById("folid").value
            };
            $(contenedor).html('<div style="position: absolute;top: 50%; left: 40%;"></div>');
			$(contenedor).fadeOut(300, function(){
				$.ajax({
					type: "POST",
					url:"confirmado.aspx",
					data:parametros,
                    success: function (datos) {
						$('.validity-tooltip').remove();
						$(contenedor).html(datos);
					}
				});
				$(contenedor).fadeIn();
			});
        
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <input type="hidden" id="folid" runat="server" />
        <div id="contenedor">
            
            <img src="../img/logo-credicorp.png" />
            <br />
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <a id="hrefop2" onclick="obvalores('1');"><asp:Button ID="btnsi" runat="server" Text="Si" /></a>
            <a id="hrefop2" onclick="obvalores('2');"><asp:Button ID="btnno1" runat="server" Text="No" /></a>
            <a id="hrefop2" onclick="obvalores('3');"><asp:Button ID="btnno2" runat="server" Text="No 2" /></a>
            <a id="hrefop2" onclick="obvalores('4');"><asp:Button ID="btnno3" runat="server" Text="No 3" /></a>            

        </div>
       </center>
    </form>
</body>
</html>
