using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterClone2.app.posts;

namespace TwitterClone2
{
    public partial class _default : System.Web.UI.Page
    {
        public IEnumerable<post> posts = new List<post>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var repository = new postrepository();
            posts = repository.GetPostUser("geloy");

            repository.CreatePost(new post() { 
                Content = "new post",
                PostedBy = "geloy",
                PostedOn = DateTime.Now

                });
        }
    }
}