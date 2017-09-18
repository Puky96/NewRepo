using System;
using System.Collections.Generic;

namespace TestAzure.DBModels
{
    public partial class Question
    {
        public Question()
        {
            Questions2Reports = new HashSet<Questions2Reports>();
        }

        public int Id { get; set; }
        public string Question1 { get; set; }
        public string QuestionEnglish { get; set; }
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }

        public Qcategory Category { get; set; }
        public ICollection<Questions2Reports> Questions2Reports { get; set; }
    }
}
