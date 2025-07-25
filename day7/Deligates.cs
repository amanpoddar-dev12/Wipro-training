

// // See https://aka.ms/new-console-template for more information
// using System.Runtime.ExceptionServices;
// using static ABC;


// //Delegate - It is type safe that hold a reference to a method 
// // DelegateName my1 = new DelegateName(Print);

// //Admin delegate Is responsible generating a invoice;

// //Admin a = new Admin(Invoice);
// //A delegate also allows methods to be passed as a parameters and invoked dynamically(at runtime)
// //It is used to implement event handling


// //Syntax   AccessSpecifier delegate void delegate_name(paramater_list)


// class ABC
// {

//     // Delegate Declaration for add operations and Print 
//     // parameterized Delegates responsible for method invocation at runtime
//     public delegate int AddDelegate(int a, int b);

//     public delegate void PrintDelegate(int result);

//     public static void Main(string[] args)
//     {

//         //Assign Methods to delegates
//         AddDelegate addDelegate = AddNumbers;

//         /*int a ;
//         // a =30;
//         ABC a1 = new ABC();
//         AddDelegate ad = AddNumbers;*/

//         PrintDelegate print = PrintResult;

//         // calling/using delegate
//         int sum = addDelegate(10, 30);
//         print(sum);

//     }


//     static int AddNumbers(int x, int y)
//     { return x + y; }

//     static void PrintResult(int result)
//     {
//         Console.WriteLine(result);
//     }
// }



// // create a delegate for a admin who is responsible for calculating the invoice(int tutionfess , int transportfees)
// //and one more delegate which will print the invoice