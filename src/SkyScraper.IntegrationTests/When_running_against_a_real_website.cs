using System.Diagnostics;
using NUnit.Framework;
using System;
using System.Threading;
using SkyScraper.Observers.ConsoleWriter;

namespace SkyScraper.IntegrationTests
{
    [TestFixture]
    [Explicit]
    class When_running_against_a_real_website
    {
        [Test]
        public void Then_images_should_be_saved()
        {
            var sw = Stopwatch.StartNew();
            var scraper = new Scraper(new HttpClient(), new ScrapedUrisDictionary());
            //var io = new ImageScraperObserver(new HttpClient(), new FileWriter(new DirectoryInfo("c:\\temp")));
            //scraper.Subscribe(io);
            scraper.Subscribe(new ConsoleWriterObserver());
            scraper.Scrape(new Uri("http://www.cambridgecupcakes.com/")).Wait();
            Console.WriteLine(sw.ElapsedMilliseconds);
            //Thread.Sleep(10000);
        }
    }
}