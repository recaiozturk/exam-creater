using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamCreateDemo.Web.Entity
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamArticleHeader { get; set; }
        public string ExamArticleContent  { get; set; }

        public string ExamCreatedDate { get; set; }

        public string QuestionOne { get; set; }
        public string QuestionOneAnswerA { get; set; }
        public string QuestionOneAnswerB { get; set; }
        public string QuestionOneAnswerC { get; set; }
        public string QuestionOneAnswerD { get; set; }
        public string QuestionOneCorrectAnswer { get; set; }

        public string QuestionTwo { get; set; }
        public string QuestionTwoAnswerA { get; set; }
        public string QuestionTwoAnswerB { get; set; }
        public string QuestionTwoAnswerC { get; set; }
        public string QuestionTwoAnswerD { get; set; }
        public string QuestionTwoCorrectAnswer { get; set; }

        public string QuestionThree { get; set; }
        public string QuestionThreeAnswerA { get; set; }
        public string QuestionThreeAnswerB{ get; set; }
        public string QuestionThreeAnswerC { get; set; }
        public string QuestionThreeAnswerD { get; set; }
        public string QuestionThreeCorrectAnswer { get; set; }

        public string QuestionFour { get; set; }
        public string QuestionFourAnswerA { get; set; }
        public string QuestionFourAnswerB { get; set; }
        public string QuestionFourAnswerC { get; set; }
        public string QuestionFourAnswerD { get; set; }
        public string QuestionFourCorrectAnswer { get; set; }
    }
}
