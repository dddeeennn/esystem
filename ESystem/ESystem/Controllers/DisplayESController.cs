using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ESystem.Infrastructure;
using ESystem.Models;

namespace ESystem.Controllers
{
    public class DisplayESController : Controller
    {
        public ActionResult Index()
        {
            NodeStore.Ctx.QueStack = null;
            NodeStore.Ctx.FirstLevelQuestions = null;
            NodeStore.UnknowAnswer = 0;
            NodeStore.Ctx.QuestionAsked = new List<int>();
            return View();
        }

        public ActionResult ExecuteES(int? id)
        {
            if (!id.HasValue)
            {
                if (NodeStore.Ctx.QueStack == null) NodeStore.Ctx.InitStack();

                if (NodeStore.Ctx.QueStack.Count == 0) RedirectToAction("DisplaySubject");

                NodeStore.Ctx.FirstLevelQuestions.Pop();
                id = NodeStore.Ctx.QueStack.Pop().Id;
                return RedirectToAction("ExecuteES", new { id });
            }
            var que = NodeStore.Ctx.GetQuestions().First(x => x.Id == id);
            var answers = NodeStore.Ctx.GetAnswers(id.Value);

            var model = new QuestionDisplayModel(que, answers.ToList());
            return View(model);
        }

        [HttpPost]
        public ActionResult ExecuteES(QuestionDisplayModel model)
        {
            var id = int.Parse(model.SelectedAnswerId);

            INode nexNode;

            if (id == 0)
            {
                NodeStore.UnknowAnswer++;
                LoadQuestions(model.Question.Id);

                if (NodeStore.Ctx.QueStack.Count == 0)
                {
                    if (NodeStore.Ctx.FirstLevelQuestions.Count != 0)
                    {
                        NodeStore.Ctx.QueStack.Push(NodeStore.Ctx.FirstLevelQuestions.Pop());
                    }
                    else
                    {
                        if (NodeStore.Ctx.QueStack.Count == 0) return RedirectToAction("DisplaySubject");
                    }
                }

                nexNode = SetNexNode();

                if (nexNode.Id == 1) return RedirectToAction("DisplaySubject");
                if (NodeStore.UnknowAnswer == 7) return RedirectToAction("DisplaySubject");
            }
            else
            {
                NodeStore.UnknowAnswer = 0;
                NodeStore.Ctx.QueStack.Clear();
                var answer = NodeStore.Ctx.GetAnswers(model.Question.Id).First(x => x.Id == id);
                nexNode = NodeStore.Ctx.GetNode(answer.NextNodeId);
                if (NodeStore.Ctx.QuestionAsked.Contains(nexNode.Id)) return RedirectToAction("DisplaySubject");
            }
            NodeStore.Ctx.QuestionAsked.Add(nexNode.Id);
            return RedirectToAction(nexNode.IsLeaf ? "DisplaySubject" : "ExecuteES", new { id = nexNode.Id });
        }

        private static INode SetNexNode()
        {
            if (NodeStore.Ctx.QueStack.Count <= 0) return NodeStore.Ctx.GetNode(1);
            
            var nexNode = NodeStore.Ctx.QueStack.Pop();

            if (NodeStore.Ctx.QuestionAsked.Contains(nexNode.Id))
            {
                SetNexNode();
            }
            else
            {
                return nexNode;
            }
            return NodeStore.Ctx.GetNode(1);
        }

        private static void LoadQuestions(int queId)
        {
            var newQues = NodeStore.Ctx.GetQuestions().Where(x => x.ParentId == queId);

            foreach (var question in newQues)
            {
                NodeStore.Ctx.QueStack.Push(question);
            }

        }

        public ActionResult DisplaySubject(int? id)
        {
            if (!id.HasValue) return View();

            var node = NodeStore.Ctx.GetNode(id.Value);
            var model = new SubjectModel(node.Id, node.Data);
            return View(model);
        }

    }
}
