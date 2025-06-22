using NettyCSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Netty
{
    public class ConnectionHandler
    {
        public static NettyClient nettyClient = new NettyClient(System.Net.IPAddress.Parse(Const.server), Const.port);

        public static void connect()
        {
            new Task(() =>
            {
                nettyClient.init();
                nettyClient.StartClient();
            }).Start();
        }
    }
}
