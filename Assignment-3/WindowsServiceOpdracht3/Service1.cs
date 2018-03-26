/*
 *Application name  : Opdracht 3 webservice
 *Author            : Team firefly
*/

using System.Diagnostics;

namespace WindowsServiceOpdracht3
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection;
    using System.ServiceProcess;
    using System.Text;
    public partial class Service1 : ServiceBase
    {
        private readonly Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

        public Service1()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Checks request
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private static bool CheckRequest(string input, string pattern)
        {
            if (!string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(pattern))
            {
                if (input.Contains(pattern)) return true;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     runs function on start
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Any, 9999));
            _socket.Listen(10);
            _socket.BeginAccept(SocketAccept, null);
        }

        /// <summary>
        ///     Begins an asynchronous operation to accept an incoming connection attempt.
        /// </summary>
        /// <param name="ar"></param>
        private void SocketAccept(IAsyncResult ar)
        {
            string responseCode = "200 OK";
            string Servername = "mijnserver";
            string contentType = "text/html";
            string sitesLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\site\\";
            string getTestPage = File.ReadAllText(sitesLocation + @"test.html");
            string getPage1 = File.ReadAllText(sitesLocation + @"page1.html");

            try
            {
                using (Socket clientSocket = _socket.EndAccept(ar))
                {
                    byte[] buffer = new byte[8000];
                    var receivedCount = clientSocket.Receive(buffer);

                    string headerTestPage = string.Format("HTTP/1.1 {0} \r\n" +
                                                          "Server: {1} \r\n" +
                                                          "Content-length: {2} \r\n" +
                                                          "Content-Type: {3} ; charset=utf-8 \r\n" +
                                                          "\r\n", responseCode, Servername, getTestPage.Length,
                        contentType);


                    var headerPage1 = string.Format("HTTP/1.1 {0} \r\n" +
                                                       "Server: {1} \r\n" +
                                                       "Content-length: {2} \r\n" +
                                                       "Content-Type: {3} ; charset=utf-8 \r\n" +
                                                       "\r\n", responseCode, Servername, getPage1.Length, contentType);


                    byte[] headerTestPageToClient = Encoding.UTF8.GetBytes(headerTestPage);
                    byte[] headerPage1ToClient = Encoding.UTF8.GetBytes(headerPage1);


                    byte[] testPageToClient = Encoding.UTF8.GetBytes(getTestPage);
                    byte[] page1ToClient = Encoding.UTF8.GetBytes(getPage1);

                    var swapped = Encoding.UTF8.GetString(buffer, 0, receivedCount);

                    if (CheckRequest(swapped, "test") == true)
                    {
                        clientSocket.Send(
                            headerTestPageToClient);

                        clientSocket.Send(
                            testPageToClient);
                        clientSocket.Close();
                    }

                    if (CheckRequest(swapped, "page") == true)
                    {
                        clientSocket.Send(
                            headerPage1ToClient);

                        clientSocket.Send(
                            page1ToClient);
                        clientSocket.Close();
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                _socket.BeginAccept(SocketAccept, null);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        ///     closes socket on stop
        /// </summary>
        protected override void OnStop()
        {
            _socket.Close();
        }
    }
}