using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvaluationTracker.Models;

namespace EvaluationTracker.Controllers
{
    public class Evaluation_FeedbacksController : Controller
    {
        private CandidateEvaluationEntities1 db = new CandidateEvaluationEntities1();

        // GET: Evaluation_Feedbacks
        public ActionResult Index()
        {
            var evaluation_Feedbacks = db.Evaluation_Feedbacks.Include(e => e.Candidate_Details).Include(e => e.Interviewer_Details);
            return View(evaluation_Feedbacks.ToList());
        }

        // GET: Evaluation_Feedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedbacks evaluation_Feedbacks = db.Evaluation_Feedbacks.Find(id);
            if (evaluation_Feedbacks == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_Feedbacks);
        }

        // GET: Evaluation_Feedbacks/Create
        public ActionResult Create()
        {
            ViewBag.Candidate_Id = new SelectList(db.Candidate_Details, "Candidate_Id", "Candidate_Name");
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewer_Details, "DasId", "Interviewer_Name");
            return View();
        }

        // POST: Evaluation_Feedbacks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Eval_Id,Evaluator_DasId,Candidate_Id,Date,Screening_Level,Feedback,Comments")] Evaluation_Feedbacks evaluation_Feedbacks)
        {
            if (ModelState.IsValid)
            {
                db.Evaluation_Feedbacks.Add(evaluation_Feedbacks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidate_Id = new SelectList(db.Candidate_Details, "Candidate_Id", "Candidate_Name", evaluation_Feedbacks.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewer_Details, "DasId", "Interviewer_Name", evaluation_Feedbacks.Evaluator_DasId);
            return View(evaluation_Feedbacks);
        }

        // GET: Evaluation_Feedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedbacks evaluation_Feedbacks = db.Evaluation_Feedbacks.Find(id);
            if (evaluation_Feedbacks == null)
            {
                return HttpNotFound();
            }
            ViewBag.Candidate_Id = new SelectList(db.Candidate_Details, "Candidate_Id", "Candidate_Name", evaluation_Feedbacks.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewer_Details, "DasId", "Interviewer_Name", evaluation_Feedbacks.Evaluator_DasId);
            return View(evaluation_Feedbacks);
        }

        // POST: Evaluation_Feedbacks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Eval_Id,Evaluator_DasId,Candidate_Id,Date,Screening_Level,Feedback,Comments")] Evaluation_Feedbacks evaluation_Feedbacks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluation_Feedbacks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Candidate_Id = new SelectList(db.Candidate_Details, "Candidate_Id", "Candidate_Name", evaluation_Feedbacks.Candidate_Id);
            ViewBag.Evaluator_DasId = new SelectList(db.Interviewer_Details, "DasId", "Interviewer_Name", evaluation_Feedbacks.Evaluator_DasId);
            return View(evaluation_Feedbacks);
        }

        // GET: Evaluation_Feedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluation_Feedbacks evaluation_Feedbacks = db.Evaluation_Feedbacks.Find(id);
            if (evaluation_Feedbacks == null)
            {
                return HttpNotFound();
            }
            return View(evaluation_Feedbacks);
        }

        // POST: Evaluation_Feedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Evaluation_Feedbacks evaluation_Feedbacks = db.Evaluation_Feedbacks.Find(id);
            db.Evaluation_Feedbacks.Remove(evaluation_Feedbacks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
