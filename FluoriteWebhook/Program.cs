using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebHook_Sender_Library;
using System.Net;
using System.IO;

namespace FluoriteWebHook
{
    class Program
    {
        static void Main(string[] args)
        {
            start();
            void start()
            {
                Console.WriteLine("Welcome to Fluorite Webhook Utilities");
                Console.WriteLine("1. Spam Discord Webhook");
                Console.WriteLine("2. Send message to Webhook");
                Console.WriteLine("3. Delete Discord Webhook");
                string response = Console.ReadLine();
                if (response == "1")
                {

                    spam();
                }
                else if (response == "2")
                {
                    send();
                }
                else if (response == "3")
                {
                    delete();
                }
                else
                {
                    Console.Clear();
                    start();
                }
            }
            void spam()
            {
                Console.Clear();
                Console.WriteLine("Enter Webhook To Spam: ");
                Console.Write("  >>");
                var webhook = Console.ReadLine();
                Console.WriteLine("Enter Message To Spam: ");
                Console.Write("  >>");
                var message = Console.ReadLine();
                Console.WriteLine("Enter How Much To Spam: ");
                Console.Write("  >>");
                var times = Console.ReadLine();
                WebHookSender.Send(webhook, message, Convert.ToInt32(times));
                Console.Clear();
                Console.WriteLine("Spamming...");
                Console.ReadLine();
                start();
            }
            void send()
            {
                Console.Clear();
                Console.WriteLine("Enter Webhook To Send: ");
                Console.Write("  >>");
                var webhook = Console.ReadLine();
                Console.WriteLine("Enter Message To Send: ");
                Console.Write("  >>");
                var message = Console.ReadLine();
                
                WebHookSender.Send(webhook, message, 1);
                Console.Clear();
                Console.WriteLine("Sent...");
                Console.ReadLine();
                start();
            }
            void delete()
            {
                Console.Clear();
                Console.WriteLine("Input Webhook to Delete");
                Console.Write("  >>");
                string webhook = Console.ReadLine();
                deletereq(webhook);
            }
            void deletereq(string webhook)
            {
                try
                {
                    HttpWebRequest Req = (HttpWebRequest)WebRequest.Create(webhook);
                    byte[] bytes = Encoding.ASCII.GetBytes("{}");
                    Req.Method = "DELETE";
                    Req.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_6) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
                    Req.ContentLength = (long)bytes.Length;
                    using (Stream requestStream = Req.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                    }
                    HttpWebResponse httpWebResponse = (HttpWebResponse)Req.GetResponse();
                    Console.WriteLine("Webhook Deleted.");
                    Console.ReadLine();
                    start();
                   
                }
                catch (Exception ex)
                {
                    
                }
            }
        }
        
    }
}
