using Newtonsoft.Json;

namespace SaturdayQuizWeb.Model
{
    public class Question
    {
        public int Number { get; set; }
        public QuestionType Type { get; set; }
        [JsonProperty("question")]
        public string QuestionText { get; set; }
        [JsonProperty("questionHtml")]
        public string QuestionHtml { get; set; }
        [JsonProperty("answer")]
        public string AnswerText { get; set; }
        [JsonProperty("answerHtml")]
        public string AnswerHtml { get; set; }
    }
}
