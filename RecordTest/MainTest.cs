using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace RecordTest
{
    [TestClass]
    public class MainTest
    {
        [TestMethod]
        public void Test_Record_Equal_Not_Equal()
        {
            PersonRec original = new("Arlo", "The Dog");
            PersonRec clone = new("Arlo", "The Dog");

            Assert.IsTrue(Equals(original, clone));
            Assert.IsTrue(original == clone);
            // same hash code 
            Assert.IsTrue(original.GetHashCode() == clone.GetHashCode());
            // they are different objects 
            Assert.IsFalse(ReferenceEquals(original, clone));

        }
    }
}
