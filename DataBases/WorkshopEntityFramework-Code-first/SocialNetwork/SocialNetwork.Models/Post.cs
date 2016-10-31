using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    /*Content with min length 10 which is required
        PostenOn field type date
        It has Tagged Users */
    public class Post
    {
        private ICollection<User> taggedUsers;

        public Post()
        {
            this.taggedUsers = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [Column(TypeName = "ntext")]
        [MinLength(10)]
        public string Content { get; set; }

        public DateTime PostedOn { get; set; }

        public virtual ICollection<User> TaggedUsers
        {
            get
            {
                return this.taggedUsers;
            }
            set
            {
                this.taggedUsers = value;
            }
        }
    }
}
