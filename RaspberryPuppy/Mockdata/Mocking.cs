using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
    public class Mocking
    {
        private static List<Personality> _MockPersonality = new List<Personality>()
        {
            new Personality(4020, "MessiRonaldo", "Beagle", 10, "Mellemfornøjet", "Male")
        };

        private static List<TripData> _MockTrip = new List<TripData>()
        {
            new TripData("Roskilde", 3, 20)
        };

        public static List<Personality> GetAllPersonality()
        {
            return _MockPersonality;
        }

        public static List<TripData> GetAllTrips()
        {
            return _MockTrip;
        }
    }
}