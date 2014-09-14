using System.Collections.Generic;
using System.Linq;
using ESystem.Infrastructure;

namespace ESystem.Models
{
    public class AnswerListModel
    {
        public Question Question { get; set; }
        public List<AnswerModel> Answers { get; set; }
        public AnswerModel NewAnswer { get; set; }

        public AnswerListModel(Question question)
        {
            Question = question;
            Answers = new List<AnswerModel>();
            NewAnswer = new AnswerModel(question);
        }

        public AnswerListModel(Question que, AnswerModel answer)
            : this(que)
        {
            NewAnswer = answer;
        }

        public AnswerListModel(Question question, List<AnswerModel> answers)
            : this(question)
        {
            Answers = answers;
            NewAnswer.Data = answers.Count > 0 ? answers.Last().Data : "";
        }

        public AnswerListModel() { }
    }
}