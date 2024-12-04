using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy
{
    public class Mocking
    {
        private static List<Puppy> _puppiesss = new List<Puppy>()
        {
            new Puppy("Fido", "Shnautzer", false, Puppy.SoundSignal.Silent)
        };

        public static List<Puppy> GetAllPup()
        {
            return _puppiesss;
        }
    }
}