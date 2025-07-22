using System; //package name -- > imported the built in package

namespace CalculatorOperations // --> namespace declaration

{

    internal class Program
    {
        //main is the entry point of your program
        static void Main(string[] args)
        {

          //  unsafe
            {
              //  int number = 456;
                //   int* ptr = &number;

                int a ;
                int b ;




                //   Console.WriteLine($"Value : {number} ");
                //   Console.WriteLine($"The address : {(int)ptr}");



                Console.WriteLine("Enter the first number : ");
                a =  Convert.ToInt32(Console.ReadLine());
                   Console.WriteLine("Enter the second number : ");
                b =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sum of 2 numbers : " + (a+b));
                Console.ReadKey();
            }
        }


    }
}



