using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaspberryPuppy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static RaspberryPuppy.Personality;

namespace RaspberryPuppy.Tests
{
    //[TestClass()]
    //public class PuppyTests
    //{
    //    private readonly Personality goodPuppy = new Personality("Fido", "Labrador", true, SoundSignal.QuietBarking);
    //    private readonly Personality nullNamePuppy = new Personality(null, "Poddle", false, SoundSignal.QuietBarking);
    //    private readonly Personality shortNamePuppy = new Personality("I", "Boxer", false, SoundSignal.LoudBarking);
    //    private readonly Personality nullRacePuppy = new Personality("Bob", null, false, SoundSignal.LoudBarking);
    //    private readonly Personality shortRacePuppy = new Personality("Bob", "M", false, SoundSignal.Silent);
    //    private readonly Personality numberRacePuppy = new Personality("Bob", "123", false, SoundSignal.Silent);
    //    private readonly Personality numberNamePuppy = new Personality("123", "M", false, SoundSignal.Silent);

    //    [TestMethod()]
    //    public void ToStringTest()
    //    {
    //        Assert.AreEqual("{Name=Fido, Race=Labrador, NeedToWalk=True, Sounds=QuietBarking}", goodPuppy.ToString());
    //    }

    //    [TestMethod()]
    //    public void ValidateNameTest()
    //    {
    //        goodPuppy.ValidateName();
    //        Assert.ThrowsException<ArgumentNullException>((() => nullNamePuppy.ValidateName()));
    //    }
    //    [TestMethod()]
    //    public void ValidateLetterName()
    //    {
    //        Assert.ThrowsException<FormatException>((() => numberNamePuppy.ValidateName()));
    //    }
    //    [TestMethod()]
    //    [DataRow("aa")]
    //    [DataRow("aaa")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

    //    public void ValidateNameInRange(string name)
    //    {
    //        var rangePuppy = new Personality { Name = name, Race = "prut", NeedToWalk = true, Sounds = SoundSignal.Silent };
    //        rangePuppy.ValidateName();
    //    }
    //    [TestMethod()]
    //    [DataRow("a")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

    //    public void ValidateNameNegativeInRange(string name)
    //    {
    //        var badRangePuppy = new Personality { Name = name, Race = "hest", NeedToWalk = false, Sounds = SoundSignal.LoudBarking };
    //        Assert.ThrowsException<ArgumentOutOfRangeException>((() => badRangePuppy.ValidateName()));
    //    }
    //    public void ValidateNameLetters()
    //    {
    //        Assert.ThrowsException<FormatException>(() => numberNamePuppy.ValidateName());
    //    }

    //    [TestMethod()]
    //    public void ValidateRaceTest()
    //    {
    //        goodPuppy.ValidateRace();
    //        Assert.ThrowsException<ArgumentNullException>((() => nullRacePuppy.ValidateRace()));
    //        Assert.ThrowsException<ArgumentOutOfRangeException>((() => shortRacePuppy.ValidateRace()));
    //    }
    //    public void ValidateRaceLetters()
    //    {
    //        Assert.ThrowsException<FormatException>(() => numberRacePuppy.ValidateRace());
    //    }
    //    [TestMethod()]
    //    [DataRow("aa")]
    //    [DataRow("aaa")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

    //    public void ValidateRaceInRange(string race)
    //    {
    //        var rangeracePuppy = new Personality { Name = "Bobeline", Race = race, NeedToWalk = true, Sounds = SoundSignal.Silent };
    //        rangeracePuppy.ValidateRace();
    //    }

    //    [TestMethod()]
    //    [DataRow("a")]
    //    [DataRow("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]

    //    public void ValidateRaceNegativeInRange(string race)
    //    {
    //        var badRacePuppy = new Personality { Name = "oluf", Race = race, NeedToWalk = false, Sounds = SoundSignal.LoudBarking };
    //        Assert.ThrowsException<ArgumentOutOfRangeException>((() => badRacePuppy.ValidateRace()));
    //    }

    //    [TestMethod()]
    //    public void ValidateTest()
    //    {
    //        goodPuppy.ValidateValidate();
    //    }
    //}
}
