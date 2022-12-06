
package com.baeldung.soap.ws.client.generated;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Classe Java pour ArrayOfArrayOfdouble complex type.
 * 
 * <p>Le fragment de schéma suivant indique le contenu attendu figurant dans cette classe.
 * 
 * <pre>
 * &lt;complexType name="ArrayOfArrayOfdouble"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="ArrayOfdouble" type="{http://schemas.microsoft.com/2003/10/Serialization/Arrays}ArrayOfdouble" maxOccurs="unbounded" minOccurs="0"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ArrayOfArrayOfdouble", propOrder = {
    "arrayOfdouble"
})
public class ArrayOfArrayOfdouble {

    @XmlElement(name = "ArrayOfdouble", nillable = true)
    protected List<ArrayOfdouble> arrayOfdouble;

    /**
     * Gets the value of the arrayOfdouble property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the arrayOfdouble property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getArrayOfdouble().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link ArrayOfdouble }
     * 
     * 
     */
    public List<ArrayOfdouble> getArrayOfdouble() {
        if (arrayOfdouble == null) {
            arrayOfdouble = new ArrayList<ArrayOfdouble>();
        }
        return this.arrayOfdouble;
    }

}
