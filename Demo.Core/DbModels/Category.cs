using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Core.DbModels
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryNameArabic { get; set; }
        public bool? ShowArabicName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Description { get; set; }
    }
}
