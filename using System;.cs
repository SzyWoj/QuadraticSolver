using System;

namespace QuadraticSolver
{
    public class QuadraticEquation
    {
        public static (double? x1, double? x2) Solve(double a, double b, double c)
        {
            double delta = b * b - 4 * a * c;
            if (delta < 0)
                return (null, null); // Brak pierwiastków rzeczywistych
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                return (x, null); // Jeden pierwiastek
            }
            else
            {
                double sqrtDelta = Math.Sqrt(delta);
                double x1 = (-b + sqrtDelta) / (2 * a);
                double x2 = (-b - sqrtDelta) / (2 * a);
                return (x1, x2); // Dwa pierwiastki
            }
        }
    }
}

// Projekt testowy: QuadraticSolver.Tests
// Plik: QuadraticEquationTests.cs

using System;
using Xunit;
using QuadraticSolver;

namespace QuadraticSolver.Tests
{
    public class QuadraticEquationTests
    {
        [Theory]
        [InlineData(1, 2, 3, null, null)] // Brak pierwiastków
        [InlineData(1, -2, 1, 1, null)]  // Jeden pierwiastek
        [InlineData(1, -3, 2, 2, 1)]    // Dwa pierwiastki
        public void Solve_ValidCases_ReturnsExpectedResults(double a, double b, double c, double? expectedX1, double? expectedX2)
        {
            var result = QuadraticEquation.Solve(a, b, c);
            Assert.Equal(expectedX1, result.x1);
            Assert.Equal(expectedX2, result.x2);
        }
    }
}