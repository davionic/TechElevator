using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SSGeek.Web.Models;

namespace SSGeek.Web.DAL
{ 
    public class ForumPostSqlDAL :  IForumPostDAL
    {
        private readonly string _connectionString;

        public ForumPostSqlDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IList<ForumPostModel> GetAllPosts()
        {
            string sql = "SELECT * FROM forum_post ORDER BY post_date DESC";
            IList<ForumPostModel> posts = new List<ForumPostModel>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                var results = command.ExecuteReader();

                while (results.Read())
                {
                    var forumPost = new ForumPostModel
                    {
                        Subject = (string)results["Subject"],
                        UserName = (string)results["Username"],
                        Message = (string)results["Message"],
                        SubmittedAt = (DateTime)results["post_date"]
                    };
                    posts.Add(forumPost);
                }
            }

            return posts;
        }

        public bool SaveNewPost(ForumPostModel post)
        {
            throw new NotImplementedException();
        }

        public ForumPostModel Create(ForumPostModel forumPost)
        {
            string sql = "INSERT INTO forum_post (Subject, UserName, Message) OUTPUT INSERTED.ID VALUES (@subject, @username, @message)";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = sql;
                command.Parameters.AddWithValue("@subject", forumPost.Subject);
                command.Parameters.AddWithValue("@username", forumPost.UserName);
                command.Parameters.AddWithValue("@message", forumPost.Message);

                int id = (int)command.ExecuteScalar();
                forumPost.Id = id;
            }

            return forumPost;
        }
    }
}
