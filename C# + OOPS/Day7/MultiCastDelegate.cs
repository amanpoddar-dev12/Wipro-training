//// See https://aka.ms/new-console-template for more information
//using System.Runtime.ExceptionServices;



////Delegate - It is type safe that hold a reference to a method 
//// DelegateName my1 = new DelegateName(Print);

////Admin delegate Is responsible generating a invoice;

////Admin a = new Admin(Invoice);
////A delegate also allows methods to be passed as a parameters and invoked dynamically(at runtime)
////It is used to implement event handling


////Syntax   AccessSpecifier delegate void delegate_name(paramater_list)


//class MultiCastDelegate
//{

//    // Delegate Declaration for add operations and Print 
//    // parameterized Delegates responsible for method invocation at runtime
//    public delegate int Operations(int a, int b);

//    public delegate void PrintDelegate(int result);

//    public static void Main9(string[] args)
//    {

//        //Assign Methods to delegates
//        //Member functions are encapsulated using delegate
//        Operations Add = AddNumbers;
//        Operations Subtract = SubtractNumbers;



//        /*int a ;
//        // a =30;
//        ABC a1 = new ABC();
//        AddDelegate ad = AddNumbers;*/


//        // calling/using delegate
//        int sumResult = Add(10, 30);
//        int diffResult = Subtract(10, 30);

//        //Multi cast Delegate
//        PrintDelegate print = PrintResult; // adding first page as printResult method
//        print += PrintResultCalci; // adding second page as printresultcalci method

//        Console.WriteLine("Sum of two numbers :");
//        print(sumResult);
//        Console.WriteLine("Difference of two numbers :");
//        print(diffResult);
//       // Console.WriteLine("Enter your choice 1. for Addition and 2. for subtraction");
//      //  int choice = int.Parse(Console.ReadLine());

        
       

//    }


//    private static int AddNumbers(int x, int y)
//    { return x + y; }

//    private static int SubtractNumbers(int x, int y)
//    { return x - y; }

//    private static void PrintResult(int result)
//    {
//        Console.WriteLine("The result of addition is :" + result);
//    }

//    private static void PrintResultCalci(int result)
//    {
//        result = result * 10;
//        Console.WriteLine("after applying bonus :" + result);
//    }
//}



//// create a delegate for a admin who is responsible for calculating the invoice(int tutionfess , int transportfees)
////and one more delegate which will print the invoice

//// now create two print methods one for printing (Page1 )the actual invoice and second print method (page 2) for deduction of 100% from tution fees
