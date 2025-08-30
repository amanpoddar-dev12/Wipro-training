using System;

public class InvalidAgeException : Exception
{

    public InvalidAgeException()
    //We are calling base class constructor
         : base("Age should be greater than 20 to apply for this job ") { }

    public InvalidAgeException(string message)
     //We are calling base class constructor
     : base(message)
    { }

}

class MainProgram
{

    static void ValidateAge(int age)
    {

        if (age < 20)
        {
            throw new InvalidAgeException();
        }
    }
    static void Main()
    {
        Console.WriteLine("Enter your age");
        int age = int.Parse(Console.ReadLine());

        try
        {

            ValidateAge(age); // If it will throw an exception
            Console.WriteLine("You are eligible");

        }
        catch (InvalidAgeException ex)
        {
            Console.WriteLine(ex.Message);

        }

    }
}

// In C# we donot have throws keyword 
