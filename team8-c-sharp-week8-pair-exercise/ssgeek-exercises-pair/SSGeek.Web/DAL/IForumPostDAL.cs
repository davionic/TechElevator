using SSGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSGeek.Web.DAL
{
    public interface IForumPostDAL
    {
        IList<ForumPostModel> GetAllPosts();
        ForumPostModel Create(ForumPostModel forumPost);
       
    }
}
