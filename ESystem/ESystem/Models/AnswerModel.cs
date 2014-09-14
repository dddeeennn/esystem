using ESystem.Infrastructure;

namespace ESystem.Models
{
    public class AnswerModel
    {
        public int Id { get; set; }
        public Question Question { get; set; }
        public string Data { get; set; }
        public INode NextNode { get; set; }
        public bool IsLeaf { get; set; }

        public AnswerModel(Question que)
        {
            Question = que;
        }

        public AnswerModel(Question que, string data, bool isLeaf)
            : this(que)
        {
            Data = data;
            IsLeaf = isLeaf;
        }

        public AnswerModel(Question que, int id, string data, bool isLeaf)
            : this(que, data, isLeaf)
        {
            Id = id;
        }

        public AnswerModel(Answer answer)
        {
            Id = answer.Id;
            Data = answer.Data;
            IsLeaf = answer.IsLeaf;
        }

        public AnswerModel() { }
    }
}