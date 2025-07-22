// // See https://aka.ms/new-console-template for more information
// //Console is a predefined class and WriteLine is a method 

// //Source Code -- HLL --- C#

// using System; // using is a keyword to import the namespaces (package)

// class Program
// {

//     // method is in pascal case (eg : AddOperation())
//     static void Main()
//     {
//         int noOfStudent = 5;
//         string[,] sName = new string[5,2];
   

        
//         Console.WriteLine("Enter the name and age of 5 students :");

//         for (int i = 0; i < noOfStudent; i++)
//         {

//             Console.WriteLine("Enter name of student " + (i + 1));
//             sName[i, 0] = Console.ReadLine();

//               Console.WriteLine("Enter age of student " + (i + 1));
//             sName[i, 1] = Console.ReadLine();
            

//         }
//          Console.WriteLine("Student Data :");
//             for (int i = 0; i < 5; i++)
//         {
//             Console.WriteLine("The " + (i+1) + "student name is : " + sName[i,0] + " and age is : "+ sName[i,1]);

//         }

//     }


// }

// //create a single dimensional array to store 5 student names by taking input from an user
// //and then display
