using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FB.Models
{
    public class FBPost
    {

        public int Id { get; set; }
        [Required]
        public String Description { get; set; }
        public int Like { get; set; }
        public int DisLike { get; set; }

        public virtual List<Comment> Comment { get; set; }
    }
}