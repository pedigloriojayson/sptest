namespace SurveyRestApi.Dtos
{
    public class DtoSurveyAnswerInfo
    {
        public int Id { get; set; }

        public KeyValuePair<int, string>[] Options { get; set; }
    }
}
