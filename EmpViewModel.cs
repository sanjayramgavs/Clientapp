using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientapp
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string Firstname { get; set; } = "";
        public string Lastname { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime? Birthdate { get; set; }
        public DateTime? Hiredate { get; set; }
        public string  city { get; set; } = "";  
        public int? ReportsTo { get; set; }  
    }
}