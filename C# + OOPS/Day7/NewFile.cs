using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//namespace ConsoleApp2
//{
    //internal class NewFile
    //{

    //    static void Main()
    //    {

    //        int n = 12;

    //        int result = Factorial(n);

    //        Console.WriteLine("The factorial of a no. is : " + result);

    //    }

    //    //Tightly coupled 
    //    static int Factorial(int n)
    //    { 
    //       //Helper Method -- Local Function
    //        int LoopFactorial()
    //        {
    //            int result = 1;
    //            for (int i = 2; i <= n; i++)
    //            { 
    //              result = result * i;
    //            }
    //            return result;


    //        }

    //        return LoopFactorial(); 


    //    }
    //}

    //class ReferenceExample
    //{
    //    static ref int Find(int[] arr, int val) {

    //        // returning a reference to an element in the array
    //        return ref arr[Array.IndexOf(arr, val)];
    //    }

    //    static void Main()
    //    {
    //        int[] data = { 2, 3, 4 };
    //       ref int x =  ref Find(data,3);   // returning data[1]
    //        x = 34;

    //     Console.WriteLine(string.Join(",",data));
    //    }


    //}


    // Indexers -- It allows instances of a class to be indexed just like an array

    //class Employee
    //{
    //    public int id { get; set; }
    //    public string name { get; set; }
    //    Employee(int id, string name)
    //    {
    //        this.id = id;
    //        this.name = name;
    //    }


    //    // modifier type  this[int index or string name]
    //    // Indexer for a Employee class to work as an array while fetching the values 
    //    public Object this[int index]
    //    {
    //        get
    //        {

    //            if (index == 0)
    //                return id;

    //            else if (index == 1)
    //                return name;
    //            else
    //                return null;
    //        }
    //        set
    //        {

    //            if (index == 0)
    //                id = Convert.ToInt32(value);

    //            else if (index == 1)
    //                name = value.ToString();

    //        }




    //    }

    //    class MainProgram
    //    {
    //        public static void Main45()
    //        {
    //            Employee e = new Employee(101, "Niti");
    //            Console.WriteLine(e[0]);

    //           // Console.WriteLine("Enter your age");
    //            if (int.TryParse("12" , out int value))
    //                Console.WriteLine("Value is " + value);

    //            //At the time of taking input in front end itself you can cofirm the value 
    //         //   Console.WriteLine("Even after converting the value is in string format"); 


    //        }
    //    }

    //}
//}


//Delegate , Extension Maths , Value type and reference types , tuple and deconstruction ,
//local function

// reference Local & Return, Indexer ,Out parameter, Pattern Matching , readonly , Async

//Data Structure 





