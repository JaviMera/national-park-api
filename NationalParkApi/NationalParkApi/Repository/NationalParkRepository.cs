using NationalParkApi.Data;
using NationalParkApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace NationalParkApi.Repository
{
    public sealed class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _context;

        public NationalParkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Remove(nationalPark);
            return Save();
        }

        public bool Exists(string name)
        {
            return _context.NationalParks.Any(park => park.Name.ToLower().Trim().Equals(name.ToLower().Trim()));
        }

        public bool Exists(int parkId)
        {
            return _context.NationalParks.Any(park => park.Id == parkId);
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _context.NationalParks.FirstOrDefault(park => park.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _context.NationalParks
                .OrderBy(park => park.Name)
                .ToList();
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _context.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
