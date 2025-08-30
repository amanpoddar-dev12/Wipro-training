//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System;
//using System.Runtime.ExceptionServices;
//using static Admin;


//class Admin
//{

//    public delegate int CalculateInvoice(int tutionfess, int transportfees);

//    public delegate void PrintInvoice(int total);

//    public static int GetTotalInvoice(int tutionfess, int transportfees)
//    {
//        return tutionfess + transportfees;
//    }

//    public  static void DisplayInvoice(int total)
//    {
//        Console.WriteLine("Total Invoice Amount :" + total);
//    }
//    public static void Main2(string[] args)
//    {
//       // Admin admin = new Admin();
//        CalculateInvoice cal = GetTotalInvoice;
//        PrintInvoice print = DisplayInvoice;
//        int total = cal(400, 300);
//        print(total);

//    }
//}
