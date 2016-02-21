using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetSystem.Data.Common.Repositories;
using VetSystem.Data.Models;
using VetSystem.Services.Data.Contracts;

namespace VetSystem.Services.Data
{
    public class CitiesService : ICitiesService
    {
        private IDbRepository<City> cities;

        public CitiesService(IDbRepository<City> cities)
        {
            this.cities = cities;
        }

        public City Create(string name)
        {
            var city = new City
            {
                Name = name
            };

            this.cities.Add(city);
            this.cities.Save();

            return city;
        }

        public IQueryable<City> GetAll()
        {
            var cities = this.cities.All().OrderBy(x => x.Name);

            return cities;
        }

        public City GetById(int id)
        {
            return this.cities.GetById(id);
        }
    }
}
