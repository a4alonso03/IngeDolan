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
    
    public partial class SCENARIO
    {
        public int NUMBER { get; set; }
        public int STORY_ID { get; set; }
        public int BACKLOG_ID { get; set; }
        public int PROJECT_ID { get; set; }
        public string ACCEPTANCE_CRITERIA { get; set; }
        public string CONTEXT { get; set; }
        public string EVENTZ { get; set; }
        public string RESULT { get; set; }
    
        public virtual USER_STORY USER_STORY { get; set; }
    }
}
