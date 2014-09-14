using System.Collections.Generic;

namespace ESystem.Infrastructure
{
    public class LevelTreeNode
    {
        public Question Question { get; set; }
        public List<Answer> Answers { get; set; }

        public LevelTreeNode()
        {
            Answers = new List<Answer>();
        }

        public LevelTreeNode(Question question)
            : this()
        {
            Question = question;
        }

    }
}