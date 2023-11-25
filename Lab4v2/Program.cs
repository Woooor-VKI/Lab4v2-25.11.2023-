using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using Library;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4v2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(); // Создание объекта-браузера
            driver.Navigate().GoToUrl("https://pikabu.ru/best");
            var articles = driver.FindElements(By.ClassName("story"));

            Console.WriteLine(articles.Count);

            foreach (var article in articles)
            {
                var message = article.FindElement(By.ClassName("story__title")).Text;
                var name = article.GetAttribute("data-author-name");
                var id = article.GetAttribute("data-story-id");

                Console.WriteLine($"{id} - {name} - {message}");

                // ApplicationData bd = new ApplicationData();
                // bd.AddRecord(name,message);
            }
            driver.Quit();
        }
    }
}
