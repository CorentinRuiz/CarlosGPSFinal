using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OSMElement
{
    [DataContract]
    public class Itinerary
    {
        [DataMember]
        public int time { get; set; }
        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public Point points { get; set; }
        [DataMember]
        public List<Instruction> instructions { get; set; }
    }

    [DataContract]
    public class Point
    {
        [DataMember]
        public List<Double[]> coordinates { get; set; }
    }

    [DataContract]
    public class Instruction
    {
        public Instruction(double distance, string text)
        {
            this.distance = distance;
            this.text = text;
        }

        [DataMember]
        public double distance { get; set; }
        [DataMember]
        public string text { get; set; }
    }
}
