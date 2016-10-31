using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json;

namespace SocialNetwork.Models
{
    /*ImageUrl which is required
    FileExtension with max length 4 which is required
    It has a User*/
    public class Image
    {
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(4)]
        public string FileExtension { get; set; }

        [JsonIgnore]
        public User User { get; set; }
    }
}
