using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Data.Common.Models;

namespace VetSystem.Data.Models
{
    public class City : BaseModel<int>
    {
        private ICollection<Clinic> clinics;

        public City()
        {
            this.clinics = new HashSet<Clinic>();
        }

        public string Name { get; set; }

        public ICollection<Clinic> Clinics
        {
            get { return this.clinics; }
            set { this.clinics = value; }
        }
    }
}
