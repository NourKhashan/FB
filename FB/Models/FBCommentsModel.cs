using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FB.Models
{
    public class FBCommentsModel
    {
        // Posts
        public FBPost FBPost { get; set; }
        public List<FBPost> Posts { get; set; }

        // Comment
        public Comment comment { get; set; }
        public List<Comment> comments { get; set; }
    }
}