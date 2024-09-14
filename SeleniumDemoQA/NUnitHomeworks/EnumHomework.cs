using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using static System.Formats.Asn1.AsnWriter;

namespace NUnitHomeworks
{
    // TODO: modify enum so CheckCustomIntNumbersForTestDataAgeEnum pass
    public enum TestDataAge
    {
        Child = 7,
        Teenager = 14,
        Adult = 30
    }

    //TODO: uncomment and implement tests so all Assert pass. Use such LINQ as Any(), Count(), Contains()
    [TestFixture]
    public class EnumHomework
    {
        [Test]
        public void CheckCustomIntNumbersForTestDataAgeEnum()
        {

            Assert.That((int)TestDataAge.Child, Is.EqualTo(7));
            Assert.That((int)TestDataAge.Teenager, Is.EqualTo(14));
            Assert.That((int)TestDataAge.Adult, Is.EqualTo(30));
        }

        [Test]
        public void SomeIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int>() { 5, 14, 15 };

            var isAnyIntCorrespondsToTestDataAge = listOfInt
            .Any(age => new[] { (int)TestDataAge.Child, (int)TestDataAge.Teenager, (int)TestDataAge.Adult }.Contains(age));

            Assert.That(isAnyIntCorrespondsToTestDataAge, Is.True);
        }

        [Test]
        public void NumberOfIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int>() { 5, 14, 15, 30 };

            var numberOfIntCorrespondToTestDataAge = listOfInt
                    .Count(age => new[] { (int)TestDataAge.Child, (int)TestDataAge.Teenager, (int)TestDataAge.Adult }.Contains(age));


            Assert.That(numberOfIntCorrespondToTestDataAge, Is.EqualTo(2));
        }


        [TestCaseSource(nameof(StringlEmentsArePresentInEnumCases))]
        public void StringlEmentsArePresentInEnum(string[] list, int expectedNumberPresent, int expectedNumberExtra, bool areAllPresentExpected, bool areExtraElementsExpected)
        {
            var listOfString = list.ToList();

            var numberOfStringsWhichPresentInEnum = listOfString
                    .Count(age => new[] { TestDataAge.Child.ToString(), TestDataAge.Teenager.ToString(), TestDataAge.Adult.ToString() }.Contains(age));
            var numberOfStringsWhichAreNotPresentInEnum = listOfString
                    .Count(age => !new[] { TestDataAge.Child.ToString(), TestDataAge.Teenager.ToString(), TestDataAge.Adult.ToString() }.Contains(age));
            var areAllPresent = listOfString
                    .All(age => new[] { TestDataAge.Child.ToString(), TestDataAge.Teenager.ToString(), TestDataAge.Adult.ToString() }.Contains(age));
            var areExtraElements = listOfString
                    .Any(age => !new[] { TestDataAge.Child.ToString(), TestDataAge.Teenager.ToString(), TestDataAge.Adult.ToString() }.Contains(age));

            Assert.That(numberOfStringsWhichPresentInEnum, Is.EqualTo(expectedNumberPresent));
            Assert.That(numberOfStringsWhichAreNotPresentInEnum, Is.EqualTo(expectedNumberExtra));
            Assert.That(areAllPresent, Is.EqualTo(areAllPresentExpected));
            Assert.That(areExtraElements, Is.EqualTo(areExtraElementsExpected));

        }

        public static object[] StringlEmentsArePresentInEnumCases =
        {
                new object[] { new string[] { "Child", "Baby", "Teenager", "Eldery", "Adult" }, 3, 2, false, true },
                new object[] { new string[] { "Child", "Teenager", "Adult" }, 3, 0, true, false },
                new object[] { new string[] { "Baby", "Teenager", "Eldery" }, 1, 2, false, true },
                new object[] { new string[] { "Adult", "Child" }, 2, 0, true, false },
                new object[] { new string[] { "Eldery", "Baby" }, 0, 2, false, true },
                new object[] { new string[] { }, 0, 0, true, false },
        };
    }
}
