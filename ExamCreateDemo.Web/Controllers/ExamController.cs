using ExamCreateDemo.Web.Data;
using ExamCreateDemo.Web.Entity;
using ExamCreateDemo.Web.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ExamCreateDemo.Web.Controllers
{
    public class ExamController : Controller
    {
        private readonly ExamContext _context;

        public ExamController(ExamContext context)
        {
            _context = context;
            
        }

       
        public IActionResult CreateExam()
        {
           
            //LoadArticles();

            return View(new ExamCreateViewModel
            {

                Articles = _context.Articles.Take(5).ToList()
            }); 
        }

        [HttpPost]
        public IActionResult CreateExam(ExamCreateViewModel exam)
        {

            //ArticleContent TextArea sorunu yuzunden Article Content kısmına boyle ulaştık
            var model = _context.Articles.Where(a => a.Header == exam.ExamArticleHeader).First();
            var article = model.ArticleContent;

            _context.Exams.Add(new Exam
            {
                ExamArticleHeader=exam.ExamArticleHeader,
                ExamArticleContent= article,
                ExamCreatedDate= DateTime.Now.ToString("dd-MM-yyyy"),

                QuestionOne =exam.QuestionOne,
                QuestionOneAnswerA=exam.QuestionOneAnswerA,
                QuestionOneAnswerB = exam.QuestionOneAnswerB,
                QuestionOneAnswerC = exam.QuestionOneAnswerC,
                QuestionOneAnswerD = exam.QuestionOneAnswerD,
                QuestionOneCorrectAnswer = exam.QuestionOneCorrectAnswer,

                QuestionTwo = exam.QuestionTwo,
                QuestionTwoAnswerA = exam.QuestionTwoAnswerA,
                QuestionTwoAnswerB = exam.QuestionTwoAnswerB,
                QuestionTwoAnswerC = exam.QuestionTwoAnswerC,
                QuestionTwoAnswerD = exam.QuestionTwoAnswerD,
                QuestionTwoCorrectAnswer = exam.QuestionTwoCorrectAnswer,

                QuestionThree = exam.QuestionThree,
                QuestionThreeAnswerA = exam.QuestionThreeAnswerA,
                QuestionThreeAnswerB = exam.QuestionThreeAnswerB,
                QuestionThreeAnswerC = exam.QuestionThreeAnswerC,
                QuestionThreeAnswerD = exam.QuestionThreeAnswerD,
                QuestionThreeCorrectAnswer = exam.QuestionThreeCorrectAnswer,

                QuestionFour = exam.QuestionThree,
                QuestionFourAnswerA = exam.QuestionFourAnswerA,
                QuestionFourAnswerB = exam.QuestionFourAnswerB,
                QuestionFourAnswerC = exam.QuestionFourAnswerC,
                QuestionFourAnswerD = exam.QuestionFourAnswerD,
                QuestionFourCorrectAnswer = exam.QuestionFourCorrectAnswer

            });

            _context.SaveChanges();



            return RedirectToAction("ExamList");

        }

        public IActionResult GetArticle(string id)
        {
            var model = _context.Articles.Where(a => a.Header == id).First();
            var article = model.ArticleContent;

            return new JsonResult(article);
        }
        


        public IActionResult ExamDetail(int id)
        {
            var exam = _context.Exams.Find(id);
            return View(exam);
        }

        public IActionResult GetAnswersValues(int Id)
        {
            
            
            var model = _context.Exams.Find(Id);
            var corretAnswer1 = model.QuestionOneCorrectAnswer;
            var corretAnswer2 = model.QuestionTwoCorrectAnswer;
            var corretAnswer3 = model.QuestionThreeCorrectAnswer;
            var corretAnswer4 = model.QuestionFourCorrectAnswer;

            Answers answer = new Answers();

            
            answer.Answer1 = corretAnswer1;
            answer.Answer2 = corretAnswer2;
            answer.Answer3 = corretAnswer3;
            answer.Answer4 = corretAnswer4;

            return new JsonResult(answer);
        }

        public IActionResult ExamList()
        {
            var exams = _context.Exams.OrderByDescending(x=>x.ExamId).ToList();
            return View(exams);
        }

        
        public IActionResult ExamDelete(int id)
        {
            var exam = _context.Exams.Find(id);
            _context.Exams.Remove(exam);
            _context.SaveChanges();

            return RedirectToAction("ExamList");
        }



        public  void LoadArticles()
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
            for (int i = 1; i < 6; i++)
            {
                header = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li[" + i + "]/div/a/h2")[0].InnerText;
                headers.Add(header);

                HtmlNode node = dokumantHeadText.DocumentNode.SelectNodes("/html/body/div[3]/div/div[3]/div/div[2]/div/div[1]/div/div/ul/li[" + i + "]/a")[0];
                string hrefValue = node.GetAttributeValue("href", string.Empty);
                Uri url2 = new Uri("https://www.wired.com" + hrefValue);
                string html2 = client.DownloadString(url2);
                HtmlAgilityPack.HtmlDocument dokumantforHref = new HtmlAgilityPack.HtmlDocument();
                dokumantforHref.LoadHtml(html2);               
                string yazi = dokumantforHref.DocumentNode.SelectNodes("/html/body/div[1]/div/main/article/div[2]/div/div[1]/div/div[1]")[0].InnerText;

                //karakter sorunları icin decode yapıyoruz
                StringWriter myWriter = new StringWriter();
                HttpUtility.HtmlDecode(yazi, myWriter);
                string myDecodedString = myWriter.ToString();
                articles.Add(myDecodedString);

            }


            for (int i = 0; i < 5; i++)
            {


                Article model = new Article();
                model.ArticleId = i+1;
                model.ArticleContent = articles[i];
                model.Header = headers[i];

                var entity = _context.Articles.Find(i+1);

                if (entity != null)
                {
                    _context.Articles.Remove(entity);
                    _context.SaveChanges();
                }


                
                _context.Add(model);
                _context.SaveChanges();
            }



        }
    }
}
