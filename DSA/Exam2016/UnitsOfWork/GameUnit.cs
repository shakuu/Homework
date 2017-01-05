using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitsOfWork
{
    public class GameUnit
    {
        private int? hash;

        public GameUnit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public override int GetHashCode()
        {
            if (this.hash.HasValue)
            {
                return this.hash.Value;
            }

            this.hash = 103;
            unchecked
            {
                hash = hash * 599 + this.Name.GetHashCode();
                hash = hash * 599 + this.Type.GetHashCode();
                hash = hash * 599 + this.Attack.GetHashCode();
            }

            return this.hash.Value;
        }

        public override bool Equals(object obj)
        {
            var other = obj as GameUnit;
            if (other == null)
            {
                return false;
            }

            var nameIsEqual = this.Name == other.Name;
            var typeIsEqual = this.Type == other.Type;
            var attackIsEqual = this.Attack == other.Attack;

            return nameIsEqual && typeIsEqual && attackIsEqual;
        }

        public override string ToString()
        {
            var toString = string.Format("{0}[{1}]({2})", this.Name, this.Type, this.Attack);
            return toString;
        }
    }
}
