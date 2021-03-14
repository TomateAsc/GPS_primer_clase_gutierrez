using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net; // agregar o trabajar con URL
using Newtonsoft.Json; //trabajar con Json
using Newtonsoft.Json.Linq; //libreria para trabajar con Json
using static GPS_primer_clase_gutierrez.resultado_geo; //importando la clase que es a donde va el Json


namespace GPS_primer_clase_gutierrez
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        const string apikey = "AIzaSyAf-OB8eta1P90esfJDtvKSc1q518-Ouo8";
        static string url_api = "https://maps.googleapis.com/maps/api/geocode/json?address=";
        static string url_api_rev = "https://maps.googleapis.com/maps/api/geocode/json?latlng=";
        static string url_key = "&key=";
        string direccion = "";
        static string url_mapa = "https://www.google.com/maps/embed/v1/view";
        static string url_mapa_center = "&center=";
        static string url_mapa_zoom = "&zoom=18";
        static string iframe = "<iframe id=\"iframe1\" src=\"";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_click(object sender, EventArgs e)
        {
            direccion = TextBox1.Text;
            Response.Write(localizacion(direccion));
            
            //string coorde = "89.5, 100.2";
            //Response.Write(rev_localization(coorde));
        }

        static string localizacion(string dir)
        {
            string url = url_api + dir.Replace(" ", "+") + url_key + apikey;
            var json = new WebClient().DownloadString(url);
            geo_response r_json = JsonConvert.DeserializeObject<geo_response>(json);
            //string info;
            string coordenadas;
            if (r_json.status == "OK") {
                //info = r_json.results[0].formatted_address;
                //coordenadas = r_json.results[0].geometry.location.lat + "--" + r_json.results[0].geometry.location.lng;
                //coordenadas = iframe + url_mapa + url_key + apikey + url_mapa_center + "-33.8569,151.2152" + url_mapa_zoom + "&maptype=satellite\"> </iframe>";
                coordenadas = iframe + url_mapa + url_key + apikey + url_mapa_center + r_json.results[0].geometry.location.lat + "," + r_json.results[0].geometry.location.lng + url_mapa_zoom + "\" style=\"width: 100 %; border: 0\" height=\"300\" ></iframe>";
                return coordenadas;
//              info = "< script type = " + "text/javascript"+" > function initMap() {const myLatLng = { lat: -25.363, lng: 131.044 };const map = new google.maps.Map(document.getElementById("+"map"+"), {zoom: 4,center: myLatLng,})new google.maps.Marker({position: myLatLng,map, title: "+"Hello World!"+",});}</script> ";
//              return info;
            }
            else {
                return json;
            }
            
        }
        static string rev_localization(string coor) {
            string url = url_api_rev + coor + url_key + apikey;
            var json = new WebClient().DownloadString(url);
            geo_response r_json = JsonConvert.DeserializeObject<geo_response>(json);
            string info;
            string coordenadas;
            if (r_json.status == "ok")
            {
                info = r_json.results[0].formatted_address;
                coordenadas = r_json.results[0].geometry.location.lat + " -- " + r_json.results[0].geometry.location.lng;
                return info;
            }
            else
            {
                return json;
            }
        }



        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_click(object sender, EventArgs e)
        {

        }

    }
}