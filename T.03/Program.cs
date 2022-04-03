using System;
using System.Collections.Generic;
using System.Linq;

namespace T._03
{
    class Messages
    {
        public Messages(int sent, int received)
        {
            this.Sent = sent;
            this.Received = received;
        }

        public int Sent { get; set; }

        public int Received { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Messages> messagesStatistics = new Dictionary<string, Messages>();

            int maxCapacity = int.Parse(Console.ReadLine());

            string command;
            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] cmdArgs = command
                    .Split('=', StringSplitOptions.RemoveEmptyEntries);

                string action = cmdArgs[0];

                if (action == "Add")
                {
                    string username = cmdArgs[1];

                    if (!messagesStatistics.ContainsKey(username))
                    {
                        int sent = int.Parse(cmdArgs[2]);
                        int received = int.Parse(cmdArgs[3]);

                        messagesStatistics.Add(username, new Messages(sent, received));
                    }
                }
                else if (action == "Message")
                {
                    string sender = cmdArgs[1];
                    string receiver = cmdArgs[2];

                    if (messagesStatistics.ContainsKey(sender) && messagesStatistics.ContainsKey(receiver))
                    {
                        messagesStatistics[sender].Sent++;
                        messagesStatistics[receiver].Received++;

                        int totalMessagesForSender = messagesStatistics[sender].Sent + messagesStatistics[sender].Received;
                        int totalMessagesForReceiver = messagesStatistics[receiver].Sent + messagesStatistics[receiver].Received;

                        if (totalMessagesForSender >= maxCapacity)
                        {
                            messagesStatistics.Remove(sender);
                            Console.WriteLine($"{sender} reached the capacity!");
                        }

                        if (totalMessagesForReceiver >= maxCapacity)
                        {
                            messagesStatistics.Remove(receiver);
                            Console.WriteLine($"{receiver} reached the capacity!");
                        }
                    }
                }
                else if (action == "Empty")
                {
                    string username = cmdArgs[1];

                    if (username == "All")
                    {
                        if (messagesStatistics.Any())
                        {
                            messagesStatistics.Clear();
                        }
                    }
                    else
                    {
                        if (messagesStatistics.ContainsKey(username))
                        {
                            messagesStatistics.Remove(username);
                        }
                    }
                }
            }

            foreach (KeyValuePair<string, Messages> user in messagesStatistics)
            {
                int totalMessages = user.Value.Sent + user.Value.Received;

                if (totalMessages >= maxCapacity)
                {
                    Console.WriteLine($"{user.Key} reached the capacity!");
                    messagesStatistics.Remove(user.Key);
                }
            }

            Console.WriteLine($"Users count: {messagesStatistics.Count}");

            foreach (KeyValuePair<string, Messages> user in messagesStatistics)
            {
                int totalMessages = user.Value.Sent + user.Value.Received;
                Console.WriteLine($"{user.Key} - {totalMessages}");
            }
        }
    }
}
