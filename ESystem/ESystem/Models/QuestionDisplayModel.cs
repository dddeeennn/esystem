using System.Collections.Generic;
using ESystem.Infrastructure;

namespace ESystem.Models
{
    public class QuestionDisplayModel
    {
        public Question Question { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public string SelectedAnswerId { get; set; }

        public QuestionDisplayModel()
        {
            Answers = new List<Answer>();
        }

        public QuestionDisplayModel(Question que, IEnumerable<Answer> answers)
            : this()
        {
            Question = que;
            Answers = answers;
        }
    }
}