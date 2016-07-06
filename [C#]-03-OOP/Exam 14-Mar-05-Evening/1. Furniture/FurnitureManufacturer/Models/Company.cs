namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using FurnitureManufacturer.Interfaces;
    using Validation;

    /// <summary>
    /// TODO: Validation
    /// </summary>
    internal class Company : ICompany
    {
        private const int NameStringMinimumLength = 5;
        private const int ReigstrationNumberExactLength = 10;

        private IValidator validator;

        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.furnitures = new HashSet<IFurniture>();

            this.Name = name;
            this.RegistrationNumber = registrationNumber;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                try
                {
                    this.validator = new Validator();

                    this.validator.CheckValidString(
                        value,
                        Company.NameStringMinimumLength,
                        message: string.Format(
                                    this.validator.ValidStringErrorMessage,
                                    nameof(this.Name),
                                    this.GetType().Name));

                    this.name = value;
                }
                catch (Exception)
                {
                    // Continue;
                    throw;
                }
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                try
                {
                    this.validator = new Validator();

                    this.validator.CheckValidString(
                        value,
                        Company.ReigstrationNumberExactLength,
                        Company.ReigstrationNumberExactLength,
                        string.Format(
                            this.validator.ValidStringErrorMessage,
                            nameof(this.Name),
                            this.GetType().Name));

                    this.validator.CheckValidCompanyRegistrationNumber(value);

                    this.registrationNumber = value;

                }
                catch (Exception)
                {
                    // Continue;
                    throw;
                }

                this.validator = null;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return new List<IFurniture>(this.furnitures);
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures
                .Add(furniture);

            this.furnitures = this.SortFurniture();
        }

        private ICollection<IFurniture> SortFurniture()
        {
            var result = this.furnitures.OrderBy(f => f.Price).ThenBy(f => f.Model).ToList();

            return result;
        }

        public void Remove(IFurniture furniture)
        {
            var elementToRemove = this.furnitures.FirstOrDefault(f =>
            {
                var result = 0;

                result = f.GetType() == furniture.GetType() ? result + 1 : result;
                result = f.Material == furniture.Material ? result + 1 : result;
                result = f.Model == furniture.Model ? result + 1 : result;
                result = f.Price == furniture.Price ? result + 1 : result;

                return result == 4;
            }
            );

            if (elementToRemove != null)
            {
                this.furnitures.Remove(elementToRemove);
            }
        }

        public IFurniture Find(string model)
        {
            return this.furnitures
                .FirstOrDefault(furniture => furniture.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            var catalogBuilder = new StringBuilder();

            var catalogHeaderLine = string.Format(
                "{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                this.Furnitures.Count != 0
                    ? this.Furnitures.Count.ToString()
                    : "no",
                this.Furnitures.Count != 1
                    ? "furnitures"
                    : "furniture");

            catalogBuilder.Append(catalogHeaderLine);

            foreach (var furniture in this.Furnitures)
            {
                catalogBuilder.AppendLine();
                catalogBuilder.Append(furniture.ToString());
            }

            return catalogBuilder.ToString();
        }
    }
}
