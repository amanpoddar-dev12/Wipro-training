using System.Collections;

class Test
{
    public static void Main(String[] args)
    {
        List<int> studentName = new List<int>();
        ArrayList subject = new ArrayList();
        Stack<int> roll = new Stack<int>();

        studentName.Add(20);
        studentName.Add(30);
        studentName.Add(50);

        subject.Add(100);
        subject.Add("kamims");
        subject.Add("akiksim");


        roll.Push(22);
        roll.Push(33);
        roll.Push(02);
        roll.Push(9);
        roll.Push(4);
        Console.WriteLine(roll.Peek());
        // Console.WriteLine(subject[0]);
        // Console.WriteLine(subject[1]);
        // Console.WriteLine(subject[2]);

    }
}
