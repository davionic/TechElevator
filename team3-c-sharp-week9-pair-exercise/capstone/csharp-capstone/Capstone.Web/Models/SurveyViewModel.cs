using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class SurveyViewModel
    {
        public List<Survey> SurveyResults { get; set; } = new List<Survey>();
        public Dictionary<string, int> SurveyTally { get; set; } = new Dictionary<string, int>();
    }
}
