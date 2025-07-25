//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//using System;
//class Delegate3
//{
//    public delegate int Admin(int tFees, int tpFees);
//    public delegate void PrintData(int total);
//    static void Main1()
//    {
//        // assigning methods to delegate
//        Admin ad = TotalFess;
//        PrintData p = Show;
//        int res = ad(10000, 2000);
//        p(res);
//    }
//    public static int TotalFess(int tf, int tpf)
//    {
//        int gst = 10;
//        return gst + tf + tpf;
//    }
//    public static void Show(int total)
//    {
//        Console.WriteLine("the total fees is:" + total);
//    }
//}