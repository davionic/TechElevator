using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPostModel
    {
        public int Id { get; internal set; }
        public string Subject { get; set; }
        public string UserName { get; set; }
        public string Message { get; set; }
        public DateTime SubmittedAt { get; set; }

        public IList<ForumPostModel> Results { get; set; }
    }
}