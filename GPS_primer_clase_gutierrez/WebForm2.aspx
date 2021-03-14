<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="GPS_primer_clase_gutierrez.WebForm2" %>
<!DOCTYPE html>
<html lang="en"><head>
  <title>Map Coordinates</title>
  <script src="~/Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
</head>
<body>
  <h1>Map Coordinates</h1>
  <form method="post">
    <fieldset>
    <div>
      <label for="latitude">Latitude:&nbsp;&nbsp;&nbsp;</label>
        <input type="text" name="latitude" value="@Request["latitude"]"/>
    </div>
    <div>
      <label for="longitude">Longitude:</label>
      <input type="text" name="longitude" value="@Request["longitude"]"/>
    </div>
    <div>
      <input type="submit" value="Map It!" />
    </div>
    </fieldset>
  </form>
  @if(IsPost) {
      @Maps.GetBingHtml(key: "AIzaSyAf-OB8eta1P90esfJDtvKSc1q518-Ouo8",
          latitude: Request["latitude"],
          longitude: Request["longitude"],
          width: "300",
          height: "300"
       )
    }
</body>
</html>