using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProxyCache
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8734/Server/ProxyCacheService");

            // Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(ProxyCacheService), httpUrl);
            host.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
            host.Description.Behaviors.Add(new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true });

            // Biding
            var binding = new BasicHttpBinding();
            binding.MaxBufferPoolSize = 2147483647;
            binding.MaxBufferSize = 2147483647;
            binding.MaxReceivedMessageSize = 2147483647;
            binding.ReaderQuotas.MaxStringContentLength = 2147483647;
            binding.ReaderQuotas.MaxArrayLength = 2147483647;
            binding.ReaderQuotas.MaxDepth = 2147483647;
            binding.ReaderQuotas.MaxBytesPerRead = 2147483647;

            // Add a service endpoint
            host.AddServiceEndpoint(typeof(IProxyCacheService), binding, "");

            // Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            // Start the Service
            host.Open();

            Console.WriteLine("Proxy Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press <Enter> key to stop");
            Console.ReadLine();
        }
    }
}
