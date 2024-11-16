using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevelopmentRepairEngine.data.script
{
    public class RequestViewModel
    {
        public DateTime StartDate { get; set; }
        public string TechType { get; set; }
        public string TechFactoryTitle { get; set; }
        public string ModelTitle { get; set; }
        public string Color { get; set; }
        public string ProblemDescription { get; set; }
        public string Status { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string RepairParts { get; set; }
        public string MasterSurname { get; set; }
    }

}
