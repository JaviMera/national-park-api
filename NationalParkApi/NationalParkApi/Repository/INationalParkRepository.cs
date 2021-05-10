using NationalParkApi.Models;
using System.Collections.Generic;

namespace NationalParkApi.Repository
{
    public interface INationalParkRepository
    {
        ICollection<NationalPark> GetNationalParks();
        NationalPark GetNationalPark(int nationalParkId);
        bool Exists(string name);
        bool Exists(int parkId);
        bool CreateNationalPark(NationalPark nationalPark);
        bool UpdateNationalPark(NationalPark nationalPark);
        bool DeleteNationalPark(NationalPark nationalPark);
    }
}
