using System;
using System.Collections.Generic;

namespace Singleton.DotNetOptimized
{
    public class DotNetOptimizedSingleton
    {
        // Static members are 'eagerly initialized' immediately when a class is loaded for the first time,
        // .NET guarantees thread safety for static initialization 
        private static readonly DotNetOptimizedSingleton Instance = new DotNetOptimizedSingleton();
        private List<Server> _servers;
        private Random _random = new Random();

        // Constructor (private)
        private DotNetOptimizedSingleton()
        {
            // load list of servers
            _servers = new List<Server> 
                { 
                 new Server{ Name = "ServerI", Ip = "120.14.220.18" },
                 new Server{ Name = "ServerII", Ip = "120.14.220.19" },
                 new Server{ Name = "ServerIII", Ip = "120.14.220.20" },
                 new Server{ Name = "ServerIV", Ip = "120.14.220.21" },
                 new Server{ Name = "ServerV", Ip = "120.14.220.22" },
                };
        }

        public static DotNetOptimizedSingleton GetLoadBalancer()
        {
            return Instance;
        }

        // Simple, but effective load balancer
        public Server NextServer
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }

    /// <summary>
    /// Represents a server machine
    /// </summary>
    public class Server
    {
        // Gets or sets server name
        public string Name { get; set; }

        // Gets or sets server IP address
        public string Ip { get; set; }
    }
}
