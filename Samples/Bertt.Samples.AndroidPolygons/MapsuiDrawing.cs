using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Styles;
using System.Collections.Generic;

namespace Bertt.Samples.AndroidPolygons
{
    public class MapsuiDrawing
    {
        public static ILayer CreateLayer(List<Polygon> polys, Color fillColor, Color outlineColor)
        {
            return new Layer("Polygons")
            {
                DataSource = new MemoryProvider(polys) { CRS = "EPSG:4326" },
                Style = new VectorStyle
                {
                    Fill = new Brush(fillColor),
                    Outline = new Pen
                    {
                        Color = outlineColor,
                        Width = 4,
                        PenStyle = PenStyle.Solid,
                        PenStrokeCap = PenStrokeCap.Round
                    }
                }
            };
        }

    }
}