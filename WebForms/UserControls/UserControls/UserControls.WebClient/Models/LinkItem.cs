namespace UserControls.WebClient.Models
{
    public class LinkItem
    {
        public LinkItem(string url, string title)
        {
            this.Url = url;
            this.Title = title;
        }

        public string Url { get; set; }

        public string Title { get; set; }
    }
}