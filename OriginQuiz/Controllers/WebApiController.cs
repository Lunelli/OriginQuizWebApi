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
    [Route("/")]
    public class WebApiController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            return "Great, things are up and running! Please visit /quiz for Origin Quiz specific endpoints.";
        }

    }
}
