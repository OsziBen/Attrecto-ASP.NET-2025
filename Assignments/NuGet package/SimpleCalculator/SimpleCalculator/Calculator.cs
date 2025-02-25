using System;

namespace SimpleCalculator
{
    public class Calculator
    {
        private void ValidateInputs(double a, double b)
        {
            if (double.IsInfinity(a) || double.IsInfinity(b))
            {
                throw new OverflowException("Input values cannot be infinite.");
            }

            if (double.IsNaN(a) || double.IsNaN(b))
            {
                throw new ArgumentException("Input values cannot be NaN.");
            }
        }

        // ADD
        public double Add(double a, double b)
        {
            ValidateInputs(a, b);

            double result = a + b;

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");   
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // SUBTRACT
        public double Subtract(double a, double b)
        {
            ValidateInputs(a, b);

            double result = a - b;

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // MULTYPLY
        public double Multiply(double a, double b)
        {
            ValidateInputs(a, b);

            double result = a * b;

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // DIVIDE
        public double Divide(double a , double b)
        {
            ValidateInputs(a, b);

            if (b == 0)
            {
                throw new DivideByZeroException("The denominator cannot be zero.");
            }

            double result = a / b;

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // MODULO
        public double Modulo(double a, double b)
        {
            ValidateInputs(a, b);

            if (b == 0)
            {
                throw new DivideByZeroException("The denominator cannot be zero.");
            }

            double result = a % b;

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // POWER
        public double Power(double baseValue, double exponent)
        {
            ValidateInputs(baseValue, exponent);

            if (baseValue == 0 && exponent == 0)
            {
                throw new ArgumentException("The result is undefined for 0 and 0.");
            }

            double result = Math.Pow(baseValue, exponent);

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

        // SQUAREROOT
        public double SquareRoot(double value)
        {
            if (double.IsInfinity(value))
            {
                throw new OverflowException("Input value cannot be infinite.");
            }

            if (double.IsNaN(value))
            {
                throw new ArgumentException("Input value cannot be NaN.");
            }

            if (value < 0)
            {
                throw new ArgumentException("Input value cannot be negative for square root operation.");
            }

            double result = Math.Sqrt(value);

            if (double.IsInfinity(result))
            {
                throw new OverflowException("The operation resulted in an infinite value.");
            }

            if (double.IsNaN(result))
            {
                throw new ArgumentException("The operation resulted in a NaN value.");
            }

            return result;
        }

    }
}
