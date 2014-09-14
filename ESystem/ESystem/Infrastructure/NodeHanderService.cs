using System.Collections.Generic;
using System.Linq;
using ESystem.Models;

namespace ESystem.Infrastructure
{
    public class NodeHanderService
    {
        public Stack<Question> QueStack;
        public Stack<LevelTreeNode> LevelTree = new Stack<LevelTreeNode>();
        private ex_systemEntities _db;
        public Stack<Question> FirstLevelQuestions; 
        public List<int> QuestionAsked = new List<int>(); 

        public NodeHanderService()
        {
            _db = new ex_systemEntities();
        }

        public void InitStack()
        {
            var ques = GetQuestions().Where(x => x.ParentId == 1).ToArray(); //its questions of 1 level of graph
            FirstLevelQuestions = new Stack<Question>(ques);
            QueStack= new Stack<Question>(ques);
        }

        public List<INode> GetAllNodes()
        {
            var nodes = new List<INode>();

            foreach (var node in _db.esNodes)
            {
                if (node.isLeaf)
                {
                    nodes.Add(new Subject(node.idNode, node.data, node.idParentNode));
                }
                else
                {
                    nodes.Add(new Question(node.idNode, node.data, node.idParentNode));
                }
            }
            
            //foreach (var node in nodes)
            //{
            //    node.Parent = nodes.FirstOrDefault(x => x.Id == node.ParentId);
            //}
            return nodes;
        }

        public List<Question> GetQuestions()
        {
            return GetAllNodes().Where(x => x.GetType() == typeof(Question)).Cast<Question>().ToList();
        }

        public List<Subject> GetSubjects()
        {
            return GetAllNodes().Where(x => x.GetType() == typeof(Subject)).Cast<Subject>().ToList();
        }

        public void InsertQuestion(QuestionModel model)
        {
            var question = new Question(model.Id, model.Data, LevelTree.Count > 0 ? LevelTree.Peek().Question.Id : 1);

            LevelTree.Push(new LevelTreeNode(question));
            CreateNode(question);
        }

        public void InsertSubject(SubjectModel model)
        {
            var subject = new Subject(model.Id, model.Data, LevelTree.Peek().Question.Id);

            CreateNode(subject);
        }

        public void CreateAnswer(AnswerModel answer)
        {
            var newAnswer = new esAnswer
            {
                data = answer.Data,
                idNodeQuestion = answer.Question.Id,
            };
            _db.esAnswers.AddObject(newAnswer);
            _db.SaveChanges();
            answer.Id = newAnswer.id;
        }

        public void CompleteCreateAnswer(AnswerModel answer, int idNextNode)
        {
            var answ = _db.esAnswers.First(x => x.id == answer.Id);
            answ.idNodeSubject = idNextNode;
            _db.SaveChanges();
        }

        public void CreateNode(INode node)
        {
            var isLeaf = !(node is Question);
            var newNode = new esNode
            {
                idParentNode = node.ParentId,
                data = node.Data,
                isLeaf = isLeaf
            };
            _db.esNodes.AddObject(newNode);
            _db.SaveChanges();
            newNode.idNode = newNode.id;
            _db.SaveChanges();
            node.Id = newNode.id;
        }

        public void UpdateNode(INode node)
        {
            var toUpdate = _db.esNodes.First(x => x.id == node.Id);
            toUpdate.idNode = node.Id;
            toUpdate.data = node.Data;
            toUpdate.idParentNode = node.ParentId;
            _db.SaveChanges();
        }

        public INode GetNode(int id)
        {
            var node = _db.esNodes.First(x => x.idNode == id);
            return node.isLeaf ? new Subject(node.idNode, node.data, node.idParentNode) :
                (INode)new Question(node.idNode, node.data, node.idParentNode);
        }

        public List<Answer> GetAnswers(int questionId)
        {
            var list = new List<Answer>();

            foreach (var answerNode in _db.esAnswers)
            {
                if (answerNode.idNodeQuestion == questionId)
                {
                    list.Add(new Answer(answerNode.id, answerNode.data, false, answerNode.idNodeSubject));
                }
            }

            return list;
        }
    }
}