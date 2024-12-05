using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
    public class Mocking
    {
        private static List<Personality> _puppiesss = new List<Personality>()
        {
            new Personality("Fido", "Shnautzer", false, Personality.SoundSignal.Silent)
        };

        public static List<Personality> GetAllPup()
        {
            return _puppiesss;
        }
    }
}