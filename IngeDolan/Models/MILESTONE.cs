//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IngeDolan.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MILESTONE
    {
        public int MILESTONE_ID { get; set; }
        public int TASK_ID { get; set; }
        public int STORY_ID { get; set; }
        public int BACKLOG_ID { get; set; }
        public int PROJECT_ID { get; set; }
        public Nullable<int> PROGRESS { get; set; }
        public Nullable<System.DateTime> DATES { get; set; }
    
        public virtual TASK TASK { get; set; }
    }
}
