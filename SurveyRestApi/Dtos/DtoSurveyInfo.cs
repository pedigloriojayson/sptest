namespace SurveyRestApi.Dtos
{
    public class DtoSurveyInfo
    {
        public int SurveyId { get; set; }

        public string SurveyTitle { get; set; }

        public string Description { get; set; }

        public DtoSurveyQuestionInfo[] Questions { get; set; }
    }
}
