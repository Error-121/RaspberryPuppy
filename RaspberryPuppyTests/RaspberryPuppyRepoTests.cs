using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaspberryPuppy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaspberryPuppy.Tests
{
    [TestClass()]
    public class RaspberryPuppyRepoTests
    {
        //        private readonly RaspberryPuppyRepo _repository = new RaspberryPuppyRepo();

        //        [TestMethod()]
        //        public void GetAllTest()
        //        {
        //            Assert.IsNotNull(_repository.GetAll());
        //        }

        //        [TestMethod()]
        //        public void GetByIdTest()
        //        {
        //            Assert.ThrowsException<ArgumentNullException>(() => _repository.GetByID(0));
        //            Assert.IsNotNull(_repository.GetByID(5));
        //        }

        //        [TestMethod()]
        //        public void AddTest()
        //        {
        //            _repository.Add(new Puppy("Buddy", "Rotweiler", false, Puppy.SoundSignal.LoudBarking));
        //            IEnumerable<Puppy> puppies = _repository.GetAll();
        //            Assert.AreEqual(11, puppies.Count());
        //        }

        //        [TestMethod()]
        //        public void UpdateTest()
        //        {
        //            var Puppy = _repository.GetByID(8);
        //            Puppy.Name = "Messi";
        //            Puppy.Race = "Akita";
        //            Assert.AreEqual("Messi", Puppy.Name);
        //            Assert.AreEqual("Akita", Puppy.Race);
        //        }

        //        [TestMethod()]
        //        public void DeleteTest()
        //        {
        //            Assert.Fail();
        //        }
        [TestMethod()]
        public void testMock()
        {
            List<Puppy> puppyListTest = Mocking.GetAllPup();
            foreach (var puppy in puppyListTest)
            {
                Assert.AreEqual("Fido", puppy.Name);
                Assert.AreEqual("Shnautzer", puppy.Race);
                Assert.AreEqual(false, puppy.NeedToWalk);
                Assert.AreEqual(Puppy.SoundSignal.Silent, puppy.Sounds);
            }
            //Assert.AreEqual(1, puppyListTest.Count);
            //Assert.AreEqual("Fido", puppyListTest[0].Name);
            //Assert.AreEqual("Shnautzer", puppyListTest[1].Race);
            //Assert.AreEqual(false, puppyListTest[2].NeedToWalk);
            //Assert.AreEqual(Puppy.SoundSignal.Silent, puppyListTest[3].Sounds);
        }

    }
}
