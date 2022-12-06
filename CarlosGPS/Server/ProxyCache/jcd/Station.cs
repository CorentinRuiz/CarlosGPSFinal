using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    public class Station
    {
        public int number { get; set; }
        public Position position { get; set; }
        public TotalStands totalStands { get; set; }
        public string status { get; set; }
    }

    public class Position
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class TotalStands
    {
        public Availabilities availabilities { get; set; }
    }

    public class Availabilities
    {
        public int stands { get; set; }

        public int bikes { get; set; }
    }
}
