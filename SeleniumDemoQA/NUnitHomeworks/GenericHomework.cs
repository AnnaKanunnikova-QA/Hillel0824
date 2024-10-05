using NUnit.Framework;

namespace NUnitHomeworks
{
    internal class GenericHomework
    {
        //Implement GetParameterType so that test pass
        public string GetParameterType<T>(T noNoNo_objectTypeIsNotAcceptable)
        {
            return "Data type: " + typeof(T).ToString();
        }


        [Test]
        public void GenericFunction()
        {
            var intType = GetParameterType(123);
            Assert.That(intType, Is.EqualTo("Data type: System.Int32"));

            var stringType = GetParameterType("some string");
            Assert.That(stringType, Is.EqualTo("Data type: System.String"));

            var doubleType = GetParameterType(new List<double>() { 1.23 });
            Assert.That(doubleType, Is.EqualTo("Data type: System.Collections.Generic.List`1[System.Double]"));
        }

    }
}
