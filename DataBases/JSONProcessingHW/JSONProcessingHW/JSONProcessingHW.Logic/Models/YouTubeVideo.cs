using JSONProcessingHW.Logic.Models.Contracts;

namespace JSONProcessingHW.Logic.Models
{
    public class YouTubeVideo : ITitleUrlModel
    {
        public string Title { get; set; }

        public string Url { get; set; }
    }
}
