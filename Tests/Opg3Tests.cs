using Microsoft.VisualBasic;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    [TestFixture]
    public class Opg3Tests
    {
        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(100_000, 500_000, 400_001)]  // Veel getallen, keuze uit evenveel
        public void Opg3_01_SizeOk(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = count;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            int actual = stack.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(100_000, 500_000, 400_001)]  // Veel getallen, keuze uit evenveel
        public void Opg3_02_UniqueNumbers(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = count;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            int actual = stack.Distinct().Count<int>();

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestCase(1, 100, 100)]  // 100 getallen, keuze uit 100
        [TestCase(100, 100, 1)]  // 1 getal, keuze uit 1
        [TestCase(1, 100, 4)]  // 4 getallen, keuze uit 100
        [TestCase(-10, 20, 30)] // negatieve lower
        [TestCase(-50, -20, 10)] // negatieve upper en lower
        [TestCase(100_000, 500_000, 400_001)]  // Veel getallen, keuze uit evenveel
        public void Opg3_03_BoundsOk(int lower, int upper, int count)
        {
            // Arrange
            Stack<int> stack;
            int expected = 0;

            // Act
            stack = BAI_Afteken1.Opdr3RandomNumbers(lower, upper, count);
            var out_bounds = stack.Where<int>(num => num < lower || num > upper);
            int actual = out_bounds.Count<int>();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
