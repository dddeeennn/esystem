using ESystem.Infrastructure;

namespace ESystem.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public int ParentId { get; set; }

        public QuestionModel(Question question)
        {
            Id = question.Id;
            Data = question.Data;
            ParentId = question.ParentId;
        }

        public QuestionModel(int id, string data, int parentId)
        {
            Id = id;
            Data = data;
            ParentId = parentId;
        }

        public QuestionModel(int id, string data)
        {
            Id = id;
            Data = data;
        }

        public QuestionModel(){}
    }
}