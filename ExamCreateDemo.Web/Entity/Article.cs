using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Entity
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Header { get; set; }
        public string ArticleContent { get; set; }
    }
}
