using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaspberryPuppy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static RaspberryPuppy.Puppy;

namespace RaspberryPuppy.Tests
{
    [TestClass()]
    public class PuppyTests
    {
        private readonly Puppy goodPuppy = new Puppy("Fido", "Labrador", true, SoundSignal.QuietBarking);
        private readonly Puppy nullNamePuppy = new Puppy(null, "Poddle", false, SoundSignal.QuietBarking);
        private readonly Puppy shortNamePuppy = new Puppy("I", "Boxer", false, SoundSignal.LoudBarking);
        private readonly Puppy nullRacePuppy = new Puppy("Bob", null, false, SoundSignal.LoudBarking);
        private readonly Puppy shortRacePuppy = new Puppy("Bob", "M", false, SoundSignal.Silent);
        private readonly Puppy numberRacePuppy = new Puppy("Bob", "123", false, SoundSignal.Silent);
        private readonly Puppy numberNamePuppy = new Puppy("123", "M", false, SoundSignal.Silent);

        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("{Name=Fido, Race=Labrador, NeedToWalk=True, Sounds=QuietBarking}", goodPuppy.ToString());
        }

        [TestMethod()]
        public void ValidateNameTest()
        {
            goodPuppy.ValidateName();
            Assert.ThrowsException<ArgumentNullException>((() => nullNamePuppy.ValidateName()));
        }
        [TestMethod()]
        public void ValidateLetterName()
        {
            Assert.ThrowsException<FormatException>((() => numberNamePuppy.ValidateName()));
        }
        [TestMethod()]
        [DataRow("aa")]
        [DataRow("aaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

        public void ValidateNameInRange(string name)
        {
            var rangePuppy = new Puppy { Name = name, Race = "prut", NeedToWalk = true, Sounds = SoundSignal.Silent };
            rangePuppy.ValidateName();
        }
        [TestMethod()]
        [DataRow("a")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

        public void ValidateNameNegativeInRange(string name)
        {
            var badRangePuppy = new Puppy { Name = name, Race = "hest", NeedToWalk = false, Sounds = SoundSignal.LoudBarking };
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => badRangePuppy.ValidateName()));
        }
        public void ValidateNameLetters()
        {
            Assert.ThrowsException<FormatException>(() => numberNamePuppy.ValidateName());
        }

        [TestMethod()]
        public void ValidateRaceTest()
        {
            goodPuppy.ValidateRace();
            Assert.ThrowsException<ArgumentNullException>((() => nullRacePuppy.ValidateRace()));
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => shortRacePuppy.ValidateRace()));
        }
        public void ValidateRaceLetters()
        {
            Assert.ThrowsException<FormatException>(() => numberRacePuppy.ValidateRace());
        }
        [TestMethod()]
        [DataRow("aa")]
        [DataRow("aaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

        public void ValidateRaceInRange(string race)
        {
            var rangeracePuppy = new Puppy { Name = "Bobeline", Race = race, NeedToWalk = true, Sounds = SoundSignal.Silent };
            rangeracePuppy.ValidateRace();
        }

        [TestMethod()]
        [DataRow("a")]
        [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

        public void ValidateRaceNegativeInRange(string race)
        {
            var badRacePuppy = new Puppy { Name = "oluf", Race = race, NeedToWalk = false, Sounds = SoundSignal.LoudBarking };
            Assert.ThrowsException<ArgumentOutOfRangeException>((() => badRacePuppy.ValidateRace()));
        }

        [TestMethod()]
        public void ValidateTest()
        {
            goodPuppy.ValidateValidate();
        }
    }
}
