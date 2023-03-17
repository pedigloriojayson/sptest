namespace SurveyRestApi.DataAccessLayer.Models
{
    public class DbQuestionInfo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string QuestionDescription { get; set; }

        public int AnswerTypeId { get; set; }

        public string AnswerDescription { get; set; }
    }
}
