using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using socketclient1.Infrastructure;

namespace socketclient1
{
    public class StateObject
    {
        // Client socket.
        public Socket workSocket = null;
        // Size of receive buffer.
        public const int BufferSize = 256;
        // Receive buffer.
        public byte[] buffer = new byte[BufferSize];
        // Received data string.
        public StringBuilder sb = new StringBuilder();
    }

    public class AsynchronousClient
    {
        

        public static int Main(String[] args)
        {
            TcpClient client = new TcpClient();

            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000);

            client.Connect(serverEndPoint);

            NetworkStream clientStream = client.GetStream();

            Encoding encoding = Encoding.GetEncoding("utf-8");
            
            try
            {


                while (true)
                {
                    byte[] bufferread = new byte[4096];
                    clientStream.Read(bufferread, 0, bufferread.Length);
                    Console.WriteLine(encoding.GetString(bufferread.Where(x => x != 0).ToArray()));

                    var message = Console.ReadLine();
                    ClientActionManager.PerformAction(message);

                    byte[] bufferwrite = encoding.GetBytes(message);

                    clientStream.Write(bufferwrite, 0, bufferwrite.Length);
                    clientStream.Flush();



                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
            return 0;
        }
    }
}
