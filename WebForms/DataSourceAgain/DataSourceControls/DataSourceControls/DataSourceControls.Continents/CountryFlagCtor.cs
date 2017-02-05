using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceControls.Continents
{
    public partial class CountryFlag
    {
        public CountryFlag(string param)
        {
            this.Id = Guid.NewGuid();
        }
    }
}
