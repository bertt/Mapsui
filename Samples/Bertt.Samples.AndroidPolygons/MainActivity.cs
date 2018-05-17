using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Mapsui.Utilities;
using Mapsui.UI.Android;
using Mapsui;
using System.Collections.Generic;
using Tiles.Tools;
using Mapsui.Geometries;
using Mapsui.Styles;
using System;
using Mapsui.Projection;

namespace Bertt.Samples.AndroidPolygons
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var mapControl = FindViewById<MapControl>(Resource.Id.mapcontrol);

            var map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            mapControl.Map = map;
            map.Transformation = new MinimalTransformation();
            map.CRS = "EPSG:3857";

            var tiles = GetRandomTiles();

            var mapsuipolys = new List<Polygon>();

            foreach (var tile in tiles)
            {
                var poly = tile.ToMapsui();
                mapsuipolys.Add(poly);
            }
            map.Layers.Add(MapsuiDrawing.CreateLayer(mapsuipolys, new Color(150, 150, 30, 128), Color.Red));
        }

        private List<Tile> GetRandomTiles()
        {
            var rndX = new Random();
            var rndY = new Random();

            var res = new List<Tile>();

            // add 5000 polygons
            for (int i = 0; i < 10000; i++)
            {
                var x = rndX.Next(16383);
                var Y = rndX.Next(16383);

                var t = new Tile(x, Y, 14);
                res.Add(t);
            }

            return res;
        }
    }
}

