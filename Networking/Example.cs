using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Networking
{
    class Example
    {
        static void Main()
        {
            int port = 666;
            string hostname = "localhost";

            // Server
            new Thread(() =>
            {
                TcpListener listener = new TcpListener(IPAddress.Any, port);
                listener.Start(); // Starts server

                // Handler loop
                while (true)
                {
                    // Blocking until a client connects to the server
                    TcpClient client = listener.AcceptTcpClient();
                    new Thread(() =>
                    {
                        using (Network<Message> net = new Network<Message>(client))
                        {
                            // Receive the Object
                            Message msg = net.ReceiveObject();
                            // Actually work with the received data
                            // HandleData(msg);

                            // Maybe send acknowledgment
                        }
                    }).Start();
                }
            }).Start();

            // Client
            new Thread(() => {
                using (Network<Message> net = new Network<Message>(new TcpClient(hostname, port)))
                {
                    // The data your sending
                    var msg = new Message()
                    {
                        Author = "Name",
                        Value = "Messagevalue",
                        ID = 1
                    };

                    net.SendObject(msg);

                    // Maybe receive acknowlegdement
                }
            }).Start();
        }
    }
}
