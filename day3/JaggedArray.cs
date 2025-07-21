using System; // using is a keyword to import the namespaces (package)

class JaggedArray
{

    // method is in pascal case (eg : AddOperation())
    static void Main()
    {
        int noOfStudent = 3;
        //  string[,] sName = new string[5,2];
        string[] sName = new string[noOfStudent];
        string[][] studentSubject = new string[noOfStudent][];



        Console.WriteLine("Let's save name and their subjects of 3 students :");

        for (int i = 0; i < noOfStudent; i++)
        {

            Console.WriteLine("Enter name of student " + (i + 1));
            sName[i] = Console.ReadLine();

            Console.WriteLine("How many subjects you want to store ");
            int subCount = Convert.ToInt32(Console.ReadLine());

            studentSubject[i] = new string[subCount];
            for (int j = 0; j < subCount; j++)
            {
                Console.Write("Enter name of subjects : ");
                studentSubject[i][j] = Console.ReadLine();
                Console.WriteLine(studentSubject[i][j]);
            }

        }
        Console.WriteLine("Student Data name and subject wise :");
        for (int i = 0; i < noOfStudent; i++)
        {
            Console.WriteLine("The " + (i + 1) + "student name is : " + sName[i]);
            for (int j = 0; j < studentSubject[i].Length; j++)
            {
                Console.WriteLine(studentSubject[i][j]);
            }

        }

    }


}
