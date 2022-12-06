using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace RoutingServer
{
    public class Address
    {
        public Point point { get; set; }

        public Address() { }
    }

    public class Point
    {
        public double lng { get; set; }
        public double lat { get; set; }
    }
}
