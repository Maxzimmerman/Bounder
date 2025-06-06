﻿using Bounder.Dtos;
using Bounder.Models;
using NetTopologySuite.Geometries;

namespace Bounder.Services
{
    public static class LocationInAreaService
    {
        public static bool IsPointWithinArea(Models.Location location)
        {
            var coordinatesOfArea = new List<Coordinate>()
            {
                new Coordinate(50.10903449728312, 8.667310702507082),
                new Coordinate(50.108951498648366, 8.66739720374046),
                new Coordinate(50.10884097692695, 8.667161169367214),
                new Coordinate(50.108930426433204, 8.66707533868603),
                new Coordinate(50.10903449728312, 8.667310702507082)
            };

            var geometryFactory = new GeometryFactory();
            var area = geometryFactory.CreatePolygon(coordinatesOfArea.ToArray());
            var point = geometryFactory.CreatePoint(new Coordinate(location.Latitude, location.Longitude));
            return area.Contains(point);
        }

        public static Company getCompanyTheLocationIsWithin(Models.Location location, List<Company> companies)
        {
            var geometryFacotory = new GeometryFactory();
            var point = geometryFacotory.CreatePoint(new Coordinate(location.Latitude, location.Longitude));

            foreach(Company company in companies)
            {
                var coordinates = company.Area.ToCoordinate().ToArray();
                if (coordinates.Count() != 0)
                {
                    var area = geometryFacotory.CreatePolygon(coordinates);
                    if (area.Contains(point))
                    {
                        return company;
                    }
                }
                else
                    continue;
            }
            return new Company();
        }
    }
}
