
namespace AnimalHierarchy.AbstractModels
{
    using System;
    using Interfaces;
    using Types;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private SexType sex;

        public Animal(string name, int age, SexType sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }

        #region Properties
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                this.name = value;
            }
        }

        virtual public SexType Sex
        {
            get
            {
                return this.sex;
            }
            protected set
            {
                this.sex = value;
            }
        }
        #endregion

        public virtual void MakeASound()
        {
            Console.WriteLine("I am too shy");
        }
    }
}
