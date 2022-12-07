using RoutingServer.ProxyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RoutingServer
{
    internal class ItineraryHelper
    {
        public Station GetClosestStation(Address address, List<Station> stations, bool departure)
        {
            var minDistance = Double.MaxValue;
            Station closestStation = null;

            foreach (var station in stations)
            {
                var distance = GetDistanceFrom2GpsCoordinates(address.point.lat, address.point.lng, station.position.latitude, station.position.longitude);

                if (distance < minDistance && station.status == "OPEN" && GetAvailableStands(station, departure) > 0)
                {
                    minDistance = distance;
                    closestStation = station;
                }
            }

            return closestStation;
        }

        private double GetDistanceFrom2GpsCoordinates(double lat1, double lon1, double lat2, double lon2)
        {
            // Radius of the earth in km
            var earthRadius = 6371;
            var dLat = Deg2Rad(lat2 - lat1);
            var dLon = Deg2Rad(lon2 - lon1);
            var a =
                Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                Math.Cos(Deg2Rad(lat1)) * Math.Cos(Deg2Rad(lat2)) *
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
            ;
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = earthRadius * c; // Distance in km
            return d;
        }

        private double Deg2Rad(double deg)
        {
            return deg * (Math.PI / 180);
        }

        private int GetAvailableStands(Station station, bool departure)
        {
            return departure ? station.totalStands.availabilities.bikes : station.totalStands.availabilities.stands;
        }
    }
}
