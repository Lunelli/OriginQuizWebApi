using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OriginQuiz.Models;

namespace OriginQuiz.Services
{
    public class OriginQuizService
    {

        public List<Question> getQuizQuestions()
        {
            var question1 = new Question();
            question1.id = "1";
            question1.question = "Qual a origem da BMW?";
            question1.addOption("a", "Inglaterra");
            question1.addOption("b", "USA");
            question1.addOption("c", "Alemanha");
            question1.addOption("d", "Japão");
            question1.correctOptionId = "c";

            var question2 = new Question();
            question2.id = "2";
            question2.question = "Qual a origem da Toyota?";
            question2.addOption("a", "Inglaterra");
            question2.addOption("b", "USA");
            question2.addOption("c", "Alemanha");
            question2.addOption("d", "Japão");
            question2.correctOptionId = "d";

            var question3 = new Question();
            question3.id = "3";
            question3.question = "Qual a origem da Mini?";
            question3.addOption("a", "Inglaterra");
            question3.addOption("b", "USA");
            question3.addOption("c", "Alemanha");
            question3.addOption("d", "Japão");
            question3.correctOptionId = "a";

            var question4 = new Question();
            question4.id = "4";
            question4.question = "Qual a origem da General Motors?";
            question4.addOption("a", "Inglaterra");
            question4.addOption("b", "USA");
            question4.addOption("c", "Alemanha");
            question4.addOption("d", "Japão");
            question4.correctOptionId = "b";

            var question5 = new Question();
            question5.id = "5";
            question5.question = "Qual a origem da Rolls-Royce?";
            question5.addOption("a", "Inglaterra");
            question5.addOption("b", "USA");
            question5.addOption("c", "Alemanha");
            question5.addOption("d", "Japão");
            question5.correctOptionId = "a";

            return new List<Question> { question1, question2, question3, question4, question5 };
        }

        public ActionResult<Result> getQuizResult(List<Answer> answers)
        {
            var hit = 0;
            var questions = new OriginQuizService().getQuizQuestions();

            foreach (var answer in answers)
            {
                var question = questions.Find(x => x.id == answer.questionId);
                if (question != null && question.correctOptionId == answer.answerId) hit++;
            }

            double hitPercentage = ((double)hit / questions.Count) * 100;
            var statement = $"Teste finalizado! Você pontuou {hitPercentage}% de acertos!";

            var result = new Result();
            result.statement = statement;
            result.hitPercentage = hitPercentage;

            return result;
        }

    }
}
