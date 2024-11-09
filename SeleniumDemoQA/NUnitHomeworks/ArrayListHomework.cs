using NUnit.Framework;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpBasics
{
    internal class ArrayListHomework
    {
        [Test]
        public void TestSumOfArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            // Act
            int sum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
               sum = sum + numbers[i];
            }

            // Assert
            Assert.That(sum, Is.EqualTo(55));
        }

        [Test]
        public void TestReverseArray()
        {
            // Arrange
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] expectedReversed = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };

            // Act
            int[] reversedArray = new int[numbers.Length]; // Replace null with code to reverse
            int j = 0;
            for (int i = numbers.Length -1; i >=0; i--)
            {
                reversedArray[j++] = numbers[i];
            }
            // Assert
            Assert.That(reversedArray, Is.EqualTo(expectedReversed));
        }

        [Test]
        public void TestReplaceStudentName()
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };
            string newName = "Bob";


            students[1] = newName;

            // Act
            // Implement replacement

            // Assert
            Assert.That(students[1], Is.EqualTo(newName)); // Second student's name should be "Bob"
        }

        [TestCase("Sue", true)]
        [TestCase("Alex", false)]
        public void TestStudentNameExists(string nameToCheck, bool existsExpected)
        {
            // Arrange
            string[] students = new string[] { "John", "Jane", "Bill", "Sue", "Anna" };

            // Act
            bool exists = false; // Replace false with code to get to know if nameToCheck exists in students []
            

            foreach (string student in students)
            {
                if (student.Equals(nameToCheck)) {
                    exists = true; 
                    break;
                }   
            }

            // Assert
            Assert.That(exists, Is.EqualTo(existsExpected));
        }

        [Test]
        public void TestDoubleValues()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedDoubled = new List<int> { 2, 4, 6, 8, 10 };

            // Act
            List<int> doubledNumbers = new List <int> ();

            foreach ( int number in numbers)
            {
                doubledNumbers.Add(number*2);
            }


            // Implement code to fill doubledNumbers with values

            // Assert
            Assert.That(doubledNumbers, Is.EqualTo(expectedDoubled));
        }

        [Test]
        public void TestRemoveEvenNumbers()
        {
            // Arrange
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> expectedList = new List<int> { 1, 3, 5 };

            // Act
            // Implement code to remove extra items
           for (int i = 0; i < numbers.Count;)
           {
                if (numbers[i] % 2 == 0) {
                    numbers.Remove(numbers[i]);
                } else
                {
                    i++;
                }
           }
           

            // Assert
            Assert.That(numbers, Is.EqualTo(expectedList));
        }


        [Test]
        public void TestAddAnimal()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            string newAnimal = "Penguin";
            List<string> expectedList = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra", "Penguin" };


            animals.Add(newAnimal);
            // Act
            // Implement code to add new value

            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }

        [Test]
        public void TestSortAnimals()
        {
            // Arrange
            List<string> animals = new List<string> { "Lion", "Tiger", "Elephant", "Giraffe", "Zebra" };
            List<string> expectedList = new List<string> { "Elephant", "Giraffe", "Lion", "Tiger", "Zebra" };

            // Act
            // Implement code to sort list

            animals.Sort();
            // Assert
            Assert.That(animals, Is.EqualTo(expectedList));
        }
    }
}
