using SurveyRestApi.DataAccessLayer.Models;

namespace SurveyRestApi.DataAccessLayer
{
    public interface IDb
    {


        public IEnumerable<DbQuestionInfo> GetQuestionFromSurveyId(int id);

        public IEnumerable<DbAnswerInfo> GetOptionalAnswersFromSurveyId(int id);

    }
}
