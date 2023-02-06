using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
            this.maps.Overlays.Add(markers);
        }
    }
}
