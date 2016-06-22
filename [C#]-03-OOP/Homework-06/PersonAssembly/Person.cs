namespace PersonAssembly
{
    using System;

    public class Person
    {
        private int? age;
        private string name;
        
        public Person(string name)
        {
            this.Name = name;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.Age = age;
        }
        
        public int? Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (!(0 <= value && value <= 250))
                {
                    throw new ArgumentException("Age out of range");
                }

                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Value is null or empty");
                }

                this.name = value;
            }
        }
        
        public override string ToString()
        {
            var format = "Name: {0}, Age: {1}";

            var name = string.IsNullOrEmpty(this.Name) ?
                       "Name is not specified" : this.Name;

            var age = this.Age == null ?
                      "Age is not specified" : this.Age.ToString();

            return string.Format(format, name, age);
        }
    }
}
