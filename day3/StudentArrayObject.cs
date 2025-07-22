// using System;
// using StudentProgram;
// class StudentArray
// {


//     static void Main()
//     {

//         int studentCount = 2;
//         Student[] students = new Student[studentCount];//Array of student class 
//         // string[][] studentSubject = new string[noOfStudent][];
//         for (int i = 0; i < studentCount; i++)
//         {
//             students[i] = new Student();// With a new keyword object will be created and stored in a memory of a student class 
          
//             Console.WriteLine("Enter name of student");
//             students[i].Name = Console.ReadLine();// setting the value

//             Console.WriteLine("Enter Age of student");
//             students[i].Age = Convert.ToInt32(Console.ReadLine());

//             Console.WriteLine("How many subjects you want to store marks");
//             int subjectCount = Convert.ToInt32(Console.ReadLine());

//             students[i].SubjectMarks = new int[subjectCount];

//             for (int j = 0; j < subjectCount; j++)
//             {

//                 Console.Write("Enter marks for subjects :");
//                 students[i].SubjectMarks[j] = Convert.ToInt32(Console.ReadLine());

//             }


//         }

//         Console.WriteLine("Student obj details are given below :");

//         foreach (Student s in students)
//         {
//             Console.WriteLine(s.Name);// provided the value using get property
//             Console.WriteLine(s.Age);

//             foreach (int marks in s.SubjectMarks)
//             {
//                 Console.WriteLine("Students Marks are : " + marks);
//                     }

//         }
//     }

// }
    
