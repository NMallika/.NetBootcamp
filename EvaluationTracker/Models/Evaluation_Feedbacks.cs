//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EvaluationTracker.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Evaluation_Feedbacks
    {
        public int Eval_Id { get; set; }
        public string Evaluator_DasId { get; set; }
        public Nullable<int> Candidate_Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Screening_Level { get; set; }
        public string Feedback { get; set; }
        public string Comments { get; set; }
    
        public virtual Candidate_Details Candidate_Details { get; set; }
        public virtual Interviewer_Details Interviewer_Details { get; set; }
    }
}
