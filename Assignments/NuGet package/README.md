# OsziBen.NuGet.SimpleCalculator

## Introduction

**SimpleCalculator** is a straightforward calculator library designed to perform basic arithmetic operations such as addition, subtraction, multiplication, and division. It aims to simplify the implementation of these operations in your applications, allowing developers to focus on building features rather than handling arithmetic logic manually. This package is particularly useful for developers who need a reliable and easy-to-use calculator functionality without the overhead of complex libraries.

## Getting Started

### Requirements

- .NET 9.0 or higher
- Visual Studio or any compatible IDE
- Basic knowledge of C# programming

### Installation

To install the package, use the NuGet package manager with the following command:

    Install-Package OsziBen.NuGet.SimpleCalculator

Or using the .NET CLI:

    dotnet add package OsziBen.NuGet.SimpleCalculator

## Usage
### Basic Example

Here’s a basic example of how to use the SimpleCalculator package:

    using NuGet_package;

    class Program
    {
        static void Main()
        {
            var calculator = new SimpleCalculator();
        
            var sum = calculator.Add(3, 5);
            Console.WriteLine($"Sum: {sum}");

            var difference = calculator.Subtract(10, 4);
            Console.WriteLine($"Difference: {difference}");

            var product = calculator.Multiply(7, 6);
            Console.WriteLine($"Product: {product}");

            var quotient = calculator.Divide(20, 4);
            Console.WriteLine($"Quotient: {quotient}");
        }
    }

### Advanced Features

The SimpleCalculator package also supports the following features:

* Exponentiation: Calculate powers of numbers.
* Square Root: Easily find the square root of a number.

Example:

    var power = calculator.Power(2, 3); // 2 raised to the power of 3
    var sqrt = calculator.SquareRoot(16); // Square root of 16

## Documentation

For more comprehensive documentation, visit the GitHub Documentation.

## Feedback

I welcome your feedback! Please leave any comments or issues on my GitHub Issues page.

## Contributing

I appreciate any contributions! To contribute to the project, please follow these steps:

    Fork the repository.
    Create a new branch for your feature or bug fix.
    Make your changes and commit them with clear messages.
    Push your branch and submit a pull request.

Please read the Contributing Guide for more details on how to contribute.

## License

This project is licensed under the MIT License. For more information, see the LICENSE.

## Contact

If you have any questions, feel free to reach out to me:

    Email: ...
    GitHub: OsziBen
