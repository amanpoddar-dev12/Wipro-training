//importing Nunit framework and our application
using NUnit.Framework;
using DEmo_MathLibrary_Testing_using_NUnit; // Added this as reference 

namespace MathLibrary.Tests
{
    public class claculatorTests
    {
        private Calculator calcualtor;
        [SetUp] //attributes 
        public void Setup()
        {
            calcualtor = new Calculator();//alocating memory using 'new'
        }

        [Test]
        public void Add_ShouldReturnCorrectSum()
        {
            // Assert.Pass(); for passing the flow of execution
            int result = calcualtor.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));

        }
        [Test] 
        public void Subtract_ShouldReturnCorrectDiffernce()
        {
           // Assert.Pass();
           int result = calcualtor.sub(5,3);
            Assert.That(result,Is.EqualTo(2));
        }
    }
}