using ExamCreateDemo.Web.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExamCreateDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
           //Console.WriteLine(HttpContext.Session.GetString("sessionUsername"));
            return View();
        }

        public IActionResult Test()
        {
            //Veri çekeceğimiz sitenin url'sini yazıyoruz.
            Uri url = new Uri("https://www.wired.com/most-recent/");
            WebClient client = new WebClient(); //Siteyi indirmek için bir WebClient sınıfından bir client oluşturuyoruz.
            client.Encoding = Encoding.UTF8;
            string html = client.DownloadString(url); //WebClient üzerinden indirdiğimiz kodlarımızı html değişkenine atıyoruz.
            // Yazdığımız urlden html kodlarını indiriyoruz. 
            HtmlAgilityPack.HtmlDocument dokumantHeadText = new HtmlAgilityPack.HtmlDocument();
            dokumantHeadText.LoadHtml(html);
            // İndirdiğimiz html kodlarını bir HtmlDocument nesnesine yüklüyoruz. 
            string baslik = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li[1]/div/a/h2")[0].InnerText;
            //string baslik2 = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li[2]/div/a/h2")[0].InnerText;

            List<string> headers = new List<string>();
            List<string> articles = new List<string>();
            string header;
            for (int i = 1; i <6; i++)
            {
                header = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li["+i+"]/div/a/h2")[0].InnerText;
                headers.Add(header);

                HtmlNode node = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li["+i+"]/a")[0];
                string hrefValue = node.GetAttributeValue("href", string.Empty);
                Uri url2 = new Uri("https://www.wired.com" + hrefValue);
                string html2 = client.DownloadString(url2);
                HtmlAgilityPack.HtmlDocument dokumantforHref = new HtmlAgilityPack.HtmlDocument();
                dokumantforHref.LoadHtml(html2);
                //string yazi = dokumantforHref.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div[1]/div[1]/div[1]/div/div[1]/div")[0].InnerText;
                string yazi = dokumantforHref.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div/div[1]")[0].InnerText;

                //karakter sorunları icin decode yapıyoruz
                StringWriter myWriter = new StringWriter();
                HttpUtility.HtmlDecode(yazi, myWriter);
                string myDecodedString = myWriter.ToString();
                articles.Add(myDecodedString);

            }

            List<ArticlesViewModel> articleModels = new List<ArticlesViewModel>();

            for (int i = 0; i < 5; i++)
            {
                articleModels.Add(new ArticlesViewModel
                {
                    Id=i,
                    HeaderName=headers[i],
                    Article=articles[i]
                });
            }



            ViewBag.ArticleModels = articleModels;

            return View(/*articleModels*/);
        }
    }
}
