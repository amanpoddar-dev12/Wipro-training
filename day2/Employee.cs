class Employee
{


public void Input()
{


     Console.WriteLine("Enter the first number : ");
              int  a =  Convert.ToInt32(Console.ReadLine());
                   Console.WriteLine("Enter the second number : ");
              int  b =  Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Sum of 2 numbers : " + (a+b));
                Console.ReadKey();
}
   public void Display()
   {
    
    Console.WriteLine("Employee class Method called");

    
   }

}