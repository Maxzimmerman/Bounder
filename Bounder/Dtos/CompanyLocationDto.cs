using Bounder.Models;
using NetTopologySuite.Geometries;
using System.Runtime.CompilerServices;

namespace Bounder.Dtos
{
    public static class CompanyLocationDto
    {
        public static List<Coordinate> ToCoordinate(this List<CompanyLocation> locations)
        {
            var coordinates = new List<Coordinate>();
            foreach(CompanyLocation location in locations)
            {
                coordinates.Add(new Coordinate(location.Latitude, location.Longitude));
            }
            return coordinates;
        }
    }
}
