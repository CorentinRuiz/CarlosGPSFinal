using OSMElement;
using RoutingServer.ProxyCache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Text.Json;

namespace RoutingServer
{
    public class RoutingService : IRoutingService
    {
        public BestItinerary GetItinerary(string origin, string destination)
        {
            // Retrieves the addresses given in user input and transforms them into an object
            OSMRequest osmRequest = new OSMRequest();
            Address originAddress = JsonSerializer.Deserialize<Address>(osmRequest.GetAddressDetails(origin));
            Address destinationAddress = JsonSerializer.Deserialize<Address>(osmRequest.GetAddressDetails(destination));

            // Retrieves the list of all stations
            ProxyCacheServiceClient client = new ProxyCacheServiceClient();
            List<Station> allStations = client.GetAllStations().ToList();

            // Calculates the stations closest to the departure and arrival points
            ItineraryHelper helper = new ItineraryHelper();
            var closestStationOrigin = helper.GetClosestStation(originAddress, allStations, true);
            var closestStationDest = helper.GetClosestStation(destinationAddress, allStations, false);

            // If no station is in the origin or destination city, an error is thrown for the user.
            if (closestStationOrigin == null || closestStationDest == null)
                return null;

            // Calculates the best route between the point of origin, station 1, station 2, arrival.
            List<Itinerary> itineraries = new List<Itinerary>();
            BestItinerary bestItinerary = new BestItinerary();
            bestItinerary.Time = 0;
            bestItinerary.Distance = 0;
            bestItinerary.Coordinates = new List<double[]>();
            bestItinerary.Points = new List<double[]>();
            bestItinerary.Instructions = new List<Instruction>();

            string itinerary1 = osmRequest.GetItinerary(originAddress.point.lat, originAddress.point.lng, closestStationOrigin.position.latitude, closestStationOrigin.position.longitude, false);
            Itinerary itinerary1obj = JsonSerializer.Deserialize<Itinerary>(itinerary1);
            itinerary1obj.instructions.Add(new Instruction(0, "Prenez un vélo dans la station"));
            itineraries.Add(itinerary1obj);

            string itinerary2 = osmRequest.GetItinerary(closestStationOrigin.position.latitude, closestStationOrigin.position.longitude, closestStationDest.position.latitude, closestStationOrigin.position.longitude, true);
            Itinerary itinerary2obj = JsonSerializer.Deserialize<Itinerary>(itinerary2);
            itinerary2obj.instructions.Add(new Instruction(0, "Déposez le vélo dans la station"));
            itineraries.Add(itinerary2obj);

            string itinerary3 = osmRequest.GetItinerary(closestStationDest.position.latitude, closestStationDest.position.longitude, destinationAddress.point.lat, destinationAddress.point.lng, false);
            itineraries.Add(JsonSerializer.Deserialize<Itinerary>(itinerary3));

            // Merge all data into a single route
            foreach (Itinerary itinerary in itineraries)
            {
                bestItinerary.Time += itinerary.time;
                bestItinerary.Distance += itinerary.distance;
                bestItinerary.Coordinates.AddRange(itinerary.points.coordinates);
                bestItinerary.Instructions.AddRange(itinerary.instructions);
            }

            // List the four different points of the journey (origin, station 1, station 2, arrival)
            bestItinerary.Points.Add(new double[] { originAddress.point.lng, originAddress.point.lat });
            bestItinerary.Points.Add(itinerary2obj.points.coordinates.First());
            bestItinerary.Points.Add(itinerary2obj.points.coordinates.Last());
            bestItinerary.Points.Add(new double[] { destinationAddress.point.lng, destinationAddress.point.lat });

            // Sending instructions to the ActiveMQ queue
            ActiveMQ.SendToQueue(bestItinerary.Instructions);

            return bestItinerary;
        }
    }

    [DataContract]
    public class BestItinerary
    {
        [DataMember]
        public int Time { get; set; }
        [DataMember]
        public double Distance { get; set; }
        [DataMember]
        public List<double[]> Coordinates { get; set; }
        [DataMember]
        public List<double[]> Points { get; set; }
        [DataMember]
        public List<Instruction> Instructions { get; set; }
    }
}
