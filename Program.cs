using System;
using HtmlAgilityPack;
using System.Linq;
namespace Anime_Scraper
{
    class Program
    {
        static void Main(string[] args)
        {
          for(int j = 50; j < 2000; j += 50) {
                string Url = $"https://myanimelist.net/character.php?limit={j}";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(Url);
                HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a[contains(@class, 'fs14 ')]").ToArray();
                HtmlNode[] nodes2 = doc.DocumentNode.SelectNodes("//td[contains(@class, 'animeography')]").ToArray();
                for(int i = 0; i < nodes.Length; i++) {
                    using (System.IO.StreamWriter file =
                    new System.IO.StreamWriter(@"/home/af2111/Schreibtisch/Coding/C#/AnimeShippingGen/input.txt", true))
                    {
                        file.WriteLine($"{nodes[i].InnerText}; {nodes2[i + 1].InnerText}");
                    }   
                }
            }
            
            
            
        }
       
    }
 

}
