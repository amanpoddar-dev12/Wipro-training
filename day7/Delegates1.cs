using System;

class ABC
{
    public delegate int Admin(int tutionfess, int transportfees);
    public delegate void Printer(int total);

    public delegate int Schlorship(int tutionfess, int dedution);
    static int Calculate(int tutionfess, int transportfees)
    {
        Console.WriteLine("Transport fee " + transportfees);
        int total = tutionfess + transportfees;
        Console.WriteLine("Total amount " + total);
        return total;
    }
    static int CalcSchlorShip(int tutionfess, int dedution)
    {
        Console.WriteLine("Initial tution fee " + tutionfess);
        Console.WriteLine("Schlorship amount " + dedution);
        return tutionfess - dedution;

    }
    static void Print(int total)
    {
        Console.WriteLine("Total fee " + total);

    }
    static void Main(string[] args)
    {
        int tuition = 20000;
        int transport = 3000;
        // Admin calculate = new Admin(Print);
        Schlorship schlorship = CalcSchlorShip;
        int deductedfee = schlorship(tuition, 1000);
        Admin calculate = Calculate;
        Printer print = Print;

        int total = calculate(deductedfee, transport);
        print(total);
    }
}
