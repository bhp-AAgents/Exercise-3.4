using System;
using System.IO;
using System.Net;

namespace Exercise_3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter URL: ");
            string urlStr = Console.ReadLine();

            Uri url = new UriBuilder(urlStr).Uri;
            string host = url.Host;
            Uri robotsTxtUrl = new UriBuilder(host + "/robots.txt").Uri;
            
            try
            {
                WebClient wc = new WebClient();
                wc.Headers.Add(HttpRequestHeader.UserAgent, "bhp-bot; CS student practice crawler; Developer: Bent H. Pedersen (bhp@easv.dk)");
                wc.Headers.Add(HttpRequestHeader.From, "bhp@easv.dk");
                
                String robotstxt = wc.DownloadString(robotsTxtUrl.ToString());
                Console.WriteLine(robotstxt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
