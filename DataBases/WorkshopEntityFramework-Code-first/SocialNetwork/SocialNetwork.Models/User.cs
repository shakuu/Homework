using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Models
{
    /*Username Unique with [4,20] length which is required
        First name with [2,50] length
        Last name with [2,50] length
        RegisteredOn field type date
        It has Messages, Images, Posts*/
    public class User
    {
        private ICollection<Message> messages;
        private ICollection<Image> images;
        private ICollection<Post> posts;

        public User()
        {
            this.messages = new HashSet<Message>();
            this.images = new HashSet<Image>();
            this.posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public virtual ICollection<Message> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }

        public virtual ICollection<Post> Posts
        {
            get
            {
                return this.posts;
            }

            set
            {
                this.posts = value;
            }
        }
    }
}
