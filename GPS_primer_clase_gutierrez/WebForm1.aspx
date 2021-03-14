<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="GPS_primer_clase_gutierrez.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="https://polyfill.io/v3/polyfill.min.js?features=default"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title></title>
        <script type="text/javascript">
            function initMap() {
                const myLatLng = { lat: -25.363, lng: 131.044 };
                const map = new google.maps.Map(document.getElementById("map"), {
                    zoom: 4,
                    center: myLatLng,
                });
                new google.maps.Marker({
                    position: myLatLng,
                    map,
                    title: "Hello World!",
                });
            }
        </script>
    </head>
<body>
    <form id="form1" runat="server">
        <div>
            <p> Ponga la ubicacion de texto que desea mostrar en el mapa </p>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Button"  OnClick="Button1_click"/>
        </div>
    </form>
    <div id="map" style="width: 615px; height: 400px"></div>
    <script type="text/javascript"
      src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAf-OB8eta1P90esfJDtvKSc1q518-Ouo8&callback=initMap&libraries=&v=weekly"
      ></script>
</body>
</html>
