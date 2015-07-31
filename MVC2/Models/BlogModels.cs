using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using MVC2.Models;

namespace MVC2.Models
{

    public class Post
    {
        public int Id { get; set; }

        public string AuthorId { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:dd MMM}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Created { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM}", ApplyFormatInEditMode = true)]
        public DateTimeOffset? Updated { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Body { get; set; }

        public string MediaURL { get; set; }

        public Post()
        {
            this.Comments = new HashSet<Comment>();
        }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }

    public class Comment
    {

        public int Id { get; set; }
        public int PostId { get; set; }
        [Required]
        public string AuthorId { get; set; } 
        [Required]
        public string Body { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string UpdateReason { get; set; }
        
        public virtual Post Post { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }

}