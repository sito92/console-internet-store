using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CarAndHorseStore.Core.CommandParser;
using CarAndHorseStore.Infrastructure;

namespace socketserver1
{
    class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private  NinjectContainer container;
        public Server()
        {
            container = new NinjectContainer();
            this.tcpListener = new TcpListener(IPAddress.Any, 3000);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
        }
        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                
                TcpClient client = this.tcpListener.AcceptTcpClient();


                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }
        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();
            CommandParser commandParser = container.Get<CommandParser>();
            commandParser.Start();
            Encoding encoding = Encoding.GetEncoding("utf-8");

            byte[] firstresponse = encoding.GetBytes(commandParser.WelcomeMessage());
            clientStream.Write(firstresponse, 0, firstresponse.Length);

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {

                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {

                    break;
                }

                if (bytesRead == 0)
                {

                    break;
                }


               
                var messageString = encoding.GetString(message, 0, bytesRead);
                Console.WriteLine(messageString);

                var result = commandParser.ParseCommand(messageString);

                byte[] response = encoding.GetBytes(result);
                clientStream.Write(response,0,response.Length);

            }

            tcpClient.Close();
        }

        public static int Main(String[] args)
        {
            Server server = new Server();
            Console.ReadKey();
            return 0;
        }
    }

}
