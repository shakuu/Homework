using System;

namespace EntityFrameworkCodeFirst.Models.SeedModels
{
    public class SeedHomework
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }
    }
}
