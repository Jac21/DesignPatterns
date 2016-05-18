using System;
using System.Collections.Generic;

namespace Singleton.RealWorld
{
    public class RealWorldSingletonLoadBalancer
    {
        private static RealWorldSingletonLoadBalancer _instance;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor (protected)
        protected RealWorldSingletonLoadBalancer()
        {
            // List of available servers
            _servers.Add("ServerOne");
            _servers.Add("ServerTwo");
            _servers.Add("ServerThree");
            _servers.Add("ServerFour");
        }

        public static RealWorldSingletonLoadBalancer GetLoadBalancer()
        {
            // support multithreaded applications through 'double checked locking'
            // pattern which (once instance exists) avoids locking each time method is invoked
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance == null)
                    {
                        _instance = new RealWorldSingletonLoadBalancer();
                    }
                }
            }

            return _instance;
        }

        // random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r];
            }
        }
    }
}
