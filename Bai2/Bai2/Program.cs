using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Bai2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Parse("172.16.0.1"), 80);
            //try
            //{
            //    TcpClient tcp = new TcpClient();
            //    tcp.Connect(ipe);
            //    Console.Write(ipe.ToString() + " is open.");
            //    Console.WriteLine();
            //    tcp.Close();
            //}
            //catch
            //{
            //    Console.WriteLine(ipe.ToString() + " is close.");
            //    Console.WriteLine();
            //}

            UdpClient udp = new UdpClient();
            udp.Connect(ipe);
            byte[] data = Encoding.ASCII.GetBytes("Hello");
            udp.Send(data, data.Length);
            try
            {
                udp.Receive(ref ipe);
                Console.WriteLine(ipe.ToString() + " is open.");
                Console.WriteLine();
                udp.Close();
            }
            catch {
                Console.WriteLine(ipe.ToString() + " is close.");
            }
        }
    }
}
