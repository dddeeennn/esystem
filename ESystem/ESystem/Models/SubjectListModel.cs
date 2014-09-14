using System.Collections.Generic;

namespace ESystem.Models
{
    public class SubjectListModel
    {
        public AnswerListModel Answers { get; set; }
        public List<SubjectModel> Subjects { get; set; }
        public string SelectedSubjId { get; set; }
        public string SelectedSubjData { get; set; }


        public SubjectListModel()
        {
            Subjects = new List<SubjectModel>();
        }

        public SubjectListModel(List<SubjectModel> subjects, AnswerListModel answers)
            : this()
        {
            Answers = answers;
            Subjects = subjects;
        }
    }
}