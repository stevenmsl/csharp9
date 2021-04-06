using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Collections.Generic;
using System.Linq;

namespace RecordTest
{
    /*
       - A record is a reference type and follows value-based equality semantics. 
       - To enforce value semantics, the compiler generates several methods 
         for your record type:
         - An override of Object.Equals(Object).
         - A virtual Equals method whose parameter is the record type.
         - An override of Object.GetHashCode(). 
         - Methods for operator == and operator !=.
         - Record types implement System.IEquatable<T>. 
    */


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
            // they are different objects though 
            Assert.IsFalse(ReferenceEquals(original, clone));

        }

        [TestMethod]
        public void Test_Record_Deconstruct()
        {
            PersonRec original = new("Arlo", "The Dog");
            // deconstruct
            var (firstName, lastName) = original;
            Assert.IsTrue(firstName == "Arlo");
            Assert.IsTrue(lastName == "The Dog");
        }

        [TestMethod]
        public void Test_Record_Improved_ToString()
        {
            PersonRec original = new("Arlo", "The Dog");
            const string toString = "PersonRec { FirstName = Arlo, LastName = The Dog }";
            
            /*
              - record's ToString spits out more informative string
                than its class counterpart
            */
            Assert.IsTrue(toString == original.ToString()); 

        }

        [TestMethod]
        public void Test_Record_Copy_Then_Mutate()
        {
            PersonRec original = new("Arlo", "The Dog");
            PersonRec mutate = original with { FirstName = "Arlo 2" };
            Assert.IsTrue(mutate.FirstName == "Arlo 2");
        }

        [TestMethod]
        public void Test_Record_Find_Unique()
        {
            List<PersonRec> personRecs = new();
            personRecs.AddRange
            (
                new PersonRec[] 
                    { 
                        new("Arlo","The Dog"),
                        new("Arlo", "The Dog"),
                        new("Arlo 2","The Dog"),
                        new("Arlo 2", "The Dog"),
                    }
            );

            /*
              - Record types implement System.IEquatable<T>
              - so you can just call the Distinct and use
                the default comparer
            */

            Assert.IsTrue(personRecs.Distinct().Count() == 2);
        }

        [TestMethod]
        public void Test_Record_Inheritance()
        {
            EmployeeRec employee = new("Arlo", "The Dog");
            const string result = "EmployeeRec { FirstName = Arlo, LastName = The Dog, FullName = Arlo The Dog }";

            // ToString will include the added properties
            Assert.IsTrue(employee.ToString() == result);

        }

        [TestMethod]
        public void Test_Cls_Equality()
        {
            PersonCls original = new("Arlo", "The Dog");
            PersonCls clone = new("Arlo", "The Dog");

            Assert.IsFalse(Equals(original, clone));
            Assert.IsFalse(original == clone);
            // hash code will be different 
            Assert.IsFalse(original.GetHashCode() == clone.GetHashCode());
            // they are different objects 
            Assert.IsFalse(ReferenceEquals(original, clone));

        } 


    }
}
