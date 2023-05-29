using NUnit.Framework;

namespace FactorialApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateFactorial_InputPositiveNumber_ReturnsCorrectFactorial()
        {
            // Arrange
            int number = 5;
            long expectedFactorial = 120;

            // Act
            long actualFactorial = Program.CalculateFactorial(number);

            // Assert
            Assert.That(actualFactorial, Is.EqualTo(expectedFactorial));
        }

        [Test]
        public void CalculateFactorial_InputZero_ReturnsOne()
        {
            // Arrange
            int number = 0;
            long expectedFactorial = 1;

            // Act
            long actualFactorial = Program.CalculateFactorial(number);

            // Assert
            Assert.That(actualFactorial, Is.EqualTo(expectedFactorial));
        }

        [Test]
        public void CalculateFactorial_InputNegativeNumber_ThrowsArgumentException()
        {
            // Arrange
            int number = -5;

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => Program.CalculateFactorial(number));
        }

        [Test]
        public void CalculateFactorial_InputOne_ReturnsOne()
        {
            // Arrange
            int number = 1;
            long expectedFactorial = 1;

            // Act
            long actualFactorial = Program.CalculateFactorial(number);

            // Assert
            Assert.That(actualFactorial, Is.EqualTo(expectedFactorial));                
        }

        [Test]
        public void CalculateFactorial_InputLargeNumber_ReturnsCorrectFactorial()
        {
            // Arrange
            int number = 20;
            long expectedFactorial = 2432902008176640000;

            // Act
            long actualFactorial = Program.CalculateFactorial(number);

            // Assert
            Assert.That(actualFactorial, Is.EqualTo(expectedFactorial));            
        }

    }
}