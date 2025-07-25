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

//     public static void Invoice()
//     {
//         // definition
//         Console.WriteLine("Invoice method called");
//     }
//     //Static method for delegate
//     public static void Show()
//     {
//         Console.WriteLine("Show method called using Delegate");
//     }

//     //Static method for delegate
//     public static void Print()
//     {
//         Console.WriteLine("Print method called using Delegate");

//     }
//     //Single Cast Delegate
//     public static void Print1(int a, int b) { }

//     public delegate void MyShow(); //  this delegate will point to a method
//     public delegate void Printing();
//     public delegate void Admin(); // Declaring a delegate

//     static void Main(String[] args)
//     {

//         MyShow my = new MyShow(Show);
//         Printing my1 = new Printing(Print);
//         Admin a = new Admin(Invoice);// Calling a Delegate
//         my();
//         my();                             
//         a();
//     }




// }

