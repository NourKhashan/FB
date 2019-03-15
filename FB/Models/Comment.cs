using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FB.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public String Description { get; set; }
        [ForeignKey("FBPost")]
        public int FbPostsId { get; set; }
        public virtual FBPost FBPost { get; set; }
    }
}