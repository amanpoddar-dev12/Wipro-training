public class Student
{

    public int ID { get; set; }
    public string Name { get; set; }
    public Dictionary<string, int> SubjectMarks { get; set; }
    public Student(int id, string name, Dictionary<string, int> subjectMarks)
    {
        ID = id;
        Name = name;
        SubjectMarks = subjectMarks;
    }

    public double GetAverage()
    {

        int total = 0;
        foreach (var marks in SubjectMarks.Values)
        {

            total += marks;
        }
        return (double)total / SubjectMarks.Count;
    }
    public void Display()
    {

        //code to display

        Console.WriteLine("Student id:" + ID);
        Console.WriteLine("Student name:" + Name);

        Console.WriteLine("Student Marks:");
        foreach (var subject in SubjectMarks)
        {
            Console.WriteLine(subject.Key + " " + subject.Value);
        }

        Console.WriteLine("Average Marks :" + GetAverage());
    }

}



using System;
using System.Collections.Generic;

class StudentReport
{


    static void Main()
    {
        List<Student> studentList = new List<Student>();
        Console.WriteLine("How many students you want to add");
        int studentCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < studentCount; i++)
        {
            Console.WriteLine("Enter Student ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Number of subjects:");
            int subjectCount = int.Parse(Console.ReadLine());

            Dictionary<string, int> subjectDictionary = new Dictionary<string, int>();


            for (int j = 0; j < subjectCount; j++)
            {

                Console.WriteLine("Enter name of subject:" + (j + 1));
                string subject = Console.ReadLine();

                Console.WriteLine("Enter marks of subject:" + subject);
                int marks = int.Parse(Console.ReadLine());

                subjectDictionary.Add(subject, marks);

            }


            Student student = new Student(id, name, subjectDictionary);
            studentList.Add(student);

            foreach (var studentdata in studentList)
            {
                studentdata.Display();
            }
        }




    }
}

Disadvantages of using Arrays in C#:
1) array size is fixed
2) we can store similar type of elements
3) as we know the array size is fixed  so, if we allocate more memory then it will go waste even if there is no requirement and 
if we allocate less memory that it will create a problem.
4) We cannot insert an element into the middle of an array  .
4) Searching based linear approach and if we have a large list to search with  .

Collections gives an advantage over an Arrays 
1) It is dynamic in nature
2) group  of records / objects for which we are treating it as a one single unit
3) Collections are data structures which is used to store , manage and manipulated groups of 
related objects. 

They are the part of System.Collections and System.Collections.Generic namespaces

Non -generic type of collections:
ArrayList  -- which is a resizable array(Stores object)
HashTable -- Key-Value pair , unordered
Stack -- LIFO structure
Queue -- FIFO structure

List l = new ArrayList();
disadvantage  -- No Type safety  and no of time it requires boxing/ unboxing

Generic type of collections 
List<T>  Dynamic array of a specific type (Integer , String )
Dictionary<K,V> - storing the key-value storage
HashSet<T>   No duplicates allowed
Queue<T> FIFO
StacK<T> - LIFO
SortedList<K,V>  Sorted key-value
LinkedList<T>  Doubly linked list 
ObservableCollections<T> - Notify when data changes(WPF)



