using System;
using System.Text;
using TcpSharp;

namespace ServerApp
{
    class Program
    {
        static Dictionary<string, string> clients = new Dictionary<string, string>();
        static TcpSharpSocketServer server;

        static async Task Main(string[] args)
        {
            server = new TcpSharpSocketServer(9000);

            server.OnConnected += Server_OnConnected;
            server.OnDisconnected += Server_OnDisconnected;
            server.OnDataReceived += Server_OnDataReceived;

            server.StartListening();
            Console.WriteLine($"TCP Server is listening on port {server.Port}");

            await Task.Delay(Timeout.Infinite);
        }

        private static void Server_OnConnected(object sender, OnServerConnectedEventArgs e)
        {
            Console.WriteLine($"Client connected. ConnectionId: {e.ConnectionId}");
        }

        private static void Server_OnDisconnected(object sender, OnServerDisconnectedEventArgs e)
        {
            if (clients.ContainsKey(e.ConnectionId))
            {
                string username = clients[e.ConnectionId];
                clients.Remove(e.ConnectionId);
                Console.WriteLine($"Client disconnected: {username}");
                UpdateUserList();
                BroadcastMessage($"{username} has left the chat.");
            }
        }

        private static void Server_OnDataReceived(object sender, OnServerDataReceivedEventArgs e)
        {
            string msg = Encoding.UTF8.GetString(e.Data);
            Console.WriteLine($"RECV [{e.ConnectionId}]: {msg}");
            if (!clients.ContainsKey(e.ConnectionId) && !msg.StartsWith("JOIN|"))
            {
                Console.WriteLine("Message from unregistered client ignored.");
            }
            int pipeIndex = msg.IndexOf('|');
            string command = pipeIndex >= 0 ? msg.Substring(0, pipeIndex) : msg;

            switch (command)
            {
                case "JOIN":
                    {
                        string username = msg.Split('|')[1];
                        clients[e.ConnectionId] = username;
                        Console.WriteLine($"Client {e.ConnectionId} joined as {username}");
                        BroadcastMessage($"{username} has joined the chat.");
                        UpdateUserList();
                    }
                    break;

                case "MSG":
                    {
                        if (!clients.TryGetValue(e.ConnectionId, out var senderUser))
                        {
                            Console.WriteLine($"MSG from unknown client {e.ConnectionId}");
                            break; 
                        }

                        string[] parts = msg.Split('|');
                        if (parts.Length < 3)
                        {
                            break;
                        }

                        string targetUsername = parts[1];
                        string message = string.Join("|", parts.Skip(2));

                        if (targetUsername == "ALL")
                        {
                            BroadcastMessage($"{senderUser}: {message}");
                        }
                        else
                        {
                            var target = clients.FirstOrDefault(x => x.Value == targetUsername);
                            if (!target.Equals(default(KeyValuePair<string, string>)))
                            {
                                server.SendString(target.Key, $"[PM from {senderUser}]: {message}");
                                server.SendString(e.ConnectionId, $"[PM to {targetUsername}]: {message}");
                            }
                            else
                            {
                                server.SendString(e.ConnectionId, $"User '{targetUsername}' not found");
                            }
                        }
                    }
                    break;

                case "LEAVE":
                    {
                        if (clients.ContainsKey(e.ConnectionId))
                        {
                            string username = clients[e.ConnectionId];
                            clients.Remove(e.ConnectionId);
                            Console.WriteLine($"Client {e.ConnectionId} left: {username}");
                            UpdateUserList();
                            BroadcastMessage($"{username} has left the chat.");
                        }
                    }
                    break;

                default:
                    Console.WriteLine($"Unknown command from {e.ConnectionId}: {command}");
                    break;
            }
        }

        private static void UpdateUserList()
        {
            string userList = string.Join(",", clients.Values);
            string message = $"USERLIST|{userList}";
            string[] connectionIds = clients.Keys.ToArray();
            for (int i = 0; i < connectionIds.Length; i++)
            {
                server.SendString(connectionIds[i], message);
            }
            Console.WriteLine($"User list updated: {userList}");
        }

        private static void BroadcastMessage(string message)
        {
            string[] connectionIds = clients.Keys.ToArray();
            for (int i = 0; i < connectionIds.Length; i++)
            {
                server.SendString(connectionIds[i], message);
            }
            Console.WriteLine($"Broadcast: {message}");
        }
    }
}