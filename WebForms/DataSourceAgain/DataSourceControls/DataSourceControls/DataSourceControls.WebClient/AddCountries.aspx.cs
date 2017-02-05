using System;
using System.Collections.Generic;
using System.Linq;

using DataSourceControls.Continents;

namespace DataSourceControls.WebClient
{
    public partial class AddCountries : System.Web.UI.Page
    {
        private CountriesDbEntities db;

        private IList<Continent> continents;
        private IList<Country> countries;
        private IList<Language> languages;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.db = new CountriesDbEntities();
                this.UpdateDataBinding();
                Session["db"] = this.db;
            }
            else
            {
                this.db = Session["db"] as CountriesDbEntities;
            }
        }

        protected void OnAddContinent(object sender, EventArgs e)
        {
            var continent = new Continent();
            continent.Id = Guid.NewGuid();
            continent.Name = this.AddContinentName.Text;

            db.Continents.Add(continent);
            db.SaveChanges();

            this.continents = db.Continents.ToList();
            Session["continents"] = this.continents;

            this.AddCountryContinentsDropDownList.DataSource = this.continents;
            this.AddCountryContinentsDropDownList.DataBind();
            this.ClearTextboxes();
        }

        protected void OnAddLanguage(object sender, EventArgs e)
        {
            var language = new Language();
            language.Id = Guid.NewGuid();
            language.Name = this.AddLanguageName.Text;

            db.Languages.Add(language);
            db.SaveChanges();

            this.languages = db.Languages.ToList();
            Session["languages"] = this.languages;

            this.AddCountryLanguagesDropDownList.DataSource = this.languages;
            this.AddCountryLanguagesDropDownList.DataBind();
            this.ClearTextboxes();
        }

        protected void OnAddCountry(object sender, EventArgs e)
        {
            var country = new Country();
            country.Id = Guid.NewGuid();
            country.Name = this.AddCountryName.Text;
            country.Population = int.Parse(this.AddCountryPopulation.Text);

            this.continents = Session["continents"] as IList<Continent>;
            this.languages = Session["languages"] as IList<Language>;

            var continent = this.continents.FirstOrDefault(c => c.Id == Guid.Parse(this.AddCountryContinentsDropDownList.SelectedItem.Value));
            var language = this.languages.FirstOrDefault(l => l.Id == Guid.Parse(this.AddCountryLanguagesDropDownList.SelectedItem.Value));

            country.Continent = continent;
            country.Language = language;

            db.Countries.Add(country);
            db.SaveChanges();

            this.countries = db.Countries.ToList();
            Session["countries"] = this.countries;

            this.ClearTextboxes();
        }

        protected void OnAddTown(object sender, EventArgs e)
        {
            var town = new Town();
            town.Id = Guid.NewGuid();
            town.Name = this.AddTownName.Text;
            town.Population = int.Parse(this.AddTownPopulation.Text);

            this.countries = Session["countries"] as IList<Country>;

            var country = this.countries.FirstOrDefault(c => c.Id == Guid.Parse(this.AddTownCountriesDropDownList.SelectedItem.Value));
            town.Country = country;

            db.Towns.Add(town);
            db.SaveChanges();

            this.ClearTextboxes();
        }

        protected void OnAddFlag(object sender, EventArgs e)
        {
            var flag = new CountryFlag();
            flag.Image = this.FlagFileUpload.FileBytes;
            flag.ImageBase64 = Convert.ToBase64String(flag.Image);

            this.countries = Session["countries"] as IList<Country>;
            var country = this.countries.FirstOrDefault(c => c.Id == Guid.Parse(this.AddFlagCountriesDropDownList.SelectedItem.Value));
            country.CountryFlag = flag;

            db.SaveChanges();

            this.ClearTextboxes();
        }

        private void ClearTextboxes()
        {
            this.AddCountryName.Text = "";
            this.AddCountryPopulation.Text = "";
            this.AddContinentName.Text = "";
            this.AddLanguageName.Text = "";
            this.AddTownName.Text = "";
            this.AddTownPopulation.Text = "";
        }

        private void UpdateDataBinding()
        {
            this.continents = db.Continents.ToList();
            this.languages = db.Languages.ToList();
            this.countries = db.Countries.ToList();

            this.Session["continents"] = this.continents;
            this.Session["languages"] = this.languages;
            this.Session["countries"] = this.countries;

            this.AddCountryContinentsDropDownList.DataSource = this.continents;
            this.AddCountryContinentsDropDownList.DataBind();

            this.AddCountryLanguagesDropDownList.DataSource = this.languages;
            this.AddCountryLanguagesDropDownList.DataBind();

            this.AddTownCountriesDropDownList.DataSource = this.countries;
            this.AddTownCountriesDropDownList.DataBind();

            this.AddFlagCountriesDropDownList.DataSource = this.countries;
            this.AddFlagCountriesDropDownList.DataBind();
        }
    }
}