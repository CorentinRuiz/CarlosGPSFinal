
package com.baeldung.soap.ws.client.generated;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlElementRef;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour BestItinerary complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="BestItinerary"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="Coordinates" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfArrayOfdouble" minOccurs="0"/&gt;
 *         &lt;element name="Distance" type="{http://www.w3.org/2001/XMLSchema}double" minOccurs="0"/&gt;
 *         &lt;element name="Instructions" type="{http://schemas.datacontract.org/2004/07/OSMElement}ArrayOfInstruction" minOccurs="0"/&gt;
 *         &lt;element name="Points" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfArrayOfdouble" minOccurs="0"/&gt;
 *         &lt;element name="Time" type="{http://www.w3.org/2001/XMLSchema}int" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "BestItinerary", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", propOrder = {
    "coordinates",
    "distance",
    "instructions",
    "points",
    "time"
})
public class BestItinerary {

    @XmlElementRef(name = "Coordinates", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArrayOfdouble> coordinates;
    @XmlElement(name = "Distance")
    protected Double distance;
    @XmlElementRef(name = "Instructions", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfInstruction> instructions;
    @XmlElementRef(name = "Points", namespace = "http://schemas.datacontract.org/2004/07/RoutingServer", type = JAXBElement.class, required = false)
    protected JAXBElement<ArrayOfArrayOfdouble> points;
    @XmlElement(name = "Time")
    protected Integer time;

    /**
     * Obtient la valeur de la propriété coordinates.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfdouble }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArrayOfdouble> getCoordinates() {
        return coordinates;
    }

    /**
     * Définit la valeur de la propriété coordinates.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfdouble }{@code >}
     *     
     */
    public void setCoordinates(JAXBElement<ArrayOfArrayOfdouble> value) {
        this.coordinates = value;
    }

    /**
     * Obtient la valeur de la propriété distance.
     * 
     * @return
     *     possible object is
     *     {@link Double }
     *     
     */
    public Double getDistance() {
        return distance;
    }

    /**
     * Définit la valeur de la propriété distance.
     * 
     * @param value
     *     allowed object is
     *     {@link Double }
     *     
     */
    public void setDistance(Double value) {
        this.distance = value;
    }

    /**
     * Obtient la valeur de la propriété instructions.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfInstruction }{@code >}
     *     
     */
    public JAXBElement<ArrayOfInstruction> getInstructions() {
        return instructions;
    }

    /**
     * Définit la valeur de la propriété instructions.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfInstruction }{@code >}
     *     
     */
    public void setInstructions(JAXBElement<ArrayOfInstruction> value) {
        this.instructions = value;
    }

    /**
     * Obtient la valeur de la propriété points.
     * 
     * @return
     *     possible object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfdouble }{@code >}
     *     
     */
    public JAXBElement<ArrayOfArrayOfdouble> getPoints() {
        return points;
    }

    /**
     * Définit la valeur de la propriété points.
     * 
     * @param value
     *     allowed object is
     *     {@link JAXBElement }{@code <}{@link ArrayOfArrayOfdouble }{@code >}
     *     
     */
    public void setPoints(JAXBElement<ArrayOfArrayOfdouble> value) {
        this.points = value;
    }

    /**
     * Obtient la valeur de la propriété time.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getTime() {
        return time;
    }

    /**
     * Définit la valeur de la propriété time.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setTime(Integer value) {
        this.time = value;
    }

}
