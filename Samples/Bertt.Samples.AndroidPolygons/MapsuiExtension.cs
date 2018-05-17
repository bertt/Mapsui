using Mapsui.Geometries;
using Tiles.Tools;

namespace Bertt.Samples.AndroidPolygons
{
    public static class MapsuiExtension
    {
        public static Polygon ToMapsui(this Tile tile)
        {
            var p = new Polygon();
            p.ExteriorRing.Vertices.Add(tile.BoundsLL().ToMapsui());
            p.ExteriorRing.Vertices.Add(tile.BoundsUL().ToMapsui());
            p.ExteriorRing.Vertices.Add(tile.BoundsUR().ToMapsui());
            p.ExteriorRing.Vertices.Add(tile.BoundsLR().ToMapsui());
            p.ExteriorRing.Vertices.Add(tile.BoundsLL().ToMapsui());
            return p;
        }

        public static Point ToMapsui(this Point2 point)
        {
            return new Point(point.X, point.Y);
        }
    }
}