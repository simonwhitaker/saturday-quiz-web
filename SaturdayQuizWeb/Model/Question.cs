namespace SaturdayQuizWeb.Model
{
    public class Question
    {
        public int Number { get; set; }
        public QuestionType Type { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
    }
}