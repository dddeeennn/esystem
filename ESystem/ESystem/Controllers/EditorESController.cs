﻿using System.Linq;
using System.Web.Mvc;
using ESystem.Infrastructure;
using ESystem.Models;

namespace ESystem.Controllers
{
    public class EditorESController : Controller
    {
        private readonly TreeNodeFormatter _treeNodeFormatter;

        public EditorESController()
        {
            _treeNodeFormatter = new TreeNodeFormatter();
        }

        //
        // GET: /EditorES/
        public ActionResult Index()
        {
            NodeStore.Ctx.LevelTree.Clear();
            NodeStore.TmpNode = null;
            return View();
        }

        public ActionResult AddQuestion()
        {
            return View();
        }

        public ActionResult EditExistingQuestion()
        {
            var questions = NodeStore.Ctx.GetQuestions();

            var model = new QuestionListModel
            {
                Questions = questions.Select(question => new QuestionModel(question)).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditExistingQuestion(QuestionListModel model)
        {
            var que = NodeStore.Ctx.GetNode(int.Parse(model.SelectedQuestionId));
           // var que = new QuestionModel(int.Parse(model.SelectedQuestionId), model.SelectedQuestionData);

           // NodeStore.Ctx.InsertQuestion(que);

            var levelNode = new LevelTreeNode(new Question(que.Id,que.Data,que.ParentId));
            levelNode.Answers.AddRange(NodeStore.Ctx.GetAnswers(que.Id));
            NodeStore.Ctx.LevelTree.Push(levelNode);
            
            return RedirectToAction("AddAnswer");
        }

        private void LoadLevelNode(int id)
        {
            var levelNode = NodeStore.Ctx.LevelTree.Peek();

            levelNode.Answers.AddRange(NodeStore.Ctx.GetAnswers(id));
        }

        public ActionResult InputQuestion()
        {
            return View();
        }

        [HttpPost]
        public ActionResult InputQuestion(QuestionModel model)
        {
            NodeStore.Ctx.InsertQuestion(model);

            return RedirectToAction("AddAnswer");
        }

        public ActionResult AddAnswer()
        {
            var levelNode = NodeStore.Ctx.LevelTree.Peek();

            if (NodeStore.TmpNode != null)
            {
                NodeStore.Ctx.CompleteCreateAnswer(new AnswerModel(NodeStore.TmpNode.Answers.Last()), levelNode.Question.Id);
                NodeStore.TmpNode = null;
            }

            return View(new AnswerListModel(levelNode.Question,
                levelNode.Answers.Select(x => new AnswerModel(x)).ToList()));
        }

        [HttpPost]
        public ActionResult AddAnswer(AnswerListModel model)
        {
            var levelNode = NodeStore.Ctx.LevelTree.Peek();

            model.NewAnswer.Question = model.Question;
            NodeStore.Ctx.CreateAnswer(model.NewAnswer);
            levelNode.Answers.Add(new Answer(model.NewAnswer.Id, model.NewAnswer.Data, model.NewAnswer.IsLeaf));

            NodeStore.TmpNode = levelNode;
            return RedirectToAction(model.NewAnswer.IsLeaf ? "AddSubject" : "AddQuestion");
        }

        public ActionResult AddSubject()
        {
            return View();
        }

        public ActionResult NextQuestions()
        {
            NodeStore.TmpNode = NodeStore.Ctx.LevelTree.Pop();
            NodeStore.TmpNode = null;
            if (NodeStore.Ctx.LevelTree.Count > 0)
            {
                return RedirectToAction("AddAnswer");
            }
            
            return RedirectToAction("AddQuestion");
        }

        public ActionResult SelectExistingSubject()
        {
            var subjects = NodeStore.Ctx.GetSubjects();
            var model = new SubjectListModel
            {
                Subjects = subjects.Select(s => new SubjectModel(s)).ToList(),
                Answers = new AnswerListModel(
                    NodeStore.Ctx.LevelTree.Peek().Question,
                    NodeStore.Ctx.LevelTree.Peek().Answers.
                        Select(x => new AnswerModel(x)).ToList())
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult SelectExistingSubject(SubjectListModel model)
        {
            var subj = new SubjectModel(int.Parse(model.SelectedSubjId), model.SelectedSubjData);

            NodeStore.Ctx.InsertSubject(subj);

            var answer = NodeStore.Ctx.LevelTree.Peek().Answers.Last();

            NodeStore.Ctx.CompleteCreateAnswer(new AnswerModel(answer), subj.Id);

            return RedirectToAction("AddAnswer");
        }

        public ActionResult ListQueEditor()
        {
            var model = NodeStore.Ctx.GetQuestions();
            return View(model);
        }

        public ActionResult ListSubjEditor()
        {
            var model = NodeStore.Ctx.GetSubjects();
            return View(model);
        }

        public ActionResult DisplayQueTree()
        {
            return View();
        }

        public ActionResult GetQueTree()
        {
            var model = _treeNodeFormatter.Get().Root;
            return new JsonCamelCaseResult(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveQue(int id, string data, int parentId)
        {
            try
            {
                NodeStore.Ctx.UpdateNode(new Question(id, data, parentId));
                return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RemoveNode(int id)
        {
            try
            {
                NodeStore.Ctx.RemoveNode(id);
                return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult InputSubject()
        {
            return View(new SubjectModel(NodeStore.Ctx.LevelTree.Peek()));
        }

        [HttpPost]
        public ActionResult InputSubject(SubjectModel model)
        {
            var subject = new Subject(model.Id, model.Data, model.ParentId);
            NodeStore.Ctx.CreateNode(subject);

            var answer = NodeStore.Ctx.LevelTree.Peek().Answers.Last();

            NodeStore.Ctx.CompleteCreateAnswer(new AnswerModel(answer), subject.Id);

            NodeStore.TmpNode = null;

            return RedirectToAction("AddAnswer");
        }
    }
}
