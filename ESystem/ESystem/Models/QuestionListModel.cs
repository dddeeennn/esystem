using System.Collections.Generic;

namespace ESystem.Models
{
    public class QuestionListModel
    {
        public List<QuestionModel> Questions { get; set; }
        public string SelectedQuestionId { get; set; }
        public string SelectedQuestionData { get; set; }

        public QuestionListModel()
        {
            Questions = new List<QuestionModel>();
        }

    }
}