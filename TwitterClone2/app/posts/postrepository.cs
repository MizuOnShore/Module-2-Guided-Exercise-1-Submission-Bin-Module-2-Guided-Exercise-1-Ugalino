using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace TwitterClone2.app.posts
{
    public class postrepository
    {
        string connectionStiring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\IT114L-A54-18\source\repos\TwitterClone2\TwitterClone2\App_data\TwitterClone.mdf;Integrated Security=True";
        public IEnumerable<post> GetAllPosts()
        {
            using (var connection = new SqlConnection(connectionStiring))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "select * from Posts";
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBy"],
                        PostedOn = (DateTime)row["postedOn"],
                    })
                    .ToList();
            }
        }
        public IEnumerable<post> GetPostUser(string username)
        {
            using (var connection = new SqlConnection(connectionStiring))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = $"select * from Posts where postedBy = @username";
                command.Parameters.AddWithValue("username", username);
                return command
                    .ExecuteReader()
                    .Cast<IDataRecord>()
                    .Select(row => new post()
                    {
                        Content = (string)row["content"],
                        PostedBy = (string)row["postedBy"],
                        PostedOn = (DateTime)row["postedOn"],
                    })
                    .ToList();
            }
        }

        public void CreatePost (post post)
        {
            using (var connection = new SqlConnection(connectionStiring))
            using (var command = connection.CreateCommand())
            {
                connection.Open();
                command.CommandText = "insert into Posts (content, postedOn, postedBy)" +
                     "values (@content, @postedOn, @postedBy)";
                command.Parameters.AddWithValue("content", post.Content);
                command.Parameters.AddWithValue("postedOn", post.PostedOn);
                command.Parameters.AddWithValue("postedBy", post.PostedBy);

                int rowsAffected = command.ExecuteNonQuery();

            }
        }
        //return new List<post>(){
        //    new post()
        //    {
        //    Content = "NI HAO MA",
        //    PostedBy = "gelo",
        //    PostedOn = DateTime.Now,

        //    },
        //    new post ()
        //    {
        //    Content = "NI HAO MA",
        //    PostedBy = "geloooooooooooooooooooooooooooooooooooooooo",
        //    PostedOn = DateTime.Now,
        //    },
        //    new post()
        //    {
        //    Content = "NI HAO MA",
        //    PostedBy = "geloooooooooooooooy",
        //    PostedOn = DateTime.Now,

        //    },
        //};       

    }
}