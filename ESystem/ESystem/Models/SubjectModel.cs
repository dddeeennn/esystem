using System.Linq;
using ESystem.Infrastructure;

namespace ESystem.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int ParentId { get; set; }
        public AnswerListModel Answers { get; set; }

        public SubjectModel(LevelTreeNode node)
        {
            ParentId = node.Question.Id;
            Answers = new AnswerListModel(node.Question, node.Answers.Select(x => new AnswerModel(x)).ToList());
        }

        public SubjectModel(Subject subject)
        {
            Id = subject.Id;
            Data = subject.Data;
            ParentId = subject.ParentId;
        }
        public SubjectModel(Subject subject, AnswerListModel answer)
            : this(subject)
        {
            Answers = answer;
        }

        public SubjectModel() { }

        public SubjectModel(int id, string data)
            : this(id, data, 0)
        {

        }

        public SubjectModel(int id, string data, int parentId)
        {
            Id = id;
            Data = data;
            ParentId = parentId;
        }
    }
}