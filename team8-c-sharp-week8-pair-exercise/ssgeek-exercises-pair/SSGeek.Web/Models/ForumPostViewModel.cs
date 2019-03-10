using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.Models
{
    public class ForumPostViewModel
    {
        
        public IList<ForumPostModel> Results { get; set; }

        public string NewPostResult { get; set; }
    }
}
