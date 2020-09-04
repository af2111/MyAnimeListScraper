using System;
using HtmlAgilityPack;
using System.Linq;
using System.Diagnostics;
using System.Threading;
namespace Anime_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
        Console.WriteLine("Gib einen Suchbegriff ein.");
        String Suchbegriff = Console.ReadLine();
        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        int QueryResults = 0;
          for(int j = 0; j < 1000; j += 50) {
                string Url = $"https://myanimelist.net/character.php?limit={j}";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);
                HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'fs14 ')]").ToArray();
                HtmlNode[] nodes2 = doc.DocumentNode.SelectNodes("//td[contains(@class, 'animeography')]").Skip(1).ToArray();
                for(int i = 0; i < nodes.Length; i++) {
                    if(nodes[i].InnerText.Contains(Suchbegriff) || nodes2[i].InnerText.Contains(Suchbegriff)) {
                        using (System.IO.StreamWriter file =
                        new System.IO.StreamWriter(@"/home/af2111/Schreibtisch/Coding/C#/AnimeShippingGen/input.txt", true))
                        {
                        QueryResults++;
                        file.WriteLine($"{nodes[i].InnerText}; {nodes2[i].InnerText}");
                        }
                    }
                    else {
                        continue;
                    }
                       
                }
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);     
            Console.WriteLine($"Zeit gebraucht: " + elapsedTime);       
            Console.WriteLine($"{QueryResults} Ergebnisse gefunden.");
            
        }
       
    }
 

}
