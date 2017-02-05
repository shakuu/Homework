using System;

namespace DataSourceControls.Continents
{
    public partial class Town
    {
        public Town()
        {
            this.Id = Guid.NewGuid();
            this.Country = new Country();
            this.Country.Continent = new Continent();
            this.Country.Language = new Language();
        }
    }
}
