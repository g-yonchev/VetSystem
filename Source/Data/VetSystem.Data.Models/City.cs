namespace VetSystem.Data.Models
{
    using System.Collections.Generic;

    using VetSystem.Data.Common.Models;

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
