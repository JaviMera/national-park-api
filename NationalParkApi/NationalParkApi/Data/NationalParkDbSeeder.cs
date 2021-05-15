using NationalParkApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NationalParkApi.Data
{
    public class NationalParkDbSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        public NationalParkDbSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.NationalParks.Any())
                {
                    InsertNationalParksData();
                }
            }
        }

        private void InsertNationalParksData()
        {
            _dbContext.NationalParks.AddRange(new List<NationalPark>
            {
                new NationalPark
                {
                    Name = "Acadia",
                    State = "Maine",
                    Established = new DateTime(1919, 2, 19)
                },
                new NationalPark
                {
                    Name = "Everglades",
                    State = "Florida",
                    Established = new DateTime(1934, 5, 30)
                },
                new NationalPark
                {
                    Name = "Grand Canyion",
                    State = "Arizona",
                    Established = new DateTime(1919, 2, 26)
                },
                new NationalPark
                {
                    Name = "Grand Teton",
                    State = "Wyoming",
                    Established = new DateTime(1929, 2, 26)
                }
            });

            _dbContext.SaveChanges();
        }
    }
}
