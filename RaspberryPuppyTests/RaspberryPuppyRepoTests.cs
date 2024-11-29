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
        private readonly RaspberryPuppyRepo _repository = new RaspberryPuppyRepo();

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.IsNotNull(_repository.GetAll());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.ThrowsException<ArgumentNullException>(() => _repository.GetByID(0));
            Assert.IsNotNull(_repository.GetByID(5));
        }

        [TestMethod()]
        public void AddTest()
        {
            _repository.Add(new Puppy("Buddy", "Rotweiler", false, Puppy.SoundSignal.LoudBarking));
            IEnumerable<Puppy> puppies = _repository.GetAll();
            Assert.AreEqual(11, puppies.Count());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }
    }
}
