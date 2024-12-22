using System.Buffers.Text;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment05
{
    internal class Program
    {
        #region Metods
        #region Question 1
        static void ModifyByValue(int number)
        {
            number += 10; // Change won't reflect outside
            Console.WriteLine($"Inside ModifyByValue: {number}");
        }
        static void ModifyByReference(ref int number)
        {
            number += 10; // Change will reflect outside
            Console.WriteLine($"Inside ModifyByReference: {number}");
        }
        #endregion

        #region Question 2
        static void ModifyReferenceByValue(Person person)
        {
            person.Name = "Haneen"; // This change will reflect outside
            person = new Person { Name = "Rawan" }; // This change won't reflect outside
            Console.WriteLine($"Inside ModifyReferenceByValue: {person.Name}");
        }

        static void ModifyReferenceByReference(ref Person person)
        {
            person.Name = "Haneen"; // This change will reflect outside
            person = new Person { Name = "Rawan" }; // This change will also reflect outside
            Console.WriteLine($"Inside ModifyReferenceByReference: {person.Name}");
        }
        #endregion

        #region Question 3
        static void Calculate(int num1, int num2 , out int sum, out int subtraction)
        {
            sum = num1 + num2;         // Calculate summation
            subtraction = num1 - num2;  // Calculate subtraction
        }
        #endregion

        #region Question 4
        static int CalculateDigitSum(int number)
        {
            int sum = 0;

            // Process each digit
            while (number != 0)
            {
                sum += number % 10; // Extract the last digit and add to sum
                number /= 10;       // Remove the last digit
            }

            return sum;
        }
        #endregion

        #region Question 5
        static bool IsPrime(int number)
        {
            // Handle edge cases
            if (number <= 1)
                return false;

            // Check divisors from 2 to √number
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false; // Not a prime number
            }

            return true; // Prime number
        }
        #endregion

        #region Question 6
        static void MinMaxArray(int[] array, out int min, out int max)
        {
            // Initialize min and max with the first element
            min = array[0];
            max = array[0];

            // Loop through the array to find min and max
            foreach (int num in array)
            {
                if (num < min)
                    min = num;
                if (num > max)
                    max = num;
            }
        }
        // Another Solution
        /*
        static void MinMaxArray(int[] array, ref int min, ref int max)
        {
            /// Initialize min and max with the first element
            min = array[0];
            max = array[0];

            /// Loop through the array to find min and max
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                    min = array[i];
                if (array[i] > max)
                    max = array[i];
            }
         }
         */
        #endregion

        #region Question 7
        static long Factorial(int number)
        {
            // Factorial of negative numbers is not defined
            if (number < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            long result = 1;

            // Multiply numbers from 1 to 'number'
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
        #endregion

        #region Question 8
        static string ChangeChar(string input, int position, char newChar)
        {
            // Check if the position is valid
            if (position < 0 || position >= input.Length)
            {
                throw new ArgumentOutOfRangeException("Position is out of range.");
            }

            // Convert the string to a character array to modify it
            char[] charArray = input.ToCharArray();

            // Replace the character at the specified position
            charArray[position] = newChar;

            // Convert the character array back to a string
            return new string(charArray);
        }

        #endregion
        #endregion
        static void Main(string[] args)
        {
            #region Q1.Explain the difference between passing (Value type parameters) by value and by reference then write a suitable c# example.
            /*
             * Passing by Value:
            - A copy of the actual value is passed to the method.
            - Changes made to the parameter inside the method do not affect the original value 
               outside the method.
            - This is the default behavior for value types in C#.
            * Passing by Reference:
            - A reference to the original value is passed to the method.
            - Changes made to the parameter inside the method directly affect the original value 
              outside the method.
            - Use the ref keyword for passing by reference.
             */

            #region Example

            //int value = 5;

            //// Passing by value
            //Console.WriteLine($"Before ModifyByValue: {value}");
            //ModifyByValue(value);
            //Console.WriteLine($"After ModifyByValue: {value}");

            //// Passing by reference
            //Console.WriteLine($"\nBefore ModifyByReference: {value}");
            //ModifyByReference(ref value);
            //Console.WriteLine($"After ModifyByReference: {value}");
            //
            #endregion

            #endregion

            #region Q2.Explain the difference between passing (Reference type parameters) by value and by reference then write a suitable c# example.
            /*
             * Passing Reference Type by Value:
             - The reference (pointer) to the object is passed by value.
             - Changes made to the object’s data will reflect outside the method, but reassigning the 
               reference inside the method will not affect the original reference outside the method.
             * Passing Reference Type by Reference:
             - The actual reference (pointer) to the object is passed by reference.
             - Changes made to the object’s data or reassigning the reference will directly affect the 
               original object outside the method.
             - Use the ref keyword to pass by reference.
             */

            #region Example

            //Person person = new Person { Name = "Nena" };

            //// Passing reference type by value
            //Console.WriteLine($"Before ModifyReferenceByValue: {person.Name}");
            //ModifyReferenceByValue(person);
            //Console.WriteLine($"After ModifyReferenceByValue: {person.Name}");

            //// Passing reference type by reference
            //Console.WriteLine($"\nBefore ModifyReferenceByReference: {person.Name}");
            //ModifyReferenceByReference(ref person);
            //Console.WriteLine($"After ModifyReferenceByReference: {person.Name}"); 

            #endregion

            #endregion

            #region Q3.Write a c# Function that accept 4 parameters from user and return result of summation and subtracting of two numbers

            //Console.Write("Enter the first number: ");
            //bool isparsed = int.TryParse(Console.ReadLine(), out int num1);

            //Console.Write("Enter the second number: ");
            //bool flag = int.TryParse(Console.ReadLine(), out int num2);

            //// Variables to store results
            //int sum, subtraction;

            //// Call the function
            //Calculate(num1, num2, out sum, out subtraction);

            //if (isparsed && flag)
            //{
            //    // Display the results
            //    Console.WriteLine($"The sum of {num1} and {num2} is: {sum}");
            //    Console.WriteLine($"The difference of {num1} and {num2} is: {subtraction}");
            //}
            //else
            //{
            //    Console.WriteLine("Numbers are not valid");
            //}

            #endregion

            #region  Q4.Write a program in C# Sharp to create a function to calculate the sum of the individual digits of a given number.
            ///Output should be like
            ///Enter a number: 25
            ///The sum of the digits of the number 25 is: 7

            //Console.Write("Enter a number: ");
            //bool isparsed = int.TryParse(Console.ReadLine() , out int number);

            //if (isparsed && number >= 10)
            //{
            //    // Calculate the sum of digits
            //    int digitSum = CalculateDigitSum(Math.Abs(number)); // Use Math.Abs for negative numbers

            //    // Display the result
            //    Console.WriteLine($"The sum of the digits of the number {number} is: {digitSum}");
            //}
            //else
            //{
            //   Console.WriteLine("Number is not valid");
            //}

            #endregion

            #region Q5.Create a function named "IsPrime", which receives an integer number and retuns true if it is prime, or false if it is not.

            //Console.Write("Enter a number: ");
            //bool isparsed = int.TryParse(Console.ReadLine(), out int number);

            //// Check if the number is prime
            //bool result = IsPrime(number);

            //if (isparsed)
            //{
            //    // Display the result
            //    if (result)
            //    {
            //        Console.WriteLine($"The number {number} is a prime number.");
            //    }
            //    else
            //    {
            //        Console.WriteLine($"The number {number} is not a prime number.");
            //    }
            //}
            //else
            //{
            //       Console.WriteLine("Number is not valid");
            //}

            #endregion

            #region Q6.Create a function named MinMaxArray, to return the minimum and maximum values stored in an array, using reference parameters.

            //int[] numbers = { 30, 70, 10, 90, 20, 80 };

            //// Variables to store results
            //int min, max;
            ////int min = 0, max = 0;

            //// Call the function
            //MinMaxArray(numbers, out min, out max);
            ////MinMaxArray(numbers, ref min, ref max);


            //// Display the results
            //Console.WriteLine($"Minimum value in the array: {min}");
            //Console.WriteLine($"Maximum value in the array: {max}");

            #endregion

            #region  Q7.Create an iterative (non-recursive) function to calculate the factorial of the number specified as parameter.

            //Console.Write("Enter a number: ");
            //bool isparsed = int.TryParse(Console.ReadLine() , out int number);

            //if (isparsed)
            //{
            //    // Calculate the factorial
            //    try
            //    {
            //        long result = Factorial(number);
            //        Console.WriteLine($"The factorial of {number} is: {result}");
            //    }
            //    catch (ArgumentException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("The Number is not valid");
            //}

            #endregion

            #region Q8.Create a function named "ChangeChar" to modify a letter in a certain position(0 based) of a string, replacing it with a different letter.

            //string str = "Hello, World!";

            //// Prompt user for input
            //Console.Write("Enter the position of the character to change (0-based index): ");
            //bool isparsed = int.TryParse(Console.ReadLine() , out int position);

            //Console.Write("Enter the new character: ");
            //char newChar = Console.ReadKey().KeyChar; // Read the character from user
            //Console.WriteLine(); // For newline after key press

            //if (isparsed)
            //{
            //    try
            //    {
            //        // Call the ChangeChar function to modify the string
            //        string modifiedString = ChangeChar(str, position, newChar);

            //        // Display the modified string
            //        Console.WriteLine($"Original String: {str}");
            //        Console.WriteLine($"Modified String: {modifiedString}");
            //    }
            //    catch (ArgumentOutOfRangeException ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("The position is not valid");
            //}

            #endregion
        }
    }
}
