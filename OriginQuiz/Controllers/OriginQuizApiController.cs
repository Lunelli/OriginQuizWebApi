using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OriginQuiz.Models;
using OriginQuiz.Services;

namespace OriginQuiz.Controllers
{
    [ApiController]
    [Route("quiz")]
    public class OriginQuizApiController : ControllerBase
    {
        [HttpGet]
        public List<Question> Get()
        {
            return new OriginQuizService().getQuizQuestions();
        }

        [HttpPost]
        public ActionResult<Result> Post(List<Answer> answers)
        {
            return new OriginQuizService().getQuizResult(answers);
        }
    }
}
