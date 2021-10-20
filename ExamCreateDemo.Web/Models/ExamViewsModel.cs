using ExamCreateDemo.Web.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Models
{
    public class ExamViewsModel
    {

    }

    

    public class ExamCreateViewModel
    {
        public int ExamId { get; set; }
        public string ExamArticleHeader { get; set; }
        public string ExamArticleContent { get; set; }

        

        [Required]
        public string QuestionOne { get; set; }
        [Required]
        public string QuestionOneAnswerA { get; set; }
        [Required]
        public string QuestionOneAnswerB { get; set; }
        [Required]
        public string QuestionOneAnswerC { get; set; }
        [Required]
        public string QuestionOneAnswerD { get; set; }
        [Required]
        public string QuestionOneCorrectAnswer { get; set; }
        [Required]
        public string QuestionTwo { get; set; }
        [Required]
        public string QuestionTwoAnswerA { get; set; }
        [Required]
        public string QuestionTwoAnswerB { get; set; }
        [Required]
        public string QuestionTwoAnswerC { get; set; }
        [Required]
        public string QuestionTwoAnswerD { get; set; }
        [Required]
        public string QuestionTwoCorrectAnswer { get; set; }
        [Required]
        public string QuestionThree { get; set; }
        [Required]
        public string QuestionThreeAnswerA { get; set; }
        [Required]
        public string QuestionThreeAnswerB { get; set; }
        [Required]
        public string QuestionThreeAnswerC { get; set; }
        [Required]
        public string QuestionThreeAnswerD { get; set; }
        [Required]
        public string QuestionThreeCorrectAnswer { get; set; }
        [Required]
        public string QuestionFour { get; set; }
        [Required]
        public string QuestionFourAnswerA { get; set; }
        [Required]
        public string QuestionFourAnswerB { get; set; }
        [Required]
        public string QuestionFourAnswerC { get; set; }
        [Required]
        public string QuestionFourAnswerD { get; set; }
        [Required]
        public string QuestionFourCorrectAnswer { get; set; }


        public List<Article> Articles { get; set; }

        public string ChoosenArticle { get; set; }
    }
}
