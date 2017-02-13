using System;

namespace StateManagement.WebClient
{
    public class ApplicationModel
    {
        public ApplicationModel()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int RequestsCount { get; set; }
    }
}