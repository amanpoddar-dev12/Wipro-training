class LoopProgram
{


    static void Main()
    {
        //Syntax of for loop
           // initialization or the starting point ,
           // condition to check wether it has reached to the end point   
           // increment   
        for(int i= 0 ;i<=5 ; i++)
        {
            Console.WriteLine("the value of i is : " + i);
        }
        
        //Syntax of while loop
        int x=0;
        while(x<5)
        {
            Console.WriteLine("The value of x is :" + x);
            x++;
        }

        //Syntax of do While Loop
        int y=5;
        do
        {
            Console.WriteLine("Even if condition is fail the program will execute once");
            y++;

        }
        while(y<1);
    //
      // To use for each loop in case of arrays/collection

      //In an array reference type of variable it's holding multiple values
      string[] names = {"Niti" ,"Jatin","Preeti"};
      //the iteration will do automatically by setting the starting point and ending point
      Console.WriteLine("The element at first index no :" + names[0]);
      foreach(string name in names)
      {
        Console.WriteLine(name);
      }

    }
}
//Single dimensional array
// Array is static in nature means a fixed size 
// int[] numbers = new int[5];

// int[] scores = {45,67,34,67,43};
// //Array is good/fast in searching 

// //MultiDimensional Array
// int[,] matrix = new int[2,3]
// {
           
//     {3,     4,   5},
        
//     {7,    8,    3}
// }

// for(int i=0 ; i<2 ; i++)
// {

//     for(int j=0; j<3 ; j++)
//     {
//         Console.WriteLine(matrix[1][0])
//     }
// }