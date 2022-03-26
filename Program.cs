using System;
using HtmlAgilityPack;

namespace hangman_of_the_day
{
    class Program
    {
        static string GetWordOfTheDay()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load("https://www.dictionary.com/e/word-of-the-day/");

            HtmlNode wordNode = doc.DocumentNode.SelectSingleNode("/html/body/div/div[2]/div[3]/div[1]/div/div[1]/div[3]/div[1]/div/div[3]/h1");
            return wordNode.InnerText;
        }

        static void Main(string[] args)
        {
            Hangman game = new Hangman(GetWordOfTheDay());
        }
    }
}
