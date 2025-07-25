//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;
//using ConsoleApp2;


//public static class NewService
//{
//    static int x1 = 200;
//    public static void Test4(this OldService ser)
//    {
//        Console.WriteLine("New extension Method :");
//    }

//    public static void Test5(this OldService ser1, int x,int y)
//    {
//        int result = x + y;
//        Console.WriteLine(result);
//        Console.WriteLine(ser1.x);
//    }

//    public static bool IsPalindrome(this string s)
//    {

//       var rev = new string(s.Reverse().ToArray());

//        return s.Equals(rev, StringComparison.OrdinalIgnoreCase);
    
//    }

//    public static bool IsValidEmail(this string email)
//    { 
    
//        return Regex.IsMatch(email , @"^[^@\s]+@[^@\s]+\.[^@\s]+$""");

    
//    }
//    public static void Main()
//    {

//        OldService sobj = new OldService();
//        sobj.Test1();
//        sobj.Test2();
//        sobj.Test4();
//        sobj.Test5(600,700);
//        string s = "Madam";
//        Console.WriteLine( s.IsPalindrome());

//        string input = "niti@gmail.com";
//        if (input.IsValidEmail())
//        {
//            Console.WriteLine("valid email"); 
//        }


//    }
//}