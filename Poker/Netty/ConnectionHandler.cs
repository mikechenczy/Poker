using Poker.Netty.Client;

namespace Poker.Netty
{
    public class ConnectionHandler
    {
        public static NettyClient nettyClient = new NettyClient();

        public static void connect()
        {
            nettyClient.doConnect();
        }
    }
}
