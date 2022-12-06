package org.carlosgps.classes;

import com.baeldung.soap.ws.client.generated.ArrayOfdouble;
import com.baeldung.soap.ws.client.generated.BestItinerary;
import com.baeldung.soap.ws.client.generated.IRoutingService;
import com.baeldung.soap.ws.client.generated.RoutingService;


import java.util.ArrayList;
import java.util.List;

public class ItineraryRequesterService {

    RoutingService routingService;

    IRoutingService routingServiceInterface;

    BestItinerary bestItinerary;

    public ItineraryRequesterService() {
        routingService = new RoutingService();
        routingServiceInterface = routingService.getBasicHttpBindingIRoutingService();
    }

    public GPSPoint getOriginPoint(){
        List<Double> originAPIFormat = bestItinerary.getPoints().getValue().getArrayOfdouble().get(0).getDouble();
        return new GPSPoint(originAPIFormat.get(originAPIFormat.size()-1), originAPIFormat.get(0));
    }

    public GPSPoint getDestinationPoint(){
        List<Double> destAPIFormat = bestItinerary.getPoints().getValue().getArrayOfdouble().get(bestItinerary.getPoints().getValue().getArrayOfdouble().size() - 1).getDouble();
        return new GPSPoint(destAPIFormat.get(destAPIFormat.size()-1),destAPIFormat.get(0));
    }

    public GPSPoint getFirstStationPoint(){
        if(bestItinerary.getPoints().getValue().getArrayOfdouble().size() == 4){
            List<Double> stationPointAPIFormat = bestItinerary.getPoints().getValue().getArrayOfdouble().get(1).getDouble();
            return new GPSPoint(stationPointAPIFormat.get(stationPointAPIFormat.size()-1),stationPointAPIFormat.get(0));
        }

        return null;
    }

    public List<GPSPoint> getWayPoints(){
        List<ArrayOfdouble> wayPointsPointAPIFormat = bestItinerary.getCoordinates().getValue().getArrayOfdouble();
        List<GPSPoint> waypts = new ArrayList<>();

        for(ArrayOfdouble latLng : wayPointsPointAPIFormat){
            waypts.add(new GPSPoint(latLng.getDouble().get(latLng.getDouble().size()-1),latLng.getDouble().get(0)));
        }

        return waypts;
    }

    public GPSPoint getLastStationPoint(){
        if(bestItinerary.getPoints().getValue().getArrayOfdouble().size() == 4){
            List<Double> stationPointAPIFormat = bestItinerary.getPoints().getValue().getArrayOfdouble().get(2).getDouble();
            return new GPSPoint(stationPointAPIFormat.get(stationPointAPIFormat.size()-1),stationPointAPIFormat.get(0));
        }
        return null;
    }

    public Double getTotalDistance(){
        return Math.round(bestItinerary.getDistance() * 100.0) / 100.0;
    }

    public void setBestItinerary(String origin, String destination) {
       bestItinerary = routingServiceInterface.getItinerary(origin,destination);
    }

    public BestItinerary getBestItinerary() {
        return bestItinerary;
    }
}
