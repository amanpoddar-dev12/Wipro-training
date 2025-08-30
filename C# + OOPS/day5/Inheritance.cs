// /*Inheritance --- When a child class is inheriting some of the properties of base class 

// In Inheritane we use some conventions like base class , super class , parent class

// similarly we call the class  who has inherited the features of base class as child class,
// sub class , derived class  */

// /*Types of Inheritance*/
// // single inheritance --- There is one base class and one child class

public class Person
{
    //properties 
    protected string Name { get; set; }
    public virtual void Display()
    {
        Console.WriteLine("Displaying Name you entered :");
    }

    public void SetName(string Name)
    {

        this.Name = name;
    }
}

// Single Level
public class Student : Person
{

    // public Student(string name)
    // {
    //     Name = name;
    // }
    public int RollNumber { get; set; }

    public void Study()

    { Console.WriteLine(Name + "is studying :"); }

    static void Main()
    {

        Student stud = new Student();
        //stud.Name = "Niti";
        stud.SetName("Niti");
        stud.RollNumber = 2004;
        stud.Display();
        stud.Study();
    }

}



// /*Inheritance --- When a child class is inheriting some of the properties of base class 

// In Inheritane we use some conventions like base class , super class , parent class

// similarly we call the class  who has inherited the features of base class as child class,
// sub class , derived class  */

// /*Types of Inheritance*/
// // Multilevel inheritance --- There is one base class and one child class and that child will become a base for another child class 

// public class Father
// { 


//     public void FatherDetails()
//     {
//         Console.WriteLine("Father Details :");

//     }
// }
// public class Person : Father
// {
//     //properties 
//     protected string Name { get; set; }
//     public virtual void Display()
//     {
//         Console.WriteLine("Displaying Name you entered :" + Name);
//     }

//     public void setName(string Name)
//     {

//         this.Name = name;
//     }
// }


// public class Student : Person
// {

//     // public Student(string name)
//     // {
//     //     Name = name;
//     // }
//     public int RollNumber { get; set; }

//     public void Study()

//     { Console.WriteLine(Name + "is studying :"); }

//     static void Main()
//     {

//         Student stud = new Student();
//         //stud.Name = "Niti";
//         stud.setName("Niti");
//         stud.RollNumber = 2004;
//         stud.FatherDetails();
//         stud.Display();
//         stud.Study();
//     }

// }

// // Multi level
// public class MainProgram
// {
//     // static void Main()
//     // {

//     //     Student stud = new Student("Niti");
//     //    // stud.Name = "Niti";
//     //     stud.RollNumber = 2004;
//     //     stud.Display();
//     //     stud.Study();
//     // }

// }

// // there is HR --NameOFHR{get; set;} virtual SalaryDisplay() , AdminIncharge override , Employee  Employee e = new Employee(); e.SalaryDisplay()



/*Inheritance --- When a child class is inheriting some of the properties of base class 

In Inheritane we use some conventions like base class , super class , parent class

similarly we call the class  who has inherited the features of base class as child class,
sub class , derived class  */

/*Types of Inheritance*/
// Hierarchical inheritance --- When multiple child classes inherit the same base class

// public class Person
// {
//     //properties 
//     protected string Name { get; set; }
//     public virtual void Display()
//     {
//         Console.WriteLine("Displaying Name you entered :" + Name);
//     }

//     // public void setName(string Name)
//     // {

//     //     this.Name = name;
//     // }
// }


// public class Student : Person
// {

//     // public Student(string name)
//     // {
//     //     Name = name;
//     // }
//     public int RollNumber { get; set; }

//     public void Study()

//     { Console.WriteLine(Name + "is studying :"); }

//     // static void Main()
//     // {

//     //     Student stud = new Student();
//     //     //stud.Name = "Niti";
//     //     stud.setName("Niti");
//     //     stud.RollNumber = 2004;
//     //     stud.FatherDetails();
//     //     stud.Display();
//     //     stud.Study();
//     // }

// }


// public class Teacher : Person
// {
//     public string Subject { get; set; }

//     public void Teaches()
//     {

//         Console.WriteLine(Name + "Teaches Computer Science");
//     }
//     static void Main()
//     {

//         Teacher t = new Teacher();
//         t.Name = "Niti";

//         t.Teaches(); // From child class i.e Teacher
//         t.Display(); // From Base class i.e. Person

//     }

// }

// // there is HR --NameOFHR{get; set;} virtual SalaryDisplay() , AdminIncharge override , Employee  Employee e = new Employee(); e.SalaryDisplay()




// //Multiple Inheritance

// using school;
// public interface ICurricularActivities
// {


//     void Stream();
// }

// public interface INonCurricularActivities
// {

//     void Activities();
// }

// public class Student : Person, ICurricularActivities, INonCurricularActivities
// {

//     public int RollNumber { get; set; }
//     public void Study()
//     {

//     }
//     public void Stream()
//     {
//         Console.WriteLine("Taken Science Stream");
//     }

//     public void Activities()
//     {
//         Console.WriteLine("Sports - BasketBall");
//     }


//     static void Main()
//     {

//         Student s = new Student();
//         Console.WriteLine("Enter the name of student");
//         string sname = Console.ReadLine();
//         s.Name = sname;
//         s.Study();
//         s.Display();
//         s.Stream();
//         s.Activities();
//     }
// }