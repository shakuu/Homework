namespace StudentsAndWorkers.AbstractModels
{
    using System;

    public abstract class Human
    {
        private string first;
        private string last;

        public Human(string first, string last)
        {
            this.FirstName = first;
            this.LastName = last;
        }

        #region Properties
        public string FirstName
        {
            get
            {
                return this.first;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Empty string");
                }
                else
                {
                    this.first = value;
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.last;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Empty string");
                }
                else
                {
                    this.first = value;
                }
            }
        }


        public string FullName
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
        #endregion

        #region ToStringTest
        //public override string ToString()
        //{
        //    var allProperties = this.GetType()
        //        .GetProperties()
        //        .Where(prop => prop.Name != "FirstName" && prop.Name != "LastName")
        //        .OrderBy(prop => prop.ToString().Length)
        //        .ToArray();

        //    var output = new StringBuilder();
        //    var format = "{0, -6}: {1, 6}";

        //    var len = allProperties.Length;
        //    foreach (var prop in allProperties)
        //    {
        //        var propValue = this.GetType()
        //            .GetProperty(prop.Name)
        //            .GetValue(this);

        //        output.AppendFormat(format, prop.Name, propValue);
        //        output.AppendFormat(", ");
        //    }

        //    return output.ToString().Trim(new[] { ',', ' ' });
        //}
        #endregion
    }
}
