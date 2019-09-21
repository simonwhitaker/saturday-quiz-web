using Newtonsoft.Json;

namespace SaturdayQuizWeb.Model
{
    public class Question
    {
        public int Number { get; set; }
        public QuestionType Type { get; set; }
        [JsonProperty("question")]
        public string QuestionText { get; set; }
        public string Answer { get; set; }
    }
}