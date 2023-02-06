using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Google.Maps.Direction;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utility.GoogleMaps
{
   public class GMapsNET
    {
        private GMapControl maps;
        public GMapsNET(int width,int height)
        {
            //initial map
            maps = new GMapControl();
            maps.Width = width;
            maps.Height = height;
            maps.MapProvider = GoogleMapProvider.Instance;           
            maps.Position = new GMap.NET.PointLatLng(22.8016472, 120.2858846);
            maps.MaxZoom = 20;
            maps.Zoom = 16;
            maps.ShowCenter = false;
            maps.DragButton = MouseButtons.Left;
        }

        public GMapControl getMap()
        {
            return this.maps;
        }

        public void AddMaker(double lat, double lng,string keywords)
        {
            GMapOverlay markers = new GMapOverlay("markers");
            GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_dot);

            /*工具提示文字*/
            marker.ToolTipText = keywords;
            marker.ToolTip.Fill = new SolidBrush(Color.FromArgb(100, Color.Black));
            marker.ToolTip.Foreground = Brushes.White;
            marker.ToolTip.TextPadding = new Size(20, 20);

            markers.Markers.Add(marker);
            maps.Zoom = 16;
            this.maps.Overlays.Add(markers);
        }



        public void getRoute(string OriPlaceId,string DesPlaceId)
        {
            List<PointLatLng> pointList = new List<PointLatLng>();
            var request = new DirectionRequest();
            request.Mode = Google.Maps.TravelMode.driving;
            request.Origin = $"place_id:{OriPlaceId}";
            request.Destination = $"place_id:{DesPlaceId}";
            var response = new DirectionService().GetResponse(request);
            //DirectionStep[] steps = response.Routes[0].Legs[0].Steps;
            string encode = response.Routes[0].OverviewPolyline.Points;
         
            List<PointLatLng> pointLatLngs= Coordinate.Decode(encode).ToList();
            foreach (var point in pointLatLngs)
            {
                pointList.Add(new PointLatLng(point.Lat,point.Lng));
                Console.WriteLine(point);
            }


          
         



            //foreach (var step in steps)
            //{              
            //    pointList.Add(new PointLatLng(step.StartLocation.Latitude, step.StartLocation.Longitude));
            //    pointList.Add(new PointLatLng(step.EndLocation.Latitude, step.EndLocation.Longitude));               

            //}

            GMapOverlay routes = new GMapOverlay("routes");
            GMapRoute mapRoute = new GMapRoute(pointList, "mapRoute");
            mapRoute.Stroke = new Pen(Color.Red, 3);
            routes.Routes.Add(mapRoute);
            this.maps.Overlays.Add(routes);
            this.maps.ZoomAndCenterRoute(mapRoute);//focus在哪條路
        }



        public void removeRoute()
        {
            foreach (var overlay in this.maps.Overlays)
            {
                if (overlay.Id.Equals("routes"))
                {
                    this.maps.Overlays.Remove(overlay);
                    this.maps.Refresh();
                    break;
                }
            }
        }



    }
}
