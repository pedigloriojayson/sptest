using Microsoft.AspNetCore.Mvc;
using SurveyRestApi.DataAccessLayer;
using SurveyRestApi.Dtos;

namespace SurveyRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveyController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SurveyController> _logger;
        private readonly IDb _db;

        public SurveyController(IDb db, ILogger<SurveyController> logger)
        {
            _db = db;
            _logger = logger;
        }


        [HttpGet("GetOptionalAnswers")]
        public ActionResult<DtoCompiledAnswer> GetOptionalAnswers(int surveyID)
        {
            var res = _db.GetOptionalAnswersFromSurveyId(surveyID);

            if (res.Count() == 0) return NotFound("No Optional Answers Found!");

            else
                return new DtoCompiledAnswer()
                {
                    Answers = res.GroupBy(y => y.AnswerId).Select(y => new DtoSurveyAnswerInfo()
                    {
                        Id = y.Key,
                        Options = y.Select(s => new KeyValuePair<int, string>(s.AnswerKey, s.AnswerDescription)).ToArray()
                    }).ToArray()
                };


        }

        [HttpGet("GetQuestions")]
        public ActionResult<DtoSurveyInfo> GetQuestions(int surveyID)
        {
            var res = _db.GetQuestionFromSurveyId(surveyID);

            if (res.Count() == 0) return NotFound("No Survey ID found!");

            else
                return new DtoSurveyInfo()
                {
                    SurveyId = res.First().Id,
                    Description = res.First().Description,
                    SurveyTitle = res.First().Title,
                    Questions = res.Select(y => new DtoSurveyQuestionInfo()
                    {
                        QuestionDescription = y.QuestionDescription,
                        AnswerType = y.AnswerTypeId,
                        AnswerDescription = y.AnswerDescription
                    }).ToArray()
                };


        }
    }
}